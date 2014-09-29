using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    public class DoorControlImpl : IDoorControl
    {
        private string _name;
        private readonly CardDB _cardDB = new CardDB();
        private bool requestOk;
        private Door door;
        private readonly Beeper _beeper = new Beeper();

        public bool RequestEntry(string name)
        {
            this._name = name;
            requestOk = _cardDB.LookUpInDB(_name);
            return requestOk;
        }

        public void ValidateEntryRequest()
        {
            if (!requestOk)
            {
                throw new Exception("Entry cannot be granted - user does not exist.");
            }
            else
            {
                door = new Door(requestOk);
            }
        }

        public void MakeHappyNoise()
        {
            
            _beeper.SomeNoise();
        }

        public void OpenDoor()
        {
            door.Open();
            MakeHappyNoise();
        }

        public void CloseDoor()
        {
            door.Close();
        }

        public bool GetDoorStatus()
        {
            return door.DoorStatus();
        }
    }
}
