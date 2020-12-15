using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //internal static v128 shl_byte(v128 v, int n)
        //{
        //    Assert.IsDefinedBitShift<byte>(n);
        //
        //    byte16 mask = (byte)(0b1111_1111 << n);
        //
        //    return mask & shl_short(v, n);
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //internal static v128 shrl_byte(v128 v, int n)
        //{
        //    Assert.IsDefinedBitShift<byte>(n);
        //
        //    byte16 mask = (byte)(0b1111_1111 >> n);
        //
        //    return mask & shrl_short(v, n);
        //}

        /// <summary>       Returns the componentwise result of rotating the bits of a byte right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ror(byte x, int n)
        {
            return (byte)((x >> n) | (x << (8 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte2 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ror(byte2 x, int n)
        {
            return (x >> n) | (x << (8 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte3 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ror(byte3 x, int n)
        {
            return (x >> n) | (x << (8 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte4 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ror(byte4 x, int n)
        {
            return (x >> n) | (x << (8 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ror(byte8 x, int n)
        {
            return (x >> n) | (x << (8 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ror(byte16 x, int n)
        {
            return (x >> n) | (x << (8 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a byte8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ror(byte32 x, int n)
        {
            return (x >> n) | (x << (8 - n));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ror(sbyte x, int n)
        {
            return (sbyte)ror((byte)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte2 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ror(sbyte2 x, int n)
        {
            return (sbyte2)ror((byte2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte3 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ror(sbyte3 x, int n)
        {
            return (sbyte3)ror((byte3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte4 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ror(sbyte4 x, int n)
        {
            return (sbyte4)ror((byte4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ror(sbyte8 x, int n)
        {
            return (sbyte8)ror((byte8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ror(sbyte16 x, int n)
        {
            return (sbyte16)ror((byte16)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an sbyte8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ror(sbyte32 x, int n)
        {
            return (sbyte32)ror((byte32)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ushort right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ror(ushort x, int n)
        {
            return (ushort)((x >> n) | (x << (16 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort2 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ror(ushort2 x, int n)
        {
            return (x >> n) | (x << (16 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort3 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ror(ushort3 x, int n)
        {
            return (x >> n) | (x << (16 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort4 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ror(ushort4 x, int n)
        {
            return (x >> n) | (x << (16 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ror(ushort8 x, int n)
        {
            return (x >> n) | (x << (16 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ushort16 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ror(ushort16 x, int n)
        {
            return (x >> n) | (x << (16 - n));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a short right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ror(short x, int n)
        {
            return (short)ror((ushort)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short2 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ror(short2 x, int n)
        {
            return (short2)ror((ushort2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short3 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ror(short3 x, int n)
        {
            return (short3)ror((ushort3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short4 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ror(short4 x, int n)
        {
            return (short4)ror((ushort4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ror(short8 x, int n)
        {
            return (short8)ror((ushort8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a short16 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ror(short16 x, int n)
        {
            return (short16)ror((ushort16)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int n)
        {
            return (x >> n) | (x << (32 - n));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an int8 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int n)
        {
            return (int8)ror((uint8)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, int n)
        {
            return (x >> n) | (x << (64 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, int n)
        {
            return (x >> n) | (x << (64 - n));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, int n)
        {
            return (x >> n) | (x << (64 - n));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, int n)
        {
            return (long2)ror((ulong2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, int n)
        {
            return (long3)ror((ulong3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 right by bits n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, int n)
        {
            return (long4)ror((ulong4)x, n);
        }
    }
}
