using System.Linq;

namespace OpenGL
{
    public static partial class Utils
    {
        public static void DrawRubik(bool shadingMode = false)
        {
            GL.glPushMatrix();
            GL.glTranslated(0, (RubikTetrahedron.height / 3) + 1, 0);
            RubikTetrahedron.shadingMode = shadingMode;

            Tetrahedron[] sorted = RubikTetrahedron.tetrahedronArray.OrderBy(ob => ob.id).ToArray();

            int index = 0;
            //Draw Bottom Floor:
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glTranslated(0, 0, -(RubikTetrahedron.width / 4)); // center of Equilateral triangle
            GL.glTranslated(-Tetrahedron.edgeLength, -RubikTetrahedron.height / 3, 0); // center of Equilateral triangle
            DrawTetrahedron(sorted[index++]); //0
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //1
            DrawTetrahedron(sorted[index++]); //2
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //3
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //4
            DrawTetrahedron(sorted[index++]); //5
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //6
            GL.glTranslated(0, Tetrahedron.width, 0);
            GL.glRotated(120, 0, 0, 1);
            DrawTetrahedron(sorted[index++]); //7
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //8
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //9
            DrawTetrahedron(sorted[index++]);//10
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //11
            GL.glTranslated(0, Tetrahedron.width, 0);
            GL.glRotated(120, 0, 0, 1);
            DrawTetrahedron(sorted[index++]); //12
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //13
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //14
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            GL.glPopMatrix(); //after bottom floor

            //Draw Middle Floor:
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glTranslated(0, 0, -(RubikTetrahedron.width / 4)); // center of Equilateral triangle
            GL.glTranslated(-0.5 * Tetrahedron.edgeLength, -RubikTetrahedron.mediumHeight / 3, Tetrahedron.height);
            DrawTetrahedron(sorted[index++]); //15
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //16
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //17
            GL.glTranslated(0, Tetrahedron.width, 0);
            GL.glRotated(120, 0, 0, 1);
            DrawTetrahedron(sorted[index++]); //18
            GL.glTranslated((Tetrahedron.edgeLength / 2), 0, 0);
            DrawTetrahedron(sorted[index++]); //19
            GL.glTranslated(0, Tetrahedron.width, 0);
            GL.glRotated(120, 0, 0, 1);
            DrawTetrahedron(sorted[index++]); //20
            GL.glPopMatrix();

            //Draw Top Floor:
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glTranslated(0, 0, -(RubikTetrahedron.width / 4)); // center of Equilateral triangle
            GL.glTranslated(0, 0, Tetrahedron.height);
            GL.glTranslated(0, -(Tetrahedron.width / 3), Tetrahedron.height);
            DrawTetrahedron(sorted[index++]); //21
            GL.glPopMatrix();

            GL.glPopMatrix();

        }
    }
}