using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_me
{
    enum Direction { VERTICAL, HORIZONTIAL };
    
    class ScrollBar : window
    {
        //The direction's default value is VERTICAL
        Direction direction = Direction.VERTICAL;
        public window mx_prevWindow;
        public window mx_scrlWindow;
        public window mx_forwWindow;
        private float mx_scrollPos = 0;
        public const int mx_X = 20;
        public const int mx_Y = 20;

        public ScrollBar(CRect scrollBar, Direction dir):base(scrollBar)
        {
            this.direction = dir;
        }

        public override void setWindowPos(CRect mx_wnd)
        {
            base.setWindowPos(mx_wnd);
            if (direction == Direction.VERTICAL)
            {
                mx_prevWindow.setWindowPos(new CRect(mx_window.left, mx_window.top, mx_X, mx_Y));
                mx_forwWindow.setWindowPos(new CRect(mx_window.left,mx_window.bottom-mx_Y,mx_X,mx_Y));
            }
            else
            {
                mx_prevWindow.setWindowPos(new CRect(mx_window.left, mx_window.top, mx_X, mx_Y));
                mx_forwWindow.setWindowPos(new CRect(mx_window.right-mx_X, mx_window.top - mx_Y, mx_X, mx_Y));
            }
        }

        public bool setScrollPos(float sPos)
        {
            if (direction == Direction.VERTICAL)
            {
                if(sPos<0||sPos>mx_window.height-mx_Y*3)                    
                    return false;
                this.mx_scrollPos = sPos;
                mx_scrlWindow.mx_window = new CRect(mx_window.left,mx_window.top+(int)mx_scrollPos,mx_X,mx_Y);
            }
            else
            {
                if (sPos < 0 || sPos > mx_window.width - mx_X * 3)
                    return false;
                this.mx_scrollPos = sPos;
                mx_scrlWindow.mx_window = new CRect(mx_window.left+mx_X+(int)mx_scrollPos, mx_window.top, mx_X, mx_Y);
            }
            return true;
        }

        public override void create()
        {
            mx_prevWindow = new window();
            mx_scrlWindow = new window();
            mx_forwWindow = new window();
        }

        public override string ToString()
        {
            return "ScrollBar:" + mx_window + "\r\n" +
                "PrevButton:" + mx_prevWindow + "\r\n" +
                "ForwButton:" + mx_forwWindow;
        }

        public override void updateWindow()
        {
            if (direction == Direction.VERTICAL)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Green;
            base.updateWindow();
        }
    }
}
