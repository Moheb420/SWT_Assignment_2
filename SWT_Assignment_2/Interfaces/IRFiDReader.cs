using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{
    public interface IRFiDReader
    {
        public void OnRfidRead(int id);

        public void RfidDetected(int id);
    }
}
