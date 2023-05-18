using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1
{
    internal class CCircle
    {
        private Boolean isSelected;
        private int x, y;
        private const int rad = 50;
        private const int sqRad = rad * rad;
        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Boolean isEqual(int x, int y)
        {
            return (x == this.x) && (y == this.y);
        }
        public Boolean isPossess(int x, int y)
        {
            int sqDist = (this.x - x) * (this.x - x) + (this.y - y) * (this.y - y);
            return sqDist <= sqRad;
        }
        public void paint(Graphics g)
        {
            if (isSelected)
            {
                g.FillEllipse(Brushes.Red, x - rad, y - rad, 2 * rad, 2 * rad);
            }
            else
            {
                g.FillEllipse(Brushes.Black, x - rad, y - rad, 2 * rad, 2 * rad);
            }
        }
        public void select()
        {
            isSelected = true;
        }
        public void unselect()
        {
            isSelected = false;
        }
        public Boolean isSelect()
        {
            return isSelected;
        }
    }
}