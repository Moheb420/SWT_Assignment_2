using NSubstitute;
using SWT_Assignment_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Test.Unit
{
    [TestFixture]
    public class DoorTest
    {

        private Door _uut;

        [SetUp]
        public void Setup()
        {

            _uut = new Door();
        }

        [Test]
        public void DoorOpen()
        {
            DoorEventArg DoorIsOpen = null;
            _uut.DoorEvent_ += (o, e) => DoorIsOpen = e;
            _uut.OnDoorOpen();
            Assert.That(DoorIsOpen.DoorOpen);
        }


        [TestCase(true, 2, true)]

        [TestCase(false, 0, false)]

        public void DoorClose(bool x, int y, bool result)
        {
            bool DoorIsClosed = false;
            int countEvent = 0;
            _uut.DoorEvent_ += (o, e) =>
            {
                DoorIsClosed = !e.DoorOpen;
                countEvent++;
            };
            if (x)
            {
                _uut.OnDoorOpen();
            }
            _uut.OnDoorClose();

            Assert.That(countEvent == y && DoorIsClosed == result);

        }


        [TestCase(true, true, false)]
        [TestCase(true, false, false)]

        [TestCase(false, false, true)]
        [TestCase(false, true, false)]
        public void DoorisLocked(bool x, bool y, bool result)
        {
            if (x)
                _uut.OnDoorOpen();

            _uut.LockDoor();

            if (y)
                _uut.UnlockDoor();

            Assert.That(_uut.isLocked == result);
        }



        [TestCase(true, false, false)]
        [TestCase(true, true, false)]
        [TestCase(false, false, false)]
        [TestCase(false, true, false)]
        public void DoorisUnLocked(bool x, bool y, bool result)
        {
            if (x)
                _uut.OnDoorOpen();

            if (y)
                _uut.UnlockDoor();

            Assert.That(_uut.isLocked == result);
        }

    }
}