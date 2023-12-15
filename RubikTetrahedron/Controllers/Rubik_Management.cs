using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGL
{

    public static class Rubik_Management
    {
        public static Tetrahedron[] t = new Tetrahedron[22];
        private static int t_index = 0;
        public static int axis;
        public static int[] bottom;
        public static int[] middle;
        public static int top;
        public static double[,] dir_XYZ = new double[4,3] {
            { 0, 0, 1.5* (Rubik.a) } ,
            { -1.5* (Rubik.a), -Rubik.big_t_height / 3,-(Rubik.big_h/4) },
            {0,(2*Rubik.big_t_height/3),  -(Rubik.big_h/4) },
            { 1.5* (Rubik.a) , -Rubik.big_t_height / 3,-(Rubik.big_h/4) },
        };
       
        public static void add_tetrahedron(int id, Color [] colors)
        {
            if (t_index >= t.Length)
            {
                t_index = 0;
            }
            t[t_index++] = new Tetrahedron(id,colors);
        }

        public static void resetIndex()
        {
            t_index = 0;
        }
        public static void set_direction(int d)
        {
            axis = d;
            switch(d){
                case 1:
                    bottom = new []{ 0, 1, 3, 4, 6, 7, 8, 10, 11, 12, 13, 14 ,2,5,9};
                    middle = new[] { 15, 16, 17, 18, 19, 20 };
                    top = 21;
                    break;
                case 2:
                    bottom = new[] { 6, 4, 17, 16, 21, 20, 19, 12, 11, 9, 8, 5, 7, 18, 10 };
                    middle = new [] { 3, 1, 15, 14, 13, 2 };
                    top = 0;
                    break;
                case 3:
                    bottom = new[] { 6, 5, 3, 2, 0, 14, 15, 20, 21, 18, 17, 7, 4, 1, 16 };
                    middle = new[] { 8, 9, 13, 12, 19, 10 }; ; 

                    top = 11;

                    break;
                case 4:
                    bottom = new[] { 0, 2, 13, 9, 11, 10, 19, 18, 21, 16, 15, 1, 14, 12, 20 };

                    middle = new [] {                     3,5,8,7,17,4
 }; 
                    top = 6;
                    break;
                default:
                    return;
            }
            for (int i = 0; i < bottom.Length; i++)
            {
                t[bottom[i]].loc = location.bottom;
            }
            for (int i = 0; i < middle.Length; i++)
            {
                t[middle[i]].loc = location.middle;
            }
            t[top].loc = location.top;

        }

        //note to self:
        //top will be modulo of colors;
        //others will be a switch. might need to change order in array of tethedrons.

        private static void rotate(ref int[] arr, int d,int n,int start)
        {
            int k = start;
            Tetrahedron[] temp = new Tetrahedron[n];
            for (int i = d + start; i < n; i++)
            {
                temp[k] = t[arr[i]];
                k++;
            }

            // Storing the first d elements of array arr[]
            //  into temp
            for (int i = 0 + start; i < d + start; i++)
            {
                temp[k] = t[arr[i]];
                k++;
            }

            // Copying the elements of temp[] in arr[]
            // to get the final rotated array
            for (int i = 0 + start; i < n; i++)
            {
                t[arr[i]] = temp[i];
            }

        }
        public static void rotate_bottom(bool right)
        {
            int d = right ? 8 : 4;
            int d2 = right ? 2:1;
            rotate(ref bottom, d,12,0);
            rotate(ref bottom, d2, 15, 12);
        }
        public static void rotate_middle(bool right)
        {
            int d = right ? 4 : 2;
            rotate(ref middle, d, middle.Length, 0);
        }

    }

}
