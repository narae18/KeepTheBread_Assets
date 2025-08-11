# Keep The Bread

게임프로그래밍 캡스톤 디자인 최종 프로젝트, 학과 캡스톤 경진 1등 수상작

- 엔진: Unity
- 언어: C# (스크립트), ShaderLab/HLSL (효과)
- 레포 구성: Assets 중심 (BGM, Image, PreAssets, Prefab, Scenes, Scripts, TextMesh Pro)

## 게임 개요
빵을 지키는 액션/캐주얼 게임. 제한된 자원과 상호작용을 활용해 웨이브를 버티며 핵심 오브젝트(빵)를 보호한다.
- 핵심 루프: 준비 → 방어/전투 → 보상/강화 → 다음 웨이브
- 차별점: 직관적 조작, 짧은 러닝타임, 시각·청각 피드백 최적화

## 수상
- 2025년 게임프로그래밍 과목 캡스톤 디자인 1등


###  게임 실행 영상
[![Watch the video](https://img.youtube.com/vi/lRjWc6zfzCQ/maxresdefault.jpg)](https://www.youtube.com/watch?v=lRjWc6zfzCQ&t=28s)


## 조작
- 이동: WASD
- 상호작용/공격: 마우스 좌클릭
- 스킬/아이템: 1~3
- 일시정지: ESC
(실제 키 바인딩과 다르면 이 섹션을 프로젝트에 맞춰 수정)

## 폴더 구조
- Assets/BGM: 배경음악 리소스
- Assets/Image: UI 및 텍스처
- Assets/PreAssets: 프리프로덕션 리소스
- Assets/Prefab: 프리팹
- Assets/Scenes: 씬 파일
- Assets/Scripts: 게임 로직 C# 스크립트
- Assets/TextMesh Pro: 폰트/텍스트 리소스

## 기술 포인트
- 웨이브 스포너와 난이도 곡선
- 오브젝트 풀링으로 GC 스파이크 최소화
- 상태 기반 AI (간단한 FSM)
- 화면 셰이크·히트 정지 등 타격감 연출
- TextMesh Pro 기반 UI

## 성능/품질
- 대상: 60 FPS (FHD 기준)
- 최적화: 풀링, 배치, 간단한 LOD/오클루전 활용

