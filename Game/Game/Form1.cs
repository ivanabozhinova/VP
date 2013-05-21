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

        private int timeElapsed; //izminato vreme vo sekundi
        private static readonly int TIME = 1200; //vremetraenje na igrata
        private int lives;
        public Game game { set; get; }
        public Player player { set; get; }
        bool playerIsWalking { set; get; }
        public PLAYERID playerId { set; get; }
        public Ball ball { set; get; }
        public List<Ball> Balls;

        public List<Point> ShootingPoints;
        private int shootingY;
        private int shootingX;
        private Pen shootingPen = new Pen(Color.Black, 3);
        private Pen shootingPen1 = new Pen(Color.Gray, 1);
        private int deviation = 5;
        private int numTicks = 0;


        public Form1()
        {
            InitializeComponent();
            //creating a new game 
            game = new Game();

            Balls = new List<Ball>();
            ShootingPoints = new List<Point>();

            //fixing the form
            DoubleBuffered = true;
            DoubleBuffered = true; //fixing the form
            this.Width = game.currentScene.statusBarImg.Width + 15;
            this.Height = 520;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            playerIsWalking = false;
            playerId = PLAYERID.simona;
            player = new Player(this.Width / 2, this.Height - game.currentScene.statusBarImg.Height - 65, playerId);

            lives = 3;
            pbTime.ForeColor = Color.FromArgb(255, 0, 0);
            
            ball = new Ball(30, 30, this.Width, this.Height, 30, Math.PI / 4);
            Balls.Add(ball);
            ball = new Ball(this.Width - 115, 30, this.Width, this.Height, 30, 3 * Math.PI / 4);
            Balls.Add(ball);

            this.timer1.Interval = 50;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Enabled = true;
            this.timer1.Start();

            this.timer2.Interval = 50;
            this.timer2.Tick += new EventHandler(timer2_Tick);
            this.timer2.Enabled = true;
            this.timer2.Start();
            
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            game.currentScene.drawScene(g, this.ClientRectangle);
            player.DrawPlayer(g, this.ClientRectangle, playerIsWalking);
            foreach (Ball ball in Balls)
                ball.DrawBall(g);
            //Brush zigzagBrush = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.ZigZag, Color.Black);
            if (player.isHit(Balls))
            {
                timer1.Dispose();
            }

            //test na krivata
            g.TranslateTransform(100, 0);
            Point[] points = new Point[4];
            points[0] = new Point(-5, 70);
            points[1] = new Point(5, 80);
            points[2] = new Point(-5, 90);
            points[3] = new Point(5, 100);

            Pen blackPen = new Pen(Color.Black, 5);
           // g.DrawCurve(blackPen, points);

            if (player.isShooting && numTicks < 50)
            {
                g.DrawCurve(shootingPen, ShootingPoints.ToArray());
                g.TranslateTransform(1, 0);
                g.DrawCurve(shootingPen1, ShootingPoints.ToArray());
                g.ResetTransform();
                //ShootingPoints.ToArray();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.ChangeDirection(DIRECTION.left);
                    player.Move(this.Width);
                    playerIsWalking = true;
                    break;
                case Keys.Right:
                    player.ChangeDirection(DIRECTION.right);
                    player.Move(this.Width);
                    playerIsWalking = true;
                    break;
                case Keys.Space:
                    player.isShooting = true;
                    shootingX = player.X-85;
                    shootingY = this.Height-100;
                    numTicks = 0;
                    ShootingPoints = new List<Point>();
                    break;                    
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    playerIsWalking = false;
                    break;
            }            
     
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball ball in Balls)
                ball.MoveBall();

            if (player.isShooting && shootingY > 5)
            {
                deviation *= -1;
                shootingX += deviation;
                shootingY -=10;
                ShootingPoints.Add(new Point(shootingX, shootingY));
               
            }
            if (player.isShooting && shootingY < 5)
            {
                player.isShooting = false;
                ShootingPoints = new List<Point>();
               // MessageBox.Show(numTicks.ToString());
            }
            numTicks++;
            
           /* timeElapsed++;
            pbTime.Value = TIME - timeElapsed;
            
            if (timeElapsed == TIME)
            {
                timer1.Stop();
            }
            updateTime();

            Invalidate();*/
        }

        


        private void updateTime() //metod za obnovuvanje na vremeto
        {
            int left = TIME - timeElapsed;
            int min = left / 60;
            int sec = left % 60;            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            pbTime.Value = TIME - timeElapsed;

            if (timeElapsed == TIME)
            {
                timer2.Stop();
            }
            updateTime();

            Invalidate();
        }

        

       
        
    }
}
