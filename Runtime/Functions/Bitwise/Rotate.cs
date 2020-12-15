using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise result of rotating the bits of a byte right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ror(byte x, int n)
        {
            int repeated = x | (x << 8);
            repeated |= repeated << 16;

            return (byte)math.ror(repeated, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ror(byte2 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ror(byte3 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ror(byte4 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ror(byte8 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ror(byte16 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ror(byte32 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ror(sbyte x, int n)
        {
            return (sbyte)ror((byte)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ror(sbyte2 x, int n)
        {
            return (sbyte2)ror((byte2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ror(sbyte3 x, int n)
        {
            return (sbyte3)ror((byte3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ror(sbyte4 x, int n)
        {
            return (sbyte4)ror((byte4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ror(sbyte8 x, int n)
        {
            return (sbyte8)ror((byte8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ror(sbyte16 x, int n)
        {
            return (sbyte16)ror((byte16)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ror(sbyte32 x, int n)
        {
            return (sbyte32)ror((byte32)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ushort right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ror(ushort x, int n)
        {
            int repeated = x | (x << 16);

            return (ushort)math.ror(repeated, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ror(ushort2 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ror(ushort3 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ror(ushort4 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ror(ushort8 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort16 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ror(ushort16 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a short right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ror(short x, int n)
        {
            return (short)ror((ushort)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ror(short2 x, int n)
        {
            return (short2)ror((ushort2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ror(short3 x, int n)
        {
            return (short3)ror((ushort3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ror(short4 x, int n)
        {
            return (short4)ror((ushort4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ror(short8 x, int n)
        {
            return (short8)ror((ushort8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short16 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ror(short16 x, int n)
        {
            return (short16)ror((ushort16)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int n)
        {
            n &= 31;

            return (x >> n) | (x << (-n & 31));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an int8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int n)
        {
            return (int8)ror((uint8)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, int n)
        {
            n &= 63;

            return (x >> n) | (x << (-n & 63));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, int n)
        {
            n &= 63;

            return (x >> n) | (x << (-n & 63));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, int n)
        {
            n &= 63;

            return (x >> n) | (x << (-n & 63));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, int n)
        {
            return (long2)ror((ulong2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, int n)
        {
            return (long3)ror((ulong3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, int n)
        {
            return (long4)ror((ulong4)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a byte right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte rol(byte x, int n)
        {
            int repeated = x | (x << 8);
            repeated |= repeated << 16;

            return (byte)math.rol(repeated, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 rol(byte2 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 rol(byte3 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 rol(byte4 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 rol(byte8 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 rol(byte16 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 rol(byte32 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte rol(sbyte x, int n)
        {
            return (sbyte)rol((byte)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 rol(sbyte2 x, int n)
        {
            return (sbyte2)rol((byte2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 rol(sbyte3 x, int n)
        {
            return (sbyte3)rol((byte3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 rol(sbyte4 x, int n)
        {
            return (sbyte4)rol((byte4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 rol(sbyte8 x, int n)
        {
            return (sbyte8)rol((byte8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 rol(sbyte16 x, int n)
        {
            return (sbyte16)rol((byte16)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 rol(sbyte32 x, int n)
        {
            return (sbyte32)rol((byte32)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ushort right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort rol(ushort x, int n)
        {
            int repeated = x | (x << 16);

            return (ushort)math.rol(repeated, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 rol(ushort2 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 rol(ushort3 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 rol(ushort4 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 rol(ushort8 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort16 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 rol(ushort16 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a short right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short rol(short x, int n)
        {
            return (short)rol((ushort)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 rol(short2 x, int n)
        {
            return (short2)rol((ushort2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 rol(short3 x, int n)
        {
            return (short3)rol((ushort3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 rol(short4 x, int n)
        {
            return (short4)rol((ushort4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 rol(short8 x, int n)
        {
            return (short8)rol((ushort8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short16 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 rol(short16 x, int n)
        {
            return (short16)rol((ushort16)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, int n)
        {
            n &= 31;

            return (x << n) | (x >> (-n & 31));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an int8 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, int n)
        {
            return (int8)rol((uint8)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, int n)
        {
            n &= 63;

            return (x << n) | (x >> (-n & 63));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, int n)
        {
            n &= 63;

            return (x << n) | (x >> (-n & 63));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, int n)
        {
            n &= 63;

            return (x << n) | (x >> (-n & 63));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 rol(long2 x, int n)
        {
            return (long2)rol((ulong2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, int n)
        {
            return (long3)rol((ulong3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 right by n bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, int n)
        {
            return (long4)rol((ulong4)x, n);
        }
    }
}
