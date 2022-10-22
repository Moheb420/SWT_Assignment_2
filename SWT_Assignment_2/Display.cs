using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{
    public class Display: IDisplay
    {

        public string programMessage;
        public string stationMessage;
        public string chargingMessage;

        private readonly IDisplay display;

        public Display()
        {
            programMessage = "Started";
            stationMessage = "init";
            chargingMessage = "none";
        }
        public Display(IDisplay display_)
        {
            display = display_;
            updateDisplay();
        }



        public void Writeline(string text) => Console.WriteLine(text);
        public void Writeline() => Console.WriteLine();

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
            Console.Clear();
           Writeline($"Station message : {stationMessage}");
          Writeline($"Charger message : {chargingMessage}");
            //Console.WriteLine();

          Writeline($"Program message : {programMessage}");
        }
    }
}
