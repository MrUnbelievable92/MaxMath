using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.byte2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return 0 != Xse.cmpeq_epi8(c, Xse.bsrli_si128(c, 1 * sizeof(byte))).SByte0;
            }
            else
            {
                return c.x == c.y;
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.byte3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return c.xxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z;
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.byte4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return c.xxxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z & c.x == c.w;
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.byte8"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte8 c)
        {
            if (Architecture.IsTableLookupSupported)
            {
                return c.Equals(Xse.shuffle_epi8(c, Xse.setzero_si128()));
            }
            else
            {
                return ((c.x0 == c.x1 & c.x0 == c.x2) & (c.x0 == c.x3 & c.x0 == c.x4)) & ((c.x0 == c.x5 & c.x0 == c.x6) & c.x0 == c.x7);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.byte16"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte16 c)
        {
            if (Architecture.IsTableLookupSupported)
            {
                return c.Equals(Xse.shuffle_epi8(c, Xse.setzero_si128()));
            }
            else
            {
                return (((c.x0 == c.x1 & c.x0 == c.x2) & (c.x0 == c.x3 & c.x0 == c.x4)) & ((c.x0 == c.x5 & c.x0 == c.x6) & (c.x0 == c.x7 & c.x0 == c.x8))) & (((c.x0 == c.x9 & c.x0 == c.x10) & (c.x0 == c.x11 & c.x0 == c.x12)) & ((c.x0 == c.x13 & c.x0 == c.x14) & c.x0 == c.x15));
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.byte32"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return c.Equals(Avx2.mm256_broadcastb_epi8(Avx.mm256_castsi256_si128(c)));
            }
            else
            {
                return all_eq(c.v16_0) & all_eq(c.v16_16) & c.v16_0.Equals(c.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="MaxMath.sbyte2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte2 c)
        {
            return all_eq((byte2)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="MaxMath.sbyte3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte3 c)
        {
            return all_eq((byte3)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="MaxMath.sbyte4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte4 c)
        {
            return all_eq((byte4)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="MaxMath.sbyte8"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte8 c)
        {
            return all_eq((byte8)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="MaxMath.sbyte16"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte16 c)
        {
            return all_eq((byte16)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="MaxMath.sbyte32"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte32 c)
        {
            return all_eq((byte32)c);
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.short2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return 0 != Xse.cmpeq_epi16(c, Xse.bsrli_si128(c, 1 * sizeof(short))).SShort0;
            }
            else
            {
                return c.x == c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.short3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return c.xxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.short4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return c.xxxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z & c.x == c.w;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.short8"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short8 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return c.Equals(Xse.shuffle_epi16(c, new v128(0, 0, 0, 0, 0, 0, 0, 0)));
            }
            else
            {
                return ((c.x0 == c.x1 & c.x0 == c.x2) & (c.x0 == c.x3 & c.x0 == c.x4)) & ((c.x0 == c.x5 & c.x0 == c.x6) & c.x0 == c.x7);
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.short16"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return c.Equals(Avx2.mm256_broadcastw_epi16(Avx.mm256_castsi256_si128(c)));
            }
            else
            {
                return all_eq(c.v8_0) & all_eq(c.v8_8) & c.v8_0.Equals(c.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.ushort2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort2 c)
        {
            return all_eq((short2)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.ushort3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort3 c)
        {
            return all_eq((short3)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.ushort4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort4 c)
        {
            return all_eq((short4)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.ushort8"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort8 c)
        {
            return all_eq((short8)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.ushort16"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort16 c)
        {
            return all_eq((short16)c);
        }


        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="int2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return 0 != Xse.cmpeq_epi32(_c, Xse.bsrli_si128(_c, 1 * sizeof(int))).SInt0;
            }
            else
            {
                return c.x == c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="int3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int3 c)
        {
            return c.xxx.Equals(c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="int4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int4 c)
        {
            return c.xxxx.Equals(c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="MaxMath.int8"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return c.Equals(Avx2.mm256_broadcastd_epi32(Avx.mm256_castsi256_si128(c)));
            }
            else
            {
                return all_eq(c.v4_0) & all_eq(c.v4_4) & c.v4_0.Equals(c.v4_4);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="uint2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint2 c)
        {
            return all_eq((int2)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="uint3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint3 c)
        {
            return c.xxx.Equals(c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="uint4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint4 c)
        {
            return c.xxxx.Equals(c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.uint8"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint8 c)
        {
            return all_eq((int8)c);
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.long2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(long2 c)
        {
            if (Architecture.IsCMP64Supported)
            {
                return 0 != Xse.cmpeq_epi64(c, Xse.bsrli_si128(c, 1 * sizeof(long))).SLong0;
            }
            else
            {
                return c.x == c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.long3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(long3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return c.xx.Equals(c.yz);
            }
            else
            {
                return c.x == c.y & c.x == c.z;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.long4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(long4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return c.xxxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z & c.x == c.w;
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.ulong2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ulong2 c)
        {
            return all_eq((long2)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.ulong3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ulong3 c)
        {
            return all_eq((long3)c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="MaxMath.ulong4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ulong4 c)
        {
            return all_eq((long4)c);
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="float2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(float2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return 0 != Xse.cmpeq_ps(_c, Xse.bsrli_si128(_c, 1 * sizeof(float))).SInt0;
            }
            else
            {
                return c.x == c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="float3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(float3 c)
        {
            return c.xxx.Equals(c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="float4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(float4 c)
        {
            return c.xxxx.Equals(c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="MaxMath.float8"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(float8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return c.Equals(Avx2.mm256_broadcastss_ps(Avx.mm256_castps256_ps128(c)));
            }
            else
            {
                return all_eq(c.v4_0) & all_eq(c.v4_4) & c.v4_0.Equals(c.v4_4);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all components of a <see cref="double2"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(double2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return 0 != Xse.cmpeq_pd(_c, Xse.bsrli_si128(_c, 1 * sizeof(double))).SInt0;
            }
            else
            {
                return c.x == c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="double3"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(double3 c)
        {
            return c.xxx.Equals(c);
        }

        /// <summary>       Returns <see langword="true"/> if all components of an <see cref="double4"/> have the same value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(double4 c)
        {
            return c.xxxx.Equals(c);
        }
    }
}