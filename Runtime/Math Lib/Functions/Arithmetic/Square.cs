using MaxMath.Intrinsics;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 square(UInt128 x)
        {
            UInt128 product = UInt128.umul128(x.lo64, x.lo64);

            return new UInt128(product.lo64, product.hi64 + ((x.lo64 * x.hi64) << 1));
        }

        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 square(Int128 x)
        {
            return (Int128)square((UInt128)x);
        }


        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [return: AssumeRange(0u, byte.MaxValue * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int square(byte x)
        {
            return x * x;
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [0, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 square(byte2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.square_epi8(x, fourBit: promises.Promises(Promise.NoOverflow), elements: 2);
            }
            else
            {
                return x * x;
            }
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [0, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 square(byte3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.square_epi8(x, fourBit: promises.Promises(Promise.NoOverflow), elements: 3);
            }
            else
            {
                return x * x;
            }
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [0, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 square(byte4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.square_epi8(x, fourBit: promises.Promises(Promise.NoOverflow), elements: 4);
            }
            else
            {
                return x * x;
            }
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [0, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 square(byte8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.square_epi8(x, fourBit: promises.Promises(Promise.NoOverflow), elements: 8);
            }
            else
            {
                return x * x;
            }
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [0, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 square(byte16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.square_epi8(x, fourBit: promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return x * x;
            }
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [0, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 square(byte32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_square_epi8(x, fourBit: promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte32(square(x.v16_0, promises), square(x.v16_16, promises));
            }
        }


        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int square(sbyte x)
        {
            return square((byte)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [-15, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 square(sbyte2 x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.NoOverflow))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return (sbyte2)square((byte2)abs(x), promises);
                }
            }

            return (sbyte2)square((byte2)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [-15, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 square(sbyte3 x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.NoOverflow))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return (sbyte3)square((byte3)abs(x), promises);
                }
            }

            return (sbyte3)square((byte3)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [-15, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 square(sbyte4 x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.NoOverflow))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return (sbyte4)square((byte4)abs(x), promises);
                }
            }

            return (sbyte4)square((byte4)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [-15, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 square(sbyte8 x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.NoOverflow))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return (sbyte8)square((byte8)abs(x), promises);
                }
            }

            return (sbyte8)square((byte8)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [-15, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 square(sbyte16 x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.NoOverflow))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return (sbyte16)square((byte16)abs(x), promises);
                }
            }

            return (sbyte16)square((byte16)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> outside of the interval [-15, 15].      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 square(sbyte32 x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.NoOverflow))
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return (sbyte32)square((byte32)abs(x), promises);
                }
            }

            return (sbyte32)square((byte32)x);
        }


        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [return: AssumeRange(0u, (uint)ushort.MaxValue * ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int square(ushort x)
        {
            return x * x;
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 square(ushort2 x)
        {
            return x * x;
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 square(ushort3 x)
        {
            return x * x;
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 square(ushort4 x)
        {
            return x * x;
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 square(ushort8 x)
        {
            return x * x;
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 square(ushort16 x)
        {
            return x * x;
        }


        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int square(short x)
        {
            return square((ushort)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 square(short2 x)
        {
            return (short2)square((ushort2)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 square(short3 x)
        {
            return (short3)square((ushort3)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 square(short4 x)
        {
            return (short4)square((ushort4)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 square(short8 x)
        {
            return (short8)square((ushort8)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 square(short16 x)
        {
            return (short16)square((ushort16)x);
        }


        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 square(uint8 x)
        {
            return x * x;
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 square(int8 x)
        {
            return (int8)square((uint8)x);
        }


        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong square(ulong x)
        {
            return x * x;
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 square(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.square_epi64(x);
            }
            else
            {
                return x * x;
            }
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 square(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_square_epi64(x, 3);
            }
            else
            {
                return new ulong3(square(x.xy), square(x.z));
            }
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 square(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_square_epi64(x, 4);
            }
            else
            {
                return new ulong4(square(x.xy), square(x.zw));
            }
        }


        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long square(long x)
        {
            return (long)square((ulong)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 square(long2 x)
        {
            return (long2)square((ulong2)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 square(long3 x)
        {
            return (long3)square((ulong3)x);
        }

        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 square(long4 x)
        {
            return (long4)square((ulong4)x);
        }


        /// <summary>       Computes the component-wise square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 square(float8 x)
        {
            return x * x;
        }
    }
}