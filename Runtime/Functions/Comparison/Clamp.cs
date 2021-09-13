using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.float8"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 saturate(float8 x)
        {
            return clamp(x, 0f, 1f);
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 clamp(UInt128 x, UInt128 a, UInt128 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 clamp(Int128 x, Int128 a, Int128 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="byte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte clamp(byte x, byte a, byte b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 clamp(byte2 x, byte2 a, byte2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 clamp(byte3 x, byte3 a, byte3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 clamp(byte4 x, byte4 a, byte4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 clamp(byte8 x, byte8 a, byte8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 clamp(byte16 x, byte16 a, byte16 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 clamp(byte32 x, byte32 a, byte32 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="sbyte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte clamp(sbyte x, sbyte a, sbyte b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 clamp(sbyte2 x, sbyte2 a, sbyte2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 clamp(sbyte3 x, sbyte3 a, sbyte3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 clamp(sbyte4 x, sbyte4 a, sbyte4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 clamp(sbyte8 x, sbyte8 a, sbyte8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 clamp(sbyte16 x, sbyte16 a, sbyte16 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 clamp(sbyte32 x, sbyte32 a, sbyte32 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="ushort"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort clamp(ushort x, ushort a, ushort b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 clamp(ushort2 x, ushort2 a, ushort2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 clamp(ushort3 x, ushort3 a, ushort3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 clamp(ushort4 x, ushort4 a, ushort4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 clamp(ushort8 x, ushort8 a, ushort8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 clamp(ushort16 x, ushort16 a, ushort16 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="short"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short clamp(short x, short a, short b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 clamp(short2 x, short2 a, short2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 clamp(short3 x, short3 a, short3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 clamp(short4 x, short4 a, short4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 clamp(short8 x, short8 a, short8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 clamp(short16 x, short16 a, short16 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 clamp(int8 x, int8 a, int8 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 clamp(uint8 x, uint8 a, uint8 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 clamp(ulong2 x, ulong2 a, ulong2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 clamp(ulong3 x, ulong3 a, ulong3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 clamp(ulong4 x, ulong4 a, ulong4 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 clamp(long2 x, long2 a, long2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 clamp(long3 x, long3 a, long3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 clamp(long4 x, long4 a, long4 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="int4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 clamp(float8 x, float8 a, float8 b)
        {
            return max(a, min(x, b));
        }
    }
}