using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGL
{ 
    public class Tetrahedron
    {
        public double[] rotation_matrix = new double[16] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
        public Color[] colors;
        public int id;
        public location loc;

        public Tetrahedron(int id,Color[]  colors)
        {
            this.colors = (Color[])colors.Clone();
            this.id = id;
        }
    }
}