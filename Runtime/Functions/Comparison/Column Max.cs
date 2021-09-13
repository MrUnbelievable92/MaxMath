using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = x;

                return Sse2.max_epu8(_x, Sse2.bsrli_si128(_x, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.max((uint)x.x, (uint)x.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = x;

                return Sse2.max_epu8(Sse2.max_epu8(_x, Sse2.bsrli_si128(_x, 1 * sizeof(byte))), Sse2.bsrli_si128(_x, 2 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)math.max((uint)x.x, math.max((uint)x.y, (uint)x.z));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = x;

                v128 cmax0 = Sse2.max_epu8(_x, Sse2.bsrli_si128(_x, 2 * sizeof(byte)));

                return Sse2.max_epu8(cmax0, Sse2.bsrli_si128(cmax0, 1 * sizeof(byte))).Byte0; 
            }
            else
            {
                return (byte)math.max((uint)x.x, math.max((uint)x.y, math.max((uint)x.z, (uint)x.w)));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte8 x)
        {
            return cmax(max(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte32 x)
        {
            return cmax(max(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return max(x, vshr(x, 1)).x;
            }
            else
            {
                return (sbyte)math.max((int)x.x, (int)x.y);
            }
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return max(x, max(vshr(x, 1), vshr(x, 2))).x;
            }
            else
            {
                return (sbyte)math.max((int)x.x, math.max((int)x.y, (int)x.z));
            }
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = max(x, vshr(x, 2));

                return max(x, vshr(x, 1)).x;
            }
            else
            {
                return (sbyte)math.max((int)x.x, math.max((int)x.y, math.max((int)x.z, (int)x.w)));
            }
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte8 x)
        {
            return cmax(max(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte32 x)
        {
            return cmax(max(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return max(x, x.yy).x;
            }
            else
            {
                return (short)math.max((int)x.x, (int)x.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = max(x, x.zyz);

                return max(x, x.yyy).x;
            }
            else
            {
                return (short)math.max((int)x.x, math.max((int)x.y, (int)x.z));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = max(x, x.zwzw);

                return max(x, x.yyyy).x;
            }
            else
            {
                return (short)math.max((int)x.x, math.max((int)x.y, math.max((int)x.z, (int)x.w)));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short8 x)
        {
            return cmax(max(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return max(x, x.yy).x;
            }
            else
            {
                return (ushort)math.max((uint)x.x, (uint)x.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = max(x, x.zyz);

                return max(x, x.yyy).x;
            }
            else
            {
                return (ushort)math.max((uint)x.x, math.max((uint)x.y, (uint)x.z));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                x = max(x, x.zwzw);

                return max(x, x.yyyy).x;
            }
            else
            {
                return (ushort)math.max((uint)x.x, math.max((uint)x.y, math.max((uint)x.z, (uint)x.w)));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort8 x)
        {
            return cmax(max(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the maximum component of an <see cref="MaxMath.int8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmax(int8 x)
        {
            return math.cmax(math.max(x.v4_0, x.v4_4));
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.uint8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmax(uint8 x)
        {
            return math.cmax(math.max(x.v4_0, x.v4_4));
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.long2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long2 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return max(x, x.yy).x;
            }
            else
            {
                return math.max(x.x, x.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.long3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long3 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                long2 temp = max(x.xy, x.yz);

                return max(temp, temp.yy).x;
            }
            else
            {
                return math.max(x.x, math.max(x.y, x.z));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.long4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long4 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                long2 temp = max(x.xy, x.zw);

                return max(temp, temp.yy).x;
            }
            else
            {
                return math.max(x.x, math.max(x.y, math.max(x.z, x.w)));
            }
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ulong2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong2 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return max(x, x.yy).x;
            }
            else
            {
                return math.max(x.x, x.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ulong3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong3 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                ulong2 temp = max(x.xy, x.yz);

                return max(temp, temp.yy).x;
            }
            else
            {
                return math.max(x.x, math.max(x.y, x.z));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ulong4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong4 x)
        {
            if (Sse4_2.IsSse42Supported)
            {
                ulong2 temp = max(x.xy, x.zw);

                return max(temp, temp.yy).x;
            }
            else
            {
                return math.max(x.x, math.max(x.y, math.max(x.z, x.w)));
            }
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmax(float8 x)
        {
            return math.cmax(math.max(x.v4_0, x.v4_4));
        }
    }
}