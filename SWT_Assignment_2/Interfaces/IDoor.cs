using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Assignment_2.Interfaces
{
    public interface IDoor
    {
        public void UnlockDoor();
        public void LockDoor();
        public void OnDoorOpen();
        public void OnDoorClose();
    }
}
