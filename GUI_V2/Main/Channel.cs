using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public enum Channel_Name
    {
        Ch_A, Ch_B, Ch_C, Ch_D
    }

    public enum Function
    {
        Default, Burst, AC_Sweep, User//, Modulation
    }

    class Channel
    {
        Channel_Name name { get; set; }
        Function function { get; set; }
        bool enable { get; set; } 
        WaveForm wave { get; set; }
        //float A_max { get; set; }
        //float f_max { get; set; }
        
    }
}
