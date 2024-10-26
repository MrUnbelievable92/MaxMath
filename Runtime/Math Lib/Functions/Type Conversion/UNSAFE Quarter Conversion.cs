using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="byte"/> to its <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(byte x, Promise promise = Promise.NoOverflow)
        {
            return quarter.GetInteger(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(byte2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(byte3 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(byte4 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise), toquarterunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte8"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarterunsafe(byte8 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new quarter8(toquarterunsafe(x.x0, promise), toquarterunsafe(x.x1, promise), toquarterunsafe(x.x2, promise), toquarterunsafe(x.x3, promise), toquarterunsafe(x.x4, promise), toquarterunsafe(x.x5, promise), toquarterunsafe(x.x6, promise), toquarterunsafe(x.x7, promise));
            }
        }


        /// <summary>       Converts a <see cref="ushort"/> to its <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(ushort x, Promise promise = Promise.NoOverflow)
        {
            return quarter.GetInteger(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(ushort2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(ushort3 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(ushort4 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise), toquarterunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort8"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarterunsafe(ushort8 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new quarter8(toquarterunsafe(x.x0, promise), toquarterunsafe(x.x1, promise), toquarterunsafe(x.x2, promise), toquarterunsafe(x.x3, promise), toquarterunsafe(x.x4, promise), toquarterunsafe(x.x5, promise), toquarterunsafe(x.x6, promise), toquarterunsafe(x.x7, promise));
            }
        }


        /// <summary>       Converts a <see cref="uint"/> to its <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(uint x, Promise promise = Promise.NoOverflow)
        {
            return quarter.GetInteger(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
        }

        /// <summary>       Converts each value in a <see cref="uint2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(uint2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_pq(RegisterConversion.ToV128(x), quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="uint3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(uint3 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_pq(RegisterConversion.ToV128(x), quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="uint4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(uint4 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_pq(RegisterConversion.ToV128(x), quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise), toquarterunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.uint8"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarterunsafe(uint8 x, Promise promise = Promise.NoOverflow)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu32_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
            }
            else
            {
                return new quarter8(toquarterunsafe(x.v4_0, promise), toquarterunsafe(x.v4_4, promise));
            }
        }


        /// <summary>       Converts a <see cref="ulong"/> to its <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(ulong x, Promise promise = Promise.NoOverflow)
        {
            return quarter.GetInteger(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(ulong2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu64_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(ulong3 x, Promise promise = Promise.NoOverflow)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.xy, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [0, 15].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(ulong4 x, Promise promise = Promise.NoOverflow)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_pq(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.xy, promise), toquarterunsafe(x.zw, promise));
            }
        }


        /// <summary>       Converts an <see cref="sbyte"/> to its <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(sbyte x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.ZeroOrGreater))
            {
                return toquarterunsafe((byte)x, promise);
            }
            else
            {
                return quarter.SByteToQuarter(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(sbyte2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(sbyte3 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(sbyte4 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise), toquarterunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte8"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarterunsafe(sbyte8 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 8);
            }
            else
            {
                return new quarter8(toquarterunsafe(x.x0, promise), toquarterunsafe(x.x1, promise), toquarterunsafe(x.x2, promise), toquarterunsafe(x.x3, promise), toquarterunsafe(x.x4, promise), toquarterunsafe(x.x5, promise), toquarterunsafe(x.x6, promise), toquarterunsafe(x.x7, promise));
            }
        }


        /// <summary>       Converts a <see cref="short"/> to its <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(short x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.ZeroOrGreater))
            {
                return toquarterunsafe((ushort)x, promise);
            }
            else
            {
                return quarter.ShortToQuarter(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(short2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(short3 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(short4 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise), toquarterunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short8"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarterunsafe(short8 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 8);
            }
            else
            {
                return new quarter8(toquarterunsafe(x.x0, promise), toquarterunsafe(x.x1, promise), toquarterunsafe(x.x2, promise), toquarterunsafe(x.x3, promise), toquarterunsafe(x.x4, promise), toquarterunsafe(x.x5, promise), toquarterunsafe(x.x6, promise), toquarterunsafe(x.x7, promise));
            }
        }


        /// <summary>       Converts an <see cref="int"/> to its <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(int x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.ZeroOrGreater))
            {
                return toquarterunsafe((uint)x, promise);
            }
            else
            {
                return quarter.IntToQuarter(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
            }
        }

        /// <summary>       Converts each value in an <see cref="int2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(int2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_pq(RegisterConversion.ToV128(x), quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="int3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(int3 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_pq(RegisterConversion.ToV128(x), quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="int4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(int4 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_pq(RegisterConversion.ToV128(x), quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise), toquarterunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.int8"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarterunsafe(int8 x, Promise promise = Promise.NoOverflow)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi32_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new quarter8(toquarterunsafe(x.v4_0, promise), toquarterunsafe(x.v4_4, promise));
            }
        }


        /// <summary>       Converts a <see cref="long"/> to its <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(long x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.ZeroOrGreater))
            {
                return toquarterunsafe((ulong)x, promise);
            }
            else
            {
                return quarter.LongToQuarter(x, quarter.PositiveInfinity, promise.Promises(Promise.NoOverflow));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.long2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(long2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.long3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(long3 x, Promise promise = Promise.NoOverflow)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.xy, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.long4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation for input values outside the interval [-15, 15].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set may cause a memory access violation for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(long4 x, Promise promise = Promise.NoOverflow)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_pq(x, quarter.PositiveInfinity, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.xy, promise), toquarterunsafe(x.zw, promise));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to its <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(half x, Promise promise = Promise.NoOverflow)
        {
            return toquarterunsafe((float)x, promise);
        }

        /// <summary>       Converts each value in a <see cref="half2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(half2 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                return new quarter2(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="half3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(half3 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                return new quarter3(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="half4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(half4 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                return new quarter4(toquarterunsafe(x.x, promise), toquarterunsafe(x.y, promise), toquarterunsafe(x.z, promise), toquarterunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half8"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarterunsafe(half8 x, Promise promise = Promise.NoOverflow)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbsolute: promise.Promises(Promise.ZeroOrGreater), 8);
            }
            else
            {
                return new quarter8(toquarterunsafe(x.x0, promise), toquarterunsafe(x.x1, promise), toquarterunsafe(x.x2, promise), toquarterunsafe(x.x3, promise), toquarterunsafe(x.x4, promise), toquarterunsafe(x.x5, promise), toquarterunsafe(x.x6, promise), toquarterunsafe(x.x7, promise));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to its <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(float x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter)x;
        }

        /// <summary>       Converts each value in a <see cref="float2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(float2 x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter2)x;
        }

        /// <summary>       Converts each value in a <see cref="float3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(float3 x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter3)x;
        }

        /// <summary>       Converts each value in a <see cref="float4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(float4 x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter4)x;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.float8"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarterunsafe(float8 x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter8)x;
        }


        /// <summary>       Converts a <see cref="double"/> to its <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(double x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter)x;

        }

        /// <summary>       Converts each value in a <see cref="double2"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarterunsafe(double2 x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter2)x;
        }

        /// <summary>       Converts each value in a <see cref="double3"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarterunsafe(double3 x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter3)x;
        }

        /// <summary>       Converts each value in a <see cref="double4"/> to its respective <see cref="quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0. The <see cref="Promise.ZeroOrGreater"/> flag has no effect if the <see cref="Promise.NoOverflow"/> flag is not set aswell.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarterunsafe(double4 x, Promise promise = Promise.NoOverflow)
        {
            if (promise.Promises(Promise.NoOverflow))
            {
                if (promise.Promises(Promise.ZeroOrGreater))
                {
                }
                else
                {
                }
            }
                return (quarter4)x;
        }
    }
}
