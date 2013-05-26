using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BubbleTrouble.Properties;
using System.Media;


namespace BubbleTrouble
{
    public partial class Game : Form
    {
        public int level { set; get; }
        public int numLives { set; get; }
        public int scores { set; get; }

        public Player player { set; get; }
        public PLAYERID playerId { set; get; }
        public Ball ball { set; get; }
        public List<Ball> Balls{ set; get; }
        public Shot Shot;
        public ProgressBar pbTime;
        public View currentView;
        Timer timer1;
        int ticksCounter;
        int INTERVAL = 15;

        public Game()
        {
            InitializeComponent();
            currentView = new MainMenuView();
            this.playerId = PLAYERID.player1;
            this.enableAllMainMenuControls();

           
            //fixing the form
            DoubleBuffered = true;
            this.Width = 700 + 15;
            this.Height = 520;

            //pause
            this.buttonPause.BackColor = Color.Transparent;
            this.buttonPause.Visible = false;

            //labeli za score
            lblScore.BackColor = Color.Transparent;
            finScore.BackColor = Color.Transparent;
            lblScore.Size = new Size(21, 21);
            finScore.Size = new Size(21, 21);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.timer1 = new Timer();

            this.timer1.Tick += new EventHandler(timer1_Tick);
            ticksCounter = 0;

            this.level = 1;
            this.scores = 0;
            this.numLives = 5;
            
        }


        public void startGame()
        {
            this.Shot = new Shot();
            this.Balls = new List<Ball>();
            this.playerId = playerId;
            LevelView currentLevel = (LevelView)currentView;
            player = new Player(this.Width / 2, this.Height - currentLevel.statusBarImg.Height - 91, playerId);
            player.IsWalking = false;

            currentLevel.resetBalls(this.Width,this.Height);
            foreach (Ball b in currentLevel.Balls)
            {
                Balls.Add(b);
            }
            pbTime = new ProgressBar(10, 412, this.Width - 5, 5);

            finScore.Visible = false;

            this.timer1.Interval = INTERVAL;
            this.timer1.Enabled = true;
            this.timer1.Start();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (currentView.GetType() == typeof(MainMenuView) ||
                currentView.GetType() == typeof(ChoosePlayerView) ||
                currentView.GetType() == typeof(InstructionsView) ||
                currentView.GetType() == typeof(ScoreView))
            {
                currentView.drawView(g, this.ClientRectangle);
                if (currentView.GetType() == typeof(ScoreView))
                {
                    this.enableAllScoreViewControls();
                    lblScore.Visible = false;
                    this.finScore.Visible = true;
                    finScore.Text = lblScore.Text;
                }
                this.buttonPause.Visible = false;
            }

            else
            {
                this.buttonPause.Visible = true;
                lblScore.Visible = true;

                //iscrtuvanje na scenata
                currentView.drawView(g, this.ClientRectangle);

                //iscrtuvanje na linijata za pukanje
                if (player.isShooting && Shot.numTicks < 150)
                {
                    Shot.Draw(g, player);
                }

                //iscrtuvanje na igracot
                player.DrawPlayer(g, this.ClientRectangle);

                if (Balls.Count() == 0)
                {

                    if (currentView.GetType() != typeof(ThirdLevelView))
                    {
                        this.Update();
                        if (ticksCounter >= 35)
                        {
                            ticksCounter = 0;
                            player.isKilled = false;
                            this.nextLevel();
                            this.startGame();
                            Invalidate();
                        }
                        else
                        {
                            ticksCounter++;
                            //za congrats Level 1 completed etc...
                            lblScore.Visible = false;
                            buttonPause.Visible = false;
                            if (currentView.GetType() == typeof(FirstLevelView))
                                g.DrawImage(Resources.lvl1c, 0, 0, this.Width, this.Height);
                            if (currentView.GetType() == typeof(SecondLevelView))
                                g.DrawImage(Resources.lvl2c, 0, 0, this.Width, this.Height);
                        }
                    }
                    else
                    {                        
                        currentView = new ScoreView();
                        currentView.backgroundImg = Resources.youWon;
                        this.enableAllScoreViewControls();
                        ticksCounter = 0;
                        this.lblScore.Visible = false;
                        buttonPause.Visible = false;
                        Invalidate();
                    }
                    
                }
           else
           {
                    //iscrtuvanje na topkite
                    foreach (Ball ball in Balls)
                    {
                        ball.DrawBall(g);
                    }
                   
                    //  ako igracot e pogoden od topka igrata zavrsuva ili istece vremeto
                    if (player.isHit(Balls) || pbTime.timeUp())
                    {
                        timer1.Stop();
                        // ako e posledna runda i igracot go podogi topka ili istece vremeto
                        if (numLives == 1)
                        {

                            player.isKilled = true;
                            this.Update();

                            //otkako ke gi izgubi site zivoti
                            //broi 15 ticks
                            //za vreme na broenjeto se zatemnuva
                            //i posle ide na gameOver(showScore)
                            if (ticksCounter >= 35)
                            {
                                currentView = new ScoreView();
                                currentView.drawView(g, this.ClientRectangle);
                                ticksCounter = 0;

                            }
                            else
                            {
                                ticksCounter++;
                                if (pbTime.timeUp())
                                {
                                    Brush brush = new SolidBrush(Color.FromArgb(30, Color.Black));
                                    g.FillRectangle(brush, 0, 0, currentView.backgroundImg.Width, currentView.backgroundImg.Height);
                                }
                                else this.roundOver(this.player.X - 25, this.player.Y - 10, 100, g, this.ClientRectangle);
                            }
                            Invalidate();
                        }
                        //if it's not the last round when the player is killed wait for 10 ticks and replay the round
                        else
                        {
                            if (ticksCounter >= 30)
                            {
                                ticksCounter = 0;
                                player.isKilled = false;
                                replayLevel();
                            }
                            else
                            {
                                player.isKilled = true;
                                ticksCounter++;
                                if (pbTime.timeUp())
                                {
                                    Brush brush = new SolidBrush(Color.FromArgb(30, Color.Black));
                                    g.FillRectangle(brush, 0, 0, currentView.backgroundImg.Width, currentView.backgroundImg.Height);
                                }
                                else this.roundOver(this.player.X - 25, this.player.Y - 10, 100, g, this.ClientRectangle);
                            }
                        }
                        Invalidate();

                    }
                    //iscrtuvanje na progres barot
                    pbTime.DrawPB(g);
                }

               ////iscrtuvanje na linijata za pukanje
               //if (player.isShooting && Shot.numTicks < 150)
               //{  Shot.Draw(g, player);
               //}
            }
        }


