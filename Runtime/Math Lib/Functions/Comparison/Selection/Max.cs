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
            public static v128 max_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.max_epi8(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_GE_EPI8(a, 0, elements) && constexpr.ALL_GE_EPI8(b, 0, elements))
                    {
                        return Sse2.max_epu8(a, b);
                    }
                    else
                    {
                        return blendv_si128(a, b, Sse2.cmpgt_epi8(b, a));
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epi32(v128 a, v128 b)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.max_epi32(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(a, b, Sse2.cmpgt_epi32(b, a));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epi64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_GE_EPI64(a, int.MinValue) && constexpr.ALL_GE_EPI64(b, int.MinValue) && constexpr.ALL_LE_EPI64(a, int.MaxValue) && constexpr.ALL_LE_EPI64(b, int.MaxValue))
                    {
                        return max_epi32(a, b);
                    }

                    return blendv_si128(a, b, cmpgt_epi64(b, a));
                }
                else throw new IllegalInstructionException();
            }
            
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_max_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_GE_EPI64(a, int.MinValue, elements) && constexpr.ALL_GE_EPI64(b, int.MinValue, elements) && constexpr.ALL_LE_EPI64(a, int.MaxValue, elements) && constexpr.ALL_LE_EPI64(b, int.MaxValue, elements))
                    {
                        return Avx2.mm256_max_epi32(a, b);
                    }

                    return mm256_blendv_si256(a, b, mm256_cmpgt_epi64(b, a, elements));
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epu16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.max_epu16(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue, elements))
                    {
                        return Sse2.max_epi16(a, b);
                    }
                    else
                    {
                        ushort8 mask = 1 << 15;
    
                        return Sse2.xor_si128(mask,
                                              Sse2.max_epi16(Sse2.xor_si128(a, mask),
                                                             Sse2.xor_si128(b, mask)));
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.max_epu32(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(a, b, cmpgt_epu32(b, a, elements));
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epu64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue) && constexpr.ALL_LE_EPU64(b, uint.MaxValue))
                    {
                        return max_epu32(a, b);
                    }

                    return blendv_si128(a, b, cmpgt_epu64(b, a));
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_max_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements) && constexpr.ALL_LE_EPU64(b, uint.MaxValue, elements))
                    {
                        return Avx2.mm256_max_epu32(a, b);
                    }

                    return mm256_blendv_si256(a, b, mm256_cmpgt_epu64(b, a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the maximum of two <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 max(UInt128 a, UInt128 b)
        {
            return select(b, a, a > b);
        }

        /// <summary>       Returns the maximum of two <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 max(Int128 a, Int128 b)
        {
            return select(b, a, a > b);
        }


        /// <summary>       Returns the maximum of two <see cref="byte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte max(byte a, byte b)
        {
            return a > b ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 max(byte2 a, byte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte2((byte)math.max((uint)a.x, (uint)b.x), (byte)math.max((uint)a.y, (uint)b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 max(byte3 a, byte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte3((byte)math.max((uint)a.x, (uint)b.x), (byte)math.max((uint)a.y, (uint)b.y), (byte)math.max((uint)a.z, (uint)b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 max(byte4 a, byte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte4((byte)math.max((uint)a.x, (uint)b.x), (byte)math.max((uint)a.y, (uint)b.y), (byte)math.max((uint)a.z, (uint)b.z), (byte)math.max((uint)a.w, (uint)b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 max(byte8 a, byte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte8((byte)math.max((uint)a.x0, (uint)b.x0), (byte)math.max((uint)a.x1, (uint)b.x1), (byte)math.max((uint)a.x2, (uint)b.x2), (byte)math.max((uint)a.x3, (uint)b.x3), (byte)math.max((uint)a.x4, (uint)b.x4), (byte)math.max((uint)a.x5, (uint)b.x5), (byte)math.max((uint)a.x6, (uint)b.x6), (byte)math.max((uint)a.x7, (uint)b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 max(byte16 a, byte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte16((byte)math.max((uint)a.x0, (uint)b.x0), (byte)math.max((uint)a.x1, (uint)b.x1), (byte)math.max((uint)a.x2, (uint)b.x2), (byte)math.max((uint)a.x3, (uint)b.x3), (byte)math.max((uint)a.x4, (uint)b.x4), (byte)math.max((uint)a.x5, (uint)b.x5), (byte)math.max((uint)a.x6, (uint)b.x6), (byte)math.max((uint)a.x7, (uint)b.x7), (byte)math.max((uint)a.x8, (uint)b.x8), (byte)math.max((uint)a.x9, (uint)b.x9), (byte)math.max((uint)a.x10, (uint)b.x10), (byte)math.max((uint)a.x11, (uint)b.x11), (byte)math.max((uint)a.x12, (uint)b.x12), (byte)math.max((uint)a.x13, (uint)b.x13), (byte)math.max((uint)a.x14, (uint)b.x14), (byte)math.max((uint)a.x15, (uint)b.x15));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 max(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu8(a, b);
            }
            else
            {
                return new byte32(max(a.v16_0, b.v16_0), max(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="sbyte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte max(sbyte a, sbyte b)
        {
            return a > b ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 max(sbyte2 a, sbyte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epi8(a, b, 2);
            }
            else
            {
                return new sbyte2((sbyte)math.max(a.x, b.x), (sbyte)math.max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 max(sbyte3 a, sbyte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epi8(a, b, 3);
            }
            else
            {
                return new sbyte3((sbyte)math.max(a.x, b.x), (sbyte)math.max(a.y, b.y), (sbyte)math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 max(sbyte4 a, sbyte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epi8(a, b, 4);
            }
            else
            {
                return new sbyte4((sbyte)math.max(a.x, b.x), (sbyte)math.max(a.y, b.y), (sbyte)math.max(a.z, b.z), (sbyte)math.max(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 max(sbyte8 a, sbyte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epi8(a, b, 8);
            }
            else
            {
                return new sbyte8((sbyte)math.max(a.x0, b.x0), (sbyte)math.max(a.x1, b.x1), (sbyte)math.max(a.x2, b.x2), (sbyte)math.max(a.x3, b.x3), (sbyte)math.max(a.x4, b.x4), (sbyte)math.max(a.x5, b.x5), (sbyte)math.max(a.x6, b.x6), (sbyte)math.max(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 max(sbyte16 a, sbyte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epi8(a, b, 16);
            }
            else
            {
                return new sbyte16((sbyte)math.max(a.x0, b.x0), (sbyte)math.max(a.x1, b.x1), (sbyte)math.max(a.x2, b.x2), (sbyte)math.max(a.x3, b.x3), (sbyte)math.max(a.x4, b.x4), (sbyte)math.max(a.x5, b.x5), (sbyte)math.max(a.x6, b.x6), (sbyte)math.max(a.x7, b.x7), (sbyte)math.max(a.x8, b.x8), (sbyte)math.max(a.x9, b.x9), (sbyte)math.max(a.x10, b.x10), (sbyte)math.max(a.x11, b.x11), (sbyte)math.max(a.x12, b.x12), (sbyte)math.max(a.x13, b.x13), (sbyte)math.max(a.x14, b.x14), (sbyte)math.max(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 max(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi8(a, b);
            }
            else
            {
                return new sbyte32(max(a.v16_0, b.v16_0), max(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="ushort"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort max(ushort a, ushort b)
        {
            return a > b ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 max(ushort2 a, ushort2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epu16(a, b, 2);
            }
            else
            {
                return new ushort2((ushort)math.max((uint)a.x, (uint)b.x), (ushort)math.max((uint)a.y, (uint)b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 max(ushort3 a, ushort3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epu16(a, b, 3);
            }
            else
            {
                return new ushort3((ushort)math.max((uint)a.x, (uint)b.x), (ushort)math.max((uint)a.y, (uint)b.y), (ushort)math.max((uint)a.z, (uint)b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 max(ushort4 a, ushort4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epu16(a, b, 4);
            }
            else
            {
                return new ushort4((ushort)math.max((uint)a.x, (uint)b.x), (ushort)math.max((uint)a.y, (uint)b.y), (ushort)math.max((uint)a.z, (uint)b.z), (ushort)math.max((uint)a.w, (uint)b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 max(ushort8 a, ushort8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epu16(a, b, 8);
            }
            else
            {
                return new ushort8((ushort)math.max((uint)a.x0, (uint)b.x0), (ushort)math.max((uint)a.x1, (uint)b.x1), (ushort)math.max((uint)a.x2, (uint)b.x2), (ushort)math.max((uint)a.x3, (uint)b.x3), (ushort)math.max((uint)a.x4, (uint)b.x4), (ushort)math.max((uint)a.x5, (uint)b.x5), (ushort)math.max((uint)a.x6, (uint)b.x6), (ushort)math.max((uint)a.x7, (uint)b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 max(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu16(a, b);
            }
            else
            {
                return new ushort16(max(a.v8_0, b.v8_0), max(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="short"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short max(short a, short b)
        {
            return a > b ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 max(short2 a, short2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(a, b);
            }
            else
            {
                return new short2((short)math.max(a.x, b.x), (short)math.max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 max(short3 a, short3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(a, b);
            }
            else
            {
                return new short3((short)math.max(a.x, b.x), (short)math.max(a.y, b.y), (short)math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 max(short4 a, short4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(a, b);
            }
            else
            {
                return new short4((short)math.max(a.x, b.x), (short)math.max(a.y, b.y), (short)math.max(a.z, b.z), (short)math.max(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 max(short8 a, short8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(a, b);
            }
            else
            {
                return new short8((short)math.max(a.x0, b.x0), (short)math.max(a.x1, b.x1), (short)math.max(a.x2, b.x2), (short)math.max(a.x3, b.x3), (short)math.max(a.x4, b.x4), (short)math.max(a.x5, b.x5), (short)math.max(a.x6, b.x6), (short)math.max(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 max(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi16(a, b);
            }
            else
            {
                return new short16(max(a.v8_0, b.v8_0), max(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 max(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi32(a, b);
            }
            else
            {
                return new int8(math.max(a.v4_0, b.v4_0), math.max(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 max(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu32(a, b);
            }
            else
            {
                return new uint8(math.max(a.v4_0, b.v4_0), math.max(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 max(ulong2 a, ulong2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epu64(a, b);
            }
            else
            {
                return new ulong2(math.max(a.x, b.x), math.max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 max(ulong3 a, ulong3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_max_epu64(a, b, 3);
            }
            else
            {
                return new ulong3(max(a.xy, b.xy), math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 max(ulong4 a, ulong4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_max_epu64(a, b, 4);
            }
            else
            {
                return new ulong4(max(a.xy, b.xy), max(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 max(long2 a, long2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.max_epi64(a, b);
            }
            else
            {
                return new long2(math.max(a.x, b.x), math.max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 max(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_max_epi64(a, b, 3);
            }
            else
            {
                return new long3(max(a.xy, b.xy), math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 max(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_max_epi64(a, b, 4);
            }
            else
            {
                return new long4(max(a.xy, b.xy), max(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 max(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_max_ps(a, b);
            }
            else
            {
                return new float8(math.max(a.v4_0, b.v4_0), math.max(a.v4_4, b.v4_4));
            }
        }
    }
}