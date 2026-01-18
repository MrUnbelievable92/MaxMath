using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceilpow2(UInt128 x)
        {
            if (constexpr.IS_TRUE(x <= 1ul << 63))
            {
                return math.ceilpow2(x.lo64);
            }

            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 sse = new v128(x.lo64, x.hi64);
                sse = Xse.or_si128(sse, Xse.bsrli_si128(sse,  8 / 8));
                sse = Xse.or_si128(sse, Xse.bsrli_si128(sse, 16 / 8));
                sse = Xse.or_si128(sse, Xse.bsrli_si128(sse, 32 / 8));
                sse = Xse.or_si128(sse, Xse.bsrli_si128(sse, 64 / 8));
                x = new UInt128(sse.ULong0, sse.ULong1);
            }
            else
            {
                x |= x >> 8;
                x |= x >> 16;
                x |= x >> 32;
                x |= x >> 64;
            }

            return x + 1;
        }

        /// <summary>       Returns the result of a calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceilpow2(Int128 x)
        {
            return (Int128)ceilpow2(x.value);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0ul, byte.MaxValue + 1ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceilpow2(byte x)
        {
            x -= 1;
            x |= (byte)((uint)x >> 1);
            x |= (byte)((uint)x >> 2);
            x |= (byte)((uint)x >> 4);

            return x + 1u;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceilpow2(byte2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceilpow2(byte3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceilpow2(byte4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceilpow2(byte8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceilpow2(byte16 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceilpow2(byte32 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0L, (long)sbyte.MaxValue + 1L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceilpow2(sbyte x)
        {
            return (int)ceilpow2((byte)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceilpow2(sbyte2 x)
        {
            return (sbyte2)ceilpow2((byte2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceilpow2(sbyte3 x)
        {
            return (sbyte3)ceilpow2((byte3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceilpow2(sbyte4 x)
        {
            return (sbyte4)ceilpow2((byte4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceilpow2(sbyte8 x)
        {
            return (sbyte8)ceilpow2((byte8)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceilpow2(sbyte16 x)
        {
            return (sbyte16)ceilpow2((byte16)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceilpow2(sbyte32 x)
        {
            return (sbyte32)ceilpow2((byte32)x);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0ul, ushort.MaxValue + 1ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceilpow2(ushort x)
        {
            x -= 1;
            x |= (ushort)((uint)x >> 1);
            x |= (ushort)((uint)x >> 2);
            x |= (ushort)((uint)x >> 4);
            x |= (ushort)((uint)x >> 8);

            return x + 1u;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0L, short.MaxValue + 1L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceilpow2(short x)
        {
            return (int)ceilpow2((ushort)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceilpow2(short2 x)
        {
            return (short2)ceilpow2((ushort2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceilpow2(short3 x)
        {
            return (short3)ceilpow2((ushort3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceilpow2(short4 x)
        {
            return (short4)ceilpow2((ushort4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceilpow2(short8 x)
        {
            return (short8)ceilpow2((ushort8)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceilpow2(short16 x)
        {
            return (short16)ceilpow2((ushort16)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceilpow2(int8 x)
        {
            return (int8)ceilpow2((uint8)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceilpow2(long2 x)
        {
            return (long2)ceilpow2((ulong2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceilpow2(long3 x)
        {
            return (long3)ceilpow2((ulong3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceilpow2(long4 x)
        {
            return (long4)ceilpow2((ulong4)x);
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
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


        /// <summary>       Returns the result of a calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 floorpow2(UInt128 x)
        {
            if (constexpr.IS_TRUE(x.hi64 == 0))
            {
                return floorpow2(x.lo64);
            }

            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 sse = new v128(x.lo64, x.hi64);
                sse = Xse.or_si128(sse, Xse.bsrli_si128(sse, 1));
                sse = Xse.or_si128(sse, Xse.bsrli_si128(sse, 2));
                sse = Xse.or_si128(sse, Xse.bsrli_si128(sse, 4));
                sse = Xse.or_si128(sse, Xse.bsrli_si128(sse, 8));
                x = new UInt128(sse.ULong0, sse.ULong1);
            }
            else
            {
                x |= x >> 8;
                x |= x >> 16;
                x |= x >> 32;
                x |= x >> 64;
            }

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 floorpow2(Int128 x)
        {
            return (Int128)floorpow2(x.value);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0ul, (byte.MaxValue + 1ul) / 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floorpow2(byte x)
        {
            x |= (byte)((uint)x >> 1);
            x |= (byte)((uint)x >> 2);
            x |= (byte)((uint)x >> 4);

            return (byte)((uint)x - ((uint)x >> 1));
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floorpow2(byte2 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floorpow2(byte3 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floorpow2(byte4 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floorpow2(byte8 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 floorpow2(byte16 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 floorpow2(byte32 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x - (x >> 1);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0L, ((long)sbyte.MaxValue + 1L) / 2L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floorpow2(sbyte x)
        {
            return (sbyte)floorpow2((byte)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floorpow2(sbyte2 x)
        {
            return (sbyte2)floorpow2((byte2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floorpow2(sbyte3 x)
        {
            return (sbyte3)floorpow2((byte3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floorpow2(sbyte4 x)
        {
            return (sbyte4)floorpow2((byte4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floorpow2(sbyte8 x)
        {
            return (sbyte8)floorpow2((byte8)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 floorpow2(sbyte16 x)
        {
            return (sbyte16)floorpow2((byte16)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 floorpow2(sbyte32 x)
        {
            return (sbyte32)floorpow2((byte32)x);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0ul, (ushort.MaxValue + 1ul) / 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floorpow2(ushort x)
        {
            x |= (ushort)((uint)x >> 1);
            x |= (ushort)((uint)x >> 2);
            x |= (ushort)((uint)x >> 4);
            x |= (ushort)((uint)x >> 8);

            return (ushort)((uint)x - ((uint)x >> 1));
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floorpow2(ushort2 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floorpow2(ushort3 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floorpow2(ushort4 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floorpow2(ushort8 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 floorpow2(ushort16 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x - (x >> 1);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0L, (short.MaxValue + 1L) / 2L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floorpow2(short x)
        {
            return (short)floorpow2((ushort)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floorpow2(short2 x)
        {
            return (short2)floorpow2((ushort2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floorpow2(short3 x)
        {
            return (short3)floorpow2((ushort3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floorpow2(short4 x)
        {
            return (short4)floorpow2((ushort4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floorpow2(short8 x)
        {
            return (short8)floorpow2((ushort8)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 floorpow2(short16 x)
        {
            return (short16)floorpow2((ushort16)x);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0L, (int.MaxValue + 1L) / 2L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floorpow2(int x)
        {
            return (int)floorpow2((uint)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floorpow2(int2 x)
        {
            return (int2)floorpow2((uint2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floorpow2(int3 x)
        {
            return (int3)floorpow2((uint3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floorpow2(int4 x)
        {
            return (int4)floorpow2((uint4)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floorpow2(int8 x)
        {
            return (int8)floorpow2((uint8)x);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0ul, (uint.MaxValue + 1ul) / 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint floorpow2(uint x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 floorpow2(uint2 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 floorpow2(uint3 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 floorpow2(uint4 x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
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


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0L, 1L << 61)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floorpow2(long x)
        {
            return (long)floorpow2((ulong)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floorpow2(long2 x)
        {
            return (long2)floorpow2((ulong2)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floorpow2(long3 x)
        {
            return (long3)floorpow2((ulong3)x);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floorpow2(long4 x)
        {
            return (long4)floorpow2((ulong4)x);
        }


        /// <summary>       Returns the result of calculation of the smallest power of two greater than or equal to <paramref name="x"/>.     </summary>
        [return: AssumeRange(0ul, 1ul << 62)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floorpow2(ulong x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;

            return x - (x >> 1);
        }

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
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

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
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

        /// <summary>       Returns the result of a componentwise calculation of the floor power of two smaller than or equal to <paramref name="x"/>.     </summary>
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