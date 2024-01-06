using RubikTetrahedron.Enums;

namespace OpenGL
{
    public static partial class Utils
    {
        public static void setColor(Color c)
        {
            switch (c)
            {
                case Color.red:
                    GL.glColor3f(1.0f, 0.0f, 0.0f);     // Red
                    break;
                case Color.green:
                    GL.glColor3f(0.0f, 1.0f, 0.0f);     // Green
                    break;
                case Color.yellow:
                    GL.glColor3f(1.0f, 1.0f, 0.0f);     // Yellow
                    break;
                case Color.blue:
                    GL.glColor3f(0.0f, 0.0f, 1.0f);     // Blue
                    break;
                case Color.black:
                    GL.glColor3f(0.0f, 0.0f, 0.0f);     // Black
                    break;
            }

        }
    }
}
