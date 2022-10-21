using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{
    public interface IChargeControl
    {
        public bool Connected { get; }
        public bool Connected_();
        public void readyToCharge();
    }
}
