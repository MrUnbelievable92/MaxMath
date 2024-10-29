using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 mad(UInt128 a, UInt128 b, UInt128 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 mad(Int128 a, Int128 b, Int128 c)
        {
            return (a * b) + c;
        }


        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 mad(float8 a, float8 b, float8 c)
        {
            // fmad operations will be chosen if Burst.FloatMode.Fast is selected.

            return (a * b) + c;
        }


        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 mad(uint8 a, uint8 b, uint8 c)
        {
            return (a * b) + c;
        }


        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 mad(int8 a, int8 b, int8 c)
        {
            return (a * b) + c;
        }


        /// <summary>       Returns the result of a multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="byte"/>s.    </summary>
        [return: AssumeRange(0ul, (ulong)byte.MaxValue * byte.MaxValue + byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mad(byte a, byte b, byte c)
        {
            return math.mad((uint)a, (uint)b, (uint)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mad(byte2 a, byte2 b, byte2 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mad(byte3 a, byte3 b, byte3 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mad(byte4 a, byte4 b, byte4 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 mad(byte8 a, byte8 b, byte8 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 mad(byte16 a, byte16 b, byte16 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 mad(byte32 a, byte32 b, byte32 c)
        {
            return (a * b) + c;
        }


        /// <summary>       Returns the result of a multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="sbyte"/>s.    </summary>
        [return: AssumeRange((long)sbyte.MinValue * (long)sbyte.MaxValue + (long)sbyte.MinValue, (long)sbyte.MinValue * (long)sbyte.MinValue + (long)sbyte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mad(sbyte a, sbyte b, sbyte c)
        {
            return math.mad((int)a, (int)b, (int)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mad(sbyte2 a, sbyte2 b, sbyte2 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mad(sbyte3 a, sbyte3 b, sbyte3 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mad(sbyte4 a, sbyte4 b, sbyte4 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 mad(sbyte8 a, sbyte8 b, sbyte8 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 mad(sbyte16 a, sbyte16 b, sbyte16 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 mad(sbyte32 a, sbyte32 b, sbyte32 c)
        {
            return (a * b) + c;
        }


        /// <summary>       Returns the result of a multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="ushort"/>s.    </summary>
        [return: AssumeRange(0ul, (ulong)ushort.MaxValue * ushort.MaxValue + ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mad(ushort a, ushort b, ushort c)
        {
            return math.mad((uint)a, (uint)b, (uint)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mad(ushort2 a, ushort2 b, ushort2 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mad(ushort3 a, ushort3 b, ushort3 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mad(ushort4 a, ushort4 b, ushort4 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 mad(ushort8 a, ushort8 b, ushort8 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 mad(ushort16 a, ushort16 b, ushort16 c)
        {
            return (a * b) + c;
        }


        /// <summary>       Returns the result of a multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="short"/>s.    </summary>
        [return: AssumeRange((long)short.MinValue * short.MaxValue + short.MinValue, (long)short.MinValue * short.MinValue + short.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mad(short a, short b, short c)
        {
            return math.mad((int)a, (int)b, (int)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mad(short2 a, short2 b, short2 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mad(short3 a, short3 b, short3 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mad(short4 a, short4 b, short4 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 mad(short8 a, short8 b, short8 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 mad(short16 a, short16 b, short16 c)
        {
            return (a * b) + c;
        }


        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mad(ulong2 a, ulong2 b, ulong2 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mad(ulong3 a, ulong3 b, ulong3 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mad(ulong4 a, ulong4 b, ulong4 c)
        {
            return (a * b) + c;
        }


        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mad(long2 a, long2 b, long2 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mad(long3 a, long3 b, long3 c)
        {
            return (a * b) + c;
        }

        /// <summary>       Returns the result of a componentwise multiply-add operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mad(long4 a, long4 b, long4 c)
        {
            return (a * b) + c;
        }
    }
}