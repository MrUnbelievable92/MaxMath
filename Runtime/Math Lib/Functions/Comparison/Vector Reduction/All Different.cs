using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // optimizable (imm8 shuffles instead of byte shuffles)
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.byte2"/> is equal to the corresponding component of the other <see cref="MaxMath.byte2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte2 a, byte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(2 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.byte3"/> is equal to the corresponding component of the other <see cref="MaxMath.byte3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte3 a, byte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(3 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.byte4"/> is equal to the corresponding component of the other <see cref="MaxMath.byte4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte4 a, byte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(4 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.byte8"/> is equal to the corresponding component of the other <see cref="MaxMath.byte8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte8 a, byte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(8 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
            }
            else
            {
                return all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.byte16"/> is equal to the corresponding component of the other <see cref="MaxMath.byte16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte16 a, byte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b));
            }
            else
            {
                return all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.byte32"/> is equal to the corresponding component of the other <see cref="MaxMath.byte32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(a, b));
            }
            else if (Sse2.IsSse2Supported)
            {
                return all_dif(a.v16_0, b.v16_0) & all_dif(a.v16_16, b.v16_16);
            }
            else
            {
                return all(a != b);
            }
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="MaxMath.sbyte2"/> is equal to the corresponding component of the other <see cref="MaxMath.sbyte2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte2 a, sbyte2 b)
        {
            return all_dif((byte2)a, (byte2)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="MaxMath.sbyte3"/> is equal to the corresponding component of the other <see cref="MaxMath.sbyte3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte3 a, sbyte3 b)
        {
            return all_dif((byte3)a, (byte3)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="MaxMath.sbyte4"/> is equal to the corresponding component of the other <see cref="MaxMath.sbyte4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte4 a, sbyte4 b)
        {
            return all_dif((byte4)a, (byte4)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="MaxMath.sbyte8"/> is equal to the corresponding component of the other <see cref="MaxMath.sbyte8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte8 a, sbyte8 b)
        {
            return all_dif((byte8)a, (byte8)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="MaxMath.sbyte16"/> is equal to the corresponding component of the other <see cref="MaxMath.sbyte16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte16 a, sbyte16 b)
        {
            return all_dif((byte16)a, (byte16)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="MaxMath.sbyte32"/> is equal to the corresponding component of the other <see cref="MaxMath.sbyte32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte32 a, sbyte32 b)
        {
            return all_dif((byte32)a, (byte32)b);
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.short2"/> is equal to the corresponding component of the other <see cref="MaxMath.short2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short2 a, short2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(2 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.short3"/> is equal to the corresponding component of the other <see cref="MaxMath.short3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short3 a, short3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(3 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.short4"/> is equal to the corresponding component of the other <see cref="MaxMath.short4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short4 a, short4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(4 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.short8"/> is equal to the corresponding component of the other <see cref="MaxMath.short8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short8 a, short8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b));
            }
            else
            {
                return all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.short16"/> is equal to the corresponding component of the other <see cref="MaxMath.short16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi16(a, b));
            }
            else if (Sse2.IsSse2Supported)
            {
                return all_dif(a.v8_0, b.v8_0) & all_dif(a.v8_8, b.v8_8);
            }
            else
            {
                return all(a != b);
            }
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.ushort2"/> is equal to the corresponding component of the other <see cref="MaxMath.ushort2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort2 a, ushort2 b)
        {
            return all_dif((short2)a, (short2)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.ushort3"/> is equal to the corresponding component of the other <see cref="MaxMath.ushort3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort3 a, ushort3 b)
        {
            return all_dif((short3)a, (short3)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.ushort4"/> is equal to the corresponding component of the other <see cref="MaxMath.ushort4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort4 a, ushort4 b)
        {
            return all_dif((short4)a, (short4)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.ushort8"/> is equal to the corresponding component of the other <see cref="MaxMath.ushort8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort8 a, ushort8 b)
        {
            return all_dif((short8)a, (short8)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.ushort16"/> is equal to the corresponding component of the other <see cref="MaxMath.ushort16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort16 a, ushort16 b)
        {
            return all_dif((short16)a, (short16)b);
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="int2"/> is equal to the corresponding component of the other <see cref="int2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int2 a, int2 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="int3"/> is equal to the corresponding component of the other <see cref="int3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int3 a, int3 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="int4"/> is equal to the corresponding component of the other <see cref="int4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int4 a, int4 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="MaxMath.int8"/> is equal to the corresponding component of the other <see cref="MaxMath.int8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi32(a, b));
            }
            else if (Sse2.IsSse2Supported)
            {
                return math.all(a.v4_0 != b.v4_0) & math.all(a.v4_4 != b.v4_4);
            }
            else
            {
                return all(a != b);
            }
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="uint2"/> is equal to the corresponding component of the other <see cref="uint2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint2 a, uint2 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="uint3"/> is equal to the corresponding component of the other <see cref="uint3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint3 a, uint3 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="uint4"/> is equal to the corresponding component of the other <see cref="uint4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint4 a, uint4 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.uint8"/> is equal to the corresponding component of the other <see cref="MaxMath.uint8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint8 a, uint8 b)
        {
            return all_dif((int8)a, (int8)b);
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.long2"/> is equal to the corresponding component of the other <see cref="MaxMath.long2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long2 a, long2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (Sse2.movemask_epi8(Xse.cmpeq_epi64(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.long3"/> is equal to the corresponding component of the other <see cref="MaxMath.long3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == (maxmath.bitmask32(3 * sizeof(long)) & Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(a, b)));
            }
            else
            {
                return all_dif(a.xy, b.xy) & a.z != b.z;
            }
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.long4"/> is equal to the corresponding component of the other <see cref="MaxMath.long4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == (Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(a, b)));
            }
            else
            {
                return all_dif(a.xy, b.xy) & all_dif(a.zw, b.zw);
            }
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.ulong2"/> is equal to the corresponding component of the other <see cref="MaxMath.ulong2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong2 a, ulong2 b)
        {
            return all_dif((long2)a, (long2)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.ulong3"/> is equal to the corresponding component of the other <see cref="MaxMath.ulong3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong3 a, ulong3 b)
        {
            return all_dif((long3)a, (long3)b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of a <see cref="MaxMath.ulong4"/> is equal to the corresponding component of the other <see cref="MaxMath.ulong4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong4 a, ulong4 b)
        {
            return all_dif((long4)a, (long4)b);
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="float2"/> is equal to the corresponding component of the other <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float2 a, float2 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="float3"/> is equal to the corresponding component of the other <see cref="float3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float3 a, float3 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="float4"/> is equal to the corresponding component of the other <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float4 a, float4 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="MaxMath.float8"/> is equal to the corresponding component of the other <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return 0 == Avx.mm256_movemask_ps(Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.EQ_OQ));
            }
            else if (Sse.IsSseSupported)
            {
                return math.all(a.v4_0 != b.v4_0) & math.all(a.v4_4 != b.v4_4);
            }
            else
            {
                return all(a != b);
            }
        }


        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="double2"/> is equal to the corresponding component of the other <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double2 a, double2 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="double3"/> is equal to the corresponding component of the other <see cref="double3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double3 a, double3 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns <see langword="false" /> if any of the components of an <see cref="double4"/> is equal to the corresponding component of the other <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double4 a, double4 b)
        {
            return math.all(a != b);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.byte2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.cmpeq_epi8(c, Sse2.bsrli_si128(c, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.byte3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return all_dif(c.xxzx, c.yzyy);
            }
            else
            {
                for (int i = 0; i < 3 - 1; i++)
                {
                    for (int j = i + 1; j < 3; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.byte4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte4 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return all_dif((byte16)Ssse3.shuffle_epi8(c, new v128(0, 0, 0, 1, 1, 2,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0)),
                               (byte16)Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 2, 3, 3,    1, 1, 1, 1, 1, 1, 1, 1, 1, 1)));
            }
            else if (Sse2.IsSse2Supported)
            {
                return math.all(c != c.ywxz & c != c.wzxz);
            }
            else
            {
                for (int i = 0; i < 4 - 1; i++)
                {
                    for (int j = i + 1; j < 4; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.byte8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte8 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 cmp0 = Sse2.cmpeq_epi8(Sse2.shuffle_epi32(c, Sse.SHUFFLE(0, 0, 0, 0)), // Int0 = Byte 0, 1, 2, 3
                                            Ssse3.shuffle_epi8(c, new v128(4, 5, 0, 7, 1, 6, 7, 5, 6, 2, 4, 6, 3, 3, 3, 4)));

                v128 cmp1 = Sse2.cmpeq_epi8(Sse2.shuffle_epi32(c, Sse.SHUFFLE(1, 1, 1, 1)), // Int1 = Byte 4, 5, 6, 7
                                            Ssse3.shuffle_epi8(c, new v128(1, 2, 2, 0, 5, 0, 7, 1, 6, 6, 7, 6, 7, 7, 7, 6)));

                return 0 == Sse2.movemask_epi8(Sse2.or_si128(cmp0, cmp1));
            }
            else
            {
                for (int i = 0; i < 8 - 1; i++)
                {
                    for (int j = i + 1; j < 8; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.byte16"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte16 c)
        {
            if (Sse2.IsSse2Supported)
            {
                //v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14,    15)), // c 
                //                                                                    Ssse3.shuffle_epi8(c, new v128(1,  2,  3,  4,  5,  6,  7,  8,  9, 10,  11, 12, 13, 14, 15,     0))), // alignr1
                //                                                                                                                                           
                //                                                    Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13,    14, 15)), // c
                //                                                                    Ssse3.shuffle_epi8(c, new v128(2,  3,  4,  5,  6,  7,  8,  9, 10, 11,  12, 13, 14, 15,     0,  1)))), // alignr2
                //                                                                                                                                           
                //                                      Sse2.or_si128(Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12,    13, 14, 15)), // c
                //                                                                    Ssse3.shuffle_epi8(c, new v128(3,  4,  5,  6,  7,  8,  9, 10, 11, 12,  13, 14, 15,     0,  1,  2))), // alignr3
                //                                                                                                                                           
                //                                                    Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11,    12, 13, 14, 15)), // c
                //                                                                    Ssse3.shuffle_epi8(c, new v128(4,  5,  6,  7,  8,  9, 10, 11, 12, 13,  14, 15,     0,  1,  2,  3))))), // alignr4 or shuffle_epi32(0, 3, 2, 1)
                //
                //                        Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10,     11, 12, 13, 14, 15)), // c
                //                                                                    Ssse3.shuffle_epi8(c, new v128(5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15,      0,  1,  2,  3,  4))), // alignr5 
                //
                //                                                    Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  1,  2,  3,  4,  5,  6,  7,  8,  9,    10, 11, 12, 13, 14, 15)), // c
                //                                                                    Ssse3.shuffle_epi8(c, new v128(6,  7,  8,  9, 10, 11, 12, 13, 14, 15,     0,  1,  2,  3,  4,  5)))), // alignr6 
                //
                //                                      Sse2.or_si128(Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  1,  2,  3,  4,  5,  6,  7,  8,     9, 10, 11, 12, 13, 14, 15)), // c
                //                                                                    Ssse3.shuffle_epi8(c, new v128(7,  8,  9, 10, 11, 12, 13, 14, 15,     0,  1,  2,  3,  4,  5,  6))),  // alignr7 
                //
                //                                                    Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15)), // c
                //                                                                    Ssse3.shuffle_epi8(c, new v128(8,  5, 15, 11,  1, 13, 14, 15,  4,  1,  2,  0,  4,  0,  1,  1))))));
                

                v128 finalCmp;
                if (Ssse3.IsSsse3Supported)
                {
                    finalCmp = Ssse3.shuffle_epi8(c, new v128(8, 15, 15, 11, 15, 13, 14, 15, 15, 1, 2, 0, 4, 0, 1, 1));
                }
                else
                {
                    finalCmp = new v128(c.x8, c.x15, c.x15, c.x11, c.x15, c.x13, c.x14, c.x15, c.x15, c.x1, c.x2, c.x0, c.x4, c.x0, c.x1, c.x1); 
                }

                // minimum number of comparisons (120 necessary + 8 free duplicates/rearrangements)
                v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi8(c, Xse.bror_si128(c, 1 * sizeof(byte))),
                                                                    Sse2.cmpeq_epi8(c, Xse.bror_si128(c, 2 * sizeof(byte)))),
                                                      Sse2.or_si128(Sse2.cmpeq_epi8(c, Xse.bror_si128(c, 3 * sizeof(byte))),
                                                                    Sse2.cmpeq_epi8(c, Xse.bror_si128(c, 4 * sizeof(byte))))),
                                        Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi8(c, Xse.bror_si128(c, 5 * sizeof(byte))),
                                                                    Sse2.cmpeq_epi8(c, Xse.bror_si128(c, 6 * sizeof(byte)))),
                                                      Sse2.or_si128(Sse2.cmpeq_epi8(c, Xse.bror_si128(c, 7 * sizeof(byte))),
                                                                    Sse2.cmpeq_epi8(c, finalCmp))));
                
                return 0 == Sse2.movemask_epi8(or);
            }
            else
            {
                for (int i = 0; i < 16 - 1; i++)
                {
                    for (int j = i + 1; j < 16; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.byte32"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                // NOT OPTIMIZED AT ALL!!! :( COMBINATORICS, MAN...
                
                v256 lolo = Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(1, 0, 1, 0));
                v256 hihi = Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(3, 2, 3, 2));
                
                
                v256 cmp0 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2)),
                                                  Avx2.mm256_shuffle_epi8(lolo, new v256(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 3, 4, 5)));
                
                v256 cmp1 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)),
                                                  Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                 
                v256 cmp2 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4)),
                                                  Avx2.mm256_shuffle_epi8(lolo, new v256(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)));
                
                v256 cmp3 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3)),
                                                  Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                
                v256 cmp4 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8)),
                                                  Avx2.mm256_shuffle_epi8(lolo, new v256(15, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 7, 8, 9, 10, 11, 12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 9, 10, 11, 12)));
                
                v256 cmp5 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5)),
                                                  Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                
                v256 cmp6 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7)),
                                                  Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                
                v256 cmp7 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(8, 8, 8, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 11, 11, 11, 11, 12, 12, 12, 13, 13, 14, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                  Avx2.mm256_shuffle_epi8(lolo, new v256(13, 14, 15, 10, 11, 12, 13, 14, 15, 11, 12, 13, 14, 15, 12, 13, 14, 15, 13, 14, 15, 14, 15, 15, 1, 1, 1, 1, 1, 1, 1, 1)));
                
                v256 cmp8 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9)),
                                                  Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                
                v256 cmp9 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(hihi, new v256(0, 0, 0, 0, 0, 0, 0, 0, 9, 10, 10, 10, 10, 10, 11, 11, 11, 11, 12, 12, 12, 13, 13, 14, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                  Avx2.mm256_shuffle_epi8(hihi, new v256(1, 2, 3, 4, 5, 6, 7, 8, 15, 11, 12, 13, 14, 15, 12, 13, 14, 15, 13, 14, 15, 14, 15, 15, 1, 1, 1, 1, 1, 1, 1, 1)));
                
                v256 cmp10 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11)),
                                                   Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                
                v256 cmp11 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15)),
                                                   Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                
                v256 cmp12 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13)),
                                                   Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                
                v256 cmp13 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(hihi, new v256(0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2)),
                                                   Avx2.mm256_shuffle_epi8(hihi, new v256(9, 10, 11, 12, 13, 14, 15, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)));
                
                v256 cmp14 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(hihi, new v256(2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5)),
                                                   Avx2.mm256_shuffle_epi8(hihi, new v256(14, 15, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 6, 7, 8, 9, 10, 11, 12)));
                
                v256 cmp15 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(hihi, new v256(5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9)),
                                                   Avx2.mm256_shuffle_epi8(hihi, new v256(13, 14, 15, 7, 8, 9, 10, 11, 12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 9, 10, 11, 12, 13, 14, 15, 10, 11, 12, 13, 14)));
                
                v256 or_0_1_2    = Xse.mm256_ternarylogic_si256(cmp0,  cmp1,  cmp2,  TernaryOperation.OxFE);
                v256 or_3_4_5    = Xse.mm256_ternarylogic_si256(cmp3,  cmp4,  cmp5,  TernaryOperation.OxFE);
                v256 or_6_7_8    = Xse.mm256_ternarylogic_si256(cmp6,  cmp7,  cmp8,  TernaryOperation.OxFE);
                v256 or_9_10_11  = Xse.mm256_ternarylogic_si256(cmp9,  cmp10, cmp11, TernaryOperation.OxFE);
                v256 or_12_13_14 = Xse.mm256_ternarylogic_si256(cmp12, cmp13, cmp14, TernaryOperation.OxFE);
                
                v256 almostThereLo = Xse.mm256_ternarylogic_si256(or_0_1_2, or_3_4_5, cmp15, TernaryOperation.OxFE);
                v256 almostThereHi = Xse.mm256_ternarylogic_si256(or_6_7_8, or_9_10_11, or_12_13_14, TernaryOperation.OxFE);
                
                v256 or = Avx2.mm256_or_si256(almostThereLo, almostThereHi);
                
                return 0 == Avx2.mm256_movemask_epi8(or);

                //Avx2.mm256_shuffle_epi8(lolo, new v256(0, 0, 0, 0, 0, 0, 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 1));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 2));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(1, 1, 1, 1, 1, 1, 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1, 2, 2, 2));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 3, 4, 5));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(2, 2, 2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2, 3, 3, 3, 3, 3, 3));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 4, 5, 6, 7, 8, 9));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3, 4, 4, 4, 4, 4,  4,  4,  4,  4,  4));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4, 5, 5, 5, 5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5, 6, 6, 6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 6,  6,  6,  6, 7, 7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7, 8,  8,  8,  8));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(28, 29, 30, 31, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 9, 10, 11, 12));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 9,  9,  9,  9,  9,  9,  9,  9,  9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 11));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(23, 24, 25, 26, 27, 28, 29, 30, 31, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 12, 13));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(27, 28, 29, 30, 31, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 15, 16, 17, 18, 19, 20, 21, 22, 23));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 16, 16, 16, 16, 16, 16, 16, 16));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(24, 25, 26, 27, 28, 29, 30, 31, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 17, 18, 19, 20, 21, 22, 23, 24));
                //
                //Avx2.mm256_shuffle_epi8(hihi, new v256(16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18));
                //Avx2.mm256_shuffle_epi8(hihi, new v256(25, 26, 27, 28, 29, 30, 31, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29));
                //
                //Avx2.mm256_shuffle_epi8(hihi, new v256(18, 18, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 21, 21, 21, 21, 21, 21, 21));
                //Avx2.mm256_shuffle_epi8(hihi, new v256(30, 31, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 22, 23, 24, 25, 26, 27, 28));
                //
                //Avx2.mm256_shuffle_epi8(hihi, new v256(21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 23, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 25, 25, 25, 25, 25));
                //Avx2.mm256_shuffle_epi8(hihi, new v256(29, 30, 31, 23, 24, 25, 26, 27, 28, 29, 30, 31, 24, 25, 26, 27, 28, 29, 30, 31, 25, 26, 27, 28, 29, 30, 31, 26, 27, 28, 29, 30));
                //
                //Avx2.mm256_shuffle_epi8(hihi, new v256(25, 26, 26, 26, 26, 26, 27, 27, 27, 27, 28, 28, 28, 29, 29, 30,     0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                //Avx2.mm256_shuffle_epi8(hihi, new v256(31, 27, 28, 29, 30, 31, 28, 29, 30, 31, 29, 30, 31, 30, 31, 31,     1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1));
            }
            else if (Ssse3.IsSsse3Supported)
            {
                if (all_dif(c.v16_0) && all_dif(c.v16_16))
                {
                    v128 lo = c.v16_0;
                    v128 hi = c.v16_16;
                    v128 resultHi = Sse2.setzero_si128();

                    for (int i = 0; i < 16; i++)
                    {
                        resultHi = Sse2.or_si128(resultHi, Sse2.cmpeq_epi8(lo, Ssse3.shuffle_epi8(hi, Sse2.setzero_si128())));
                        hi = Sse2.bsrli_si128(hi, 1 * sizeof(byte));
                    }

                    return Xse.allfalse_epi128<byte>(resultHi, 16);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                for (int i = 0; i < 32 - 1; i++)
                {
                    for (int j = i + 1; j < 32; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="MaxMath.sbyte2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte2 c)
        {
            return all_dif((short2)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="MaxMath.sbyte3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte3 c)
        {
            return all_dif((short3)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="MaxMath.sbyte4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte4 c)
        {
            return all_dif((byte4)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="MaxMath.sbyte8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte8 c)
        {
            return all_dif((byte8)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="MaxMath.sbyte16"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte16 c)
        {
            return all_dif((byte16)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="MaxMath.sbyte32"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte32 c)
        {
            return all_dif((byte32)c);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.short2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.cmpeq_epi16(c, Sse2.bsrli_si128(c, 1 * sizeof(short))).UShort0;
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.short3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return all_dif(c.xxzx, c.yzyy);
            }
            else
            {
                for (int i = 0; i < 3 - 1; i++)
                {
                    for (int j = i + 1; j < 3; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.short4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short4 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return all_dif((short8)Ssse3.shuffle_epi8(c, new v128(0, 1,  0, 1,  0, 1,  2, 3,  2, 3,  4, 5,    0, 1,  0, 1)),
                               (short8)Ssse3.shuffle_epi8(c, new v128(2, 3,  4, 5,  6, 7,  4, 5,  6, 7,  6, 7,    2, 3,  2, 3)));
            }
            else if (Sse2.IsSse2Supported)
            {
                return math.all(c != c.ywxz & c != c.wzxz);
            }
            else
            {
                for (int i = 0; i < 4 - 1; i++)
                {
                    for (int j = i + 1; j < 4; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.short8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                //v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  2,  3)),
                //                                                       Ssse3.shuffle_epi8(c, new v128(2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 4,  5))),
                //
                //                                      Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(2,  3,  2,  3,  2,  3,  2,  3,  2,  3,  4,  5,  4,  5,  4,  5)),
                //                                                       Ssse3.shuffle_epi8(c, new v128(6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 6,  7,  8,  9,  10, 11)))),
                //
                //                        Sse2.or_si128(Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(4,  5,  4,  5,  6,  7,  6,  7,  6,  7,  6,  7,  8,  9,  8,  9)),
                //                                                       Ssse3.shuffle_epi8(c, new v128(12, 13, 14, 15, 8,  9,  10, 11, 12, 13, 14, 15, 10, 11, 12, 13))),
                //
                //                                      Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(8,  9,  10, 11, 10, 11, 12, 13,     0,  1,  0,  1,  0,  1,  0,  1)),
                //                                                       Ssse3.shuffle_epi8(c, new v128(14, 15, 12, 13, 14, 15, 14, 15,     2,  3,  2,  3,  2,  3,  2,  3)))));
                                                
                v128 finalCmp;
                if (Ssse3.IsSsse3Supported)
                {
                    finalCmp = Ssse3.shuffle_epi8(c, new v128(8, 9,   10, 11,   12, 13,   14, 15,   14, 15,   0, 1,   2, 3,   4, 5));
                }
                else
                {
                    finalCmp = Sse2.bsrli_si128(c, 4 * sizeof(short));
                    finalCmp = Sse2.or_si128(finalCmp, Sse2.bslli_si128(c, 5 * sizeof(short)));
                    finalCmp = Xse.insert_epi16(finalCmp, Xse.extract_epi16(c, 7), 5);
                }

                v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi16(c, Xse.bror_si128(c, 1 * sizeof(short))),
                                                      Sse2.cmpeq_epi16(c, Xse.bror_si128(c, 2 * sizeof(short)))),
                                        Sse2.or_si128(Sse2.cmpeq_epi16(c, Xse.bror_si128(c, 3 * sizeof(short))),
                                                      Sse2.cmpeq_epi16(c, finalCmp)));

                return 0 == Sse2.movemask_epi8(or);
            }
            else
            {
                for (int i = 0; i < 8 - 1; i++)
                {
                    for (int j = i + 1; j < 8; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.short16"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shuf = new v256(0, 1,  14, 15,  14, 15,  6, 7,  14, 15,  10, 11,  12, 13,  14, 15,     0, 1,  2, 3,  4, 5,  0, 1,  8, 9,  0, 1,  2, 3,  2, 3);
                v256 finalCmp = Avx2.mm256_shuffle_epi8(Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(1, 0, 3, 2)), shuf);
                finalCmp.SShort8 = c.x15;

                // minimum number of comparisons (120 necessary + 8 free duplicates/rearrangements)
                v256 or = Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si256(c, 1 * sizeof(short))),
                                                                                      Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si256(c, 2 * sizeof(short)))),
                                                                  Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si256(c, 3 * sizeof(short))),
                                                                                      Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si256(c, 4 * sizeof(short))))),
                                              Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si256(c, 5 * sizeof(short))),
                                                                                      Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si256(c, 6 * sizeof(short)))),
                                                                  Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si256(c, 7 * sizeof(short))),
                                                                                      Avx2.mm256_cmpeq_epi16(c, finalCmp))));
                
                return 0 == Avx2.mm256_movemask_epi8(or);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                if (all_dif(c.v8_0) && all_dif(c.v8_8))
                {
                    v128 lo = c.v8_0; 
                    v128 hi = c.v8_8;
                    bool loDif = all_dif(c.v8_0);
                    v128 resultHi = Sse2.setzero_si128();
                    v128 SHUFFLE_MASK = new v128(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1);

                    for (int i = 0; i < 8; i++)
                    {
                        resultHi = Sse2.or_si128(resultHi, Sse2.cmpeq_epi16(lo, Ssse3.shuffle_epi8(hi, SHUFFLE_MASK)));
                        hi = Sse2.bsrli_si128(hi, 1 * sizeof(short));
                    }

                    return Xse.allfalse_epi128<short>(resultHi, 8);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                for (int i = 0; i < 16 - 1; i++)
                {
                    for (int j = i + 1; j < 16; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.ushort2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort2 c)
        {
            return all_dif((short2)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.ushort3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort3 c)
        {
            return all_dif((short3)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.ushort4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort4 c)
        {
            return all_dif((short4)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.ushort8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort8 c)
        {
            return all_dif((short8)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.ushort16"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort16 c)
        {
            return all_dif((short16)c);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="int2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return 0 == Sse2.cmpeq_epi32(_c, Sse2.bsrli_si128(_c, 1 * sizeof(int))).UInt0;
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="int3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int3 c)
        {
            return math.all(c.xxz != c.yzy);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="int4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 _c = Avx.mm256_castsi128_si256(RegisterConversion.ToV128(c));

                return all_dif((int8)Avx2.mm256_permute4x64_epi64(_c, Sse.SHUFFLE(1, 0, 1, 0)), 
                               (int8)Avx2.mm256_permutevar8x32_epi32(_c, new v256(1, 3, 0, 2, 3, 2, 0, 2)));
            }
            else
            {
                return math.all(c != c.ywxz & c != c.wzxz);
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="MaxMath.int8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                //v256 or = Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(0, 0, 0, 0, 0, 0, 0, 1)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 2, 3, 4, 5, 6, 7, 2))),
                //
                //                                                  Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 1, 1, 1, 1, 2, 2, 2)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(3, 4, 5, 6, 7, 3, 4, 5)))),
                //
                //                              Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(2, 2, 3, 3, 3, 3, 4, 4)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(6, 7, 4, 5, 6, 7, 5, 6))),
                //
                //                                                  Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(4, 5, 5, 6,    0, 0, 0, 0)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(7, 6, 7, 7,    1, 1, 1, 1)))));

                v256 cmp0 = Avx2.mm256_cmpeq_epi32(c, Avx2.mm256_permutevar8x32_epi32(c, Avx.mm256_castsi128_si256(new v128(1, 0, 3, 0))));
                v256 cmp1 = Avx2.mm256_cmpeq_epi32(c, Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 0, 7, 4, 1, 1, 1, 1)));
                v256 cmp2 = Avx2.mm256_cmpeq_epi32(c, Avx2.mm256_permutevar8x32_epi32(c, new v256(2, 2, 5, 6, 5, 6, 7, 4)));
                v256 cmp3 = Avx2.mm256_cmpeq_epi32(Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(2, 1, 1, 1)), Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(3, 3, 2, 0)));
                
                v256 or = Xse.mm256_ternarylogic_si256(Avx2.mm256_or_si256(cmp0, cmp1), cmp2, cmp3, TernaryOperation.OxFE);

                return 0 == Avx2.mm256_movemask_epi8(or);
            }
            else if (Sse2.IsSse2Supported)
            {
                int4 lo = c.v4_0;
                int4 hi = c.v4_4;


                int4 _0000 = lo.xxxx;
                int4 _1234 = math.shuffle(lo, hi, math.ShuffleComponent.LeftY,
                                                  math.ShuffleComponent.LeftZ, 
                                                  math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.RightX);

                v128 _1st_cmp = Sse2.cmpeq_epi32(RegisterConversion.ToV128(_0000), RegisterConversion.ToV128(_1234));


                int4 _0001 = lo.xxxy;
                int4 _5672 = math.shuffle(lo, hi, math.ShuffleComponent.RightY, 
                                                  math.ShuffleComponent.RightZ, 
                                                  math.ShuffleComponent.RightW, 
                                                  math.ShuffleComponent.LeftZ);

                v128 _2nd_cmp = Sse2.cmpeq_epi32(RegisterConversion.ToV128(_0001), RegisterConversion.ToV128(_5672));


                int4 _1111 = lo.yyyy;
                int4 _3456 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.RightX, 
                                                  math.ShuffleComponent.RightY, 
                                                  math.ShuffleComponent.RightZ);

                v128 _3rd_cmp = Sse2.cmpeq_epi32(RegisterConversion.ToV128(_1111), RegisterConversion.ToV128(_3456));


                int4 _1222 = lo.yzzz;
                int4 _7345 = math.shuffle(lo, hi, math.ShuffleComponent.RightW, 
                                                  math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.RightX, 
                                                  math.ShuffleComponent.RightY);

                v128 _4th_cmp = Sse2.cmpeq_epi32(RegisterConversion.ToV128(_1222), RegisterConversion.ToV128(_7345));


                int4 _2233 = lo.zzww;
                int4 _6745 = hi.zwxy;

                v128 _5th_cmp = Sse2.cmpeq_epi32(RegisterConversion.ToV128(_2233), RegisterConversion.ToV128(_6745));


                int4 _3344 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.RightX, 
                                                  math.ShuffleComponent.RightX);
                int4 _6756 = hi.zwyz;

                v128 _6th_cmp = Sse2.cmpeq_epi32(RegisterConversion.ToV128(_3344), RegisterConversion.ToV128(_6756));


                int4 _4556 = hi.xyyz;
                int4 _7677 = hi.wzww;

                v128 _7th_cmp = Sse2.cmpeq_epi32(RegisterConversion.ToV128(_4556), RegisterConversion.ToV128(_7677));


                v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.or_si128(_1st_cmp, _2nd_cmp),
                                                      Sse2.or_si128(_3rd_cmp, _4th_cmp)),
                                        Sse2.or_si128(Sse2.or_si128(_5th_cmp, _6th_cmp),
                                                      _7th_cmp));

                return 0 == Sse2.movemask_epi8(or);
            }
            else
            {
                for (int i = 0; i < 8 - 1; i++)
                {
                    for (int j = i + 1; j < 8; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="uint2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint2 c)
        {
            return all_dif((int2)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="uint3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint3 c)
        {
            return all_dif((int3)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="uint4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint4 c)
        {
            return all_dif((int4)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.uint8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint8 c)
        {
            return all_dif((int8)c);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.long2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Xse.cmpeq_epi64(c, Sse2.bsrli_si128(c, 1 * sizeof(long))).ULong0;
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.long3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.long4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long4 c)
        {
            return all_dif(c, c.ywxz) & all_dif(c, c.wzxz);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.ulong2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong2 c)
        {
            return all_dif((long2)c);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.ulong3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="MaxMath.ulong4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong4 c)
        {
            return all_dif(c, c.ywxz) & all_dif(c, c.wzxz);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="float2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return 0 == Sse.cmpeq_ps(_c, Sse2.bsrli_si128(_c, 1 * sizeof(float))).SInt0;
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="float3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float3 c)
        {
            return math.all(c.xxz != c.yzy);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="float4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 _c = Avx.mm256_castps128_ps256(RegisterConversion.ToV128(c));

                return all_dif((float8)Avx2.mm256_permute4x64_pd(_c, Sse.SHUFFLE(1, 0, 1, 0)), 
                               (float8)Avx2.mm256_permutevar8x32_ps(_c, new v256(1, 3, 0, 2, 3, 2, 0, 2)));
            }
            else
            {
                return math.all(c != c.ywxz & c != c.wzxz);
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of an <see cref="MaxMath.float8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                //v256 or = Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(0, 0, 0, 0, 0, 0, 0, 1)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 2, 3, 4, 5, 6, 7, 2))),
                //
                //                                                  Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 1, 1, 1, 1, 2, 2, 2)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(3, 4, 5, 6, 7, 3, 4, 5)))),
                //
                //                              Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(2, 2, 3, 3, 3, 3, 4, 4)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(6, 7, 4, 5, 6, 7, 5, 6))),
                //
                //                                                  Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(4, 5, 5, 6,    0, 0, 0, 0)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(7, 6, 7, 7,    1, 1, 1, 1)))));
                
                v256 cmp0 = Avx.mm256_cmp_ps(c, Avx2.mm256_permutevar8x32_ps(c, Avx.mm256_castsi128_si256(new v128(1, 0, 3, 0))), (int)Avx.CMP.EQ_OQ);
                v256 cmp1 = Avx.mm256_cmp_ps(c, Avx2.mm256_permutevar8x32_ps(c, new v256(1, 0, 7, 4, 1, 1, 1, 1)), (int)Avx.CMP.EQ_OQ);
                v256 cmp2 = Avx.mm256_cmp_ps(c, Avx2.mm256_permutevar8x32_ps(c, new v256(2, 2, 5, 6, 5, 6, 7, 4)), (int)Avx.CMP.EQ_OQ);
                v256 cmp3 = Avx.mm256_cmp_ps(Avx2.mm256_permute4x64_pd(c, Sse.SHUFFLE(2, 1, 1, 1)), Avx2.mm256_permute4x64_pd(c, Sse.SHUFFLE(3, 3, 2, 0)),(int)Avx.CMP.EQ_OQ);
                
                v256 or = Avx.mm256_or_ps(Avx.mm256_or_ps(cmp0, cmp1), Avx.mm256_or_ps(cmp2, cmp3));

                return 0 == Avx.mm256_movemask_ps(or);
            }
            else if (Sse.IsSseSupported)
            {
                float4 lo = c.v4_0;
                float4 hi = c.v4_4;


                float4 _0000 = lo.xxxx;
                float4 _1234 = math.shuffle(lo, hi, math.ShuffleComponent.LeftY,
                                                    math.ShuffleComponent.LeftZ, 
                                                    math.ShuffleComponent.LeftW, 
                                                    math.ShuffleComponent.RightX);

                v128 _1st_cmp = Sse.cmpeq_ps(RegisterConversion.ToV128(_0000), RegisterConversion.ToV128(_1234));


                float4 _0001 = lo.xxxy;
                float4 _5672 = math.shuffle(lo, hi, math.ShuffleComponent.RightY, 
                                                    math.ShuffleComponent.RightZ, 
                                                    math.ShuffleComponent.RightW, 
                                                    math.ShuffleComponent.LeftZ);

                v128 _2nd_cmp = Sse.cmpeq_ps(RegisterConversion.ToV128(_0001), RegisterConversion.ToV128(_5672));


                float4 _1111 = lo.yyyy;
                float4 _3456 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW, 
                                                    math.ShuffleComponent.RightX, 
                                                    math.ShuffleComponent.RightY, 
                                                    math.ShuffleComponent.RightZ);

                v128 _3rd_cmp = Sse.cmpeq_ps(RegisterConversion.ToV128(_1111), RegisterConversion.ToV128(_3456));


                float4 _1222 = lo.yzzz;
                float4 _7345 = math.shuffle(lo, hi, math.ShuffleComponent.RightW, 
                                                    math.ShuffleComponent.LeftW, 
                                                    math.ShuffleComponent.RightX, 
                                                    math.ShuffleComponent.RightY);

                v128 _4th_cmp = Sse.cmpeq_ps(RegisterConversion.ToV128(_1222), RegisterConversion.ToV128(_7345));


                float4 _2233 = lo.zzww;
                float4 _6745 = hi.zwxy;

                v128 _5th_cmp = Sse.cmpeq_ps(RegisterConversion.ToV128(_2233), RegisterConversion.ToV128(_6745));


                float4 _3344 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW, 
                                                    math.ShuffleComponent.LeftW, 
                                                    math.ShuffleComponent.RightX, 
                                                    math.ShuffleComponent.RightX);
                float4 _6756 = hi.zwyz;

                v128 _6th_cmp = Sse.cmpeq_ps(RegisterConversion.ToV128(_3344), RegisterConversion.ToV128(_6756));


                float4 _4556 = hi.xyyz;
                float4 _7677 = hi.wzww;

                v128 _7th_cmp = Sse.cmpeq_ps(RegisterConversion.ToV128(_4556), RegisterConversion.ToV128(_7677));


                v128 or = Sse.or_ps(Sse.or_ps(Sse.or_ps(_1st_cmp, _2nd_cmp),
                                              Sse.or_ps(_3rd_cmp, _4th_cmp)),
                                    Sse.or_ps(Sse.or_ps(_5th_cmp, _6th_cmp),
                                              _7th_cmp));

                return 0 == Sse.movemask_ps(or);
            }
            else
            {
                for (int i = 0; i < 8 - 1; i++)
                {
                    for (int j = i + 1; j < 8; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="double2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return 0 == Sse2.cmpeq_pd(_c, Sse2.bsrli_si128(_c, 1 * sizeof(double))).SLong0;
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="double3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of a <see cref="double4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double4 c)
        {
            return math.all(c != c.ywxz & c != c.wzxz);
        }
    }
}