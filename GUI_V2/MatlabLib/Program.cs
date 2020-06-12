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
    public static class Program
    {
        static void Main(string[] args)
        {
            BasicFunctions basicFunctions = new BasicFunctions();
            float A = (float)1.2;
            float f = (float)10;
            float Offset = (float)0.5;
            float ph = 0;
            int length = 4096;
            MWArray[] b = basicFunctions.Sin((int)2, (MWArray)A, (MWArray)f, (MWArray)Offset, (MWArray)ph, (MWArray)length);
            MWNumericArray X = (MWNumericArray)b[0];
            MWNumericArray Y = (MWNumericArray)b[1];
            length = X.ToArray().Length;
            double[,] x = (double[,])X.ToArray(MWArrayComponent.Real);
            double[,] y = (double[,])Y.ToArray(MWArrayComponent.Real);
            var c = new float[length];
            var d = new float[length];
            for (int i = 0; i < length; i++)
            {
                c[i] = Convert.ToSingle(x[0,i]);
                d[i] = Convert.ToSingle(y[0,i]);
            }
            Console.WriteLine("Sin errores");
        }
    }

    public class MatLib {
        BasicFunctions basicFunctions;
        public MatLib() {
            basicFunctions = new BasicFunctions();
        }
    }
}
