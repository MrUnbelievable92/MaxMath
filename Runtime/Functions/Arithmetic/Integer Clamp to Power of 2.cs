using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceilpow2(byte2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceilpow2(byte3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceilpow2(byte4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceilpow2(byte8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceilpow2(byte16 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceilpow2(byte32 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceilpow2(sbyte2 x)
        {
            return (sbyte2)ceilpow2((byte2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceilpow2(sbyte3 x)
        {
            return (sbyte3)ceilpow2((byte3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceilpow2(sbyte4 x)
        {
            return (sbyte4)ceilpow2((byte4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceilpow2(sbyte8 x)
        {
            return (sbyte8)ceilpow2((byte8)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceilpow2(sbyte16 x)
        {
            return (sbyte16)ceilpow2((byte16)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceilpow2(sbyte32 x)
        {
            return (sbyte32)ceilpow2((byte32)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceilpow2(ushort2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceilpow2(ushort3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceilpow2(ushort4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceilpow2(ushort8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceilpow2(ushort16 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceilpow2(short2 x)
        {
            return (short2)ceilpow2((ushort2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceilpow2(short3 x)
        {
            return (short3)ceilpow2((ushort3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceilpow2(short4 x)
        {
            return (short4)ceilpow2((ushort4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceilpow2(short8 x)
        {
            return (short8)ceilpow2((ushort8)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceilpow2(short16 x)
        {
            return (short16)ceilpow2((ushort16)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceilpow2(int8 x)
        {
            return (int8)ceilpow2((uint8)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceilpow2(uint8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceilpow2(long2 x)
        {
            return (long2)ceilpow2((ulong2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceilpow2(long3 x)
        {
            return (long3)ceilpow2((ulong3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceilpow2(long4 x)
        {
            return (long4)ceilpow2((ulong4)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceilpow2(ulong2 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return shrl(0x8000_0000_0000_0000, lzcnt(x - 1) - 1);
            }
            else
            {
                x -= 1;
                x |= x >> 1;
                x |= x >> 2;
                x |= x >> 4;
                x |= x >> 8;
                x |= x >> 16;
                x |= x >> 32;

                return x + 1;
            }
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceilpow2(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return shrl(0x8000_0000_0000_0000, lzcnt(x - 1) - 1);
            }
            else
            {
                x -= 1;
                x |= x >> 1;
                x |= x >> 2;
                x |= x >> 4;
                x |= x >> 8;
                x |= x >> 16;
                x |= x >> 32;

                return x + 1;
            }
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceilpow2(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return shrl(0x8000_0000_0000_0000, lzcnt(x - 1) - 1);
            }
            else
            {
                x -= 1;
                x |= x >> 1;
                x |= x >> 2;
                x |= x >> 4;
                x |= x >> 8;
                x |= x >> 16;
                x |= x >> 32;

                return x + 1;
            }
        }


        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floorpow2(byte2 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floorpow2(byte3 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floorpow2(byte4 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floorpow2(byte8 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 floorpow2(byte16 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 floorpow2(byte32 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }


        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floorpow2(sbyte2 x)
        {
            return (sbyte2)floorpow2((byte2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floorpow2(sbyte3 x)
        {
            return (sbyte3)floorpow2((byte3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floorpow2(sbyte4 x)
        {
            return (sbyte4)floorpow2((byte4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floorpow2(sbyte8 x)
        {
            return (sbyte8)floorpow2((byte8)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 floorpow2(sbyte16 x)
        {
            return (sbyte16)floorpow2((byte16)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 floorpow2(sbyte32 x)
        {
            return (sbyte32)floorpow2((byte32)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floorpow2(ushort2 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floorpow2(ushort3 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floorpow2(ushort4 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floorpow2(ushort8 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 floorpow2(ushort16 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }


        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floorpow2(short2 x)
        {
            return (short2)floorpow2((ushort2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floorpow2(short3 x)
        {
            return (short3)floorpow2((ushort3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floorpow2(short4 x)
        {
            return (short4)floorpow2((ushort4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floorpow2(short8 x)
        {
            return (short8)floorpow2((ushort8)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 floorpow2(short16 x)
        {
            return (short16)floorpow2((ushort16)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floorpow2(int8 x)
        {
            return (int8)floorpow2((uint8)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 floorpow2(uint8 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return x - (x >> 1);
        }


        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floorpow2(long2 x)
        {
            return (long2)floorpow2((ulong2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floorpow2(long3 x)
        {
            return (long3)floorpow2((ulong3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floorpow2(long4 x)
        {
            return (long4)floorpow2((ulong4)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floorpow2(ulong2 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return shrl(0x8000_0000_0000_0000, lzcnt(x));
            }
            else
            {
                x |= x >> 1;
                x |= x >> 2;
                x |= x >> 4;
                x |= x >> 8;
                x |= x >> 16;
                x |= x >> 32;

                return x - (x >> 1);
            }
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floorpow2(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return shrl(0x8000_0000_0000_0000, lzcnt(x));
            }
            else
            {
                x |= x >> 1;
                x |= x >> 2;
                x |= x >> 4;
                x |= x >> 8;
                x |= x >> 16;
                x |= x >> 32;

                return x - (x >> 1);
            }
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floorpow2(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return shrl(0x8000_0000_0000_0000, lzcnt(x));
            }
            else
            {
                x |= x >> 1;
                x |= x >> 2;
                x |= x >> 4;
                x |= x >> 8;
                x |= x >> 16;
                x |= x >> 32;

                return x - (x >> 1);
            }
        }
    }
}
