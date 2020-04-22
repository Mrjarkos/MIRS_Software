using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public enum Chirp_Type {
        Lineal, Logaritmic
    }
    class Chirp: WaveForm 
    {
        float freq_init { get; set; }
        float freq_final { get; set; }
        Chirp_Type type { get; set; }
        float time { get; set; }
    }
}
