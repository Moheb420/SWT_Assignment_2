﻿using SWT_Assignment_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using NSubstitute;

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
        private StationControl _uut;


        [SetUp]
        public void Setup()
        {
            fakeCharger_ = Substitute.For<IChargeControl>();
            fakeDoor_ = Substitute.For<IDoor>();
            fakeDisplay_ = Substitute.For<IDisplay>();
            fakeRFiDReader = Substitute.For<IRFiDReader>();
            fakeLogfile_ = Substitute.For<ILogFile>();
            _uut = new StationControl(fakeCharger_, fakeDisplay_, fakeLogfile_, fakeRFiDReader, fakeDoor_);
        }

        //[Test]
        //public void InDoorOpen_DisplayFunctionCalled()
        //{
        //    fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = true });
        //    //fakeDisplay_.Received(1).displayStationMessage("Dør åbnet");
        //}


        //[Test]
        //public void OnDoorClose_DisplayFunctionCalled()
        //{
        //    fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = false });
        //    //fakeDisplay_.Received(1).displayStationMessage("Dør lukket");
        //}

        //[TestCase(123)]
        //[TestCase(0)]
        //[TestCase(int.MinValue)]
        //[TestCase(int.MaxValue)]

        //public void RfidDetect(int num)
        //{

        //    fakeCharger_.IsConnected().Returns(true);
        //    fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num});

        //    fakeCharger_.Received().IsConnected();
        //    fakeCharger_.Received().StartCharge();
        //    fakeCharger_.Received().StopCharge();
        //    fakeLogfile_.Received().log($"Skab låst med RFID: {num}");
        //    fakeDisplay_.Received().displayStationMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");

          
        //}

        //[TestCase(123)]
        //[TestCase(0)]
        //[TestCase(int.MinValue)]
        //[TestCase(int.MaxValue)]

        //public void InDoorOpen_DisplayFunctionCalled(int num)
        //{

        //    fakeCharger_.IsConnected().Returns(true);
        //    fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });

        //    fakeCharger_.Received().IsConnected();
        //    fakeCharger_.Received().StartCharge();
        //    fakeCharger_.Received().StopCharge();
        //    fakeLogfile_.Received().log($"Skab låst med RFID: {num}");
        //    fakeDisplay_.Received().displayStationMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        //}

        //[TestCase(123, 321)]
        //[TestCase(0,34)]

        //public void RfidDetectWithDifferentID(int num, int num2)
        //{

        //    fakeCharger_.IsConnected().Returns(true);
        //    fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });

        //    fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num2 });

        //    fakeDisplay_.Received().displayStationMessage("Forkert RFID tag");


        //}


        //[Test]

        //public void RfidIsNotConnected()
        //{
        //    int num = 32;
        //    fakeCharger_.IsConnected().Returns(false);
        //    fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });
            

        //    fakeDisplay_.Received().displayStationMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");


        //}

        //[Test]

        //public void RfidDetected()
        //{
        //    int num = 32;
        //    fakeCharger_.IsConnected().Returns(false);
        //    fakeDoor_.DoorEvent_ += Raise.EventWith<DoorEventArg>(new DoorEventArg { DoorOpen = true });
        //    fakeDisplay_.Received(1).displayStationMessage("Dør åbnet");
        //    fakeRFiDReader.RfidDetectEvent += Raise.EventWith<RfidDetectEvent>(new RfidDetectEvent { RfId = num });

        //    fakeDisplay_.Received().displayStationMessage(Arg.Any<string>());


        //}


    }
}