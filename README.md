# Gun Shooter Project

본 프로젝트는 Unity 6을 기반으로 개발된 1인칭 슈팅(FPS) 게임으로, 게임 시스템 전반을 직접 설계 및 구현하였으며, **에셋 관리의 효율성, 유지보수 가능한 구조**, 그리고 **몰입감 있는 전투 경험**을 목표로 구성하였습니다. 무기 시스템, AI 기반 적 행동, UI 흐름 제어, 레벨 디자인 등 게임의 모든 핵심 요소를 단독으로 개발하였습니다.

## Demo ScreenShot

![1](https://github.com/user-attachments/assets/87cf7129-bf76-4805-a813-33d2aea1fea7)
![2](https://github.com/user-attachments/assets/8ed62b45-ce80-4705-b33b-ca7274d7b241)
![3](https://github.com/user-attachments/assets/285ce8f0-11e9-4e81-9ff8-4d91a3599d9f)

## 🔧 개발 환경 및 기술 스택

-   **Engine**: Unity 6
-   **Language**: C#
-   **AI**: NavMeshAgent
-   **에셋 관리**: ScriptableObject 기반 구조화
-   **맵 디자인**: ProBuilder 활용 레벨 제작
-   **애니메이션 및 이펙트**: ParticleSystem, Cinemachine, AudioSource
-   **UI**: TextMeshPro 기반 실시간 HUD 설계
-   **입력 시스템**: Unity StarterAssets 기반 컨트롤러 커스터마이징
-   **비주얼 연출**: Post-processing 프로파일을 통한 화면 연출 강화

## 🧩 주요 시스템 및 설계 특징

### 1. **무기 시스템 (확장성 중심 구조 설계)**

-   `WeaponSO`(ScriptableObject)를 활용해 **데이터 기반 무기 관리** 구현
    -   데미지, 연사 속도, 탄창 크기, 줌 가능 여부 등 세부 속성 분리
    -   무기 추가 시 **코드 수정 없이 확장 가능**한 구조 설계
-   `ActiveWeapon` 컴포넌트는 무기 장착, 발사, 줌, 애니메이션, 사운드 등 **전투 전반 제어**
-   무기 발사 시 `Weapon` 클래스가 Raycast 기반 타격 처리 및 피격 시각 이펙트 적용

### 2. **아이템 시스템 (상속을 활용한 구조화)**

-   `Pickup` 추상 클래스를 정의하고, `WeaponPickup`, `AmmoPickup` 등에서 상속하여 구현
    -   `OnPickup` 메서드를 추상화해 각 아이템의 동작을 분리
    -   공통 기능(회전, 부유, 사운드 재생)은 `Pickup`에서 처리하여 **재사용성과 응집력 강화**

### 3. **적 AI 및 전투 구조**

-   `Robot`: NavMesh 기반으로 플레이어 추적, 충돌 시 자폭 처리
-   `Turret`: 고정 위치에서 일정 간격으로 투사체를 발사하며, 플레이어 방향 자동 조준
-   `Projectile`: 이동, 충돌 판정, 데미지 부여, 사운드 및 피격 이펙트까지 단일 스크립트로 통합
-   `EnemyHealth`: 적 체력 관리 및 사망 시 이펙트와 `GameManager`와 연동된 UI 갱신 수행

### 4. **플레이어 및 UI 시스템**

-   `PlayerHealth`는 체력/실드 시스템, 피격 이펙트, 사망 시 카메라 전환 및 UI 출력까지 관리
-   `GameManager`는 적 수 UI 갱신, 승리 조건 체크, 일시정지 및 씬 관리까지 통합 제어
-   UI 전반은 `TextMeshPro`를 활용하여 직관적이며 실시간으로 갱신되는 HUD 구성

### 5. **StarterAssets 기반 컨트롤러 확장**

-   Unity의 `StarterAssets` 패키지를 기반으로 **커스터마이징한 FirstPersonController** 사용
    -   무기 발사 및 줌 중 회전 속도 조절
    -   카메라 FOV 변경, 커서 상태 제어, 애니메이션 연동 등 FPS 조작 최적화

### 6. **레벨 디자인 및 맵 구성**

-   `ProBuilder`를 활용하여 FPS 전투에 적합한 맵 직접 설계
    -   장애물, 고저차, 엄폐 지형 등을 구성하여 전투 전략성을 높임
    -   NavMesh 베이킹을 통한 적 AI의 자연스러운 경로 탐색 지원

### 7. **포스트 프로세싱 기반 화면 연출**

-   Post-processing Volume을 통해 화면의 몰입감 향상
    -   Bloom, Vignette, Color Grading 등을 활용하여 **전투 상황의 시각적 긴장감** 강화
    -   무기 줌 연출 및 플레이어 사망 연출에 적절한 시각 효과 적용

## 🏆 개발 포인트 요약

-   **ScriptableObject를 통한 무기 확장성 확보 및 에셋 관리 구조화**
-   **상속 기반 아이템 시스템 설계로 재사용성과 기능 분리 구현**
-   **StarterAssets를 기반으로 한 FPS 컨트롤러 커스터마이징 경험**
-   **UI, 사운드, 이펙트, AI를 연계한 몰입감 있는 전투 구조 구축**
-   **ProBuilder를 활용한 실전용 맵 디자인 및 AI 경로 탐색 환경 구현**
-   **Post-processing을 활용한 카메라 및 전투 시각 연출 최적화**

## 🔭 향후 개선 계획

-   웨이브 기반 적 생성 및 스코어링 시스템 추가
-   다양한 무기 종류 및 업그레이드 시스템 개발
-   보스 AI 도입 및 고유 패턴 구현
-   인게임 미션/목표 설정 시스템 추가

## 🎮 게임 플레이 방법

-   이동: WASD 키를 이용해 전후좌우 이동
-   달리기: 왼쪽 Shift 키를 누르고 이동하여 빠르게 달리기 가능
-   점프: Spacebar 키로 점프 가능
-   무기 발사: 마우스 왼쪽 클릭으로 발사
-   무기 줌(조준경): 마우스 오른쪽 클릭으로 줌 인/아웃

## 🌐 데모 및 저장소 링크

-   🕹️ Web Demo: [실행하기](https://mayquartet.com/my_htmls/Gun_Shooter/index.html)
-   📦 GitHub Repository: https://github.com/ralskwo/Gun-Shooter
