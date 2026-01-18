using System.Collections.Generic;

namespace MaxMath.Tests
{
    internal struct SubVector
    {
        internal string Name;
        internal int Length;
        internal int Index;
    }

    internal class SubVectorIterator
    {
        internal SubVectorIterator(int num)
        {
            Num = num;
        }

        private int Num;

        internal List<SubVector> Generate()
        {
            List<SubVector> result = new List<SubVector>();
            int length = 2;

            while (length != Num)
            {
                for (int index = 0; index + length <= Num; index++)
                {
                    result.Add(new SubVector{ Name = $"v{length}_{index}", Length = length, Index = index });
                }

                switch (length)
                {
                    case 2:  length = 3; break;
                    case 3:  length = 4; break;
                    default: length *= 2; break;
                }
            }

            return result;
        }
    }
}
