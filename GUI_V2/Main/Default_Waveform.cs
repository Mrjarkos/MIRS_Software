using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public enum Default_Wave_Form
    {
        Sinusoidal, Square, Triangular, Sawtooth, Sinus_Rectified
    }

    class Default_Waveform: WaveForm
    {
        Default_Wave_Form waveform { get; set; }
        float Ph { get; set; }
        float Offset { get; set; }
        float Duty { get; set; }
    }
}
