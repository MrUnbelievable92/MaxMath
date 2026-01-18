using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="sbyte"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte trunctosbyte(quarter x, Promise promises = Promise.Nothing)
        {
            return (sbyte)BASE_cvtf8i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 trunctosbyte(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(x, elements: 2, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new sbyte2(trunctosbyte(x.x, promises), trunctosbyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 trunctosbyte(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(x, elements: 3, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new sbyte3(trunctosbyte(x.x, promises), trunctosbyte(x.y, promises), trunctosbyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 trunctosbyte(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(x, elements: 4, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new sbyte4(trunctosbyte(x.x, promises), trunctosbyte(x.y, promises), trunctosbyte(x.z, promises), trunctosbyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 trunctosbyte(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(x, elements: 8, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new sbyte8(trunctosbyte(x.x0, promises), trunctosbyte(x.x1, promises), trunctosbyte(x.x2, promises), trunctosbyte(x.x3, promises), trunctosbyte(x.x4, promises), trunctosbyte(x.x5, promises), trunctosbyte(x.x6, promises), trunctosbyte(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.sbyte16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 trunctosbyte(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(x, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new sbyte16(trunctosbyte(x.x0, promises), trunctosbyte(x.x1, promises), trunctosbyte(x.x2, promises), trunctosbyte(x.x3, promises), trunctosbyte(x.x4, promises), trunctosbyte(x.x5, promises), trunctosbyte(x.x6, promises), trunctosbyte(x.x7, promises), trunctosbyte(x.x8, promises), trunctosbyte(x.x9, promises), trunctosbyte(x.x10, promises), trunctosbyte(x.x11, promises), trunctosbyte(x.x12, promises), trunctosbyte(x.x13, promises), trunctosbyte(x.x14, promises), trunctosbyte(x.x15, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter32"/> to an <see cref="MaxMath.sbyte32"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 trunctosbyte(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi8(x, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new sbyte32(trunctosbyte(x.v16_0, promises), trunctosbyte(x.v16_16, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="byte"/> while rounding towards zero.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte trunctobyte(quarter x)
        {
            return (byte)BASE_cvtf8i32(x, signed: false, trunc: true);
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 trunctobyte(quarter2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(x, elements: 2);
            }
            else
            {
                return new byte2(trunctobyte(x.x), trunctobyte(x.y));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 trunctobyte(quarter3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(x, elements: 3);
            }
            else
            {
                return new byte3(trunctobyte(x.x), trunctobyte(x.y), trunctobyte(x.z));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 trunctobyte(quarter4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(x, elements: 4);
            }
            else
            {
                return new byte4(trunctobyte(x.x), trunctobyte(x.y), trunctobyte(x.z), trunctobyte(x.w));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 trunctobyte(quarter8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(x, elements: 8);
            }
            else
            {
                return new byte8(trunctobyte(x.x0), trunctobyte(x.x1), trunctobyte(x.x2), trunctobyte(x.x3), trunctobyte(x.x4), trunctobyte(x.x5), trunctobyte(x.x6), trunctobyte(x.x7));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.byte16"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 trunctobyte(quarter16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(x);
            }
            else
            {
                return new byte16(trunctobyte(x.x0), trunctobyte(x.x1), trunctobyte(x.x2), trunctobyte(x.x3), trunctobyte(x.x4), trunctobyte(x.x5), trunctobyte(x.x6), trunctobyte(x.x7), trunctobyte(x.x8), trunctobyte(x.x9), trunctobyte(x.x10), trunctobyte(x.x11), trunctobyte(x.x12), trunctobyte(x.x13), trunctobyte(x.x14), trunctobyte(x.x15));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter32"/> to an <see cref="MaxMath.byte32"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 trunctobyte(quarter32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu8(x);
            }
            else
            {
                return new byte32(trunctobyte(x.v16_0), trunctobyte(x.v16_16));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="short"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short trunctoshort(quarter x, Promise promises = Promise.Nothing)
        {
            return (short)BASE_cvtf8i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.short2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 trunctoshort(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(x, elements: 2, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new short2(trunctoshort(x.x, promises), trunctoshort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.short3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 trunctoshort(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(x, elements: 3, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new short3(trunctoshort(x.x, promises), trunctoshort(x.y, promises), trunctoshort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.short4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 trunctoshort(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(x, elements: 4, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new short4(trunctoshort(x.x, promises), trunctoshort(x.y, promises), trunctoshort(x.z, promises), trunctoshort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.short8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 trunctoshort(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(x, elements: 8, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new short8(trunctoshort(x.x0, promises), trunctoshort(x.x1, promises), trunctoshort(x.x2, promises), trunctoshort(x.x3, promises), trunctoshort(x.x4, promises), trunctoshort(x.x5, promises), trunctoshort(x.x6, promises), trunctoshort(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.short16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 trunctoshort(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi16(x, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new short16(trunctoshort(x.v8_0, promises), trunctoshort(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="ushort"/> while rounding towards zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort trunctoushort(quarter x)
        {
            return (ushort)BASE_cvtf8i32(x, signed: false, trunc: true);
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 trunctoushort(quarter2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(x, elements: 2);
            }
            else
            {
                return new ushort2(trunctoushort(x.x), trunctoushort(x.y));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 trunctoushort(quarter3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(x, elements: 3);
            }
            else
            {
                return new ushort3(trunctoushort(x.x), trunctoushort(x.y), trunctoushort(x.z));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 trunctoushort(quarter4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(x, elements: 4);
            }
            else
            {
                return new ushort4(trunctoushort(x.x), trunctoushort(x.y), trunctoushort(x.z), trunctoushort(x.w));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 trunctoushort(quarter8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(x, elements: 8);
            }
            else
            {
                return new ushort8(trunctoushort(x.x0), trunctoushort(x.x1), trunctoushort(x.x2), trunctoushort(x.x3), trunctoushort(x.x4), trunctoushort(x.x5), trunctoushort(x.x6), trunctoushort(x.x7));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.ushort16"/> component while rounding towards the nearest numerical value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 trunctoushort(quarter16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu16(x);
            }
            else
            {
                return new ushort16(trunctoushort(x.v8_0), trunctoushort(x.v8_8));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="int"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int trunctoint(quarter x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf8i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to an <see cref="int2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 trunctoint(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cvttpq_epi32(x, elements: 2, positive: promises.Promises(Promise.Positive)));
            }
            else
            {
                return new int2(trunctoint(x.x, promises), trunctoint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to an <see cref="int3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 trunctoint(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvttpq_epi32(x, elements: 3, positive: promises.Promises(Promise.Positive)));
            }
            else
            {
                return new int3(trunctoint(x.x, promises), trunctoint(x.y, promises), trunctoint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to an <see cref="int4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 trunctoint(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cvttpq_epi32(x, elements: 4, positive: promises.Promises(Promise.Positive)));
            }
            else
            {
                return new int4(trunctoint(x.x, promises), trunctoint(x.y, promises), trunctoint(x.z, promises), trunctoint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to an <see cref="MaxMath.int8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 trunctoint(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi32(x, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new int8(trunctoint(x.v4_0, promises), trunctoint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="uint"/> while rounding towards zero.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint trunctouint(quarter x)
        {
            return BASE_cvtf8i32(x, signed: false, trunc: true);
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="uint2"/> component while rounding towards the nearest respective uinteger value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 trunctouint(quarter2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cvttpq_epu32(x, elements: 2));
            }
            else
            {
                return new uint2(trunctouint(x.x), trunctouint(x.y));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="uint3"/> component while rounding towards the nearest respective uinteger value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 trunctouint(quarter3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvttpq_epu32(x, elements: 3));
            }
            else
            {
                return new uint3(trunctouint(x.x), trunctouint(x.y), trunctouint(x.z));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="uint4"/> component while rounding towards the nearest respective uinteger value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 trunctouint(quarter4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.cvttpq_epu32(x, elements: 4));
            }
            else
            {
                return new uint4(trunctouint(x.x), trunctouint(x.y), trunctouint(x.z), trunctouint(x.w));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.uint8"/> component while rounding towards the nearest respective uinteger value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 trunctouint(quarter8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu32(x);
            }
            else
            {
                return new uint8(trunctouint(x.v4_0), trunctouint(x.v4_4));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="long"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long trunctolong(quarter x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf8i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.long2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 trunctolong(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi64(x, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new long2(trunctolong(x.x, promises), trunctolong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.long3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 trunctolong(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi64(x, elements: 3, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new long3(trunctolong(x.xy, promises), trunctolong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.long4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 trunctolong(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi64(x, elements: 4, positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new long4(trunctolong(x.xy, promises), trunctolong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="ulong"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong trunctoulong(quarter x)
        {
            return BASE_cvtf8i32(x, signed: false, trunc: true);
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards the nearest numerical value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 trunctoulong(quarter2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu64(x);
            }
            else
            {
                return new ulong2(trunctoulong(x.x), trunctoulong(x.y));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards the nearest numerical value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 trunctoulong(quarter3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu64(x, elements: 3);
            }
            else
            {
                return new ulong3(trunctoulong(x.xy), trunctoulong(x.z));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards the nearest numerical value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 trunctoulong(quarter4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu64(x, elements: 4);
            }
            else
            {
                return new ulong4(trunctoulong(x.xy), trunctoulong(x.zw));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="Int128"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 trunctoint128(quarter x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf8i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="UInt128"/> while rounding towards zero.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 trunctouint128(quarter x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf8i32(x, signed: false, trunc: true);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="sbyte"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte trunctosbyte(half x, Promise promises = Promise.Nothing)
        {
            return (sbyte)BASE_cvtf16i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 trunctosbyte(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte2(trunctosbyte(x.x, promises), trunctosbyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 trunctosbyte(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte3(trunctosbyte(x.x, promises), trunctosbyte(x.y, promises), trunctosbyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 trunctosbyte(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte4(trunctosbyte(x.x, promises), trunctosbyte(x.y, promises), trunctosbyte(x.z, promises), trunctosbyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 trunctosbyte(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(x, elements: 8, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte8(trunctosbyte(x.x0, promises), trunctosbyte(x.x1, promises), trunctosbyte(x.x2, promises), trunctosbyte(x.x3, promises), trunctosbyte(x.x4, promises), trunctosbyte(x.x5, promises), trunctosbyte(x.x6, promises), trunctosbyte(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half16"/> to an <see cref="MaxMath.sbyte16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 trunctosbyte(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi8(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte16(trunctosbyte(x.v8_0, promises), trunctosbyte(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="byte"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte trunctobyte(half x, Promise promises = Promise.Nothing)
        {
            return (byte)BASE_cvtf16i32(x, signed: false, trunc: true, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 trunctobyte(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(RegisterConversion.ToV128(x), elements: 2, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte2(trunctobyte(x.x, promises), trunctobyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 trunctobyte(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte3(trunctobyte(x.x, promises), trunctobyte(x.y, promises), trunctobyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 trunctobyte(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte4(trunctobyte(x.x, promises), trunctobyte(x.y, promises), trunctobyte(x.z, promises), trunctobyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 trunctobyte(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(x, elements: 8, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte8(trunctobyte(x.x0, promises), trunctobyte(x.x1, promises), trunctobyte(x.x2, promises), trunctobyte(x.x3, promises), trunctobyte(x.x4, promises), trunctobyte(x.x5, promises), trunctobyte(x.x6, promises), trunctobyte(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half16"/> to an <see cref="MaxMath.byte16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 trunctobyte(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu8(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte16(trunctobyte(x.v8_0, promises), trunctobyte(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="short"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short trunctoshort(half x, Promise promises = Promise.Nothing)
        {
            return (short)BASE_cvtf16i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.short2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 trunctoshort(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short2(trunctoshort(x.x, promises), trunctoshort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.short3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 trunctoshort(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short3(trunctoshort(x.x, promises), trunctoshort(x.y, promises), trunctoshort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.short4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 trunctoshort(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short4(trunctoshort(x.x, promises), trunctoshort(x.y, promises), trunctoshort(x.z, promises), trunctoshort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.short8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 trunctoshort(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(x, elements: 8, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short8(trunctoshort(x.x0, promises), trunctoshort(x.x1, promises), trunctoshort(x.x2, promises), trunctoshort(x.x3, promises), trunctoshort(x.x4, promises), trunctoshort(x.x5, promises), trunctoshort(x.x6, promises), trunctoshort(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.short16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 trunctoshort(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi16(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short16(trunctoshort(x.v8_0, promises), trunctoshort(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ushort"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort trunctoushort(half x, Promise promises = Promise.Nothing)
        {
            return (ushort)BASE_cvtf16i32(x, signed: false, trunc: true, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 trunctoushort(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(RegisterConversion.ToV128(x), elements: 2, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort2(trunctoushort(x.x, promises), trunctoushort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 trunctoushort(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort3(trunctoushort(x.x, promises), trunctoushort(x.y, promises), trunctoushort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 trunctoushort(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort4(trunctoushort(x.x, promises), trunctoushort(x.y, promises), trunctoushort(x.z, promises), trunctoushort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 trunctoushort(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(x, elements: 8, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort8(trunctoushort(x.x0, promises), trunctoushort(x.x1, promises), trunctoushort(x.x2, promises), trunctoushort(x.x3, promises), trunctoushort(x.x4, promises), trunctoushort(x.x5, promises), trunctoushort(x.x6, promises), trunctoushort(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.ushort16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 trunctoushort(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu16(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort16(trunctoushort(x.v8_0, promises), trunctoushort(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="int"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int trunctoint(half x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf16i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to an <see cref="int2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 trunctoint(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cvttph_epi32(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int2(trunctoint(x.x, promises), trunctoint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to an <see cref="int3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 trunctoint(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvttph_epi32(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int3(trunctoint(x.x, promises), trunctoint(x.y, promises), trunctoint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to an <see cref="int4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 trunctoint(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cvttph_epi32(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int4(trunctoint(x.x, promises), trunctoint(x.y, promises), trunctoint(x.z, promises), trunctoint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to an <see cref="MaxMath.int8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 trunctoint(half8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi32(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new int8(trunctoint(x.v4_0, promises), trunctoint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="uint"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint trunctouint(half x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf16i32(x, signed: false, trunc: true, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="uint2"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 trunctouint(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cvttph_epu32(RegisterConversion.ToV128(x), elements: 2, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint2(trunctouint(x.x, promises), trunctouint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="uint3"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 trunctouint(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvttph_epu32(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint3(trunctouint(x.x, promises), trunctouint(x.y, promises), trunctouint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="uint4"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 trunctouint(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.cvttph_epu32(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint4(trunctouint(x.x, promises), trunctouint(x.y, promises), trunctouint(x.z, promises), trunctouint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.uint8"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 trunctouint(half8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu32(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new uint8(trunctouint(x.v4_0, promises), trunctouint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="long"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long trunctolong(half x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf16i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.long2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 trunctolong(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi64(RegisterConversion.ToV128(x), positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long2(trunctolong(x.x, promises), trunctolong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.long3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 trunctolong(half3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi64(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long3(trunctolong(x.xy, promises), trunctolong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.long4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 trunctolong(half4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi64(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long4(trunctolong(x.xy, promises), trunctolong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ulong"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong trunctoulong(half x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf16i32(x, signed: false, trunc: true, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 trunctoulong(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu64(RegisterConversion.ToV128(x), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong2(trunctoulong(x.x, promises), trunctoulong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 trunctoulong(half3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu64(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong3(trunctoulong(x.xy, promises), trunctoulong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 trunctoulong(half4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu64(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong4(trunctoulong(x.xy, promises), trunctoulong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="Int128"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 trunctoint128(half x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf16i32(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="UInt128"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 trunctouint128(half x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf16i32(x, signed: false, trunc: true, nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="sbyte"/> while rounding towards zero.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte trunctosbyte(float x)
        {
            return (sbyte)x;
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 trunctosbyte(float2 x)
        {
            return (sbyte2)x;
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 trunctosbyte(float3 x)
        {
            return (sbyte3)x;
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 trunctosbyte(float4 x)
        {
            return (sbyte4)x;
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 trunctosbyte(float8 x)
        {
            return (sbyte8)x;
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="byte"/> while rounding towards zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte trunctobyte(float x)
        {
            return (byte)x;
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 trunctobyte(float2 x)
        {
            return (byte2)x;
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 trunctobyte(float3 x)
        {
            return (byte3)x;
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 trunctobyte(float4 x)
        {
            return (byte4)x;
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 trunctobyte(float8 x)
        {
            return (byte8)x;
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="short"/> while rounding towards zero.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short trunctoshort(float x)
        {
            return (short)x;
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.short2"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 trunctoshort(float2 x)
        {
            return (short2)x;
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.short3"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 trunctoshort(float3 x)
        {
            return (short3)x;
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.short4"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 trunctoshort(float4 x)
        {
            return (short4)x;
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.short8"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 trunctoshort(float8 x)
        {
            return (short8)x;
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ushort"/> while rounding towards zero.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort trunctoushort(float x)
        {
            return (ushort)x;
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 trunctoushort(float2 x)
        {
            return (ushort2)x;
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 trunctoushort(float3 x)
        {
            return (ushort3)x;
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 trunctoushort(float4 x)
        {
            return (ushort4)x;
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 trunctoushort(float8 x)
        {
            return (ushort8)x;
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="int"/> while rounding towards zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int trunctoint(float x)
        {
            return (int)x;
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to an <see cref="int2"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 trunctoint(float2 x)
        {
            return (int2)x;
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to an <see cref="int3"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 trunctoint(float3 x)
        {
            return (int3)x;
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to an <see cref="int4"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 trunctoint(float4 x)
        {
            return (int4)x;
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to an <see cref="MaxMath.int8"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 trunctoint(float8 x)
        {
            return (int8)x;
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="uint"/> while rounding towards zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint trunctouint(float x)
        {
            return (uint)x;
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="uint2"/> component while rounding towards the nearest respective uinteger value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 trunctouint(float2 x)
        {
            return (uint2)x;
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="uint3"/> component while rounding towards the nearest respective uinteger value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 trunctouint(float3 x)
        {
            return (uint3)x;
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="uint4"/> component while rounding towards the nearest respective uinteger value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 trunctouint(float4 x)
        {
            return (uint4)x;
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.uint8"/> component while rounding towards the nearest respective uinteger value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 trunctouint(float8 x)
        {
            return (uint8)x;
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="long"/> while rounding towards zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long trunctolong(float x)
        {
            return (long)x;
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.long2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 trunctolong(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttps_epi64(RegisterConversion.ToV128(x), positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long2(trunctolong(x.x), trunctolong(x.y));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.long3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 trunctolong(float3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epi64(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long3(trunctolong(x.xy, promises), trunctolong(x.z));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.long4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 trunctolong(float4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epi64(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long4(trunctolong(x.xy, promises), trunctolong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ulong"/> while rounding towards zero.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong trunctoulong(float x)
        {
            return (ulong)x;
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 trunctoulong(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttps_epu64(RegisterConversion.ToV128(x), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong2(trunctoulong(x.x), trunctoulong(x.y));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 trunctoulong(float3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epu64(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong3(trunctoulong(x.xy, promises), trunctoulong(x.z));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 trunctoulong(float4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epu64(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong4(trunctoulong(x.xy, promises), trunctoulong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="Int128"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 trunctoint128(float x, Promise promises = Promise.Nothing)
        {
            return (Int128)BASE_cvtf32i128(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="UInt128"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 trunctouint128(float x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf32i128(x, signed: false, trunc: true, nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="sbyte"/> while rounding towards zero.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte trunctosbyte(double x)
        {
            return (sbyte)x;
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 trunctosbyte(double2 x)
        {
            return (sbyte2)x;
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 trunctosbyte(double3 x)
        {
            return (sbyte3)x;
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 trunctosbyte(double4 x)
        {
            return (sbyte4)x;
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="byte"/> while rounding towards zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte trunctobyte(double x)
        {
            return (byte)x;
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 trunctobyte(double2 x)
        {
            return (byte2)x;
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 trunctobyte(double3 x)
        {
            return (byte3)x;
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 trunctobyte(double4 x)
        {
            return (byte4)x;
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="short"/> while rounding towards zero.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short trunctoshort(double x)
        {
            return (short)x;
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.short2"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 trunctoshort(double2 x)
        {
            return (short2)x;
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.short3"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 trunctoshort(double3 x)
        {
            return (short3)x;
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.short4"/> component while rounding towards the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 trunctoshort(double4 x)
        {
            return (short4)x;
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ushort"/> while rounding towards zero.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort trunctoushort(double x)
        {
            return (ushort)x;
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 trunctoushort(double2 x)
        {
            return (ushort2)x;
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 trunctoushort(double3 x)
        {
            return (ushort3)x;
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards the nearest numerical value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 trunctoushort(double4 x)
        {
            return (ushort4)x;
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="int"/> while rounding towards zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int trunctoint(double x)
        {
            return (int)x;
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to an <see cref="int2"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 trunctoint(double2 x)
        {
            return (int2)x;
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to an <see cref="int3"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 trunctoint(double3 x)
        {
            return (int3)x;
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to an <see cref="int4"/> component while rounding towards the nearest numerical value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 trunctoint(double4 x)
        {
            return (int4)x;
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="uint"/> while rounding towards zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint trunctouint(double x)
        {
            return (uint)x;
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="uint2"/> component while rounding towards the nearest respective uinteger value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 trunctouint(double2 x)
        {
            return (uint2)x;
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="uint3"/> component while rounding towards the nearest respective uinteger value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 trunctouint(double3 x)
        {
            return (uint3)x;
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="uint4"/> component while rounding towards the nearest respective uinteger value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 trunctouint(double4 x)
        {
            return (uint4)x;
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="long"/> while rounding towards zero.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long trunctolong(double x)
        {
            return (long)x;
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.long2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 trunctolong(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpd_epi64(RegisterConversion.ToV128(x), positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long2(trunctolong(x.x), trunctolong(x.y));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.long3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 trunctolong(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epi64(RegisterConversion.ToV256(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long3(trunctolong(x.xy, promises), trunctolong(x.z));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.long4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 trunctolong(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epi64(RegisterConversion.ToV256(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long4(trunctolong(x.xy, promises), trunctolong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ulong"/> while rounding towards zero.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong trunctoulong(double x)
        {
            return (ulong)x;
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 trunctoulong(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpd_epu64(RegisterConversion.ToV128(x), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong2(trunctoulong(x.x), trunctoulong(x.y));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 trunctoulong(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epu64(RegisterConversion.ToV256(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong3(trunctoulong(x.xy, promises), trunctoulong(x.z));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 trunctoulong(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epu64(RegisterConversion.ToV256(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong4(trunctoulong(x.xy, promises), trunctoulong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="Int128"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 trunctoint128(double x, Promise promises = Promise.Nothing)
        {
            return (Int128)BASE_cvtf64i128(x, signed: true, trunc: true, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="UInt128"/> while rounding towards zero.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 trunctouint128(double x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf64i128(x, signed: false, trunc: true, nonZero: promises.Promises(Promise.NonZero));
        }
    }
}
