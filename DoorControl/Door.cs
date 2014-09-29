using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    class Door : IDoor
    {
        private bool _access;
        private bool _doorOpen;

        public Door(bool access)
        {
            _access = access;
        }

        public void Open()
        {
            if (_access)
            {
                _doorOpen = true;
            }
            else
            {
                throw new Exception("Cannot open door.");
            }
        }

        public void Close()
        {
            _doorOpen = false;
        }

        public bool DoorStatus()
        {
            return _doorOpen;
        }

    }
}
