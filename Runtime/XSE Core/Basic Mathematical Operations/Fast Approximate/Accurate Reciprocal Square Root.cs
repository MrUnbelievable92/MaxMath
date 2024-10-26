using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rsqrt23_ps(v128 a)
		{
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = rsqrt_ps(a);
                v128 result = mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, set1_epi32(0xC040_0000));
                result = mul_ps(result, set1_epi32(0xBF00_0000));
                result = mul_ps(rsqrt, result);

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return div_ps(set1_ps(1f), sqrt_ps(a));
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_rsqrt23_ps(v256 a)
		{
            if (Avx.IsAvxSupported)
            {
                v256 rsqrt = Avx.mm256_rsqrt_ps(a);
                v256 result = Avx.mm256_mul_ps(a, rsqrt);
                result = mm256_fmadd_ps(rsqrt, result, mm256_set1_epi32(0xC040_0000));
                result = Avx.mm256_mul_ps(result, mm256_set1_epi32(0xBF00_0000));
                result = Avx.mm256_mul_ps(rsqrt, result);

                return result;
            }
            else throw new IllegalInstructionException();
		}
	}
}