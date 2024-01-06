namespace OpenGL
{
    public static partial class Utils
    {
        public static void DrawReflection()
        {
            GL.glEnable(GL.GL_BLEND);
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            //only floor, draw only to STENCIL buffer
            GL.glEnable(GL.GL_STENCIL_TEST);
            GL.glStencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
            GL.glStencilFunc(GL.GL_ALWAYS, 1, 0xFFFFFFFF); // draw floor always
            GL.glColorMask((byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE);
            GL.glDisable(GL.GL_DEPTH_TEST);

            DrawFloor();

            // restore regular settings
            GL.glColorMask((byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE);
            GL.glEnable(GL.GL_DEPTH_TEST);

            // reflection is drawn only where STENCIL buffer value equal to 1
            GL.glStencilFunc(GL.GL_EQUAL, 1, 0xFFFFFFFF);
            GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);

            GL.glEnable(GL.GL_STENCIL_TEST);

            //// draw reflected scene
            GL.glPushMatrix();
            GL.glScalef(1, -1, 1); //swap on Z axis
            GL.glEnable(GL.GL_CULL_FACE);

            GL.glCullFace(GL.GL_BACK);
            DrawRubik();
            GL.glCullFace(GL.GL_FRONT);
            DrawRubik();
            GL.glDisable(GL.GL_CULL_FACE);

            GL.glPopMatrix();


            GL.glDepthMask((byte)GL.GL_TRUE);
            // Disable GL.GL_STENCIL_TEST to show All, else it will be cut on GL.GL_STENCIL
            GL.glDisable(GL.GL_STENCIL_TEST);
        }
    }
}
