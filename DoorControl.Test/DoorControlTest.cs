using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DoorControl.Test
{
    [TestFixture]
    public class DoorControlTest
    {
        [Test]
        public void DoorControl_RequestEntry_UsernameIsInDBIsTrue()
        {
            var uut = new DoorControlImpl();
            Assert.True(uut.RequestEntry("Daniel"));
        }

        [Test]
        public void DoorControl_RequestEntry_UsernameIsNotInDBIsFalse()
        {
            var uut = new DoorControlImpl();
            Assert.False(uut.RequestEntry("Ib"));
        }

        [Test]
        public void DoorControl_ValidateEntry_UsernameIsIncorrect()
        {
            var uut = new DoorControlImpl();
            uut.RequestEntry("Test");
            var exception = Assert.Throws<Exception>(() => uut.ValidateEntryRequest());
            Assert.That(exception.Message, Is.EqualTo("Entry cannot be granted - user does not exist."));
        }

        [Test]
        public void DoorControl_OpenDoor_CanOpenDoorWithCorrectID()
        {
            var uut = new DoorControlImpl();
            uut.RequestEntry("Daniel");
            uut.ValidateEntryRequest();
            uut.OpenDoor();
            Assert.True(uut.GetDoorStatus());
        }

        [Test]
        public void DoorControl_OpenDoor_CanCLoseDoorWithCorrectID()
        {
            var uut = new DoorControlImpl();
            uut.RequestEntry("Daniel");
            uut.ValidateEntryRequest();
            uut.OpenDoor();
            Assert.True(uut.GetDoorStatus());
            uut.CloseDoor();
            Assert.False(uut.GetDoorStatus());
        }
    }
}
