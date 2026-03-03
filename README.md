# BOJ C# 풀이 모음

백준 온라인 저지(BOJ) 문제 풀이를 C#으로 정리한 저장소입니다. 각 파일은 문제 번호와 동일한 이름의 단일 소스 파일로, 표준 입력을 받아 정답을 출력합니다.

## 구조

- `BOJ/`: 모든 풀이 소스 파일 (`.cs`)
- 루트 디렉터리: 솔루션 파일 (`BOJ.slnx`) 및 프로젝트 설정

## 실행 방법

이 프로젝트는 여러 풀이 파일이 하나의 프로젝트에 포함되므로, 실행할 문제를 `BOJ/BOJ.csproj`의 `StartupObject`에 지정해야 합니다.

**1단계**: `BOJ/BOJ.csproj`의 `StartupObject`를 실행할 클래스명으로 변경합니다.

```xml
<!-- 예: 1000번 문제를 실행하려면 -->
<StartupObject>BOJ.Program1000</StartupObject>
```

**2단계**: 프로젝트 디렉터리를 지정해 실행합니다. (`--project BOJ`는 `BOJ/BOJ.csproj`가 위치한 폴더를 가리킵니다.)

```bash
dotnet run --project BOJ < input.txt > output.txt
```

## 실행 환경

- .NET 10.0
- 외부 패키지 의존성 없음

## 규칙

- 파일명은 문제 번호와 동일합니다. (예: `1000.cs`, `1753.cs`)
- 각 파일은 하나의 문제 풀이만 포함합니다.
- 각 파일 상단 주석에 문제 제목, 난이도(tier), 태그를 기록합니다.