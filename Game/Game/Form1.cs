using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Game
{
    public partial class Form1 : Form
    {
        public Game game { set; get; }
        public Player player { set; get; }
        public PLAYERID playerId { set; get; }
        public Ball ball { set; get; }
        public List<Ball> Balls;
        public Shot Shot;
        public ProgressBar pbTime;
        public SCENE_NUMBER currentGameState { set; get; }
        public Stopwatch stopwatch;
        EventHandler eh;
        public Form1()
        {
            InitializeComponent();
            currentGameState = SCENE_NUMBER.begin;
            this.hideAllChoosePlayerMenuControls();
            //creating a new game 
            game = new Game(currentGameState);
            eh = new EventHandler(timer1_Tick);
            this.playerId = PLAYERID.player3;

            //fixing the form
            DoubleBuffered = true;
            this.Width = 700 + 15;
            this.Height = 520;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


        }

        public void setNewGame(PLAYERID playerId)
        {
            Shot = new Shot();
            Balls = new List<Ball>();

            this.playerId = playerId;
            player = new Player(this.Width / 2, this.Height - game.currentScene.statusBarImg.Height - 91, playerId);
            player.IsWalking = false;

            ball = new Ball(30, 40, this.Width, this.Height, 40, Math.PI / 4);
            Balls.Add(ball);
            ball = new Ball(this.Width - 115, 180, this.Width, this.Height, 32, 3 * Math.PI / 4);
            Balls.Add(ball);
            ball = new Ball(30, 220, this.Width, this.Height, 20, Math.PI / 4);
            //Balls.Add(ball);
            ball = new Ball(this.Width - 115, 270, this.Width, this.Height, 8, 3 * Math.PI / 4);
            //Balls.Add(ball);

            pbTime = new ProgressBar(10, 412, this.Width, 5);
            
            this.timer1.Interval = 5;
<<<<<<< HEAD
            this.timer1.Tick += new EventHandler(timer1_Tick);
=======
            if (game.numLives == 5) 
            this.timer1.Tick += eh;
>>>>>>> 55f61fa5848a574f3fa60459e7b547b0bd977d2b
            this.timer1.Enabled = true;
            this.timer1.Start();

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (currentGameState == SCENE_NUMBER.begin)
            {
                game.currentScene.drawBeginScene(g, this.ClientRectangle);
            }
            else if (currentGameState == SCENE_NUMBER.choosePlayer)
            {
                game.currentScene.drawBeginScene(g, this.ClientRectangle);
            }
            else
            {
                //iscrtuvanje na scenata
                game.currentScene.drawScene(g, this.ClientRectangle);

                //iscrtuvanje na topkite
                foreach (Ball ball in Balls)
                    ball.DrawBall(g);

                //iscrtuvanje na igracot
                player.DrawPlayer(g, this.ClientRectangle);

                //ako igracot e pogoden od topka igrata zavrsuva
                if (player.isHit(Balls))
                {
                    timer1.Stop();
                    game.playerKilled(this.player.X - 25, this.player.Y - 10, 100, g, this.ClientRectangle);
                    player.isKilled = true;
                    this.Update();

                    //if (player.isKilled)
                    //{
                    //    stopwatch = new Stopwatch();
                    //    stopwatch.Start();
                    //    while (stopwatch.Elapsed.Seconds <= 1) ;


                    //    stopwatch.Stop();
                       replayLevel();

                    //}                  

                }



                //iscrtuvanje na linijata za pukanje
                if (player.isShooting && Shot.numTicks > 0 && Shot.numTicks < 150)
                {
                    Shot.Draw(g, player);
                }

                //iscrtuvanje na progres barot
                pbTime.DrawPB(g);

                               
            }

        }


        

        public void replayLevel()
        {
            if (game.numLives >0)
            {
                player.isKilled = false;
                float score = game.currentScore;
                SCENE_NUMBER scNo = game.sceneNo;
                int lives = game.numLives;
                game = new Game(scNo);
                game.goToScene(scNo, score, lives);
                setNewGame(playerId);
            }
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (player.isKilled) break;
                    player.ChangeDirection(DIRECTION.left);
                    player.Move(this.Width);
                    player.IsWalking = true;
                    break;
                case Keys.Right:
                    if (player.isKilled) break;
                    player.ChangeDirection(DIRECTION.right);
                    player.Move(this.Width);
                    player.IsWalking = true;
                    break;
                case Keys.Space:


                    if (player.isKilled) break;

                    if (Shot != null)

                    if (player.isKilled) break;

                    if (Shot != null)

                    Shot.resetShot(player, this.Height);
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    player.IsWalking = false;
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball ball in Balls)
            {
                ball.MoveBall();
                ball.Time++;
            }

            if (player.isShooting && Shot.shootingY > 5)
            {
                Shot.addNewPoint();
            }
            if (player.isShooting && Shot.shootingY < 5)
            {
                player.isShooting = false;
                //Shot.ShootingPoints = new List<Point>();
            }
            Shot.numTicks++;

            pbTime.timeChange++;
            if (pbTime.timeChange == this.Width - 5)
                timer1.Stop();

            if (player.isShooting)
            hitBallCheck();
            Invalidate();
        }

        private void hideAllBeginMenuControls()
        {
            this.buttonChoosePLAYER.Visible = false;
            this.buttonCONTROLS.Visible = false;
            this.buttonNewGAME.Visible = false;
            this.buttonChoosePLAYER.Enabled = false;
            this.buttonCONTROLS.Enabled = false;
            this.buttonNewGAME.Enabled = false;
        }
        private void activateAllBeginMenuControls()
        {
            this.buttonChoosePLAYER.Visible = true;
            this.buttonCONTROLS.Visible = true;
            this.buttonNewGAME.Visible = true;
            this.buttonChoosePLAYER.Enabled = true;
            this.buttonCONTROLS.Enabled = true;
            this.buttonNewGAME.Enabled = true;
        }

         private void hideAllChoosePlayerMenuControls()
         {
             btn_back.Enabled = false;
             btn_pl1.Enabled = false;
             btn_pl2.Enabled = false;
             btn_pl3.Enabled = false;

             btn_back.Visible = false;
             btn_pl1.Visible = false;
             btn_pl2.Visible = false;
             btn_pl3.Visible = false;
         }
         private void activateAllChoosePlayerMenuControls()
         {
             btn_back.Enabled = true;
             btn_pl1.Enabled = true;
             btn_pl2.Enabled = true;
             btn_pl3.Enabled = true;

             btn_back.Visible = true;
             btn_pl1.Visible = true;
             btn_pl2.Visible = true;
             btn_pl3.Visible = true;
         }
        private void buttonNewGAME_Click(object sender, EventArgs e)
        {
            currentGameState = SCENE_NUMBER.level1;
            game.goToScene(SCENE_NUMBER.level1);
            this.hideAllBeginMenuControls();
            this.hideAllChoosePlayerMenuControls();
            this.setNewGame(this.playerId);
        }

        private void buttonChoosePLAYER_Click(object sender, EventArgs e)
        {
            currentGameState = SCENE_NUMBER.choosePlayer;
            this.hideAllBeginMenuControls();
            this.activateAllChoosePlayerMenuControls();
            game.goToScene(SCENE_NUMBER.choosePlayer);
            Invalidate();
            //ne rabote kako so treba
        }

        public void hitBallCheck()
        {
            for (int i = 0; i < Balls.Count; i++)
                for (int j = 0; j < Shot.ShootingPoints.Count; j++)
                {
                    if (Balls[i].isHitBall(Shot.ShootingPoints[j]))
                    {
                        Balls[i].isHit = true;
                        player.isShooting = false;
                        break;
                    }
                    else
                    {
                        Balls[i].isHit = false;
                    }
                }


            for (int i = Balls.Count - 1; i >= 0; i--)
            {
                Ball current = Balls[i];
                if (current.isHit)
                {
                    switch (current.Radius)
                    {
                        case 40:
                            ball = new Ball(current.X+40, current.Y, this.Width, this.Height, 32, -Math.PI / 4);
                            Balls.Add(ball);
                            ball = new Ball(current.X-40, current.Y, this.Width, this.Height, 32, -3* Math.PI / 4);
                            Balls.Add(ball);
                            break;
                        case 32:
                            ball = new Ball(current.X+30, current.Y, this.Width, this.Height, 20, -Math.PI / 4);
                            Balls.Add(ball);
                            ball = new Ball(current.X-30, current.Y, this.Width, this.Height, 20, -3* Math.PI / 4);
                            Balls.Add(ball);
                            break;
                        case 20:
                            ball = new Ball(current.X+20, current.Y, this.Width, this.Height, 8, -Math.PI / 4);
                            Balls.Add(ball);
                            ball = new Ball(current.X-20, current.Y, this.Width, this.Height, 8, -3* Math.PI / 4);
                            Balls.Add(ball);
                            break;
                    }
                    Balls.RemoveAt(i);
                    break;
                }
               
            }

        }
        

        private void btn_back_Click(object sender, EventArgs e)
        {
            currentGameState=SCENE_NUMBER.begin;
            game.goToScene(currentGameState);
            this.activateAllBeginMenuControls();
            this.hideAllChoosePlayerMenuControls();
            Invalidate();
        }

        private void btn_pl1_Click(object sender, EventArgs e)
        {
            this.playerId = PLAYERID.player1;
            currentGameState = SCENE_NUMBER.begin;
            game.goToScene(currentGameState);
            this.activateAllBeginMenuControls();
            this.hideAllChoosePlayerMenuControls();
            Invalidate();
        }

        private void btn_pl2_Click(object sender, EventArgs e)
        {
            this.playerId = PLAYERID.player2;
            currentGameState = SCENE_NUMBER.begin;
            game.goToScene(currentGameState);
            this.activateAllBeginMenuControls();
            this.hideAllChoosePlayerMenuControls();
            Invalidate();
        }

        private void btn_pl3_Click(object sender, EventArgs e)
        {
            this.playerId = PLAYERID.player3;
            currentGameState = SCENE_NUMBER.begin;
            game.goToScene(currentGameState);
            this.activateAllBeginMenuControls();
            this.hideAllChoosePlayerMenuControls();
            Invalidate();
        }

      
    }
}
