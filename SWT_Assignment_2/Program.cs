using SWT_Assignment_2;
using SWT_Assignment_2.Interfaces;
using UsbSimulator;

class Program
{
    static void Main(string[] args)
    {
        // Assemble your system here from all the classes
        IDoor door = new Door();
        IDisplay display = new Display();
        IRFiDReader rfidReader = new RfidReader();
        UsbChargerSimulator usbChargerSimulator = new UsbChargerSimulator();

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
                    usbChargerSimulator.SimulateConnected(true);
                   display.displayChargingMessage("USB is connecting : " + usbChargerSimulator.Connected);
                    break;

                case 'R':
                    System.Console.WriteLine("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.OnRfidRead(id);
                    break;

                default:
                    break;
            }

        } while (!finish);
    }
}
