using System.Collections.Generic;

namespace MaxMath.Tests
{
    unsafe internal struct Swizzle
    {
        internal Swizzle(byte* v, int num)
        {
            Dictionary<byte, char> map_xyzw = new Dictionary<byte, char>
            {
                { 0, 'x' },
                { 1, 'y' },
                { 2, 'z' },
                { 3, 'w' },
            };

            Name = map_xyzw[v[0]].ToString();
            Indices = new int[num];
            for (int i = 1; i < num; i++)
            {
                Name += map_xyzw[v[i]];
                Indices[i] = v[i];
            }

            if        (num == 2)   AllUnique = maxmath.all_dif(*(byte2*)v);
            else if   (num == 3)   AllUnique = maxmath.all_dif(*(byte3*)v);
            else    /*(num == 4)*/ AllUnique = maxmath.all_dif(*(byte4*)v);
        }

        internal string Name;
        internal int[] Indices;
        internal bool AllUnique;
    }

    unsafe internal class SwizzleIterator
    {
        internal SwizzleIterator(int num)
        {
            Num = num;
        }

        private int Num;

        private static bool Next(byte* v, int indices, int num)
        {
            for (int i = num - 1; i >= 0; i--)
            {
                if (v[i] == indices - 1)
                {
                    v[i] = 0;

                    continue;
                }
                else
                {
                    v[i]++;

                    return true;
                }
            }

            return false;
        }

        private void AddLoop(List<Swizzle> result, byte* v, int num)
        {
            do
            {
                result.Add(new Swizzle(v, num));
            }
            while (Next(v, Num, num));
        }

        internal List<Swizzle> Generate()
        {
            List<Swizzle> result = new List<Swizzle>();

            byte4 v4 = 0;
            AddLoop(result, (byte*)&v4, 4);
            byte3 v3 = 0;
            AddLoop(result, (byte*)&v3, 3);
            byte2 v2 = 0;
            AddLoop(result, (byte*)&v2, 2);

            return result;
        }
    }
}
