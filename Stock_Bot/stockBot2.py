import requests
from bs4 import BeautifulSoup
import telepot
from telepot.loop import MessageLoop
import time
import pandas as pd
import os

my_token = '8122523141:AAE_XLPGXdpa_kcu0TUWnC62O5ZxIyMOP_E'
telegram_id = '5996719385'
bot = telepot.Bot(my_token)

# KRX 상장법인 목록 다운로드
def download_krx_stock_list(filepath='CORP_LIST.xlsx'):
    url = 'https://kind.krx.co.kr/corpgeneral/corpList.do?method=download'
    headers = {'User-Agent': 'Mozilla/5.0'}
    try:
        res = requests.get(url, headers=headers)
        res.raise_for_status()
        with open(filepath, 'wb') as f:
            f.write(res.content)
        print(f"'{filepath}' 다운로드 완료.")
    except requests.exceptions.RequestException as e:
        print(f"파일 오류: {e}")
        return False
    return True

# 종목 코드 조회
def get_stock_code(name, filepath='CORP_LIST.xlsx'):
    if not os.path.exists(filepath):
        print("다운로드 시작")
        if not download_krx_stock_list(filepath):
            return None
    try:
        df = pd.read_html(filepath, encoding='cp949')[0]
#        print(df.columns)
        result = df[df['회사명'] == name]

        if not result.empty:
            return result.iloc[0]['종목코드']
        else:
            return None
    except Exception as e:
        print(f"조회 오류: {e}")
        os.remove(filepath)
        return None


# 주가 조회
def get_price(code):
    if not code:
        return '유효하지 않은 종목 코드'
    url = f'https://finance.naver.com/item/main.naver?code={code}'
    headers = {'User-agent': 'Mozilla/5.0'}
    try:
        result = requests.get(url, headers=headers)
        result.raise_for_status()
        bs_obj = BeautifulSoup(result.content, 'html.parser')
        today_div = bs_obj.find('div', {'class': 'today'})
        if not today_div:
            return '주가 정보 없음'
        price_em = today_div.find('em')
        if not price_em:
            return '주가 정보 없음'
        price = price_em.select_one('span.blind').text
        return price

    except requests.exceptions.RequestException as e:
        print(f"요청 오류: {e}")
        return '주가 정보 요청 실패'
    except AttributeError as e:
        print(f"파싱 오류: {e}")
        return '파싱 실패'


# 메시지 핸들러
def handle(msg):
    content_type, chat_type, chat_id = telepot.glance(msg)
    if content_type != 'text':
        bot.sendMessage(chat_id, '텍스트 오류')
        return
    name = msg['text'].strip()
    print(f"수신 메시지: {name} (from: {chat_id})")
    if name == '/start':
        bot.sendMessage(chat_id, '주식 챗봇 실행. 회사명 입력. (예: 삼성전자)')
        return

    code = get_stock_code(name)

    if code:
        price = get_price(code)
        bot.sendMessage(chat_id, f"**{name}**\n현재가: **{price}**원\n(종목코드: {code})", parse_mode='Markdown')
        print(f"**{name}**\n현재가: **{price}**원\n(종목코드: {code})")
    else:
        bot.sendMessage(chat_id, f"{name}을 찾을 수 없음")
        print(f"{name}을 찾을 수 없음")

if __name__ == "__main__":
    print('프로그램 시작')
    MessageLoop(bot, handle).run_as_thread()
    while True:
        time.sleep(10)
