namespace OpenGL
{
    public static partial class Utils
    {
        public static void DrawAxis()
        {
            GL.glPushMatrix();
            GL.glTranslated(0, (cRubik.height / 3) + 1, 0);
            GL.glBegin(GL.GL_LINES);
            GL.glColor3f(1.0f, 0.0f, 0.0f); //RED
            int selectedAxis = cRubik.axis - 1;
            GL.glVertex3d(2 * cRubik.dir_XYZ[selectedAxis, 0], 2 * cRubik.dir_XYZ[selectedAxis, 1], 2 * cRubik.dir_XYZ[selectedAxis, 2]);
            GL.glVertex3d(-2 * cRubik.dir_XYZ[selectedAxis, 0], -2 * cRubik.dir_XYZ[selectedAxis, 1], -2 * cRubik.dir_XYZ[selectedAxis, 2]);
            GL.glEnd();
            GL.glPopMatrix();
        }
    }
}
