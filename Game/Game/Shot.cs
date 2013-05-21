using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Game
{
    public class Shot
    {
        public List<Point> ShootingPoints { get; set; }
        public int shootingX { get; set; } //X koordinata na linijata
        public int shootingY { get; set; } //Y koordinata na tocka od linijata
        public Pen shootingPen = new Pen(Color.Black, 3);
        public Pen shootingPen1 = new Pen(Color.Gray, 1);
        
        public int numTicks { get; set; } // kolku vreme pominalo od pritiskanjeto Space
        public int yGrowth; // kolku brzo da raste po Y
        public int deviation; // kolku da otstapuva od prava linija

       

        public Shot()
        {
            ShootingPoints = new List<Point>(); 
            numTicks = 0;
            yGrowth = 10;
            deviation = 5;
        }

        /*Crtanjeto na linijata e implementirano so pomos na metodot DrawCurve
        * koj povrzuva niza od tocki.
        * So sekoj tik na tajmerot dodavame edna tocka poveke vo nizata.
        * Koordinatite na novata tocka se za yGrowth povisoko od prethodnata i 
        * za deviation polevo/podesno (zatoa se mnozi so -1)
        */

        public void addNewPoint()
        {
            deviation *= -1;
            shootingX += deviation;
            shootingY -= yGrowth;
            ShootingPoints.Add(new Point(shootingX, shootingY));
        }

        public void Draw(Graphics g)
        {
            if (ShootingPoints.Count > 0)
            {
                g.DrawCurve(shootingPen, ShootingPoints.ToArray());
                g.TranslateTransform(1, 0);
                g.DrawCurve(shootingPen1, ShootingPoints.ToArray());
                g.ResetTransform();
            }
        }

        public void resetShot(Player player, int height)
        {
            if (!player.isShooting)
            {
                player.isShooting = true;
                shootingX = player.X + 15;
                shootingY = height - 100;
                numTicks = 0;
                ShootingPoints = new List<Point>();
            }
        }
    }



}
