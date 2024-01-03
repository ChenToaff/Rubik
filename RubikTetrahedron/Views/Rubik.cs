using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenGL;
using System.Runtime.InteropServices;

namespace RubikTetrahedron
{
    public partial class Rubik : Form
    {
        cOGL cGL;

        public Rubik()
        {

            InitializeComponent();
            cGL = new cOGL(panel1);
            //apply the bars values as cGL.ScrollValue[..] properties 
            //!!!
            //!!!
            hScrollBarScroll(hScrollBar1, null);
            hScrollBarScroll(hScrollBar2, null);
            hScrollBarScroll(hScrollBar3, null);
            hScrollBarScroll(hScrollBar4, null);
            hScrollBarScroll(hScrollBar5, null);
            hScrollBarScroll(hScrollBar6, null);
            hScrollBarScroll(hScrollBar7, null);
            hScrollBarScroll(hScrollBar8, null);
            hScrollBarScroll(hScrollBar9, null);
            //hScrollBarScroll(hScrollBar10, null);
            hScrollBarScroll(hScrollBar11, null);
            hScrollBarScroll(hScrollBar12, null);
            hScrollBarScroll(hScrollBar13, null);
            //hScrollBarScroll(hScrollBar14, null);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            cGL.Draw();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            //cGL.OnResize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hScrollBarScroll(object sender, ScrollEventArgs e)
        {
            cGL.intOptionC = 0;
            HScrollBar hb = (HScrollBar)sender;
            int n = int.Parse(hb.Name.Substring(10));
            cGL.ScrollValue[n - 1] = (hb.Value - 100) / 10.0f;
            if (e != null)
                cGL.Draw();
        }

        public float[] oldPos = new float[7];

        private void numericUpDownValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nUD = (NumericUpDown)sender;
            int i = int.Parse(nUD.Name.Substring(nUD.Name.Length - 1));
            int pos = (int)nUD.Value;
            switch (i)
            {
                case 1:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.xShift += 0.25f;
                        cGL.intOptionC = 4;
                    }
                    else
                    {
                        cGL.xShift -= 0.25f;
                        cGL.intOptionC = -4;
                    }
                    break;
                case 2:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.yShift += 0.25f;
                        cGL.intOptionC = 5;
                    }
                    else
                    {
                        cGL.yShift -= 0.25f;
                        cGL.intOptionC = -5;
                    }
                    break;
                case 3:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.zShift += 0.25f;
                        cGL.intOptionC = 6;
                    }
                    else
                    {
                        cGL.zShift -= 0.25f;
                        cGL.intOptionC = -6;
                    }
                    break;
                case 4:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.xAngle += 5;
                        cGL.intOptionC = 1;
                    }
                    else
                    {
                        cGL.xAngle -= 5;
                        cGL.intOptionC = -1;
                    }
                    break;
                case 5:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.yAngle += 5;
                        cGL.intOptionC = 2;
                    }
                    else
                    {
                        cGL.yAngle -= 5;
                        cGL.intOptionC = -2;
                    }
                    break;
                case 6:
                    if (pos > oldPos[i - 1])
                    {
                        cGL.zAngle += 5;
                        cGL.intOptionC = 3;
                    }
                    else
                    {
                        cGL.zAngle -= 5;
                        cGL.intOptionC = -3;
                    }
                    break;
            }
            cGL.Draw();
            oldPos[i - 1] = pos;
            cGL.intOptionC = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cGL.alpha -= 15;
            cGL.Draw();
        }



        private void rotate_top(object sender, EventArgs e)
        {


            bool right = true;
            if (sender == top_left)
                right = false;

            int rotate_direction = right ? 1 : -1;

            for (int i = 0; i < 120; i++)
            {
                GL.glPushMatrix();
                double[] rotation_matrix = new double[16];
                double[] temp = new double[16];
                GL.glLoadIdentity();
                GL.glRotated(rotate_direction, RubikController.dir_XYZ[RubikController.axis - 1, 0], RubikController.dir_XYZ[RubikController.axis - 1, 1], RubikController.dir_XYZ[RubikController.axis - 1, 2]);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, temp);
                GL.glMultMatrixd(RubikController.t[RubikController.top].rotation_matrix);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, rotation_matrix);

                RubikController.t[RubikController.top].rotation_matrix = (double[])rotation_matrix.Clone();
                GL.glPopMatrix();
                cGL.Draw();

            }
        }

            
           

        
        private void rotate_middle(object sender, EventArgs e)
        {
            bool right = true;
            if (sender == middle_left)
                right = false;
            int rotate_direction = right ? 1 : -1;

            for (int j = 0; j < 120; j++)
            {
                for (int i = 0; i < RubikController.t.Length; i++)
                {
                    if(RubikController.t[i].loc == location.middle)
                    {
                        //RubikController.t[i].rotation_in_dir[RubikController.axis - 1] += 1 * rotate_direction;
                        GL.glPushMatrix();
                        double[] rotation_matrix = new double[16];
                        double[] temp = new double[16];
                        GL.glLoadIdentity();
                        GL.glRotated(rotate_direction, RubikController.dir_XYZ[RubikController.axis - 1, 0], RubikController.dir_XYZ[RubikController.axis - 1, 1], RubikController.dir_XYZ[RubikController.axis - 1, 2]);
                        GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, temp);
                        GL.glMultMatrixd(RubikController.t[i].rotation_matrix);
                        GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, rotation_matrix);

                        RubikController.t[i].rotation_matrix = (double[])rotation_matrix.Clone();
                        GL.glPopMatrix();
                    }

                }
                cGL.Draw();
            }
            RubikController.rotate_middle(right);

        }
        private void rotate_bottom(object sender, EventArgs e)
        {
            bool right = true;
            if (sender == bottom_left)
                right = false;
            int rotate_direction = right ? 1 : -1;

            for (int j = 0; j < 120; j++)
            {
                for (int i = 0; i < RubikController.t.Length; i++)
                {
                    if (RubikController.t[i].loc == location.bottom)
                    {
                        GL.glPushMatrix();
                        double[] rotation_matrix = new double[16];
                        double[] temp = new double[16];
                        GL.glLoadIdentity();
                        GL.glRotated(rotate_direction, RubikController.dir_XYZ[RubikController.axis - 1, 0], RubikController.dir_XYZ[RubikController.axis - 1, 1], RubikController.dir_XYZ[RubikController.axis - 1, 2]);
                        GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, temp);
                        //GL.glLoadMatrixd(RubikController.t[i].rotation_matrix);
                        GL.glMultMatrixd(RubikController.t[i].rotation_matrix);
                        GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, rotation_matrix);

                        RubikController.t[i].rotation_matrix = (double[])rotation_matrix.Clone();
                        GL.glPopMatrix();
                    }
                }
                cGL.Draw();
            }
            RubikController.rotate_bottom(right);
        }
        private void direction_radioButton(object sender, EventArgs e)
        {
            if (sender == direction1)
            {
               RubikController.set_direction(1);
            }
            else if(sender == direction2)
            {
                RubikController.set_direction(2);
            }
            else if (sender == direction3)
            {
                RubikController.set_direction(3);
            }
            else if (sender == direction4)
            {
                RubikController.set_direction(4);
            }

        }

      
    }
}
        