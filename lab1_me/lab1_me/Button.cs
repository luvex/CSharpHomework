using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_me
{
    class Button:window
    {
        string btnLabel;

        public Button(CRect btn, string btnLabel)
            : base(btn)
        {
            this.btnLabel = btnLabel;
        }

        public override string ToString()
        {
            return "Button:" + btnLabel + base.ToString();
        }

        public override void updateWindow()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.updateWindow();
        }
    }
}
