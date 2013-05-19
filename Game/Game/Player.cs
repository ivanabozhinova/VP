using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Game.Properties;

namespace Game
{
    public enum DIRECTION { right, left };
    public enum PLAYERID { ivana, simona, sneze };
    public class Player
    {
        public int X { set; get; }
        public int Y { set; get; }
        public Image playerBackImg { set; get; }
        public Image playerProfileImg { set; get; }
        public bool isShooting { set; get; }
        public PLAYERID playerId { set; get; }
        public DIRECTION direction { set; get; }
        //nekoe property za pukanjeto nz so da pisam 

        public Player(int x,int y, PLAYERID playerId)
        {
            this.X = x;
            this.Y = y;
            isShooting = false;
          
            direction = DIRECTION.left;
            switch (playerId) //ova mozda ke treba u form poso go predavam po reference sekade
            {
                case PLAYERID.ivana:
                    playerBackImg = Resources.ivana2;
                    playerProfileImg = Resources.ivana;
                    break;
                case PLAYERID.simona:
                    playerBackImg = Resources.simona2;
                    playerProfileImg = Resources.simona;
                    break;
                case PLAYERID.sneze:
                    playerBackImg = Resources.sneze2;
                    playerProfileImg = Resources.sneze;
                    break;
            }
        }

        public void ChangeDirection(DIRECTION direction)
        {
            this.direction = direction;
            switch (direction)
            {
                case DIRECTION.right:
                                      if (this.playerId==PLAYERID.ivana) this.playerProfileImg = Resources.ivana4;
                                 else if (this.playerId == PLAYERID.simona) this.playerProfileImg = Resources.simona4;
                                 else if (this.playerId == PLAYERID.sneze) this.playerProfileImg = Resources.sneze4;
                    break;
                case DIRECTION.left:
                                     if (this.playerId == PLAYERID.ivana) this.playerProfileImg = Resources.ivana;
                                else if (this.playerId == PLAYERID.simona) this.playerProfileImg = Resources.simona;
                                else if (this.playerId == PLAYERID.sneze) this.playerProfileImg = Resources.sneze;
                    break;
            }
        }


        public void Move(int worldWidth)
        {
            switch (direction)
            {
                case DIRECTION.right:
                    X += 5;
                    if (X > worldWidth) X = worldWidth;
                    break;
                case DIRECTION.left:
                    X -= 5;
                    if (X < 0) X = 0;
                    break;
            }

            
            
        }

        public void DrawPlayer(Graphics g, Rectangle ClientRectangle,bool isWalking)
        {
         
            if (isWalking)
            {
                g.DrawImage(playerProfileImg, X, Y, playerProfileImg.Width, playerProfileImg.Height);
                
            }
            if (!isWalking)
                g.DrawImage(playerBackImg, X, Y, playerBackImg.Width, playerBackImg.Height);
        }

    }
}