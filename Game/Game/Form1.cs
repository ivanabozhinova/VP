using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        public Form1()
        {
            InitializeComponent();
            currentGameState = SCENE_NUMBER.begin;
            //creating a new game 
            game = new Game(currentGameState);
            this.playerId = PLAYERID.ivana;

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
            player = new Player(this.Width / 2, this.Height - game.currentScene.statusBarImg.Height - 65, playerId);
            player.IsWalking = false;

            ball = new Ball(30, 30, this.Width, this.Height, 40, Math.PI / 4);
            Balls.Add(ball);
            ball = new Ball(this.Width - 115, 30, this.Width, this.Height, 32, 3 * Math.PI / 4);
            Balls.Add(ball);
            ball = new Ball(30, 30, this.Width, this.Height, 20, Math.PI / 4);
            Balls.Add(ball);
            ball = new Ball(this.Width - 115, 30, this.Width, this.Height, 8, 3 * Math.PI / 4);
            Balls.Add(ball);


            pbTime = new ProgressBar(6, 408, this.Width, 15);

            pbTime = new ProgressBar(10, 412, this.Width, 5);


            this.timer1.Interval = 50;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Enabled = true;
            this.timer1.Start();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (currentGameState == SCENE_NUMBER.begin)
                game.currentScene.drawBeginScene(g, this.ClientRectangle);


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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.ChangeDirection(DIRECTION.left);
                    player.Move(this.Width);
                    player.IsWalking = true;
                    break;
                case Keys.Right:
                    player.ChangeDirection(DIRECTION.right);
                    player.Move(this.Width);
                    player.IsWalking = true;
                    break;
                case Keys.Space:
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


            hitBallCheck();
            Invalidate();
        }

        private void buttonNewGAME_Click(object sender, EventArgs e)
        {
            currentGameState = SCENE_NUMBER.level1;
            game.goToScene(SCENE_NUMBER.level1);
            this.buttonChoosePLAYER.Visible = false;
            this.buttonCONTROLS.Visible = false;
            this.buttonNewGAME.Visible = false;

            this.buttonChoosePLAYER.Enabled = false;
            this.buttonCONTROLS.Enabled = false;
            this.buttonNewGAME.Enabled = false;

            this.setNewGame(this.playerId);
        }

        public void hitBallCheck()
        {
            for (int i = 0; i < Balls.Count; i++)
                for (int j = 0; j < Shot.ShootingPoints.Count; j++)
                {
                    if (Balls[i].isHitBall(Shot))
                    {
                        Balls[i].ishited = true;
                    }

                }

            for (int i = Balls.Count; i <= 0; i--)
            {
                if (Balls[i].ishited)
                    Balls.RemoveAt(i);
            }
        }







    }
}
