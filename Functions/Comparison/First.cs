using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the index of the first true bool value of a bool2 vector or 4 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool2 x)
        {
            return math.tzcnt(*(int*)&x) / 8;
        }

        /// <summary>       Returns the index of the first true bool value of a bool3 vector or 4 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool3 x)
        {
            return math.tzcnt(*(int*)&x) / 8;
        }

        /// <summary>       Returns the index of the first true bool value of a bool4 vector or 4 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool4 x)
        {
            return math.tzcnt(*(int*)&x) / 8;
        }
    }
}