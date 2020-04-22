using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    abstract class WaveForm
    {
        float freq { get; set; }
        float Amp { get; set; }
        bool Inv { get; set; }
    }
}
