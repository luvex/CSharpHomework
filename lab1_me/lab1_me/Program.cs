using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_me
{
    class Program
    {
        static void sendMessage(MyForm form, window iCtrlID, int iMsgID, int iParam)
        {
            form.ProcEvent(iCtrlID, iMsgID, iParam);
        }

        static void Main(string[] args)
        {
            MyForm form = new MyForm(new CRect(0, 0, 0, 0),
                "Demo of my window foundation class library");

            form.create();
            Console.WriteLine("--------------------------lab1----------------------------");
            Console.WriteLine("--------{0}--------", form);
            form.setWindowPos(new CRect(0, 0, 400, 400));
            form.updateWindow();
            Console.WriteLine("--------{0}--------", form);
            form.setWindowPos(new CRect(0, 0, 350, 370));
            form.updateWindow();

            Console.WriteLine("\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------lab2----------------------------");
            sendMessage(form, form.mx_Button, MyForm.MX_BUTTON_CLICKON, 0);
            sendMessage(form, form.mx_HScrollBar, MyForm.MX_SCROLLBAR_H, 10);
            //Horizontal scroll bar's handler should repaint the edit box;
            sendMessage(form, form.mx_HScrollBar, MyForm.MX_SCROLLBAR_H, -11);
            //Horizontal scroll bar's handler should repaint the edit box;
            sendMessage(form, form.mx_VScrollBar, MyForm.MX_SCROLLBAR_V, 20);
            // Vertical scroll bar's handler should repaint the edit box;
            sendMessage(form, form, MyForm.MX_CLOSE, 0);
            sendMessage(form, form.mx_Button, MyForm.MX_BUTTON_CLICKON, 0);
            Console.ReadLine();

        }
    }
}
