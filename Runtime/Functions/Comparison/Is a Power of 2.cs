using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.and_si128(Sse2.and_si128(Operator.greater_mask_byte(x, default(v128)),
                                                            Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                             new byte16(1));
                return *(bool2*)&result;
            }
            else
            {
                return new bool2(math.ispow2((uint)x.x), math.ispow2((uint)x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.and_si128(Sse2.and_si128(Operator.greater_mask_byte(x, default(v128)),
                                                            Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                             new byte16(1));
                return *(bool3*)&result;
            }
            else
            {
                return new bool3(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.and_si128(Sse2.and_si128(Operator.greater_mask_byte(x, default(v128)),
                                                            Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                             new byte16(1));
                return *(bool4*)&result;
            }
            else
            {
                return new bool4(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z), math.ispow2((uint)x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(Sse2.and_si128(Operator.greater_mask_byte(x, byte8.zero),
                                                     Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                      new byte16(1));
            }
            else
            {
                return new bool8(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(Sse2.and_si128(Operator.greater_mask_byte(x, byte16.zero),
                                                     Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                      new byte16(1));
            }
            else
            {
                return new bool16(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7), math.ispow2((uint)x.x8), math.ispow2((uint)x.x9), math.ispow2((uint)x.x10), math.ispow2((uint)x.x11), math.ispow2((uint)x.x12), math.ispow2((uint)x.x13), math.ispow2((uint)x.x14), math.ispow2((uint)x.x15));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 ispow2(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(Avx2.mm256_and_si256(Operator.greater_mask_byte(x, default(v256)),
                                                                 Avx2.mm256_cmpeq_epi8(default(v256), x & (x - 1))),
                                            new byte32(1));
            }
            else
            {
                return new bool32(ispow2(x.v16_0), ispow2(x.v16_16));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of x is less than or equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.and_si128(Sse2.and_si128(Sse2.cmpgt_epi8(x, default(v128)),
                                                            Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                             new sbyte16(1));
                return *(bool2*)&result;
            }
            else
            {
                return new bool2(math.ispow2(x.x), math.ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is less than or equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.and_si128(Sse2.and_si128(Sse2.cmpgt_epi8(x, default(v128)),
                                                            Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                             new sbyte16(1));
                return *(bool3*)&result;
            }
            else
            {
                return new bool3(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is less than or equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.and_si128(Sse2.and_si128(Sse2.cmpgt_epi8(x, default(v128)),
                                                            Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                             new sbyte16(1));
                return *(bool4*)&result;
            }
            else
            {
                return new bool4(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z), math.ispow2(x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is less than or equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(sbyte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(Sse2.and_si128(Sse2.cmpgt_epi8(x, default(v128)),
                                                     Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                      new sbyte16(1));
            }
            else
            {
                return new bool8(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is less than or equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(Sse2.and_si128(Sse2.cmpgt_epi8(x, default(v128)),
                                                     Sse2.cmpeq_epi8(default(v128), x & (x - 1))),
                                      new sbyte16(1));
            }
            else
            {
                return new bool16(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7), math.ispow2(x.x8), math.ispow2(x.x9), math.ispow2(x.x10), math.ispow2(x.x11), math.ispow2(x.x12), math.ispow2(x.x13), math.ispow2(x.x14), math.ispow2(x.x15));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is less than or equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 ispow2(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi8(x, default(v256)),
                                                                 Avx2.mm256_cmpeq_epi8(default(v256), x & (x - 1))),
                                            new sbyte32(1));
            }
            else
            {
                return new bool32(ispow2(x.v16_0), ispow2(x.v16_16));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = (byte2)(new ushort2(1) & Sse2.and_si128(Operator.greater_mask_ushort(x, default(v128)),
                                                                      Sse2.cmpeq_epi16(default(v128), x & (x - 1))));
                return *(bool2*)&result;
            }
            else
            {
                return new bool2(math.ispow2((uint)x.x), math.ispow2((uint)x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = (byte3)(new ushort3(1) & Sse2.and_si128(Operator.greater_mask_ushort(x, default(v128)),
                                                                      Sse2.cmpeq_epi16(default(v128), x & (x - 1))));
                return *(bool3*)&result;
            }
            else
            {
                return new bool3(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = (byte4)(new ushort4(1) & Sse2.and_si128(Operator.greater_mask_ushort(x, default(v128)),
                                                                      Sse2.cmpeq_epi16(default(v128), x & (x - 1))));
                return *(bool4*)&result;
            }
            else
            {
                return new bool4(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z), math.ispow2((uint)x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)(byte8)(new ushort8(1) & Sse2.and_si128(Operator.greater_mask_ushort(x, default(v128)),
                                                                     Sse2.cmpeq_epi16(default(v128), x & (x - 1))));
            }
            else
            {
                return new bool8(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v128)(new byte16(1) & (byte16)(ushort16)Avx2.mm256_and_si256(Operator.greater_mask_ushort(x, default(v256)),
                                                                                     Avx2.mm256_cmpeq_epi16(default(v256), x & (x - 1))));
            }
            else 
            {
                return new bool16(ispow2(x.v8_0), ispow2(x.v8_8));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = (byte2)(new short2(1) & Sse2.and_si128(Sse2.cmpgt_epi16(x, default(v128)),
                                                                     Sse2.cmpeq_epi16(default(v128), x & (x - 1))));
                return *(bool2*)&result;
            }
            else
            {
                return new bool2(math.ispow2(x.x), math.ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = (byte3)(new short3(1) & Sse2.and_si128(Sse2.cmpgt_epi16(x, default(v128)),
                                                                     Sse2.cmpeq_epi16(default(v128), x & (x - 1))));
                return *(bool3*)&result;
            }
            else
            {
                return new bool3(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result = (byte4)(new short4(1) & Sse2.and_si128(Sse2.cmpgt_epi16(x, default(v128)),
                                                                     Sse2.cmpeq_epi16(default(v128), x & (x - 1))));
                return *(bool4*)&result;
            }
            else
            {
                return new bool4(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z), math.ispow2(x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)(byte8)(new short8(1) & Sse2.and_si128(Sse2.cmpgt_epi16(x, default(v128)),
                                                                    Sse2.cmpeq_epi16(default(v128), x & (x - 1))));
            }
            else
            {
                return new bool8(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v128)(new byte16(1) & (byte16)(short16)Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi16(x, default(v256)),
                                                                                    Avx2.mm256_cmpeq_epi16(default(v256), x & (x - 1))));
            }
            else
            {
                return new bool16(ispow2(x.v8_0), ispow2(x.v8_8));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v128)(new byte8(1) & (byte8)(uint8)Avx2.mm256_and_si256(Operator.greater_mask_uint(x, default(v256)),
                                                                                Avx2.mm256_cmpeq_epi32(default(v256), x & (x - 1))));
            }
            else
            {
                return new bool8(math.ispow2(x.v4_0), math.ispow2(x.v4_4));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v128)(new byte8(1) & (byte8)(int8)Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi32(x, default(v256)),
                                                                               Avx2.mm256_cmpeq_epi32(default(v256), x & (x - 1))));
            }
            else
            {
                return new bool8(math.ispow2(x.v4_0), math.ispow2(x.v4_4));
            }
        }


        /// <summary>       Checks if the input is a power of two. If x is equal to zero, then this function returns false.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ulong x)
        {
            return (x > 0) & (blsr(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(ulong2 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                v128 result = (byte2)(new ulong2(1) & Sse2.and_si128(Operator.greater_mask_ulong(x, default(v128)),
                                                                     Sse4_1.cmpeq_epi64(default(v128), x & (x - 1))));
                return *(bool2*)&result;
            }
            else
            {
                return new bool2(ispow2(x.x), ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = new byte3(1) & ((byte3)(ulong3)Avx2.mm256_and_si256(Operator.greater_mask_ulong(x, default(v256)),
                                                                                  Avx2.mm256_cmpeq_epi64(default(v256), x & (x - 1))));
                return *(bool3*)&result;
            }
            else
            {
                return new bool3(ispow2(x.xy), ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = new byte4(1) & ((byte4)(long4)Avx2.mm256_and_si256(Operator.greater_mask_ulong(x, default(v256)),
                                                                                 Avx2.mm256_cmpeq_epi64(default(v256), x & (x - 1))));
                return *(bool4*)&result;
            }
            else
            {
                return new bool4(ispow2(x.xy), ispow2(x.zw));
            }
        }


        /// <summary>       Checks if the input is a power of two. If x is equal to zero, then this function returns false.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(long x)
        {
            return (x > 0) & (blsr(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(long2 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                v128 result = (byte2)(new long2(1) & Sse2.and_si128(Sse4_2.cmpgt_epi64(x, default(v128)),
                                                                    Sse4_1.cmpeq_epi64(default(v128), x & (x - 1))));
                return *(bool2*)&result;
            }
            else
            {
                return new bool2(ispow2(x.x), ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = new byte3(1) & ((byte3)(ulong3)Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(x, default(v256)),
                                                                                  Avx2.mm256_cmpeq_epi64(default(v256), x & (x - 1))));
                return *(bool3*)&result;
            }
            else
            {
                return new bool3(ispow2(x.xy), ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of x is equal to zero, then this function returns false in that component.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = new byte4(1) & ((byte4)(ulong4)Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(x, default(v256)),
                                                                                  Avx2.mm256_cmpeq_epi64(default(v256), x & (x - 1))));
                return *(bool4*)&result;
            }
            else
            {
                return new bool4(ispow2(x.xy), ispow2(x.zw));
            }
        }
    }
}