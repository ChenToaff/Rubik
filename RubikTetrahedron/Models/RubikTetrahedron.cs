﻿using System;
using RubikTetrahedron.Enums;

namespace OpenGL
{
    public static class RubikTetrahedron
    {
        public static Tetrahedron[] tetrahedronArray = new Tetrahedron[22];
        public static int axis;
        public static int[] bottom;
        public static int[] middle;
        public static int top;


        public static double edgeLength = (3 * Tetrahedron.edgeLength);
        public static double width = (Math.Sqrt(6) / 3) * edgeLength;
        public static double height = (Math.Sqrt(3) / 2) * edgeLength;

        public static double mediumHeight = (Math.Sqrt(3) / 2) * (2 * Tetrahedron.edgeLength);
        public static bool shadingMode;




        public static double[,] dir_XYZ = new double[4,3] {
            { 0, 0, 1.5* (Tetrahedron.edgeLength) } ,
            { -1.5* (Tetrahedron.edgeLength), -height / 3,-(width/4) },
            {0,(2*height/3),  -(width/4) },
            { 1.5* (Tetrahedron.edgeLength) , -height / 3,-(width/4) },
        };
       
        public static void Init()
        {
            tetrahedronArray[0] = new Tetrahedron(new[] { Color.red, Color.blue, Color.green, Color.black },  false);      //0  main corner
            tetrahedronArray[1] = new Tetrahedron(new[] { Color.black, Color.black, Color.green, Color.red }, true);       ;  //1 center-piece
            tetrahedronArray[2] = new Tetrahedron(new[] { Color.black, Color.black, Color.red, Color.black },  false, true);              //2
            tetrahedronArray[3] = new Tetrahedron(new[] { Color.red, Color.black, Color.green, Color.black } , false);                    //3
            tetrahedronArray[4] = new Tetrahedron(new[] { Color.black, Color.black, Color.green, Color.black },true);                     //4  center-piece
            tetrahedronArray[5] = new Tetrahedron(new[] { Color.black, Color.black, Color.red, Color.black } , false, true);        //5
            tetrahedronArray[6] = new Tetrahedron(new[] { Color.red, Color.black, Color.green, Color.yellow }, false);              //6   main corner
            tetrahedronArray[7] = new Tetrahedron(new[] { Color.black, Color.black, Color.yellow, Color.black },true);                 //7 center-piece
            tetrahedronArray[8] = new Tetrahedron(new[] { Color.red, Color.black, Color.yellow, Color.black }, false);                //8
            tetrahedronArray[9] = new Tetrahedron(new[] { Color.black, Color.black, Color.red, Color.black },false, true);//9 center-piece
            tetrahedronArray[10]= new Tetrahedron(new[] { Color.black, Color.black, Color.yellow, Color.black }, true);                ;  //10
            tetrahedronArray[11]= new Tetrahedron(new[] { Color.red, Color.black, Color.yellow, Color.blue },false);      //11   main corner
            tetrahedronArray[12]= new Tetrahedron(new[] { Color.black, Color.black, Color.blue, Color.black }, true);                 //12 center-piece
            tetrahedronArray[13]= new Tetrahedron(new[] { Color.red, Color.black, Color.blue, Color.black }, false);      //13 
            tetrahedronArray[14]= new Tetrahedron(new[] { Color.black, Color.black, Color.blue, Color.black } ,true);               //14 center-piece
            tetrahedronArray[15]= new Tetrahedron(new[] { Color.black, Color.blue, Color.green, Color.black } ,false);              //15 corner
            tetrahedronArray[16]= new Tetrahedron(new[] { Color.black, Color.black, Color.green, Color.black },true);                  //16 center-piece
            tetrahedronArray[17]= new Tetrahedron(new[] { Color.black, Color.black, Color.green, Color.yellow },false);              //17 corner
            tetrahedronArray[18]= new Tetrahedron(new[] { Color.black, Color.black, Color.yellow, Color.black },true);               //18 center-piece
            tetrahedronArray[19]= new Tetrahedron(new[] { Color.black, Color.black, Color.yellow, Color.blue },false);                 //19 corner
            tetrahedronArray[20]= new Tetrahedron(new[] { Color.black, Color.black, Color.blue, Color.black } ,true);                 //20 center-piece
            tetrahedronArray[21]= new Tetrahedron(new[] { Color.black, Color.blue, Color.green, Color.yellow },false);              //21  main corner

            SetAxis(1);
        }


        public static void SetAxis(int axis)
        {
            RubikTetrahedron.axis = axis;
            switch (axis)
            {
                case 1:
                    bottom = new[] { 0, 1, 3, 4, 6, 7, 8, 10, 11, 12, 13, 14, 2, 5, 9 };
                    middle = new[] { 15, 16, 17, 18, 19, 20 };
                    top = 21;
                    break;
                case 2:
                    bottom = new[] { 6, 4, 17, 16, 21, 20, 19, 12, 11, 9, 8, 5, 7, 18, 10 };
                    middle = new[] { 3, 1, 15, 14, 13, 2 };
                    top = 0;
                    break;
                case 3:
                    bottom = new[] { 6, 5, 3, 2, 0, 14, 15, 20, 21, 18, 17, 7, 4, 1, 16 };
                    middle = new[] { 8, 9, 13, 12, 19, 10 }; ;

                    top = 11;

                    break;
                case 4:
                    bottom = new[] { 0, 2, 13, 9, 11, 10, 19, 18, 21, 16, 15, 1, 14, 12, 20 };

                    middle = new[] { 3,5,8,7,17,4 };
                    top = 6;
                    break;
                default:
                    return;
            }
            for (int i = 0; i < bottom.Length; i++)
            {
                tetrahedronArray[bottom[i]].loc = location.bottom;
            }
            for (int i = 0; i < middle.Length; i++)
            {
                tetrahedronArray[middle[i]].loc = location.middle;
            }
            tetrahedronArray[top].loc = location.top;

        }

        private static void rotate(ref int[] arr, int d, int n, int start)
        {
            int k = start;
            Tetrahedron[] temp = new Tetrahedron[n];
            for (int i = d + start; i < n; i++)
            {
                temp[k] = tetrahedronArray[arr[i]];
                k++;
            }

            // Storing the first d elements of array arr[]
            //  into temp
            for (int i = 0 + start; i < d + start; i++)
            {
                temp[k] = tetrahedronArray[arr[i]];
                k++;
            }

            // Copying the elements of temp[] in arr[]
            // to get the final rotated array
            for (int i = 0 + start; i < n; i++)
            {
                tetrahedronArray[arr[i]] = temp[i];
            }

        }
        public static void rotate_bottom(bool right)
        {
            int d = right ? 8 : 4;
            int d2 = right ? 2 : 1;
            rotate(ref bottom, d, 12, 0);
            rotate(ref bottom, d2, 15, 12);

        }
        public static void rotate_middle(bool right)
        {
            int d = right ? 4 : 2;
            rotate(ref middle, d, middle.Length, 0);
        }


    }

}