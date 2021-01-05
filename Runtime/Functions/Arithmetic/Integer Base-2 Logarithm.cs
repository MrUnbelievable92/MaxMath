using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul)]
        public static byte ceillog2(byte x)
        {
            return (byte)(8 - lzcnt((byte)(x - 1)));
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceillog2(byte2 x)
        {
            return 8 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceillog2(byte3 x)
        {
            return 8 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceillog2(byte4 x)
        {
            return 8 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceillog2(byte8 x)
        {
            return 8 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceillog2(byte16 x)
        {
            return 8 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceillog2(byte32 x)
        {
            return 8 - lzcnt(x - 1);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 8)]
        public static sbyte ceillog2(sbyte x)
        {
            return (sbyte)ceillog2((byte)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceillog2(sbyte2 x)
        {
            return (sbyte2)ceillog2((byte2)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceillog2(sbyte3 x)
        {
            return (sbyte3)ceillog2((byte3)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceillog2(sbyte4 x)
        {
            return (sbyte4)ceillog2((byte4)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceillog2(sbyte8 x)
        {
            return (sbyte8)ceillog2((byte8)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceillog2(sbyte16 x)
        {
            return (sbyte16)ceillog2((byte16)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceillog2(sbyte32 x)
        {
            return (sbyte32)ceillog2((byte32)x);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul)]
        public static ushort ceillog2(ushort x)
        {
            return (ushort)(16 - lzcnt((ushort)(x - 1)));
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceillog2(ushort2 x)
        {
            return 16 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceillog2(ushort3 x)
        {
            return 16 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceillog2(ushort4 x)
        {
            return 16 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceillog2(ushort8 x)
        {
            return 16 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceillog2(ushort16 x)
        {
            return 16 - lzcnt(x - 1);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 16)]
        public static short ceillog2(short x)
        {
            return (short)ceillog2((ushort)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceillog2(short2 x)
        {
            return (short2)ceillog2((ushort2)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceillog2(short3 x)
        {
            return (short3)ceillog2((ushort3)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceillog2(short4 x)
        {
            return (short4)ceillog2((ushort4)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceillog2(short8 x)
        {
            return (short8)ceillog2((ushort8)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceillog2(short16 x)
        {
            return (short16)ceillog2((ushort16)x);
        }


        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceillog2(uint8 x)
        {
            return 32 - lzcnt(x - 1);
        }


        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceillog2(int8 x)
        {
            return (int8)ceillog2((uint8)x);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 64ul)]
        public static ulong ceillog2(ulong x)
        {
            return (ulong)(64 - math.lzcnt(x - 1));
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceillog2(ulong2 x)
        {
            return 64 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceillog2(ulong3 x)
        {
            return 64 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceillog2(ulong4 x)
        {
            return 64 - lzcnt(x - 1);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0L, 64L)]
        public static long ceillog2(long x)
        {
            return (long)ceillog2((ulong)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceillog2(long2 x)
        {
            return (long2)ceillog2((ulong2)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceillog2(long3 x)
        {
            return (long3)ceillog2((ulong3)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceillog2(long4 x)
        {
            return (long4)ceillog2((ulong4)x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floorlog2(byte x)
        {
            return (byte)(7 - lzcnt((byte)(x)));
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floorlog2(byte2 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floorlog2(byte3 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floorlog2(byte4 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floorlog2(byte8 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 floorlog2(byte16 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 floorlog2(byte32 x)
        {
            return 7 - lzcnt(x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floorlog2(sbyte x)
        {
            return (sbyte)floorlog2((byte)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floorlog2(sbyte2 x)
        {
            return (sbyte2)floorlog2((byte2)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floorlog2(sbyte3 x)
        {
            return (sbyte3)floorlog2((byte3)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floorlog2(sbyte4 x)
        {
            return (sbyte4)floorlog2((byte4)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floorlog2(sbyte8 x)
        {
            return (sbyte8)floorlog2((byte8)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 floorlog2(sbyte16 x)
        {
            return (sbyte16)floorlog2((byte16)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 floorlog2(sbyte32 x)
        {
            return (sbyte32)floorlog2((byte32)x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floorlog2(ushort x)
        {
            return (ushort)(15 - lzcnt(x));
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floorlog2(ushort2 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floorlog2(ushort3 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floorlog2(ushort4 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floorlog2(ushort8 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 floorlog2(ushort16 x)
        {
            return 15 - lzcnt(x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floorlog2(short x)
        {
            return (short)floorlog2((ushort)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floorlog2(short2 x)
        {
            return (short2)floorlog2((ushort2)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floorlog2(short3 x)
        {
            return (short3)floorlog2((ushort3)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floorlog2(short4 x)
        {
            return (short4)floorlog2((ushort4)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floorlog2(short8 x)
        {
            return (short8)floorlog2((ushort8)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 floorlog2(short16 x)
        {
            return (short16)floorlog2((ushort16)x);
        }


        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 floorlog2(uint8 x)
        {
            return 31 - lzcnt(x);
        }


        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floorlog2(int8 x)
        {
            return (int8)floorlog2((uint8)x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floorlog2(ulong x)
        {
            return (ulong)(63 - math.lzcnt(x));
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floorlog2(ulong2 x)
        {
            return 63 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floorlog2(ulong3 x)
        {
            return 63 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floorlog2(ulong4 x)
        {
            return 63 - lzcnt(x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floorlog2(long x)
        {
            return (long)floorlog2((ulong)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floorlog2(long2 x)
        {
            return (long2)floorlog2((ulong2)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floorlog2(long3 x)
        {
            return (long3)floorlog2((ulong3)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of x. x must be greater than 0, otherwise the result is undefined.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floorlog2(long4 x)
        {
            return (long4)floorlog2((ulong4)x);
        }
    }
}