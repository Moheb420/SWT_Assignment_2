using SWT_Assignment_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Test.Unit
{
    [TestFixture]
    public class RfidReaderTest
    {

        private RfidReader _uut;

        [SetUp]
        public void Setup()
        {

            _uut = new RfidReader();
        }

        [TestCase(1)]

        [TestCase(0)]

        [TestCase(-1)]
        public void RfidReader(int num)
        {
            RfidDetectEvent rfidDetectEvent = null;
            _uut.RfidDetectEvent += (object_, event_) => rfidDetectEvent = event_;
            _uut.OnRfidRead(num);
            Assert.That(rfidDetectEvent.RfId  == num);

        }
    }
}
