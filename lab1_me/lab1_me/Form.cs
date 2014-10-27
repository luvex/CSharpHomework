using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_me
{
    class Form:window
    {
        string title;
        public const int mx_titleHeight = 20;
        public const int mx_margin = 3;
        public Form(CRect form, String title) : base(form)
        {
            this.title = title;
        }

        public CRect getInsideForm()
        {
            return new CRect(mx_window.left+mx_margin,mx_window.top+mx_margin,mx_window.width-2*mx_margin,mx_window.height-2*mx_margin);
        }

        public override string ToString()
        {
            return this.title;
        }

        public override void updateWindow()
        {
            Console.WriteLine(ToString());
        }
    }
}
