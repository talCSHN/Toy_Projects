# Toy_Projects
## 토이프로젝트 모음 리포지토리

# 📈 라즈베리파이 + 텔레그램 주식조회 봇 - [소스](https://github.com/talCSHN/Raspberry_Pi_Study/blob/main/PiSrc/stockBot2.py)

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



***

## 📝 개인 포트폴리오 사이트 게시판 - [소스](https://github.com/talCSHN/IoT_WebApp_2025/tree/main/day10/Day10Study)

<img src="./Images/Board_Main.png" width="1000">

#### 기술 스택
- C# ASP.NET
- MySQL

#### 설명
- 포트폴리오 웹 사이트 내 게시판 페이지
- 해당 페이지에서 게시글 **조회/추가/수정/삭제** 가능
- **Velog RSS**를 통해 실제 내 벨로그 게시글 연동 - [Velog 링크](https://velog.io/@wwh11111/posts)

##### 글쓰기
<img src="./Images/Insert.png" width="1000">

##### 수정
<img src="./Images/Update.png" width="1000">

##### 상세
<img src="./Images/Select.png" width="1000">

##### 삭제
<img src="./Images/Delete.png" width="1000">

##### 벨로그 게시물은 링크를 통해 상세 내용 확인(수정 및 삭제 불가)
<img src="./Images/Main2.png" width="1000">
아래 velog 실제글로 이동
<img src="./Images/Velog.png" width="1000">

***

## 👑 보물찾기 게임 - [소스](https://github.com/talCSHN/IoT_CSharp_WinApp_2025/tree/main/toyproject/WinFormPractice)

![toyproject](https://github.com/user-attachments/assets/87223d87-e58d-454d-bb05-2d73a078201d)

#### 기술스택
- C# .NET WinForms

#### 게임 설명
- 10x10 그리드에 100개 버튼 생성
- 매번 랜덤 위치에 보물 생성
- 시작 시 **10초** 타이머 작동. 하단 Progress bar에 시간 경과 표시
- **버튼 클릭 시**
    - ❌ : 보물이 아닌 버튼 클릭. 게임 종료까지 해당 버튼 비활성화

    - 👑 : 보물이 있는 버튼 클릭. `보물 발견` 메시지 출력
- **승리 조건** - 보물이 있는 버튼 👑 발견
  - 제한 시간(10초)내 보물 찾지 못하면 `실패` 메시지 출력. `게임 종료`
- `게임 승리` 또는 `게임 종료`되면 자동으로 게임 리셋 후 새 게임 진행

***

<!-- ## 영화 즐겨찾기 앱 - [소스](https://github.com/talCSHN/IoT_WPF_2025/tree/main/day06/Day06Study)

https://github.com/user-attachments/assets/4de78572-386d-4700-b545-58f491fd1621

#### 기술스택
- C# .NET WPF

#### 프로그램 설명 -->
