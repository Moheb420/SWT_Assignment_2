using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{
    public interface IDisplay
    {
        void displayProgramMessage(string val);
        void displayStationMessage(string val);
        void displayChargingMessage(string val);

        void updateDisplay();
    }
}
