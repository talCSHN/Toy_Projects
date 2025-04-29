# Toy_Projects
토이프로젝트 모음 리포지토리

## 👑 보물찾기 게임 - [소스](https://github.com/talCSHN/IoT_CSharp_WinApp_2025/tree/main/toyproject/WinFormPractice)

![toyproject](https://github.com/user-attachments/assets/87223d87-e58d-454d-bb05-2d73a078201d)

#### 기술스택
- C# .NET WinForms

#### 게임 설명
- 10x10 그리드에 100개 버튼 생성
- 시작 시 **10초** 타이머 작동. 하단 Progress bar에 시간 경과 표시
- **버튼 클릭 시**
    - ❌ : 보물이 아닌 버튼 클릭. 게임 종료까지 해당 버튼 비활성화

    - 👑 : 보물이 있는 버튼 클릭. `보물 발견` 메시지 출력
- **승리 조건** - 보물이 있는 버튼 👑 발견
  - 제한 시간(10초)내 보물 찾지 못하면 `실패` 메시지 출력. `게임 종료`
- `게임 승리` 또는 `게임 종료`되면 자동으로 게임 리셋 후 새 게임 진행
