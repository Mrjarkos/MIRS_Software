using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using MatlabBasicFunctions;

namespace MatlabLib
{
    public abstract class BasicMathFunctions
    {
        private static BasicFunctions basicFunctions = new BasicFunctions();

        public static Points Sin(float Amp, float freq, float Offset, bool Inv, float Ph, int length = 4096)
        {
            Amp = Inv == true ? (float)-1 * Amp : Amp;
            MWArray[] b = basicFunctions.Sin(2, Amp, freq, Offset, Ph, length);
            Points points = new Points(b[0], b[1]);
            return points;
        }

        public static Points SinRect(float Amp, float freq, float Offset, bool Inv, float Ph, int length = 4096)
        {
            Amp = Inv == true ? (float)-1 * Amp : Amp;
            MWArray[] b = basicFunctions.SinRect(2, Amp, freq, Offset, Ph, length);
            Points points = new Points(b[0], b[1]);
            return points;
        }

        public static Points Square(float Amp, float freq, float Offset, bool Inv, float duty, float Ph, int length = 4096)
        {
            Amp = Inv == true ? (float)-1 * Amp : Amp;
            MWArray[] b = basicFunctions.Square(2, Amp, freq, Offset, duty, Ph, length);
            Points points = new Points(b[0], b[1]);
            return points;
        }

        public static Points Triangular(float Amp, float freq, float Offset, bool Inv, float Ph, int length = 4096)
        {
            Amp = Inv == true ? (float)-1 * Amp : Amp;
            MWArray[] b = basicFunctions.Sawtooth(2, Amp, freq, Offset, Ph, 50, length);
            Points points = new Points(b[0], b[1]);
            return points;
        }

        public static Points Sawtooth(float Amp, float freq, float Offset, bool Inv, float duty, float Ph, int length = 4096)
        {
            Amp = Inv == true ? (float)-1 * Amp : Amp;
            MWArray[] b = basicFunctions.Sawtooth(2, Amp, freq, Offset, Ph, duty, length);
            Points points = new Points(b[0], b[1]);
            return points;
        }

        public static Points None(float freq = (float)1e3, int length = 4096)
        {
            Points points = new Points(length);
            for (int i = 0; i < length; i++)
            {
                points.X[i] = (float)i / (float)length * 1 / freq;
                points.Y[i] = 0;
            }
            return points;
        }
    }
}
    
