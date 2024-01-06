
namespace OpenGL
{
    public static partial class Utils
    {          
        public static void DrawFloor()
        {
            GL.glPushMatrix();
            GL.glTranslatef(0, Room.baseUnit, 0);
            GL.glEnable(GL.GL_LIGHTING);
            //!!! for blended REFLECTION 
            GL.glColor4d(0.8, 0.8, 0.8, 0.6);
            GL.glBegin(GL.GL_QUADS);

            for (int i = 0; i < 4; i++)
            {
                GL.glVertex3d(Room.cubemap[5, i, 0], Room.cubemap[5, i, 1], Room.cubemap[5, i, 2]);
            }
            GL.glEnd();
            GL.glPopMatrix();

        }
               
    }
}
