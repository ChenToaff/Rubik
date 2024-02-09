using System;
using System.Windows.Forms;
using OpenGL;
using RubikTetrahedron.Enums;

namespace RubikTetrahedron
{
    public partial class Rubik : Form
    {
        cOGL cGL;

        public Rubik()
        {

            InitializeComponent();
            cGL = new cOGL(panel1);
            hScrollBarScroll(hScrollBar1, null);
            hScrollBarScroll(hScrollBar2, null);
            hScrollBarScroll(hScrollBar3, null);

            Button[] rotationButtons = {  xRotatePositiveBtn,xRotateNegitiveBtn, yRotateNegitiveBtn, yRotatePositiveBtn, zRotatePositiveBtn, zRotateNegitiveBtn };

            for (int i = 0; i < 6; i++)
            {
                var timer = new Timer { Interval = 100 };
                Rotate r = (Rotate)i;

                timer.Tick += (sender, e) => handleRotate(r);
                rotationButtons[i].MouseDown += (sender, e) => timer.Start();
                rotationButtons[i].MouseUp += (sender, e) => timer.Stop();
                rotationButtons[i].Click += (sender, e) => handleRotate(r);
                rotationButtons[i].Disposed += (sender, e) =>
                {
                    timer.Stop();
                    timer.Dispose();
                };
            }


            Button[] translationButtons = {  xTranslateNegitiveBtn, xTranslatePositiveBtn, yTranslatePositiveBtn, yTranslateNegitiveBtn, zTranslatePositiveBtn, zTranslateNegitiveBtn };

            for (int i = 0; i < 6; i++)
            {
                var timer = new Timer { Interval = 100 };
                Translate t = (Translate)i;

                timer.Tick += (sender, e) => handleTranslate(t);
                translationButtons[i].MouseDown += (sender, e) => timer.Start();
                translationButtons[i].MouseUp += (sender, e) => timer.Stop();
                translationButtons[i].Click += (sender, e) => handleTranslate(t);
                translationButtons[i].Disposed += (sender, e) =>
                {
                    timer.Stop();
                    timer.Dispose();
                };
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            cGL.Draw();
        }

        private void hScrollBarScroll(object sender, ScrollEventArgs e)
        {
            HScrollBar hb = (HScrollBar)sender;
            int n = int.Parse(hb.Name.Substring(10));
            cGL.lightPosition[n - 1] = (hb.Value - 100) / 10.0f;
            if (e != null)
                cGL.Draw();
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
                GL.glRotated(rotate_direction, cRubik.dir_XYZ[cRubik.axis - 1, 0], cRubik.dir_XYZ[cRubik.axis - 1, 1], cRubik.dir_XYZ[cRubik.axis - 1, 2]);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, temp);
                GL.glMultMatrixd(cRubik.tetrahedronArray[cRubik.top].rotation_matrix);
                GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, rotation_matrix);

                cRubik.tetrahedronArray[cRubik.top].rotation_matrix = (double[])rotation_matrix.Clone();
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
                for (int i = 0; i < cRubik.tetrahedronArray.Length; i++)
                {
                    if (cRubik.tetrahedronArray[i].loc == location.middle)
                    {
                        GL.glPushMatrix();
                        double[] rotation_matrix = new double[16];
                        double[] temp = new double[16];
                        GL.glLoadIdentity();
                        GL.glRotated(rotate_direction, cRubik.dir_XYZ[cRubik.axis - 1, 0], cRubik.dir_XYZ[cRubik.axis - 1, 1], cRubik.dir_XYZ[cRubik.axis - 1, 2]);
                        GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, temp);
                        GL.glMultMatrixd(cRubik.tetrahedronArray[i].rotation_matrix);
                        GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, rotation_matrix);

                        cRubik.tetrahedronArray[i].rotation_matrix = (double[])rotation_matrix.Clone();
                        GL.glPopMatrix();
                    }

                }
                cGL.Draw();
            }
            cRubik.rotate_middle(right);

        }
        private void rotate_bottom(object sender, EventArgs e)
        {
            bool right = true;
            if (sender == bottom_left)
                right = false;
            int rotate_direction = right ? 1 : -1;

            for (int j = 0; j < 120; j++)
            {
                for (int i = 0; i < cRubik.tetrahedronArray.Length; i++)
                {
                    if (cRubik.tetrahedronArray[i].loc == location.bottom)
                    {
                        GL.glPushMatrix();
                        double[] rotation_matrix = new double[16];
                        double[] temp = new double[16];
                        GL.glLoadIdentity();
                        GL.glRotated(rotate_direction, cRubik.dir_XYZ[cRubik.axis - 1, 0], cRubik.dir_XYZ[cRubik.axis - 1, 1], cRubik.dir_XYZ[cRubik.axis - 1, 2]);
                        GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, temp);
                        GL.glMultMatrixd(cRubik.tetrahedronArray[i].rotation_matrix);
                        GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, rotation_matrix);

                        cRubik.tetrahedronArray[i].rotation_matrix = (double[])rotation_matrix.Clone();
                        GL.glPopMatrix();
                    }
                }
                cGL.Draw();
            }
            cRubik.rotate_bottom(right);
        }
        private void direction_radioButton(object sender, EventArgs e)
        {
            if (sender == direction1)
            {
                cRubik.SetAxis(1);
            }
            else if (sender == direction2)
            {
                cRubik.SetAxis(2);
            }
            else if (sender == direction3)
            {
                cRubik.SetAxis(3);
            }
            else if (sender == direction4)
            {
                cRubik.SetAxis(4);
            }

        }
        private void handleTranslate(Translate t)
        {
            switch (t)
            {
                case Translate.xPositive:
                    cGL.xTranslateAmount += 0.25f;
                    break;
                case Translate.xNegitive:
                    cGL.xTranslateAmount -= 0.25f;
                    break;
                case Translate.yPositive:
                    cGL.yTranslateAmount -= 0.25f;
                    break;
                case Translate.yNegitive:
                    cGL.yTranslateAmount += 0.25f;
                    break;
                case Translate.zPositive:
                    cGL.zoomIn -= 0.25f;
                    break;
                case Translate.zNegitive:
                    cGL.zoomIn += 0.25f;
                    break;
            }
            cGL.Draw();
        }
        private void handleRotate(Rotate r)
        {
            switch (r)
            {
                case Rotate.xPositive:
                    cGL.xRotateAngle += 3f;
                    break;
                case Rotate.xNegitive:
                    cGL.xRotateAngle -= 3f;
                    break;
                case Rotate.yPositive:
                    cGL.yRotateAngle += 3f;
                    break;
                case Rotate.yNegitive:
                    cGL.yRotateAngle -= 3f;
                    break;
                case Rotate.zPositive:
                    cGL.zRotateAngle -= 0.1f;
                    break;
                case Rotate.zNegitive:
                    cGL.zRotateAngle += 0.1f;
                    break;
            }
            cGL.Draw();
        }

    }
}