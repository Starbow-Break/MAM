# Metaverse Academy Manager

## **프로젝트 개요**
메타버스 아카데미 강사가 되어 학생들이 경진대회에서 좋은 성적을 거두게 하는것이 목표인 시뮬레이션 게임입니다.

강사인 플레이어는 학생들의 성향과 실력을 토대로 프로젝트 팀을 편성합니다. 그리고 강의와 자습을 진행하면서 학생들의 실력을 올려주고 점심 시간에 학생들과 같이 밥을 먹으면서 학생들에 대해 알아갑니다. 
이를 반복하여 마지막날 학생들이 경진대회에서 좋은 결과를 얻을 수 있도록 하는것이 목표입니다.

#### :movie_camera:[시연 영상](https://www.youtube.com/watch?v=tRzVFwRMs_E)

## 주요 기능

### 팀 편성

- 각 프로젝트 시작 전에 팀 편성을 진행합니다. 각 팀당 2명 씩 13팀을 구성합니다.
- 편성할 팀을 선택하면 학생 목록이 나타나고 학생을 선택하면 선택된 학생이 팀에 배정됩니다.
- 학생 목록에서 마우스 호버시 각 학생의 정보가 표시 됩니다. 특정 정보들은 학생들의 친밀도가 일정 이상 상승해야 볼 수 있습니다.
<p align="center">
  <img src="https://github.com/user-attachments/assets/0db87fbc-aa31-4910-892b-fdf9f8090c1a" width="60%" height="60%"/>
</p>

### 강의

- 강의의 종류, 난이도를 선택한 뒤 강의 미니게임을 진행합니다.
  
#### Unity 미니게임

- 각 아이콘의 순서에 맞게 방향키 또는 스페이스 바를 순서대로 누르는 미니게임입니다.
- 가운데에 있는 아이콘이 나오면 스베이스 바를, 나머지 아이콘은 각 아이콘의 위치에 해당하는 방향키를 누르면 됩니다.

<p align="center">
  <img src="https://github.com/user-attachments/assets/a73545b2-2340-4fe7-b3fe-1ec90e5bf888" width="40%" height="40%"/>
  <img src="https://github.com/user-attachments/assets/361b4269-052d-4d95-9026-8607b3b03a59" width="40%" height="40%"/>
</p>

#### C# 미니게임

- 노트가 나타나면 한박자 뒤에 스페이스 바를 눌러 처리하는것을 기본 규칙으로 하는 리듬 게임 기반 미니게임입니다.
- 노트는 총 세 가지가 존재하고 각 노트에 맞춰서 스페이스 바를 눌러 처리하면 됩니다.
  - 원형 노트 : 기본 규칙에 맞춰 처리하면 됩니다.
  - 삼각형 노트 : 말풍선에서 언급하는 색에 해당하는 노트만 처리해야 합니다.
  - 사각형 노트 : 말풍선에서 언급하는 횟수만큼 한 박자 간격으로 처리하면 됩니다.

<p align="center">
  <img src="https://github.com/user-attachments/assets/cccab7e7-6c12-4871-8398-884535489716" width="30%" height="30%"/>
  <img src="https://github.com/user-attachments/assets/216ac72f-f566-4898-a64a-ecb7c1d8f768" width="30%" height="30%"/>
  <img src="https://github.com/user-attachments/assets/8c2b2ba4-9a87-48d8-8543-ce8ab45111c6" width="30%" height="30%"/>
<p align="center">

### 점심 시간

- 가고싶은 식당과 같이 식사할 학생을 최대 6명 선택합니다.

<p align="center">
  <img src="https://github.com/user-attachments/assets/5b04e182-71d2-4074-bf6b-3b4875dde911" width="60%" height="60%"/>
</p>

- 선택된 학생들은 각 학생들의 선호 식당을 반영하여 호감도가 상승합니다.

<p align="center">
  <img src="https://github.com/user-attachments/assets/845e78cf-b762-4a3a-916f-df86013bc911" width="60%" height="60%"/>
</p>

### 자습

- 학생을 선택해서 칭찬하거나 혼내거나 도와줄 수 있습니다. 선택한 행동과 학생들의 성향에 따라 학생들의 능력치가 변합니다.
- 최대 3번 행동할 수 있습니다.

<p align="center">
  <img src="https://github.com/user-attachments/assets/05aa99bb-76c8-4ae8-b325-2470ef9732ef" width="30%" height="30%"/>
  <img src="https://github.com/user-attachments/assets/1a99843f-b00c-45be-98dc-15b063bd7274" width="30%" height="30%"/>
  <img src="https://github.com/user-attachments/assets/05f85074-6e54-4a7d-9417-a4ed4bbb8926" width="30%" height="30%"/>
</p>

### 하루 정산

- 하루가 마무리되면서 각 팀의 프로젝트 진행률이 공개됩니다.

<p align="center">
  <img src="https://github.com/user-attachments/assets/e83bc3c0-e5b0-4d65-82fd-816f791acda3" width="60%" height="60%"/>
</p>

- 다음 하루가 진행되기 전 발표 / 대회까지 남은 기간을 보여줍니다.

<p align="center">
  <img src="https://github.com/user-attachments/assets/3aff1e68-0889-45a5-be14-c37f7a6027f9" width="60%" height="60%"/>
</p>

### 발표 / 대회

- 발표/대회 날이 되면 발표/대회를 진행합니다.
- 각 팀의 프로젝트 진행률에 따라 각 팀의 성적이 부여됩니다.

<p align="center">
  <img src="https://github.com/user-attachments/assets/05aa99bb-76c8-4ae8-b325-2470ef9732ef" width="60%" height="60%"/>
</p>

## 기술 스택

Unity, C#


## 팀원 소개
|김범수 <a href="https://github.com/Starbow-Break"><img src="https://github.com/user-attachments/assets/5cf4751a-cd8d-4328-b893-d8f76379e049" width="16" height="16"/></a>|박남훈 <a href="https://github.com/gunmango"><img src="https://github.com/user-attachments/assets/5cf4751a-cd8d-4328-b893-d8f76379e049" width="16" height="16"/></a>|
|:---:|:---:|
|<img src="https://github.com/user-attachments/assets/2fdb6c87-57a7-4d4d-9552-b87ca5df228c" width="200" height="200"/>|<img src="https://github.com/user-attachments/assets/0ad6068f-0807-404c-87a0-876a52928fbf" width="200" height="200"/>|
