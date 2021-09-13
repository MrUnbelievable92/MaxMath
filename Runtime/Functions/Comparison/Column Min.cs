using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = x;

                return Sse2.min_epu8(_x, Sse2.bsrli_si128(_x, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.min((uint)x.x, (uint)x.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = x;

                return Sse2.min_epu8(Sse2.min_epu8(_x, Sse2.bsrli_si128(_x, 1 * sizeof(byte))), Sse2.bsrli_si128(_x, 2 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.min((uint)x.x, math.min((uint)x.y, (uint)x.z));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = x;

                v128 cmin0 = Sse2.min_epu8(_x, Sse2.bsrli_si128(_x, 2 * sizeof(byte)));

                return Sse2.min_epu8(cmin0, Sse2.bsrli_si128(cmin0, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.min((uint)x.x, math.min((uint)x.y, math.min((uint)x.z, (uint)x.w)));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte8 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.minpos_epu16(Sse4_1.cvtepu8_epi16(x)).Byte0;
            }
            else
            {
                return cmin(min(x.v4_0, x.v4_4));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte32 x)
        {
            return cmin(min(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return min(x, vshr(x, 1)).x;
            }
            else
            {
                return (sbyte)math.min((int)x.x, (int)x.y);
            }
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return min(x, min(vshr(x, 1), vshr(x, 2))).x;
            }
            else
            {
                return (sbyte)math.min((int)x.x, math.min((int)x.y, (int)x.z));
            }
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = min(x, vshr(x, 2));

                return min(x, vshr(x, 1)).x;
            }
            else
            {
                return (sbyte)math.min((int)x.x, math.min((int)x.y, math.min((int)x.z, (int)x.w)));
            }
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte8 x)
        {
            return cmin(min(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte32 x)
        {
            return cmin(min(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return min(x, x.yy).x;
            }
            else
            {
                return (short)math.min((int)x.x, (int)x.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = min(x, x.zyz);

                return min(x, x.yyy).x;
            }
            else
            {
                return (short)math.min((int)x.x, math.min((int)x.y, (int)x.z));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = min(x, x.zwzw);

                return min(x, x.yyyy).x;
            }
            else
            {
                return (short)math.min((int)x.x, math.min((int)x.y, math.min((int)x.z, (int)x.w)));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short8 x)
        {
            return cmin(min(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return min(x, x.yy).x;
            }
            else
            {
                return (ushort)math.min((uint)x.x, (uint)x.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = min(x, x.zyz);

                return min(x, x.yyy).x;
            }
            else
            {
                return (ushort)math.min((uint)x.x, math.min((uint)x.y, (uint)x.z));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = min(x, x.zwzw);

                return min(x, x.yyyy).x;
            }
            else
            {
                return (ushort)math.min((uint)x.x, math.min((uint)x.y, math.min((uint)x.z, (uint)x.w)));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort8 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.minpos_epu16(x).UShort0;
            }
            else
            {
                return cmin(min(x.v4_0, x.v4_4));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the minimum component of an <see cref="MaxMath.int8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmin(int8 x)
        {
            return math.cmin(math.min(x.v4_0, x.v4_4));
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.uint8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmin(uint8 x)
        {
            return math.cmin(math.min(x.v4_0, x.v4_4));
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.long2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long2 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return min(x, x.yy).x;
            }
            else
            {
                return math.min(x.x, x.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.long3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long3 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                long2 temp = min(x.xy, x.yz);

                return min(temp, temp.yy).x;
            }
            else
            {
                return math.min(x.x, math.min(x.y, x.z));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.long4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long4 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                long2 temp = min(x.xy, x.zw);

                return min(temp, temp.yy).x;
            }
            else
            {
                return math.min(x.x, math.min(x.y, math.min(x.z, x.w)));
            }
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ulong2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong2 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return min(x, x.yy).x;
            }
            else
            {
                return math.min(x.x, x.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ulong3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong3 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                ulong2 temp = min(x.xy, x.yz);

                return min(temp, temp.yy).x;
            }
            else
            {
                return math.min(x.x, math.min(x.y, x.z));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ulong4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong4 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                ulong2 temp = min(x.xy, x.zw);

                return min(temp, temp.yy).x;
            }
            else
            {
                return math.min(x.x, math.min(x.y, math.min(x.z, x.w)));
            }
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmin(float8 x)
        {
            return math.cmin(math.min(x.v4_0, x.v4_4));
        }
    }
}