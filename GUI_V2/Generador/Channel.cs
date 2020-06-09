using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Generador
{
    public enum Default_Wave_Form
    {
        Sinusoidal, Square, Triangular, Sawtooth, Sinus_Rectified
    }

    class Channel
    {
        public Channel_Name name { get; set; }
        public bool enable { get; set; }
        Points wave { get; set; }
        public Color colorBrush;
        public FunctionControl Gui { get; set; }

        public Channel(Channel_Name name, Color color) {
            this.name = name;
            this.colorBrush = color;
            enable = false;
            wave = MathFunctions.None();
        }

        public Channel() { 
        
        }

        public void Set_Enable(bool en)
        {
            this.enable = en;
        }

        public void Enable() {
            this.enable = true;
        }

        public void Disable()
        {
            this.enable = false;
        }

        public void SetWaveForm(Points waveform)
        {
            this.wave = waveform;
        }

        public Points GetWaveform()
        {
            return this.wave;
        }

    }
}
