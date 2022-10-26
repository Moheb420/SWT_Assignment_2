using NSubstitute;
using SWT_Assignment_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;
using NUnit.Framework;

namespace SWT_Assignment_2.Test.Unit
{
    [TestFixture]
    public class ChargerControlTests
    {
        private ChargeControl _uut;
        private IUsbCharger _fakeUsbCharger;
        private IDisplay _fakeDisplay;
        [SetUp]
        public void Setup()
        {
            _fakeUsbCharger = Substitute.For<IUsbCharger>();
            _fakeDisplay = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_fakeUsbCharger,_fakeDisplay);
        }


        [Test]
        public void startChargeUsB()
        {
            _uut.StartCharge();
            _fakeUsbCharger.Received().StartCharge();
        }

        //[Test]
        //public void stopChargeUsB()
        //{
        //    _uut.StopCharge();
        //    _fakeUsbCharger.Received().StopCharge();
        //}


        //private const string noConnection = "Der er ingen forbindelse til en telefon";
        //private const string fullCharge = "Telefonen er fuld opladt: ";
        //private const string charging = "Opladning er igang sat: ";
        //private const string errorInConnection = "Noget gik galt med opladning: 'ERROR'";



        //[TestCase(0, noConnection)]
        //[TestCase(500.1, errorInConnection)]
        //[TestCase(double.MaxValue, errorInConnection)]
        //[TestCase(499.9, charging, true)]
        //[TestCase(5.1, charging, true)]
        //[TestCase(5, fullCharge, true)]
        //[TestCase(0.1, fullCharge, true)]


        //public void displayCounterValue(double x, string print, bool usesCurrent = false)
        //{
        //    _fakeUsbCharger.CurrentValueEvent += Raise.EventWith<CurrentEventArgs>(new CurrentEventArgs { Current = x });

        //    if (usesCurrent)
        //        print = print + x;

        //    _fakeDisplay.Received(1).displayChargingMessage(print);
        //}

        //[TestCase(-0.1)]
        //[TestCase(double.MinValue)]
        //public void DisplayChargerMinValue(double x)
        //{
        //    _fakeUsbCharger.CurrentValueEvent += Raise.EventWith<CurrentEventArgs>(new CurrentEventArgs { Current = x });

        //    _fakeDisplay.Received(0).displayChargingMessage(Arg.Any<string>());
        //}

        //[Test]
        //public void isConnectedTrue()
        //{
        //    _fakeUsbCharger.Connected.Returns(false);

        //    Assert.IsFalse(_uut.Connected);
        //}

        //[Test]
        //public void isConnectedFalse()
        //{
        //    _fakeUsbCharger.Connected.Returns(true);

        //    Assert.IsTrue(_uut.IsConnected());
        //}
    }
}

