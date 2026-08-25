using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Converts a <see cref="quarter"/> to an <see cref="sbyte"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(quarter x, Promise promises = Promise.Nothing)
        {
            return select((sbyte)ceil(x, promises), (sbyte)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter2"/> to an <see cref="sbyte2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceiltosbyte(quarter2 x, Promise promises = Promise.Nothing)
        {
            return select((sbyte2)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter3"/> to an <see cref="sbyte3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceiltosbyte(quarter3 x, Promise promises = Promise.Nothing)
        {
            return select((sbyte3)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter4"/> to an <see cref="sbyte4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceiltosbyte(quarter4 x, Promise promises = Promise.Nothing)
        {
            return select((sbyte4)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter8"/> to an <see cref="sbyte8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceiltosbyte(quarter8 x, Promise promises = Promise.Nothing)
        {
            return select((sbyte8)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter16"/> to an <see cref="sbyte16"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceiltosbyte(quarter16 x, Promise promises = Promise.Nothing)
        {
            return select((sbyte16)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter32"/> to an <see cref="sbyte32"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceiltosbyte(quarter32 x, Promise promises = Promise.Nothing)
        {
            return select((sbyte32)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to a <see cref="byte"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(quarter x, Promise promises = Promise.Nothing)
        {
            return select((byte)ceil(x, promises), (byte)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter2"/> to a <see cref="byte2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceiltobyte(quarter2 x, Promise promises = Promise.Nothing)
        {
            return select((byte2)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter3"/> to a <see cref="byte3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceiltobyte(quarter3 x, Promise promises = Promise.Nothing)
        {
            return select((byte3)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter4"/> to a <see cref="byte4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceiltobyte(quarter4 x, Promise promises = Promise.Nothing)
        {
            return select((byte4)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter8"/> to a <see cref="byte8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceiltobyte(quarter8 x, Promise promises = Promise.Nothing)
        {
            return select((byte8)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter16"/> to a <see cref="byte16"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceiltobyte(quarter16 x, Promise promises = Promise.Nothing)
        {
            return select((byte16)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter32"/> to a <see cref="byte32"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceiltobyte(quarter32 x, Promise promises = Promise.Nothing)
        {
            return select((byte32)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to a <see cref="short"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(quarter x, Promise promises = Promise.Nothing)
        {
            return select((short)ceil(x, promises), (short)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter2"/> to a <see cref="short2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceiltoshort(quarter2 x, Promise promises = Promise.Nothing)
        {
            return select((short2)ceil(x, promises), (short)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter3"/> to a <see cref="short3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceiltoshort(quarter3 x, Promise promises = Promise.Nothing)
        {
            return select((short3)ceil(x, promises), (short)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter4"/> to a <see cref="short4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceiltoshort(quarter4 x, Promise promises = Promise.Nothing)
        {
            return select((short4)ceil(x, promises), (short)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter8"/> to a <see cref="short8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceiltoshort(quarter8 x, Promise promises = Promise.Nothing)
        {
            return select((short8)ceil(x, promises), (short)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter16"/> to a <see cref="short16"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceiltoshort(quarter16 x, Promise promises = Promise.Nothing)
        {
            return select((short16)ceil(x, promises), (short)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to a <see cref="ushort"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(quarter x, Promise promises = Promise.Nothing)
        {
            return select((ushort)ceil(x, promises), (ushort)16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter2"/> to a <see cref="ushort2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceiltoushort(quarter2 x, Promise promises = Promise.Nothing)
        {
            return select((ushort2)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter3"/> to a <see cref="ushort3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceiltoushort(quarter3 x, Promise promises = Promise.Nothing)
        {
            return select((ushort3)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter4"/> to a <see cref="ushort4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceiltoushort(quarter4 x, Promise promises = Promise.Nothing)
        {
            return select((ushort4)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter8"/> to a <see cref="ushort8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceiltoushort(quarter8 x, Promise promises = Promise.Nothing)
        {
            return select((ushort8)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter16"/> to a <see cref="ushort16"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceiltoushort(quarter16 x, Promise promises = Promise.Nothing)
        {
            return select((ushort16)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to an <see cref="int"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(quarter x, Promise promises = Promise.Nothing)
        {
            return select((int)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter2"/> to an <see cref="int2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceiltoint(quarter2 x, Promise promises = Promise.Nothing)
        {
            return select((int2)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter3"/> to an <see cref="int3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceiltoint(quarter3 x, Promise promises = Promise.Nothing)
        {
            return select((int3)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter4"/> to an <see cref="int4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceiltoint(quarter4 x, Promise promises = Promise.Nothing)
        {
            return select((int4)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter8"/> to an <see cref="int8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceiltoint(quarter8 x, Promise promises = Promise.Nothing)
        {
            return select((int8)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to a <see cref="uint"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(quarter x, Promise promises = Promise.Nothing)
        {
            return select((uint)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter2"/> to a <see cref="uint2"/> component rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceiltouint(quarter2 x, Promise promises = Promise.Nothing)
        {
            return select((uint2)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter3"/> to a <see cref="uint3"/> component rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceiltouint(quarter3 x, Promise promises = Promise.Nothing)
        {
            return select((uint3)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter4"/> to a <see cref="uint4"/> component rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceiltouint(quarter4 x, Promise promises = Promise.Nothing)
        {
            return select((uint4)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter8"/> to a <see cref="uint8"/> component rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceiltouint(quarter8 x, Promise promises = Promise.Nothing)
        {
            return select((uint8)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to a <see cref="long"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(quarter x, Promise promises = Promise.Nothing)
        {
            return select((long)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter2"/> to a <see cref="long2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceiltolong(quarter2 x, Promise promises = Promise.Nothing)
        {
            return select((long2)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter3"/> to a <see cref="long3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceiltolong(quarter3 x, Promise promises = Promise.Nothing)
        {
            return select((long3)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter4"/> to a <see cref="long4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceiltolong(quarter4 x, Promise promises = Promise.Nothing)
        {
            return select((long4)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to a <see cref="ulong"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(quarter x, Promise promises = Promise.Nothing)
        {
            return select((ulong)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter2"/> to a <see cref="ulong2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceiltoulong(quarter2 x, Promise promises = Promise.Nothing)
        {
            return select((ulong2)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter3"/> to a <see cref="ulong3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceiltoulong(quarter3 x, Promise promises = Promise.Nothing)
        {
            return select((ulong3)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }

        /// <summary>       Converts each component in a <see cref="quarter4"/> to a <see cref="ulong4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceiltoulong(quarter4 x, Promise promises = Promise.Nothing)
        {
            return select((ulong4)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to an <see cref="Int128"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(quarter x, Promise promises = Promise.Nothing)
        {
            return select((Int128)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="quarter"/> to a <see cref="UInt128"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(quarter x, Promise promises = Promise.Nothing)
        {
            return select((UInt128)ceil(x, promises), 16, asbyte(x) == MaxMath.quarter.MaxValue.value);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="sbyte"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(half x, Promise promises = Promise.Nothing)
        {
            return (sbyte)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to an <see cref="sbyte2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceiltosbyte(half2 x, Promise promises = Promise.Nothing)
        {
            return (sbyte2)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to an <see cref="sbyte3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceiltosbyte(half3 x, Promise promises = Promise.Nothing)
        {
            return (sbyte3)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to an <see cref="sbyte4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceiltosbyte(half4 x, Promise promises = Promise.Nothing)
        {
            return (sbyte4)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half8"/> to an <see cref="sbyte8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceiltosbyte(half8 x, Promise promises = Promise.Nothing)
        {
            return (sbyte8)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half16"/> to an <see cref="sbyte16"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceiltosbyte(half16 x, Promise promises = Promise.Nothing)
        {
            return (sbyte16)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="byte"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(half x, Promise promises = Promise.Nothing)
        {
            return (byte)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="byte2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceiltobyte(half2 x, Promise promises = Promise.Nothing)
        {
            return (byte2)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="byte3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceiltobyte(half3 x, Promise promises = Promise.Nothing)
        {
            return (byte3)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="byte4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceiltobyte(half4 x, Promise promises = Promise.Nothing)
        {
            return (byte4)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half8"/> to a <see cref="byte8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceiltobyte(half8 x, Promise promises = Promise.Nothing)
        {
            return (byte8)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half16"/> to a <see cref="byte16"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceiltobyte(half16 x, Promise promises = Promise.Nothing)
        {
            return (byte16)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="short"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(half x, Promise promises = Promise.Nothing)
        {
            return (short)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="short2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceiltoshort(half2 x, Promise promises = Promise.Nothing)
        {
            return (short2)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="short3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceiltoshort(half3 x, Promise promises = Promise.Nothing)
        {
            return (short3)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="short4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceiltoshort(half4 x, Promise promises = Promise.Nothing)
        {
            return (short4)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half8"/> to a <see cref="short8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceiltoshort(half8 x, Promise promises = Promise.Nothing)
        {
            return (short8)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half16"/> to a <see cref="short16"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceiltoshort(half16 x, Promise promises = Promise.Nothing)
        {
            return (short16)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ushort"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(half x, Promise promises = Promise.Nothing)
        {
            return (ushort)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="ushort2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceiltoushort(half2 x, Promise promises = Promise.Nothing)
        {
            return (ushort2)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="ushort3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceiltoushort(half3 x, Promise promises = Promise.Nothing)
        {
            return (ushort3)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="ushort4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceiltoushort(half4 x, Promise promises = Promise.Nothing)
        {
            return (ushort4)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half8"/> to a <see cref="ushort8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceiltoushort(half8 x, Promise promises = Promise.Nothing)
        {
            return (ushort8)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half16"/> to a <see cref="ushort16"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceiltoushort(half16 x, Promise promises = Promise.Nothing)
        {
            return (ushort16)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="int"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(half x, Promise promises = Promise.Nothing)
        {
            return (int)(float)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to an <see cref="int2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceiltoint(half2 x, Promise promises = Promise.Nothing)
        {
            return (int2)(float2)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to an <see cref="int3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceiltoint(half3 x, Promise promises = Promise.Nothing)
        {
            return (int3)(float3)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to an <see cref="int4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceiltoint(half4 x, Promise promises = Promise.Nothing)
        {
            return (int4)(float4)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half8"/> to an <see cref="int8"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceiltoint(half8 x, Promise promises = Promise.Nothing)
        {
            return (int8)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="uint"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(half x, Promise promises = Promise.Nothing)
        {
            return (uint)(float)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="uint2"/> component rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceiltouint(half2 x, Promise promises = Promise.Nothing)
        {
            return (uint2)(float2)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="uint3"/> component rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceiltouint(half3 x, Promise promises = Promise.Nothing)
        {
            return (uint3)(float3)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="uint4"/> component rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceiltouint(half4 x, Promise promises = Promise.Nothing)
        {
            return (uint4)(float4)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half8"/> to a <see cref="uint8"/> component rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceiltouint(half8 x, Promise promises = Promise.Nothing)
        {
            return (uint8)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="long"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(half x, Promise promises = Promise.Nothing)
        {
            return (long)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="long2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceiltolong(half2 x, Promise promises = Promise.Nothing)
        {
            return (long2)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="long3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceiltolong(half3 x, Promise promises = Promise.Nothing)
        {
            return (long3)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="long4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceiltolong(half4 x, Promise promises = Promise.Nothing)
        {
            return (long4)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ulong"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(half x, Promise promises = Promise.Nothing)
        {
            return (ulong)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half2"/> to a <see cref="ulong2"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceiltoulong(half2 x, Promise promises = Promise.Nothing)
        {
            return (ulong2)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half3"/> to a <see cref="ulong3"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceiltoulong(half3 x, Promise promises = Promise.Nothing)
        {
            return (ulong3)ceil(x, promises);
        }

        /// <summary>       Converts each component in a <see cref="half4"/> to a <see cref="ulong4"/> component while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceiltoulong(half4 x, Promise promises = Promise.Nothing)
        {
            return (ulong4)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="Int128"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(half x, Promise promises = Promise.Nothing)
        {
            return (Int128)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="UInt128"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(half x, Promise promises = Promise.Nothing)
        {
            return (UInt128)ceil(x, promises);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="sbyte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(float x)
        {
            return (sbyte)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to an <see cref="sbyte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceiltosbyte(float2 x)
        {
            return (sbyte2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to an <see cref="sbyte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceiltosbyte(float3 x)
        {
            return (sbyte3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to an <see cref="sbyte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceiltosbyte(float4 x)
        {
            return (sbyte4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float8"/> to an <see cref="sbyte8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceiltosbyte(float8 x)
        {
            return (sbyte8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="byte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(float x)
        {
            return (byte)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="byte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceiltobyte(float2 x)
        {
            return (byte2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="byte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceiltobyte(float3 x)
        {
            return (byte3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="byte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceiltobyte(float4 x)
        {
            return (byte4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float8"/> to a <see cref="byte8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceiltobyte(float8 x)
        {
            return (byte8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="short"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(float x)
        {
            return (short)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="short2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceiltoshort(float2 x)
        {
            return (short2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="short3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceiltoshort(float3 x)
        {
            return (short3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="short4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceiltoshort(float4 x)
        {
            return (short4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float8"/> to a <see cref="short8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceiltoshort(float8 x)
        {
            return (short8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ushort"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(float x)
        {
            return (ushort)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="ushort2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceiltoushort(float2 x)
        {
            return (ushort2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="ushort3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceiltoushort(float3 x)
        {
            return (ushort3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="ushort4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceiltoushort(float4 x)
        {
            return (ushort4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float8"/> to a <see cref="ushort8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceiltoushort(float8 x)
        {
            return (ushort8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="int"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(float x)
        {
            return (int)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to an <see cref="int2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceiltoint(float2 x)
        {
            return (int2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to an <see cref="int3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceiltoint(float3 x)
        {
            return (int3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to an <see cref="int4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceiltoint(float4 x)
        {
            return (int4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float8"/> to an <see cref="int8"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceiltoint(float8 x)
        {
            return (int8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="uint"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(float x)
        {
            return (uint)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="uint2"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceiltouint(float2 x)
        {
            return (uint2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="uint3"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceiltouint(float3 x)
        {
            return (uint3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="uint4"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceiltouint(float4 x)
        {
            return (uint4)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float8"/> to a <see cref="uint8"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceiltouint(float8 x)
        {
            return (uint8)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="long"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(float x)
        {
            return (long)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="long2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceiltolong(float2 x)
        {
            return (long2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="long3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceiltolong(float3 x)
        {
            return (long3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="long4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceiltolong(float4 x)
        {
            return (long4)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ulong"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(float x)
        {
            return (ulong)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float2"/> to a <see cref="ulong2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceiltoulong(float2 x)
        {
            return (ulong2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float3"/> to a <see cref="ulong3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceiltoulong(float3 x)
        {
            return (ulong3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="float4"/> to a <see cref="ulong4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceiltoulong(float4 x)
        {
            return (ulong4)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="Int128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(float x)
        {
            return (Int128)ceil(x);
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="UInt128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(float x)
        {
            return (UInt128)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="sbyte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(double x)
        {
            return (sbyte)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to an <see cref="sbyte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceiltosbyte(double2 x)
        {
            return (sbyte2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to an <see cref="sbyte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceiltosbyte(double3 x)
        {
            return (sbyte3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to an <see cref="sbyte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceiltosbyte(double4 x)
        {
            return (sbyte4)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="byte"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(double x)
        {
            return (byte)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="byte2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceiltobyte(double2 x)
        {
            return (byte2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="byte3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceiltobyte(double3 x)
        {
            return (byte3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="byte4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceiltobyte(double4 x)
        {
            return (byte4)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="short"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(double x)
        {
            return (short)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="short2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceiltoshort(double2 x)
        {
            return (short2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="short3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceiltoshort(double3 x)
        {
            return (short3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="short4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceiltoshort(double4 x)
        {
            return (short4)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ushort"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(double x)
        {
            return (ushort)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="ushort2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceiltoushort(double2 x)
        {
            return (ushort2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="ushort3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceiltoushort(double3 x)
        {
            return (ushort3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="ushort4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceiltoushort(double4 x)
        {
            return (ushort4)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="int"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(double x)
        {
            return (int)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to an <see cref="int2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceiltoint(double2 x)
        {
            return (int2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to an <see cref="int3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceiltoint(double3 x)
        {
            return (int3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to an <see cref="int4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceiltoint(double4 x)
        {
            return (int4)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="uint"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(double x)
        {
            return (uint)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="uint2"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceiltouint(double2 x)
        {
            return (uint2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="uint3"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceiltouint(double3 x)
        {
            return (uint3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="uint4"/> component rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceiltouint(double4 x)
        {
            return (uint4)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="long"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(double x)
        {
            return (long)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="long2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceiltolong(double2 x)
        {
            return (long2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="long3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceiltolong(double3 x)
        {
            return (long3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="long4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceiltolong(double4 x)
        {
            return (long4)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ulong"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(double x)
        {
            return (ulong)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double2"/> to a <see cref="ulong2"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceiltoulong(double2 x)
        {
            return (ulong2)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double3"/> to a <see cref="ulong3"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceiltoulong(double3 x)
        {
            return (ulong3)ceil(x);
        }

        /// <summary>       Converts each component in a <see cref="double4"/> to a <see cref="ulong4"/> component while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceiltoulong(double4 x)
        {
            return (ulong4)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="Int128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(double x)
        {
            return (Int128)ceil(x);
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="UInt128"/> while rounding towards positive infinity.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(double x)
        {
            return (UInt128)ceil(x);
        }

        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="sbyte"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceiltosbyte(quadruple x, Promise promises = Promise.Nothing)
        {
            return (sbyte)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="short"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceiltoshort(quadruple x, Promise promises = Promise.Nothing)
        {
            return (short)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="int"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceiltoint(quadruple x, Promise promises = Promise.Nothing)
        {
            return (int)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="long"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceiltolong(quadruple x, Promise promises = Promise.Nothing)
        {
            return (long)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="Int128"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceiltoint128(quadruple x, Promise promises = Promise.Nothing)
        {
            return (Int128)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="byte"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceiltobyte(quadruple x, Promise promises = Promise.Nothing)
        {
            return (byte)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="ushort"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceiltoushort(quadruple x, Promise promises = Promise.Nothing)
        {
            return (ushort)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="uint"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceiltouint(quadruple x, Promise promises = Promise.Nothing)
        {
            return (uint)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="ulong"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceiltoulong(quadruple x, Promise promises = Promise.Nothing)
        {
            return (ulong)ceil(x, promises);
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="UInt128"/> while rounding towards positive infinity.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceiltouint128(quadruple x, Promise promises = Promise.Nothing)
        {
            return (UInt128)ceil(x, promises);
        }
    }
}
