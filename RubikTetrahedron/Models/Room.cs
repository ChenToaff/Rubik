namespace OpenGL
{
    public static class Room
    {
        public static uint[] textures = new uint[6];
        public static float baseUnit = 12f;
        public static float[,,] cubemap = new float[6, 4, 3]
        {
            {{-baseUnit, -baseUnit, baseUnit },{baseUnit, -baseUnit, baseUnit },{baseUnit, baseUnit, baseUnit },{-baseUnit, baseUnit, baseUnit } },                  // front
            {{baseUnit, -baseUnit, -baseUnit },{-baseUnit, -baseUnit, -baseUnit },{-baseUnit, baseUnit, -baseUnit },{baseUnit, baseUnit, -baseUnit } },              // back
            {{-baseUnit, -baseUnit, -baseUnit },{-baseUnit, -baseUnit, baseUnit },{-baseUnit, baseUnit, baseUnit },{-baseUnit, baseUnit, -baseUnit } },              // left
            {{baseUnit, -baseUnit, baseUnit },{baseUnit, -baseUnit, -baseUnit },{baseUnit, baseUnit, -baseUnit },{baseUnit, baseUnit, baseUnit } },                  // right
            {{-baseUnit, baseUnit, baseUnit },{baseUnit, baseUnit, baseUnit },{baseUnit, baseUnit, -baseUnit },{-baseUnit, baseUnit, -baseUnit } },                  // top
            {{-baseUnit, -baseUnit, -baseUnit },{baseUnit, -baseUnit, -baseUnit },{baseUnit, -baseUnit, baseUnit },{-baseUnit, -baseUnit, baseUnit } } ,             // bottom
        };
      
    }
}
