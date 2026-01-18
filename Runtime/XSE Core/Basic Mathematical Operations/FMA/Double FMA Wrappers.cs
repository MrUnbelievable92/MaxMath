//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmadd_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmadd_pd(a, b, c);
            }
            else
#endif
            if (Sse2.IsSse2Supported)
            {
                return add_pd(mul_pd(a, b), c);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vfmaq_f64(a, b, c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmsub_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmsub_pd(a, b, c);
            }
            else
#endif
            if (Sse2.IsSse2Supported)
            {
                return sub_pd(mul_pd(a, b), c);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vfmsq_f64(a, b, c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnmadd_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fnmadd_pd(a, b, c);
            }
            else
#endif
            if (Sse2.IsSse2Supported)
            {
                return sub_pd(c, mul_pd(a, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                if (constexpr.IS_CONST(a))
                {
                    a = neg_pd(a);
                }
                else
                {
                    b = neg_pd(b);
                }

                return fmadd_pd(a, b, c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnmsub_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fnmsub_pd(a, b, c);
            }
            else
#endif
            if (Sse2.IsSse2Supported)
            {
                return sub_pd(neg_pd(c), mul_pd(a, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                if (constexpr.IS_CONST(a))
                {
                    a = neg_pd(a);
                }
                else
                {
                    b = neg_pd(b);
                }

                return fmsub_pd(a, b, c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmaddsub_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmaddsub_pd(a, b, c);
            }
            else
#endif
            if (Sse3.IsSse3Supported)
            {
                return addsub_pd(mul_pd(a, b), c);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return fmadd_pd(a, b, xor_pd(c, new v128(1ul << 63, 0)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmsubadd_pd(v128 a, v128 b, v128 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmsubadd_pd(a, b, c);
            }
            else
#endif
            if (Sse3.IsSse3Supported)
            {
                return addsub_pd(mul_pd(a, b), xor_pd(c, new v128(1ul << 63, 0)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return fmsub_pd(a, b, xor_pd(c, new v128(1ul << 63, 0)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmadd_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmadd_pd(a, b, c);
            }
            else
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_add_pd(Avx.mm256_mul_pd(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmsub_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmsub_pd(a, b, c);
            }
            else
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_pd(Avx.mm256_mul_pd(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fnmadd_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fnmadd_pd(a, b, c);
            }
            else
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_pd(c, Avx.mm256_mul_pd(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fnmsub_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fnmsub_pd(a, b, c);
            }
            else
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_pd(mm256_neg_pd(c), Avx.mm256_mul_pd(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmaddsub_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmaddsub_pd(a, b, c);
            }
            else
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_pd(Avx.mm256_mul_pd(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmsubadd_pd(v256 a, v256 b, v256 c)
        {
#if !TESTING
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmsubadd_pd(a, b, c);
            }
            else
#endif
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_pd(Avx.mm256_mul_pd(a, b), Avx.mm256_xor_pd(c, new v256(1ul << 63, 0, 1ul << 63, 0)));
            }
            else throw new IllegalInstructionException();
        }
    }
}
