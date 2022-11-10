using SWT_Assignment_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using NSubstitute;
using UsbSimulator;

namespace SWT_Assignment_2.Test.Unit
{
    [TestFixture]
    public class StationControlTest
    {
        private IChargeControl fakeCharger_;
        private IDoor fakeDoor_;
        private IDisplay fakeDisplay_;
        private IRFiDReader fakeRFiDReader;
        private ILogFile fakeLogfile_;
        private IUsbCharger fakeusbCharger_;
        private StationControl _uut;


        [SetUp]
        public void Setup()
        {
            fakeCharger_ = Substitute.For<IChargeControl>();
            fakeDoor_ = Substitute.For<IDoor>();
            fakeDisplay_ = Substitute.For<IDisplay>();
            fakeRFiDReader = Substitute.For<IRFiDReader>();
            fakeLogfile_ = Substitute.For<ILogFile>();
            fakeusbCharger_ = new UsbChargerSimulator();
            _uut = new StationControl(fakeCharger_, fakeDisplay_, fakeLogfile_, fakeRFiDReader, fakeDoor_, fakeusbCharger_);
        }

        [Test]
        public void InDoorOpen_DisplayFunctionCalled()
        {
            fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = true });
            fakeDisplay_.Received(1).displayConenctPhone();
        }


        [Test]
        public void OnDoorClose_DisplayFunctionCalled()
        {

            //fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = true });
            fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = false });
            fakeDisplay_.Received(1).displayStationMessage("Døren er lukket");
        }

        [TestCase(123)]
        [TestCase(1)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]

        public void RfidDetectFirstID(int num)
        {

            fakeCharger_.IsConnected().Returns(true);
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });
            fakeCharger_.Received().IsConnected();
            fakeDoor_.Received().LockDoor();
            fakeCharger_.Received().StartUSBCharge();
            fakeLogfile_.log($"Skab låst med RFID: {num}");
            fakeDisplay_.Received().Writeline("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        [Test]

        public void RfidDetectOpenDoor()
        {
            int id = 32;
            fakeCharger_.IsConnected().Returns(false);
            fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = true });
            fakeDisplay_.Received().displayConenctPhone();
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = id });
            fakeDisplay_.displayStationMessage(Arg.Any<string>());
        }

        [Test]

        public void RfidDetectTelefonNotConnected()
        {
            int id = 32;
            fakeCharger_.IsConnected().Returns(false);
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = id });
            fakeDisplay_.Received().displayStationMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }


        [TestCase(123)]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]

        public void RfidDetectSecondID(int num)
        {

            fakeCharger_.IsConnected().Returns(true);
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });
            fakeCharger_.Received().StartUSBCharge();
            fakeDoor_.Received().UnlockDoor();
            fakeLogfile_. Received().log($"Skab låst op med RFID: {num}");
            fakeDisplay_.Received().displayStationMessage("Tag din telefon ud af skabet og luk døren");
        }

      
        [TestCase(44, 18)]
        [TestCase(-2, 22)]

        public void RfidDetectWithDifferentID(int num, int num2)
        {

            fakeCharger_.IsConnected().Returns(true);
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });

            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num2 });

            fakeDisplay_.Received().displayStationMessage("Forkert RFID tag");

        }
    }
}
