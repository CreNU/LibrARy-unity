# 공동 편집 규칙 (librARy-unity)

## 커밋 로그
구체적으로 써주세요

## 코-딩 스타일 (coding style)

- **낙타체**를 사용합니다.

- 중괄호는 내려서, 한줄이더라도 씁니다.
>     if (NoBrace)
>     {
>         BraceWillBeSad();
>     }

- 변수명의 맨 앞글자는 대문자로 합니다.
~~예쁘잖아요.~~ 네?

- 데이터형이 헷갈릴 수 있는 변수는 앞에 데이터형을 적어주세요.
>     Public Hero HeroAquaMan;
>     Public Turtle TurtleObj;
>     
>     HeroAquaMan.TalkToFishes(TurtleObj);
>     TurtleObj.IAmTurtle();

- 조건문에서 NOT은 (조건) == false 이렇게 합니다.
>     if (ilililii == false)
O
>     if (!ilililii)
X
