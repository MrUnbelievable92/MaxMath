using System.Runtime.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the maximum component of a byte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return max(x, x.yy).x;
            }
            else
            {
                return (byte)math.max((uint)x.x, (uint)x.y);
            }
        }

        /// <summary>       Returns the maximum component of a byte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                x = max(x, x.zyz);

                return max(x, x.yyy).x;
            }
            else
            {
                return (byte)math.max((uint)x.x, math.max((uint)x.y, (uint)x.z));
            }
        }

        /// <summary>       Returns the maximum component of a byte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                x = max(x, x.zwzw);

                return max(x, x.yyyy).x;
            }
            else
            {
                return (byte)math.max((uint)x.x, math.max((uint)x.y, math.max((uint)x.z, (uint)x.w)));
            }
        }

        /// <summary>       Returns the maximum component of a byte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte8 x)
        {
            return cmax(max(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the maximum component of a byte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }

        /// <summary>       Returns the maximum component of a byte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte32 x)
        {
            return cmax(max(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the maximum component of an sbyte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return max(x, x.yy).x;
            }
            else
            {
                return (sbyte)math.max((int)x.x, (int)x.y);
            }
        }

        /// <summary>       Returns the maximum component of an sbyte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                x = max(x, x.zyz);

                return max(x, x.yyy).x;
            }
            else
            {
                return (sbyte)math.max((int)x.x, math.max((int)x.y, (int)x.z));
            }
        }

        /// <summary>       Returns the maximum component of an sbyte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                x = max(x, x.zwzw);

                return max(x, x.yyyy).x;
            }
            else
            {
                return (sbyte)math.max((int)x.x, math.max((int)x.y, math.max((int)x.z, (int)x.w)));
            }
        }

        /// <summary>       Returns the maximum component of an sbyte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte8 x)
        {
            return cmax(max(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the maximum component of an sbyte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }

        /// <summary>       Returns the maximum component of an sbyte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte32 x)
        {
            return cmax(max(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the maximum component of a short2 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a short3 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a short4 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a short8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short8 x)
        {
            return cmax(max(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the maximum component of a short16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the maximum component of a ushort2 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a ushort3 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a ushort4 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a ushort8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort8 x)
        {
            return cmax(max(x.v4_0, x.v4_4));
        }

        /// <summary>       Returns the maximum component of a ushort16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the maximum component of an int8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmax(int8 x)
        {
            return math.cmax(math.max(x.v4_0, x.v4_4));
        }


        /// <summary>       Returns the maximum component of a uint8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmax(uint8 x)
        {
            return math.cmax(math.max(x.v4_0, x.v4_4));
        }


        /// <summary>       Returns the maximum component of a long2 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a long3 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a long4 vector.       </summary>
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


        /// <summary>       Returns the maximum component of a ulong2 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a ulong3 vector.       </summary>
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

        /// <summary>       Returns the maximum component of a ulong4 vector.       </summary>
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


        /// <summary>       Returns the maximum component of a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmax(float8 x)
        {
            return math.cmax(math.max(x.v4_0, x.v4_4));
        }
    }
}