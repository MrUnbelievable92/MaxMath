using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool2 x)
        {
            return math.tzcnt(*(int*)&x) / 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool3 x)
        {
            return math.tzcnt(*(int*)&x) / 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool4 x)
        {
            return math.tzcnt(*(int*)&x) / 8;
        }
    }
}