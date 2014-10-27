using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_me
{
    class window
    {
        public CRect mx_window;

        public window()
        {
            mx_window = new CRect();
        }

        public window(CRect mx_window)
        {
            this.mx_window = mx_window;
        }

        public window(int iLeft, int iTop, int iWidth, int iHeight)
        {
            this.mx_window.left = iLeft;
            this.mx_window.top = iTop;
            this.mx_window.width = iWidth;
            this.mx_window.height = iHeight;
        }

        public virtual void create()
        {
        }

        public virtual void setWindowPos(CRect mx_wnd)
        {
            this.mx_window = mx_wnd;
        }

        public virtual void setWindowPos(int iLeft, int iTop, int iWidth, int iHeight)
        {
            this.mx_window.left = iLeft;
            this.mx_window.top = iTop;
            this.mx_window.width = iWidth;
            this.mx_window.height = iHeight;
        }

        public virtual void updateWindow()
        {
            Console.WriteLine(ToString());
        }

        public override String ToString()
        {
            return mx_window.ToString();
        }

    }
}
