using RubikTetrahedron.Enums;

namespace OpenGL
{
    public static partial class Utils
    {
        private static double[,] vertices = new double[4, 3] {
                { -0.5*Tetrahedron.edgeLength,   0.0f,   0.0f },
                { 0.5* Tetrahedron.edgeLength,  0.0f,  0.0f},
                { 0, Tetrahedron.width ,0},
                { 0, Tetrahedron.width/3, Tetrahedron.height},
                };

        private static int[,] indices = new int[4, 3] { { 0, 2, 1 }, { 0, 3, 2 }, { 1, 3, 0 }, { 1, 2, 3 } };

        public static void DrawTetrahedron(Tetrahedron t)
        {
            double[] CurrentRotationTraslation = new double[16];
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, CurrentRotationTraslation);
            GL.glPopMatrix();
            GL.glPushMatrix();
            GL.glPushMatrix();
            GL.glMultMatrixd(t.rotation_matrix);
            GL.glMultMatrixd(CurrentRotationTraslation);


            if (t.isFlippedPiece){
                FlippedPiece();
            }
            if (t.isBottomPiece){
                BottomPiece();
            }

            GL.glBegin(GL.GL_TRIANGLES);
            Vector[] triangle = new Vector[3];
            for (int j = 0; j < 4; j++)
            {
                if (!cRubik.shadingMode)
                {
                    setColor(t.colors[j]);
                }
                for (int i = 0; i < 3; i++)
                {
                    triangle[i] = new Vector(vertices[indices[j, i], 0], vertices[indices[j, i], 1], vertices[indices[j, i], 2]);
                    GL.glVertex3d(triangle[i].X, triangle[i].Y, triangle[i].Z);
                }
          
            }

            GL.glEnd();

            GL.glBegin(GL.GL_LINE_STRIP);
            if (!cRubik.shadingMode)
            {
                setColor(Color.black);
            }

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                    GL.glVertex3d(vertices[indices[j, i], 0], vertices[indices[j, i], 1], vertices[indices[j, i], 2]);
            }


            GL.glEnd();
            GL.glPopMatrix();
            GL.glLoadMatrixd(CurrentRotationTraslation);

        }

        private static void FlippedPiece()
        {
            double[] angleMatrix = new double[16];
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glTranslated(-0, Tetrahedron.width / 3, Tetrahedron.height);
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
            GL.glPopMatrix();
            GL.glMultMatrixd(angleMatrix);
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glRotated(180, 0, 1, 0);
            GL.glRotated(39, 1, 0, 0);
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
            GL.glPopMatrix();
            GL.glMultMatrixd(angleMatrix);
        }
        public static void BottomPiece()
        {
            double[] angleMatrix = new double[16];
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glTranslated(-0, Tetrahedron.width, 0);
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
            GL.glPopMatrix();
            GL.glMultMatrixd(angleMatrix);
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glRotated(109.5, 1, 0, 0);
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
            GL.glPopMatrix();
            GL.glMultMatrixd(angleMatrix);
        }
    }
}