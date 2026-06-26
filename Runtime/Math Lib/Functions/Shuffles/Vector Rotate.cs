using System.Runtime.CompilerServices;
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
            public static v128 brol_si128(v128 a, int imm8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        if (BurstArchitecture.IsTableLookupSupported)
                        {
                            switch ((uint)imm8 % 16)
                            {
                                case 1:  return alignr_epi8(a, a, 15 * sizeof(byte));
                                case 2:  return alignr_epi8(a, a, 14 * sizeof(byte));
                                case 3:  return alignr_epi8(a, a, 13 * sizeof(byte));
                                case 4:  return shuffle_epi32(a, Sse.SHUFFLE(2, 1, 0, 3));
                                case 5:  return alignr_epi8(a, a, 11 * sizeof(byte));
                                case 6:  return alignr_epi8(a, a, 10 * sizeof(byte));
                                case 7:  return alignr_epi8(a, a,  9 * sizeof(byte));
                                case 8:  return shuffle_epi32(a, Sse.SHUFFLE(1, 0, 3, 2));
                                case 9:  return alignr_epi8(a, a,  7 * sizeof(byte));
                                case 10: return alignr_epi8(a, a,  6 * sizeof(byte));
                                case 11: return alignr_epi8(a, a,  5 * sizeof(byte));
                                case 12: return shuffle_epi32(a, Sse.SHUFFLE(0, 3, 2, 1));
                                case 13: return alignr_epi8(a, a,  3 * sizeof(byte));
                                case 14: return alignr_epi8(a, a,  2 * sizeof(byte));
                                case 15: return alignr_epi8(a, a,  1 * sizeof(byte));

                                default: return a;
                            }
                        }
                        else
                        {
                            switch ((uint)imm8 % 16)
                            {
                                case 1:  return or_si128(bsrli_si128(a, 15 * sizeof(byte)), bslli_si128(a,  1 * sizeof(byte)));
                                case 2:  return or_si128(bsrli_si128(a, 14 * sizeof(byte)), bslli_si128(a,  2 * sizeof(byte)));
                                case 3:  return or_si128(bsrli_si128(a, 13 * sizeof(byte)), bslli_si128(a,  3 * sizeof(byte)));
                                case 4:  return shuffle_epi32(a, Sse.SHUFFLE(2, 1, 0, 3));
                                case 5:  return or_si128(bsrli_si128(a, 11 * sizeof(byte)), bslli_si128(a,  5 * sizeof(byte)));
                                case 6:  return or_si128(bsrli_si128(a, 10 * sizeof(byte)), bslli_si128(a,  6 * sizeof(byte)));
                                case 7:  return or_si128(bsrli_si128(a,  9 * sizeof(byte)), bslli_si128(a,  7 * sizeof(byte)));
                                case 8:  return shuffle_epi32(a, Sse.SHUFFLE(1, 0, 3, 2));
                                case 9:  return or_si128(bsrli_si128(a,  7 * sizeof(byte)), bslli_si128(a,  9 * sizeof(byte)));
                                case 10: return or_si128(bsrli_si128(a,  6 * sizeof(byte)), bslli_si128(a, 10 * sizeof(byte)));
                                case 11: return or_si128(bsrli_si128(a,  5 * sizeof(byte)), bslli_si128(a, 11 * sizeof(byte)));
                                case 12: return shuffle_epi32(a, Sse.SHUFFLE(0, 3, 2, 1));
                                case 13: return or_si128(bsrli_si128(a,  3 * sizeof(byte)), bslli_si128(a, 13 * sizeof(byte)));
                                case 14: return or_si128(bsrli_si128(a,  2 * sizeof(byte)), bslli_si128(a, 14 * sizeof(byte)));
                                case 15: return or_si128(bsrli_si128(a,  1 * sizeof(byte)), bslli_si128(a, 15 * sizeof(byte)));

                                default: return a;
                            }
                        }
                    }

                    v128* stack = stackalloc v128[2];
                    stack[0] = a;
                    stack[1] = a;

                    return loadu_si128((byte*)stack + (16 - ((uint)imm8 % 16)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_brol_si128(v256 a, int imm8)
            {
                if (Avx.IsAvxSupported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            switch ((uint)imm8 % 16)
                            {
                                case 1:  return Avx2.mm256_alignr_epi8(a, a, 15 * sizeof(byte));
                                case 2:  return Avx2.mm256_alignr_epi8(a, a, 14 * sizeof(byte));
                                case 3:  return Avx2.mm256_alignr_epi8(a, a, 13 * sizeof(byte));
                                case 4:  return Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(2, 1, 0, 3));
                                case 5:  return Avx2.mm256_alignr_epi8(a, a, 11 * sizeof(byte));
                                case 6:  return Avx2.mm256_alignr_epi8(a, a, 10 * sizeof(byte));
                                case 7:  return Avx2.mm256_alignr_epi8(a, a,  9 * sizeof(byte));
                                case 8:  return Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(1, 0, 3, 2));
                                case 9:  return Avx2.mm256_alignr_epi8(a, a,  7 * sizeof(byte));
                                case 10: return Avx2.mm256_alignr_epi8(a, a,  6 * sizeof(byte));
                                case 11: return Avx2.mm256_alignr_epi8(a, a,  5 * sizeof(byte));
                                case 12: return Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(0, 3, 2, 1));
                                case 13: return Avx2.mm256_alignr_epi8(a, a,  3 * sizeof(byte));
                                case 14: return Avx2.mm256_alignr_epi8(a, a,  2 * sizeof(byte));
                                case 15: return Avx2.mm256_alignr_epi8(a, a,  1 * sizeof(byte));

                                default: return a;
                            }
                        }
                        else
                        {
                            switch ((uint)imm8 % 16)
                            {
                                case 0:  return a;
                                case 4:  return Avx.mm256_shuffle_ps(a, a, Sse.SHUFFLE(2, 1, 0, 3));
                                case 8:  return Avx.mm256_shuffle_ps(a, a, Sse.SHUFFLE(1, 0, 3, 2));
                                case 12: return Avx.mm256_shuffle_ps(a, a, Sse.SHUFFLE(0, 3, 2, 1));

                                default: break;
                            }
                        }
                    }

                    return new v256(brol_si128(Avx.mm256_castsi256_si128(a), imm8), brol_si128(Avx.mm256_extractf128_ps(a, 1), imm8));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v256 mm256_brol_si256(v256 a, int imm8)
            {
                if (Avx.IsAvxSupported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            switch ((uint)imm8 % 32)
                            {
                                case 1:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a, 15 * sizeof(byte));
                                case 2:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a, 14 * sizeof(byte));
                                case 3:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a, 13 * sizeof(byte));
                                case 4:  return Avx2.mm256_permutevar8x32_epi32(a, new v256(7, 0, 1, 2, 3, 4, 5, 6));
                                case 5:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a, 11 * sizeof(byte));
                                case 6:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a, 10 * sizeof(byte));
                                case 7:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a,  9 * sizeof(byte));
                                case 8:  return Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(2, 1, 0, 3));
                                case 9:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a,  7 * sizeof(byte));
                                case 10: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a,  6 * sizeof(byte));
                                case 11: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a,  5 * sizeof(byte));
                                case 12: return Avx2.mm256_permutevar8x32_epi32(a, new v256(5, 6, 7, 0, 1, 2, 3, 4));
                                case 13: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a,  3 * sizeof(byte));
                                case 14: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a,  2 * sizeof(byte));
                                case 15: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), a,  1 * sizeof(byte));
                                case 16: return Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2));
                                case 17: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), 15 * sizeof(byte));
                                case 18: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), 14 * sizeof(byte));
                                case 19: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), 13 * sizeof(byte));
                                case 20: return Avx2.mm256_permutevar8x32_epi32(a, new v256(3, 4, 5, 6, 7, 0, 1, 2));
                                case 21: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), 11 * sizeof(byte));
                                case 22: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)), 10 * sizeof(byte));
                                case 23: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)),  9 * sizeof(byte));
                                case 24: return Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(0, 3, 2, 1));
                                case 25: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)),  7 * sizeof(byte));
                                case 26: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)),  6 * sizeof(byte));
                                case 27: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)),  5 * sizeof(byte));
                                case 28: return Avx2.mm256_permutevar8x32_epi32(a, new v256(1, 2, 3, 4, 5, 6, 7, 0));
                                case 29: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)),  3 * sizeof(byte));
                                case 30: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)),  2 * sizeof(byte));
                                case 31: return Avx2.mm256_alignr_epi8(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 3, 2)),  1 * sizeof(byte));

                                default: return a;
                            }
                        }
                        else
                        {
                            v256 aLaneSwap = Avx.mm256_permute2f128_ps(a, a, 0b01);

                            switch ((uint)imm8 % 32)
                            {
                                case 0:  return a;
                                case 4:  return Avx.mm256_blend_ps(Avx.mm256_permute_ps(a, Sse.SHUFFLE(2, 1, 0, 3)), Avx.mm256_permute_ps(aLaneSwap, Sse.SHUFFLE(2, 1, 0, 3)), 0b0001_0001);
                                case 8:  return Avx.mm256_shuffle_ps(aLaneSwap, a,         Sse.SHUFFLE(1, 0, 3, 2));
                                case 12: return Avx.mm256_blend_ps(Avx.mm256_permute_ps(a, Sse.SHUFFLE(0, 3, 2, 1)), Avx.mm256_permute_ps(aLaneSwap, Sse.SHUFFLE(0, 3, 2, 1)), 0b0111_0111);
                                case 16: return aLaneSwap;
                                case 20: return Avx.mm256_blend_ps(Avx.mm256_permute_ps(aLaneSwap, Sse.SHUFFLE(2, 1, 0, 3)), Avx.mm256_permute_ps(a, Sse.SHUFFLE(2, 1, 0, 3)), 0b0001_0001);
                                case 24: return Avx.mm256_shuffle_ps(a, aLaneSwap,                 Sse.SHUFFLE(1, 0, 3, 2));
                                case 28: return Avx.mm256_blend_ps(Avx.mm256_permute_ps(aLaneSwap, Sse.SHUFFLE(0, 3, 2, 1)), Avx.mm256_permute_ps(a, Sse.SHUFFLE(0, 3, 2, 1)), 0b0111_0111);

                                default: break;
                            }
                        }
                    }

                    v256* stack = stackalloc v256[2];
                    stack[0] = a;
                    stack[1] = a;

                    return Avx.mm256_loadu_si256((byte*)stack + (32 - ((uint)imm8 % 32)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bror_si128(v128 a, int imm8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return brol_si128(a, 16 - imm8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bror_si128(v256 a, int imm8)
            {
                if (Avx.IsAvxSupported)
                {
                    return mm256_brol_si128(a, 16 - imm8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bror_si256(v256 a, int imm8)
            {
                if (Avx.IsAvxSupported)
                {
                    return mm256_brol_si256(a, 32 - imm8);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 vror(bool2 x, int n)
        {
            return tobool(vror(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 vror(bool3 x, int n)
        {
            return tobool(vror(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 vror(bool4 x, int n)
        {
            return tobool(vror(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 vror(bool8 x, int n)
        {
            return tobool(vror(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 vror(bool16 x, int n)
        {
            return tobool(vror(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool32"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 vror(bool32 x, int n)
        {
            return tobool(vror(tobyte(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vror(byte2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vror(byte3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 vror(byte4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Sse2.IsSse2Supported)
            {
                return Xse.cvtsi32_si128(ror(((v128)x).SInt0, n * 8));
            }

            switch ((uint)n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 vror(byte8 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Sse2.IsSse2Supported)
            {
                return Xse.cvtsi64x_si128(ror(((v128)x).SLong0, n * 8));
            }

            switch ((uint)n % 8)
            {
                case 1: return vrol(x, 7);
                case 2: return vrol(x, 6);
                case 3: return vrol(x, 5);
                case 4: return vrol(x, 4);
                case 5: return vrol(x, 3);
                case 6: return vrol(x, 2);
                case 7: return vrol(x, 1);

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte16 vror(byte16 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[2];
                stack[0] = x;
                stack[1] = x;

                return Xse.loadu_si128((byte*)stack + ((uint)n % 16));
            }

            switch ((uint)n % 16)
            {
                case 1:  return vrol(x, 15);
                case 2:  return vrol(x, 14);
                case 3:  return vrol(x, 13);
                case 4:  return vrol(x, 12);
                case 5:  return vrol(x, 11);
                case 6:  return vrol(x, 10);
                case 7:  return vrol(x,  9);
                case 8:  return vrol(x,  8);
                case 9:  return vrol(x,  7);
                case 10: return vrol(x,  6);
                case 11: return vrol(x,  5);
                case 12: return vrol(x,  4);
                case 13: return vrol(x,  3);
                case 14: return vrol(x,  2);
                case 15: return vrol(x,  1);

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte32"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte32 vror(byte32 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Avx.IsAvxSupported)
            {
                v256* stack = stackalloc v256[2];
                stack[0] = x;
                stack[1] = x;

                return Avx.mm256_loadu_si256((byte*)stack + ((uint)n % 32));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[4];
                stack[0] = x.__x0;
                stack[1] = x.__x16;
                stack[2] = x.__x0;
                stack[3] = x.__x16;

                byte* address = (byte*)stack + ((uint)n % 32);

                v128 lo = Xse.loadu_si128(address);
                v128 hi = Xse.loadu_si128(address + sizeof(v128));

                return new byte32(lo, hi);
            }

            switch ((uint)n % 32)
            {
                case 1:  return vrol(x, 31);
                case 2:  return vrol(x, 30);
                case 3:  return vrol(x, 29);
                case 4:  return vrol(x, 28);
                case 5:  return vrol(x, 27);
                case 6:  return vrol(x, 26);
                case 7:  return vrol(x, 25);
                case 8:  return vrol(x, 24);
                case 9:  return vrol(x, 23);
                case 10: return vrol(x, 22);
                case 11: return vrol(x, 21);
                case 12: return vrol(x, 20);
                case 13: return vrol(x, 19);
                case 14: return vrol(x, 18);
                case 15: return vrol(x, 17);
                case 16: return vrol(x, 16);
                case 17: return vrol(x, 15);
                case 18: return vrol(x, 14);
                case 19: return vrol(x, 13);
                case 20: return vrol(x, 12);
                case 21: return vrol(x, 11);
                case 22: return vrol(x, 10);
                case 23: return vrol(x,  9);
                case 24: return vrol(x,  8);
                case 25: return vrol(x,  7);
                case 26: return vrol(x,  6);
                case 27: return vrol(x,  5);
                case 28: return vrol(x,  4);
                case 29: return vrol(x,  3);
                case 30: return vrol(x,  2);
                case 31: return vrol(x,  1);

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vror(sbyte2 x, int n)
        {
            return (sbyte2)vror((byte2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vror(sbyte3 x, int n)
        {
            return (sbyte3)vror((byte3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vror(sbyte4 x, int n)
        {
            return (sbyte4)vror((byte4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vror(sbyte8 x, int n)
        {
            return (sbyte8)vror((byte8)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vror(sbyte16 x, int n)
        {
            return (sbyte16)vror((byte16)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte32"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 vror(sbyte32 x, int n)
        {
            return (sbyte32)vror((byte32)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vror(short2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vror(short3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 vror(short4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Sse2.IsSse2Supported)
            {
                return Xse.cvtsi64x_si128(ror(((v128)x).SLong0, n * 16));
            }

            switch ((uint)n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short8 vror(short8 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128* stack = stackalloc v128[2];
                stack[0] = x;
                stack[1] = x;

                return Xse.loadu_si128((byte*)stack + (((uint)n % 8) * sizeof(short)));
            }

            switch ((uint)n % 8)
            {
                case 1: return vrol(x, 7);
                case 2: return vrol(x, 6);
                case 3: return vrol(x, 5);
                case 4: return vrol(x, 4);
                case 5: return vrol(x, 3);
                case 6: return vrol(x, 2);
                case 7: return vrol(x, 1);

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short16 vror(short16 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Avx.IsAvxSupported)
            {
                v256* stack = stackalloc v256[2];
                stack[0] = x;
                stack[1] = x;

                return Avx.mm256_loadu_si256((byte*)stack + (((uint)n % 16) * sizeof(short)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[4];
                stack[0] = x.__x0;
                stack[1] = x.__x8;
                stack[2] = x.__x0;
                stack[3] = x.__x8;

                byte* address = (byte*)stack + (((uint)n % 16) * sizeof(short));

                v128 lo = Xse.loadu_si128(address);
                v128 hi = Xse.loadu_si128(address + sizeof(v128));

                return new short16(lo, hi);
            }

            switch ((uint)n % 16)
            {
                case 1:  return vrol(x, 15);
                case 2:  return vrol(x, 14);
                case 3:  return vrol(x, 13);
                case 4:  return vrol(x, 12);
                case 5:  return vrol(x, 11);
                case 6:  return vrol(x, 10);
                case 7:  return vrol(x, 9);
                case 8:  return vrol(x, 8);
                case 9:  return vrol(x, 7);
                case 10: return vrol(x, 6);
                case 11: return vrol(x, 5);
                case 12: return vrol(x, 4);
                case 13: return vrol(x, 3);
                case 14: return vrol(x, 2);
                case 15: return vrol(x, 1);

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vror(ushort2 x, int n)
        {
            return (ushort2)vror((short2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vror(ushort3 x, int n)
        {
            return (ushort3)vror((short3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vror(ushort4 x, int n)
        {
            return (ushort4)vror((short4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vror(ushort8 x, int n)
        {
            return (ushort8)vror((short8)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 vror(ushort16 x, int n)
        {
            return (ushort16)vror((short16)x, n);
        }


        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.int2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vror(int2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.int3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vror(int3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.int4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int4 vror(int4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[2];
                stack[0] = x;
                stack[1] = x;

                return Xse.loadu_si128((byte*)stack + (((uint)n % 4) * sizeof(int)));
            }

            switch ((uint)n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.int8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int8 vror(int8 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Avx.IsAvxSupported)
            {
                v256* stack = stackalloc v256[2];
                stack[0] = x;
                stack[1] = x;

                return Avx.mm256_loadu_si256((byte*)stack + (((uint)n % 8) * sizeof(int)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[4];
                stack[0] = x.__x0;
                stack[1] = x.__x4;
                stack[2] = x.__x0;
                stack[3] = x.__x4;

                byte* address = (byte*)stack + (((uint)n % 8) * sizeof(int));

                v128 lo = Xse.loadu_si128(address);
                v128 hi = Xse.loadu_si128(address + sizeof(v128));

                return new int8(lo, hi);
            }

            switch ((uint)n % 8)
            {
                case 1: return vrol(x, 7);
                case 2: return vrol(x, 6);
                case 3: return vrol(x, 5);
                case 4: return vrol(x, 4);
                case 5: return vrol(x, 3);
                case 6: return vrol(x, 2);
                case 7: return vrol(x, 1);

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vror(uint2 x, int n)
        {
            return (uint2)vror((int2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vror(uint3 x, int n)
        {
            return (uint3)vror((int3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vror(uint4 x, int n)
        {
            return (uint4)vror((int4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vror(uint8 x, int n)
        {
            return (uint8)vror((int8)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.long2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vror(long2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.long3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vror(long3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.long4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static long4 vror(long4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Avx.IsAvxSupported)
            {
                v256* stack = stackalloc v256[2];
                stack[0] = x;
                stack[1] = x;

                return Avx.mm256_loadu_si256((byte*)stack + (((uint)n % 4) * sizeof(long)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[4];
                stack[0] = x.xy;
                stack[1] = x.zw;
                stack[2] = x.xy;
                stack[3] = x.zw;

                byte* address = (byte*)stack + (((uint)n % 4) * sizeof(long));

                v128 lo = Xse.loadu_si128(address);
                v128 hi = Xse.loadu_si128(address + sizeof(v128));

                return new long4(lo, hi);
            }

            switch ((uint)n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ulong2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vror(ulong2 x, int n)
        {
            return (ulong2)vror((long2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ulong3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vror(ulong3 x, int n)
        {
            return (ulong3)vror((long3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ulong4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vror(ulong4 x, int n)
        {
            return (ulong4)vror((long4)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 vror(quarter2 x, int n)
        {
            return asquarter(vror(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 vror(quarter3 x, int n)
        {
            return asquarter(vror(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 vror(quarter4 x, int n)
        {
            return asquarter(vror(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 vror(quarter8 x, int n)
        {
            return asquarter(vror(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 vror(quarter16 x, int n)
        {
            return asquarter(vror(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter32"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 vror(quarter32 x, int n)
        {
            return asquarter(vror(asbyte(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 vror(half2 x, int n)
        {
            return ashalf(vror(asushort(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 vror(half3 x, int n)
        {
            return ashalf(vror(asushort(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 vror(half4 x, int n)
        {
            return ashalf(vror(asushort(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 vror(half8 x, int n)
        {
            return ashalf(vror(asshort(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 vror(half16 x, int n)
        {
            return ashalf(vror(asshort(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.float2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vror(float2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.float3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vror(float3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.float4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static float4 vror(float4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[2];
                stack[0] = x;
                stack[1] = x;

                v128 result = Xse.loadu_si128((byte*)stack + (((uint)n % 4) * sizeof(float)));

                return *(float4*)&result;
            }

            switch ((uint)n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.float8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static float8 vror(float8 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Avx.IsAvxSupported)
            {
                v256* stack = stackalloc v256[2];
                stack[0] = x;
                stack[1] = x;

                return Avx.mm256_loadu_ps((byte*)stack + (((uint)n % 8) * sizeof(float)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[4];
                stack[0] = x.v4_0;
                stack[1] = x.v4_4;
                stack[2] = x.v4_0;
                stack[3] = x.v4_4;

                byte* address = (byte*)stack + (((uint)n % 8) * sizeof(float));

                v128 lo = Xse.loadu_si128(address);
                v128 hi = Xse.loadu_si128(address + sizeof(v128));

                return new float8(*(float4*)&lo, *(float4*)&hi);
            }

            switch ((uint)n % 8)
            {
                case 1: return vrol(x, 7);
                case 2: return vrol(x, 6);
                case 3: return vrol(x, 5);
                case 4: return vrol(x, 4);
                case 5: return vrol(x, 3);
                case 6: return vrol(x, 2);
                case 7: return vrol(x, 1);

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.double2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vror(double2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.double3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vror(double3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.double4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static double4 vror(double4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Avx.IsAvxSupported)
            {
                v256* stack = stackalloc v256[2];
                stack[0] = x;
                stack[1] = x;

                return Avx.mm256_loadu_pd((byte*)stack + (((uint)n % 4) * sizeof(double)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[4];
                stack[0] = x.xy;
                stack[1] = x.zw;
                stack[2] = x.xy;
                stack[3] = x.zw;

                byte* address = (byte*)stack + (((uint)n % 4) * sizeof(double));

                v128 lo = Xse.loadu_si128(address);
                v128 hi = Xse.loadu_si128(address + sizeof(v128));

                return new double4(lo, hi);
            }

            switch ((uint)n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 vror(mask8x2 x, int n)
        {
            return (v128)vror((byte2)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 vror(mask8x3 x, int n)
        {
            return (v128)vror((byte3)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 vror(mask8x4 x, int n)
        {
            return (v128)vror((byte4)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 vror(mask8x8 x, int n)
        {
            return (v128)vror((byte8)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 vror(mask8x16 x, int n)
        {
            return (v128)vror((byte16)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool32"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 vror(mask8x32 x, int n)
        {
            return (v256)vror((byte32)(v256)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 vror(mask16x2 x, int n)
        {
            return (v128)vror((ushort2)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 vror(mask16x3 x, int n)
        {
            return (v128)vror((ushort3)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 vror(mask16x4 x, int n)
        {
            return (v128)vror((ushort4)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 vror(mask16x8 x, int n)
        {
            return (v128)vror((ushort8)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool16"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 vror(mask16x16 x, int n)
        {
            return (v256)vror((ushort16)(v256)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 vror(mask32x2 x, int n)
        {
            return (v128)vror((uint2)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 vror(mask32x3 x, int n)
        {
            return (v128)vror((uint3)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 vror(mask32x4 x, int n)
        {
            return (v128)vror((uint4)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool8"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 vror(mask32x8 x, int n)
        {
            return (v256)vror((uint8)(v256)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 vror(mask64x2 x, int n)
        {
            return (v128)vror((ulong2)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 vror(mask64x3 x, int n)
        {
            return (v256)vror((ulong3)(v256)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> right by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 vror(mask64x4 x, int n)
        {
            return (v256)vror((ulong4)(v256)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 vrol(bool2 x, int n)
        {
            return tobool(vrol(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 vrol(bool3 x, int n)
        {
            return tobool(vrol(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 vrol(bool4 x, int n)
        {
            return tobool(vrol(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 vrol(bool8 x, int n)
        {
            return tobool(vrol(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 vrol(bool16 x, int n)
        {
            return tobool(vrol(tobyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool32"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 vrol(bool32 x, int n)
        {
            return tobool(vrol(tobyte(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vrol(byte2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vrol(byte3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte4 vrol(byte4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Sse2.IsSse2Supported)
            {
                return Xse.cvtsi32_si128(rol(((v128)x).SInt0, n * 8));
            }

            switch ((uint)n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte8 vrol(byte8 x, int n)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch ((uint)n % 8)
                    {
                        case 1: return Xse.shuffle_epi8(x, new v128(7, 0, 1, 2, 3, 4, 5, 6,      0, 0, 0, 0, 0, 0, 0, 0));
                        case 2: return Xse.shufflelo_epi16(x, Sse.SHUFFLE(2, 1, 0, 3));
                        case 3: return Xse.shuffle_epi8(x, new v128(5, 6, 7, 0, 1, 2, 3, 4,      0, 0, 0, 0, 0, 0, 0, 0));
                        case 4: return Xse.shufflelo_epi16(x, Sse.SHUFFLE(1, 0, 3, 2));
                        case 5: return Xse.shuffle_epi8(x, new v128(3, 4, 5, 6, 7, 0, 1, 2,      0, 0, 0, 0, 0, 0, 0, 0));
                        case 6: return Xse.shufflelo_epi16(x, Sse.SHUFFLE(0, 3, 2, 1));
                        case 7: return Xse.shuffle_epi8(x, new v128(1, 2, 3, 4, 5, 6, 7, 0,      0, 0, 0, 0, 0, 0, 0, 0));

                        default: return x;
                    }
                }
                else
                {
                    return Xse.cvtsi64x_si128(rol(((v128)x).SLong0, n * 8));
                }
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch ((uint)n % 8)
                    {
                        case 1: return Xse.cvtsi64x_si128(rol(((v128)x).SLong0, 1 * 8));
                        case 2: return Xse.shufflelo_epi16(x, Sse.SHUFFLE(2, 1, 0, 3));
                        case 3: return Xse.cvtsi64x_si128(rol(((v128)x).SLong0, 3 * 8));
                        case 4: return Xse.shufflelo_epi16(x, Sse.SHUFFLE(1, 0, 3, 2));
                        case 5: return Xse.cvtsi64x_si128(rol(((v128)x).SLong0, 5 * 8));
                        case 6: return Xse.shufflelo_epi16(x, Sse.SHUFFLE(0, 3, 2, 1));
                        case 7: return Xse.cvtsi64x_si128(rol(((v128)x).SLong0, 7 * 8));

                        default: return x;
                    }
                }
                else
                {
                    return Xse.cvtsi64x_si128(rol(((v128)x).SLong0, n * 8));
                }
            }
            else
            {
                switch ((uint)n % 8)
                {
                    case 1: return new byte8(x.x7, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 2: return new byte8(x.x6, x.x7, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 3: return new byte8(x.x5, x.x6, x.x7, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 4: return new byte8(x.x4, x.x5, x.x6, x.x7, x.x0, x.x1, x.x2, x.x3);
                    case 5: return new byte8(x.x3, x.x4, x.x5, x.x6, x.x7, x.x0, x.x1, x.x2);
                    case 6: return new byte8(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x0, x.x1);
                    case 7: return new byte8(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte16 vrol(byte16 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.brol_si128(x, n);
            }
            else
            {
                switch ((uint)n % 16)
                {
                    case 1:  return new byte16(x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 2:  return new byte16(x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 3:  return new byte16(x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 4:  return new byte16(x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 5:  return new byte16(x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 6:  return new byte16(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 7:  return new byte16(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 8:  return new byte16(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 9:  return new byte16(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 10: return new byte16(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 11: return new byte16(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 12: return new byte16(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3);
                    case 13: return new byte16(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2);
                    case 14: return new byte16(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1);
                    case 15: return new byte16(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.byte32"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static byte32 vrol(byte32 x, int n)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_brol_si256(x, n);
            }
            else if (BurstArchitecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch ((uint)n % 32)
                    {
                        case 1:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0, 15 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16, 15 * sizeof(byte)));
                        case 2:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0, 14 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16, 14 * sizeof(byte)));
                        case 3:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0, 13 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16, 13 * sizeof(byte)));
                        case 4:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0, 12 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16, 12 * sizeof(byte)));
                        case 5:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0, 11 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16, 11 * sizeof(byte)));
                        case 6:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0, 10 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16, 10 * sizeof(byte)));
                        case 7:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  9 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  9 * sizeof(byte)));
                        case 8:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  8 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  8 * sizeof(byte)));
                        case 9:  return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  7 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  7 * sizeof(byte)));
                        case 10: return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  6 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  6 * sizeof(byte)));
                        case 11: return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  5 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  5 * sizeof(byte)));
                        case 12: return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  4 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  4 * sizeof(byte)));
                        case 13: return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  3 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  3 * sizeof(byte)));
                        case 14: return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  2 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  2 * sizeof(byte)));
                        case 15: return new byte32(Xse.alignr_epi8(x.__x16, x.__x0,  1 * sizeof(byte)), Xse.alignr_epi8(x.__x0, x.__x16,  1 * sizeof(byte)));
                        case 16: return new byte32(x.__x16, x.__x0);
                        case 17: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16, 15 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0, 15 * sizeof(byte)));
                        case 18: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16, 14 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0, 14 * sizeof(byte)));
                        case 19: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16, 13 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0, 13 * sizeof(byte)));
                        case 20: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16, 12 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0, 12 * sizeof(byte)));
                        case 21: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16, 11 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0, 11 * sizeof(byte)));
                        case 22: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16, 10 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0, 10 * sizeof(byte)));
                        case 23: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  9 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  9 * sizeof(byte)));
                        case 24: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  8 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  8 * sizeof(byte)));
                        case 25: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  7 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  7 * sizeof(byte)));
                        case 26: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  6 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  6 * sizeof(byte)));
                        case 27: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  5 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  5 * sizeof(byte)));
                        case 28: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  4 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  4 * sizeof(byte)));
                        case 29: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  3 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  3 * sizeof(byte)));
                        case 30: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  2 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  2 * sizeof(byte)));
                        case 31: return new byte32(Xse.alignr_epi8(x.__x0, x.__x16,  1 * sizeof(byte)), Xse.alignr_epi8(x.__x16, x.__x0,  1 * sizeof(byte)));

                        default: return x;
                    }
                }
                else
                {
                    v128* stack = stackalloc v128[4];
                    stack[0] = x.__x0;
                    stack[1] = x.__x16;
                    stack[2] = x.__x0;
                    stack[3] = x.__x16;

                    byte* address = (byte*)stack + (32 - ((uint)n % 32));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + sizeof(v128));

                    return new byte32(lo, hi);
                }
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch ((uint)n % 32)
                    {
                        case 1:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16, 15 * sizeof(byte)), Xse.bslli_si128(x.__x0,   1 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,  15 * sizeof(byte)), Xse.bslli_si128(x.__x16,  1 * sizeof(byte))));
                        case 2:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16, 14 * sizeof(byte)), Xse.bslli_si128(x.__x0,   2 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,  14 * sizeof(byte)), Xse.bslli_si128(x.__x16,  2 * sizeof(byte))));
                        case 3:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16, 13 * sizeof(byte)), Xse.bslli_si128(x.__x0,   3 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,  13 * sizeof(byte)), Xse.bslli_si128(x.__x16,  3 * sizeof(byte))));
                        case 4:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16, 12 * sizeof(byte)), Xse.bslli_si128(x.__x0,   4 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,  12 * sizeof(byte)), Xse.bslli_si128(x.__x16,  4 * sizeof(byte))));
                        case 5:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16, 11 * sizeof(byte)), Xse.bslli_si128(x.__x0,   5 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,  11 * sizeof(byte)), Xse.bslli_si128(x.__x16,  5 * sizeof(byte))));
                        case 6:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16, 10 * sizeof(byte)), Xse.bslli_si128(x.__x0,   6 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,  10 * sizeof(byte)), Xse.bslli_si128(x.__x16,  6 * sizeof(byte))));
                        case 7:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  9 * sizeof(byte)), Xse.bslli_si128(x.__x0,   7 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   9 * sizeof(byte)), Xse.bslli_si128(x.__x16,  7 * sizeof(byte))));
                        case 8:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  8 * sizeof(byte)), Xse.bslli_si128(x.__x0,   8 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   8 * sizeof(byte)), Xse.bslli_si128(x.__x16,  8 * sizeof(byte))));
                        case 9:  return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  7 * sizeof(byte)), Xse.bslli_si128(x.__x0,   9 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   7 * sizeof(byte)), Xse.bslli_si128(x.__x16,  9 * sizeof(byte))));
                        case 10: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  6 * sizeof(byte)), Xse.bslli_si128(x.__x0,  10 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   6 * sizeof(byte)), Xse.bslli_si128(x.__x16, 10 * sizeof(byte))));
                        case 11: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  5 * sizeof(byte)), Xse.bslli_si128(x.__x0,  11 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   5 * sizeof(byte)), Xse.bslli_si128(x.__x16, 11 * sizeof(byte))));
                        case 12: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  4 * sizeof(byte)), Xse.bslli_si128(x.__x0,  12 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   4 * sizeof(byte)), Xse.bslli_si128(x.__x16, 12 * sizeof(byte))));
                        case 13: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  3 * sizeof(byte)), Xse.bslli_si128(x.__x0,  13 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   3 * sizeof(byte)), Xse.bslli_si128(x.__x16, 13 * sizeof(byte))));
                        case 14: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  2 * sizeof(byte)), Xse.bslli_si128(x.__x0,  14 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   2 * sizeof(byte)), Xse.bslli_si128(x.__x16, 14 * sizeof(byte))));
                        case 15: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x16,  1 * sizeof(byte)), Xse.bslli_si128(x.__x0,  15 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x0,   1 * sizeof(byte)), Xse.bslli_si128(x.__x16, 15 * sizeof(byte))));
                        case 16: return new byte32(x.__x16, x.__x0);
                        case 17: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,  15 * sizeof(byte)), Xse.bslli_si128(x.__x16,  1 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16, 15 * sizeof(byte)), Xse.bslli_si128(x.__x0,   1 * sizeof(byte))));
                        case 18: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,  14 * sizeof(byte)), Xse.bslli_si128(x.__x16,  2 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16, 14 * sizeof(byte)), Xse.bslli_si128(x.__x0,   2 * sizeof(byte))));
                        case 19: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,  13 * sizeof(byte)), Xse.bslli_si128(x.__x16,  3 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16, 13 * sizeof(byte)), Xse.bslli_si128(x.__x0,   3 * sizeof(byte))));
                        case 20: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,  12 * sizeof(byte)), Xse.bslli_si128(x.__x16,  4 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16, 12 * sizeof(byte)), Xse.bslli_si128(x.__x0,   4 * sizeof(byte))));
                        case 21: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,  11 * sizeof(byte)), Xse.bslli_si128(x.__x16,  5 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16, 11 * sizeof(byte)), Xse.bslli_si128(x.__x0,   5 * sizeof(byte))));
                        case 22: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,  10 * sizeof(byte)), Xse.bslli_si128(x.__x16,  6 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16, 10 * sizeof(byte)), Xse.bslli_si128(x.__x0,   6 * sizeof(byte))));
                        case 23: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   9 * sizeof(byte)), Xse.bslli_si128(x.__x16,  7 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  9 * sizeof(byte)), Xse.bslli_si128(x.__x0,   7 * sizeof(byte))));
                        case 24: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   8 * sizeof(byte)), Xse.bslli_si128(x.__x16,  8 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  8 * sizeof(byte)), Xse.bslli_si128(x.__x0,   8 * sizeof(byte))));
                        case 25: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   7 * sizeof(byte)), Xse.bslli_si128(x.__x16,  9 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  7 * sizeof(byte)), Xse.bslli_si128(x.__x0,   9 * sizeof(byte))));
                        case 26: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   6 * sizeof(byte)), Xse.bslli_si128(x.__x16, 10 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  6 * sizeof(byte)), Xse.bslli_si128(x.__x0,  10 * sizeof(byte))));
                        case 27: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   5 * sizeof(byte)), Xse.bslli_si128(x.__x16, 11 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  5 * sizeof(byte)), Xse.bslli_si128(x.__x0,  11 * sizeof(byte))));
                        case 28: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   4 * sizeof(byte)), Xse.bslli_si128(x.__x16, 12 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  4 * sizeof(byte)), Xse.bslli_si128(x.__x0,  12 * sizeof(byte))));
                        case 29: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   3 * sizeof(byte)), Xse.bslli_si128(x.__x16, 13 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  3 * sizeof(byte)), Xse.bslli_si128(x.__x0,  13 * sizeof(byte))));
                        case 30: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   2 * sizeof(byte)), Xse.bslli_si128(x.__x16, 14 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  2 * sizeof(byte)), Xse.bslli_si128(x.__x0,  14 * sizeof(byte))));
                        case 31: return new byte32(Xse.or_si128(Xse.bsrli_si128(x.__x0,   1 * sizeof(byte)), Xse.bslli_si128(x.__x16, 15 * sizeof(byte))),
                                                   Xse.or_si128(Xse.bsrli_si128(x.__x16,  1 * sizeof(byte)), Xse.bslli_si128(x.__x0,  15 * sizeof(byte))));

                        default: return x;
                    }
                }
                else
                {
                    v128* stack = stackalloc v128[4];
                    stack[0] = x.__x0;
                    stack[1] = x.__x16;
                    stack[2] = x.__x0;
                    stack[3] = x.__x16;

                    byte* address = (byte*)stack + (32 - ((uint)n % 32));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + sizeof(v128));

                    return new byte32(lo, hi);
                }
            }
            else
            {
                switch ((uint)n % 32)
                {
                    case 1:  return new byte32(x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30);
                    case 2:  return new byte32(x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29);
                    case 3:  return new byte32(x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28);
                    case 4:  return new byte32(x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27);
                    case 5:  return new byte32(x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26);
                    case 6:  return new byte32(x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25);
                    case 7:  return new byte32(x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24);
                    case 8:  return new byte32(x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23);
                    case 9:  return new byte32(x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22);
                    case 10: return new byte32(x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21);
                    case 11: return new byte32(x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20);
                    case 12: return new byte32(x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19);
                    case 13: return new byte32(x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18);
                    case 14: return new byte32(x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17);
                    case 15: return new byte32(x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16);
                    case 16: return new byte32(x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15);
                    case 17: return new byte32(x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 18: return new byte32(x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 19: return new byte32(x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 20: return new byte32(x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 21: return new byte32(x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 22: return new byte32(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 23: return new byte32(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 24: return new byte32(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 25: return new byte32(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 26: return new byte32(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 27: return new byte32(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 28: return new byte32(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2, x.x3);
                    case 29: return new byte32(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1, x.x2);
                    case 30: return new byte32(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0, x.x1);
                    case 31: return new byte32(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, x.x0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vrol(sbyte2 x, int n)
        {
            return (sbyte2)vrol((byte2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vrol(sbyte3 x, int n)
        {
            return (sbyte3)vrol((byte3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vrol(sbyte4 x, int n)
        {
            return (sbyte4)vrol((byte4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vrol(sbyte8 x, int n)
        {
            return (sbyte8)vrol((byte8)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vrol(sbyte16 x, int n)
        {
            return (sbyte16)vrol((byte16)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.sbyte32"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 vrol(sbyte32 x, int n)
        {
            return (sbyte32)vrol((byte32)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vrol(short2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vrol(short3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short4 vrol(short4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Sse2.IsSse2Supported)
            {
                return Xse.cvtsi64x_si128(rol(((v128)x).SLong0, n * 16));
            }

            switch ((uint)n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short8 vrol(short8 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.brol_si128(x, 2 * n);
            }
            else
            {
                switch ((uint)n % 8)
                {
                    case 1: return new short8(x.x7, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 2: return new short8(x.x6, x.x7, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 3: return new short8(x.x5, x.x6, x.x7, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 4: return new short8(x.x4, x.x5, x.x6, x.x7, x.x0, x.x1, x.x2, x.x3);
                    case 5: return new short8(x.x3, x.x4, x.x5, x.x6, x.x7, x.x0, x.x1, x.x2);
                    case 6: return new short8(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x0, x.x1);
                    case 7: return new short8(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x0);

                    default: return x;
                }
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.short16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static short16 vrol(short16 x, int n)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_brol_si256(x, 2 * n);
            }
            else if (BurstArchitecture.IsTableLookupSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch ((uint)n % 16)
                    {
                        case 1:  return new short16(Xse.alignr_epi8(x.__x8, x.__x0, 7 * sizeof(short)), Xse.alignr_epi8(x.__x0, x.__x8, 7 * sizeof(short)));
                        case 2:  return new short16(Xse.alignr_epi8(x.__x8, x.__x0, 6 * sizeof(short)), Xse.alignr_epi8(x.__x0, x.__x8, 6 * sizeof(short)));
                        case 3:  return new short16(Xse.alignr_epi8(x.__x8, x.__x0, 5 * sizeof(short)), Xse.alignr_epi8(x.__x0, x.__x8, 5 * sizeof(short)));
                        case 4:  return new short16(Xse.alignr_epi8(x.__x8, x.__x0, 4 * sizeof(short)), Xse.alignr_epi8(x.__x0, x.__x8, 4 * sizeof(short)));
                        case 5:  return new short16(Xse.alignr_epi8(x.__x8, x.__x0, 3 * sizeof(short)), Xse.alignr_epi8(x.__x0, x.__x8, 3 * sizeof(short)));
                        case 6:  return new short16(Xse.alignr_epi8(x.__x8, x.__x0, 2 * sizeof(short)), Xse.alignr_epi8(x.__x0, x.__x8, 2 * sizeof(short)));
                        case 7:  return new short16(Xse.alignr_epi8(x.__x8, x.__x0, 1 * sizeof(short)), Xse.alignr_epi8(x.__x0, x.__x8, 1 * sizeof(short)));
                        case 8:  return new short16(x.__x8, x.__x0);
                        case 9:  return new short16(Xse.alignr_epi8(x.__x0, x.__x8, 7 * sizeof(short)), Xse.alignr_epi8(x.__x8, x.__x0, 7 * sizeof(short)));
                        case 10: return new short16(Xse.alignr_epi8(x.__x0, x.__x8, 6 * sizeof(short)), Xse.alignr_epi8(x.__x8, x.__x0, 6 * sizeof(short)));
                        case 11: return new short16(Xse.alignr_epi8(x.__x0, x.__x8, 5 * sizeof(short)), Xse.alignr_epi8(x.__x8, x.__x0, 5 * sizeof(short)));
                        case 12: return new short16(Xse.alignr_epi8(x.__x0, x.__x8, 4 * sizeof(short)), Xse.alignr_epi8(x.__x8, x.__x0, 4 * sizeof(short)));
                        case 13: return new short16(Xse.alignr_epi8(x.__x0, x.__x8, 3 * sizeof(short)), Xse.alignr_epi8(x.__x8, x.__x0, 3 * sizeof(short)));
                        case 14: return new short16(Xse.alignr_epi8(x.__x0, x.__x8, 2 * sizeof(short)), Xse.alignr_epi8(x.__x8, x.__x0, 2 * sizeof(short)));
                        case 15: return new short16(Xse.alignr_epi8(x.__x0, x.__x8, 1 * sizeof(short)), Xse.alignr_epi8(x.__x8, x.__x0, 1 * sizeof(short)));

                        default: return x;
                    }
                }
                else
                {
                    v128* stack = stackalloc v128[4];
                    stack[0] = x.__x0;
                    stack[1] = x.__x8;
                    stack[2] = x.__x0;
                    stack[3] = x.__x8;

                    byte* address = (byte*)stack + ((16 - ((uint)n %16)) * sizeof(short));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + sizeof(v128));

                    return new short16(lo, hi);
                }
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch ((uint)n % 16)
                    {
                        case 1:  return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x8, 7 * sizeof(short)), Xse.bslli_si128(x.__x0, 1 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x0, 7 * sizeof(short)), Xse.bslli_si128(x.__x8, 1 * sizeof(short))));
                        case 2:  return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x8, 6 * sizeof(short)), Xse.bslli_si128(x.__x0, 2 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x0, 6 * sizeof(short)), Xse.bslli_si128(x.__x8, 2 * sizeof(short))));
                        case 3:  return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x8, 5 * sizeof(short)), Xse.bslli_si128(x.__x0, 3 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x0, 5 * sizeof(short)), Xse.bslli_si128(x.__x8, 3 * sizeof(short))));
                        case 4:  return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x8, 4 * sizeof(short)), Xse.bslli_si128(x.__x0, 4 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x0, 4 * sizeof(short)), Xse.bslli_si128(x.__x8, 4 * sizeof(short))));
                        case 5:  return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x8, 3 * sizeof(short)), Xse.bslli_si128(x.__x0, 5 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x0, 3 * sizeof(short)), Xse.bslli_si128(x.__x8, 5 * sizeof(short))));
                        case 6:  return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x8, 2 * sizeof(short)), Xse.bslli_si128(x.__x0, 6 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x0, 2 * sizeof(short)), Xse.bslli_si128(x.__x8, 6 * sizeof(short))));
                        case 7:  return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x8, 1 * sizeof(short)), Xse.bslli_si128(x.__x0, 7 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x0, 1 * sizeof(short)), Xse.bslli_si128(x.__x8, 7 * sizeof(short))));
                        case 8:  return new short16(x.__x8, x.__x0);
                        case 9:  return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x0, 7 * sizeof(short)), Xse.bslli_si128(x.__x8, 1 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x8, 7 * sizeof(short)), Xse.bslli_si128(x.__x0, 1 * sizeof(short))));
                        case 10: return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x0, 6 * sizeof(short)), Xse.bslli_si128(x.__x8, 2 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x8, 6 * sizeof(short)), Xse.bslli_si128(x.__x0, 2 * sizeof(short))));
                        case 11: return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x0, 5 * sizeof(short)), Xse.bslli_si128(x.__x8, 3 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x8, 5 * sizeof(short)), Xse.bslli_si128(x.__x0, 3 * sizeof(short))));
                        case 12: return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x0, 4 * sizeof(short)), Xse.bslli_si128(x.__x8, 4 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x8, 4 * sizeof(short)), Xse.bslli_si128(x.__x0, 4 * sizeof(short))));
                        case 13: return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x0, 3 * sizeof(short)), Xse.bslli_si128(x.__x8, 5 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x8, 3 * sizeof(short)), Xse.bslli_si128(x.__x0, 5 * sizeof(short))));
                        case 14: return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x0, 2 * sizeof(short)), Xse.bslli_si128(x.__x8, 6 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x8, 2 * sizeof(short)), Xse.bslli_si128(x.__x0, 6 * sizeof(short))));
                        case 15: return new short16(Xse.or_si128(Xse.bsrli_si128(x.__x0, 1 * sizeof(short)), Xse.bslli_si128(x.__x8, 7 * sizeof(short))),
                                                    Xse.or_si128(Xse.bsrli_si128(x.__x8, 1 * sizeof(short)), Xse.bslli_si128(x.__x0, 7 * sizeof(short))));

                        default: return x;
                    }
                }
                else
                {
                    v128* stack = stackalloc v128[4];
                    stack[0] = x.__x0;
                    stack[1] = x.__x8;
                    stack[2] = x.__x0;
                    stack[3] = x.__x8;

                    byte* address = (byte*)stack + ((16 - ((uint)n %16)) * sizeof(short));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + sizeof(v128));

                    return new short16(lo, hi);
                }
            }
            else
            {
                switch ((uint)n % 16)
                {
                    case 1:  return new short16(x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 2:  return new short16(x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 3:  return new short16(x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 4:  return new short16(x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 5:  return new short16(x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 6:  return new short16(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 7:  return new short16(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 8:  return new short16(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 9:  return new short16(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 10: return new short16(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 11: return new short16(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 12: return new short16(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2, x.x3);
                    case 13: return new short16(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1, x.x2);
                    case 14: return new short16(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0, x.x1);
                    case 15: return new short16(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x0);

                    default: return x;
                }
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vrol(ushort2 x, int n)
        {
            return (ushort2)vrol((short2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vrol(ushort3 x, int n)
        {
            return (ushort3)vrol((short3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vrol(ushort4 x, int n)
        {
            return (ushort4)vrol((short4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vrol(ushort8 x, int n)
        {
            return (ushort8)vrol((short8)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ushort16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 vrol(ushort16 x, int n)
        {
            return (ushort16)vrol((short16)x, n);
        }


        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.int2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vrol(int2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.int3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vrol(int3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.int4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int4 vrol(int4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[2];
                stack[0] = x;
                stack[1] = x;

                return Xse.loadu_si128((byte*)stack + ((4 - ((uint)n % 4)) * sizeof(int)));
            }

            switch ((uint)n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within an <see cref="MaxMath.int8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int8 vrol(int8 x, int n)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_brol_si256(x, 4 * n);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    ;
                }
                else
                {
                    v128* stack = stackalloc v128[4];
                    stack[0] = x.__x0;
                    stack[1] = x.__x4;
                    stack[2] = x.__x0;
                    stack[3] = x.__x4;

                    byte* address = (byte*)stack + ((8 - ((uint)n % 8)) * sizeof(int));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + sizeof(v128));

                    return new int8(lo, hi);
                }
            }

            switch ((uint)n % 8)
            {
                case 1: return new int8(shuffle(x.__x0, x.__x4, ShuffleComponent.RightW, ShuffleComponent.LeftX,  ShuffleComponent.LeftY,  ShuffleComponent.LeftZ),
                                        shuffle(x.__x0, x.__x4, ShuffleComponent.LeftW,  ShuffleComponent.RightX, ShuffleComponent.RightY, ShuffleComponent.RightZ));
                case 2: return new int8(shuffle(x.__x0, x.__x4, ShuffleComponent.RightZ, ShuffleComponent.RightW, ShuffleComponent.LeftX,  ShuffleComponent.LeftY),
                                        shuffle(x.__x0, x.__x4, ShuffleComponent.LeftZ,  ShuffleComponent.LeftW,  ShuffleComponent.RightX, ShuffleComponent.RightY));
                case 3: return new int8(shuffle(x.__x0, x.__x4, ShuffleComponent.RightY, ShuffleComponent.RightZ, ShuffleComponent.RightW, ShuffleComponent.LeftX),
                                        shuffle(x.__x0, x.__x4, ShuffleComponent.LeftY,  ShuffleComponent.LeftZ,  ShuffleComponent.LeftW,  ShuffleComponent.RightX));
                case 4: return new int8(x.__x4, x.__x0);
                case 5: return new int8(shuffle(x.__x0, x.__x4, ShuffleComponent.LeftW,  ShuffleComponent.RightX, ShuffleComponent.RightY, ShuffleComponent.RightZ),
                                        shuffle(x.__x0, x.__x4, ShuffleComponent.RightW, ShuffleComponent.LeftX,  ShuffleComponent.LeftY,  ShuffleComponent.LeftZ));
                case 6: return new int8(shuffle(x.__x0, x.__x4, ShuffleComponent.LeftZ,  ShuffleComponent.LeftW,  ShuffleComponent.RightX, ShuffleComponent.RightY),
                                        shuffle(x.__x0, x.__x4, ShuffleComponent.RightZ, ShuffleComponent.RightW, ShuffleComponent.LeftX,  ShuffleComponent.LeftY));
                case 7: return new int8(shuffle(x.__x0, x.__x4, ShuffleComponent.LeftY,  ShuffleComponent.LeftZ,  ShuffleComponent.LeftW,  ShuffleComponent.RightX),
                                        shuffle(x.__x0, x.__x4, ShuffleComponent.RightY, ShuffleComponent.RightZ, ShuffleComponent.RightW, ShuffleComponent.LeftX));

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vrol(uint2 x, int n)
        {
            return (uint2)vrol((int2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vrol(uint3 x, int n)
        {
            return (uint3)vrol((int3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static uint4 vrol(uint4 x, int n)
        {
            return (uint4)vrol((int4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.uint8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vrol(uint8 x, int n)
        {
            return (uint8)vrol((int8)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.long2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vrol(long2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.long3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vrol(long3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.long4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static long4 vrol(long4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Avx.IsAvxSupported)
            {
                v256* stack = stackalloc v256[2];
                stack[0] = x;
                stack[1] = x;

                return Avx.mm256_loadu_si256((byte*)stack + ((4 - ((uint)n % 4)) * sizeof(long)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[4];
                stack[0] = x.xy;
                stack[1] = x.zw;
                stack[2] = x.xy;
                stack[3] = x.zw;

                byte* address = (byte*)stack + ((4 - ((uint)n % 4)) * sizeof(long));

                v128 lo = Xse.loadu_si128(address);
                v128 hi = Xse.loadu_si128(address + sizeof(v128));

                return new long4(lo, hi);
            }

            switch ((uint)n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ulong2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vrol(ulong2 x, int n)
        {
            return (ulong2)vrol((long2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ulong3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vrol(ulong3 x, int n)
        {
            return (ulong3)vrol((long3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.ulong4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vrol(ulong4 x, int n)
        {
            return (ulong4)vrol((long4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 vrol(quarter2 x, int n)
        {
            return asquarter(vrol(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 vrol(quarter3 x, int n)
        {
            return asquarter(vrol(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static quarter4 vrol(quarter4 x, int n)
        {
            return asquarter(vrol(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 vrol(quarter8 x, int n)
        {
            return asquarter(vrol(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 vrol(quarter16 x, int n)
        {
            return asquarter(vrol(asbyte(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.quarter32"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 vrol(quarter32 x, int n)
        {
            return asquarter(vrol(asbyte(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 vrol(half2 x, int n)
        {
            return ashalf(vrol(asshort(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 vrol(half3 x, int n)
        {
            return ashalf(vrol(asshort(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 vrol(half4 x, int n)
        {
            return ashalf(vrol(asshort(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 vrol(half8 x, int n)
        {
            return ashalf(vrol(asshort(x), n));
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.half16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 vrol(half16 x, int n)
        {
            return ashalf(vrol(asshort(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.float2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vrol(float2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.float3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vrol(float3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.float4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static float4 vrol(float4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[2];
                stack[0] = x;
                stack[1] = x;

                v128 result = Xse.loadu_si128((byte*)stack + ((4 - ((uint)n % 4)) * sizeof(float)));

                return *(float4*)&result;
            }

            switch ((uint)n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.float8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static float8 vrol(float8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(n))
                {
                    switch ((uint)n % 8)
                    {
                        case 1: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(1, 0, 3, 2)), x, 3 * sizeof(float));
                        case 2: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(2, 1, 0, 3));
                        case 3: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(1, 0, 3, 2)), x, 1 * sizeof(float));
                        case 4: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(1, 0, 3, 2));
                        case 5: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(1, 0, 3, 2)), 3 * sizeof(float));
                        case 6: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(0, 3, 2, 1));
                        case 7: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(1, 0, 3, 2)), 1 * sizeof(float));

                        default: return x;
                    }
                }
                else
                {
                    v256* stack = stackalloc v256[2];
                    stack[0] = x;
                    stack[1] = x;

                    return Avx.mm256_loadu_ps((byte*)stack + ((8 - ((uint)n % 8)) * sizeof(float)));
                }
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(n))
                {
                    ;
                }
                else
                {
                    v128* stack = stackalloc v128[4];
                    stack[0] = x.v4_0;
                    stack[1] = x.v4_4;
                    stack[2] = x.v4_0;
                    stack[3] = x.v4_4;

                    byte* address = (byte*)stack + ((8 - ((uint)n % 8)) * sizeof(float));

                    v128 lo = Xse.loadu_si128(address);
                    v128 hi = Xse.loadu_si128(address + sizeof(v128));

                    return new float8(*(float4*)&lo, *(float4*)&hi);
                }
            }

            switch ((uint)n % 8)
            {
                case 1: return new float8(shuffle(x.v4_0, x.v4_4, ShuffleComponent.RightW, ShuffleComponent.LeftX,  ShuffleComponent.LeftY,  ShuffleComponent.LeftZ),
                                          shuffle(x.v4_0, x.v4_4, ShuffleComponent.LeftW,  ShuffleComponent.RightX, ShuffleComponent.RightY, ShuffleComponent.RightZ));
                case 2: return new float8(shuffle(x.v4_0, x.v4_4, ShuffleComponent.RightZ, ShuffleComponent.RightW, ShuffleComponent.LeftX,  ShuffleComponent.LeftY),
                                          shuffle(x.v4_0, x.v4_4, ShuffleComponent.LeftZ,  ShuffleComponent.LeftW,  ShuffleComponent.RightX, ShuffleComponent.RightY));
                case 3: return new float8(shuffle(x.v4_0, x.v4_4, ShuffleComponent.RightY, ShuffleComponent.RightZ, ShuffleComponent.RightW, ShuffleComponent.LeftX),
                                          shuffle(x.v4_0, x.v4_4, ShuffleComponent.LeftY,  ShuffleComponent.LeftZ,  ShuffleComponent.LeftW,  ShuffleComponent.RightX));
                case 4: return new float8(x.__x4, x.v4_0);
                case 5: return new float8(shuffle(x.v4_0, x.v4_4, ShuffleComponent.LeftW,  ShuffleComponent.RightX, ShuffleComponent.RightY, ShuffleComponent.RightZ),
                                          shuffle(x.v4_0, x.v4_4, ShuffleComponent.RightW, ShuffleComponent.LeftX,  ShuffleComponent.LeftY,  ShuffleComponent.LeftZ));
                case 6: return new float8(shuffle(x.v4_0, x.v4_4, ShuffleComponent.LeftZ,  ShuffleComponent.LeftW,  ShuffleComponent.RightX, ShuffleComponent.RightY),
                                          shuffle(x.v4_0, x.v4_4, ShuffleComponent.RightZ, ShuffleComponent.RightW, ShuffleComponent.LeftX,  ShuffleComponent.LeftY));
                case 7: return new float8(shuffle(x.v4_0, x.v4_4, ShuffleComponent.LeftY,  ShuffleComponent.LeftZ,  ShuffleComponent.LeftW,  ShuffleComponent.RightX),
                                          shuffle(x.v4_0, x.v4_4, ShuffleComponent.RightY, ShuffleComponent.RightZ, ShuffleComponent.RightW, ShuffleComponent.LeftX));

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.double2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vrol(double2 x, int n)
        {
            return isdivisible(n, 2) ? x : x.yx;
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.double3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vrol(double3 x, int n)
        {
            switch ((uint)n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.double4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static double4 vrol(double4 x, int n)
        {
            if (constexpr.IS_CONST(n))
            {
                ;
            }
            else if (Avx.IsAvxSupported)
            {
                v256* stack = stackalloc v256[2];
                stack[0] = x;
                stack[1] = x;

                return Avx.mm256_loadu_pd((byte*)stack + ((4 - ((uint)n % 4)) * sizeof(double)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128* stack = stackalloc v128[4];
                stack[0] = x.xy;
                stack[1] = x.zw;
                stack[2] = x.xy;
                stack[3] = x.zw;

                byte* address = (byte*)stack + ((4 - ((uint)n % 4)) * sizeof(double));

                v128 lo = Xse.loadu_si128(address);
                v128 hi = Xse.loadu_si128(address + sizeof(v128));

                return new double4(lo, hi);
            }

            switch ((uint)n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 vrol(mask8x2 x, int n)
        {
            return (v128)vrol((byte2)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 vrol(mask8x3 x, int n)
        {
            return (v128)vrol((byte3)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 vrol(mask8x4 x, int n)
        {
            return (v128)vrol((byte4)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 vrol(mask8x8 x, int n)
        {
            return (v128)vrol((byte8)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 vrol(mask8x16 x, int n)
        {
            return (v128)vrol((byte16)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool32"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 vrol(mask8x32 x, int n)
        {
            return (v256)vrol((byte32)(v256)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 vrol(mask16x2 x, int n)
        {
            return (v128)vrol((ushort2)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 vrol(mask16x3 x, int n)
        {
            return (v128)vrol((ushort3)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 vrol(mask16x4 x, int n)
        {
            return (v128)vrol((ushort4)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 vrol(mask16x8 x, int n)
        {
            return (v128)vrol((ushort8)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool16"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 vrol(mask16x16 x, int n)
        {
            return (v256)vrol((ushort16)(v256)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 vrol(mask32x2 x, int n)
        {
            return (v128)vrol((uint2)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 vrol(mask32x3 x, int n)
        {
            return (v128)vrol((uint3)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 vrol(mask32x4 x, int n)
        {
            return (v128)vrol((uint4)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool8"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 vrol(mask32x8 x, int n)
        {
            return (v256)vrol((uint8)(v256)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool2"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 vrol(mask64x2 x, int n)
        {
            return (v128)vrol((ulong2)(v128)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool3"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 vrol(mask64x3 x, int n)
        {
            return (v256)vrol((ulong3)(v256)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a <see cref="MaxMath.bool4"/> left by <paramref name="n"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 vrol(mask64x4 x, int n)
        {
            return (v256)vrol((ulong4)(v256)x, n);
        }
    }
}