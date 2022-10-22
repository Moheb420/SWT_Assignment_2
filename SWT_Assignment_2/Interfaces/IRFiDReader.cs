using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{


  
    public interface IRFiDReader
    {
        event EventHandler<RfidDetectEvent> RfidDetectEvent; 
        public void OnRfidRead(int id);
    }

    public class RfidDetectEvent : EventArgs
    {
        public int RfId { set; get; }
    }
}
