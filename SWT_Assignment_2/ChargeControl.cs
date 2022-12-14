using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Assignment_2.Interfaces;

namespace SWT_Assignment_2
{
    public class ChargeControl : IChargeControl
    {
        private readonly IUsbCharger _usbCharger;
        public readonly IDisplay _display;


        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
            _usbCharger = usbCharger;
            _display = display;
        }
        public bool IsConnected()
        {
            return _usbCharger.Connected;
        }

        public void StartUSBCharge()
        {
            _usbCharger.StartCharge();
        }

        public void StopUSBCharge()
        {
            _usbCharger.StopCharge();
        }
    }
}
