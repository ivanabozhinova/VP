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

        public Brush barBrush = new SolidBrush(Color.Red);

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
            g.FillRectangle(barBrush, startX, startY, timeChange, heightR);
<<<<<<< HEAD

=======
>>>>>>> 86d49a8d7e900fd81f70306f1664315e97295ec4
        }


    }
}
