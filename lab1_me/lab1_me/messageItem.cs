using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_me
{
    public delegate void MsgProc(int iParam);

    class messageItem
    {
        public window mx_ctrl;
        public int mx_msgId;
        public MsgProc mx_msgProc;
        public messageItem(window ctrl,int msgId,MsgProc msgProc)
        {
            this.mx_ctrl = ctrl;
            this.mx_msgId = msgId;
            this.mx_msgProc = msgProc;
        }

    }
}
