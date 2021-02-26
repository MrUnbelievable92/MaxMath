using System.Runtime.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ror(sbyte2 x, sbyte2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 7;

                return (sbyte2)(shrl((byte2)x, (byte2)n) | shl((byte2)x, (byte2)(-n & 7)));
            }
            else
            {
                return new sbyte2(ror(x.x, n.x), ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ror(sbyte3 x, sbyte3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 7;

                return (sbyte3)(shrl((byte3)x, (byte3)n) | shl((byte3)x, (byte3)(-n & 7)));
            }
            else
            {
                return new sbyte3(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ror(sbyte4 x, sbyte4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 7;

                return (sbyte4)(shrl((byte4)x, (byte4)n) | shl((byte4)x, (byte4)(-n & 7)));
            }
            else
            {
                return new sbyte4(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z), ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ror(sbyte8 x, sbyte8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 7;

                return (sbyte8)(shrl((byte8)x, (byte8)n) | shl((byte8)x, (byte8)(-n & 7)));
            }
            else
            {
                return new sbyte8(ror(x.x0, n.x0), ror(x.x1, n.x1), ror(x.x2, n.x2), ror(x.x3, n.x3), ror(x.x4, n.x4), ror(x.x5, n.x5), ror(x.x6, n.x6), ror(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ror(sbyte16 x, sbyte16 n)
        {
            return new sbyte16(ror(x.v8_0, n.v8_0), ror(x.v8_8, n.v8_8));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ror(sbyte32 x, sbyte32 n)
        {
            return new sbyte32(ror(x.v8_0, n.v8_0), ror(x.v8_8, n.v8_8), ror(x.v8_16, n.v8_16), ror(x.v8_24, n.v8_24));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a byte2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ror(byte2 x, byte2 n)
        {
            return (byte2)ror((sbyte2)x, (sbyte2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ror(byte3 x, byte3 n)
        {
            return (byte3)ror((sbyte3)x, (sbyte3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ror(byte4 x, byte4 n)
        {
            return (byte4)ror((sbyte4)x, (sbyte4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ror(byte8 x, byte8 n)
        {
            return (byte8)ror((sbyte8)x, (sbyte8)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ror(byte16 x, byte16 n)
        {
            return (byte16)ror((sbyte16)x, (sbyte16)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ror(byte32 x, byte32 n)
        {
            return (byte32)ror((sbyte32)x, (sbyte32)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a short2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ror(short2 x, short2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 15;

                return (short2)(shrl((ushort2)x, (ushort2)n) | shl((ushort2)x, (ushort2)(-n & 15)));
            }
            else
            {
                return new short2(ror(x.x, n.x), ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ror(short3 x, short3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 15;

                return (short3)(shrl((ushort3)x, (ushort3)n) | shl((ushort3)x, (ushort3)(-n & 15)));
            }
            else
            {
                return new short3(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ror(short4 x, short4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 15;

                return (short4)(shrl((ushort4)x, (ushort4)n) | shl((ushort4)x, (ushort4)(-n & 15)));
            }
            else
            {
                return new short4(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z), ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ror(short8 x, short8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 15;

                return (short8)(shrl((ushort8)x, (ushort8)n) | shl((ushort8)x, (ushort8)(-n & 15)));
            }
            else
            {
                return new short8(ror(x.x0, n.x0), ror(x.x1, n.x1), ror(x.x2, n.x2), ror(x.x3, n.x3), ror(x.x4, n.x4), ror(x.x5, n.x5), ror(x.x6, n.x6), ror(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ror(short16 x, short16 n)
        {
            return new short16(ror(x.v8_0, n.v8_0), ror(x.v8_8, n.v8_8));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ushort2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ror(ushort2 x, ushort2 n)
        {
            return (ushort2)ror((short2)x, (short2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ror(ushort3 x, ushort3 n)
        {
            return (ushort3)ror((short3)x, (short3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ror(ushort4 x, ushort4 n)
        {
            return (ushort4)ror((short4)x, (short4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ror(ushort8 x, ushort8 n)
        {
            return (ushort8)ror((short8)x, (short8)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ror(ushort16 x, ushort16 n)
        {
            return (ushort16)ror((short16)x, (short16)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an int2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ror(int2 x, int2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shrl(x, n) | shl(x, -n & 31);
            }
            else
            {
                return new int2(math.ror(x.x, n.x), math.ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an int3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ror(int3 x, int3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shrl(x, n) | shl(x, -n & 31);
            }
            else
            {
                return new int3(math.ror(x.x, n.x), math.ror(x.y, n.y), math.ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an int4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ror(int4 x, int4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shrl(x, n) | shl(x, -n & 31);
            }
            else
            {
                return new int4(math.ror(x.x, n.x), math.ror(x.y, n.y), math.ror(x.z, n.z), math.ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an int8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shrl(x, n) | shl(x, -n & 31);
            }
            else
            {
                return new int8(math.ror(x.x0, n.x0), math.ror(x.x1, n.x1), math.ror(x.x2, n.x2), math.ror(x.x3, n.x3), math.ror(x.x4, n.x4), math.ror(x.x5, n.x5), math.ror(x.x6, n.x6), math.ror(x.x7, n.x7));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, uint2 n)
        {
            return (uint2)ror((int2)x, (int2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, uint3 n)
        {
            return (uint3)ror((int3)x, (int3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, uint4 n)
        {
            return (uint4)ror((int4)x, (int4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, uint8 n)
        {
            return (uint8)ror((int8)x, (int8)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, int2 n)
        {
            return ror(x, (uint2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, int3 n)
        {
            return ror(x, (uint3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, int4 n)
        {
            return ror(x, (uint4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int8 n)
        {
            return ror(x, (uint8)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, long2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 63;

                return shrl(x, n) | shl(x, -n & 63);
            }
            else
            {
                return new long2(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, long3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 63;

                return shrl(x, n) | shl(x, -n & 63);
            }
            else
            {
                return new long3(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y), math.ror(x.z, (int)n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, long4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 63;

                return shrl(x, n) | shl(x, -n & 63);
            }
            else
            {
                return new long4(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y), math.ror(x.z, (int)n.z), math.ror(x.w, (int)n.w));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, ulong2 n)
        {
            return (ulong2)ror((long2)x, (long2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, ulong3 n)
        {
            return (ulong3)ror((long3)x, (long3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, ulong4 n)
        {
            return (ulong4)ror((long4)x, (long4)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, long2 n)
        {
            return ror(x, (ulong2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, long3 n)
        {
            return ror(x, (ulong3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, long4 n)
        {
            return ror(x, (ulong4)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 rol(sbyte2 x, sbyte2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 7;

                return (sbyte2)(shl((byte2)x, (byte2)n) | shrl((byte2)x, (byte2)(-n & 7)));
            }
            else
            {
                return new sbyte2(rol(x.x, n.x), rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 rol(sbyte3 x, sbyte3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 7;

                return (sbyte3)(shl((byte3)x, (byte3)n) | shrl((byte3)x, (byte3)(-n & 7)));
            }
            else
            {
                return new sbyte3(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 rol(sbyte4 x, sbyte4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 7;

                return (sbyte4)(shl((byte4)x, (byte4)n) | shrl((byte4)x, (byte4)(-n & 7)));
            }
            else
            {
                return new sbyte4(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z), rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 rol(sbyte8 x, sbyte8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 7;

                return (sbyte8)(shl((byte8)x, (byte8)n) | shrl((byte8)x, (byte8)(-n & 7)));
            }
            else
            {
                return new sbyte8(rol(x.x0, n.x0), rol(x.x1, n.x1), rol(x.x2, n.x2), rol(x.x3, n.x3), rol(x.x4, n.x4), rol(x.x5, n.x5), rol(x.x6, n.x6), rol(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 rol(sbyte16 x, sbyte16 n)
        {
            return new sbyte16(rol(x.v8_0, n.v8_0), rol(x.v8_8, n.v8_8));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 rol(sbyte32 x, sbyte32 n)
        {
            return new sbyte32(rol(x.v8_0, n.v8_0), rol(x.v8_8, n.v8_8), rol(x.v8_16, n.v8_16), rol(x.v8_24, n.v8_24));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a byte2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 rol(byte2 x, byte2 n)
        {
            return (byte2)rol((sbyte2)x, (sbyte2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 rol(byte3 x, byte3 n)
        {
            return (byte3)rol((sbyte3)x, (sbyte3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 rol(byte4 x, byte4 n)
        {
            return (byte4)rol((sbyte4)x, (sbyte4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 rol(byte8 x, byte8 n)
        {
            return (byte8)rol((sbyte8)x, (sbyte8)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 rol(byte16 x, byte16 n)
        {
            return (byte16)rol((sbyte16)x, (sbyte16)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 rol(byte32 x, byte32 n)
        {
            return (byte32)rol((sbyte32)x, (sbyte32)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a short2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 rol(short2 x, short2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 15;

                return (short2)(shl((ushort2)x, (ushort2)n) | shrl((ushort2)x, (ushort2)(-n & 15)));
            }
            else
            {
                return new short2(rol(x.x, n.x), rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 rol(short3 x, short3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 15;

                return (short3)(shl((ushort3)x, (ushort3)n) | shrl((ushort3)x, (ushort3)(-n & 15)));
            }
            else
            {
                return new short3(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 rol(short4 x, short4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 15;

                return (short4)(shl((ushort4)x, (ushort4)n) | shrl((ushort4)x, (ushort4)(-n & 15)));
            }
            else
            {
                return new short4(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z), rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 rol(short8 x, short8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 15;

                return (short8)(shl((ushort8)x, (ushort8)n) | shrl((ushort8)x, (ushort8)(-n & 15)));
            }
            else
            {
                return new short8(rol(x.x0, n.x0), rol(x.x1, n.x1), rol(x.x2, n.x2), rol(x.x3, n.x3), rol(x.x4, n.x4), rol(x.x5, n.x5), rol(x.x6, n.x6), rol(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 rol(short16 x, short16 n)
        {
            return new short16(rol(x.v8_0, n.v8_0), rol(x.v8_8, n.v8_8));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ushort2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 rol(ushort2 x, ushort2 n)
        {
            return (ushort2)rol((short2)x, (short2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 rol(ushort3 x, ushort3 n)
        {
            return (ushort3)rol((short3)x, (short3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 rol(ushort4 x, ushort4 n)
        {
            return (ushort4)rol((short4)x, (short4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 rol(ushort8 x, ushort8 n)
        {
            return (ushort8)rol((short8)x, (short8)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 rol(ushort16 x, ushort16 n)
        {
            return (ushort16)rol((short16)x, (short16)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an int2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 rol(int2 x, int2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 31;

                return shl(x, n) | shrl(x, -n & 31);
            }
            else
            {
                return new int2(math.rol(x.x, n.x), math.rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an int3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 rol(int3 x, int3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 31;

                return shl(x, n) | shrl(x, -n & 31);
            }
            else
            {
                return new int3(math.rol(x.x, n.x), math.rol(x.y, n.y), math.rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an int4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 rol(int4 x, int4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 31;

                return shl(x, n) | shrl(x, -n & 31);
            }
            else
            {
                return new int4(math.rol(x.x, n.x), math.rol(x.y, n.y), math.rol(x.z, n.z), math.rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an int8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, int8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 31;

                return shl(x, n) | shrl(x, -n & 31);
            }
            else
            {
                return new int8(math.rol(x.x0, n.x0), math.rol(x.x1, n.x1), math.rol(x.x2, n.x2), math.rol(x.x3, n.x3), math.rol(x.x4, n.x4), math.rol(x.x5, n.x5), math.rol(x.x6, n.x6), math.rol(x.x7, n.x7));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, uint2 n)
        {
            return (uint2)rol((int2)x, (int2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, uint3 n)
        {
            return (uint3)rol((int3)x, (int3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, uint4 n)
        {
            return (uint4)rol((int4)x, (int4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, uint8 n)
        {
            return (uint8)rol((int8)x, (int8)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, int2 n)
        {
            return rol(x, (uint2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, int3 n)
        {
            return rol(x, (uint3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, int4 n)
        {
            return rol(x, (uint4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, int8 n)
        {
            return rol(x, (uint8)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 rol(long2 x, long2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 63;

                return shl(x, n) | shrl(x, -n & 63);
            }
            else
            {
                return new long2(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, long3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 63;

                return shl(x, n) | shrl(x, -n & 63);
            }
            else
            {
                return new long3(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y), math.rol(x.z, (int)n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, long4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                n &= 63;

                return shl(x, n) | shrl(x, -n & 63);
            }
            else
            {
                return new long4(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y), math.rol(x.z, (int)n.z), math.rol(x.w, (int)n.w));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, ulong2 n)
        {
            return (ulong2)rol((long2)x, (long2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, ulong3 n)
        {
            return (ulong3)rol((long3)x, (long3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, ulong4 n)
        {
            return (ulong4)rol((long4)x, (long4)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, long2 n)
        {
            return rol(x, (ulong2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, long3 n)
        {
            return rol(x, (ulong3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, long4 n)
        {
            return rol(x, (ulong4)n);
        }
    }
}
