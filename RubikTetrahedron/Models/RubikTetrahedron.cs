using OpenGL;
using System;
using System.Collections.Generic;
using System.Text;
namespace OpenGL
{
    public enum Color
    {
        red,
        green,
        blue,
        yellow,
        black
    }
    public enum location
    {
        top,
        middle,
        bottom,
    }
    public static class Rubik
    {
      
        public static double a = 1;
        public static double h = (Math.Sqrt(6) / 3) * a;
        public static double t_height = (Math.Sqrt(3) / 2) * a;

        public static double big_a = (3*a);
        public static double big_h = (Math.Sqrt(6) / 3) * big_a;
        public static double big_t_height = (Math.Sqrt(3) / 2) * big_a;

        public static double mid_a =  (2 * a);
        public static double mid_h = (Math.Sqrt(6) / 3) * mid_a;
        public static double mid_t_height = (Math.Sqrt(3) / 2) * mid_a;

        public static bool shadingMode;


        private static double[,] vertices = new double[4, 3] {
                { -0.5*a,   0.0f,   0.0f },
                { 0.5*a,  0.0f,  0.0f},
                { 0, t_height ,0},
                { 0, t_height/3, h},
                };
        
        private static int[,] indices = new int[4, 3] { { 0, 2, 1 }, { 0, 3, 2 }, { 1, 3, 0 }, { 1, 2, 3 } };
        private static double[] location_matrix = new double[16];
        public static float TOP_ANGLE = 0;
        public static float MIDDLE_ANGLE = 0;
        public static float BOTTOM_ANGLE = 0;
        public static int only_draw;
        public static int draw_index;
        public static void DrawTetrahedron(bool flag, bool is_bottom = false)
        {
            if (draw_index++ != Rubik_Management.t[only_draw].id)
            {
                return;
            }
            GL.glPushMatrix();
            if (flag)
            {
                double[] angleMatrix = new double[16];
                GL.glPushMatrix();
                GL.glLoadIdentity();
                GL.glTranslated(-0, t_height/3 + TOP_ANGLE, h);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
                GL.glPopMatrix();
                GL.glMultMatrixd(angleMatrix);
                GL.glPushMatrix();
                GL.glLoadIdentity();
                GL.glRotated(180, 0, 1, 0);
                GL.glRotated(37.9, 1, 0, 0);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
                GL.glPopMatrix();
                GL.glMultMatrixd(angleMatrix);

            }
            if (is_bottom)
            {
                double[] angleMatrix = new double[16];
                GL.glPushMatrix();
                GL.glLoadIdentity();
                GL.glTranslated(-0, t_height, 0);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
                GL.glPopMatrix();
                GL.glMultMatrixd(angleMatrix);
                GL.glPushMatrix();
                GL.glLoadIdentity();
                GL.glRotated(109.7 , 1, 0, 0);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, angleMatrix);
                GL.glPopMatrix();
                GL.glMultMatrixd(angleMatrix);  
            }

            GL.glBegin(GL.GL_TRIANGLES);
            Vector[] triangle = new Vector[3];
            for (int j = 0; j < 4; j++)
            {

                setColor(Rubik_Management.t[only_draw].colors[j]);
                for (int i = 0; i < 3; i++)
                {
                    triangle[i] = new Vector(vertices[indices[j, i], 0], vertices[indices[j, i], 1], vertices[indices[j, i], 2]);
                    GL.glVertex3d(triangle[i].X, triangle[i].Y, triangle[i].Z);
                }
                drawNormal(triangle);


            }

            GL.glEnd();
          
            GL.glBegin(GL.GL_LINE_STRIP);
            setColor(Color.black);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                    GL.glVertex3d(vertices[indices[j, i], 0], vertices[indices[j, i], 1], vertices[indices[j, i], 2]);
            }


