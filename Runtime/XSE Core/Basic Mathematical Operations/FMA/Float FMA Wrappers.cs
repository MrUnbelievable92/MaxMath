using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmadd_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmadd_ps(a, b, c);
            }
            else if (Sse2.IsSse2Supported)
            {
                return add_ps(mul_ps(a, b), c);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vfmaq_f32(a, b, c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmsub_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmsub_ps(a, b, c);
            }
            else if (Sse2.IsSse2Supported)
            {
                return sub_ps(mul_ps(a, b), c);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vfmsq_f32(a, b, c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnmadd_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fnmadd_ps(a, b, c);
            }
            else if (Sse2.IsSse2Supported)
            {
                return sub_ps(c, mul_ps(a, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                if (constexpr.IS_CONST(a))
                {
                    a = neg_ps(a);
                }
                else
                {
                    b = neg_ps(b);
                }

                return fmadd_ps(a, b, c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fnmsub_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fnmsub_ps(a, b, c);
            }
            else if (Sse2.IsSse2Supported)
            {
                return sub_ps(neg_ps(c), mul_ps(a, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                if (constexpr.IS_CONST(a))
                {
                    a = neg_ps(a);
                }
                else
                {
                    b = neg_ps(b);
                }

                return fmsub_ps(a, b, c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmaddsub_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmaddsub_ps(a, b, c);
            }
            else if (Sse3.IsSse3Supported)
            {
                return addsub_ps(mul_ps(a, b), c);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return fmadd_ps(a, b, xor_ps(c, new v128(1 << 31, 0, 1 << 31, 0)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fmsubadd_ps(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.fmsubadd_ps(a, b, c);
            }
            else if (Sse3.IsSse3Supported)
            {
                return addsub_ps(mul_ps(a, b), xor_ps(c, new v128(1 << 31, 0, 1 << 31, 0)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return fmsub_ps(a, b, xor_ps(c, new v128(1 << 31, 0, 1 << 31, 0)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmadd_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmadd_ps(a, b, c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_add_ps(Avx.mm256_mul_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmsub_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmsub_ps(a, b, c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(Avx.mm256_mul_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fnmadd_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fnmadd_ps(a, b, c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(c, Avx.mm256_mul_ps(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fnmsub_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fnmsub_ps(a, b, c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(mm256_neg_ps(c), Avx.mm256_mul_ps(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmaddsub_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmaddsub_ps(a, b, c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_ps(Avx.mm256_mul_ps(a, b), c);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_fmsubadd_ps(v256 a, v256 b, v256 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmsubadd_ps(a, b, c);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_ps(Avx.mm256_mul_ps(a, b), Avx.mm256_xor_ps(c, new v256(1 << 31, 0, 1 << 31, 0, 1 << 31, 0, 1 << 31, 0)));
            }
            else throw new IllegalInstructionException();
        }
    }
}