        private void replayLevel()
        {
            numLives -= 1;
            LevelView curr = (LevelView)currentView;
            curr.resetBalls(this.Width,this.Height);
            curr.numLives = numLives;
            if (numLives > 0)
            {
                startGame();
            }
        }

        public void nextLevel()
        {
            lblScore.Visible = true;
            if(currentView.GetType() == typeof(FirstLevelView))
            {
                currentView = new SecondLevelView(this.numLives, this.scores);
           } 
            else if (currentView.GetType() == typeof(SecondLevelView))
            {
                currentView = new ThirdLevelView(this.numLives, this.scores);
            }
            

        }

        public void roundOver(float playerCoordinateX, float playerCoordinateY, float radius, Graphics g, Rectangle ClientRectangle)
        {

            var circle = new System.Drawing.Drawing2D.GraphicsPath();
            circle.AddEllipse(playerCoordinateX, playerCoordinateY, radius, radius);

            g.SetClip(circle, System.Drawing.Drawing2D.CombineMode.Exclude);

            Brush brush = new SolidBrush(Color.FromArgb(30, Color.Black));
            g.FillRectangle(brush, 0, 0, currentView.backgroundImg.Width, currentView.backgroundImg.Height);

            // Image gameover = Resourses.gameover;
            //  g.DrawImage(gameover, ClientRectangle, this.currentScene.backgroundImg.Width / 2, this.currentScene.backgroundImg.Height/ 2,gameover.Width,gameover.Height);

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
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if (player != null)
                    {
                        if (player.isKilled) break;
                        if (Shot != null)
                            Shot.resetShot(player, this.Height);
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.IsWalking = false;
                    break;
                case Keys.Right:
                    player.IsWalking = false;
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                if (!Balls[i].dying)
                    Balls[i].MoveBall();
                if (Balls[i].dying)
                    Balls[i].Time++;
                else
                    Balls[i].Time = 0;
            }

            if (player.isShooting && Shot.shootingY > 5)
            {
                Shot.addNewPoint();
            }
            if (player.isShooting && Shot.shootingY < 5)
            {
                player.isShooting = false;
            }
             Shot.numTicks++;

            pbTime.timeChange++;

            hitBallCheck(player.isShooting);

            Invalidate();
        }


