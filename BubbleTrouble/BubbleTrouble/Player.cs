using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BubbleTrouble.Properties;

namespace BubbleTrouble
{
    public enum DIRECTION { right, left };
    public enum PLAYERID { player1, player2, player3 };
    public enum BOUNDS { left, right, top, down };

    public class Player
    {
        public int X { set; get; }
        public int Y { set; get; }
        public Image playerBackImg { set; get; }
        public Image playerProfileImg { set; get; }
        public bool isShooting { set; get; }
        public PLAYERID playerId { set; get; }
        public DIRECTION direction { set; get; }
        public bool IsWalking { set; get; }
        public bool isKilled { set; get; }
        //nekoe property za pukanjeto nz so da pisam 
        double Xc;
        double Yc;

        public Player(int x, int y, PLAYERID playerId)
        {
            this.X = x;
            this.Y = y;
            this.playerId = playerId;
            isShooting = new bool();
            isShooting = false;
            isKilled = new bool();
            isKilled = false;
            direction = DIRECTION.left;

            switch (playerId) //ova mozda ke treba u form poso go predavam po reference sekade
            {
                case PLAYERID.player1:
                    playerBackImg = Resources.player1b;
                    playerProfileImg = Resources.player1l;
                    break;
                case PLAYERID.player2:
                    playerBackImg = Resources.player2b;
                    playerProfileImg = Resources.player2l;
                    break;
                case PLAYERID.player3:
                    playerBackImg = Resources.player3b;
                    playerProfileImg = Resources.player3l;
                    break;
            }
        }

        public void ChangeDirection(DIRECTION direction)
        {
            this.direction = direction;
            switch (direction)
            {
                case DIRECTION.right:
                    if (this.playerId == PLAYERID.player1) this.playerProfileImg = Resources.player1r;
                    else if (this.playerId == PLAYERID.player2) this.playerProfileImg = Resources.player2r;
                    else if (this.playerId == PLAYERID.player3) this.playerProfileImg = Resources.player3r;
                    break;
                case DIRECTION.left:
                    if (this.playerId == PLAYERID.player1) this.playerProfileImg = Resources.player1l;
                    else if (this.playerId == PLAYERID.player2) this.playerProfileImg = Resources.player2l;
                    else if (this.playerId == PLAYERID.player3) this.playerProfileImg = Resources.player3l;
                    break;
            }
        }


        public void Move(int worldWidth)
        {
            switch (direction)
            {
                case DIRECTION.right:
                    X += 8;
                    if (X >= worldWidth - 50)
                        X = worldWidth - 50;
                    break;
                case DIRECTION.left:
                    X -= 8;
                    if (X < -5)
                        X = -5;
                    break;
            }
        }

        public void DrawPlayer(Graphics g, Rectangle ClientRectangle)
        {
            if (IsWalking)
            {
                g.DrawImage(playerProfileImg, X, Y, playerProfileImg.Width, playerProfileImg.Height);
            }
            else
                g.DrawImage(playerBackImg, X, Y, playerBackImg.Width, playerBackImg.Height);
        }


        public bool isHit(List<Ball> Balls)
        {
            foreach (Ball ball in Balls)
            {
                Xc = X + playerBackImg.Width / 2;
                Yc = Y + playerBackImg.Height / 2;
                double BallXc = ball.X + ball.Radius;
                double BallYc = ball.Y + ball.Radius;
                double distance = (Xc - BallXc) * (Xc - BallXc) + (Yc - BallYc) * (Yc - BallYc);
                double playerRadius = 20;
                if (distance <= ((ball.Radius + playerRadius) * (ball.Radius + playerRadius)))
                    return true;
                // return false; // da ne zamara
            }
            return false;
        }


    }
}
