Klasi vo igrata:


Form1 : da kreirame samo istanci od Level klasata . i da kontrolirame neli koj level sme

1.class Game  :
    
                 -score
		 -timer//za progressBar
                 -numberOfLifes
		 -isHitCoveceto
                 -podaroci
		 -topkite
                 -scena

 class Topka:
		 -koordninati 
		 -tip
		 -boja
		 
class Bubble:
		-img bubble //tip na bubble
		
class Podarok:
               -tip

class Scena :  
		-lifes
		-img backgroung
		-img life
		-img bar
		+img zidovi

class Player :
               -koordinati
	       -bool puka;
	       - isHit ..neso fokusot da se nasteluva kaj nego ako e puknat /ova za crtanje		
