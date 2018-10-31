using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadWritePort
{
    public class PortAccess
    {
        //Call OutPut function from DLL file.
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int adress, int value);

        //Call Input functionfrom DLL file
        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern void Input(int adress);
    }
}
