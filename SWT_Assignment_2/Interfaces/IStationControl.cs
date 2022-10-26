using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{
    public class CurrentConnectionArg : EventArgs
    {
        // Value in mA (milliAmpere)
        public double Current { set; get; }
    }

    
        public interface IStationControl
    {

        // Event triggered on new current value
        event EventHandler<CurrentConnectionArg> CurrentConnectionVal;
        private void RfidDetected(int id){}
    }
}
