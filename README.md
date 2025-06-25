# Metaverse Academy Manager

## **프로젝트 개요**
메타버스 아카데미 강사가 되어 학생들이 경진대회에서 좋은 성적을 거두게 하는것이 목표인 시뮬레이션 게임입니다.

강사인 플레이어는 학생들의 성향과 실력을 토대로 프로젝트 팀을 편성합니다. 그리고 강의와 자습을 진행하면서 학생들의 실력을 올려주고 점심 시간에 학생들과 같이 밥을 먹으면서 학생들에 대해 알아갑니다. 
이를 반복하여 마지막날 학생들이 경진대회에서 좋은 결과를 얻을 수 있도록 하는것이 목표입니다.

#### :movie_camera:[시연 영상](https://www.youtube.com/watch?v=tRzVFwRMs_E)

## 주요 기능

### 팀 편성

- Game Start 버튼을 누르면 감옥으로 빨려들어가는 연출과 이후 플레이어가 일어나면서 대사가 재생됩니다.
- 이후 이동 키를 우측 하단에 안내하면서 플레이어를 조작할 수 있게됩니다.

  <img src="https://github.com/user-attachments/assets/72bac50b-35ff-4b16-9f35-f41f86f6180b" width="70%" height="70%"/>

### 강의

- 뼈랑 열쇠를 집을 수 있습니다. 처음에는 열쇠가 감옥 밖에 있고 뼈를 집은 상태에서 클릭하면 플레이어 앞으로 옮겨집니다. 이후에 열쇠를 집을 수 있습니다.

  <img src="https://github.com/user-attachments/assets/dea0d1c4-fb6a-4d4d-8a94-e5a550ddbd4a" width="70%" height="70%"/>

- 열쇠가 감옥 밖에 있을 때 뼈를 집지 않고 열쇠를 누르면 대사만 출력 되고 열쇠는 집어지지 않습니다.

  <img src="https://github.com/user-attachments/assets/81b67ff7-acb4-419f-90ae-8eb9e56e5fb2" width="70%" height="70%"/>

- 열쇠를 집으면 감옥 문을 열어 감옥을 빠져나올 수 있습니다.

  <img src="https://github.com/user-attachments/assets/5397bd38-0d37-480f-885f-fe93d15622b0" width="70%" height="70%"/>


### 점심 시간

- 체스판을 클릭하면 시점이 체스판으로 옮겨집니다. 이 상태에서 마우스 오른쪽 버튼을 클릭하면 원래 시점으로 돌아옵니다.

  <img src="https://github.com/user-attachments/assets/dbdde4bd-d287-43f0-878d-488babc3bf3a" width="70%" height="70%"/>
  
- 체스판 시점에서 쓰러져 있는 비숍을 클릭하면 원하는 칸에 놓을 수 있습니다.
- 클릭이 가능하다는걸 플레이어가 알 수 있도록 머서가 닿으면 외곽선이 나타나도록 구현했습니다.

  <img src="https://github.com/user-attachments/assets/5dc0fe34-7b01-4f29-8e79-bf4ef1bf8c62" width="70%" height="70%"/>
  
- 말이 상하 대칭으로 배열되면 다음 방으로 갈 수 있는 문이 열립니다.

  <img src="https://github.com/user-attachments/assets/8d895f3e-277a-48eb-9834-50057df309ca" width="70%" height="70%"/>


### 자습

- 마녀방에 입장하면 마녀와의 대화가 진행됩니다. 마녀와의 대화를 통해 마녀방의 탈출 조건을 알 수 있습니다.
  
  <img src="https://github.com/user-attachments/assets/07060cd7-af64-4933-9385-45f4cb6f5ad8" width="70%" height="70%"/>

- 재료를 집은 다음 솥에 넣을 수 있습니다.
  
  <img src="https://github.com/user-attachments/assets/18a4bccd-b409-43e0-b4a1-7e3905744b0c" width="70%" height="70%"/>

- 스위치를 누르면 솥에 넣은 재료들로 물약을 만들게 됩니다. 
- 솥에 아무 재료도 안 넣은 경우, 재료 배합이 잘못된 경우, 올바른 재료 배합인 경우에 따라 서로 다른 대사가 나옵니다. 올바른 재료 배합일 때는 다음 방으로 갈 수 있는 문이 열리게 됩니다.

  <img src="https://github.com/user-attachments/assets/a8169ed1-6a89-4b5a-9e55-a842e9980cbc" width="40%" height="40%"/>
  <img src="https://github.com/user-attachments/assets/6561cf58-af12-4488-aaf0-ef2aebf40ba7" width="40%" height="40%"/>


### 하루 정산

- 잘못된 발판을 밟으면 바닥에서 창이 튀어나오고 체크 포인트로 이동하게 됩니다. 창은 튀어나온 상태를 유지합니다.
- 주위의 힌트를 통해 올바른 발판을 알 수 있도록 디자인 했습니다.

  <img src="https://github.com/user-attachments/assets/b8d1dad0-95bf-4b5e-8db2-28579d068b6a" width="70%" height="70%"/>

### 발표 / 대회

- 엔딩 지점에 오면 두갈래 길이 보입니다.
    - 왼쪽으로 가면 함정에 걸리게 되며 경비에게 잡혀 다시 감옥으로 가게됩니다.
    - 오른쪽으로 가면 To Be Continued..라는 메세지와 함께 다음 스토리를 암시합니다.
    - 왼쪽 길에는 함정이 있다는 것을 플레이어가 조금 눈치챌 수 있도록 맵 디자인을 했습니다.
      
  <img src="https://github.com/user-attachments/assets/2e50bfba-dfc7-40c9-bda5-b890bc5b588b" width="70%" height="70%"/>


## 기술 스택

Unity, C#


## 팀원 소개
|김범수 <a href="https://github.com/Starbow-Break"><img src="https://github.com/user-attachments/assets/5cf4751a-cd8d-4328-b893-d8f76379e049" width="16" height="16"/></a>|박남훈 <a href="https://github.com/gunmango"><img src="https://github.com/user-attachments/assets/5cf4751a-cd8d-4328-b893-d8f76379e049" width="16" height="16"/></a>|
|:---:|:---:|
|<img src="https://github.com/user-attachments/assets/2fdb6c87-57a7-4d4d-9552-b87ca5df228c" width="200" height="200"/>|<img src="https://github.com/user-attachments/assets/0ad6068f-0807-404c-87a0-876a52928fbf" width="200" height="200"/>|
