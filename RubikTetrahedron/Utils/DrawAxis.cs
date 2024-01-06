namespace OpenGL
{
    public static partial class Utils
    {
        public static void DrawAxis()
        {
            GL.glPushMatrix();
            GL.glTranslated(0, (RubikTetrahedron.height / 3) + 1, 0);
            GL.glBegin(GL.GL_LINES);
            GL.glColor3f(1.0f, 0.0f, 0.0f); //    x  RED
            int i = RubikTetrahedron.axis - 1;
            GL.glVertex3d(2 * RubikTetrahedron.dir_XYZ[i, 0], 2 * RubikTetrahedron.dir_XYZ[i, 1], 2 * RubikTetrahedron.dir_XYZ[i, 2]);
            GL.glVertex3d(-2 * RubikTetrahedron.dir_XYZ[i, 0], -2 * RubikTetrahedron.dir_XYZ[i, 1], -2 * RubikTetrahedron.dir_XYZ[i, 2]);
            GL.glEnd();
            GL.glPopMatrix();
        }
    }
}
