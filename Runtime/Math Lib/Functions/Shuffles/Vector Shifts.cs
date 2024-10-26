using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v128 bslli_si128(v128 a, int imm8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        switch (imm8)
                        {
                            case 1:  return Sse2.bslli_si128(a, 1);
                            case 2:  return Sse2.bslli_si128(a, 2);
                            case 3:  return Sse2.bslli_si128(a, 3);
                            case 4:  return Sse2.bslli_si128(a, 4);
                            case 5:  return Sse2.bslli_si128(a, 5);
                            case 6:  return Sse2.bslli_si128(a, 6);
                            case 7:  return Sse2.bslli_si128(a, 7);
                            case 8:  return Sse2.bslli_si128(a, 8);
                            case 9:  return Sse2.bslli_si128(a, 9);
                            case 10: return Sse2.bslli_si128(a, 10);
                            case 11: return Sse2.bslli_si128(a, 11);
                            case 12: return Sse2.bslli_si128(a, 12);
                            case 13: return Sse2.bslli_si128(a, 13);
                            case 14: return Sse2.bslli_si128(a, 14);
                            case 15: return Sse2.bslli_si128(a, 15);

                            default: return a;
                        }
                    }

                    v128* stack = stackalloc v128[2];

                    stack[0] = setzero_si128();
                    stack[1] = a;

                    return loadu_si128((byte*)stack + (sizeof(v128) - (((uint)imm8 % 16) * sizeof(byte))));
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    if (imm8 == 0)
                    {
                        return a;
                    }
                    else if ((imm8 & ~15) != 0)
                    {
                        return Arm.Neon.vdupq_n_s8(0);
                    }
                    else
                    {
                        return Xse.imm8.Arm.vextq_s8(Arm.Neon.vdupq_n_s8(0), a, ((imm8 <= 0) | (imm8 > 15)) ? 0 : (16 - imm8));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v128 bsrli_si128(v128 a, int imm8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        switch (imm8)
                        {
                            case 1:  return Sse2.bsrli_si128(a, 1);
                            case 2:  return Sse2.bsrli_si128(a, 2);
                            case 3:  return Sse2.bsrli_si128(a, 3);
                            case 4:  return Sse2.bsrli_si128(a, 4);
                            case 5:  return Sse2.bsrli_si128(a, 5);
                            case 6:  return Sse2.bsrli_si128(a, 6);
                            case 7:  return Sse2.bsrli_si128(a, 7);
                            case 8:  return Sse2.bsrli_si128(a, 8);
                            case 9:  return Sse2.bsrli_si128(a, 9);
                            case 10: return Sse2.bsrli_si128(a, 10);
                            case 11: return Sse2.bsrli_si128(a, 11);
                            case 12: return Sse2.bsrli_si128(a, 12);
                            case 13: return Sse2.bsrli_si128(a, 13);
                            case 14: return Sse2.bsrli_si128(a, 14);
                            case 15: return Sse2.bsrli_si128(a, 15);

                            default: return a;
                        }
                    }

                    v128* stack = stackalloc v128[2];

                    stack[0] = a;
                    stack[1] = setzero_si128();

                    return loadu_si128((byte*)stack + (((uint)imm8 % 16) * sizeof(byte)));
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    if ((imm8 & ~15) != 0)
                    {
                        return Arm.Neon.vdupq_n_s8(0);
                    }
                    else
                    {
                        return Xse.imm8.Arm.vextq_s8(a, Arm.Neon.vdupq_n_s8(0),  (imm8 > 15 ? 0 : imm8));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v256 mm256_bslli_si256(v256 a, int imm8)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        switch (imm8)
                        {
                            case 1:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a, 15 * sizeof(byte));
                            case 2:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a, 14 * sizeof(byte));
                            case 3:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a, 13 * sizeof(byte));
                            case 4:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a, 12 * sizeof(byte));
                            case 5:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a, 11 * sizeof(byte));
                            case 6:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a, 10 * sizeof(byte));
                            case 7:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  9 * sizeof(byte));
                            case 8:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  8 * sizeof(byte));
                            case 9:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  7 * sizeof(byte));
                            case 10: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  6 * sizeof(byte));
                            case 11: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  5 * sizeof(byte));
                            case 12: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  4 * sizeof(byte));
                            case 13: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  3 * sizeof(byte));
                            case 14: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  2 * sizeof(byte));
                            case 15: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2)), a,  1 * sizeof(byte));
                            case 16: return Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 17: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  1 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 18: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  2 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 19: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  3 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 20: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  4 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 21: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  5 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 22: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  6 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 23: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  7 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 24: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  8 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 25: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a,  9 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 26: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a, 10 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 27: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a, 11 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 28: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a, 12 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 29: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a, 13 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 30: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a, 14 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));
                            case 31: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(a, 15 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 0, 0, 2));

                            default: return a;
                        }
                    }
                    else
                    {
                        v256* stack = stackalloc v256[2];

                        stack[0] = Avx.mm256_setzero_si256();
                        stack[1] = a;

                        return Avx.mm256_loadu_si256((byte*)(stack + 1) - ((uint)imm8 % 32));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v256 mm256_bsrli_si256(v256 a, int imm8)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        switch (imm8)
                        {
                            case 1:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  1 * sizeof(byte));
                            case 2:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  2 * sizeof(byte));
                            case 3:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  3 * sizeof(byte));
                            case 4:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  4 * sizeof(byte));
                            case 5:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  5 * sizeof(byte));
                            case 6:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  6 * sizeof(byte));
                            case 7:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  7 * sizeof(byte));
                            case 8:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  8 * sizeof(byte));
                            case 9:  return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)),  9 * sizeof(byte));
                            case 10: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)), 10 * sizeof(byte));
                            case 11: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)), 11 * sizeof(byte));
                            case 12: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)), 12 * sizeof(byte));
                            case 13: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)), 13 * sizeof(byte));
                            case 14: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)), 14 * sizeof(byte));
                            case 15: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1)), 15 * sizeof(byte));
                            case 16: return Avx2.mm256_permute2x128_si256(a, Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 17: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  1 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 18: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  2 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 19: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  3 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 20: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  4 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 21: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  5 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 22: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  6 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 23: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  7 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 24: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  8 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 25: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a,  9 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 26: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a, 10 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 27: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a, 11 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 28: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a, 12 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 29: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a, 13 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 30: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a, 14 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));
                            case 31: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(a, 15 * sizeof(byte)), Avx.mm256_setzero_si256(), Sse.SHUFFLE(0, 2, 0, 1));

                            default: return a;
                        }
                    }
                    else
                    {
                        v256* stack = stackalloc v256[2];

                        stack[0] = a;
                        stack[1] = Avx.mm256_setzero_si256();

                        return Avx.mm256_loadu_si256((byte*)stack + ((uint)imm8 % 32));
                    }
                }
                else throw new IllegalInstructionException();
            }
        }


    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of shifting the components within a <see cref="bool2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 vshl(bool2 x, int n)
        {
            return tobool(vshl(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="bool3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 vshl(bool3 x, int n)
        {
            return tobool(vshl(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="bool4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 vshl(bool4 x, int n)
        {
            return tobool(vshl(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.bool8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 vshl(bool8 x, int n)
        {
            return tobool(vshl(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.bool16"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 vshl(bool16 x, int n)
        {
            return tobool(vshl(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.bool32"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 31], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 vshl(bool32 x, int n)
        {
            return tobool(vshl(tobyte(x), n));
        }


        /// <summary>       Returns the result of shifting the components within an <see cref="int2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vshl(int2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.bslli_si128(RegisterConversion.ToV128(x), n * sizeof(int)));
            }
            else
            {
                switch (n)
                {
                    case 1: return new int2(0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="int3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vshl(int3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.bslli_si128(RegisterConversion.ToV128(x), n * sizeof(int)));
            }
            else
            {
                switch (n)
                {
                    case 1: return new int3(0, x.x, x.y);
                    case 2: return new int3(0,   0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="int4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int4 vshl(int4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.bslli_si128(RegisterConversion.ToV128(x), n * sizeof(int)));
            }
            else
            {
                switch (n)
                {
                    case 1: return new int4(0, x.x, x.y, x.z);
                    case 2: return new int4(0,   0, x.x, x.y);
                    case 3: return new int4(0,   0,   0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.int8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int8 vshl(int8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bslli_si256(x, sizeof(int) * n);
            }
            else if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:
                        {
                            v128 lo = Xse.bslli_si128(RegisterConversion.ToV128(x._v4_0), 1 * sizeof(int));

                            return new int8(RegisterConversion.ToInt4(lo), math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ));
                        }
                        case 2:
                        {
                            v128 lo = Xse.bslli_si128(RegisterConversion.ToV128(x._v4_0), 2 * sizeof(int));

                            return new int8(RegisterConversion.ToInt4(lo), math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY));
                        }
                        case 3:
                        {
                            v128 lo = Xse.bslli_si128(RegisterConversion.ToV128(x._v4_0), 3 * sizeof(int));

                            return new int8(RegisterConversion.ToInt4(lo), math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX));
                        }

                        case 4: return new int8(int4.zero, x._v4_0);

                        case 5:
                        {
                            return new int8(int4.zero, RegisterConversion.ToInt4(Xse.bslli_si128(RegisterConversion.ToV128(x._v4_0), 1 * sizeof(int))));
                        }
                        case 6:
                        {
                            return new int8(int4.zero, RegisterConversion.ToInt4(Xse.bslli_si128(RegisterConversion.ToV128(x._v4_0), 2 * sizeof(int))));
                        }
                        case 7:
                        {
                            return new int8(int4.zero, RegisterConversion.ToInt4(Xse.bslli_si128(RegisterConversion.ToV128(x._v4_0), 3 * sizeof(int))));
                        }

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = ZERO;
                    stack[1] = ZERO;
                    stack[2] = RegisterConversion.ToV128(x.v4_0);
                    stack[3] = RegisterConversion.ToV128(x.v4_4);

                    v128* address = (v128*)((byte*)stack + (2 * sizeof(v128) - (((uint)n % 8) * sizeof(int))));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new int8(RegisterConversion.ToInt4(lo), RegisterConversion.ToInt4(hi));
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new int8(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 2: return new int8(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 3: return new int8(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 4: return new int8(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 5: return new int8(0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 6: return new int8(0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 7: return new int8(0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="uint2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vshl(uint2 x, int n)
        {
            return (uint2)vshl((int2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="uint3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vshl(uint3 x, int n)
        {
            return (uint3)vshl((int3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="uint4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vshl(uint4 x, int n)
        {
            return (uint4)vshl((int4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vshl(uint8 x, int n)
        {
            return (uint8)vshl((int8)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.quarter2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 vshl(quarter2 x, int n)
        {
            return asquarter(vshl(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.quarter4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 vshl(quarter3 x, int n)
        {
            return asquarter(vshl(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.quarter4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 vshl(quarter4 x, int n)
        {
            return asquarter(vshl(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.quarter8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 vshl(quarter8 x, int n)
        {
            return asquarter(vshl(asbyte(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="half2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 vshl(half2 x, int n)
        {
            return ashalf(vshl(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="half4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 vshl(half3 x, int n)
        {
            return ashalf(vshl(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="half4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 vshl(half4 x, int n)
        {
            return ashalf(vshl(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.half8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 vshl(half8 x, int n)
        {
            return ashalf(vshl(asshort(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="float2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vshl(float2 x, int n)
        {
            return math.asfloat(vshl(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="float3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vshl(float3 x, int n)
        {
            return math.asfloat(vshl(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="float4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 vshl(float4 x, int n)
        {
            return math.asfloat(vshl(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.float8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 vshl(float8 x, int n)
        {
            return asfloat(vshl(asint(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="double2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vshl(double2 x, int n)
        {
            return asdouble(vshl(aslong(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="double3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vshl(double3 x, int n)
        {
            return asdouble(vshl(aslong(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="double4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 vshl(double4 x, int n)
        {
            return asdouble(vshl(aslong(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vshl(byte2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bslli_si128(x, n * sizeof(byte));
            }
            else
            {
                switch (n)
                {
                    case 1: return new byte2(0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vshl(byte3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bslli_si128(x, n * sizeof(byte));
            }
            else
            {
                switch (n)
                {
                    case 1: return new byte3(0, x.x, x.y);
                    case 2: return new byte3(0, 0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte4 vshl(byte4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    return Xse.bslli_si128(x, n * sizeof(byte));
                }
                else
                {
                    return Xse.cvtsi32_si128(((v128)x).SInt0 << n * 8);
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new byte4(0, x.x, x.y, x.z);
                    case 2: return new byte4(0, 0, x.x, x.y);
                    case 3: return new byte4(0, 0, 0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte8 vshl(byte8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    return Xse.bslli_si128(x, n * sizeof(byte));
                }
                else
                {
                    return Xse.cvtsi64x_si128(((v128)x).SLong0 << n * 8);
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new byte8(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 2: return new byte8(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 3: return new byte8(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 4: return new byte8(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 5: return new byte8(0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 6: return new byte8(0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 7: return new byte8(0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte16"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte16 vshl(byte16 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bslli_si128(x, n * sizeof(byte));
            }
            else
            {
                switch (n)
                {
                    case 1:  return new byte16(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 2:  return new byte16(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 3:  return new byte16(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 4:  return new byte16(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 5:  return new byte16(0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 6:  return new byte16(0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 7:  return new byte16(0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 8:  return new byte16(0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 9:  return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 10: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 11: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 12: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 13: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 14: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 15: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte32"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 31], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte32 vshl(byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bslli_si256(x, n);
            }
            else if (Architecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new byte32(Xse.bslli_si128(x._v16_0,  1 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16, 15 * sizeof(byte)));
                        case 2:  return new byte32(Xse.bslli_si128(x._v16_0,  2 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16, 14 * sizeof(byte)));
                        case 3:  return new byte32(Xse.bslli_si128(x._v16_0,  3 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16, 13 * sizeof(byte)));
                        case 4:  return new byte32(Xse.bslli_si128(x._v16_0,  4 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16, 12 * sizeof(byte)));
                        case 5:  return new byte32(Xse.bslli_si128(x._v16_0,  5 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16, 11 * sizeof(byte)));
                        case 6:  return new byte32(Xse.bslli_si128(x._v16_0,  6 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16, 10 * sizeof(byte)));
                        case 7:  return new byte32(Xse.bslli_si128(x._v16_0,  7 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  9 * sizeof(byte)));
                        case 8:  return new byte32(Xse.bslli_si128(x._v16_0,  8 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  8 * sizeof(byte)));
                        case 9:  return new byte32(Xse.bslli_si128(x._v16_0,  9 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  7 * sizeof(byte)));
                        case 10: return new byte32(Xse.bslli_si128(x._v16_0, 10 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  6 * sizeof(byte)));
                        case 11: return new byte32(Xse.bslli_si128(x._v16_0, 11 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  5 * sizeof(byte)));
                        case 12: return new byte32(Xse.bslli_si128(x._v16_0, 12 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  4 * sizeof(byte)));
                        case 13: return new byte32(Xse.bslli_si128(x._v16_0, 13 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  3 * sizeof(byte)));
                        case 14: return new byte32(Xse.bslli_si128(x._v16_0, 14 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  2 * sizeof(byte)));
                        case 15: return new byte32(Xse.bslli_si128(x._v16_0, 15 * sizeof(byte)), Xse.alignr_epi8(x._v16_0, x._v16_16,  1 * sizeof(byte)));
                        case 16: return new byte32(Xse.setzero_si128(),      x._v16_0);
                        case 17: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  1 * sizeof(byte)));
                        case 18: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  2 * sizeof(byte)));
                        case 19: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  3 * sizeof(byte)));
                        case 20: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  4 * sizeof(byte)));
                        case 21: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  5 * sizeof(byte)));
                        case 22: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  6 * sizeof(byte)));
                        case 23: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  7 * sizeof(byte)));
                        case 24: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  8 * sizeof(byte)));
                        case 25: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0,  9 * sizeof(byte)));
                        case 26: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0, 10 * sizeof(byte)));
                        case 27: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0, 11 * sizeof(byte)));
                        case 28: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0, 12 * sizeof(byte)));
                        case 29: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0, 13 * sizeof(byte)));
                        case 30: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0, 14 * sizeof(byte)));
                        case 31: return new byte32(Xse.setzero_si128(),      Xse.bslli_si128(x._v16_0, 15 * sizeof(byte)));

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = ZERO;
                    stack[1] = ZERO;
                    stack[2] = x.v16_0;
                    stack[3] = x.v16_16;

                    v128* address = (v128*)((byte*)stack + (2 * sizeof(v128) - (((uint)n % 32) * sizeof(byte))));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new byte32(lo, hi);
                }
            }
            else if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new byte32(Xse.bslli_si128(x._v16_0, 1 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,  15 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  1 * sizeof(byte))));
                        case 2:  return new byte32(Xse.bslli_si128(x._v16_0, 2 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,  14 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  2 * sizeof(byte))));
                        case 3:  return new byte32(Xse.bslli_si128(x._v16_0, 3 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,  13 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  3 * sizeof(byte))));
                        case 4:  return new byte32(Xse.bslli_si128(x._v16_0, 4 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,  12 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  4 * sizeof(byte))));
                        case 5:  return new byte32(Xse.bslli_si128(x._v16_0, 5 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,  11 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  5 * sizeof(byte))));
                        case 6:  return new byte32(Xse.bslli_si128(x._v16_0, 6 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,  10 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  6 * sizeof(byte))));
                        case 7:  return new byte32(Xse.bslli_si128(x._v16_0, 7 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   9 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  7 * sizeof(byte))));
                        case 8:  return new byte32(Xse.bslli_si128(x._v16_0, 8 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   8 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  8 * sizeof(byte))));
                        case 9:  return new byte32(Xse.bslli_si128(x._v16_0, 9 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   7 * sizeof(byte)), Xse.bslli_si128(x._v16_16,  9 * sizeof(byte))));
                        case 10: return new byte32(Xse.bslli_si128(x._v16_0, 10 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   6 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 10 * sizeof(byte))));
                        case 11: return new byte32(Xse.bslli_si128(x._v16_0, 11 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   5 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 11 * sizeof(byte))));
                        case 12: return new byte32(Xse.bslli_si128(x._v16_0, 12 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   4 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 12 * sizeof(byte))));
                        case 13: return new byte32(Xse.bslli_si128(x._v16_0, 13 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   3 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 13 * sizeof(byte))));
                        case 14: return new byte32(Xse.bslli_si128(x._v16_0, 14 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   2 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 14 * sizeof(byte))));
                        case 15: return new byte32(Xse.bslli_si128(x._v16_0, 15 * sizeof(byte)),
                                                   Xse.or_si128(Xse.bsrli_si128(x._v16_0,   1 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 15 * sizeof(byte))));
                        case 16: return new byte32(Xse.setzero_si128(), x._v16_0);
                        case 17: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  1 * sizeof(byte)));
                        case 18: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  2 * sizeof(byte)));
                        case 19: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  3 * sizeof(byte)));
                        case 20: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  4 * sizeof(byte)));
                        case 21: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  5 * sizeof(byte)));
                        case 22: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  6 * sizeof(byte)));
                        case 23: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  7 * sizeof(byte)));
                        case 24: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  8 * sizeof(byte)));
                        case 25: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0,  9 * sizeof(byte)));
                        case 26: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0, 10 * sizeof(byte)));
                        case 27: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0, 11 * sizeof(byte)));
                        case 28: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0, 12 * sizeof(byte)));
                        case 29: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0, 13 * sizeof(byte)));
                        case 30: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0, 14 * sizeof(byte)));
                        case 31: return new byte32(Xse.setzero_si128(), Xse.bslli_si128(x._v16_0, 15 * sizeof(byte)));

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = ZERO;
                    stack[1] = ZERO;
                    stack[2] = x.v16_0;
                    stack[3] = x.v16_16;

                    v128* address = (v128*)((byte*)stack + (2 * sizeof(v128) - (((uint)n % 32) * sizeof(byte))));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new byte32(lo, hi);
                }
            }
            else
            {
                switch (n)
                {
                    case 1:  return new byte32(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30);
                    case 2:  return new byte32(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29);
                    case 3:  return new byte32(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28);
                    case 4:  return new byte32(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27);
                    case 5:  return new byte32(0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26);
                    case 6:  return new byte32(0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25);
                    case 7:  return new byte32(0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24);
                    case 8:  return new byte32(0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23);
                    case 9:  return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22);
                    case 10: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21);
                    case 11: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20);
                    case 12: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19);
                    case 13: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18);
                    case 14: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17);
                    case 15: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16);
                    case 16: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15);
                    case 17: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 18: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 19: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 20: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 21: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 22: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 23: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 24: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 25: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 26: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 27: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 28: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 29: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 30: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 31: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vshl(sbyte2 x, int n)
        {
            return (sbyte2)vshl((byte2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vshl(sbyte3 x, int n)
        {
            return (sbyte3)vshl((byte3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vshl(sbyte4 x, int n)
        {
            return (sbyte4)vshl((byte4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vshl(sbyte8 x, int n)
        {
            return (sbyte8)vshl((byte8)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte16"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vshl(sbyte16 x, int n)
        {
            return (sbyte16)vshl((byte16)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte32"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 31], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 vshl(sbyte32 x, int n)
        {
            return (sbyte32)vshl((byte32)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vshl(short2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bslli_si128(x, n * sizeof(short));
            }
            else
            {
                switch (n)
                {
                    case 1: return new short2(0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vshl(short3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bslli_si128(x, n * sizeof(short));
            }
            else
            {
                switch (n)
                {
                    case 1: return new short3(0, x.x, x.y);
                    case 2: return new short3(0, 0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short4 vshl(short4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    return Xse.bslli_si128(x, n * sizeof(short));
                }
                else
                {
                    return Xse.cvtsi64x_si128(((v128)x).SLong0 << n * 16);
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new short4(0, x.x, x.y, x.z);
                    case 2: return new short4(0, 0, x.x, x.y);
                    case 3: return new short4(0, 0, 0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short8 vshl(short8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bslli_si128(x, n * sizeof(short));
            }
            else
            {
                switch (n)
                {
                    case 1: return new short8(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 2: return new short8(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 3: return new short8(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 4: return new short8(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 5: return new short8(0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 6: return new short8(0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 7: return new short8(0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short16"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short16 vshl(short16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bslli_si256(x, sizeof(short) * n);
            }
            else if (Architecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new short16(Xse.bslli_si128(x._v8_0, 1 * sizeof(short)), Xse.alignr_epi8(x._v8_0, x._v8_8, 7 * sizeof(short)));
                        case 2:  return new short16(Xse.bslli_si128(x._v8_0, 2 * sizeof(short)), Xse.alignr_epi8(x._v8_0, x._v8_8, 6 * sizeof(short)));
                        case 3:  return new short16(Xse.bslli_si128(x._v8_0, 3 * sizeof(short)), Xse.alignr_epi8(x._v8_0, x._v8_8, 5 * sizeof(short)));
                        case 4:  return new short16(Xse.bslli_si128(x._v8_0, 4 * sizeof(short)), Xse.alignr_epi8(x._v8_0, x._v8_8, 4 * sizeof(short)));
                        case 5:  return new short16(Xse.bslli_si128(x._v8_0, 5 * sizeof(short)), Xse.alignr_epi8(x._v8_0, x._v8_8, 3 * sizeof(short)));
                        case 6:  return new short16(Xse.bslli_si128(x._v8_0, 6 * sizeof(short)), Xse.alignr_epi8(x._v8_0, x._v8_8, 2 * sizeof(short)));
                        case 7:  return new short16(Xse.bslli_si128(x._v8_0, 7 * sizeof(short)), Xse.alignr_epi8(x._v8_0, x._v8_8, 1 * sizeof(short)));
                        case 8:  return new short16(Xse.setzero_si128(), x._v8_0);
                        case 9:  return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 1 * sizeof(short)));
                        case 10: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 2 * sizeof(short)));
                        case 11: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 3 * sizeof(short)));
                        case 12: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 4 * sizeof(short)));
                        case 13: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 5 * sizeof(short)));
                        case 14: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 6 * sizeof(short)));
                        case 15: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 7 * sizeof(short)));

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = ZERO;
                    stack[1] = ZERO;
                    stack[2] = x.v8_0;
                    stack[3] = x.v8_8;

                    v128* address = (v128*)((byte*)stack + (2 * sizeof(v128) - (((uint)n % 16) * sizeof(short))));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new short16(lo, hi);
                }
            }
            else if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new short16(Xse.bslli_si128(x._v8_0, 1 * sizeof(short)),
                                                    Xse.or_si128(Xse.bsrli_si128(x._v8_0, 7 * sizeof(short)), Xse.bslli_si128(x._v8_8, 1 * sizeof(short))));
                        case 2:  return new short16(Xse.bslli_si128(x._v8_0, 2 * sizeof(short)),
                                                    Xse.or_si128(Xse.bsrli_si128(x._v8_0, 6 * sizeof(short)), Xse.bslli_si128(x._v8_8, 2 * sizeof(short))));
                        case 3:  return new short16(Xse.bslli_si128(x._v8_0, 3 * sizeof(short)),
                                                    Xse.or_si128(Xse.bsrli_si128(x._v8_0, 5 * sizeof(short)), Xse.bslli_si128(x._v8_8, 3 * sizeof(short))));
                        case 4:  return new short16(Xse.bslli_si128(x._v8_0, 4 * sizeof(short)),
                                                    Xse.or_si128(Xse.bsrli_si128(x._v8_0, 4 * sizeof(short)), Xse.bslli_si128(x._v8_8, 4 * sizeof(short))));
                        case 5:  return new short16(Xse.bslli_si128(x._v8_0, 5 * sizeof(short)),
                                                    Xse.or_si128(Xse.bsrli_si128(x._v8_0, 3 * sizeof(short)), Xse.bslli_si128(x._v8_8, 5 * sizeof(short))));
                        case 6:  return new short16(Xse.bslli_si128(x._v8_0, 6 * sizeof(short)),
                                                    Xse.or_si128(Xse.bsrli_si128(x._v8_0, 2 * sizeof(short)), Xse.bslli_si128(x._v8_8, 6 * sizeof(short))));
                        case 7:  return new short16(Xse.bslli_si128(x._v8_0, 7 * sizeof(short)),
                                                    Xse.or_si128(Xse.bsrli_si128(x._v8_0, 1 * sizeof(short)), Xse.bslli_si128(x._v8_8, 7 * sizeof(short))));
                        case 8:  return new short16(Xse.setzero_si128(), x._v8_0);
                        case 9:  return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 1 * sizeof(short)));
                        case 10: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 2 * sizeof(short)));
                        case 11: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 3 * sizeof(short)));
                        case 12: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 4 * sizeof(short)));
                        case 13: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 5 * sizeof(short)));
                        case 14: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 6 * sizeof(short)));
                        case 15: return new short16(Xse.setzero_si128(), Xse.bslli_si128(x._v8_0, 7 * sizeof(short)));

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = ZERO;
                    stack[1] = ZERO;
                    stack[2] = x.v8_0;
                    stack[3] = x.v8_8;

                    v128* address = (v128*)((byte*)stack + (2 * sizeof(v128) - (((uint)n % 16) * sizeof(short))));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new short16(lo, hi);
                }
            }
            else
            {
                switch (n)
                {
                    case 1:  return new short16(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 2:  return new short16(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 3:  return new short16(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 4:  return new short16(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 5:  return new short16(0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 6:  return new short16(0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 7:  return new short16(0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 8:  return new short16(0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 9:  return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 10: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 11: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 12: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 13: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 14: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 15: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vshl(ushort2 x, int n)
        {
            return (ushort2)vshl((short2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vshl(ushort3 x, int n)
        {
            return (ushort3)vshl((short3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vshl(ushort4 x, int n)
        {
            return (ushort4)vshl((short4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort8"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vshl(ushort8 x, int n)
        {
            return (ushort8)vshl((short8)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort16"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 vshl(ushort16 x, int n)
        {
            return (ushort16)vshl((short16)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.long2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vshl(long2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bslli_si128(x, n * sizeof(long));
            }
            else
            {
                switch (n)
                {
                    case 1: return new long2(0, x.x);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.long3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vshl(long3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(3,   1, 0, 3));
                    case 2: return Avx2.mm256_permute2x128_si256(Avx.mm256_setzero_si256(), x, Sse.SHUFFLE(0, 2, 0, 0));

                    default: return x;
                }
            }
            else if (Architecture.IsSIMDSupported)
            {
                switch (n)
                {
                    case 1:  return new long3(Xse.bslli_si128(x._xy, 1 * sizeof(long)), x.y);
                    case 2:  return new long3(Xse.setzero_si128(), x.x);

                    default: return x;
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new long3(0, x.x, x.y);
                    case 2: return new long3(0, 0, x.x);

                    default: return x;
                }
            }

        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.long4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static long4 vshl(long4 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bslli_si256(x, sizeof(long) * n);
            }
            else if (Architecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new long4(Xse.bslli_si128(x._xy, 1 * sizeof(long)), Xse.alignr_epi8(x._xy, x._zw, 1 * sizeof(long)));
                        case 2:  return new long4(Xse.setzero_si128(), x._xy);
                        case 3:  return new long4(Xse.setzero_si128(), Xse.bslli_si128(x._xy, 1 * sizeof(long)));

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = ZERO;
                    stack[1] = ZERO;
                    stack[2] = x.xy;
                    stack[3] = x.zw;

                    v128* address = (v128*)((byte*)stack + (2 * sizeof(v128) - (((uint)n % 4) * sizeof(long))));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new long4(lo, hi);
                }
            }
            else if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1: return new long4(Xse.bslli_si128(x._xy, 1 * sizeof(long)), Xse.blendv_si128(Xse.bsrli_si128(x._xy, 1 * sizeof(long)), Xse.bslli_si128(x._zw, 1 * sizeof(long)), new long2(0, -1)));
                        case 2: return new long4(Xse.setzero_si128(), x._xy);
                        case 3: return new long4(Xse.setzero_si128(), Xse.bslli_si128(x._xy, 1 * sizeof(long)));

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = ZERO;
                    stack[1] = ZERO;
                    stack[2] = x.xy;
                    stack[3] = x.zw;

                    v128* address = (v128*)((byte*)stack + (2 * sizeof(v128) - (((uint)n % 4) * sizeof(long))));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new long4(lo, hi);
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new long4(0, x.x, x.y, x.z);
                    case 2: return new long4(0, 0, x.x, x.y);
                    case 3: return new long4(0, 0, 0, x.x);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ulong2"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vshl(ulong2 x, int n)
        {
            return (ulong2)vshl((long2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ulong3"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vshl(ulong3 x, int n)
        {
            return (ulong3)vshl((long3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ulong4"/> left by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vshl(ulong4 x, int n)
        {
            return (ulong4)vshl((long4)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="bool2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 vshr(bool2 x, int n)
        {
            return tobool(vshr(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="bool3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 vshr(bool3 x, int n)
        {
            return tobool(vshr(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="bool4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 vshr(bool4 x, int n)
        {
            return tobool(vshr(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.bool8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 vshr(bool8 x, int n)
        {
            return tobool(vshr(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.bool16"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 vshr(bool16 x, int n)
        {
            return tobool(vshr(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.bool32"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 31], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 vshr(bool32 x, int n)
        {
            return tobool(vshr(tobyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="int2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vshr(int2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.bsrli_si128(Xse.bslli_si128(RegisterConversion.ToV128(x), 2 * sizeof(int)), (2 + n) * sizeof(int)));
            }
            else
            {
                switch (n)
                {
                    case 1: return new int2(x.y, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="int3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vshr(int3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.bsrli_si128(Xse.bslli_si128(RegisterConversion.ToV128(x), 1 * sizeof(int)), (1 + n) * sizeof(int)));
            }
            else
            {
                switch (n)
                {
                    case 1: return new int3(x.y, x.z, 0);
                    case 2: return new int3(x.z,   0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="int4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int4 vshr(int4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.bsrli_si128(RegisterConversion.ToV128(x), n * sizeof(int)));
            }
            else
            {
                switch (n)
                {
                    case 1: return new int4(x.y, x.z, x.w, 0);
                    case 2: return new int4(x.z, x.w,   0, 0);
                    case 3: return new int4(x.w,   0,   0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.int8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int8 vshr(int8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bsrli_si256(x, sizeof(int) * n);
            }
            else if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:
                        {
                            v128 hi = Xse.bsrli_si128(RegisterConversion.ToV128(x._v4_4), 1 * sizeof(int));

                            return new int8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX), RegisterConversion.ToInt4(hi));
                        }
                        case 2:
                        {
                            v128 hi = Xse.bsrli_si128(RegisterConversion.ToV128(x._v4_4), 2 * sizeof(int));

                            return new int8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY), RegisterConversion.ToInt4(hi));
                        }
                        case 3:
                        {
                            v128 hi = Xse.bsrli_si128(RegisterConversion.ToV128(x._v4_4), 3 * sizeof(int));

                            return new int8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ), RegisterConversion.ToInt4(hi));
                        }

                        case 4: return new int8(x._v4_4, int4.zero);

                        case 5:
                        {
                            v128 lo = Xse.bsrli_si128(RegisterConversion.ToV128(x._v4_4), 1 * sizeof(int));

                            return new int8(RegisterConversion.ToInt4(lo), int4.zero);
                        }
                        case 6:
                        {
                            v128 lo = Xse.bsrli_si128(RegisterConversion.ToV128(x._v4_4), 2 * sizeof(int));

                            return new int8(RegisterConversion.ToInt4(lo), int4.zero);
                        }
                        case 7:
                        {
                            v128 lo = Xse.bsrli_si128(RegisterConversion.ToV128(x._v4_4), 3 * sizeof(int));

                            return new int8(RegisterConversion.ToInt4(lo), int4.zero);
                        }

                        default: { v128 zero = Xse.setzero_si128(); return new int8(RegisterConversion.ToInt4(zero), RegisterConversion.ToInt4(zero)); }
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = RegisterConversion.ToV128(x.v4_0);
                    stack[1] = RegisterConversion.ToV128(x.v4_4);
                    stack[2] = ZERO;
                    stack[3] = ZERO;

                    v128* address = (v128*)((byte*)stack + (((uint)n % 8) * sizeof(int)));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new int8(RegisterConversion.ToInt4(lo), RegisterConversion.ToInt4(hi));
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new int8(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0);
                    case 2: return new int8(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0);
                    case 3: return new int8(x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0, 0);
                    case 4: return new int8(x.x4, x.x5, x.x6, x.x7, 0, 0, 0, 0);
                    case 5: return new int8(x.x5, x.x6, x.x7, 0, 0, 0, 0, 0);
                    case 6: return new int8(x.x6, x.x7, 0, 0, 0, 0, 0, 0);
                    case 7: return new int8(x.x7, 0, 0, 0, 0, 0, 0, 0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="uint2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vshr(uint2 x, int n)
        {
            return (uint2)vshr((int2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="uint3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vshr(uint3 x, int n)
        {
            return (uint3)vshr((int3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="uint4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vshr(uint4 x, int n)
        {
            return (uint4)vshr((int4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.uint8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vshr(uint8 x, int n)
        {
            return (uint8)vshr((int8)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.quarter2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 vshr(quarter2 x, int n)
        {
            return asquarter(vshr(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.quarter4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 vshr(quarter3 x, int n)
        {
            return asquarter(vshr(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.quarter4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 vshr(quarter4 x, int n)
        {
            return asquarter(vshr(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.quarter8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 vshr(quarter8 x, int n)
        {
            return asquarter(vshr(asbyte(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="half2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 vshr(half2 x, int n)
        {
            return ashalf(vshr(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="half4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 vshr(half3 x, int n)
        {
            return ashalf(vshr(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="half4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 vshr(half4 x, int n)
        {
            return ashalf(vshr(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.half8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 vshr(half8 x, int n)
        {
            return ashalf(vshr(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="float2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vshr(float2 x, int n)
        {
            return math.asfloat(vshr(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="float3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vshr(float3 x, int n)
        {
            return math.asfloat(vshr(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="float4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 vshr(float4 x, int n)
        {
            return math.asfloat(vshr(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.float8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 vshr(float8 x, int n)
        {
            return asfloat(vshr(asint(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="double2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vshr(double2 x, int n)
        {
            return asdouble(vshr(aslong(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="double3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vshr(double3 x, int n)
        {
            return asdouble(vshr(aslong(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="double4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 vshr(double4 x, int n)
        {
            return asdouble(vshr(aslong(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vshr(byte2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrli_si128(Xse.bslli_si128(x, 14 * sizeof(byte)), (14 + n) * sizeof(byte));
            }
            else
            {
                switch (n)
                {
                    case 1: return new byte2(x.y, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vshr(byte3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrli_si128(Xse.bslli_si128(x, 13 * sizeof(byte)), (13 + n) * sizeof(byte));
            }
            else
            {
                switch (n)
                {
                    case 1: return new byte3(x.y, x.z, 0);
                    case 2: return new byte3(x.z, 0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte4 vshr(byte4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    return Xse.bsrli_si128(Xse.bslli_si128(x, 12 * sizeof(byte)), (12 + n) * sizeof(byte));
                }
                else
                {
                    return Xse.cvtsi32_si128((int)(((v128)x).UInt0 >> n * 8));
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new byte4(x.y, x.z, x.w, 0);
                    case 2: return new byte4(x.z, x.w, 0, 0);
                    case 3: return new byte4(x.w, 0, 0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte8 vshr(byte8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    return Xse.bsrli_si128(Xse.bslli_si128(x, 8 * sizeof(byte)), (8 + n) * sizeof(byte));
                }
                else
                {
                    return Xse.cvtsi64x_si128((long)(((v128)x).ULong0 >> n * 8));
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new byte8(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0);
                    case 2: return new byte8(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0);
                    case 3: return new byte8(x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0, 0);
                    case 4: return new byte8(x.x4, x.x5, x.x6, x.x7, 0, 0, 0, 0);
                    case 5: return new byte8(x.x5, x.x6, x.x7, 0, 0, 0, 0, 0);
                    case 6: return new byte8(x.x6, x.x7, 0, 0, 0, 0, 0, 0);
                    case 7: return new byte8(x.x7, 0, 0, 0, 0, 0, 0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte16"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte16 vshr(byte16 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrli_si128(x, n * sizeof(byte));
            }
            else
            {
                switch (n)
                {
                    case 1:  return new byte16(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0);
                    case 2:  return new byte16(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0);
                    case 3:  return new byte16(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0);
                    case 4:  return new byte16(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0);
                    case 5:  return new byte16(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0);
                    case 6:  return new byte16(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0);
                    case 7:  return new byte16(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0);
                    case 8:  return new byte16(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 9:  return new byte16(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 10: return new byte16(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 11: return new byte16(x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 12: return new byte16(x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 13: return new byte16(x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 14: return new byte16(x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 15: return new byte16(x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.byte32"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 31], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte32 vshr(byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bsrli_si256(x, n);
            }
            else if (Architecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  1 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  1 * sizeof(byte)));
                        case 2:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  2 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  2 * sizeof(byte)));
                        case 3:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  3 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  3 * sizeof(byte)));
                        case 4:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  4 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  4 * sizeof(byte)));
                        case 5:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  5 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  5 * sizeof(byte)));
                        case 6:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  6 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  6 * sizeof(byte)));
                        case 7:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  7 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  7 * sizeof(byte)));
                        case 8:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  8 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  8 * sizeof(byte)));
                        case 9:  return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16,  9 * sizeof(byte)), Xse.bsrli_si128(x._v16_16,  9 * sizeof(byte)));
                        case 10: return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16, 10 * sizeof(byte)), Xse.bsrli_si128(x._v16_16, 10 * sizeof(byte)));
                        case 11: return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16, 11 * sizeof(byte)), Xse.bsrli_si128(x._v16_16, 11 * sizeof(byte)));
                        case 12: return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16, 12 * sizeof(byte)), Xse.bsrli_si128(x._v16_16, 12 * sizeof(byte)));
                        case 13: return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16, 13 * sizeof(byte)), Xse.bsrli_si128(x._v16_16, 13 * sizeof(byte)));
                        case 14: return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16, 14 * sizeof(byte)), Xse.bsrli_si128(x._v16_16, 14 * sizeof(byte)));
                        case 15: return new byte32(Xse.alignr_epi8(x._v16_0, x._v16_16, 15 * sizeof(byte)), Xse.bsrli_si128(x._v16_16, 15 * sizeof(byte)));
                        case 16: return new byte32(x._v16_16, Xse.setzero_si128());
                        case 17: return new byte32(Xse.bsrli_si128(x._v16_16,  1 * sizeof(byte)), Xse.setzero_si128());
                        case 18: return new byte32(Xse.bsrli_si128(x._v16_16,  2 * sizeof(byte)), Xse.setzero_si128());
                        case 19: return new byte32(Xse.bsrli_si128(x._v16_16,  3 * sizeof(byte)), Xse.setzero_si128());
                        case 20: return new byte32(Xse.bsrli_si128(x._v16_16,  4 * sizeof(byte)), Xse.setzero_si128());
                        case 21: return new byte32(Xse.bsrli_si128(x._v16_16,  5 * sizeof(byte)), Xse.setzero_si128());
                        case 22: return new byte32(Xse.bsrli_si128(x._v16_16,  6 * sizeof(byte)), Xse.setzero_si128());
                        case 23: return new byte32(Xse.bsrli_si128(x._v16_16,  7 * sizeof(byte)), Xse.setzero_si128());
                        case 24: return new byte32(Xse.bsrli_si128(x._v16_16,  8 * sizeof(byte)), Xse.setzero_si128());
                        case 25: return new byte32(Xse.bsrli_si128(x._v16_16,  9 * sizeof(byte)), Xse.setzero_si128());
                        case 26: return new byte32(Xse.bsrli_si128(x._v16_16, 10 * sizeof(byte)), Xse.setzero_si128());
                        case 27: return new byte32(Xse.bsrli_si128(x._v16_16, 11 * sizeof(byte)), Xse.setzero_si128());
                        case 28: return new byte32(Xse.bsrli_si128(x._v16_16, 12 * sizeof(byte)), Xse.setzero_si128());
                        case 29: return new byte32(Xse.bsrli_si128(x._v16_16, 13 * sizeof(byte)), Xse.setzero_si128());
                        case 30: return new byte32(Xse.bsrli_si128(x._v16_16, 14 * sizeof(byte)), Xse.setzero_si128());
                        case 31: return new byte32(Xse.bsrli_si128(x._v16_16, 15 * sizeof(byte)), Xse.setzero_si128());

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = x.v16_0;
                    stack[1] = x.v16_16;
                    stack[2] = ZERO;
                    stack[3] = ZERO;

                    v128* address = (v128*)((byte*)stack + (((uint)n % 32) * sizeof(byte)));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new byte32(lo, hi);
                }
            }
            else if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 1 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 1 * sizeof(byte)));
                        case 2:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 2 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 14 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 2 * sizeof(byte)));
                        case 3:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 3 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 3 * sizeof(byte)));
                        case 4:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 4 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 12 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 4 * sizeof(byte)));
                        case 5:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 5 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 5 * sizeof(byte)));
                        case 6:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 6 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 10 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 6 * sizeof(byte)));
                        case 7:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 7 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 7 * sizeof(byte)));
                        case 8:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 8 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 8 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 8 * sizeof(byte)));
                        case 9:  return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 9 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 7 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 9 * sizeof(byte)));
                        case 10: return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 10 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 6 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 10 * sizeof(byte)));
                        case 11: return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 11 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 5 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 11 * sizeof(byte)));
                        case 12: return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 12 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 4 * sizeof(byte)), new v128(0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 12 * sizeof(byte)));
                        case 13: return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 13 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 3 * sizeof(byte)), new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 13 * sizeof(byte)));
                        case 14: return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 14 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 2 * sizeof(byte)), new v128(0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 14 * sizeof(byte)));
                        case 15: return new byte32(Xse.blendv_si128(Xse.bsrli_si128(x._v16_0, 15 * sizeof(byte)), Xse.bslli_si128(x._v16_16, 1 * sizeof(byte)), new v128(0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                                   Xse.bsrli_si128(x._v16_16, 15 * sizeof(byte)));
                        case 16: return new byte32(x._v16_16, Xse.setzero_si128());
                        case 17: return new byte32(Xse.bsrli_si128(x._v16_16,  1 * sizeof(byte)), Xse.setzero_si128());
                        case 18: return new byte32(Xse.bsrli_si128(x._v16_16,  2 * sizeof(byte)), Xse.setzero_si128());
                        case 19: return new byte32(Xse.bsrli_si128(x._v16_16,  3 * sizeof(byte)), Xse.setzero_si128());
                        case 20: return new byte32(Xse.bsrli_si128(x._v16_16,  4 * sizeof(byte)), Xse.setzero_si128());
                        case 21: return new byte32(Xse.bsrli_si128(x._v16_16,  5 * sizeof(byte)), Xse.setzero_si128());
                        case 22: return new byte32(Xse.bsrli_si128(x._v16_16,  6 * sizeof(byte)), Xse.setzero_si128());
                        case 23: return new byte32(Xse.bsrli_si128(x._v16_16,  7 * sizeof(byte)), Xse.setzero_si128());
                        case 24: return new byte32(Xse.bsrli_si128(x._v16_16,  8 * sizeof(byte)), Xse.setzero_si128());
                        case 25: return new byte32(Xse.bsrli_si128(x._v16_16,  9 * sizeof(byte)), Xse.setzero_si128());
                        case 26: return new byte32(Xse.bsrli_si128(x._v16_16, 10 * sizeof(byte)), Xse.setzero_si128());
                        case 27: return new byte32(Xse.bsrli_si128(x._v16_16, 11 * sizeof(byte)), Xse.setzero_si128());
                        case 28: return new byte32(Xse.bsrli_si128(x._v16_16, 12 * sizeof(byte)), Xse.setzero_si128());
                        case 29: return new byte32(Xse.bsrli_si128(x._v16_16, 13 * sizeof(byte)), Xse.setzero_si128());
                        case 30: return new byte32(Xse.bsrli_si128(x._v16_16, 14 * sizeof(byte)), Xse.setzero_si128());
                        case 31: return new byte32(Xse.bsrli_si128(x._v16_16, 15 * sizeof(byte)), Xse.setzero_si128());

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = x.v16_0;
                    stack[1] = x.v16_16;
                    stack[2] = ZERO;
                    stack[3] = ZERO;

                    v128* address = (v128*)((byte*)stack + (((uint)n % 32) * sizeof(byte)));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new byte32(lo, hi);
                }
            }
            else
            {
                switch (n)
                {
                    case 1:  return new byte32(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0);
                    case 2:  return new byte32(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0);
                    case 3:  return new byte32(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0);
                    case 4:  return new byte32(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0);
                    case 5:  return new byte32(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0);
                    case 6:  return new byte32(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0);
                    case 7:  return new byte32(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0);
                    case 8:  return new byte32(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 9:  return new byte32(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 10: return new byte32(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 11: return new byte32(x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 12: return new byte32(x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 13: return new byte32(x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 14: return new byte32(x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 15: return new byte32(x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 16: return new byte32(x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 17: return new byte32(x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 18: return new byte32(x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 19: return new byte32(x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 20: return new byte32(x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 21: return new byte32(x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 22: return new byte32(x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 23: return new byte32(x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 24: return new byte32(x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 25: return new byte32(x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 26: return new byte32(x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 27: return new byte32(x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 28: return new byte32(x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 29: return new byte32(x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 30: return new byte32(x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 31: return new byte32(x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vshr(sbyte2 x, int n)
        {
            return (sbyte2)vshr((byte2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vshr(sbyte3 x, int n)
        {
            return (sbyte3)vshr((byte3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vshr(sbyte4 x, int n)
        {
            return (sbyte4)vshr((byte4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vshr(sbyte8 x, int n)
        {
            return (sbyte8)vshr((byte8)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte16"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vshr(sbyte16 x, int n)
        {
            return (sbyte16)vshr((byte16)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an <see cref="MaxMath.sbyte32"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 31], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 vshr(sbyte32 x, int n)
        {
            return (sbyte32)vshr((byte32)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vshr(short2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrli_si128(Xse.bslli_si128(x, 6 * sizeof(short)), (6 + n) * sizeof(short));
            }
            else
            {
                switch (n)
                {
                    case 1: return new short2(x.y, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vshr(short3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrli_si128(Xse.bslli_si128(x, 5 * sizeof(short)), (5 + n) * sizeof(short));
            }
            else
            {
                switch (n)
                {
                    case 1: return new short3(x.y, x.z, 0);
                    case 2: return new short3(x.z, 0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short4 vshr(short4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrli_si128(Xse.bslli_si128(x, 4 * sizeof(short)), (4 + n) * sizeof(short));
            }
            else
            {
                switch (n)
                {
                    case 1: return new short4(x.y, x.z, x.w, 0);
                    case 2: return new short4(x.z, x.w, 0, 0);
                    case 3: return new short4(x.w, 0, 0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short8 vshr(short8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrli_si128(x, n * sizeof(short));
            }
            else
            {
                switch (n)
                {
                    case 1: return new short8(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0);
                    case 2: return new short8(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0);
                    case 3: return new short8(x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0, 0);
                    case 4: return new short8(x.x4, x.x5, x.x6, x.x7, 0, 0, 0, 0);
                    case 5: return new short8(x.x5, x.x6, x.x7, 0, 0, 0, 0, 0);
                    case 6: return new short8(x.x6, x.x7, 0, 0, 0, 0, 0, 0);
                    case 7: return new short8(x.x7, 0, 0, 0, 0, 0, 0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.short16"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short16 vshr(short16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bsrli_si256(x, sizeof(short) * n);
            }
            else if (Architecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new short16(Xse.alignr_epi8(x._v8_0, x._v8_8,  1 * sizeof(short)), Xse.bsrli_si128(x._v8_8,  1 * sizeof(short)));
                        case 2:  return new short16(Xse.alignr_epi8(x._v8_0, x._v8_8,  2 * sizeof(short)), Xse.bsrli_si128(x._v8_8,  2 * sizeof(short)));
                        case 3:  return new short16(Xse.alignr_epi8(x._v8_0, x._v8_8,  3 * sizeof(short)), Xse.bsrli_si128(x._v8_8,  3 * sizeof(short)));
                        case 4:  return new short16(Xse.alignr_epi8(x._v8_0, x._v8_8,  4 * sizeof(short)), Xse.bsrli_si128(x._v8_8,  4 * sizeof(short)));
                        case 5:  return new short16(Xse.alignr_epi8(x._v8_0, x._v8_8,  5 * sizeof(short)), Xse.bsrli_si128(x._v8_8,  5 * sizeof(short)));
                        case 6:  return new short16(Xse.alignr_epi8(x._v8_0, x._v8_8,  6 * sizeof(short)), Xse.bsrli_si128(x._v8_8,  6 * sizeof(short)));
                        case 7:  return new short16(Xse.alignr_epi8(x._v8_0, x._v8_8,  7 * sizeof(short)), Xse.bsrli_si128(x._v8_8,  7 * sizeof(short)));
                        case 8:  return new short16(x._v8_8, Xse.setzero_si128());
                        case 9:  return new short16(Xse.bsrli_si128(x._v8_8,  1 * sizeof(short)), Xse.setzero_si128());
                        case 10: return new short16(Xse.bsrli_si128(x._v8_8,  2 * sizeof(short)), Xse.setzero_si128());
                        case 11: return new short16(Xse.bsrli_si128(x._v8_8,  3 * sizeof(short)), Xse.setzero_si128());
                        case 12: return new short16(Xse.bsrli_si128(x._v8_8,  4 * sizeof(short)), Xse.setzero_si128());
                        case 13: return new short16(Xse.bsrli_si128(x._v8_8,  5 * sizeof(short)), Xse.setzero_si128());
                        case 14: return new short16(Xse.bsrli_si128(x._v8_8,  6 * sizeof(short)), Xse.setzero_si128());
                        case 15: return new short16(Xse.bsrli_si128(x._v8_8,  7 * sizeof(short)), Xse.setzero_si128());

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = x.v8_0;
                    stack[1] = x.v8_8;
                    stack[2] = ZERO;
                    stack[3] = ZERO;

                    v128* address = (v128*)((byte*)stack + (((uint)n % 16) * sizeof(short)));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new short16(lo, hi);
                }
            }
            else if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1:  return new short16(Xse.blendv_si128(Xse.bsrli_si128(x._v8_0, 1 * sizeof(short)), Xse.bslli_si128(x._v8_8, 7 * sizeof(short)), new v128(0, 0, 0, 0, 0, 0, 0, -1)),
                                                    Xse.bsrli_si128(x._v8_8, 1 * sizeof(short)));
                        case 2:  return new short16(Xse.blendv_si128(Xse.bsrli_si128(x._v8_0, 2 * sizeof(short)), Xse.bslli_si128(x._v8_8, 6 * sizeof(short)), new v128(0, 0, 0, 0, 0, 0, -1, -1)),
                                                    Xse.bsrli_si128(x._v8_8, 2 * sizeof(short)));
                        case 3:  return new short16(Xse.blendv_si128(Xse.bsrli_si128(x._v8_0, 3 * sizeof(short)), Xse.bslli_si128(x._v8_8, 5 * sizeof(short)), new v128(0, 0, 0, 0, 0, -1, -1, -1)),
                                                    Xse.bsrli_si128(x._v8_8, 3 * sizeof(short)));
                        case 4:  return new short16(Xse.blendv_si128(Xse.bsrli_si128(x._v8_0, 4 * sizeof(short)), Xse.bslli_si128(x._v8_8, 4 * sizeof(short)), new v128(0, 0, 0, 0, -1, -1, -1, -1)),
                                                    Xse.bsrli_si128(x._v8_8, 4 * sizeof(short)));
                        case 5:  return new short16(Xse.blendv_si128(Xse.bsrli_si128(x._v8_0, 5 * sizeof(short)), Xse.bslli_si128(x._v8_8, 3 * sizeof(short)), new v128(0, 0, 0, -1, -1, -1, -1, -1)),
                                                    Xse.bsrli_si128(x._v8_8, 5 * sizeof(short)));
                        case 6:  return new short16(Xse.blendv_si128(Xse.bsrli_si128(x._v8_0, 6 * sizeof(short)), Xse.bslli_si128(x._v8_8, 2 * sizeof(short)), new v128(0, 0, -1, -1, -1, -1, -1, -1)),
                                                    Xse.bsrli_si128(x._v8_8, 6 * sizeof(short)));
                        case 7:  return new short16(Xse.blendv_si128(Xse.bsrli_si128(x._v8_0, 7 * sizeof(short)), Xse.bslli_si128(x._v8_8, 1 * sizeof(short)), new v128(0, -1, -1, -1, -1, -1, -1, -1)),
                                                    Xse.bsrli_si128(x._v8_8, 7 * sizeof(short)));
                        case 8:  return new short16(x._v8_8, Xse.setzero_si128());
                        case 9:  return new short16(Xse.bsrli_si128(x._v8_8,  1 * sizeof(short)), Xse.setzero_si128());
                        case 10: return new short16(Xse.bsrli_si128(x._v8_8,  2 * sizeof(short)), Xse.setzero_si128());
                        case 11: return new short16(Xse.bsrli_si128(x._v8_8,  3 * sizeof(short)), Xse.setzero_si128());
                        case 12: return new short16(Xse.bsrli_si128(x._v8_8,  4 * sizeof(short)), Xse.setzero_si128());
                        case 13: return new short16(Xse.bsrli_si128(x._v8_8,  5 * sizeof(short)), Xse.setzero_si128());
                        case 14: return new short16(Xse.bsrli_si128(x._v8_8,  6 * sizeof(short)), Xse.setzero_si128());
                        case 15: return new short16(Xse.bsrli_si128(x._v8_8,  7 * sizeof(short)), Xse.setzero_si128());

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = x.v8_0;
                    stack[1] = x.v8_8;
                    stack[2] = ZERO;
                    stack[3] = ZERO;

                    v128* address = (v128*)((byte*)stack + (((uint)n % 16) * sizeof(short)));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new short16(lo, hi);
                }
            }
            else
            {
                switch (n)
                {
                    case 1:  return new short16(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0);
                    case 2:  return new short16(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0);
                    case 3:  return new short16(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0);
                    case 4:  return new short16(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0);
                    case 5:  return new short16(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0);
                    case 6:  return new short16(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0);
                    case 7:  return new short16(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0);
                    case 8:  return new short16(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 9:  return new short16(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 10: return new short16(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 11: return new short16(x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 12: return new short16(x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 13: return new short16(x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 14: return new short16(x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 15: return new short16(x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vshr(ushort2 x, int n)
        {
            return (ushort2)vshr((short2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vshr(ushort3 x, int n)
        {
            return (ushort3)vshr((short3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vshr(ushort4 x, int n)
        {
            return (ushort4)vshr((short4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort8"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 7], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vshr(ushort8 x, int n)
        {
            return (ushort8)vshr((short8)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ushort16"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 15], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 vshr(ushort16 x, int n)
        {
            return (ushort16)vshr((short16)x, n);
        }



        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.long2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vshr(long2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrli_si128(x, n * sizeof(long));
            }
            else
            {
                switch (n)
                {
                    case 1: return new long2(x.y, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.long3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vshr(long3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(2, 0, 2, 1));
                    case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(1, 0, 0, 2));

                    default: return x;
                }
            }
            else if (Architecture.IsInsertExtractSupported)
            {
                switch (n)
                {
                    case 1: return new long3(Xse.insert_epi64(Xse.bsrli_si128(x._xy, 1 * sizeof(long)), (ulong)x.z, 1), 0);
                    case 2: return new long3(x.z, 0, 0);

                    default: return x;
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new long3(x.y, x.z, 0);
                    case 2: return new long3(x.z, 0, 0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.long4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static long4 vshr(long4 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bsrli_si256(x, sizeof(long) * n);
            }
            else if (Architecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1: return new long4(Xse.alignr_epi8(x._xy, x._zw, 1 * sizeof(long)), Xse.bsrli_si128(x._zw, 1 * sizeof(long)));
                        case 2: return new long4(x._zw, Xse.setzero_si128());
                        case 3: return new long4(Xse.bsrli_si128(x._zw, 1 * sizeof(long)), Xse.setzero_si128());

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = x.xy;
                    stack[1] = x.zw;
                    stack[2] = ZERO;
                    stack[3] = ZERO;

                    v128* address = (v128*)((byte*)stack + (((uint)n % 4) * sizeof(long)));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new long4(lo, hi);
                }
            }
            else if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch (n)
                    {
                        case 1: return new long4(Xse.blendv_si128(Xse.bsrli_si128(x._xy, 1 * sizeof(long)), Xse.bslli_si128(x._zw, 1 * sizeof(long)), new long2(0, -1)),
                                                 Xse.bsrli_si128(x._zw, 1 * sizeof(long)));
                        case 2: return new long4(x._zw, Xse.setzero_si128());
                        case 3: return new long4(Xse.bsrli_si128(x._zw, 1 * sizeof(long)), Xse.setzero_si128());

                        default: return x;
                    }
                }
                else
                {
                    v128 ZERO = Xse.setzero_si128();

                    v128* stack = stackalloc v128[4];

                    stack[0] = x.xy;
                    stack[1] = x.zw;
                    stack[2] = ZERO;
                    stack[3] = ZERO;

                    v128* address = (v128*)((byte*)stack + (((uint)n % 4) * sizeof(long)));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + 1);

                    return new long4(lo, hi);
                }
            }
            else
            {
                switch (n)
                {
                    case 1: return new long4(x.y, x.z, x.w, 0);
                    case 2: return new long4(x.z, x.w, 0, 0);
                    case 3: return new long4(x.w, 0, 0, 0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ulong2"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 1], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vshr(ulong2 x, int n)
        {
            return (ulong2)vshr((long2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ulong3"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 2], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vshr(ulong3 x, int n)
        {
            return (ulong3)vshr((long3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a <see cref="MaxMath.ulong4"/> right by <paramref name="n"/> while shifting in zeros. If <paramref name="n"/> is not in the interval [0, 3], the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vshr(ulong4 x, int n)
        {
            return (ulong4)vshr((long4)x, n);
        }
    }
}