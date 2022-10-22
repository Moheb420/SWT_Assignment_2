using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{

    public class DoorEventArg : EventArgs
    {
        public bool DoorOpen { set; get; }
    }
    public interface IDoor
    {
        event EventHandler<DoorEventArg> DoorEvent_;
        public void UnlockDoor();
        public void LockDoor();
        public void OnDoorOpen();
        public void OnDoorClose();
    }
}
