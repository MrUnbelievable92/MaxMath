using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the average value of two <see cref="Int128"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 avg(Int128 x, Int128 y)
        {
            Int128 intermediate = x + y;
            ulong isGreaterEqualZero = 1 - (intermediate.intern.hi >> 63);

            return (intermediate + isGreaterEqualZero) >> 1;
        }

        /// <summary>       Returns the average value of two <see cref="UInt128"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 avg(UInt128 x, UInt128 y)
        {
            return (x + y + 1u) >> 1;
        }


        /// <summary>       Returns the average value of two <see cref="byte"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte avg(byte x, byte y)
        {
            return (byte)(((uint)x + (uint)y + 1u) / 2u);
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.byte2"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte avg(byte2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu8(c, Sse2.bsrli_si128(c, 1 * sizeof(byte))).Byte0;
            }
            else
            {
                return (byte)((1u + csum(c)) / 2u);
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.byte2"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 avg(byte2 x, byte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu8(x, y);
            }
            else
            {
                return new byte2((byte)((x.x + y.x + 1) >> 1), (byte)((x.y + y.y + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.byte3"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte avg(byte3 c)
        {
            return (byte)((1u + csum(c)) / 3u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.byte3"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 avg(byte3 x, byte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu8(x, y);
            }
            else
            {
                return new byte3((byte)((x.x + y.x + 1) >> 1), (byte)((x.y + y.y + 1) >> 1), (byte)((x.z + y.z + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.byte4"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte avg(byte4 c)
        {
            return (byte)((1u + csum(c)) / 4u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.byte4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 avg(byte4 x, byte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu8(x, y);
            }
            else
            {
                return new byte4((byte)((x.x + y.x + 1) >> 1), (byte)((x.y + y.y + 1) >> 1), (byte)((x.z + y.z + 1) >> 1), (byte)((x.w + y.w + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.byte8"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte avg(byte8 c)
        {
            return (byte)((1u + csum(c)) / 8u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.byte8"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 avg(byte8 x, byte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu8(x, y);
            }
            else
            {
                return new byte8((byte)((x.x0 + y.x0 + 1) >> 1), (byte)((x.x1 + y.x1 + 1) >> 1), (byte)((x.x2 + y.x2 + 1) >> 1), (byte)((x.x3 + y.x3 + 1) >> 1), (byte)((x.x4 + y.x4 + 1) >> 1), (byte)((x.x5 + y.x5 + 1) >> 1), (byte)((x.x6 + y.x6 + 1) >> 1), (byte)((x.x7 + y.x7 + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.byte16"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte avg(byte16 c)
        {
            return (byte)((1u + csum(c)) / 16u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.byte16"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 avg(byte16 x, byte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu8(x, y);
            }
            else
            {
                return new byte16((byte)((x.x0 + y.x0 + 1) >> 1), (byte)((x.x1 + y.x1 + 1) >> 1), (byte)((x.x2 + y.x2 + 1) >> 1), (byte)((x.x3 + y.x3 + 1) >> 1), (byte)((x.x4 + y.x4 + 1) >> 1), (byte)((x.x5 + y.x5 + 1) >> 1), (byte)((x.x6 + y.x6 + 1) >> 1), (byte)((x.x7 + y.x7 + 1) >> 1), (byte)((x.x8 + y.x8 + 1) >> 1), (byte)((x.x9 + y.x9 + 1) >> 1), (byte)((x.x10 + y.x10 + 1) >> 1), (byte)((x.x11 + y.x11 + 1) >> 1), (byte)((x.x12 + y.x12 + 1) >> 1), (byte)((x.x13 + y.x13 + 1) >> 1), (byte)((x.x14 + y.x14 + 1) >> 1), (byte)((x.x15 + y.x15 + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.byte32"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte avg(byte32 c)
        {
            return (byte)((1u + csum(c)) / 32u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.byte32"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 avg(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_avg_epu8(x, y);
            }
            else
            {
                return new byte32(avg(x.v16_0, y.v16_0), avg(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns the average value of two <see cref="sbyte"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte avg(sbyte x, sbyte y)
        {
            int intermediate = x + y;

            return (sbyte)((intermediate + tobyte(intermediate > 0)) / 2);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte2"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 avg(sbyte2 x, sbyte2 y)
        {
            short2 result = ((short2)x + (short2)y);

            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                result -= Sse2.cmpgt_epi16(result, default(v128));
            }
            else
            {
                result += tosbyte(result > 0);
            }

            return (sbyte2)(result >> 1);
        }

        /// <summary>       Returns the average value of an <see cref="MaxMath.sbyte2"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte avg(sbyte2 c)
        {
            int intermediate = csum(c);

            return (sbyte)((intermediate + tobyte(intermediate > 0)) / 2);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte3"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 avg(sbyte3 x, sbyte3 y)
        {
            short3 result = ((short3)x + (short3)y);

            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                result -= Sse2.cmpgt_epi16(result, default(v128));
            }
            else
            {
                result += tosbyte(result > 0);
            }

            return (sbyte3)(result >> 1);
        }

        /// <summary>       Returns the average value of an <see cref="MaxMath.sbyte3"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte avg(sbyte3 c)
        {
            int intermediate = csum(c);

            return (sbyte)((intermediate + tobyte(intermediate > 0)) / 3);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 avg(sbyte4 x, sbyte4 y)
        {
            short4 result = ((short4)x + (short4)y);

            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                result -= Sse2.cmpgt_epi16(result, default(v128));
            }
            else
            {
                result += tosbyte(result > 0);
            }

            return (sbyte4)(result >> 1);
        }

        /// <summary>       Returns the average value of an <see cref="MaxMath.sbyte4"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte avg(sbyte4 c)
        {
            int intermediate = csum(c);

            return (sbyte)((intermediate + tobyte(intermediate > 0)) / 8);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte8"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 avg(sbyte8 x, sbyte8 y)
        {
            short8 result = ((short8)x + (short8)y);

            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                result -= Sse2.cmpgt_epi16(result, default(v128));
            }
            else
            {
                result += tosbyte(result > 0);
            }

            return (sbyte8)(result >> 1);
        }

        /// <summary>       Returns the average value of an <see cref="MaxMath.sbyte8"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte avg(sbyte8 c)
        {
            int intermediate = csum(c);

            return (sbyte)((intermediate + tobyte(intermediate > 0)) / 8);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte16"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 avg(sbyte16 x, sbyte16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                short16 result = ((short16)x + (short16)y);

                // if the intermediate sum is positive add 1
                result -= Avx2.mm256_cmpgt_epi16(result, default(v256));

                return (sbyte16)(result >> 1);
            }
            else
            {
                return new sbyte16(avg(x.v8_0, y.v8_0), avg(x.v8_8, y.v8_8));
            }
        }

        /// <summary>       Returns the average value of an <see cref="MaxMath.sbyte16"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte avg(sbyte16 c)
        {
            int intermediate = csum(c);

            return (sbyte)((intermediate + tobyte(intermediate > 0)) / 16);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte32"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 avg(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                short16 result_lo = (short16)x.v16_0 + (short16)y.v16_0;
                short16 result_hi = (short16)x.v16_16 + (short16)y.v16_16;

                // if the intermediate sum is positive add 1
                short16 isPositiveMask = Avx2.mm256_cmpgt_epi16(result_lo, default(v256));
                result_lo = (result_lo - isPositiveMask) >> 1;
                isPositiveMask = Avx2.mm256_cmpgt_epi16(result_hi, default(v256));
                result_hi = (result_hi - isPositiveMask) >> 1;

                return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi16(result_lo, result_hi), Sse.SHUFFLE(3, 1, 2, 0));
            }
            else
            {
                return new sbyte32(avg(x.v8_0, y.v8_0), avg(x.v8_8, y.v8_8), avg(x.v8_16, y.v8_16), avg(x.v8_24, y.v8_24));
            }
        }

        /// <summary>       Returns the average value of an <see cref="MaxMath.sbyte32"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte avg(sbyte32 c)
        {
            int intermediate = csum(c);

            return (sbyte)((intermediate + tobyte(intermediate > 0)) / 32);
        }


        /// <summary>       Returns the average value of two <see cref="ushort"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort avg(ushort x, ushort y)
        {
            return (ushort)(((uint)x + (uint)y + 1u) / 2u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.ushort2"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 avg(ushort2 x, ushort2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu16(x, y);
            }
            else
            {
                return new ushort2((ushort)((x.x + y.x + 1) >> 1), (ushort)((x.y + y.y + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.ushort2"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort avg(ushort2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu16(c, Sse2.bsrli_si128(c, 1 * sizeof(ushort))).UShort0;
            }
            else
            {
                return (ushort)((1u + csum(c)) / 2u);
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.ushort3"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 avg(ushort3 x, ushort3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu16(x, y);
            }
            else
            {
                return new ushort3((ushort)((x.x + y.x + 1) >> 1), (ushort)((x.y + y.y + 1) >> 1), (ushort)((x.z + y.z + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.ushort3"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort avg(ushort3 c)
        {
            return (ushort)((1u + csum(c)) / 3u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.ushort4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 avg(ushort4 x, ushort4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu16(x, y);
            }
            else
            {
                return new ushort4((ushort)((x.x + y.x + 1) >> 1), (ushort)((x.y + y.y + 1) >> 1), (ushort)((x.z + y.z + 1) >> 1), (ushort)((x.w + y.w + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.ushort4"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort avg(ushort4 c)
        {
            return (ushort)((1u + csum(c)) / 4u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.ushort4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 avg(ushort8 x, ushort8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.avg_epu16(x, y);
            }
            else
            {
                return new ushort8((ushort)((x.x0 + y.x0 + 1) >> 1), (ushort)((x.x1 + y.x1 + 1) >> 1), (ushort)((x.x2 + y.x2 + 1) >> 1), (ushort)((x.x3 + y.x3 + 1) >> 1), (ushort)((x.x4 + y.x4 + 1) >> 1), (ushort)((x.x5 + y.x5 + 1) >> 1), (ushort)((x.x6 + y.x6 + 1) >> 1), (ushort)((x.x7 + y.x7 + 1) >> 1));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.ushort8"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort avg(ushort8 c)
        {
            return (ushort)((1u + csum(c)) / 8u);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.ushort16"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 avg(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_avg_epu16(x, y);
            }
            else
            {
                return new ushort16(avg(x.v8_0, y.v8_0), avg(x.v8_8, y.v8_8));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.ushort16"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort avg(ushort16 c)
        {
            return (ushort)((1u + csum(c)) / 16u);
        }


        /// <summary>       Returns the average value of two <see cref="short"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short avg(short x, short y)
        {
            int intermediate = x + y;

            return (short)((intermediate + tobyte(intermediate > 0)) / 2);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short2"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 avg(short2 x, short2 y)
        {
            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.add_epi32(Cast.ShortToInt(x), Cast.ShortToInt(y));
                v128 isPositiveMask = Sse2.cmpgt_epi32(result, default(v128));
                result = Sse2.sub_epi32(result, isPositiveMask);

                return Cast.Int2ToShort2(Sse2.srai_epi32(result, 1));
            }
            else
            {
                int2 result = ((int2)x + (int2)y);
                result += tosbyte(result > 0);

                return (short2)(result >> 1);
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.short2"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short avg(short2 c)
        {
            int intermediate = csum(c);

            return (short)((intermediate + tobyte(intermediate > 0)) / 2);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short3"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 avg(short3 x, short3 y)
        {
            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.add_epi32(Cast.ShortToInt(x), Cast.ShortToInt(y));
                v128 isPositiveMask = Sse2.cmpgt_epi32(result, default(v128));
                result = Sse2.sub_epi32(result, isPositiveMask);

                if (Ssse3.IsSsse3Supported)
                {
                    return Cast.Int4ToShort4(Sse2.srai_epi32(result, 1));
                }
                else
                {
                    return Cast.Int3To_U_Short3_SSE2(Sse2.srai_epi32(result, 1));
                }
            }
            else
            {
                int3 result = ((int3)x + (int3)y);
                result += tosbyte(result > 0);

                return (short3)(result >> 1);
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.short3"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short avg(short3 c)
        {
            int intermediate = csum(c);

            return (short)((intermediate + tobyte(intermediate > 0)) / 3);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 avg(short4 x, short4 y)
        {
            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                v128 result = Sse2.add_epi32(Cast.ShortToInt(x), Cast.ShortToInt(y));
                v128 isPositiveMask = Sse2.cmpgt_epi32(result, default(v128));
                result = Sse2.sub_epi32(result, isPositiveMask);

                if (Ssse3.IsSsse3Supported)
                {
                    return Cast.Int4ToShort4(Sse2.srai_epi32(result, 1));
                }
                else
                {
                    return Cast.Int4To_U_Short4_SSE2(Sse2.srai_epi32(result, 1));
                }
            }
            else
            {
                int4 result = ((int4)x + (int4)y);
                result += tosbyte(result > 0);

                return (short4)(result >> 1);
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.short4"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short avg(short4 c)
        {
            int intermediate = csum(c);

            return (short)((intermediate + tobyte(intermediate > 0)) / 4);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short8"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 avg(short8 x, short8 y)
        {
            int8 result = ((int8)x + (int8)y);

            // if the intermediate sum is positive add 1
            if (Avx2.IsAvx2Supported)
            {
                int8 isPositiveMask = Avx2.mm256_cmpgt_epi32(result, default(v256));
                result = (result - isPositiveMask) >> 1;

                return Sse2.packs_epi32(Avx.mm256_castsi256_si128(result),
                                        Avx2.mm256_extracti128_si256(result, 1));
            }
            else
            {
                return new short8(avg(x.v4_0, y.v4_0), avg(x.v4_4, y.v4_4));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.short8"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short avg(short8 c)
        {
            int intermediate = csum(c);

            return (short)((intermediate + tobyte(intermediate > 0)) / 8);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short16"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 avg(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                int8 result_lo = (int8)x.v8_0 + (int8)y.v8_0;
                int8 result_hi = (int8)x.v8_8 + (int8)y.v8_8;

                // if the intermediate sum is positive add 1
                int8 isPositiveMask = Avx2.mm256_cmpgt_epi32(result_lo, default(v256));
                result_lo = (result_lo - isPositiveMask) >> 1;
                isPositiveMask = Avx2.mm256_cmpgt_epi32(result_hi, default(v256));
                result_hi = (result_hi - isPositiveMask) >> 1;

                return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi32(result_lo, result_hi), Sse.SHUFFLE(3, 1, 2, 0));
            }
            else
            {
                return new short16(avg(x.v4_0, y.v4_0), avg(x.v4_4, y.v4_4), avg(x.v4_8, y.v4_8), avg(x.v4_12, y.v4_12));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.short16"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short avg(short16 c)
        {
            int intermediate = csum(c);

            return (short)((intermediate + tobyte(intermediate > 0)) / 16);
        }

        /////////////////////////////////////////
        // NO OVERFLOW PROTECTION FROM HERE ON //
        /////////////////////////////////////////


        /// <summary>       Returns the average value of two <see cref="uint"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint avg(uint x, uint y)
        {
            return (x + y + 1u) / 2;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="uint2"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 avg(uint2 x, uint2 y)
        {
            return (x + y + 1u) >> 1;
        }

        /// <summary>       Returns the average value of a <see cref="uint2"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint avg(uint2 c)
        {
            return (1u + math.csum(c)) / 2;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="uint3"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 avg(uint3 x, uint3 y)
        {
            return (x + y + 1u) >> 1;
        }

        /// <summary>       Returns the average value of a <see cref="uint3"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint avg(uint3 c)
        {
            return (1u + math.csum(c)) / 3;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="uint4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 avg(uint4 x, uint4 y)
        {
            return (x + y + 1u) >> 1;
        }

        /// <summary>       Returns the average value of a <see cref="uint4"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint avg(uint4 c)
        {
            return (1u + math.csum(c)) / 4u;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.uint8"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 avg(uint8 x, uint8 y)
        {
            return (x + y + 1u) >> 1;
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.uint8"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint avg(uint8 c)
        {
            return (1u + csum(c)) / 8u;
        }


        /// <summary>       Returns the average value of two <see cref="int"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int avg(int x, int y)
        {
            int intermediate = x + y;

            return (intermediate + tobyte(intermediate > 0)) / 2;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="int2"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 avg(int2 x, int2 y)
        {
            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                v128 result = UnityMathematicsLink.Tov128(x + y);
                v128 isPositiveMask = Sse2.cmpgt_epi32(result, default(v128));
                result = Sse2.sub_epi32(result, isPositiveMask);
                result = Sse2.srai_epi32(result, 1);

                return *(int2*)&result;
            }
            else
            {
                int2 result = x + y;
                result += tosbyte(result > 0);

                return result >> 1;
            }
        }

        /// <summary>       Returns the average value of an <see cref="int2"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int avg(int2 c)
        {
            int intermediate = math.csum(c);

            return (intermediate + tobyte(intermediate > 0)) / 2;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="int3"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 avg(int3 x, int3 y)
        {
            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                v128 result = UnityMathematicsLink.Tov128(x + y);
                v128 isPositiveMask = Sse2.cmpgt_epi32(result, default(v128));
                result = Sse2.sub_epi32(result, isPositiveMask);
                result = Sse2.srai_epi32(result, 1);

                return *(int3*)&result;
            }
            else
            {
                int3 result = x + y;
                result += tosbyte(result > 0);

                return result >> 1;
            }
        }

        /// <summary>       Returns the average value of an <see cref="int3"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int avg(int3 c)
        {
            int intermediate = math.csum(c);

            return (intermediate + tobyte(intermediate > 0)) / 3;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="int4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 avg(int4 x, int4 y)
        {
            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                v128 result = UnityMathematicsLink.Tov128(x + y);
                v128 isPositiveMask = Sse2.cmpgt_epi32(result, default(v128));
                result = Sse2.sub_epi32(result, isPositiveMask);
                result = Sse2.srai_epi32(result, 1);

                return *(int4*)&result;
            }
            else
            {
                int4 result = x + y;
                result += tosbyte(result > 0);

                return result >> 1;
            }
        }

        /// <summary>       Returns the average value of an <see cref="int4"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int avg(int4 c)
        {
            int intermediate = math.csum(c);

            return (intermediate + tobyte(intermediate > 0)) / 4;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.int8"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 avg(int8 x, int8 y)
        {
            int8 result = x + y;

            // if the intermediate sum is positive add 1
            if (Avx2.IsAvx2Supported)
            {
                result -= Avx2.mm256_cmpgt_epi32(result, default(v256));
            }
            else
            {
                result += tosbyte(result > 0);
            }

            return result >> 1;
        }

        /// <summary>       Returns the average value of an <see cref="MaxMath.int8"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int avg(int8 c)
        {
            int intermediate = csum(c);

            return (intermediate + tobyte(intermediate > 0)) / 8;
        }


        /// <summary>       Returns the average value of two <see cref="ulong"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong avg(ulong x, ulong y)
        {
            return (x + y + 1u) / 2;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.ulong2"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 avg(ulong2 x, ulong2 y)
        {
            return (x + y + 1u) >> 1;
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.ulong2"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong avg(ulong2 c)
        {
            return (1u + csum(c)) / 2;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.ulong3"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 avg(ulong3 x, ulong3 y)
        {
            return (x + y + 1u) >> 1;
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.ulong3"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong avg(ulong3 c)
        {
            return (1u + csum(c)) / 3;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.ulong4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 avg(ulong4 x, ulong4 y)
        {
            return (x + y + 1u) >> 1;
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.ulong4"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong avg(ulong4 c)
        {
            return (1u + csum(c)) / 4;
        }


        /// <summary>       Returns the average value of two <see cref="long"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long avg(long x, long y)
        {
            long intermediate = x + y;

            return (intermediate + tobyte(intermediate > 0)) / 2;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.long2"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 avg(long2 x, long2 y)
        {
            long2 result = x + y;

            // if the intermediate sum is positive add 1
            if (Sse2.IsSse2Supported)
            {
                result -= Operator.greater_mask_long(result, default(v128));
            }
            else
            {
                result.x += tobyte(result.x > 0);
                result.y += tobyte(result.y > 0);
            }

            return result >> 1;
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.long2"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long avg(long2 c)
        {
            long intermediate = csum(c);

            return (intermediate + tobyte(intermediate > 0)) / 2;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.long3"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 avg(long3 x, long3 y)
        {
            // if the intermediate sum is positive add 1
            if (Avx2.IsAvx2Supported)
            {
                long3 result = x + y;

                result -= Avx2.mm256_cmpgt_epi64(result, default(v256));

                return result >> 1;
            }
            else
            {
                long resultZ = x.z + y.z;

                return new long3(avg(x.xy, y.xy), resultZ + tobyte(resultZ > 0));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.long3"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long avg(long3 c)
        {
            long intermediate = csum(c);

            return (intermediate + tobyte(intermediate > 0)) / 3;
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.long4"/>s with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 avg(long4 x, long4 y)
        {
            // if the intermediate sum is positive add 1
            if (Avx2.IsAvx2Supported)
            {
                long4 result = x + y;

                result -= Avx2.mm256_cmpgt_epi64(result, default(v256));

                return result >> 1;
            }
            else
            {
                return new long4(avg(x.xy, y.xy), avg(x.zw, y.zw));
            }
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.long4"/> with rounding from |x| + 0.5 to |x| + 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long avg(long4 c)
        {
            long intermediate = csum(c);

            return (intermediate + tobyte(intermediate > 0)) / 4;
        }


        /// <summary>       Returns the average value of two <see cref="float"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float avg(float x, float y)
        {
            return 0.5f * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="float2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 avg(float2 x, float2 y)
        {
            return 0.5f * (x + y);
        }

        /// <summary>       Returns the average value of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float avg(float2 c)
        {
            return 0.5f * math.csum(c);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="float3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 avg(float3 x, float3 y)
        {
            return 0.5f * (x + y);
        }

        /// <summary>       Returns the average value of a <see cref="float3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float avg(float3 c)
        {
            return (1f / 3f) * math.csum(c);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="float4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 avg(float4 x, float4 y)
        {
            return 0.5f * (x + y);
        }

        /// <summary>       Returns the average value of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float avg(float4 c)
        {
            return 0.25f * math.csum(c);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.float8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 avg(float8 x, float8 y)
        {
            return 0.5f * (x + y);
        }

        /// <summary>       Returns the average value of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float avg(float8 c)
        {
            return 0.125f * csum(c);
        }


        /// <summary>       Returns the average value of two <see cref="double"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double avg(double x, double y)
        {
            return 0.5d * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="double2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 avg(double2 x, double2 y)
        {
            return 0.5d * (x + y);
        }

        /// <summary>       Returns the average value of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double avg(double2 c)
        {
            return 0.5d * math.csum(c);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="double3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 avg(double3 x, double3 y)
        {
            return 0.5d * (x + y);
        }

        /// <summary>       Returns the average value of a <see cref="double3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double avg(double3 c)
        {
            return (1d / 3d) * math.csum(c);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="double4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 avg(double4 x, double4 y)
        {
            return 0.5d * (x + y);
        }

        /// <summary>       Returns the average value of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double avg(double4 c)
        {
            return 0.25d * math.csum(c);
        }
    }
}