        public void hitBallCheck(bool isShooting)
        {
            if (isShooting)
            {
                for (int i = 0; i < Balls.Count; i++)
                    for (int j = 0; j < Shot.ShootingPoints.Count; j++)
                    {
                        if (!Balls[i].isHit)
                            if (Balls[i].isHitBall(Shot.ShootingPoints[j]))
                            {
                                ticksCounter = 0;
                                Balls[i].bubble = Resources.explosion;
                                Balls[i].isHit = true;
                                player.isShooting = false;
                                Balls[i].dying = true;
                                Balls[i].velocity = 0;
                                break;
                            }
                            else
                            {
                                Balls[i].isHit = false;
                            }
                    }
            }


            for (int i = Balls.Count - 1; i >= 0;  i--)
             {
                Ball current = Balls[i];
                if (current.isHit)
                {
                    ticksCounter = 0;
                    
                    if (Balls[i].Time >= 2)
                    {
                        Balls.RemoveAt(i);
                        switch (current.Radius)
                        {
                            case 40:
                                ball = new Ball(current.X + 40, current.Y, this.Width, this.Height, 32, -Math.PI / 4);
                                Balls.Add(ball);
                                ball = new Ball(current.X - 40, current.Y, this.Width, this.Height, 32, -3 * Math.PI / 4);
                                Balls.Add(ball);
                                this.scores += 10;
                                break;
                            case 32:
                                ball = new Ball(current.X + 30, current.Y, this.Width, this.Height, 20, -Math.PI / 4);
                                Balls.Add(ball);
                                ball = new Ball(current.X - 30, current.Y, this.Width, this.Height, 20, -3 * Math.PI / 4);
                                Balls.Add(ball);
                                this.scores += 15;
                                break;
                            case 20:
                                ball = new Ball(current.X + 20, current.Y, this.Width, this.Height, 8, -Math.PI / 4);
                                Balls.Add(ball);
                                ball = new Ball(current.X - 20, current.Y, this.Width, this.Height, 8, -3 * Math.PI / 4);
                                Balls.Add(ball);
                                this.scores += 20;
                                break;
                            case 8:
                                this.scores += 25;
                                break;
                        }
                        lblScore.Text = scores.ToString();
                    }
                    break;
                }
            }
        }



        private void disableAllMainMenuControls()
        {
            
            MainMenuView mainManuView = (MainMenuView)currentView;
            this.button_NewGAME = mainManuView.disableMainMenuView_newGAME_Button(this.button_NewGAME);
            this.button_choosePLAYER = mainManuView.disableMainMenuView_choosePLAYER_Button(this.button_choosePLAYER);
            this.button_INSTRCTIONS = mainManuView.disableMainMenuView_INSTRCTIONS_Button(this.button_INSTRCTIONS);
            this.finScore.Visible = false;
        }
        private void enableAllMainMenuControls()
        {

            MainMenuView mainManuView = (MainMenuView)currentView;
            this.button_NewGAME = mainManuView.enableMainMenuView_newGAME_Button(this.button_NewGAME);
            this.button_choosePLAYER = mainManuView.enableMainMenuView_choosePLAYER_Button(this.button_choosePLAYER);
            this.button_INSTRCTIONS = mainManuView.enableMainMenuView_INSTRCTIONS_Button(this.button_INSTRCTIONS);
            this.finScore.Visible = false;
        }

