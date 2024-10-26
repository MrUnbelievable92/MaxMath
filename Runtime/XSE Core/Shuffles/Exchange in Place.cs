using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void xchg_si128([NoAlias] ref v128 a, [NoAlias] ref v128 b, v128 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 cpy = a;

                a = blendv_si128(a, b, mask);
                b = blendv_si128(b, cpy, mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_xchg_si256([NoAlias] ref v256 a, [NoAlias] ref v256 b, v256 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 cpy = a;

                a = mm256_blendv_si256(a, b, mask);
                b = mm256_blendv_si256(b, cpy, mask);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void xchg_si128([NoAlias] ref v128 a, [NoAlias] ref v128 b)
        {
            if (Architecture.IsBlendSupported)
            {
                xchg_si128(ref a, ref b, setall_si128());
            }
            else if (Architecture.IsSIMDSupported)
            {
                a = add_epi32(a, b);
                b = sub_epi32(a, b);
                a = sub_epi32(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_xchg_si256([NoAlias] ref v256 a, [NoAlias] ref v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                mm256_xchg_si256(ref a, ref b, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }
    }
}
