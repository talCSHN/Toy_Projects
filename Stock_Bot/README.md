# 📈 라즈베리파이 + 텔레그램 주식조회 봇

> 한국거래소(KRX) 데이터를 이용하여 **종목명을 입력하면 실시간 현재가를 알려주는 텔레그램 봇**  
> 본 프로그램은 Raspberry Pi Linux 환경에서 동작함

https://github.com/user-attachments/assets/c7e23d2a-f426-47b2-a6b6-c9888baa24d5

---

## 🛠️ 기술스택 및 개발환경

| 구분       | 내용                                      |
|------------|-------------------------------------------|
| 언어     | Python 3.11 (라즈베리파이 v5 환경에서 테스트) |
| 주요 라이브러리 | `pandas`, `requests`, `telepot`, `lxml` |
| 플랫폼  | Telegram Bot API                         |
| 데이터  | KRX 상장법인목록 (http://kind.krx.co.kr) |
| OS | Raspberry Pi OS (Linux 기반)             |

---

## 서비스 로직

1. 사용자가 텔레그램 앱에서 봇에게 **종목명** 입력  
2. **KRX 상장법인목록 Excel 파일(CORP_LIST.xlsx)** 다운로드
3. 입력한 종목명 기준으로 **종목 코드 자동 탐색**  
4. 종목 코드 기반으로 **네이버 금융에서 현재가 크롤링**  
5. 텔레그램으로 실시간 응답 전송  

---

## 🧠 프로그램 흐름 요약

```text
사용자 메시지 (예: 삼성전자)
        ↓
 get_stock_code(name)
        ↓  (없으면)
 download_krx_stock_list() ← KRX Excel
        ↓
종목코드 반환 (예: 005930)
        ↓
 get_price(code) → 네이버 금융 HTML 파싱
        ↓
 bot.sendMessage(chat_id, 현재가 전송)
```

```bash
(env) $ python stockBot2.py
프로그램 시작
수신 메시지: 삼성전자 (from: 5996719385)
다운로드 시작
'CORP_LIST.xlsx' 다운로드 완료.
Index(['회사명', '종목코드', ...])
[삼성전자] 현재가: 82,100원
```

## 실제 텔레그램 화면
![KakaoTalk_20250721_183933943](https://github.com/user-attachments/assets/1d665cd5-8faf-4979-8e7d-3fe2766905d0)

## 🧯Trouble Shooting
| 문제                                   | 원인                              | 해결 방법                       |
| ------------------------------------ | ------------------------------- | --------------------------- |
| `Missing optional dependency 'lxml'` | `pandas.read_html()`에 필수 의존성 누락 | `pip install lxml` 설치       |
| `File is not a zip file`             | 실제 Excel이 아닌 HTML 다운로드 됨        | `read_html()`로 처리 (HTML 파싱) |
| 한글 컬럼명이 깨져서 오류                       | 인코딩 오류 (`CORP_LIST.xlsx`)       | `utf-8` 또는 `euc-kr`로 대응     |
| `'회사명' 키 오류`                         | `read_html()`은 DataFrame 리스트 반환 | `df_list[0]['회사명']` 사용      |
