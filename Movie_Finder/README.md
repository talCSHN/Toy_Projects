## MovieFinder 2025
- 전체 UI : UI설계화면 다섯영역으로 구분

- 영화즐겨찾기앱
    - TMDB 사이트에서 제공하는 OpenAPI로 데이터 가져오기
    - 내가 좋아하는 영화리스트 선택, 즐겨찾기 저장
    - 저장한 영화만 리스트업, 삭제 가능
    - 선택된 영화 더블클릭 > 영화 상세정보 팝업
    - 선택된 영화 선택 > 예고편보기 > 유튜브동영상 팝업

- API / OpenAPI
    - Applicaiton Programming Interface
    - 개발자가 직접개발하지 않고 제3자가 만들어서 제공하는 서비스

- TMDB, Youtube
    - [TMDB](https://www.themoviedb.org/) API 신청
    - [Youtube Data API](https://console.cloud.google.com/) 신청    
        - 프로젝트 생성 후 API 및 서비스 > 라이브러리
        - Youtube Data API v3 선택
        - 사용버튼 클릭 
        - 사용자 인증정보 입력

***

1. WPF 프로젝트 생성
2. NuGet 패키지 사용할 기본 라이브러리 설치
    - CommunityToolkit.Mvvm
    - MahApps.Metro / MahApps.Metro.IconPacks
    - MySql.Data
    - NLog
3. 폴더생성 : Helpers, Models, Views, ViewModels
4. MVVM 구조 초기작업
5. UI 구현
6. 로직구현
    1. TMDB API 사용 구현
    2. 관련 기능 전부구현
7. 데이터그리드 더블클릭해서 상세정보 표시
    - NuGet 패키지에서 Microsoft.Xaml.Behaviors.Wpf 설치
8. 텍스트박스에서 엔터시 이벤트 발생 처리
9. 텍스트박스 한글 입력 우선 처리
10. 실행시 텍스트박스에 포커스 가도록 처리
***
1. 상태표시줄 시계 동작
2. 상태표시줄 검색 결과 건수 표시
3. 로그 출력 정리
4. 즐겨찾기 DB연동
    1. MySQL Workbench에서 moviefinder 데이터베이스(스키마 생성)
    2. movieitems 테이블 생성. 컬럼은 MovieItem.cs 속성과 동일
    3. INSERT, UPDATE, DELETE 작업
5. YouTube 예고편 보기
    1. TrailerView, TrailerViewModel 생성
    2. WPF 기본 WebBrowser는 HTML5 기술이 표현 안 됨. 오류 많음
    3. NuGet 패키지 - CefSharp WebBrowser 패키지 설치
    4. **CefSharp.Wpf.NET Core 설치 시 프로젝트 속성 > 일반 > 빌드 > 플랫폼 대상 > Any CPU에서 x64로 변경**
    5. NuGet 패키지 - Google.Apis.YouTube.v3 설치
6. 기타 작업 완료
7. 결과 화면

    https://github.com/user-attachments/assets/895dd8c0-e57e-42eb-a64b-8e1577a03033
