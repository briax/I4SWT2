using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    interface IDoor
    {
        void Open();
        void Close();
        bool DoorStatus();
    }
}
