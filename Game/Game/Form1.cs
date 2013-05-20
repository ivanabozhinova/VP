﻿using System;
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
        bool playerIsWalking { set; get; }
        public PLAYERID playerId { set; get; }
        public Ball ball { set; get; }
        public List<Ball> Balls;


        public Form1()
        {
            InitializeComponent();
            //creating a new game 
            game = new Game();

            Balls = new List<Ball>();


            //fixing the form
            DoubleBuffered = true;
            this.Width = game.currentScene.statusBarImg.Width + 15;
            this.Height = 520;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            playerIsWalking = false;
            playerId = PLAYERID.simona;
            player = new Player(this.Width / 2, this.Height - game.currentScene.statusBarImg.Height - 65, playerId);

            ball = new Ball(30, 30, this.Width, this.Height, 30, Math.PI / 4);
            Balls.Add(ball);
            ball = new Ball(this.Width - 115, 30, this.Width, this.Height, 30, 3 * Math.PI / 4);
            Balls.Add(ball);

            this.timer1.Interval = 40;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Enabled = true;
            this.timer1.Start();

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

            }

            Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            playerIsWalking = false;
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball ball in Balls)
                ball.MoveBall();
            Invalidate();
        }




    }
}
