using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of rotating the bits of a <see cref="UInt128"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ror(UInt128 x, int n)
        {
            n &= 127;

            if (Ssse3.IsSsse3Supported)
            {
                if (Constant.IsConstantExpression(n) && n % 8 == 0 && n != 64)
                {
                    return Operator.ror128_Sse(x, n);
                }
            }

            return (x >> n) | (x << (128 - n));
        }

        /// <summary>       Returns the result of rotating the bits of an <see cref="Int128"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ror(Int128 x, int n)
        {
            return (Int128)ror(x.intern, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="byte"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ror(byte x, int n)
        {
            n &= 7;

            return (byte)((x >> n) | (x << (8 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ror(byte2 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ror(byte3 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ror(byte4 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ror(byte8 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte16"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ror(byte16 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte32"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ror(byte32 x, int n)
        {
            n &= 7;

            return (x >> n) | (x << (-n & 7));
        }


        /// <summary>       Returns the result of rotating the bits of an <see cref="sbyte"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ror(sbyte x, int n)
        {
            return (sbyte)ror((byte)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ror(sbyte2 x, int n)
        {
            return (sbyte2)ror((byte2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ror(sbyte3 x, int n)
        {
            return (sbyte3)ror((byte3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ror(sbyte4 x, int n)
        {
            return (sbyte4)ror((byte4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ror(sbyte8 x, int n)
        {
            return (sbyte8)ror((byte8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte16"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ror(sbyte16 x, int n)
        {
            return (sbyte16)ror((byte16)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte32"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ror(sbyte32 x, int n)
        {
            return (sbyte32)ror((byte32)x, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="ushort"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ror(ushort x, int n)
        {
            n &= 15;

            return (ushort)((x >> n) | (x << (16 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ror(ushort2 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ror(ushort3 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ror(ushort4 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ror(ushort8 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort16"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ror(ushort16 x, int n)
        {
            n &= 15;

            return (x >> n) | (x << (-n & 15));
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="short"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ror(short x, int n)
        {
            return (short)ror((ushort)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ror(short2 x, int n)
        {
            return (short2)ror((ushort2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ror(short3 x, int n)
        {
            return (short3)ror((ushort3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ror(short4 x, int n)
        {
            return (short4)ror((ushort4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ror(short8 x, int n)
        {
            return (short8)ror((ushort8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short16"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ror(short16 x, int n)
        {
            return (short16)ror((ushort16)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.uint8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int n)
        {
            n &= 31;

            return (x >> n) | (x << (-n & 31));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.int8"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int n)
        {
            return (int8)ror((uint8)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, int n)
        {
            n &= 63;

            return (x >> n) | (x << (-n & 63));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, int n)
        {
            n &= 63;

            return (x >> n) | (x << (-n & 63));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, int n)
        {
            n &= 63;

            return (x >> n) | (x << (-n & 63));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long2"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, int n)
        {
            return (long2)ror((ulong2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long3"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, int n)
        {
            return (long3)ror((ulong3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long4"/> right by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, int n)
        {
            return (long4)ror((ulong4)x, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="UInt128"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 rol(UInt128 x, int n)
        {
            n &= 127;

            if (Ssse3.IsSsse3Supported)
            {
                if (Constant.IsConstantExpression(n) && n % 8 == 0 && n != 64)
                {
                    return Operator.rol128_Sse(x, n);
                }
            }

            return (x << n) | (x >> (128 - n));
        }

        /// <summary>       Returns the result of rotating the bits of an <see cref="Int128"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 rol(Int128 x, int n)
        {
            return (Int128)rol(x.intern, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="byte"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte rol(byte x, int n)
        {
            n &= 7;

            return (byte)((x << n) | (x >> (8 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 rol(byte2 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 rol(byte3 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 rol(byte4 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 rol(byte8 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte16"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 rol(byte16 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.byte32"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 rol(byte32 x, int n)
        {
            n &= 7;

            return (x << n) | (x >> (-n & 7));
        }


        /// <summary>       Returns the result of rotating the bits of an <see cref="sbyte"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte rol(sbyte x, int n)
        {
            return (sbyte)rol((byte)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 rol(sbyte2 x, int n)
        {
            return (sbyte2)rol((byte2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 rol(sbyte3 x, int n)
        {
            return (sbyte3)rol((byte3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 rol(sbyte4 x, int n)
        {
            return (sbyte4)rol((byte4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 rol(sbyte8 x, int n)
        {
            return (sbyte8)rol((byte8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte16"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 rol(sbyte16 x, int n)
        {
            return (sbyte16)rol((byte16)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.sbyte32"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 rol(sbyte32 x, int n)
        {
            return (sbyte32)rol((byte32)x, n);
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="ushort"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort rol(ushort x, int n)
        {
            n &= 15;

            return (ushort)((x << n) | (x >> (16 - n)));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 rol(ushort2 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 rol(ushort3 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 rol(ushort4 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 rol(ushort8 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ushort16"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 rol(ushort16 x, int n)
        {
            n &= 15;

            return (x << n) | (x >> (-n & 15));
        }


        /// <summary>       Returns the result of rotating the bits of a <see cref="short"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short rol(short x, int n)
        {
            return (short)rol((ushort)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 rol(short2 x, int n)
        {
            return (short2)rol((ushort2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 rol(short3 x, int n)
        {
            return (short3)rol((ushort3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 rol(short4 x, int n)
        {
            return (short4)rol((ushort4)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 rol(short8 x, int n)
        {
            return (short8)rol((ushort8)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.short16"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 rol(short16 x, int n)
        {
            return (short16)rol((ushort16)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.uint8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, int n)
        {
            n &= 31;

            return (x << n) | (x >> (-n & 31));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of an <see cref="MaxMath.int8"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, int n)
        {
            return (int8)rol((uint8)x, n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, int n)
        {
            n &= 63;

            return (x << n) | (x >> (-n & 63));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, int n)
        {
            n &= 63;

            return (x << n) | (x >> (-n & 63));
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.ulong4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, int n)
        {
            n &= 63;

            return (x << n) | (x >> (-n & 63));
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long2"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 rol(long2 x, int n)
        {
            return (long2)rol((ulong2)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long3"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, int n)
        {
            return (long3)rol((ulong3)x, n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a <see cref="MaxMath.long4"/> left by <paramref name="n"/> bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, int n)
        {
            return (long4)rol((ulong4)x, n);
        }
    }
}
