namespace OpenGL
{
    public static partial class Utils
    {
        public static void DrawLightSource(float[] lightPosition)
        {
            GL.glPushMatrix();
            //Draw Light Source:
            GL.glDisable(GL.GL_LIGHTING);
            GL.glTranslatef(lightPosition[0], lightPosition[1], lightPosition[2]);
            //Yellow Light source:
            GL.glColor3f(1, 1, -12f);
            GLUT.glutSolidSphere(0.05, 8, 8);
            GL.glTranslatef(-lightPosition[0], -lightPosition[1], -lightPosition[2]);
            //Projection line from source to plane:
            GL.glBegin(GL.GL_LINES);
            GL.glColor3d(0.5, 0.5, 0);
            GL.glVertex3d(lightPosition[0], Room.cubemap[5, 0, 1] + Room.baseUnit, lightPosition[2]);
            GL.glVertex3d(lightPosition[0], lightPosition[1], lightPosition[2]);
            GL.glEnd();
            GL.glPopMatrix();
        }
    }
}
