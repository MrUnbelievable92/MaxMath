using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 frsqrt23add_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = Sse.rsqrt_ps(a);
                v128 result = Sse.mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, Sse2.set1_epi32(unchecked((int)0xC040_0000)));
                result = Sse.mul_ps(result, Sse2.set1_epi32(unchecked((int)0xBF00_0000)));

                return fmadd_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 frsqrt23sub_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = Sse.rsqrt_ps(a);
                v128 result = Sse.mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, Sse2.set1_epi32(unchecked((int)0xC040_0000)));
                result = Sse.mul_ps(result, Sse2.set1_epi32(unchecked((int)0xBF00_0000)));

                return fmsub_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnrsqrt23add_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = Sse.rsqrt_ps(a);
                v128 result = Sse.mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, Sse2.set1_epi32(unchecked((int)0xC040_0000)));
                result = Sse.mul_ps(result, Sse2.set1_epi32(unchecked((int)0xBF00_0000)));

                return fnmadd_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnrsqrt23sub_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = Sse.rsqrt_ps(a);
                v128 result = Sse.mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, Sse2.set1_epi32(unchecked((int)0xC040_0000)));
                result = Sse.mul_ps(result, Sse2.set1_epi32(unchecked((int)0xBF00_0000)));

                return fnmsub_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 frsqrt23addsub_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = Sse.rsqrt_ps(a);
                v128 result = Sse.mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, Sse2.set1_epi32(unchecked((int)0xC040_0000)));
                result = Sse.mul_ps(result, Sse2.set1_epi32(unchecked((int)0xBF00_0000)));

                return fmaddsub_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 frsqrt23subadd_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = Sse.rsqrt_ps(a);
                v128 result = Sse.mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, Sse2.set1_epi32(unchecked((int)0xC040_0000)));
                result = Sse.mul_ps(result, Sse2.set1_epi32(unchecked((int)0xBF00_0000)));

                return fmsubadd_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_frsqrt23add_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                v256 rsqrt = Avx.mm256_rsqrt_ps(a);
                v256 result = Avx.mm256_mul_ps(a, rsqrt);
                result = mm256_fmadd_ps(rsqrt, result, Avx.mm256_set1_epi32(unchecked((int)0xC040_0000)));
                result = Avx.mm256_mul_ps(result, Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000)));

                return mm256_fmadd_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_frsqrt23sub_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                v256 rsqrt = Avx.mm256_rsqrt_ps(a);
                v256 result = Avx.mm256_mul_ps(a, rsqrt);
                result = mm256_fmadd_ps(rsqrt, result, Avx.mm256_set1_epi32(unchecked((int)0xC040_0000)));
                result = Avx.mm256_mul_ps(result, Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000)));

                return mm256_fmsub_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fnrsqrt23add_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                v256 rsqrt = Avx.mm256_rsqrt_ps(a);
                v256 result = Avx.mm256_mul_ps(a, rsqrt);
                result = mm256_fmadd_ps(rsqrt, result, Avx.mm256_set1_epi32(unchecked((int)0xC040_0000)));
                result = Avx.mm256_mul_ps(result, Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000)));

                return mm256_fnmadd_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fnrsqrt23sub_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                v256 rsqrt = Avx.mm256_rsqrt_ps(a);
                v256 result = Avx.mm256_mul_ps(a, rsqrt);
                result = mm256_fmadd_ps(rsqrt, result, Avx.mm256_set1_epi32(unchecked((int)0xC040_0000)));
                result = Avx.mm256_mul_ps(result, Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000)));

                return mm256_fnmsub_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_frsqrt23addsub_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                v256 rsqrt = Avx.mm256_rsqrt_ps(a);
                v256 result = Avx.mm256_mul_ps(a, rsqrt);
                result = mm256_fmadd_ps(rsqrt, result, Avx.mm256_set1_epi32(unchecked((int)0xC040_0000)));
                result = Avx.mm256_mul_ps(result, Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000)));

                return mm256_fmaddsub_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_frsqrt23subadd_ps(v256 a, v256 b)
        {
            if (Avx.IsAvxSupported)
            {
                v256 rsqrt = Avx.mm256_rsqrt_ps(a);
                v256 result = Avx.mm256_mul_ps(a, rsqrt);
                result = mm256_fmadd_ps(rsqrt, result, Avx.mm256_set1_epi32(unchecked((int)0xC040_0000)));
                result = Avx.mm256_mul_ps(result, Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000)));

                return mm256_fmsubadd_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }
    }
}
