using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_me
{
    class CRect
    {
        public int left;
        public int top;
        public int width;
        public int height;
        public CRect()
        {
            left = 0;
            top = 0;
            width = 0;
            height = 0;
        }
        public CRect(int iLeft, int iTop, int iWidth, int iHeight)
        {
            left = iLeft;
            top = iTop;
            width = iWidth;
            height = iHeight;
        }

        public int right
        {
            get
            {
                return left + width;
            }
            set
            {
                if (value - left > 0)
                {
                    width = value - left;
                }
                else
                {
                    width = 0;
                }
            }
        }// End of property of right

        public int bottom
        {
            get
            {
                return top + height;
            }
            set
            {
                if (value - top > 0)
                {
                    height = value - top;
                }
                else
                {
                    height = 0;
                }
            }
        }// End of property of bottom

        public override string ToString()
        {
            return "RECT(left, top, width, height, right, bottom) is \r\n"
                + "("
                + left.ToString() + ", "
                + top.ToString() + ", "
                + width.ToString() + ", "
                + height.ToString() + ", "
                + right.ToString() + ", "
                + bottom.ToString() + ")";
        }
        public override bool Equals(object oRect)
        {
            if (left == ((CRect)oRect).left
                && top == ((CRect)oRect).top
                && width == ((CRect)oRect).width
                && height == ((CRect)oRect).height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
