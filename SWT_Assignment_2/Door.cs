using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Assignment_2.Interfaces;

namespace SWT_Assignment_2
{
    public class Door:IDoor
    {
      
        IStationControl _StationControl;

        private bool isOpen;
        public bool isLocked;


        public event EventHandler<DoorEventArg>? DoorEvent_;

        public void UnlockDoor()
        {
            if (!isOpen)
                isLocked = false;
        }

        public void LockDoor()
        {
            if (!isOpen)
                isLocked = true;
        }

        public void OnDoorOpen()
        {
            if (!isLocked && !isOpen)
            {
                isOpen = true;
                DoorEvent(isOpen);
            }

        }

        public void OnDoorClose()
        {
            if (isOpen)
            {
                isOpen = false;
                DoorEvent(isOpen);
            }
        }



        private void DoorEvent(bool argEventVal) => DoorEvent_?
            .Invoke(this, new DoorEventArg() { DoorOpen = argEventVal });

        
    }
}
