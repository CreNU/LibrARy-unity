# 공동 편집 규칙 (librARy-unity)

## 커밋 로그
구체적으로 써주세요

## 코-딩 스타일 (coding style)
### 변수
+ **낙타체**를 사용합니다.
+ 변수명의 맨 앞글자는 대문자로 합니다.

~~예쁘잖아요.~~ 네?

+ 데이터형이 헷갈릴 수 있는 변수는 앞에 데이터형을 적어주세요.
```
Public Hero HeroAquaMan;
Public Turtle TurtleObj;

HeroAquaMan.TalkToFishes(TurtleObj);
TurtleObj.IAmTurtle();
```
----------------------------------------------------------
### 조건문
- 조건문에서 NOT은 (조건) == false 이렇게 합니다.
```
if (ilililii == false) // (O)

if (!ilililii) // (X)
```

- 변수와 상수를 비교할 땐 **변수를 왼쪽**, **상수를 오른쪽**에 써주세요.
```
if (a < 3)//(O)

if (3 > a)//(X)
```
---------------------------------------------------------
### 중괄호
+ 중괄호는 내려서, 한줄이더라도 씁니다.
```
if (NoBrace)
{
    BraceWillBeSad();
}
```
