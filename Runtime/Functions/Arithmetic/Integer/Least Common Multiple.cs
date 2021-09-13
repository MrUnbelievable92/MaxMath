using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the least common multiple of two <see cref="UInt128"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lcm(UInt128 x, UInt128 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the least common multiple of two <see cref="Int128"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lcm(Int128 x, Int128 y)
        {
            UInt128 absX = (UInt128)abs(x);
            UInt128 absY = (UInt128)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="byte"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, (ulong)byte.MaxValue * byte.MaxValue)]
        public static uint lcm(byte x, byte y)
        {
            return lcm((uint)x, (uint)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(byte2 x, byte2 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(byte3 x, byte3 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(byte4 x, byte4 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(byte8 x, byte8 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(byte16 x, byte16 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte32"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(byte32 x, byte32 y)
        {
            return (x / gcd(x, y)) * y;
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="sbyte"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, ((ulong)sbyte.MaxValue + 1ul) * ((ulong)sbyte.MaxValue + 1ul))]
        public static uint lcm(sbyte x, sbyte y)
        {
            return lcm((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(sbyte2 x, sbyte2 y)
        {
            byte2 absX = (byte2)abs(x);
            byte2 absY = (byte2)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(sbyte3 x, sbyte3 y)
        {
            byte3 absX = (byte3)abs(x);
            byte3 absY = (byte3)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(sbyte4 x, sbyte4 y)
        {
            byte4 absX = (byte4)abs(x);
            byte4 absY = (byte4)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(sbyte8 x, sbyte8 y)
        {
            byte8 absX = (byte8)abs(x);
            byte8 absY = (byte8)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(sbyte16 x, sbyte16 y)
        {
            byte16 absX = (byte16)abs(x);
            byte16 absY = (byte16)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte32"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(sbyte32 x, sbyte32 y)
        {
            byte32 absX = (byte32)abs(x);
            byte32 absY = (byte32)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="ushort"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(ushort x, ushort y)
        {
            return lcm((uint)x, (uint)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(ushort2 x, ushort2 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(ushort3 x, ushort3 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(ushort4 x, ushort4 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(ushort8 x, ushort8 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort16"/>s.r.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(ushort16 x, ushort16 y)
        {
            return (x / gcd(x, y)) * y;
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="short"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(short x, short y)
        {
            return lcm((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(short2 x, short2 y)
        {
            ushort2 absX = (ushort2)abs(x);
            ushort2 absY = (ushort2)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(short3 x, short3 y)
        {
            ushort3 absX = (ushort3)abs(x);
            ushort3 absY = (ushort3)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(short4 x, short4 y)
        {
            ushort4 absX = (ushort4)abs(x);
            ushort4 absY = (ushort4)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(short8 x, short8 y)
        {
            ushort8 absX = (ushort8)abs(x);
            ushort8 absY = (ushort8)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(short16 x, short16 y)
        {
            ushort16 absX = (ushort16)abs(x);
            ushort16 absY = (ushort16)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }


        /// <summary>       Returns the least common multiple of the of two <see cref="int"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(int x, int y)
        {
            uint absX = (uint)math.abs(x);
            uint absY = (uint)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(int2 x, int2 y)
        {
            uint2 absX = (uint2)math.abs(x);
            uint2 absY = (uint2)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(int3 x, int3 y)
        {
            uint3 absX = (uint3)math.abs(x);
            uint3 absY = (uint3)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(int4 x, int4 y)
        {
            uint4 absX = (uint4)math.abs(x);
            uint4 absY = (uint4)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.int8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(int8 x, int8 y)
        {
            uint8 absX = (uint8)abs(x);
            uint8 absY = (uint8)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }



        /// <summary>       Returns the least common multiple of two <see cref="uint"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(uint x, uint y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(uint2 x, uint2 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(uint3 x, uint3 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(uint4 x, uint4 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.uint8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(uint8 x, uint8 y)
        {
            return (x / gcd(x, y)) * y;
        }


        /// <summary>       Returns the least common multiple of two <see cref="long"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(long x, long y)
        {
            ulong absX = (ulong)math.abs(x);
            ulong absY = (ulong)math.abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(long2 x, long2 y)
        {
            ulong2 absX = (ulong2)abs(x);
            ulong2 absY = (ulong2)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(long3 x, long3 y)
        {
            ulong3 absX = (ulong3)abs(x);
            ulong3 absY = (ulong3)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(long4 x, long4 y)
        {
            ulong4 absX = (ulong4)abs(x);
            ulong4 absY = (ulong4)abs(y);

            return (absX / gcd(absX, absY)) * absY;
        }


        /// <summary>       Returns the least common multiple of two <see cref="ulong"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(ulong x, ulong y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(ulong2 x, ulong2 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(ulong3 x, ulong3 y)
        {
            return (x / gcd(x, y)) * y;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(ulong4 x, ulong4 y)
        {
            return (x / gcd(x, y)) * y;
        }
    }
}