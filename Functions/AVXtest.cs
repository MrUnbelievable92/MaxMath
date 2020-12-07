using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testc(int4 a, int4 b)
        {
            int4 CF_intermediate = ~a & b;

            bool CF = CF_intermediate.x > -1 &
                      CF_intermediate.y > -1 &
                      CF_intermediate.z > -1 &
                      CF_intermediate.w > -1;

            return CF;
        }

        /// <summary>    For all corresponding values the following is true: NOT(both values are negative)    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testz(int4 a, int4 b)
        {
            return cvt_boolean(X86.Avx.testz_ps(*(v128*)&a, *(v128*)&b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testznc(int4 a, int4 b)
        {
            bool CF = testc(a, b);
            bool ZF = testz(a, b);

            return !(CF | ZF);
        }
    }
}
