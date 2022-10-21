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

        //public Door( IStationControl stationControl)
        //{
        //    _StationControl = stationControl;
        //}
        public void UnlockDoor()
        {
            throw new NotImplementedException();
        }

        public void LockDoor()
        {
            throw new NotImplementedException();
        }

        public void OnDoorOpen()
        {
            Console.WriteLine("Door is opened");
           

            
        }

        public void OnDoorClose()
        {
            throw new NotImplementedException();
        }
    }
}
