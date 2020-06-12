using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace MatlabLib
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

        public Points(MWArray X, MWArray Y) {
            this.length = X.ToArray().Length;
            double[,] x = (double[,])X.ToArray();
            double[,] y = (double[,])Y.ToArray();
            this.X = new float[length];
            this.Y = new float[length];
            for (int i = 0; i < length; i++)
            {
                this.X[i] = Convert.ToSingle(x[0, i]);
                this.Y[i] = Convert.ToSingle(y[0, i]);
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
}
