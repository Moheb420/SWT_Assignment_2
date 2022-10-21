using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Assignment_2.Interfaces;

namespace SWT_Assignment_2
{
    public class ChargeControl:IChargeControl
    {
        public bool Connected { get; }

        public bool Connected_()
        {
            //throw new NotImplementedException();
            return true;
        }

        public void readyToCharge()
        {
            // call stop and start charge
            throw new NotImplementedException();
        }
    }
}
