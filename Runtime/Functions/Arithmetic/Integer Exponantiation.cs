using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Computes x to the power of n.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intpow(long x, ulong n)
        {
            long p = x;
            long y = 1;

            while (true)
            {
                if ((n % 2) == 1)
                {
                    y *= p;
                }

                n >>= 1;

                if (n == 0)
                {
                    return y;
                }

                p *= p;
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intpow(long2 x, ulong2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = long2.zero;
                v128 ONE = new long2(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                v128 p = x;
                v128 y = ONE;


            Loop:
                v128 y_times_p = Operator.mul_long(y, p);
                y = Mask.BlendV(y, y_times_p, Operator.equals_mask_long(ONE, ONE & n));

                n >>= 1;

                v128 n_is_zero = Sse4_1.cmpeq_epi64(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (bitmask32(2 * sizeof(long)) != Sse2.movemask_epi8(doneMask))
                {
                    p = Operator.mul_long(p, p);

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new long2(intpow(x.x, n.x), intpow(x.y, n.y));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intpow(long3 x, ulong3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = long3.zero;
                v256 ONE = new long3(1);

                v256 doneMask = ZERO;
                v256 result = ZERO;

                v256 p = x;
                v256 y = ONE;


            Loop:
                v256 y_times_p = Operator.mul_long(y, p);
                y = Avx2.mm256_blendv_epi8(y, y_times_p, Avx2.mm256_cmpeq_epi64(ONE, ONE & n));

                n >>= 1;

                v256 n_is_zero = Avx2.mm256_cmpeq_epi64(ZERO, n);
                result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (bitmask32(3 * sizeof(long)) != (bitmask32(3 * sizeof(long)) & Avx2.mm256_movemask_epi8(doneMask)))
                {
                    p = Operator.mul_long(p, p);

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new long3(intpow(x.xy, n.xy), intpow(x.z, n.z));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intpow(long4 x, ulong4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = long4.zero;
                v256 ONE = new long4(1);

                v256 doneMask = ZERO;
                v256 result = ZERO;

                v256 p = x;
                v256 y = ONE;


            Loop:
                v256 y_times_p = Operator.mul_long(y, p);
                y = Avx2.mm256_blendv_epi8(y, y_times_p, Avx2.mm256_cmpeq_epi64(ONE, ONE & n));

                n >>= 1;

                v256 n_is_zero = Avx2.mm256_cmpeq_epi64(ZERO, n);
                result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != Avx2.mm256_movemask_epi8(doneMask))
                {
                    p = Operator.mul_long(p, p);

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new long4(intpow(x.xy, n.xy), intpow(x.zw, n.zw));
            }
        }


        // <summary>       Computes x to the power of n.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intpow(ulong x, ulong n)
        {
            return (ulong)intpow((long)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intpow(ulong2 x, ulong2 n)
        {
            return (ulong2)intpow((long2)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intpow(ulong3 x, ulong3 n)
        {
            return (ulong3)intpow((long3)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intpow(ulong4 x, ulong4 n)
        {
            return (ulong4)intpow((long4)x, n);
        }


        /// <summary>       Computes x to the power of n.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intpow(int x, uint n)
        {
            int p = x;
            int y = 1;

            while (true)
            {
                if ((n % 2) == 1)
                {
                    y *= p;
                }
            
                n >>= 1;
            
                if (n == 0)
                {
                    return y;
                }
            
                p *= p;
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intpow(int2 x, uint2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                v128 ONE = new v128(1);
                v128 _x = *(v128*)&x;
                v128 _n = *(v128*)&n;

                v128 doneMask = ZERO;
                v128 result = ZERO;

                v128 p = _x;
                v128 y = ONE;


            Loop:
                v128 y_times_p = Operator.mul_int(y, p);
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(ONE, _n)));

                _n = Sse2.srli_epi32(_n, 1);

                v128 n_is_zero = Sse2.cmpeq_epi32(ZERO, _n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != doneMask.SLong0)
                {
                    p = Operator.mul_int(p, p);

                    goto Loop;
                }
                else
                {
                    return *(int2*)&result;
                }
            }
            else
            {
                return new int2(intpow(x.x, n.x), intpow(x.y, n.y));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intpow(int3 x, uint3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                v128 ONE = new v128(1);
                v128 _x = *(v128*)&x;
                v128 _n = *(v128*)&n;

                v128 doneMask = ZERO;
                v128 result = ZERO;

                v128 p = _x;
                v128 y = ONE;


            Loop:
                v128 y_times_p = Operator.mul_int(y, p);
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(ONE, _n)));

                _n = Sse2.srli_epi32(_n, 1);

                v128 n_is_zero = Sse2.cmpeq_epi32(ZERO, _n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (bitmask32(3 * sizeof(int)) != (bitmask32(3 * sizeof(int)) & Sse2.movemask_epi8(doneMask)))
                {
                    p = Operator.mul_int(p, p);

                    goto Loop;
                }
                else
                {
                    return *(int3*)&result;
                }
            }
            else
            {
                return new int3(intpow(x.x, n.x), intpow(x.y, n.y), intpow(x.z, n.z));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intpow(int4 x, uint4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                v128 ONE = new v128(1);
                v128 _x = *(v128*)&x;
                v128 _n = *(v128*)&n;

                v128 doneMask = ZERO;
                v128 result = ZERO;

                v128 p = _x;
                v128 y = ONE;

            Loop:
                v128 y_times_p = Operator.mul_int(y, p);
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(ONE, _n)));

                _n = Sse2.srli_epi32(_n, 1);

                v128 n_is_zero = Sse2.cmpeq_epi32(ZERO, _n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (bitmask32(4 * sizeof(int)) != Sse2.movemask_epi8(doneMask))
                {
                    p = Operator.mul_int(p, p);

                    goto Loop;
                }
                else
                {
                    return *(int4*)&result;
                }
            }
            else
            {
                return new int4(intpow(x.x, n.x), intpow(x.y, n.y), intpow(x.z, n.z), intpow(x.w, n.w));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intpow(int8 x, uint8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                int8 ZERO = int8.zero;
                v256 ONE = new int8(1);

                v256 doneMask = ZERO;
                v256 result = ZERO;

                int8 p = x;
                int8 y = ONE;


            Loop:
                v256 y_times_p = y * p;
                y = Avx2.mm256_blendv_epi8(y, y_times_p, Avx2.mm256_cmpeq_epi32(ONE, ONE & n));

                n >>= 1;

                v256 n_is_zero = Avx2.mm256_cmpeq_epi32(ZERO, n);
                result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != Avx2.mm256_movemask_epi8(doneMask))
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new int8(intpow(x.v4_0, n.v4_0), intpow(x.v4_4, n.v4_4));
            }
        }


        /// <summary>       Computes x to the power of n.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intpow(uint x, uint n)
        {
            return (uint)intpow((int)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intpow(uint2 x, uint2 n)
        {
            return (uint2)intpow((int2)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intpow(uint3 x, uint3 n)
        {
            return (uint3)intpow((int3)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intpow(uint4 x, uint4 n)
        {
            return (uint4)intpow((int4)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intpow(uint8 x, uint8 n)
        {
            return (uint8)intpow((int8)x, n);
        }


        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intpow(short2 x, ushort2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                short2 ONE = new short2(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                short2 p = x;
                short2 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != doneMask.SInt0)
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new short2((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intpow(short3 x, ushort3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                short3 ONE = new short3(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                short3 p = x;
                short3 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (bitmask32(3 * sizeof(short)) != (bitmask32(3 * sizeof(short)) & Sse2.movemask_epi8(doneMask)))
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new short3((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y), (short)intpow((int)x.z, n.z));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intpow(short4 x, ushort4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                short4 ONE = new short4(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                short4 p = x;
                short4 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != doneMask.SLong0)
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new short4((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y), (short)intpow((int)x.z, n.z), (short)intpow((int)x.w, n.w));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intpow(short8 x, ushort8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                short8 ONE = new short8(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                short8 p = x;
                short8 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (bitmask32(8 * sizeof(short)) != Sse2.movemask_epi8(doneMask))
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new short8((short)intpow((int)x.x0, n.x0), 
                                  (short)intpow((int)x.x1, n.x1), 
                                  (short)intpow((int)x.x2, n.x2),
                                  (short)intpow((int)x.x3, n.x3),
                                  (short)intpow((int)x.x4, n.x4),
                                  (short)intpow((int)x.x5, n.x5),
                                  (short)intpow((int)x.x6, n.x6),
                                  (short)intpow((int)x.x7, n.x7));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intpow(short16 x, ushort16 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = default(v256);
                short16 ONE = new short16(1);

                v256 doneMask = ZERO;
                v256 result = ZERO;

                short16 p = x;
                short16 y = ONE;


                Loop:
                v256 y_times_p = y * p;
                y = Avx2.mm256_blendv_epi8(y, y_times_p, Avx2.mm256_cmpeq_epi16(ONE, Avx2.mm256_and_si256(ONE, n)));

                n >>= 1;

                v256 n_is_zero = Avx2.mm256_cmpeq_epi16(ZERO, n);
                result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != Avx2.mm256_movemask_epi8(doneMask))
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new short16(intpow(x.v8_0, n.v8_0), intpow(x.v8_8, n.v8_8));
            }
        }


        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intpow(ushort2 x, ushort2 n)
        {
            return (ushort2)intpow((short2)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intpow(ushort3 x, ushort3 n)
        {
            return (ushort3)intpow((short3)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intpow(ushort4 x, ushort4 n)
        {
            return (ushort4)intpow((short4)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intpow(ushort8 x, ushort8 n)
        {
            return (ushort8)intpow((short8)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intpow(ushort16 x, ushort16 n)
        {
            return (ushort16)intpow((short16)x, n);
        }


        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intpow(sbyte2 x, byte2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                sbyte2 ONE = new sbyte2(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                sbyte2 p = x;
                sbyte2 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi8(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != doneMask.SShort0)
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new sbyte2((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intpow(sbyte3 x, byte3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                sbyte3 ONE = new sbyte3(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                sbyte3 p = x;
                sbyte3 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi8(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (bitmask32(3 * sizeof(sbyte)) != (bitmask32(3 * sizeof(sbyte)) & Sse2.movemask_epi8(doneMask)))
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new sbyte3((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y), (sbyte)intpow((int)x.z, n.z));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intpow(sbyte4 x, byte4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                sbyte4 ONE = new sbyte4(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                sbyte4 p = x;
                sbyte4 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi8(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != doneMask.SInt0)
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new sbyte4((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y), (sbyte)intpow((int)x.z, n.z), (sbyte)intpow((int)x.w, n.w));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intpow(sbyte8 x, byte8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                sbyte8 ONE = new sbyte8(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                sbyte8 p = x;
                sbyte8 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi8(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != doneMask.SLong0)
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new sbyte8((sbyte)intpow((int)x.x0, n.x0),
                                  (sbyte)intpow((int)x.x1, n.x1),
                                  (sbyte)intpow((int)x.x2, n.x2),
                                  (sbyte)intpow((int)x.x3, n.x3),
                                  (sbyte)intpow((int)x.x4, n.x4),
                                  (sbyte)intpow((int)x.x5, n.x5),
                                  (sbyte)intpow((int)x.x6, n.x6),
                                  (sbyte)intpow((int)x.x7, n.x7));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intpow(sbyte16 x, byte16 n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);
                sbyte16 ONE = new sbyte16(1);

                v128 doneMask = ZERO;
                v128 result = ZERO;

                sbyte16 p = x;
                sbyte16 y = ONE;


                Loop:
                v128 y_times_p = y * p;
                y = Mask.BlendV(y, y_times_p, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(ONE, n)));

                n >>= 1;

                v128 n_is_zero = Sse2.cmpeq_epi8(ZERO, n);
                result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (bitmask32(16 * sizeof(sbyte)) != Sse2.movemask_epi8(doneMask))
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new sbyte16((sbyte)intpow((int)x.x0,  n.x0),
                                   (sbyte)intpow((int)x.x1,  n.x1),
                                   (sbyte)intpow((int)x.x2,  n.x2),
                                   (sbyte)intpow((int)x.x3,  n.x3),
                                   (sbyte)intpow((int)x.x4,  n.x4),
                                   (sbyte)intpow((int)x.x5,  n.x5),
                                   (sbyte)intpow((int)x.x6,  n.x6),
                                   (sbyte)intpow((int)x.x7,  n.x7),
                                   (sbyte)intpow((int)x.x8,  n.x8),
                                   (sbyte)intpow((int)x.x9,  n.x9),
                                   (sbyte)intpow((int)x.x10, n.x10),
                                   (sbyte)intpow((int)x.x11, n.x11),
                                   (sbyte)intpow((int)x.x12, n.x12),
                                   (sbyte)intpow((int)x.x13, n.x13),
                                   (sbyte)intpow((int)x.x14, n.x14),
                                   (sbyte)intpow((int)x.x15, n.x15));
            }
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intpow(sbyte32 x, byte32 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = default(v256);
                sbyte32 ONE = new sbyte32(1);

                v256 doneMask = ZERO;
                v256 result = ZERO;

                sbyte32 p = x;
                sbyte32 y = ONE;


                Loop:
                v256 y_times_p = y * p;
                y = Avx2.mm256_blendv_epi8(y, y_times_p, Avx2.mm256_cmpeq_epi8(ONE, Avx2.mm256_and_si256(ONE, n)));

                n >>= 1;

                v256 n_is_zero = Avx2.mm256_cmpeq_epi8(ZERO, n);
                result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                doneMask = n_is_zero;


                if (-1 != Avx2.mm256_movemask_epi8(doneMask))
                {
                    p *= p;

                    goto Loop;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return new sbyte32(intpow(x.v16_0, n.v16_0), intpow(x.v16_16, n.v16_16));
            }
        }


        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intpow(byte2 x, byte2 n)
        {
            return (byte2)intpow((sbyte2)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intpow(byte3 x, byte3 n)
        {
            return (byte3)intpow((sbyte3)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intpow(byte4 x, byte4 n)
        {
            return (byte4)intpow((sbyte4)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intpow(byte8 x, byte8 n)
        {
            return (byte8)intpow((sbyte8)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intpow(byte16 x, byte16 n)
        {
            return (byte16)intpow((sbyte16)x, n);
        }

        /// <summary>       Computes x to the power of n for each component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intpow(byte32 x, byte32 n)
        {
            return (byte32)intpow((sbyte32)x, n);
        }
    }
}