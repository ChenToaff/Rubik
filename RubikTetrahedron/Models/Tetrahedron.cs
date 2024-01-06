using System;
using RubikTetrahedron.Enums;
namespace OpenGL
{ 
    public class Tetrahedron
    {
        public double[] rotation_matrix = new double[16] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
        public Color[] colors;
        public location loc;
        public bool isFlippedPiece;
        public bool isBottomPiece;
        public int id;
        private static int idCounter = 0;

        public static double edgeLength = 1;
        public static double height = (Math.Sqrt(6) / 3) * edgeLength;
        public static double width = (Math.Sqrt(3) / 2) * edgeLength;

        public Tetrahedron(Color[] colors, bool flippedPiece, bool bottomPiece = false)
        {
            this.id = idCounter++;
            this.colors = (Color[])colors.Clone();
            this.isFlippedPiece = flippedPiece;
            this.isBottomPiece = bottomPiece;
        }
    }
}