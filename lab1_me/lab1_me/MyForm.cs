using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_me
{
    class MyForm : Form
    {
        public Button mx_Button;
        public ScrollBar mx_VScrollBar;
        public ScrollBar mx_HScrollBar;
        public bool windowState = false;
        public window[] mx_windowArray;
        public List<messageItem> mx_msgs = new List<messageItem>();

        public const int MX_BUTTON_CLICKON = 1001;
        public const int MX_SCROLLBAR_V = 2001;
        public const int MX_SCROLLBAR_H = 2002;
        public const int MX_CLOSE = 3001;

        public MyForm(CRect myform, string title)
            : base(myform, title)
        {
        }
        public override void create()
        {
            try
            {
                windowState = true;
                mx_Button = new Button(new CRect(),"OK");
                mx_Button.create();
                mx_VScrollBar = new ScrollBar(new CRect(),Direction.VERTICAL);
                mx_VScrollBar.create();
                mx_HScrollBar = new ScrollBar(new CRect(), Direction.HORIZONTIAL);
                mx_HScrollBar.create();

                mx_windowArray = new window[3];
                mx_windowArray[0] = mx_Button;
                mx_windowArray[1] = mx_VScrollBar;
                mx_windowArray[2] = mx_HScrollBar;

                mx_msgs.Add(new messageItem(this,MX_CLOSE,closeWindow));
                mx_msgs.Add(new messageItem(mx_windowArray[0],MX_BUTTON_CLICKON,onBtnClick));
                mx_msgs.Add(new messageItem(mx_windowArray[1],MX_SCROLLBAR_V,onVerScroll));
                mx_msgs.Add(new messageItem(mx_windowArray[2],MX_SCROLLBAR_H,onHorScroll));
            }
            catch
            {
                Console.WriteLine("Creating form failed!");
            }
            
        }
        public void setControlPos()
        {
            CRect insideForm = getInsideForm();
            mx_windowArray[0].setWindowPos(new CRect(insideForm.right-10-120,insideForm.bottom-10-30,120,30));
            mx_windowArray[1].setWindowPos(new CRect(insideForm.right-20,insideForm.top,20,insideForm.height-10-30-10-20));
            mx_windowArray[2].setWindowPos(new CRect(insideForm.left,insideForm.bottom-10-30-10-20,insideForm.width-20,20));
            updateWindow();
        }
        public override void setWindowPos(CRect mx_wnd)
        {
            base.setWindowPos(mx_wnd);
            setControlPos();
        }

        public override void updateWindow()
        {
            foreach (window temp in mx_windowArray)
            {
                temp.updateWindow();
            }
        }

        public void ProcEvent(window iCtrlID,int iMsgID,int iParam)
        {
            foreach (messageItem temp in mx_msgs)
            {
                if (temp.mx_ctrl.Equals(iCtrlID) && temp.mx_msgId == iMsgID)
                {
                    temp.mx_msgProc(iParam);
                }
            }
        }

        public void closeWindow(int param)
        {
            if (windowState == true)
            {
                this.windowState = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Window is destroyed.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Window does not exist!");
            }
        }
        public void onBtnClick(int param)
        {
            if (windowState == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Button OK is clicked.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Button OK does not exist!");
            }
        }
        public void onVerScroll(int param)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Vertical scroll bar IDC_SBH_VER is clicked, and move window ({0}, 0);",param);
            if (mx_VScrollBar.setScrollPos(param))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Edit move (0, {0})", param);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Scroll action failed! Out of bound");
            }
        }
        public void onHorScroll(int param)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Horizontal scroll bar IDC_SBH_HOR is clicked, and move window ({0}, 0)", param);
            if (mx_HScrollBar.setScrollPos(param))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Edit move ({0}, 0)", param);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Scroll action failed! Out of bound");
            }
        }
    }
}
