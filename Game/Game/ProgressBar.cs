using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Game
{
    public class ProgressBar
    {
        public float startX { set; get; }
        public float startY { set; get; }
        public float heightR { set; get; }
        public float widthR { set; get; }

        public float timeChange;

        public Pen barPen = new Pen(Color.Red, 20);

        public ProgressBar(float sX, float sY, float wR, float hR) 
        {
            startX = sX;
            startY = sY;            
            widthR = wR;
            heightR = hR;
            timeChange = 0;
        }

        public void DrawPB(Graphics g)
        {
            g.DrawRectangle(barPen, startX, startY, timeChange, heightR);

        }


    }
}
