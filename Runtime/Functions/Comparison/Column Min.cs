using System.Runtime.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the minimum component of a byte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return min(x, x.yy).x;
            }
            else
            {
                return (byte)math.min((uint)x.x, (uint)x.y);
            }
        }

        /// <summary>       Returns the minimum component of a byte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                x = min(x, x.zyz);

                return min(x, x.yyy).x;
            }
            else
            {
                return (byte)math.min((uint)x.x, math.min((uint)x.y, (uint)x.z));
            }
        }

        /// <summary>       Returns the minimum component of a byte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                x = min(x, x.zwzw);

                return min(x, x.yyyy).x;
            }
            else
            {
                return (byte)math.min((uint)x.x, math.min((uint)x.y, math.min((uint)x.z, (uint)x.w)));
            }
        }

        /// <summary>       Returns the minimum component of a byte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte8 x)
        {
            return cmin(min(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the minimum component of a byte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }

        /// <summary>       Returns the minimum component of a byte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte32 x)
        {
            return cmin(min(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the minimum component of an sbyte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return min(x, x.yy).x;
            }
            else
            {
                return (sbyte)math.min((int)x.x, (int)x.y);
            }
        }

        /// <summary>       Returns the minimum component of an sbyte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                x = min(x, x.zyz);

                return min(x, x.yyy).x;
            }
            else
            {
                return (sbyte)math.min((int)x.x, math.min((int)x.y, (int)x.z));
            }
        }

        /// <summary>       Returns the minimum component of an sbyte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                x = min(x, x.zwzw);

                return min(x, x.yyyy).x;
            }
            else
            {
                return (sbyte)math.min((int)x.x, math.min((int)x.y, math.min((int)x.z, (int)x.w)));
            }
        }

        /// <summary>       Returns the minimum component of an sbyte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte8 x)
        {
            return cmin(min(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the minimum component of an sbyte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }

        /// <summary>       Returns the minimum component of an sbyte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte32 x)
        {
            return cmin(min(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the minimum component of a short2 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a short3 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a short4 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a short8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short8 x)
        {
            return cmin(min(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the minimum component of a short16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the minimum component of a ushort2 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a ushort3 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a ushort4 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a ushort8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort8 x)
        {
            return cmin(min(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the minimum component of a ushort16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the minimum component of an int8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmin(int8 x)
        {
            return math.cmin(math.min(x.v4_0, x.v4_4));
        }


        /// <summary>       Returns the minimum component of a uint8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmin(uint8 x)
        {
            return math.cmin(math.min(x.v4_0, x.v4_4));
        }


        /// <summary>       Returns the minimum component of a long2 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a long3 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a long4 vector.       </summary>
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


        /// <summary>       Returns the minimum component of a ulong2 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a ulong3 vector.       </summary>
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

        /// <summary>       Returns the minimum component of a ulong4 vector.       </summary>
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


        /// <summary>       Returns the minimum component of a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmin(float8 x)
        {
            return math.cmin(math.min(x.v4_0, x.v4_4));
        }
    }
}