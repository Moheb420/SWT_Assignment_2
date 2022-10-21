using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{
    public class Display: IDisplay
    {

        private string programMessage;
        private string stationMessage;
        private string chargingMessage;


        public Display()
        {
            programMessage = "Started";
            stationMessage = "init";
            chargingMessage = "none";
            updateDisplay();
        }

        public void displayProgramMessage(string val)
        {
            programMessage = val;
            updateDisplay();
        }

        public void displayStationMessage(string val)
        {
            stationMessage = val;
            updateDisplay();
        }

        public void displayChargingMessage(string val)
        {
            chargingMessage = val;
            updateDisplay();
        }

        public void updateDisplay()
        {
            Console.WriteLine("Station message : ",stationMessage);
            Console.WriteLine("Charger message : ",chargingMessage);
            Console.WriteLine();
            Console.WriteLine("Program message : ", programMessage);
        }
    }
}
