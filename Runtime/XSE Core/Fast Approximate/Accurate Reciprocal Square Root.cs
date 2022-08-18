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
            if (Sse.IsSseSupported)
            {  
                v128 rsqrt = Sse.rsqrt_ps(a);
                v128 result = Sse.mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, Sse2.set1_epi32(unchecked((int)0xC040_0000)));
                result = Sse.mul_ps(result, Sse2.set1_epi32(unchecked((int)0xBF00_0000)));
                result = Sse.mul_ps(rsqrt, result);

                return result;
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
                result = mm256_fmadd_ps(rsqrt, result, Avx.mm256_set1_epi32(unchecked((int)0xC040_0000)));
                result = Avx.mm256_mul_ps(result, Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000)));
                result = Avx.mm256_mul_ps(rsqrt, result);

                return result;
            }
            else throw new IllegalInstructionException();
		}
	}
}