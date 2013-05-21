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
        // bool playerIsWalking { set; get; }
        public PLAYERID playerId { set; get; }
        public Ball ball { set; get; }
        public List<Ball> Balls;
        public Shot Shot;
        private int timeElapsed; //izminato vreme vo sekundi
        private static readonly int TIME = 1200; //vremetraenje na igrata


        public Form1()
        {
            InitializeComponent();
            //creating a new game 
            game = new Game();
            Shot = new Shot();
            Balls = new List<Ball>();

            //fixing the form
            DoubleBuffered = true;
            this.Width = game.currentScene.statusBarImg.Width + 15;
            this.Height = 520;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            playerId = PLAYERID.simona;
            player = new Player(this.Width / 2, this.Height - game.currentScene.statusBarImg.Height - 65, playerId);
            player.IsWalking = false;

            ball = new Ball(30, 30, this.Width, this.Height, 30, Math.PI / 4);
            Balls.Add(ball);
            ball = new Ball(this.Width - 115, 30, this.Width, this.Height, 30, 3 * Math.PI / 4);
            Balls.Add(ball);

            this.timer1.Interval = 50;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Enabled = true;
            this.timer1.Start();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            game.currentScene.drawScene(g, this.ClientRectangle);
            player.DrawPlayer(g, this.ClientRectangle);
            foreach (Ball ball in Balls)
                ball.DrawBall(g);

            if (player.isHit(Balls))
            {
                timer1.Dispose();
            }

            if (player.isShooting && Shot.numTicks < 50)
            {
                Shot.Draw(g);
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
                ball.MoveBall();

            if (player.isShooting && Shot.shootingY > 5)
            {
                Shot.deviation *= -1;
                Shot.shootingX += Shot.deviation;
                Shot.shootingY -= 10;
                Shot.ShootingPoints.Add(new Point(Shot.shootingX, Shot.shootingY));

            }
            if (player.isShooting && Shot.shootingY < 5)
            {
                player.isShooting = false;
                Shot.ShootingPoints = new List<Point>();
                // MessageBox.Show(numTicks.ToString());
            }
            Shot.numTicks++;

            //timeElapsed++;
            //pbTime.Value = TIME - timeElapsed;

            //if (timeElapsed == TIME)
            //{
            //    timer1.Stop();
            //}
            //updateTime();
            Invalidate();
        }


        private void updateTime() //metod za obnovuvanje na vremeto
        {
            int left = TIME - timeElapsed;
            int min = left / 60;
            int sec = left % 60;

        }

    }
}
