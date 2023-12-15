using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RubikTetrahedron.Properties;

namespace OpenGL
{
    public static class Cubemap
    {
        public static uint[] Textures = new uint[6];

        public static void GenerateTextures()
        {
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            GL.glGenTextures(6, Textures);
            Bitmap[] images ={Resources.front,Resources.back,
                                    Resources.left,Resources.right,Resources.top,Resources.bottom};
            for (int i = 0; i < 6; i++)
            {
                
                //RubikTetrahedron.Properties.
                Bitmap image = new Bitmap(images[i]);
                image.RotateFlip(RotateFlipType.RotateNoneFlipY); //Y axis in Windows is directed downwards, while in OpenGL-upwards
                System.Drawing.Imaging.BitmapData bitmapdata;
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[i]);
                //2D for XYZ
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB8, image.Width, image.Height,
                                                              0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_byte, bitmapdata.Scan0);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

                image.UnlockBits(bitmapdata);
                image.Dispose();
            }
        }
        public static float b = 12f;

        public static float[,,] room = new float[6, 4, 3]
        {
            {{-b, -b, b },{b, -b, b },{b, b, b },{-b, b, b } },                  // front
            {{b, -b, -b },{-b, -b, -b },{-b, b, -b },{b, b, -b } },              // back
            {{-b, -b, -b },{-b, -b, b },{-b, b, b },{-b, b, -b } },              // left
            {{b, -b, b },{b, -b, -b },{b, b, -b },{b, b, b } },                  // right
            {{-b, b, b },{b, b, b },{b, b, -b },{-b, b, -b } },                  // top
            {{-b, -b, -b },{b, -b, -b },{b, -b, b },{-b, -b, b } } ,             // bottom
        };
      
        public static void DrawTexturedCube()
        {
            for (int i = 0; i < 5; i++)
            {
                GL.glBindTexture(GL.GL_TEXTURE_2D, Textures[i]);
                GL.glDisable(GL.GL_LIGHTING);
                GL.glBegin(GL.GL_QUADS);
                GL.glColor3f(1.0f, 1.0f, 1.0f);
                GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(room[i,0,0], room[i, 0, 1], room[i, 0, 2]);
                GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(room[i, 1, 0], room[i, 1, 1], room[i, 1, 2]);
                GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(room[i, 2, 0], room[i, 2, 1], room[i, 2, 2]);
                GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(room[i, 3, 0], room[i, 3, 1], room[i, 3, 2]);
                GL.glEnd();

            }


        }
    }
}
