## **Имплементација на играта Bubble Trouble**

**Bubble Trouble** е игра која се состои од еден играч и три нивоа. На корисникот му е овозможена опцијата да избира помеѓу три понудени играчи.
Идејата за играта е позајмена од  http://www.bubbletrouble.net/bubble-trouble/games/Bubble-Trouble.html 

**Цел** на играта е да се погодат сите балончиња кои се појавуваат на екранот,при тоа истите во зависност од големината можат да се делат на две други со помала големина. Играта е ограничена и на време , што значи за да премине корисникот на следно ниво треба да ги погоди сите балончиња во одреден временски интервал. Дозволени се 5 шанси да се одигра моменталното ниво , доколку во неколку обиди играчот не успее да го заврши истото. Исто така , за секоја погодена топка се освојуваат соодветен број на поени. 

**Инструкции:**
Играчот може да се движи во лева насока (лева стрелка) , десна насока (десна стрелка) и да пука (space).

## Структура и организација на код
* Windows.Form - Game 
*  Kласи :
        * Player
        * Shot
        * Ball
        * ProgressBar
        * View :
                  * MainMenuView
                  * ChoosePlayerView
                  * InstructionsView
                  * ScoreView
                  *  LevelView :
                                 * FirstLevelView
                                 * SecondLevelView
                                 * ThirdLevelView

**Kласата Player**
 содржи методи кои го придвижуваат играчот , го ицртуваат и проверуваат дали тој е погоден од балонче или не.

**Kласата Shot**
 содржи методи кои ја ицртуваат спиралата која ги убива балончињата.

**Kласата Bаll**
 содржи методи кои ја ицртуваат топката(балончето) ,проверуваат дали е погодена од спиралата и
ја пресметуваат траекторијата по која ќе се движи.

**Kласата ProgressBar**
 содржи методи кои  го исцртуваат прогрес барот и проверуваат дали е истечено времето.

**Kласата View**
 содржи виртуелни методи за исцртување на позадина и целиот приказ.Намената на оваа класа е од неа да видат изведени сите други класи кои ќе имаат различна позадина и различни функционалности во нив

 **Kласите МainMenuView ,ChoosePlayerView,ScoreView,InstructionsView**
 наследуваaт од View класата и содржat методи кои ги сетираат соодветните функционалности на копчињата кои се потребни за да функционираат тие прикази.

**Kласата LevelView**
   наследува од View класата ,содржи методи кои го прикажуваат целиот изглед на едно ниво ,
вклучувајќи го бројот на животи ,бројот на ниво ,статусбарот ,и сетирање на низа од топчиња

**Kласите  FirstLevelView, SecondLevelView , ThirdLevelView**
   наследуваат од LevelView класата , притоа во нив се сетира бројот и типот на топките кои се предодредени за секое ниво

## **Опис на функции и класи**
Функцијата **IsHitBall(Point s) во класата Ball** проверува дали топката е погодена од спиралата. 
За да се провери тоа, за спиралата сметаме како да е правоаголник чија ширина е од 2*девијацијата, а висината се менува со секој тик на тајмерот. 
Со оваа функција е поврзана и функцијата **hitBallCheck(bool isShooting) во класата Game**. 
Тука ја изминуваме низата од топки и низата од точки на спиралата и проверуваме дали топката се допира 
со некој дел од спиралата. Ако се допира , својството Ball.isHit го поставуваме на true и во следната итерација на низата од топки, во зависност од радиусот на топката, доколку е најмалата верзија ја бришеме од низата 
т.е. исчезнува од погледот, во другите случаи на нејзино место се создаваат две нови топки за една големина на радиусот помали од избришаната.


## **Screenshoots од изгледот на играта и кратко упатство како се игра**

•       При стартување на играта се отвара прозорец каде јасно се гледа името на играта и основните опции кои ги нуди, како:
![My image](https://raw.github.com/ibozinova/VP/master/PrintScr_za_BubbleTrouble/NewGame.png)

o	Инструкции за контролите (How to play) – клик на копчето Instructions
 ![My image](https://raw.github.com/ibozinova/VP/master/PrintScr_za_BubbleTrouble/Instructions.png)
 
o	Избор на играч – клик на копчето Choose a Player 
![My image](https://raw.github.com/ibozinova/VP/master/PrintScr_za_BubbleTrouble/ChooseAPlayer.png)

•	При клик на копчето New Game се отвара поглед од првиот левел на играта, соодветен број на топки за левелот и играчот со кој сме избрале да играме, како и прогрес бар со време, број на животи и поени.
Играта е поделена во три нивоа, а секое ниво е со своја тежина. Разликата меѓу нивоата е во бројот и брзината на топките.
Левелот е успешно поминат кога се уништени сите топки во временскиот интервал кој е даден, и притоа играчот да не биде погоден од некоја топка.

 ![My image](https://raw.github.com/ibozinova/VP/master/PrintScr_za_BubbleTrouble/LevelCompleted.png)
 
•	За да стигне играчот до победа, потребно е да пука во топките и да избегнува тие да удрат во него. Во зависност од големината, кога топката е погодена се дели на две помали топки и тоа е анимирано со „експлозија“ 
  ![My image](https://raw.github.com/ibozinova/VP/master/PrintScr_za_BubbleTrouble/Shot.png)
  
  ![My image](https://raw.github.com/ibozinova/VP/master/PrintScr_za_BubbleTrouble/BallExplosion.png)
  
•	На крајот од играта (кога истекло времето или играчот ги изгубил сите животи) се прикажува прозорец  дека играта завршила, а кога ќе стигне до победа се прикажува прозорец со соодветна порака дека победил.
Во двата случаи се прикажува бројот на поени што ги освоил и опции да игра повторно или да ја исклучи играта.
  ![My image](https://raw.github.com/ibozinova/VP/master/PrintScr_za_BubbleTrouble/GameOver.png)
  
  ![My image](https://raw.github.com/ibozinova/VP/master/PrintScr_za_BubbleTrouble/YouWon.png)
