using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGL
{
    public static class Drawings
    {
        private static float diff = 12f;
        public static void Draw(float [] pos)
        {
            drawRoom();
            drawReflection();
            drawLightSource(pos);
            DrawFloor();
            drawRubikShading(pos);
            DrawAxes();
            drawRubik();
        }

        static void DrawAxes()
        {
            GL.glPushMatrix();
            GL.glTranslated(0, (Rubik.big_t_height / 3) + 1, 0);

            GL.glBegin(GL.GL_LINES);

            GL.glColor3f(1.0f, 0.0f, 0.0f); //    x  RED
            int i = Rubik_Management.axis - 1;
            GL.glVertex3d(2 * Rubik_Management.dir_XYZ[i, 0], 2 * Rubik_Management.dir_XYZ[i, 1], 2 * Rubik_Management.dir_XYZ[i, 2]);
            GL.glVertex3d(-2 * Rubik_Management.dir_XYZ[i, 0], -2 * Rubik_Management.dir_XYZ[i, 1], -2 * Rubik_Management.dir_XYZ[i, 2]);

            GL.glEnd();
            GL.glPopMatrix();
        }
        static void drawLightSource(float[] pos)
        {
            GL.glPushMatrix();
            //Draw Light Source
            GL.glDisable(GL.GL_LIGHTING);
            GL.glTranslatef(pos[0], pos[1], pos[2]);
            //Yellow Light source
            GL.glColor3f(1, 1, -Cubemap.b);
            GLUT.glutSolidSphere(0.05, 8, 8);
            GL.glTranslatef(-pos[0], -pos[1], -pos[2]);
            //projection line from source to plane
            GL.glBegin(GL.GL_LINES);
            GL.glColor3d(0.5, 0.5, 0);
            GL.glVertex3d(pos[0], Cubemap.room[5, 0, 1] + diff, pos[2]);
            GL.glVertex3d(pos[0], pos[1], pos[2]);
            GL.glEnd();
            GL.glPopMatrix();
        }

        static void drawRoom()
        {
            GL.glPushMatrix();
            GL.glTranslatef(0, diff, 0);
            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glEnable(GL.GL_BLEND);
            GL.glEnable(GL.GL_CULL_FACE);
            GL.glCullFace(GL.GL_FRONT);
            Cubemap.DrawTexturedCube();
            GL.glCullFace(GL.GL_BACK);
            Cubemap.DrawTexturedCube();
            GL.glDisable(GL.GL_CULL_FACE);
            GL.glDisable(GL.GL_TEXTURE_2D);
            GL.glDisable(GL.GL_BLEND);
            GL.glPopMatrix();
        }

        static void DrawFloor()
        {
            GL.glPushMatrix();
            GL.glTranslatef(0, diff, 0);
            GL.glEnable(GL.GL_LIGHTING);
            //!!! for blended REFLECTION 
            GL.glColor4d(0.8, 0.8, 0.8, 0.5);
            GL.glBegin(GL.GL_QUADS);

            for (int i = 0; i < 4; i++)
            {
                GL.glVertex3d(Cubemap.room[5, i, 0], Cubemap.room[5, i, 1], Cubemap.room[5, i, 2]);
            }
            GL.glEnd();
            GL.glPopMatrix();

        }
        static void drawRubik(bool shadingMode = false)
        {
            GL.glPushMatrix();
            GL.glTranslated(0, (Rubik.big_t_height / 3) + 1, 0);
            Rubik.shadingMode = shadingMode;
            for (int i = 0; i < 22; i++)
            {
                Rubik.DrawSubRubik(i);
            }
            GL.glPopMatrix();

        }

        static void drawRubikShading(float[] pos)
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
            drawRoom();
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
            Rubik.shadingMode = true;
            float[,] wall = new float[3, 3];
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    wall[k, 0] = Cubemap.room[j, k, 0] - (Math.Abs(Cubemap.room[j, k, 0]) / Cubemap.room[j, k, 0]) * 0.01f;
                    wall[k, 1] = -Cubemap.room[j, k, 1] + diff + (Math.Abs(Cubemap.room[j, k, 1]) / Cubemap.room[j, k, 1]) * 0.01f;
                    wall[k, 2] = Cubemap.room[j, k, 2] - (Math.Abs(Cubemap.room[j, k, 2]) / Cubemap.room[j, k, 2]) * 0.01f;
                }
                GL.glPushMatrix();
                GL.glMultMatrixf(Shading.MakeShadowMatrix(wall, pos));
                if (j == 4)
                {
                    GL.glColor4d(0.5, 0.5, 0.5, 0.5);            // shadow
                }
                else
                {
                    GL.glColor4d(0.5 + (0.1 * j), 0.5 + (0.1 * j), 0.5 + (0.1 * j), 0.7);            // shadow

                }
                drawRubik(true);

                GL.glPopMatrix();
            }
            GL.glDisable(GL.GL_BLEND);
            //GL.glDepthMask((byte)GL.GL_FALSE);
            //drawRoom();
            GL.glDepthMask((byte)GL.GL_TRUE);
            // Disable GL.GL_STENCIL_TEST to show All, else it will be cut on GL.GL_STENCIL
            GL.glDisable(GL.GL_STENCIL_TEST);

        }
        static void drawReflection()
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
            drawRubik();
            GL.glCullFace(GL.GL_FRONT);
            drawRubik();
            GL.glDisable(GL.GL_CULL_FACE);

            GL.glPopMatrix();

            
            GL.glDepthMask((byte)GL.GL_TRUE);
            // Disable GL.GL_STENCIL_TEST to show All, else it will be cut on GL.GL_STENCIL
            GL.glDisable(GL.GL_STENCIL_TEST);
        }
    }
}
