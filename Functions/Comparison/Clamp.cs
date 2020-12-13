using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise clamping of the float8 vector x into the interval [0, 1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 saturate(float8 x)
        {
            return clamp(x, 0f, 1f);
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are byte2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 clamp(byte2 x, byte2 a, byte2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are byte3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 clamp(byte3 x, byte3 a, byte3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are byte4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 clamp(byte4 x, byte4 a, byte4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are byte8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 clamp(byte8 x, byte8 a, byte8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are byte16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 clamp(byte16 x, byte16 a, byte16 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are byte32 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 clamp(byte32 x, byte32 a, byte32 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are sbyte2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 clamp(sbyte2 x, sbyte2 a, sbyte2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are sbyte3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 clamp(sbyte3 x, sbyte3 a, sbyte3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are sbyte4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 clamp(sbyte4 x, sbyte4 a, sbyte4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are sbyte8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 clamp(sbyte8 x, sbyte8 a, sbyte8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are sbyte16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 clamp(sbyte16 x, sbyte16 a, sbyte16 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are sbyte32 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 clamp(sbyte32 x, sbyte32 a, sbyte32 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are ushort2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 clamp(ushort2 x, ushort2 a, ushort2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are ushort3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 clamp(ushort3 x, ushort3 a, ushort3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are ushort4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 clamp(ushort4 x, ushort4 a, ushort4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are ushort8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 clamp(ushort8 x, ushort8 a, ushort8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are ushort16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 clamp(ushort16 x, ushort16 a, ushort16 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are short2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 clamp(short2 x, short2 a, short2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are short3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 clamp(short3 x, short3 a, short3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are short4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 clamp(short4 x, short4 a, short4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are short8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 clamp(short8 x, short8 a, short8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are short16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 clamp(short16 x, short16 a, short16 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are int8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 clamp(int8 x, int8 a, int8 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are uint8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 clamp(uint8 x, uint8 a, uint8 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are ulong2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 clamp(ulong2 x, ulong2 a, ulong2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are ulong3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 clamp(ulong3 x, ulong3 a, ulong3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are ulong4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 clamp(ulong4 x, ulong4 a, ulong4 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are long2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 clamp(long2 x, long2 a, long2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are long3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 clamp(long3 x, long3 a, long3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are long4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 clamp(long4 x, long4 a, long4 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value x into the interval[a, b], where x, a and b are int4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 clamp(float8 x, float8 a, float8 b)
        {
            return max(a, min(x, b));
        }
    }
}