using System;

namespace OpenGL
{
    public static partial class Utils
    {
        public static void DrawShading(float[] lightPosition)
        {
            GL.glEnable(GL.GL_STENCIL_TEST);
            GL.glStencilFunc(GL.GL_ALWAYS, 1, 0xFF); // Set any stencil to 1
            GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_REPLACE);
            GL.glStencilMask(0xFF); // Write to stencil buffer
            GL.glDepthMask((byte)GL.GL_FALSE); // Don't write to depth buffer
            GL.glClear(GL.GL_STENCIL_BUFFER_BIT); // Clear stencil buffer (0 by default)


            GL.glEnable(GL.GL_BLEND);
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            GL.glEnable(GL.GL_STENCIL_TEST);
            GL.glStencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
            GL.glStencilFunc(GL.GL_ALWAYS, 1, 0xFFFFFFFF); // draw floor always
            GL.glColorMask((byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE);
            GL.glDisable(GL.GL_DEPTH_TEST);
            DrawRoom();
            DrawFloor();
            // restore regular settings
            GL.glColorMask((byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE);
            GL.glEnable(GL.GL_DEPTH_TEST);

            // reflection is drawn only where STENCIL buffer value equal to 1
            GL.glStencilFunc(GL.GL_EQUAL, 1, 0xFFFFFFFF);
            GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);

            GL.glEnable(GL.GL_STENCIL_TEST);
            //SHADING begin
            GL.glDisable(GL.GL_LIGHTING);
            GL.glEnable(GL.GL_BLEND);
            cRubik.shadingMode = true;
            float[,] wall = new float[3, 3];
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    wall[k, 0] = Room.cubemap[j, k, 0] - (Math.Abs(Room.cubemap[j, k, 0]) / Room.cubemap[j, k, 0]) * 0.01f;
                    wall[k, 1] = -Room.cubemap[j, k, 1] + Room.baseUnit + (Math.Abs(Room.cubemap[j, k, 1]) / Room.cubemap[j, k, 1]) * 0.01f;
                    wall[k, 2] = Room.cubemap[j, k, 2] - (Math.Abs(Room.cubemap[j, k, 2]) / Room.cubemap[j, k, 2]) * 0.01f;
                }
                GL.glPushMatrix();
                GL.glMultMatrixf(Helpers.MakeShadowMatrix(wall, lightPosition));
                if (j == 4){
                    GL.glColor4d(0.5, 0.5, 0.5, 0.5);  // shadow
                }
                else{
                    GL.glColor4d(0.5 + (0.1 * j), 0.5 + (0.1 * j), 0.5 + (0.1 * j), 0.7);  // shadow
                }
                DrawRubik(true);

                GL.glPopMatrix();
            }
            GL.glDisable(GL.GL_BLEND);
            //GL.glDepthMask((byte)GL.GL_FALSE);
            GL.glDepthMask((byte)GL.GL_TRUE);
            // Disable GL.GL_STENCIL_TEST to show All, else it will be cut on GL.GL_STENCIL
            GL.glDisable(GL.GL_STENCIL_TEST);

        }
    }
}
