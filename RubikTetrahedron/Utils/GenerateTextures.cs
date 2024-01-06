using System.Drawing;
using RubikTetrahedron.Properties;

namespace OpenGL
{
     public static partial class Utils
     { 
        public static void GenerateTextures()
        {
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            GL.glGenTextures(6, Room.textures);
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

                GL.glBindTexture(GL.GL_TEXTURE_2D, Room.textures[i]);
                //2D for XYZ
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB8, image.Width, image.Height,
                                                              0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_byte, bitmapdata.Scan0);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

                image.UnlockBits(bitmapdata);
                image.Dispose();
            }
        }
    }
}
