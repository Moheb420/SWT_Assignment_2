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
        private Display display;
        private StationControl _uut;


        [SetUp]
        public void Setup()
        {
            display = new Display();
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
            display.displayStationMessage("Dør åbnet");
            Assert.AreEqual(display.stationMessage, "Dør åbnet");
        }


        [Test]
        public void OnDoorClose_DisplayFunctionCalled()
        {
            fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = false });
            display.displayStationMessage("Dør lukket");
            Assert.AreEqual(display.stationMessage, "Dør lukket");
        }

        [TestCase(123)]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]

        public void RfidDetectFirstID(int num)
        {

            fakeCharger_.IsConnected().Returns(true);
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });
            Assert.AreEqual(true, fakeCharger_.IsConnected());
            fakeCharger_.StartUSBCharge();
            fakeCharger_.StopUSBCharge();
            fakeLogfile_.log($"Skab låst med RFID: {num}");
            fakeDisplay_.displayStationMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        [Test]

        public void RfidDetectOpenDoor()
        {
            int id = 32;
            fakeCharger_.IsConnected().Returns(false);
            fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = true });
            fakeDisplay_.displayStationMessage("Dør åbnet");
            fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = true });
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = id });
            fakeDisplay_.displayStationMessage(Arg.Any<string>());
        }

        [Test]

        public void RfidDetectTelefonNotConnected()
        {
            int id = 32;
            fakeCharger_.IsConnected().Returns(false);
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = id });

            fakeDisplay_.displayStationMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
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
            fakeCharger_.StopUSBCharge();
            fakeLogfile_.log($"Skab låst op med RFID: {num}");
            fakeDisplay_.displayStationMessage("Åben skabet og tag din telefon ud, husk at luk døren efter dig!");
        }

        [TestCase(123)]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]

        public void InDoorOpen_DisplayFunctionCalled(int num)
        {

            fakeCharger_.IsConnected().Returns(true);
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });
            fakeCharger_.IsConnected();
            fakeCharger_.StartUSBCharge();
            fakeCharger_.StopUSBCharge();
            fakeLogfile_.log($"Skab låst med RFID: {num}");
            fakeDisplay_.displayStationMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        [TestCase(44, 18)]
        [TestCase(-2, 22)]

        public void RfidDetectWithDifferentID(int num, int num2)
        {

            fakeCharger_.IsConnected().Returns(true);
            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });

            fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num2 });

            fakeDisplay_.displayStationMessage("Forkert RFID tag");

        }
    }
}
