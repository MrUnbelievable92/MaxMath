using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool testc(int4 a, int4 b)
        {
            int4 CF_intermediate = ~a & b;

            bool CF = CF_intermediate.x > -1 &
                      CF_intermediate.y > -1 &
                      CF_intermediate.z > -1 &
                      CF_intermediate.w > -1;

            return CF;
        }

        /// <summary>    For all corresponding values in two int4 vectors the following is true: NOT(both values are negative)    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool testz(int4 a, int4 b)
        {
            return tobool(Avx.testz_ps(*(v128*)&a, *(v128*)&b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool testznc(int4 a, int4 b)
        {
            bool CF = testc(a, b);
            bool ZF = testz(a, b);

            return !(CF | ZF);
        }
    }
}
