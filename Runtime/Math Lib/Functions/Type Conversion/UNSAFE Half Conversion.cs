using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="byte"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(byte x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromByte(x, promise.Promises(Promise.NonZero));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(byte2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepu8_ph(x, promise.Promises(Promise.NonZero), 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(byte3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepu8_ph(x, promise.Promises(Promise.NonZero), 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(byte4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtepu8_ph(x, promise.Promises(Promise.NonZero), 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise), tohalfunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte8"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfunsafe(byte8 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_ph(x, promise.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new half8(tohalfunsafe(x.x0, promise), tohalfunsafe(x.x1, promise), tohalfunsafe(x.x2, promise), tohalfunsafe(x.x3, promise), tohalfunsafe(x.x4, promise), tohalfunsafe(x.x5, promise), tohalfunsafe(x.x6, promise), tohalfunsafe(x.x7, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte16"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfunsafe(byte16 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu8_ph(x, promise.Promises(Promise.NonZero));
            }
            else
            {
                return new half16(tohalfunsafe(x.v8_0, promise), tohalfunsafe(x.v8_8, promise));
            }
        }


        /// <summary>       Converts a <see cref="ushort"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(ushort x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromUShort(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(ushort2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepu16_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(ushort3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepu16_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(ushort4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtepu16_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise), tohalfunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort8"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfunsafe(ushort8 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, 8);
            }
            else
            {
                return new half8(tohalfunsafe(x.x0, promise), tohalfunsafe(x.x1, promise), tohalfunsafe(x.x2, promise), tohalfunsafe(x.x3, promise), tohalfunsafe(x.x4, promise), tohalfunsafe(x.x5, promise), tohalfunsafe(x.x6, promise), tohalfunsafe(x.x7, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ushort16"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfunsafe(ushort16 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu16_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
            }
            else
            {
                return new half16(tohalfunsafe(x.v8_0, promise), tohalfunsafe(x.v8_8, promise));
            }
        }


        /// <summary>       Converts a <see cref="uint"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(uint x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromUInt(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
        }

        /// <summary>       Converts each value in a <see cref="uint2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(uint2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepu32_ph(RegisterConversion.ToV128(x), (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="uint3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(uint3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepu32_ph(RegisterConversion.ToV128(x), (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="uint4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(uint4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtepu32_ph(RegisterConversion.ToV128(x), (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise), tohalfunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.uint8"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfunsafe(uint8 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu32_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
            }
            else
            {
                return new half8(tohalfunsafe(x.v4_0, promise), tohalfunsafe(x.v4_4, promise));
            }
        }


        /// <summary>       Converts a <see cref="ulong"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(ulong x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromULong(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(ulong2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepu64_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(ulong3 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToHalf3(Xse.mm256_cvtepu64_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, elements: 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.xy, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(ulong4 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToHalf4(Xse.mm256_cvtepu64_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, elements: 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.xy, promise), tohalfunsafe(x.zw, promise));
            }
        }


        /// <summary>       Converts a <see cref="UInt128"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [0, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [0, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(UInt128 x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromUInt128(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
        }


        /// <summary>       Converts an <see cref="sbyte"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(sbyte x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromSByte(x, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater));
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(sbyte2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepi8_ph(x, promiseNonZero: promise.Promises(Promise.NonZero), promiseNotNegative: promise.Promises(Promise.ZeroOrGreater), 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(sbyte3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepi8_ph(x, promise.Promises(Promise.NonZero), promiseNotNegative: promise.Promises(Promise.ZeroOrGreater), 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(sbyte4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtepi8_ph(x, promise.Promises(Promise.NonZero), promiseNotNegative: promise.Promises(Promise.ZeroOrGreater), 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise), tohalfunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte8"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfunsafe(sbyte8 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_ph(x, promise.Promises(Promise.NonZero), promiseNotNegative: promise.Promises(Promise.ZeroOrGreater), 8);
            }
            else
            {
                return new half8(tohalfunsafe(x.x0, promise), tohalfunsafe(x.x1, promise), tohalfunsafe(x.x2, promise), tohalfunsafe(x.x3, promise), tohalfunsafe(x.x4, promise), tohalfunsafe(x.x5, promise), tohalfunsafe(x.x6, promise), tohalfunsafe(x.x7, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte16"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfunsafe(sbyte16 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi8_ph(x, promise.Promises(Promise.NonZero), promiseNotNegative: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new half16(tohalfunsafe(x.v8_0, promise), tohalfunsafe(x.v8_8, promise));
            }
        }


        /// <summary>       Converts a <see cref="short"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(short x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromShort(x, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), absBelow2pow11: promise.Promises(Promise.Unsafe0));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(short2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepi16_ph(x, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), absBelow2pow11: promise.Promises(Promise.Unsafe0), 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(short3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepi16_ph(x, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), absBelow2pow11: promise.Promises(Promise.Unsafe0), 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(short4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtepi16_ph(x, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), absBelow2pow11: promise.Promises(Promise.Unsafe0), 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise), tohalfunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short8"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfunsafe(short8 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_ph(x, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), absBelow2pow11: promise.Promises(Promise.Unsafe0), 8);
            }
            else
            {
                return new half8(tohalfunsafe(x.x0, promise), tohalfunsafe(x.x1, promise), tohalfunsafe(x.x2, promise), tohalfunsafe(x.x3, promise), tohalfunsafe(x.x4, promise), tohalfunsafe(x.x5, promise), tohalfunsafe(x.x6, promise), tohalfunsafe(x.x7, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short16"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfunsafe(short16 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi16_ph(x, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), absBelow2pow11: promise.Promises(Promise.Unsafe0));
            }
            else
            {
                return new half16(tohalfunsafe(x.v8_0, promise), tohalfunsafe(x.v8_8, promise));
            }
        }


        /// <summary>       Converts an <see cref="int"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(int x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromInt(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
        }

        /// <summary>       Converts each value in an <see cref="int2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(int2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepi32_ph(RegisterConversion.ToV128(x), (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, elements: 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="int3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(int3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepi32_ph(RegisterConversion.ToV128(x), (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, elements: 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="int4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(int4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtepi32_ph(RegisterConversion.ToV128(x), (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, elements: 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise), tohalfunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.int8"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfunsafe(int8 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi32_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
            }
            else
            {
                return new half8(tohalfunsafe(x.v4_0, promise), tohalfunsafe(x.v4_4, promise));
            }
        }


        /// <summary>       Converts a <see cref="long"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(long x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromLong(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(long2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepi64_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(long3 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToHalf3(Xse.mm256_cvtepi64_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, elements: 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.xy, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(long4 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToHalf4(Xse.mm256_cvtepi64_ph(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2, elements: 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.xy, promise), tohalfunsafe(x.zw, promise));
            }
        }


        /// <summary>       Converts an <see cref="Int128"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for input values equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns incorrect results for negative input values.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns incorrect results for input values outside the interval [-2047, 2047].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(Int128 x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromInt128(x, (half)float.PositiveInfinity, nonZero: promise.Promises(Promise.NonZero), nonNegative: promise.Promises(Promise.ZeroOrGreater), inRange: promise.CountUnsafeLevels() >= 1, absBelow2pow11: promise.CountUnsafeLevels() >= 2);
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(quarter x, Promise promise = Promise.Nothing)
        {
            return quarter.ToHalf(x, inRange: promise.Promises(Promise.NoOverflow), abs: promise.Promises(Promise.ZeroOrGreater));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(quarter2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtpq_ph(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(quarter3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtpq_ph(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(quarter4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtpq_ph(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise), tohalfunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter8"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfunsafe(quarter8 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ph(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 4);
            }
            else
            {
                return new half8(tohalfunsafe(x.x0, promise), tohalfunsafe(x.x1, promise), tohalfunsafe(x.x2, promise), tohalfunsafe(x.x3, promise), tohalfunsafe(x.x4, promise), tohalfunsafe(x.x5, promise), tohalfunsafe(x.x6, promise), tohalfunsafe(x.x7, promise));
            }
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.quarter16"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 tohalfunsafe(quarter16 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_ph(x);
            }
            else
            {
                return new half16(tohalfunsafe(x.v8_0, promise), tohalfunsafe(x.v8_8, promise));
            }
        }

        
        /// <summary>       Converts a <see cref="float"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(float x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromFloat(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0));
        }

        /// <summary>       Converts each value in a <see cref="float2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(float2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtps_ph(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0), elements: 2));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="float3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(float3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtps_ph(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0), elements: 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="float4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(float4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtps_ph(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0), elements: 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise), tohalfunsafe(x.z, promise), tohalfunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.float8"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalfunsafe(float8 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_ph(x);
            }
            else
            {
                return new half8(tohalfunsafe(x.v4_0, promise), tohalfunsafe(x.v4_4, promise));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to its <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(double x, Promise promise = Promise.Nothing)
        {
            return HalfExtensions.FromDouble(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0));
        }

        /// <summary>       Converts each value in a <see cref="double2"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalfunsafe(double2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtpd_ph(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new half2(tohalfunsafe(x.x, promise), tohalfunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="double3"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalfunsafe(double3 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToHalf3(Xse.mm256_cvtpd_ph(RegisterConversion.ToV256(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0), elements: 3));
            }
            else
            {
                return new half3(tohalfunsafe(x.xy, promise), tohalfunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="double4"/> to its respective <see cref="half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalfunsafe(double4 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToHalf4(Xse.mm256_cvtpd_ph(RegisterConversion.ToV256(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0), elements: 4));
            }
            else
            {
                return new half4(tohalfunsafe(x.xy, promise), tohalfunsafe(x.zw, promise));
            }
        }
    }
}
