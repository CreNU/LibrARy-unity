# 코-딩 스타일
### LibrARy-unity Coding Style

1. **낙타체**를 사용합니다.


2. 중괄호는 내려서, 한줄이더라도 씁니다.

>     if (NoBrace)
>
>     {
>         BraceWillBeSad();
>     }

3. 변수명의 맨 앞글자는 대문자로 합니다.
예쁘잖아요.


4. 데이터형이 헷갈릴 수 있는 변수는 앞에 데이터형을 적어주세요.
>     Public Hero HeroAquaMan;
>     Public Turtle TurtleObj;
>     
>     HeroAquaMan.TalkToFishes(TurtleObj);
>     TurtleObj.IAmTurtle();


5. 조건문에서 NOT은 (조건) == false 이렇게 합니다.
>     if (ilililii == false)
O
>     if (!ilililii)
X
