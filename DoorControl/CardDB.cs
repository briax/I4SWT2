using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    class CardDB : ICardDB
    {
        private bool _boolUser = false;

        public bool LookUpInDB(string name)
        {
            // in bin/Debug Good luck med resten! :D tak!
            const string path = @"card_database.txt";
            var sr = new StreamReader(path);
            string line;
           
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Equals(name))
                {
                    _boolUser = true;
                    break;
                }
                else
                {
                    _boolUser = false;
                }
          }
          
          sr.Close();
          
          return _boolUser;
        }
    }
}
