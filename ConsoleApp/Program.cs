using Ladeskab;
using SWT_Assignment_2;
using SWT_Assignment_2.Interfaces;
using UsbSimulator;

class Program
{
    public static int Main() { 
    // Assemble your system here from all the classes
        IDoor door = new Door();

        IDisplay display = new Display();
        IRFiDReader rfidReader = new RfidReader();
        UsbChargerSimulator usbChargerSimulator = new UsbChargerSimulator();

        StationControl stationControl = newStationControl(door, rfidReader, display, usbChargerSimulator);

        bool finish = false;
        do
        {
            string input;

            display.displayProgramMessage("Indtast E, O, C, U, R: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    door.OnDoorOpen();
                    break;

                case 'C':
                    door.OnDoorClose();
                    break;

                case 'U':
                    usbChargerSimulator.SimulateConnected(usbChargerSimulator.Connected);
                    display.displayChargingMessage("USB is connecting : " + usbChargerSimulator.Connected);
                    break;

                case 'R':
                    display.displayProgramMessage("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();
                    int id = Convert.ToInt32(idString);
                    stationControl.RfidDetected(id);
                    break;

                default:
                    break;
            }

        } while (!finish);

        return 0;
    }

    public static  StationControl newStationControl(IDoor door, IRFiDReader rFiDReader, IDisplay display,
       IUsbCharger usbCharger )
    {
        return new StationControl(new ChargeControl(usbCharger, display), display, new LogFile(), rFiDReader, door,usbCharger);
    }
}
