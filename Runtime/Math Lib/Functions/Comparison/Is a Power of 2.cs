using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false" />.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(UInt128 x)
        {
            if (Unity.Burst.Intrinsics.Arm.Neon.IsNeonSupported)
            {
                return countbits(x) == 1;
            }
            else if (Popcnt.IsPopcntSupported)
            {
                return countbits(x) == 1;
            }
            else
            {
                return x.IsNotZero & (bits_resetlowest(x) == 0);
            }
        }

        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false" />.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(Int128 x)
        {
            return (x > 0) & (bits_resetlowest(x) == 0);
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false" />.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(byte x)
        {
            return (x != 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();

                return RegisterConversion.IsTrue8<bool2>(Sse2.andnot_si128(Sse2.cmpeq_epi8(x, ZERO),
                                                                           Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool2(math.ispow2((uint)x.x), math.ispow2((uint)x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue8<bool3>(Sse2.andnot_si128(Sse2.cmpeq_epi8(x, ZERO),
                                                                           Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool3(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue8<bool4>(Sse2.andnot_si128(Sse2.cmpeq_epi8(x, ZERO),
                                                                           Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool4(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z), math.ispow2((uint)x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue8<bool8>(Sse2.andnot_si128(Sse2.cmpeq_epi8(x, ZERO),
                                                                           Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool8(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue8<bool16>(Sse2.andnot_si128(Sse2.cmpeq_epi8(x, ZERO),
                                                                            Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool16(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7), math.ispow2((uint)x.x8), math.ispow2((uint)x.x9), math.ispow2((uint)x.x10), math.ispow2((uint)x.x11), math.ispow2((uint)x.x12), math.ispow2((uint)x.x13), math.ispow2((uint)x.x14), math.ispow2((uint)x.x15));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 ispow2(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();
                
                return RegisterConversion.IsTrue8(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(x, ZERO),
                                                                     Avx2.mm256_cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool32(ispow2(x.v16_0), ispow2(x.v16_16));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false" />.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(sbyte x)
        {
            return (x > 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();

                return RegisterConversion.IsTrue8<bool2>(Sse2.and_si128(Sse2.cmpgt_epi8(x, ZERO),
                                                                        Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool2(math.ispow2(x.x), math.ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue8<bool3>(Sse2.and_si128(Sse2.cmpgt_epi8(x, ZERO),
                                                                        Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool3(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue8<bool4>(Sse2.and_si128(Sse2.cmpgt_epi8(x, ZERO),
                                                                        Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool4(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z), math.ispow2(x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(sbyte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue8<bool8>(Sse2.and_si128(Sse2.cmpgt_epi8(x, ZERO),
                                                                        Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool8(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue8<bool16>(Sse2.and_si128(Sse2.cmpgt_epi8(x, ZERO),
                                                                         Sse2.cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool16(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7), math.ispow2(x.x8), math.ispow2(x.x9), math.ispow2(x.x10), math.ispow2(x.x11), math.ispow2(x.x12), math.ispow2(x.x13), math.ispow2(x.x14), math.ispow2(x.x15));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 ispow2(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();
                
                return RegisterConversion.IsTrue8(Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi8(x, ZERO),
                                                                  Avx2.mm256_cmpeq_epi8(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool32(ispow2(x.v16_0), ispow2(x.v16_16));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false" />.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ushort x)
        {
            return (x != 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue16<bool2>(Sse2.andnot_si128(Sse2.cmpeq_epi16(x, ZERO),
                                                                            Sse2.cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool2(math.ispow2((uint)x.x), math.ispow2((uint)x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue16<bool3>(Sse2.andnot_si128(Sse2.cmpeq_epi16(x, ZERO),
                                                                            Sse2.cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool3(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue16<bool4>(Sse2.andnot_si128(Sse2.cmpeq_epi16(x, ZERO),
                                                                            Sse2.cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool4(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z), math.ispow2((uint)x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue16<bool8>(Sse2.andnot_si128(Sse2.cmpeq_epi16(x, ZERO),
                                                                            Sse2.cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool8(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();
                
                return RegisterConversion.IsTrue16(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi16(x, ZERO),
                                                                           Avx2.mm256_cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else 
            {
                return new bool16(ispow2(x.v8_0), ispow2(x.v8_8));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false" />.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(short x)
        {
            return (x > 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue16<bool2>(Sse2.and_si128(Sse2.cmpgt_epi16(x, ZERO),
                                                                        Sse2.cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool2(math.ispow2(x.x), math.ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue16<bool3>(Sse2.and_si128(Sse2.cmpgt_epi16(x, ZERO),
                                                                         Sse2.cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool3(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue16<bool4>(Sse2.and_si128(Sse2.cmpgt_epi16(x, ZERO),
                                                                         Sse2.cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool4(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z), math.ispow2(x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue16<bool8>(Sse2.and_si128(Sse2.cmpgt_epi16(x, ZERO),
                                                                         Sse2.cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool8(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();

                return RegisterConversion.IsTrue16(Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi16(x, ZERO),
                                                                   Avx2.mm256_cmpeq_epi16(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool16(ispow2(x.v8_0), ispow2(x.v8_8));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();

                return RegisterConversion.IsTrue32(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(x, ZERO),
                                                                      Avx2.mm256_cmpeq_epi32(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool8(math.ispow2(x.v4_0), math.ispow2(x.v4_4));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();

                return RegisterConversion.IsTrue32(Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi32(x, ZERO),
                                                                   Avx2.mm256_cmpeq_epi32(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool8(math.ispow2(x.v4_0), math.ispow2(x.v4_4));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false" />.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ulong x)
        {
            return (x != 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue64<bool2>(Sse2.andnot_si128(Xse.cmpeq_epi64(x, ZERO),
                                                                            Xse.cmpeq_epi64(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool2(ispow2(x.x), ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();

                return RegisterConversion.IsTrue64<bool3>(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(x, ZERO),
                                                                                  Avx2.mm256_cmpeq_epi64(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool3(ispow2(x.xy), ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();
                
                return RegisterConversion.IsTrue64<bool4>(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(x, ZERO),
                                                                                  Avx2.mm256_cmpeq_epi64(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool4(ispow2(x.xy), ispow2(x.zw));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false" />.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(long x)
        {
            return (x > 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                
                return RegisterConversion.IsTrue64<bool2>(Sse2.and_si128(Xse.cmpgt_epi64(x, ZERO),
                                                                         Xse.cmpeq_epi64(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool2(ispow2(x.x), ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();
                
                return RegisterConversion.IsTrue64<bool3>(Avx2.mm256_and_si256(Xse.mm256_cmpgt_epi64(x, ZERO, 3),
                                                                               Avx2.mm256_cmpeq_epi64(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool3(ispow2(x.xy), ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false" /> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Xse.mm256_setall_si256();
                
                return RegisterConversion.IsTrue64<bool4>(Avx2.mm256_and_si256(Xse.mm256_cmpgt_epi64(x, ZERO, 4),
                                                                               Avx2.mm256_cmpeq_epi64(ZERO, x & (x + ALL_ONES))));
            }
            else
            {
                return new bool4(ispow2(x.xy), ispow2(x.zw));
            }
        }
    }
}