using System;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]     [return: AssumeRange(-1, 3)] 
        public static int last(bool2 x)
        {
            return 3 - (math.lzcnt(*(short*)&x) / 8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]     [return: AssumeRange(-1, 3)] 
        public static int last(bool3 x)
        {
            return 3 - (math.lzcnt(*(int*)&x & 0x00FF_FFFF) / 8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]     [return: AssumeRange(-1, 3)] 
        public static int last(bool4 x)
        {
            return 3 - (math.lzcnt(*(int*)&x) / 8);
        }
    }
}