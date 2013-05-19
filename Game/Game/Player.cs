using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Game.Properties;

namespace Game
{
    enum DIRECTION { right, left };
    class Player
    {
        public int X { set; get; }
        public int Y { set; get; }
        public Image playerBackImg { set; get; }
        public Image playerRightProfileImg { set; get; }
        public Image playerLeftProfileImg { set; get; }
        public bool isShooting { set; get; }
        public bool isWalking { set; get; }
        public DIRECTION direction { set; get; }
        //nekoe property za pukanjeto nz so da pisam 

        public Player(Point coordinates, int player)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            isShooting = false;
            isWalking = false;
            direction = DIRECTION.right;
            switch (player) //ova mozda ke treba u form poso go predavam po reference sekade
            {
                case 1:
                    playerBackImg = Resources.ivana;
                    playerLeftProfileImg = Resources.ivana2;
                    break;
                case 2:
                    playerBackImg = Resources.simona;
                    playerLeftProfileImg = Resources.simona2;
                    break;
                case 3:
                    playerBackImg = Resources.sneze2;
                    playerLeftProfileImg = Resources.sneze;
                    break;
            }
        }

        public void ChangeDirection(DIRECTION direction)
        {
            this.direction = direction;
        }


        public void Move(int worldWidth)
        {
            switch (direction)
            {
                case DIRECTION.right:
                    X += 1;
                    if (X > worldWidth) X = worldWidth;
                    break;
                case DIRECTION.left:
                    X -= 1;
                    if (X < 0) X = 0;
                    break;
            }

            isWalking = true;
        }

        public void DrawPlayer(Graphics g, Rectangle ClientRectangle)
        {
            if (!isWalking)
                g.DrawImage(playerBackImg, X + ClientRectangle.X, ClientRectangle.Y + ClientRectangle.Height-20, playerBackImg.Width, playerBackImg.Height);
            else
                g.DrawImage(playerLeftProfileImg, X + ClientRectangle.X, Y+ClientRectangle.Y + ClientRectangle.Height-20, playerBackImg.Width, playerLeftProfileImg.Height);
        }

    }
}