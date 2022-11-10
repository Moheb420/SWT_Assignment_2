﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SWT_Assignment_2;
using SWT_Assignment_2.Interfaces;
using UsbSimulator;

namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private IUsbCharger usbCharger;
        private int _oldId;
        private IDoor _door;
        public IDisplay display_;
        private IRFiDReader rfiDReader_;
        private ILogFile logfile_;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
        public StationControl(IChargeControl chargeControl, IDisplay chargerDisplay, ILogFile logfile, IRFiDReader rFiDReader, IDoor door, IUsbCharger usbCharger_)
        {
            _charger = chargeControl;
            display_ = chargerDisplay;
            logfile_ = logfile;
            rfiDReader_ = rFiDReader;
            _door = door;
            usbCharger = usbCharger_;

            rfiDReader_.RfidDetectEvent += HandleRfid;
            _door.DoorEvent_ += HandleDoor;
            //Curent value of usb ?
        }

        private void HandleRfid(object? sender, RfidDetectEvent e)
        {
            if (_charger.IsConnected())
            {

                _door.LockDoor();
                _charger.StartUSBCharge();
                _oldId = e.RfId;

                logfile_.log($"Skab låst med RFID: {e.RfId}");
                display_.Writeline("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                _state = LadeskabState.Locked;
            }
        }

        private void HandleDoor(object? sender, DoorEventArg e)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (e.DoorOpen == true)
                    {
                        _state = LadeskabState.DoorOpen;
                        display_.displayConenctPhone();
                    }
                    if (e.DoorOpen == false)
                    {
                        _state = LadeskabState.Locked;
                        display_.displayStationMessage("Døren er lukket");
                    }
                    break;
                    
            }
        }



            rfiDReader_.RfidDetectEvent += HandleRfid;
            _door.DoorEvent_ += HandleDoor;
        }

        private void HandleDoor(object? sender, DoorEventArg e)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (e.DoorOpen == true)
                    {
                        _state = LadeskabState.DoorOpen;
                        display_.displayConenctPhone();
                    }
                    if (e.DoorOpen == false)
                    {
                        _state = LadeskabState.Locked;
                        display_.displayStationMessage("Døren er lukket");
                    }
                    break;
                    
            }
        }

        private void HandleRfid(object? sender, RfidDetectEvent e)
        {
            if (_charger.IsConnected()){
                _door.LockDoor();
                _charger.StartUSBCharge();
                _oldId = e.RfId;

                logfile_.log($"Skab låst med RFID: {e.RfId}");
                display_.Writeline("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                _state = LadeskabState.Locked;
            }
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.IsConnected())
                    {

                        _door.LockDoor();
                        _charger.StartUSBCharge();
                        _oldId = id;

                        logfile_.log($"Skab låst med RFID: {id}");

                    display_.Writeline("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        display_.Writeline("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopUSBCharge();
                        _door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            logfile_.log(logFile);
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        display_.Writeline("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        display_.Writeline("Forkert RFID tag");
                    }

                    break;
            }
        }

    }
}
