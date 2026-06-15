# Bundle Warriors

개발 기간: 2026.03. ~ 진행 중  
작성일: 26.06.13.

## 프로젝트 소개

**2D, UI 메타 시스템 중심의 게임 개발 경험을 쌓기 위해 진행한 (개인)토이 프로젝트입니다.**

라이브 서비스 RPG 게임(트릭컬 리바이브)를 오마주하여 실제 운영이 고려된 게임 시스템을 개발하였습니다.  
2D, UI에 대한 이해도를 확보하고자 프로젝트를 시작하였으며, 실제로 생소한 구조적 문제, 디버깅 효율 문제 등을 해결하였습니다.

## 주요 기능

아래 영상 자료는 모두 실제 Android 환경(빌드)에서 촬영되었습니다!

### 로비 화면 로딩
<img width="800" height="369" alt="ezgif-2637ccb62ff4cb68" src="https://github.com/user-attachments/assets/68562927-6719-4989-8d3d-4c2729a79770" />

### 병사 모집
<img width="800" height="369" alt="ezgif-25aac64ff8925b99" src="https://github.com/user-attachments/assets/5fcc3187-e9df-49fb-92e5-02067fe419e3" />

### 병사 레벨업
<img width="800" height="369" alt="ezgif-22d22770a10b7125" src="https://github.com/user-attachments/assets/ddceafb3-63f5-49bf-8825-d092729fac2b" />

### 플레이어 정보
<img width="800" height="369" alt="ezgif-20d9550d977ff482" src="https://github.com/user-attachments/assets/18def994-7c30-41fd-be3d-b40fe8961f17" />

### 상점
<img width="800" height="369" alt="ezgif-2fe9c4b381d7cbe1" src="https://github.com/user-attachments/assets/a4838f8e-a433-4ad9-818a-e7abc9a150c4" />

### 배낭
<img width="800" height="369" alt="ezgif-2b7028bf4b8a9336" src="https://github.com/user-attachments/assets/0040599e-4b56-4a39-a326-4e19d9aec98b" />

## 주요 기술

- UGUI
- Assembly Definition (18개 규모의 Assembly 구조 설계)
- Custom Editor (개발 도구, 편의성 PropertyDrawer 제작)
- Scriaptable Object
- Firebase Crashlytics (비정상 종료 자동 리포팅)
- VContainer (DI 기반 아키텍처)

## 아키텍처 소개

프로젝트의 모든 어셈블리에 대해 설명했습니다.

아키텍처에 관심 있으시다면 읽어봐주시면 감사드리겠습니다.

```text
모든 어셈블리
├── 커스텀 모듈(Assets/)
│   ├── AssetValidator ─────────────────────────────────── # 프리팹 검증 도구 `Asset Validator`의 핵심 시스템
│   │   └── AssetValidator.Editor ──────────────────────── # AssetValidator의 에디터 구현 포함
│   │
│   └── UIConstraint ───────────────────────────────────── # Layout Pass 기반 RectTransform 제어 시스템 `UI Constraint` 
│
└── 프로젝트 핵심 모듈 (Assets/Scripts/)
    ├── Core
    │   ├── ProjectB.Core ──────────────────────────────── # 공통 기반 타입, Unity 기본 클래스들의 유틸리티 및 확장 기능
    │   └── ProjectB.Core.Editor ───────────────────────── # Core의 에디터 구현 포함
    │
    ├── Data
    │   └── ProjectB.Data ──────────────────────────────── # 데이터 타입이 인터페이스 구현됨
    │
    ├── Authoring
    │   └── ProjectB.Authoring ─────────────────────────── # ScriptableObject 기반 게임 데이터 구현(Data 어셈블리의 인터페이스를 구현)
    │
    ├── Gameplay
    │   ├── ProjectB.Gameplay.Events ───────────────────── # 게임플레이와 외부 모듈(주로 UI) 사이의 이벤트 계약
    │   ├── Inbound
    │   │   ├── ProjectB.Gameplay.Inbound.Ports ────────── # 외부에서 호출하는 사용자 기능 인터페이스
    │   │   └── ProjectB.Gameplay.Inbound.Implements ───── # Inbound Ports 구현
    │   ├── Internal
    │   │   ├── ProjectB.Gameplay.Internal.Ports ───────── # Gameplay 로직의 내부 기능 인터페이스
    │   │   └── ProjectB.Gameplay.Internal.Implements ──── # Internal Ports 구현
    │   ├── Outbound
    │   │   └── ProjectB.Gameplay.Outbound.Ports ───────── # 외부 시스템 연동 인터페이스 (Infrastructure 어셈블리에서 구현)
    │   │
    │   └── ProjectB.Gameplay.MonoSystems ──────────────── # 사용되는 곳은 없지만 단독으로 존재해야 하는 시스템 객체 구현
    │
    ├── Infrastructure
    │   ├── ProjectB.Infrastructure ────────────────────── # Outbounds의 외부 기술 기반 구현
    │   ├── ProjectB.Infrastructure.UI ─────────────────── # UI Presenter를 생성하는 외부 기술(현재 VContainer 기반)
    │   │
    │   └── ProjectB.Infrastructure.VContainer.Editor ──── # 프로젝트에서 사용되는 VContainer 관련 Util 기능의 에디터 구현
    │
    ├── UI
    │   ├── ProjectB.UI ────────────────────────────────── # UI 공통 클래스(UIView, PrefabPool 등) 포함
    │   ├── ProjectB.UI.Views ──────────────────────────── # 버튼, 텍스트 등 표준적인 UI 개념을 나타내는 UGUI Wrapper
    │   └── ProjectB.UI.Presenters ─────────────────────── # 게임의 기능에 따라 View를 제어하는 시스템
    │
    └── Dependency
        └── ProjectB.Dependency ────────────────────────── # 전체 의존성을 연결하는 루트 Assembly
```


<img width="842" height="615" alt="스크린샷 2026-06-15 오후 12 22 45" src="https://github.com/user-attachments/assets/ed197073-4099-46dc-aaa3-c007f63ed133" />
