using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGL
{
    public static class matrix_tools
    {
        public static double[] transpose(double[] m)
        {
            double[] trans = new double[16];
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {
                    trans[j + i * 4] = m[i * 4 + j];
                }
            return trans;
        }
        public static double[] multiply(double[] A, double[] B)
        {
            double[] result = new double[16];
            int index = 0;
            double temp;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        temp += A[i*4 + k] * B[k*4 + j];
                    }
                    result[index++] = temp;
                }

            }
            return result;
        }
        //public static double[] getXYZ(double[] m)
        //{
        //    //double [] XYZ = new
        //    //return XYZ;
        //}

        public static double [] inverse(double [] m)
        {{
                double[] inv = new double[16];
                double[] invOut = new double[16];
                double det;
                int i;

                inv[0] = m[5] * m[10] * m[15] -
                         m[5] * m[11] * m[14] -
                         m[9] * m[6] * m[15] +
                         m[9] * m[7] * m[14] +
                         m[13] * m[6] * m[11] -
                         m[13] * m[7] * m[10];

                inv[4] = -m[4] * m[10] * m[15] +
                          m[4] * m[11] * m[14] +
                          m[8] * m[6] * m[15] -
                          m[8] * m[7] * m[14] -
                          m[12] * m[6] * m[11] +
                          m[12] * m[7] * m[10];

                inv[8] = m[4] * m[9] * m[15] -
                         m[4] * m[11] * m[13] -
                         m[8] * m[5] * m[15] +
                         m[8] * m[7] * m[13] +
                         m[12] * m[5] * m[11] -
                         m[12] * m[7] * m[9];

                inv[12] = -m[4] * m[9] * m[14] +
                           m[4] * m[10] * m[13] +
                           m[8] * m[5] * m[14] -
                           m[8] * m[6] * m[13] -
                           m[12] * m[5] * m[10] +
                           m[12] * m[6] * m[9];

                inv[1] = -m[1] * m[10] * m[15] +
                          m[1] * m[11] * m[14] +
                          m[9] * m[2] * m[15] -
                          m[9] * m[3] * m[14] -
                          m[13] * m[2] * m[11] +
                          m[13] * m[3] * m[10];

                inv[5] = m[0] * m[10] * m[15] -
                         m[0] * m[11] * m[14] -
                         m[8] * m[2] * m[15] +
                         m[8] * m[3] * m[14] +
                         m[12] * m[2] * m[11] -
                         m[12] * m[3] * m[10];

                inv[9] = -m[0] * m[9] * m[15] +
                          m[0] * m[11] * m[13] +
                          m[8] * m[1] * m[15] -
                          m[8] * m[3] * m[13] -
                          m[12] * m[1] * m[11] +
                          m[12] * m[3] * m[9];

                inv[13] = m[0] * m[9] * m[14] -
                          m[0] * m[10] * m[13] -
                          m[8] * m[1] * m[14] +
                          m[8] * m[2] * m[13] +
                          m[12] * m[1] * m[10] -
                          m[12] * m[2] * m[9];

                inv[2] = m[1] * m[6] * m[15] -
                         m[1] * m[7] * m[14] -
                         m[5] * m[2] * m[15] +
                         m[5] * m[3] * m[14] +
                         m[13] * m[2] * m[7] -
                         m[13] * m[3] * m[6];

                inv[6] = -m[0] * m[6] * m[15] +
                          m[0] * m[7] * m[14] +
                          m[4] * m[2] * m[15] -
                          m[4] * m[3] * m[14] -
                          m[12] * m[2] * m[7] +
                          m[12] * m[3] * m[6];

                inv[10] = m[0] * m[5] * m[15] -
                          m[0] * m[7] * m[13] -
                          m[4] * m[1] * m[15] +
                          m[4] * m[3] * m[13] +
                          m[12] * m[1] * m[7] -
                          m[12] * m[3] * m[5];

                inv[14] = -m[0] * m[5] * m[14] +
                           m[0] * m[6] * m[13] +
                           m[4] * m[1] * m[14] -
                           m[4] * m[2] * m[13] -
                           m[12] * m[1] * m[6] +
                           m[12] * m[2] * m[5];

                inv[3] = -m[1] * m[6] * m[11] +
                          m[1] * m[7] * m[10] +
                          m[5] * m[2] * m[11] -
                          m[5] * m[3] * m[10] -
                          m[9] * m[2] * m[7] +
                          m[9] * m[3] * m[6];

                inv[7] = m[0] * m[6] * m[11] -
                         m[0] * m[7] * m[10] -
                         m[4] * m[2] * m[11] +
                         m[4] * m[3] * m[10] +
                         m[8] * m[2] * m[7] -
                         m[8] * m[3] * m[6];

                inv[11] = -m[0] * m[5] * m[11] +
                           m[0] * m[7] * m[9] +
                           m[4] * m[1] * m[11] -
                           m[4] * m[3] * m[9] -
                           m[8] * m[1] * m[7] +
                           m[8] * m[3] * m[5];

                inv[15] = m[0] * m[5] * m[10] -
                          m[0] * m[6] * m[9] -
                          m[4] * m[1] * m[10] +
                          m[4] * m[2] * m[9] +
                          m[8] * m[1] * m[6] -
                          m[8] * m[2] * m[5];

                det = m[0] * inv[0] + m[1] * inv[4] + m[2] * inv[8] + m[3] * inv[12];

                det = 1.0 / det;

                for (i = 0; i < 16; i++)
                    invOut[i] = inv[i] * det;

                return invOut;
            }
        }

    }
}