            GL.glEnd();
            GL.glPopMatrix();


        }
        public static void setColor(Color c)
        {
            if (shadingMode)
            {
                return;
            }

            switch (c) {
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
        public static void drawNormal(Vector [] triangle)
        {
            Vector a = triangle[0] - triangle[1];
            Vector b = triangle[1] - triangle[2];
            Vector normal = a.CrossProduct(b).Normalize();
            GL.glNormal3d(normal.X, normal.Y, normal.Z);
        }
        public static void DrawSubRubik(int only = 0)
        {
            draw_index = 0;
            
            GL.glPushMatrix();

            GL.glMultMatrixd(Rubik_Management.t[only].rotation_matrix);

            only_draw = only;

            GL.glTranslated(0, 0, -(big_h / 4)); // center of Equilateral triangle
            GL.glPushMatrix(); // before bottom floor
            GL.glTranslated(-Rubik.a , -big_t_height / 3, 0); // center of Equilateral triangle


            DrawTetrahedron(false);      //0
            GL.glTranslated((a / 2) , 0, 0); 
            DrawTetrahedron(true); //1
            DrawTetrahedron(false, true);  //2
            GL.glTranslated((a / 2) , 0, 0);
            DrawTetrahedron(false); //3
            GL.glTranslated((a / 2) , 0, 0);
            DrawTetrahedron(true); //4
            DrawTetrahedron(false, true); //5
            GL.glTranslated((a / 2) , 0, 0);
            DrawTetrahedron(false); //6


            GL.glTranslated(0, t_height, 0);
            GL.glRotated(120, 0, 0, 1);


            DrawTetrahedron(true); //7
            GL.glTranslated((a / 2), 0, 0);

            DrawTetrahedron(false); //8
            GL.glTranslated((a / 2) , 0, 0);

            DrawTetrahedron(false,true); //9
            DrawTetrahedron(true); //10
            GL.glTranslated((a / 2), 0, 0);



            DrawTetrahedron(false); //11


            GL.glTranslated(0, t_height, 0);
            GL.glRotated(120, 0, 0, 1);


            DrawTetrahedron(true); //12

            GL.glTranslated((a / 2) , 0, 0);
            DrawTetrahedron(false); //13
            GL.glTranslated((a / 2), 0, 0);
            DrawTetrahedron(true); //14
            GL.glTranslated((a / 2) , 0, 0);
            GL.glPopMatrix(); //after bottom floor

            //DrawMiddleFloor()
            GL.glTranslated(0, 0, Rubik.h );

            GL.glPushMatrix();
            GL.glTranslated(-0.5 * a, -mid_t_height / 3,0);

            DrawTetrahedron(false); //15
            GL.glTranslated((a / 2), 0, 0);
            DrawTetrahedron(true); //16
            GL.glTranslated((a / 2) , 0, 0);
            DrawTetrahedron(false); //17

            GL.glTranslated(0, t_height, 0);
            GL.glRotated(120, 0, 0, 1);

            DrawTetrahedron(true); //18
            GL.glTranslated((a / 2) , 0, 0);
            DrawTetrahedron(false); //19
            GL.glTranslated(0, t_height, 0);
            GL.glRotated(120, 0, 0, 1);

            DrawTetrahedron(true); //20
            GL.glPopMatrix();
            

            //DrawTopFloor()
            
            GL.glTranslated(0, -(t_height/3), Rubik.h);
            DrawTetrahedron(false); //21
            GL.glPopMatrix();
            draw_index = 0;

        }
        public static void init_Rubik()
        {
            Rubik_Management.add_tetrahedron(0,new[] { Color.red, Color.blue, Color.green, Color.black });  //0  main corner
            Rubik_Management.add_tetrahedron(1,new[] { Color.black, Color.black, Color.green, Color.red });  //1 center-piece
            Rubik_Management.add_tetrahedron(2,new[] { Color.black, Color.black, Color.red, Color.black });  //2
            Rubik_Management.add_tetrahedron(3,new[] { Color.red, Color.black, Color.green, Color.black });  //3
            Rubik_Management.add_tetrahedron(4,new[] { Color.black, Color.black, Color.green, Color.black });  //4  center-piece
            Rubik_Management.add_tetrahedron(5,new[] { Color.black, Color.black, Color.red, Color.black });  //5
            Rubik_Management.add_tetrahedron(6,new[] { Color.red, Color.black, Color.green, Color.yellow });  //6   main corner
            Rubik_Management.add_tetrahedron(7,new[] { Color.black, Color.black, Color.yellow, Color.black });  //7 center-piece
            Rubik_Management.add_tetrahedron(8,new[] { Color.red, Color.black, Color.yellow, Color.black });  //8
            Rubik_Management.add_tetrahedron(9,new[] { Color.black, Color.black, Color.red, Color.black });  //9 center-piece
            Rubik_Management.add_tetrahedron(10,new[] { Color.black, Color.black, Color.yellow, Color.black });  //10
            Rubik_Management.add_tetrahedron(11,new[] { Color.red, Color.black, Color.yellow, Color.blue });  //11   main corner
            Rubik_Management.add_tetrahedron(12,new[] { Color.black, Color.black, Color.blue, Color.black });  //12 center-piece
            Rubik_Management.add_tetrahedron(13,new[] { Color.red, Color.black, Color.blue, Color.black });  //13 
            Rubik_Management.add_tetrahedron(14,new[] { Color.black, Color.black, Color.blue, Color.black });  //14 center-piece
            Rubik_Management.add_tetrahedron(15,new[] { Color.black, Color.blue, Color.green, Color.black });  //15 corner
            Rubik_Management.add_tetrahedron(16,new[] { Color.black, Color.black, Color.green, Color.black });  //16 center-piece
            Rubik_Management.add_tetrahedron(17,new[] { Color.black, Color.black, Color.green, Color.yellow });  //17 corner
            Rubik_Management.add_tetrahedron(18,new[] { Color.black, Color.black, Color.yellow, Color.black });  //18 center-piece
            Rubik_Management.add_tetrahedron(19,new[] { Color.black, Color.black, Color.yellow, Color.blue });  //19 corner
            Rubik_Management.add_tetrahedron(20,new[] { Color.black, Color.black, Color.blue, Color.black });  //20 center-piece
            Rubik_Management.add_tetrahedron(21,new[] { Color.black, Color.blue, Color.green, Color.yellow });  //21  main corner

            Rubik_Management.set_direction(1);
        }

        
    }
}
