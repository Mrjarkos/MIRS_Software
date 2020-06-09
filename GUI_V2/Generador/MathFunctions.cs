using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador
{
    public class Points
    {
        public float[] X;
        public float[] Y;
        int length;

        public Points(int length)
        {
            this.length = length;
            X = new float[length];
            Y = new float[length];
            for (int i = 0; i < length; i++)
            {
                X[i] = 0;
                Y[i] = 0;
            }
        }
        public static Points cpPoints(Points points, int cicles)
        {
            Points points1 = new Points(cicles * points.length);
            for (int j = 0; j < cicles; j++)
            {
                for (int i = 0; i < points.length; i++)
                {
                    points1.X[i + j * (points.length)] = points.X[i] + j * points.X[points.length - 1];
                    points1.Y[i + j * (points.length)] = points.Y[i];
                }
            }

            return points1;
        }
    }

    public abstract class MathFunctions
    {
        public static Points Sin(float Amp, float freq, float Offset, bool Inv, float Ph, int length= 4096) {
            float T = 1/freq;
            Ph = Ph * (float)Math.PI / (float)180;
            Points points = new Points(length);
            Amp=Inv==true?(float)-1*Amp:Amp;
            
            for (int i = 0; i < length; i++)
            {
                points.X[i] = (float)i / (float)length *T;
                points.Y[i] = (float)(Amp * Math.Sin(2 * Math.PI * freq * points.X[i] + Ph) + Offset);
            }
            return points;
        }
        
        public static Points Square(float Amp, float freq, float Offset, bool Inv, float duty, float Ph, int length = 4096)
        {
            double x;
            float T = 1/freq;
            Ph = Ph/ (float)360*T;
            duty = duty / (float)100;
            Points points = new Points(length);
            Amp = Inv == true ? (float)-1 * Amp : Amp;
            for (int i = 0; i < length; i++)
            {
                points.X[i] = (float)i / (float)length * 1 / freq;
                x = points.X[i] + Ph;
                points.Y[i] = (float)x%T > T*duty ? -Amp/2 + Offset : Amp/2 + Offset;
            }
            return points;
        }

        public static Points None(float freq=(float)1e3, int length = 4096)
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
