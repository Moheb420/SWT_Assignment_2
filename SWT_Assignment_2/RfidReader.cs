using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Assignment_2.Interfaces;

namespace SWT_Assignment_2
{
    public class RfidReader:IRFiDReader
    {
        public event EventHandler<RfidDetectEvent>? RfidDetectEvent;
        public void OnRfidRead(int id) => RfidDetectEvent?.Invoke(this, new RfidDetectEvent{RfId = id});

    }
}
