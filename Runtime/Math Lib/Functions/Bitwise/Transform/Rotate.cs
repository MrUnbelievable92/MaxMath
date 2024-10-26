//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            private const bool ROTATE_IN_RANGE = 
#if TESTING 
            false;
#else
            true;
#endif
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ror_epi8(v128 a, int n)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(srli_epi8(a, n, inRange: ROTATE_IN_RANGE), slli_epi8(a, 8 - n, inRange: ROTATE_IN_RANGE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ror_epi16(v128 a, int n)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        if (Architecture.IsTableLookupSupported)
                        {
                            switch (n)
                            {
                                case 0:  return a;
                                case 8:  return bswap_epi16(a);
                                default: break;
                            }
                        }
                    }

                    return or_si128(srli_epi16(a, n, inRange: ROTATE_IN_RANGE), slli_epi16(a, 16 - n, inRange: ROTATE_IN_RANGE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ror_epi32(v128 a, int n)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        if (Architecture.IsTableLookupSupported)
                        {
                            switch (n)
                            {
                                case 0:  return a;
                                case 8:  return shuffle_epi8(a, new v128(1, 2, 3, 0,   5, 6, 7, 4,   9, 10, 11, 8,    13, 14, 15, 12));
                                case 16: return shuffle_epi8(a, new v128(2, 3, 0, 1,   6, 7, 4, 5,   10, 11, 8, 9,    14, 15, 12, 13));
                                case 24: return shuffle_epi8(a, new v128(3, 0, 1, 2,   7, 4, 5, 6,   11, 8, 9, 10,    15, 12, 13, 14));
                                default: break;
                            }
                        }

                        if (n == 16)
                        {
                            return shufflelo_epi16(shufflehi_epi16(a, Sse.SHUFFLE(2, 3, 0, 1)), Sse.SHUFFLE(2, 3, 0, 1));
                        }
                    }

                    return or_si128(srli_epi32(a, n, inRange: ROTATE_IN_RANGE), slli_epi32(a, 32 - n, inRange: ROTATE_IN_RANGE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ror_epi64(v128 a, int n)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        if (n == 32)
                        {
                            return shuffle_epi32(a, Sse.SHUFFLE(2, 3, 0, 1));
                        }

                        if (Architecture.IsTableLookupSupported)
                        {
                            switch (n)
                            {
                                case 0:  return a;
                                case 8:  return shuffle_epi8(a, new v128(1, 2, 3, 4, 5, 6, 7, 0,   9, 10, 11, 12, 13, 14, 15, 8));
                                case 16: return shuffle_epi8(a, new v128(2, 3, 4, 5, 6, 7, 0, 1,   10, 11, 12, 13, 14, 15, 8, 9));
                                case 24: return shuffle_epi8(a, new v128(3, 4, 5, 6, 7, 0, 1, 2,   11, 12, 13, 14, 15, 8, 9, 10));
                                case 40: return shuffle_epi8(a, new v128(5, 6, 7, 0, 1, 2, 3, 4,   13, 14, 15, 8, 9, 10, 11, 12));
                                case 48: return shuffle_epi8(a, new v128(6, 7, 0, 1, 2, 3, 4, 5,   14, 15, 8, 9, 10, 11, 12, 13));
                                case 56: return shuffle_epi8(a, new v128(7, 0, 1, 2, 3, 4, 5, 6,   15, 8, 9, 10, 11, 12, 13, 14));
                                default: break;
                            }
                        }
                    }

                    return or_si128(srli_epi64(a, n, inRange: ROTATE_IN_RANGE), slli_epi64(a, 64 - n, inRange: ROTATE_IN_RANGE));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ror_epi8(v256 a, int n)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(mm256_srli_epi8(a, n), mm256_slli_epi8(a, 8 - n));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ror_epi16(v256 a, int n)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        switch (n)
                        {
                            case 0:  return a;
                            case 8:  return mm256_bswap_epi16(a);
                            default: break;
                        }
                    }

                    return Avx2.mm256_or_si256(mm256_srli_epi16(a, n), mm256_slli_epi16(a, 16 - n));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ror_epi32(v256 a, int n)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        switch (n)
                        {
                            case 0:  return a;
                            case 8:  return Avx2.mm256_shuffle_epi8(a, new v256(1, 2, 3, 0,   5, 6, 7, 4,   9, 10, 11, 8,    13, 14, 15, 12,    1, 2, 3, 0,   5, 6, 7, 4,   9, 10, 11, 8,    13, 14, 15, 12));
                            case 16: return Avx2.mm256_shuffle_epi8(a, new v256(2, 3, 0, 1,   6, 7, 4, 5,   10, 11, 8, 9,    14, 15, 12, 13,    2, 3, 0, 1,   6, 7, 4, 5,   10, 11, 8, 9,    14, 15, 12, 13));
                            case 24: return Avx2.mm256_shuffle_epi8(a, new v256(3, 0, 1, 2,   7, 4, 5, 6,   11, 8, 9, 10,    15, 12, 13, 14,    3, 0, 1, 2,   7, 4, 5, 6,   11, 8, 9, 10,    15, 12, 13, 14));
                            default: break;
                        }
                    }

                    return Avx2.mm256_or_si256(mm256_srli_epi32(a, n), mm256_slli_epi32(a, 32 - n));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ror_epi64(v256 a, int n)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        switch (n)
                        {
                            case 0:  return a;
                            case 8:  return Avx2.mm256_shuffle_epi8(a, new v256(1, 2, 3, 4, 5, 6, 7, 0,   9, 10, 11, 12, 13, 14, 15, 8,   1, 2, 3, 4, 5, 6, 7, 0,   9, 10, 11, 12, 13, 14, 15, 8));
                            case 16: return Avx2.mm256_shuffle_epi8(a, new v256(2, 3, 4, 5, 6, 7, 0, 1,   10, 11, 12, 13, 14, 15, 8, 9,   2, 3, 4, 5, 6, 7, 0, 1,   10, 11, 12, 13, 14, 15, 8, 9));
                            case 24: return Avx2.mm256_shuffle_epi8(a, new v256(3, 4, 5, 6, 7, 0, 1, 2,   11, 12, 13, 14, 15, 8, 9, 10,   3, 4, 5, 6, 7, 0, 1, 2,   11, 12, 13, 14, 15, 8, 9, 10));
                            case 32: return Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(2, 3, 0, 1));
                            case 40: return Avx2.mm256_shuffle_epi8(a, new v256(5, 6, 7, 0, 1, 2, 3, 4,   13, 14, 15, 8, 9, 10, 11, 12,   5, 6, 7, 0, 1, 2, 3, 4,   13, 14, 15, 8, 9, 10, 11, 12));
                            case 48: return Avx2.mm256_shuffle_epi8(a, new v256(6, 7, 0, 1, 2, 3, 4, 5,   14, 15, 8, 9, 10, 11, 12, 13,   6, 7, 0, 1, 2, 3, 4, 5,   14, 15, 8, 9, 10, 11, 12, 13));
                            case 56: return Avx2.mm256_shuffle_epi8(a, new v256(7, 0, 1, 2, 3, 4, 5, 6,   15, 8, 9, 10, 11, 12, 13, 14,   7, 0, 1, 2, 3, 4, 5, 6,   15, 8, 9, 10, 11, 12, 13, 14));
                            default: break;
                        }
                    }

                    return Avx2.mm256_or_si256(mm256_srli_epi64(a, n), mm256_slli_epi64(a, 64 - n));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rol_epi8(v128 a, int n)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        switch (n)
                        {
                            case 0:  return a;
                            case 1:  return sub_epi8(slli_epi8(a, 1), cmpgt_epi8(setzero_si128(), a));
                            default: break;
                        }
                    }

                    return or_si128(slli_epi8(a, n, inRange: ROTATE_IN_RANGE), srli_epi8(a, 8 - n, inRange: ROTATE_IN_RANGE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rol_epi16(v128 a, int n)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        if (Architecture.IsTableLookupSupported)
                        {
                            switch (n)
                            {
                                case 0:  return a;
                                case 8:  return bswap_epi16(a);
                                default: break;
                            }
                        }
                    }

                    return or_si128(slli_epi16(a, n, inRange: ROTATE_IN_RANGE), srli_epi16(a, 16 - n, inRange: ROTATE_IN_RANGE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rol_epi32(v128 a, int n)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        if (Architecture.IsTableLookupSupported)
                        {
                            switch (n)
                            {
                                case 0:  return a;
                                case 8:  return shuffle_epi8(a, new v128(3, 0, 1, 2,   7, 4, 5, 6,   11, 8, 9, 10,    15, 12, 13, 14));
                                case 16: return shuffle_epi8(a, new v128(2, 3, 0, 1,   6, 7, 4, 5,   10, 11, 8, 9,    14, 15, 12, 13));
                                case 24: return shuffle_epi8(a, new v128(1, 2, 3, 0,   5, 6, 7, 4,   9, 10, 11, 8,    13, 14, 15, 12));
                                default: break;
                            }
                        }

                        if (n == 16)
                        {
                            return shufflelo_epi16(shufflehi_epi16(a, Sse.SHUFFLE(2, 3, 0, 1)), Sse.SHUFFLE(2, 3, 0, 1));
                        }
                    }

                    return or_si128(slli_epi32(a, n, inRange: ROTATE_IN_RANGE), srli_epi32(a, 32 - n, inRange: ROTATE_IN_RANGE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rol_epi64(v128 a, int n)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        if (n == 32)
                        {
                            return shuffle_epi32(a, Sse.SHUFFLE(2, 3, 0, 1));
                        }

                        if (Architecture.IsTableLookupSupported)
                        {
                            switch (n)
                            {
                                case 0:  return a;
                                case 8:  return shuffle_epi8(a, new v128(7, 0, 1, 2, 3, 4, 5, 6,   15, 8, 9, 10, 11, 12, 13, 14));
                                case 16: return shuffle_epi8(a, new v128(6, 7, 0, 1, 2, 3, 4, 5,   14, 15, 8, 9, 10, 11, 12, 13));
                                case 24: return shuffle_epi8(a, new v128(5, 6, 7, 0, 1, 2, 3, 4,   13, 14, 15, 8, 9, 10, 11, 12));
                                case 40: return shuffle_epi8(a, new v128(3, 4, 5, 6, 7, 0, 1, 2,   11, 12, 13, 14, 15, 8, 9, 10));
                                case 48: return shuffle_epi8(a, new v128(2, 3, 4, 5, 6, 7, 0, 1,   10, 11, 12, 13, 14, 15, 8, 9));
                                case 56: return shuffle_epi8(a, new v128(1, 2, 3, 4, 5, 6, 7, 0,   9, 10, 11, 12, 13, 14, 15, 8));
                                default: break;
                            }
                        }
                    }

                    return or_si128(slli_epi64(a, n, inRange: ROTATE_IN_RANGE), srli_epi64(a, 64 - n, inRange: ROTATE_IN_RANGE));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rol_epi8(v256 a, int n)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        switch (n)
                        {
                            case 0:  return a;
                            case 1:  return Avx2.mm256_sub_epi8(mm256_slli_epi8(a, 1), Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a));
                            default: break;
                        }
                    }

                    return Avx2.mm256_or_si256(mm256_slli_epi8(a, n), mm256_srli_epi8(a, 8 - n));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rol_epi16(v256 a, int n)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        switch (n)
                        {
                            case 0:  return a;
                            case 8:  return mm256_bswap_epi16(a);
                            default: break;
                        }
                    }

                    return Avx2.mm256_or_si256(mm256_slli_epi16(a, n), mm256_srli_epi16(a, 16 - n));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rol_epi32(v256 a, int n)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        switch (n)
                        {
                            case 0:  return a;
                            case 8:  return Avx2.mm256_shuffle_epi8(a, new v256(3, 0, 1, 2,   7, 4, 5, 6,   11, 8, 9, 10,    15, 12, 13, 14,   3, 0, 1, 2,   7, 4, 5, 6,   11, 8, 9, 10,    15, 12, 13, 14));
                            case 16: return Avx2.mm256_shuffle_epi8(a, new v256(2, 3, 0, 1,   6, 7, 4, 5,   10, 11, 8, 9,    14, 15, 12, 13,   2, 3, 0, 1,   6, 7, 4, 5,   10, 11, 8, 9,    14, 15, 12, 13));
                            case 24: return Avx2.mm256_shuffle_epi8(a, new v256(1, 2, 3, 0,   5, 6, 7, 4,   9, 10, 11, 8,    13, 14, 15, 12,   1, 2, 3, 0,   5, 6, 7, 4,   9, 10, 11, 8,    13, 14, 15, 12));
                            default: break;
                        }
                    }

                    return Avx2.mm256_or_si256(mm256_slli_epi32(a, n), mm256_srli_epi32(a, 32 - n));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rol_epi64(v256 a, int n)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(n))
                    {
                        switch (n)
                        {
                            case 0:  return a;
                            case 8:  return Avx2.mm256_shuffle_epi8(a, new v256(7, 0, 1, 2, 3, 4, 5, 6,   15, 8, 9, 10, 11, 12, 13, 14,   7, 0, 1, 2, 3, 4, 5, 6,   15, 8, 9, 10, 11, 12, 13, 14));
                            case 16: return Avx2.mm256_shuffle_epi8(a, new v256(6, 7, 0, 1, 2, 3, 4, 5,   14, 15, 8, 9, 10, 11, 12, 13,   6, 7, 0, 1, 2, 3, 4, 5,   14, 15, 8, 9, 10, 11, 12, 13));
                            case 24: return Avx2.mm256_shuffle_epi8(a, new v256(5, 6, 7, 0, 1, 2, 3, 4,   13, 14, 15, 8, 9, 10, 11, 12,   5, 6, 7, 0, 1, 2, 3, 4,   13, 14, 15, 8, 9, 10, 11, 12));
                            case 32: return Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(2, 3, 0, 1));
                            case 40: return Avx2.mm256_shuffle_epi8(a, new v256(3, 4, 5, 6, 7, 0, 1, 2,   11, 12, 13, 14, 15, 8, 9, 10,   3, 4, 5, 6, 7, 0, 1, 2,   11, 12, 13, 14, 15, 8, 9, 10));
                            case 48: return Avx2.mm256_shuffle_epi8(a, new v256(2, 3, 4, 5, 6, 7, 0, 1,   10, 11, 12, 13, 14, 15, 8, 9,   2, 3, 4, 5, 6, 7, 0, 1,   10, 11, 12, 13, 14, 15, 8, 9));
                            case 56: return Avx2.mm256_shuffle_epi8(a, new v256(1, 2, 3, 4, 5, 6, 7, 0,   9, 10, 11, 12, 13, 14, 15, 8,   1, 2, 3, 4, 5, 6, 7, 0,   9, 10, 11, 12, 13, 14, 15, 8));
                            default: break;
                        }
                    }

                    return Avx2.mm256_or_si256(mm256_slli_epi64(a, n), mm256_srli_epi64(a, 64 - n));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of rotating the bits of a <see cref="UInt128"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ror(UInt128 x, int n)
        {
            return (x >> n) | (x << (128 - n));
        }

        /// <summary>       Returns the result of rotating the bits of an <see cref="Int128"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ror(Int128 x, int n)
        {
            return (Int128)ror(x.value, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="byte"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ror(byte x, int n)
        {
            return (byte)((x >> n) | (x << (8 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ror(byte2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi8(x, n);
            }
            else
            {
                return new byte2(ror(x.x, n), ror(x.y, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ror(byte3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi8(x, n);
            }
            else
            {
                return new byte3(ror(x.x, n), ror(x.y, n), ror(x.z, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ror(byte4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi8(x, n);
            }
            else
            {
                return new byte4(ror(x.x, n), ror(x.y, n), ror(x.z, n), ror(x.w, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ror(byte8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi8(x, n);
            }
            else
            {
                return new byte8(ror(x.x0, n),
                                 ror(x.x1, n),
                                 ror(x.x2, n),
                                 ror(x.x3, n),
                                 ror(x.x4, n),
                                 ror(x.x5, n),
                                 ror(x.x6, n),
                                 ror(x.x7, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte16"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ror(byte16 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi8(x, n);
            }
            else
            {
                return new byte16(ror(x.x0,  n),
                                  ror(x.x1,  n),
                                  ror(x.x2,  n),
                                  ror(x.x3,  n),
                                  ror(x.x4,  n),
                                  ror(x.x5,  n),
                                  ror(x.x6,  n),
                                  ror(x.x7,  n),
                                  ror(x.x8,  n),
                                  ror(x.x9,  n),
                                  ror(x.x10, n),
                                  ror(x.x11, n),
                                  ror(x.x12, n),
                                  ror(x.x13, n),
                                  ror(x.x14, n),
                                  ror(x.x15, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte32"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ror(byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ror_epi8(x, n);
            }
            else
            {
                return new byte32(ror(x.v16_0, n), ror(x.v16_16, n));
            }
        }


        /// <summary>       Returns the result of rotating the bits of an <see cref="sbyte"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ror(sbyte x, int n)
        {
            return (sbyte)ror((byte)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ror(sbyte2 x, int n)
        {
            return (sbyte2)ror((byte2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ror(sbyte3 x, int n)
        {
            return (sbyte3)ror((byte3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ror(sbyte4 x, int n)
        {
            return (sbyte4)ror((byte4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ror(sbyte8 x, int n)
        {
            return (sbyte8)ror((byte8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte16"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ror(sbyte16 x, int n)
        {
            return (sbyte16)ror((byte16)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte32"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ror(sbyte32 x, int n)
        {
            return (sbyte32)ror((byte32)x, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="ushort"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ror(ushort x, int n)
        {
            return (ushort)((x >> n) | (x << (16 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ror(ushort2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi16(x, n);
            }
            else
            {
                return new ushort2(ror(x.x, n), ror(x.y, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ror(ushort3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi16(x, n);
            }
            else
            {
                return new ushort3(ror(x.x, n), ror(x.y, n), ror(x.z, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ror(ushort4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi16(x, n);
            }
            else
            {
                return new ushort4(ror(x.x, n), ror(x.y, n), ror(x.z, n), ror(x.w, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ror(ushort8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi16(x, n);
            }
            else
            {
                return new ushort8(ror(x.x0, n),
                                   ror(x.x1, n),
                                   ror(x.x2, n),
                                   ror(x.x3, n),
                                   ror(x.x4, n),
                                   ror(x.x5, n),
                                   ror(x.x6, n),
                                   ror(x.x7, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort16"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ror(ushort16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ror_epi16(x, n);
            }
            else
            {
                return new ushort16(ror(x.v8_0, n), ror(x.v8_8, n));
            }
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="short"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ror(short x, int n)
        {
            return (short)ror((ushort)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ror(short2 x, int n)
        {
            return (short2)ror((ushort2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ror(short3 x, int n)
        {
            return (short3)ror((ushort3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ror(short4 x, int n)
        {
            return (short4)ror((ushort4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ror(short8 x, int n)
        {
            return (short8)ror((ushort8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short16"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ror(short16 x, int n)
        {
            return (short16)ror((ushort16)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.uint8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ror_epi32(x, n);
            }
            else
            {
                return new uint8(math.ror(x.v4_0, n), math.ror(x.v4_4, n));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.int8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int n)
        {
            return (int8)ror((uint8)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ror_epi64(x, n);
            }
            else
            {
                return new ulong2(math.ror(x.x, n), math.ror(x.y, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ror_epi64(x, n);
            }
            else
            {
                return new ulong3(ror(x.xy, n), math.ror(x.z, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ror_epi64(x, n);
            }
            else
            {
                return new ulong4(ror(x.xy, n), ror(x.zw, n));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, int n)
        {
            return (long2)ror((ulong2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, int n)
        {
            return (long3)ror((ulong3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, int n)
        {
            return (long4)ror((ulong4)x, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="UInt128"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 rol(UInt128 x, int n)
        {
            return (x << n) | (x >> (128 - n));
        }

        /// <summary>       Returns the result of rotating the bits of an <see cref="Int128"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 rol(Int128 x, int n)
        {
            return (Int128)rol(x.value, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="byte"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte rol(byte x, int n)
        {
            return (byte)((x << n) | (x >> (8 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 rol(byte2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi8(x, n);
            }
            else
            {
                return new byte2(rol(x.x, n), rol(x.y, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 rol(byte3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi8(x, n);
            }
            else
            {
                return new byte3(rol(x.x, n), rol(x.y, n), rol(x.z, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 rol(byte4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi8(x, n);
            }
            else
            {
                return new byte4(rol(x.x, n), rol(x.y, n), rol(x.z, n), rol(x.w, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 rol(byte8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi8(x, n);
            }
            else
            {
                return new byte8(rol(x.x0, n),
                                 rol(x.x1, n),
                                 rol(x.x2, n),
                                 rol(x.x3, n),
                                 rol(x.x4, n),
                                 rol(x.x5, n),
                                 rol(x.x6, n),
                                 rol(x.x7, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte16"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 rol(byte16 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi8(x, n);
            }
            else
            {
                return new byte16(rol(x.x0,  n),
                                  rol(x.x1,  n),
                                  rol(x.x2,  n),
                                  rol(x.x3,  n),
                                  rol(x.x4,  n),
                                  rol(x.x5,  n),
                                  rol(x.x6,  n),
                                  rol(x.x7,  n),
                                  rol(x.x8,  n),
                                  rol(x.x9,  n),
                                  rol(x.x10, n),
                                  rol(x.x11, n),
                                  rol(x.x12, n),
                                  rol(x.x13, n),
                                  rol(x.x14, n),
                                  rol(x.x15, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte32"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 rol(byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rol_epi8(x, n);
            }
            else
            {
                return new byte32(rol(x.v16_0, n), rol(x.v16_16, n));
            }
        }


        /// <summary>       Returns the result of rotating the bits of an <see cref="sbyte"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte rol(sbyte x, int n)
        {
            return (sbyte)rol((byte)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 rol(sbyte2 x, int n)
        {
            return (sbyte2)rol((byte2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 rol(sbyte3 x, int n)
        {
            return (sbyte3)rol((byte3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 rol(sbyte4 x, int n)
        {
            return (sbyte4)rol((byte4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 rol(sbyte8 x, int n)
        {
            return (sbyte8)rol((byte8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte16"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 rol(sbyte16 x, int n)
        {
            return (sbyte16)rol((byte16)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte32"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 rol(sbyte32 x, int n)
        {
            return (sbyte32)rol((byte32)x, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="ushort"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort rol(ushort x, int n)
        {
            return (ushort)((x << n) | (x >> (16 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 rol(ushort2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi16(x, n);
            }
            else
            {
                return new ushort2(rol(x.x, n), rol(x.y, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 rol(ushort3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi16(x, n);
            }
            else
            {
                return new ushort3(rol(x.x, n), rol(x.y, n), rol(x.z, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 rol(ushort4 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi16(x, n);
            }
            else
            {
                return new ushort4(rol(x.x, n), rol(x.y, n), rol(x.z, n), rol(x.w, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 rol(ushort8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi16(x, n);
            }
            else
            {
                return new ushort8(rol(x.x0, n),
                                   rol(x.x1, n),
                                   rol(x.x2, n),
                                   rol(x.x3, n),
                                   rol(x.x4, n),
                                   rol(x.x5, n),
                                   rol(x.x6, n),
                                   rol(x.x7, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort16"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 rol(ushort16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rol_epi16(x, n);
            }
            else
            {
                return new ushort16(rol(x.v8_0, n), rol(x.v8_8, n));
            }
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="short"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short rol(short x, int n)
        {
            return (short)rol((ushort)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 rol(short2 x, int n)
        {
            return (short2)rol((ushort2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 rol(short3 x, int n)
        {
            return (short3)rol((ushort3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 rol(short4 x, int n)
        {
            return (short4)rol((ushort4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 rol(short8 x, int n)
        {
            return (short8)rol((ushort8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short16"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 rol(short16 x, int n)
        {
            return (short16)rol((ushort16)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.uint8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rol_epi32(x, n);
            }
            else
            {
                return new uint8(math.rol(x.v4_0, n), math.rol(x.v4_4, n));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.int8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, int n)
        {
            return (int8)rol((uint8)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rol_epi64(x, n);
            }
            else
            {
                return new ulong2(math.rol(x.x, n), math.rol(x.y, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rol_epi64(x, n);
            }
            else
            {
                return new ulong3(rol(x.xy, n), math.rol(x.z, n));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rol_epi64(x, n);
            }
            else
            {
                return new ulong4(rol(x.xy, n), rol(x.zw, n));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 rol(long2 x, int n)
        {
            return (long2)rol((ulong2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, int n)
        {
            return (long3)rol((ulong3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, int n)
        {
            return (long4)rol((ulong4)x, n);
        }
    }
}