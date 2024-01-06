namespace OpenGL
{
    public static partial class Utils
    {
        public static void DrawRoom()
        {
            GL.glPushMatrix();
            GL.glTranslatef(0, Room.baseUnit, 0);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glEnable(GL.GL_BLEND);
            GL.glEnable(GL.GL_CULL_FACE);
            GL.glCullFace(GL.GL_FRONT);
            DrawTexturedCube();
            GL.glCullFace(GL.GL_BACK);
            DrawTexturedCube();
            GL.glDisable(GL.GL_CULL_FACE);
            GL.glDisable(GL.GL_TEXTURE_2D);
            GL.glDisable(GL.GL_BLEND);
            GL.glPopMatrix();
        }
        private static void DrawTexturedCube()
        {
            for (int i = 0; i < 5; i++)
            {
                GL.glBindTexture(GL.GL_TEXTURE_2D, Room.textures[i]);
                GL.glDisable(GL.GL_LIGHTING);
                GL.glBegin(GL.GL_QUADS);
                GL.glColor3f(1.0f, 1.0f, 1.0f);
                GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(Room.cubemap[i, 0, 0], Room.cubemap[i, 0, 1], Room.cubemap[i, 0, 2]);
                GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(Room.cubemap[i, 1, 0], Room.cubemap[i, 1, 1], Room.cubemap[i, 1, 2]);
                GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(Room.cubemap[i, 2, 0], Room.cubemap[i, 2, 1], Room.cubemap[i, 2, 2]);
                GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(Room.cubemap[i, 3, 0], Room.cubemap[i, 3, 1], Room.cubemap[i, 3, 2]);
                GL.glEnd();

            }
        }
    }
}
