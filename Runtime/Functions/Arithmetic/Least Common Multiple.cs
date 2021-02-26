using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two byte2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(byte2 x, byte2 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two byte3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(byte3 x, byte3 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two byte4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(byte4 x, byte4 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two byte8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(byte8 x, byte8 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two byte16 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(byte16 x, byte16 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two byte32 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(byte32 x, byte32 y)
        {
            return (x / gcd(x, y)) * y;
        }


        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two sbyte2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(sbyte2 x, sbyte2 y)
        {
            byte2 absX = (byte2)abs(x);
            byte2 absY = (byte2)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two sbyte3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(sbyte3 x, sbyte3 y)
        {
            byte3 absX = (byte3)abs(x);
            byte3 absY = (byte3)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two sbyte4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(sbyte4 x, sbyte4 y)
        {
            byte4 absX = (byte4)abs(x);
            byte4 absY = (byte4)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two sbyte8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(sbyte8 x, sbyte8 y)
        {
            byte8 absX = (byte8)abs(x);
            byte8 absY = (byte8)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two sbyte16 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(sbyte16 x, sbyte16 y)
        {
            byte16 absX = (byte16)abs(x);
            byte16 absY = (byte16)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two sbyte32 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(sbyte32 x, sbyte32 y)
        {
            byte32 absX = (byte32)abs(x);
            byte32 absY = (byte32)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }


        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two ushort2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(ushort2 x, ushort2 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two ushort3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(ushort3 x, ushort3 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two ushort4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(ushort4 x, ushort4 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two ushort8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(ushort8 x, ushort8 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two ushort16 vectors.r.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(ushort16 x, ushort16 y)
        {
            return (x / gcd(x, y)) * y;
        }


        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two short2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(short2 x, short2 y)
        {
            ushort2 absX = (ushort2)abs(x);
            ushort2 absY = (ushort2)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two short3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(short3 x, short3 y)
        {
            ushort3 absX = (ushort3)abs(x);
            ushort3 absY = (ushort3)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two short4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(short4 x, short4 y)
        {
            ushort4 absX = (ushort4)abs(x);
            ushort4 absY = (ushort4)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two short8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(short8 x, short8 y)
        {
            ushort8 absX = (ushort8)abs(x);
            ushort8 absY = (ushort8)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two short16 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(short16 x, short16 y)
        {
            ushort16 absX = (ushort16)abs(x);
            ushort16 absY = (ushort16)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }


        /// <summary>       Returns the least common multiple of the corresponding values of two ints.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(int x, int y)
        {
            uint absX = (uint)math.abs(x);
            uint absY = (uint)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two int2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(int2 x, int2 y)
        {
            uint2 absX = (uint2)math.abs(x);
            uint2 absY = (uint2)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two int3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(int3 x, int3 y)
        {
            uint3 absX = (uint3)math.abs(x);
            uint3 absY = (uint3)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two int4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(int4 x, int4 y)
        {
            uint4 absX = (uint4)math.abs(x);
            uint4 absY = (uint4)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two int8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(int8 x, int8 y)
        {
            uint8 absX = (uint8)abs(x);
            uint8 absY = (uint8)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }



        /// <summary>       Returns the least common multiple of the corresponding values of two uints.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(uint x, uint y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two uint2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(uint2 x, uint2 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two uint3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(uint3 x, uint3 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two uint4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(uint4 x, uint4 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two uint8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(uint8 x, uint8 y)
        {
            return (x / gcd(x, y)) * y;
        }


        /// <summary>       Returns the least common multiple of the corresponding values of two longs.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(long x, long y)
        {
            ulong absX = (ulong)math.abs(x);
            ulong absY = (ulong)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two long2 vectors.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(long2 x, long2 y)
        {
            ulong2 absX = (ulong2)abs(x);
            ulong2 absY = (ulong2)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two long3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(long3 x, long3 y)
        {
            ulong3 absX = (ulong3)abs(x);
            ulong3 absY = (ulong3)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two long4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(long4 x, long4 y)
        {
            ulong4 absX = (ulong4)abs(x);
            ulong4 absY = (ulong4)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }


        /// <summary>       Returns the least common multiple of the corresponding values of two ulongs.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(ulong x, ulong y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two ulong2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(ulong2 x, ulong2 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two ulong3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(ulong3 x, ulong3 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two ulong4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(ulong4 x, ulong4 y)
        {
            return (x / gcd(x, y)) * y;
        }
    }
}