        private void disableAllChoosePlayerMenuControls()
        {
            ChoosePlayerView choosePlayerView = (ChoosePlayerView)currentView;
            this.button_player1 = choosePlayerView.disableChoosePlayerView_player1_Button(this.button_player1);
            this.button_player2 = choosePlayerView.disableChoosePlayerView_player2_Button(this.button_player2);
            this.button_player3 = choosePlayerView.disableChoosePlayerView_player3_Button(this.button_player3);
            this.button_BACK = choosePlayerView.disableChoosePlayerView_BACK_Button(this.button_BACK);
            this.finScore.Visible = false;
        }
        private void enableAllChoosePlayerMenuControls()
        {
            ChoosePlayerView choosePlayerView = (ChoosePlayerView)currentView;
            this.button_player1 = choosePlayerView.enableChoosePlayerView_player1_Button(this.button_player1);
            this.button_player2 = choosePlayerView.enableChoosePlayerView_player2_Button(this.button_player2);
            this.button_player3 = choosePlayerView.enableChoosePlayerView_player3_Button(this.button_player3);
            this.button_BACK = choosePlayerView.enableChoosePlayerView_BACK_Button(this.button_BACK);
        }
        private void enableAllScoreViewControls()
        {
            ScoreView scoreView = (ScoreView)currentView;
            this.button_QUITGame = scoreView.enableScoreView_QUIT_Button(this.button_QUITGame);
            this.button_BACK = scoreView.enableScoreView_BACK_Button(this.button_BACK);
        }
        private void disableAllScoreViewControls()
        {
            ScoreView scoreView = (ScoreView)currentView;
            this.button_QUITGame = scoreView.disableScoreView_QUIT_Button(this.button_QUITGame);
            this.button_BACK = scoreView.disableScoreView_BACK_Button(this.button_BACK);
        }
        private void enableAllInstructionsViewControls()
        {
            InstructionsView instructionsView = (InstructionsView)currentView;
            this.button_BACK = instructionsView.enableInstructionsView_BACK_Button(this.button_BACK);
        }
        private void disableAllInstructionsViewControls()
        {
            InstructionsView instructionsView = (InstructionsView)currentView;
            this.button_BACK = instructionsView.disableInstructionsView_BACK_Button(this.button_BACK);
            this.finScore.Visible = false;
        }

        private void button_NewGAME_Click(object sender, EventArgs e)
        {
            level = 1;
            scores = 0;
            numLives = 5;
            this.disableAllMainMenuControls();
            currentView = new FirstLevelView(numLives, scores);
            this.startGame();
            this.lblScore.Visible = true;
            lblScore.Text = scores.ToString();
            Invalidate();
        }

        private void button_choosePLAYER_Click(object sender, EventArgs e)
        {
            this.disableAllMainMenuControls();
            currentView = new ChoosePlayerView();
            this.enableAllChoosePlayerMenuControls();
            Invalidate();
        }



        private void button_BACK_Click(object sender, EventArgs e)
        {
            if (currentView.GetType() == typeof(ScoreView))
            {
                this.disableAllScoreViewControls();
            }

            else if (currentView.GetType() == typeof(ChoosePlayerView))
            {
                this.disableAllChoosePlayerMenuControls();
            }
            else if (currentView.GetType() == typeof(InstructionsView))
            {
                this.disableAllInstructionsViewControls();
            }

            currentView = new MainMenuView();
            enableAllMainMenuControls();

            Invalidate();
        }

        private void button_player1_Click(object sender, EventArgs e)
        {
            if (currentView.GetType() == typeof(ChoosePlayerView))
            {
                disableAllChoosePlayerMenuControls();
            }

            this.playerId = PLAYERID.player1;
            currentView = new MainMenuView();
            enableAllMainMenuControls();
            Invalidate();
        }

        private void button_player2_Click(object sender, EventArgs e)
        {
            if (currentView.GetType() == typeof(ChoosePlayerView))
            {
                disableAllChoosePlayerMenuControls();
            }

            this.playerId = PLAYERID.player2;
            currentView = new MainMenuView();
            enableAllMainMenuControls();
            Invalidate();
        }

        private void button_player3_Click(object sender, EventArgs e)
        {
            if (currentView.GetType() == typeof(ChoosePlayerView))
            {
                disableAllChoosePlayerMenuControls();
            }

            this.playerId = PLAYERID.player3;
            currentView = new MainMenuView();
            enableAllMainMenuControls();
            Invalidate();
        }



        //button which brings you to the View with instructions
        private void button_INSTRCTIONS_Click(object sender, EventArgs e)
        {
            this.disableAllMainMenuControls();
            currentView = new InstructionsView();
            this.enableAllInstructionsViewControls();
            Invalidate();
        }

        private void button_QUITGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (buttonPause.Text == "PAUSE")
            {
                buttonPause.Text = "RESUME";
                timer1.Enabled = false;
            }
            else if (buttonPause.Text == "RESUME")
            {
                buttonPause.Text = "PAUSE";
                timer1.Enabled = true;
            }
        }

       




    }
}
