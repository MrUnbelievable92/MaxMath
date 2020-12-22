using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of performing a reversal of the bit pattern of a byte value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte reversebits(byte x)
        {
            x = (byte)(((x >> 1) & 0x55) | ((x & 0x55) << 1));
            x = (byte)(((x >> 2) & 0x33) | ((x & 0x33) << 2));

            return (byte)((x >> 4) | (x << 4));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a byte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 reversebits(byte2 x)
        {
            x = ((x >> 1) & 0x55) | ((x & 0x55) << 1);
            x = ((x >> 2) & 0x33) | ((x & 0x33) << 2);

            return (x >> 4) | (x << 4);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a byte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 reversebits(byte3 x)
        {
            x = ((x >> 1) & 0x55) | ((x & 0x55) << 1);
            x = ((x >> 2) & 0x33) | ((x & 0x33) << 2);

            return (x >> 4) | (x << 4);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a byte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 reversebits(byte4 x)
        {
            x = ((x >> 1) & 0x55) | ((x & 0x55) << 1);
            x = ((x >> 2) & 0x33) | ((x & 0x33) << 2);

            return (x >> 4) | (x << 4);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a byte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 reversebits(byte8 x)
        {
            x = ((x >> 1) & 0x55) | ((x & 0x55) << 1);
            x = ((x >> 2) & 0x33) | ((x & 0x33) << 2);

            return (x >> 4) | (x << 4);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a byte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 reversebits(byte16 x)
        {
            x = ((x >> 1) & 0x55) | ((x & 0x55) << 1);
            x = ((x >> 2) & 0x33) | ((x & 0x33) << 2);

            return (x >> 4) | (x << 4);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a byte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 reversebits(byte32 x)
        {
            x = ((x >> 1) & 0x55) | ((x & 0x55) << 1);
            x = ((x >> 2) & 0x33) | ((x & 0x33) << 2);

            return (x >> 4) | (x << 4);
        }


        /// <summary>       Returns the result of performing a reversal of the bit pattern of an sbyte value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte reversebits(sbyte x)
        {
            return (sbyte)reversebits((byte)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an sbyte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 reversebits(sbyte2 x)
        {
            return (sbyte2)reversebits((byte2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an sbyte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 reversebits(sbyte3 x)
        {
            return (sbyte3)reversebits((byte3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an sbyte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 reversebits(sbyte4 x)
        {
            return (sbyte4)reversebits((byte4)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an sbyte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 reversebits(sbyte8 x)
        {
            return (sbyte8)reversebits((byte8)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an sbyte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 reversebits(sbyte16 x)
        {
            return (sbyte16)reversebits((byte16)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an sbyte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 reversebits(sbyte32 x)
        {
            return (sbyte32)reversebits((byte32)x);
        }


        /// <summary>       Returns the result of performing a reversal of the bit pattern of a ushort value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort reversebits(ushort x)
        {
            x = (ushort)(((x >> 1) & 0x5555u) | ((x & 0x5555u) << 1));
            x = (ushort)(((x >> 2) & 0x3333u) | ((x & 0x3333u) << 2));
            x = (ushort)(((x >> 4) & 0x0F0Fu) | ((x & 0x0F0Fu) << 4));

            return (ushort)((x >> 8) | (x << 8));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a ushort2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 reversebits(ushort2 x)
        {
            x = ((x >> 1) & 0x5555) | ((x & 0x5555) << 1);
            x = ((x >> 2) & 0x3333) | ((x & 0x3333) << 2);
            x = ((x >> 4) & 0x0F0F) | ((x & 0x0F0F) << 4);

            return (x >> 8) | (x << 8);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a ushort3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 reversebits(ushort3 x)
        {
            x = ((x >> 1) & 0x5555) | ((x & 0x5555) << 1);
            x = ((x >> 2) & 0x3333) | ((x & 0x3333) << 2);
            x = ((x >> 4) & 0x0F0F) | ((x & 0x0F0F) << 4);

            return (x >> 8) | (x << 8);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a ushort4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 reversebits(ushort4 x)
        {
            x = ((x >> 1) & 0x5555) | ((x & 0x5555) << 1);
            x = ((x >> 2) & 0x3333) | ((x & 0x3333) << 2);
            x = ((x >> 4) & 0x0F0F) | ((x & 0x0F0F) << 4);

            return (x >> 8) | (x << 8);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a ushort16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 reversebits(ushort8 x)
        {
            x = ((x >> 1) & 0x5555) | ((x & 0x5555) << 1);
            x = ((x >> 2) & 0x3333) | ((x & 0x3333) << 2);
            x = ((x >> 4) & 0x0F0F) | ((x & 0x0F0F) << 4);

            return (x >> 8) | (x << 8);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a ushort16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 reversebits(ushort16 x)
        {
            x = ((x >> 1) & 0x5555) | ((x & 0x5555) << 1);
            x = ((x >> 2) & 0x3333) | ((x & 0x3333) << 2);
            x = ((x >> 4) & 0x0F0F) | ((x & 0x0F0F) << 4);

            return (x >> 8) | (x << 8);
        }


        /// <summary>       Returns the result of performing a reversal of the bit pattern of a short value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short reversebits(short x)
        {
            return (short)reversebits((ushort)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a short2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 reversebits(short2 x)
        {
            return (short2)reversebits((ushort2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a short3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 reversebits(short3 x)
        {
            return (short3)reversebits((ushort3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a short4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 reversebits(short4 x)
        {
            return (short4)reversebits((ushort4)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a short8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 reversebits(short8 x)
        {
            return (short8)reversebits((ushort8)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a short16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 reversebits(short16 x)
        {
            return (short16)reversebits((ushort16)x);
        }


        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a uint8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 reversebits(uint8 x)
        {
            x = ((x >> 1) & 0x5555_5555u) | ((x & 0x5555_5555u) << 1);
            x = ((x >> 2) & 0x3333_3333u) | ((x & 0x3333_3333u) << 2);
            x = ((x >> 4) & 0x0F0F_0F0Fu) | ((x & 0x0F0F_0F0Fu) << 4);
            x = ((x >> 8) & 0x00FF_00FFu) | ((x & 0x00FF_00FFu) << 8);

            return (x >> 16) | (x << 16);
        }


        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an int8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 reversebits(int8 x)
        {
            return (int8)reversebits((uint8)x);
        }


        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a ulong2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 reversebits(ulong2 x)
        {
            x = ((x >> 1)  & 0x5555_5555_5555_5555ul) | ((x & 0x5555_5555_5555_5555ul) << 1);
            x = ((x >> 2)  & 0x3333_3333_3333_3333ul) | ((x & 0x3333_3333_3333_3333ul) << 2);
            x = ((x >> 4)  & 0x0F0F_0F0F_0F0F_0F0Ful) | ((x & 0x0F0F_0F0F_0F0F_0F0Ful) << 4);
            x = ((x >> 8)  & 0x00FF_00FF_00FF_00FFul) | ((x & 0x00FF_00FF_00FF_00FFul) << 8);
            x = ((x >> 16) & 0x0000_FFFF_0000_FFFFul) | ((x & 0x0000_FFFF_0000_FFFFul) << 16);

            return (x >> 32) | (x << 32);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a ulong3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 reversebits(ulong3 x)
        {
            x = ((x >> 1)  & 0x5555_5555_5555_5555ul) | ((x & 0x5555_5555_5555_5555ul) << 1);
            x = ((x >> 2)  & 0x3333_3333_3333_3333ul) | ((x & 0x3333_3333_3333_3333ul) << 2);
            x = ((x >> 4)  & 0x0F0F_0F0F_0F0F_0F0Ful) | ((x & 0x0F0F_0F0F_0F0F_0F0Ful) << 4);
            x = ((x >> 8)  & 0x00FF_00FF_00FF_00FFul) | ((x & 0x00FF_00FF_00FF_00FFul) << 8);
            x = ((x >> 16) & 0x0000_FFFF_0000_FFFFul) | ((x & 0x0000_FFFF_0000_FFFFul) << 16);

            return (x >> 32) | (x << 32);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a ulong4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 reversebits(ulong4 x)
        {
            x = ((x >> 1)  & 0x5555_5555_5555_5555ul) | ((x & 0x5555_5555_5555_5555ul) << 1);
            x = ((x >> 2)  & 0x3333_3333_3333_3333ul) | ((x & 0x3333_3333_3333_3333ul) << 2);
            x = ((x >> 4)  & 0x0F0F_0F0F_0F0F_0F0Ful) | ((x & 0x0F0F_0F0F_0F0F_0F0Ful) << 4);
            x = ((x >> 8)  & 0x00FF_00FF_00FF_00FFul) | ((x & 0x00FF_00FF_00FF_00FFul) << 8);
            x = ((x >> 16) & 0x0000_FFFF_0000_FFFFul) | ((x & 0x0000_FFFF_0000_FFFFul) << 16);

            return (x >> 32) | (x << 32);
        }


        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a long2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 reversebits(long2 x)
        {
            return (long2)reversebits((ulong2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a long3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 reversebits(long3 x)
        {
            return (long3)reversebits((ulong3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a long4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 reversebits(long4 x)
        {
            return (long4)reversebits((ulong4)x);
        }
    }
}