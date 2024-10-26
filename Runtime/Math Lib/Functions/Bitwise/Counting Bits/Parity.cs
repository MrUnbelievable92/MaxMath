using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpe_epi8(v128 a)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    v128 MASK = new v128(-1, 0, 0, -1, 0, -1, -1, 0, 0, -1, -1, 0, -1, 0, 0, -1);

                    return shuffle_epi8(MASK, ternarylogic_si128(set1_epi8(0b0000_1111), a, srli_epi16(a, 4), TernaryOperation.Ox6O));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    a = xor_si128(a, srli_epi16(a, 4));
                    a = xor_si128(a, srli_epi16(a, 2));
                    a = xor_si128(a, srli_epi16(a, 1));

                    return cmpeq_epi8(and_si128(a, set1_epi8(1)), setzero_si128());
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpe_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MASK = new v256(-1, 0, 0, -1, 0, -1, -1, 0, 0, -1, -1, 0, -1, 0, 0, -1,
                                         -1, 0, 0, -1, 0, -1, -1, 0, 0, -1, -1, 0, -1, 0, 0, -1);

                    return Avx2.mm256_shuffle_epi8(MASK, mm256_ternarylogic_si256(mm256_set1_epi8(0b0000_1111), a, mm256_srli_epi16(a, 4), TernaryOperation.Ox6O));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpe_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    a = xor_si128(a, srli_epi16(a, 8));
                    a = bpe_epi8(a);

                    if (Architecture.IsTableLookupSupported)
                    {
                        return shuffle_epi8(a, new v128(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                    }
                    else
                    {
                        return neg_epi16(and_si128(a, set1_epi16(1)));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpe_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi16(a, 8));
                    a = mm256_bpe_epi8(a);

                    return Avx2.mm256_shuffle_epi8(a, new v256(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14,
                                                               0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpe_epi32(v128 a, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    a = xor_si128(a, srli_epi32(a, 16));
                    a = xor_si128(a, srli_epi16(a, 8));
                    a = bpe_epi8(a);

                    if (Architecture.IsTableLookupSupported)
                    {
                        return shuffle_epi8(a, new v128(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));
                    }
                    else
                    {
                        return neg_epi32(and_si128(a, set1_epi32(1)));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpe_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi32(a, 16));
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi16(a, 8));
                    a = mm256_bpe_epi8(a);

                    return Avx2.mm256_shuffle_epi8(a, new v256(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12,
                                                               0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpe_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    a = xor_si128(a, srli_epi64(a, 32));
                    a = xor_si128(a, srli_epi32(a, 16));
                    a = xor_si128(a, srli_epi16(a, 8));
                    a = bpe_epi8(a);

                    if (Architecture.IsTableLookupSupported)
                    {
                        return shuffle_epi8(a, new v128(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));
                    }
                    else
                    {
                        return neg_epi64(and_si128(a, set1_epi64x(1)));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpe_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi64(a, 32));
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi32(a, 16));
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi16(a, 8));
                    a = mm256_bpe_epi8(a);

                    return Avx2.mm256_shuffle_epi8(a, new v256(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8,
                                                               0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpo_epi8(v128 a)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    v128 MASK = new v128(0, -1, -1, 0, -1, 0, 0, -1, -1, 0, 0, -1, 0, -1, -1, 0);

                    return shuffle_epi8(MASK, ternarylogic_si128(set1_epi8(0b0000_1111), a, srli_epi16(a, 4), TernaryOperation.Ox6O));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    a = xor_si128(a, srli_epi16(a, 4));
                    a = xor_si128(a, srli_epi16(a, 2));
                    a = xor_si128(a, srli_epi16(a, 1));

                    return cmpeq_epi8(and_si128(a, set1_epi8(1)), set1_epi8(1));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpo_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MASK = new v256(0, -1, -1, 0, -1, 0, 0, -1, -1, 0, 0, -1, 0, -1, -1, 0,
                                         0, -1, -1, 0, -1, 0, 0, -1, -1, 0, 0, -1, 0, -1, -1, 0);

                    return Avx2.mm256_shuffle_epi8(MASK, mm256_ternarylogic_si256(mm256_set1_epi8(0b0000_1111), a, mm256_srli_epi16(a, 4), TernaryOperation.Ox6O));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpo_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    a = xor_si128(a, srli_epi16(a, 8));
                    a = bpo_epi8(a);

                    if (Architecture.IsTableLookupSupported)
                    {
                        return shuffle_epi8(a, new v128(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                    }
                    else
                    {
                        return neg_epi16(and_si128(a, set1_epi16(1)));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpo_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi16(a, 8));
                    a = mm256_bpo_epi8(a);

                    return Avx2.mm256_shuffle_epi8(a, new v256(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14,
                                                               0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpo_epi32(v128 a, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    a = xor_si128(a, srli_epi32(a, 16));
                    a = xor_si128(a, srli_epi16(a, 8));
                    a = bpo_epi8(a);

                    if (Architecture.IsTableLookupSupported)
                    {
                        return shuffle_epi8(a, new v128(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));
                    }
                    else
                    {
                        return neg_epi32(and_si128(a, set1_epi32(1)));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpo_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi32(a, 16));
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi16(a, 8));
                    a = mm256_bpo_epi8(a);

                    return Avx2.mm256_shuffle_epi8(a, new v256(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12,
                                                               0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpo_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    a = xor_si128(a, srli_epi64(a, 32));
                    a = xor_si128(a, srli_epi32(a, 16));
                    a = xor_si128(a, srli_epi16(a, 8));
                    a = bpo_epi8(a);

                    if (Architecture.IsTableLookupSupported)
                    {
                        return shuffle_epi8(a, new v128(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));
                    }
                    else
                    {
                        return neg_epi64(and_si128(a, set1_epi64x(1)));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpo_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi64(a, 32));
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi32(a, 16));
                    a = Avx2.mm256_xor_si256(a, mm256_srli_epi16(a, 8));
                    a = mm256_bpo_epi8(a);

                    return Avx2.mm256_shuffle_epi8(a, new v256(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8,
                                                               0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return (countbits(x) & 1) != 0;
            }
            else
            {
                x ^= (byte)(x >> 4);
                x ^= (byte)(x >> 2);
                x ^= (byte)(x >> 1);

                return (x & 1) != 0;
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityodd(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.bpo_epi8(x)));
            }
            else
            {
                return new bool2(parityodd(x.x), parityodd(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityodd(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.bpo_epi8(x)));
            }
            else
            {
                return new bool3(parityodd(x.x), parityodd(x.y), parityodd(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityodd(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.bpo_epi8(x)));
            }
            else
            {
                return new bool4(parityodd(x.x), parityodd(x.y), parityodd(x.z), parityodd(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityodd(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.bpo_epi8(x));
            }
            else
            {
                return new bool8(parityodd(x.x0), parityodd(x.x1), parityodd(x.x2), parityodd(x.x3), parityodd(x.x4), parityodd(x.x5), parityodd(x.x6), parityodd(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 parityodd(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.bpo_epi8(x));
            }
            else
            {
                return new bool16(parityodd(x.x0), parityodd(x.x1), parityodd(x.x2), parityodd(x.x3), parityodd(x.x4), parityodd(x.x5), parityodd(x.x6), parityodd(x.x7), parityodd(x.x8), parityodd(x.x9), parityodd(x.x10), parityodd(x.x11), parityodd(x.x12), parityodd(x.x13), parityodd(x.x14), parityodd(x.x15));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 parityodd(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_bpo_epi8(x));
            }
            else
            {
                return new bool32(parityodd(x.v16_0), parityodd(x.v16_16));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(ushort x)
        {
            x ^= (ushort)(x >> 8);

            return parityodd((byte)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityodd(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.bpo_epi16(x)));
            }
            else
            {
                return new bool2(parityodd(x.x), parityodd(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityodd(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.bpo_epi16(x)));
            }
            else
            {
                return new bool3(parityodd(x.x), parityodd(x.y), parityodd(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityodd(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.bpo_epi16(x)));
            }
            else
            {
                return new bool4(parityodd(x.x), parityodd(x.y), parityodd(x.z), parityodd(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityodd(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Xse.bpo_epi16(x));
            }
            else
            {
                return new bool8(parityodd(x.x0), parityodd(x.x1), parityodd(x.x2), parityodd(x.x3), parityodd(x.x4), parityodd(x.x5), parityodd(x.x6), parityodd(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 parityodd(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.mm256_bpo_epi16(x));
            }
            else
            {
                return new bool16(parityodd(x.v8_0), parityodd(x.v8_8));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(uint x)
        {
            x ^= x >> 16;

            return parityodd((ushort)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityodd(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue32(Xse.bpo_epi32(RegisterConversion.ToV128(x))));
            }
            else
            {
                return new bool2(parityodd(x.x), parityodd(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityodd(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(Xse.bpo_epi32(RegisterConversion.ToV128(x))));
            }
            else
            {
                return new bool3(parityodd(x.x), parityodd(x.y), parityodd(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityodd(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue32(Xse.bpo_epi32(RegisterConversion.ToV128(x))));
            }
            else
            {
                return new bool4(parityodd(x.x), parityodd(x.y), parityodd(x.z), parityodd(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityodd(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_bpo_epi32(x));
            }
            else
            {
                return new bool8(parityodd(x.v4_0), parityodd(x.v4_4));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(ulong x)
        {
            if (Architecture.IsPopcntSupported)
            {
                return (math.countbits(x) & 1) == 1;
            }
            else
            {
                x ^= x >> 32;

                return parityodd((uint)x);
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityodd(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.bpo_epi64(x)));
            }
            else
            {
                return new bool2(parityodd(x.x), parityodd(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityodd(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_bpo_epi64(x)));
            }
            else
            {
                return new bool3(parityodd(x.xy), parityodd(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityodd(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_bpo_epi64(x)));
            }
            else
            {
                return new bool4(parityodd(x.xy), parityodd(x.zw));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(UInt128 x)
        {
            return parityodd(x.lo64 ^ x.hi64);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(sbyte x)
        {
            return parityodd((byte)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityodd(sbyte2 x)
        {
            return parityodd((byte2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityodd(sbyte3 x)
        {
            return parityodd((byte3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityodd(sbyte4 x)
        {
            return parityodd((byte4)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityodd(sbyte8 x)
        {
            return parityodd((byte8)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 parityodd(sbyte16 x)
        {
            return parityodd((byte16)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 parityodd(sbyte32 x)
        {
            return parityodd((byte32)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(short x)
        {
            return parityodd((ushort)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityodd(short2 x)
        {
            return parityodd((ushort2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityodd(short3 x)
        {
            return parityodd((ushort3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityodd(short4 x)
        {
            return parityodd((ushort4)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityodd(short8 x)
        {
            return parityodd((ushort8)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 parityodd(short16 x)
        {
            return parityodd((ushort16)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(int x)
        {
            return parityodd((uint)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityodd(int2 x)
        {
            return parityodd((uint2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityodd(int3 x)
        {
            return parityodd((uint3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityodd(int4 x)
        {
            return parityodd((uint4)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityodd(int8 x)
        {
            return parityodd((uint8)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(long x)
        {
            return parityodd((ulong)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityodd(long2 x)
        {
            return parityodd((ulong2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityodd(long3 x)
        {
            return parityodd((ulong3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityodd(long4 x)
        {
            return parityodd((ulong4)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(Int128 x)
        {
            return parityodd((UInt128)x);
        }
        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return (countbits(x) & 1) == 0;
            }
            else
            {
                x ^= (byte)(x >> 4);
                x ^= (byte)(x >> 2);
                x ^= (byte)(x >> 1);

                return (x & 1) == 0;
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityeven(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.bpe_epi8(x)));
            }
            else
            {
                return new bool2(parityeven(x.x), parityeven(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityeven(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.bpe_epi8(x)));
            }
            else
            {
                return new bool3(parityeven(x.x), parityeven(x.y), parityeven(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityeven(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.bpe_epi8(x)));
            }
            else
            {
                return new bool4(parityeven(x.x), parityeven(x.y), parityeven(x.z), parityeven(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityeven(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.bpe_epi8(x));
            }
            else
            {
                return new bool8(parityeven(x.x0), parityeven(x.x1), parityeven(x.x2), parityeven(x.x3), parityeven(x.x4), parityeven(x.x5), parityeven(x.x6), parityeven(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 parityeven(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.bpe_epi8(x));
            }
            else
            {
                return new bool16(parityeven(x.x0), parityeven(x.x1), parityeven(x.x2), parityeven(x.x3), parityeven(x.x4), parityeven(x.x5), parityeven(x.x6), parityeven(x.x7), parityeven(x.x8), parityeven(x.x9), parityeven(x.x10), parityeven(x.x11), parityeven(x.x12), parityeven(x.x13), parityeven(x.x14), parityeven(x.x15));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 parityeven(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_bpe_epi8(x));
            }
            else
            {
                return new bool32(parityeven(x.v16_0), parityeven(x.v16_16));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(ushort x)
        {
            x ^= (ushort)(x >> 8);

            return parityeven((byte)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityeven(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.bpe_epi16(x)));
            }
            else
            {
                return new bool2(parityeven(x.x), parityeven(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityeven(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.bpe_epi16(x)));
            }
            else
            {
                return new bool3(parityeven(x.x), parityeven(x.y), parityeven(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityeven(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.bpe_epi16(x)));
            }
            else
            {
                return new bool4(parityeven(x.x), parityeven(x.y), parityeven(x.z), parityeven(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityeven(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Xse.bpe_epi16(x));
            }
            else
            {
                return new bool8(parityeven(x.x0), parityeven(x.x1), parityeven(x.x2), parityeven(x.x3), parityeven(x.x4), parityeven(x.x5), parityeven(x.x6), parityeven(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 parityeven(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.mm256_bpe_epi16(x));
            }
            else
            {
                return new bool16(parityeven(x.v8_0), parityeven(x.v8_8));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(uint x)
        {
            x ^= x >> 16;

            return parityeven((ushort)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityeven(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue32(Xse.bpe_epi32(RegisterConversion.ToV128(x))));
            }
            else
            {
                return new bool2(parityeven(x.x), parityeven(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityeven(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(Xse.bpe_epi32(RegisterConversion.ToV128(x))));
            }
            else
            {
                return new bool3(parityeven(x.x), parityeven(x.y), parityeven(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityeven(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue32(Xse.bpe_epi32(RegisterConversion.ToV128(x))));
            }
            else
            {
                return new bool4(parityeven(x.x), parityeven(x.y), parityeven(x.z), parityeven(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityeven(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_bpe_epi32(x));
            }
            else
            {
                return new bool8(parityeven(x.v4_0), parityeven(x.v4_4));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(ulong x)
        {
            if (Architecture.IsPopcntSupported)
            {
                return (math.countbits(x) & 1) == 0;
            }
            else
            {
                x ^= x >> 32;

                return parityeven((uint)x);
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityeven(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.bpe_epi64(x)));
            }
            else
            {
                return new bool2(parityeven(x.x), parityeven(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityeven(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_bpe_epi64(x)));
            }
            else
            {
                return new bool3(parityeven(x.xy), parityeven(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityeven(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_bpe_epi64(x)));
            }
            else
            {
                return new bool4(parityeven(x.xy), parityeven(x.zw));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(UInt128 x)
        {
            return parityeven(x.lo64 ^ x.hi64);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(sbyte x)
        {
            return parityeven((byte)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityeven(sbyte2 x)
        {
            return parityeven((byte2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityeven(sbyte3 x)
        {
            return parityeven((byte3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityeven(sbyte4 x)
        {
            return parityeven((byte4)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityeven(sbyte8 x)
        {
            return parityeven((byte8)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 parityeven(sbyte16 x)
        {
            return parityeven((byte16)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 parityeven(sbyte32 x)
        {
            return parityeven((byte32)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(short x)
        {
            return parityeven((ushort)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityeven(short2 x)
        {
            return parityeven((ushort2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityeven(short3 x)
        {
            return parityeven((ushort3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityeven(short4 x)
        {
            return parityeven((ushort4)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityeven(short8 x)
        {
            return parityeven((ushort8)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 parityeven(short16 x)
        {
            return parityeven((ushort16)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(int x)
        {
            return parityeven((uint)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityeven(int2 x)
        {
            return parityeven((uint2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityeven(int3 x)
        {
            return parityeven((uint3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityeven(int4 x)
        {
            return parityeven((uint4)x);
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 parityeven(int8 x)
        {
            return parityeven((uint8)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(long x)
        {
            return parityeven((ulong)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 parityeven(long2 x)
        {
            return parityeven((ulong2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 parityeven(long3 x)
        {
            return parityeven((ulong3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 parityeven(long4 x)
        {
            return parityeven((ulong4)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(Int128 x)
        {
            return parityeven((UInt128)x);
        }
    }
}
