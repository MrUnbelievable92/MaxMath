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
                v128 rsqrt = rsqrt_ps(a);
                v128 result = mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, set1_epi32(0xC040_0000));
                result = mul_ps(result, set1_epi32(0xBF00_0000));

                return fmadd_ps(rsqrt, result, b);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return add_ps(div_ps(set1_ps(1f), sqrt_ps(a)), b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 frsqrt23sub_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = rsqrt_ps(a);
                v128 result = mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, set1_epi32(0xC040_0000));
                result = mul_ps(result, set1_epi32(0xBF00_0000));

                return fmsub_ps(rsqrt, result, b);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sub_ps(div_ps(set1_ps(1f), sqrt_ps(a)), b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnrsqrt23add_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = rsqrt_ps(a);
                v128 result = mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, set1_epi32(0xC040_0000));
                result = mul_ps(result, set1_epi32(0xBF00_0000));

                return fnmadd_ps(rsqrt, result, b);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sub_ps(b, div_ps(set1_ps(1f), sqrt_ps(a)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnrsqrt23sub_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = rsqrt_ps(a);
                v128 result = mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, set1_epi32(0xC040_0000));
                result = mul_ps(result, set1_epi32(0xBF00_0000));

                return fnmsub_ps(rsqrt, result, b);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sub_ps(neg_ps(b), div_ps(set1_ps(1f), sqrt_ps(a)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 frsqrt23addsub_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = rsqrt_ps(a);
                v128 result = mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, set1_epi32(0xC040_0000));
                result = mul_ps(result, set1_epi32(0xBF00_0000));

                return fmaddsub_ps(rsqrt, result, b);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return addsub_ps(div_ps(set1_ps(1f), sqrt_ps(a)), b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 frsqrt23subadd_ps(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 rsqrt = rsqrt_ps(a);
                v128 result = mul_ps(a, rsqrt);
                result = fmadd_ps(rsqrt, result, set1_epi32(0xC040_0000));
                result = mul_ps(result, set1_epi32(0xBF00_0000));

                return fmsubadd_ps(rsqrt, result, b);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return subadd_ps(div_ps(set1_ps(1f), sqrt_ps(a)), b);
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
                result = mm256_fmadd_ps(rsqrt, result, mm256_set1_epi32(0xC040_0000));
                result = Avx.mm256_mul_ps(result, mm256_set1_epi32(0xBF00_0000));

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
                result = mm256_fmadd_ps(rsqrt, result, mm256_set1_epi32(0xC040_0000));
                result = Avx.mm256_mul_ps(result, mm256_set1_epi32(0xBF00_0000));

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
                result = mm256_fmadd_ps(rsqrt, result, mm256_set1_epi32(0xC040_0000));
                result = Avx.mm256_mul_ps(result, mm256_set1_epi32(0xBF00_0000));

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
                result = mm256_fmadd_ps(rsqrt, result, mm256_set1_epi32(0xC040_0000));
                result = Avx.mm256_mul_ps(result, mm256_set1_epi32(0xBF00_0000));

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
                result = mm256_fmadd_ps(rsqrt, result, mm256_set1_epi32(0xC040_0000));
                result = Avx.mm256_mul_ps(result, mm256_set1_epi32(0xBF00_0000));

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
                result = mm256_fmadd_ps(rsqrt, result, mm256_set1_epi32(0xC040_0000));
                result = Avx.mm256_mul_ps(result, mm256_set1_epi32(0xBF00_0000));

                return mm256_fmsubadd_ps(rsqrt, result, b);
            }
            else throw new IllegalInstructionException();
        }
    }
}
