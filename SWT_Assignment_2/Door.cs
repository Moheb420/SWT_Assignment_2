using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using SWT_Assignment_2.Interfaces;

namespace SWT_Assignment_2
{
    public class Door:IDoor
    {
      
        Display display = new Display();

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
                display.displayConenctPhone();
                
            }

        }

        public void OnDoorClose()
        {
            if (isOpen)
            {
                isOpen = false;
                DoorEvent(isOpen);
                 Console.WriteLine("Enter id for rfid");
                //int id =  Convert.ToInt32(Console.ReadLine());
                //if(id != null)
                //_StationControl.RfidDetected(id);
            }
        }



        private void DoorEvent(bool argEventVal) => DoorEvent_?
            .Invoke(this, new DoorEventArg() { DoorOpen = argEventVal });

        
    }
}
