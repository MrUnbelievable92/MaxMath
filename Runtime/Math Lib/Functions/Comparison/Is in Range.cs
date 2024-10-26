using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_epu8(v128 a, v128 b, v128 c)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return cmpeq_epi8(a, min_epu8(max_epu8(a, b), c));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_epu16(v128 a, v128 b, v128 c, byte elements = 8)
            {
                if (Architecture.IsMinMaxSupported)
                {
                    return cmpeq_epi16(a, min_epu16(max_epu16(a, b), c));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 minGreaterValue = cmpgt_epu16(b, a);
                    v128 valueGreaterMax = cmpgt_epu16(a, c);

                    return nor_si128(minGreaterValue, valueGreaterMax);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_epu32(v128 a, v128 b, v128 c, byte elements = 4)
            {
                if (Architecture.IsMinMaxSupported)
                {
                    return cmpeq_epi32(a, min_epu32(max_epu32(a, b), c));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 minGreaterValue = cmpgt_epu32(b, a);
                    v128 valueGreaterMax = cmpgt_epu32(a, c);

                    return nor_si128(minGreaterValue, valueGreaterMax);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_epu64(v128 a, v128 b, v128 c)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return cmpeq_epi64(a, min_epu64(max_epu64(a, b), c));
                //}
                //else
                if (Architecture.IsSIMDSupported)
                {
                    v128 minGreaterValue = cmpgt_epu64(b, a);
                    v128 valueGreaterMax = cmpgt_epu64(a, c);

                    return nor_si128(minGreaterValue, valueGreaterMax);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_epi8(v128 a, v128 b, v128 c, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(b) && constexpr.ALL_NEQ_EPI8(b, sbyte.MinValue, elements)
                     && constexpr.IS_CONST(c) && constexpr.ALL_NEQ_EPI8(c, sbyte.MaxValue, elements))
                    {
                        return and_si128(cmpgt_epi8(a, dec_epi8(b)), cmpgt_epi8(inc_epi8(c), a));
                    }

                    if (Architecture.IsMinMaxSupported)
                    {
                        return cmpeq_epi8(a, min_epi8(max_epi8(a, b), c));
                    }
                    else
                    {
                        v128 minGreaterValue = cmpgt_epi8(b, a);
                        v128 valueGreaterMax = cmpgt_epi8(a, c);

                        return nor_si128(minGreaterValue, valueGreaterMax);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_epi16(v128 a, v128 b, v128 c, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(b) && constexpr.ALL_NEQ_EPI16(b, short.MinValue, elements)
                     && constexpr.IS_CONST(c) && constexpr.ALL_NEQ_EPI16(c, short.MaxValue, elements))
                    {
                        return and_si128(cmpgt_epi16(a, dec_epi16(b)), cmpgt_epi16(inc_epi16(c), a));
                    }

                    return cmpeq_epi16(a, min_epi16(max_epi16(a, b), c));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_epi32(v128 a, v128 b, v128 c, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(b) && constexpr.ALL_NEQ_EPI32(b, int.MinValue, elements)
                     && constexpr.IS_CONST(c) && constexpr.ALL_NEQ_EPI32(c, int.MaxValue, elements))
                    {
                        return and_si128(cmpgt_epi32(a, dec_epi32(b)), cmpgt_epi32(inc_epi32(c), a));
                    }

                    if (Architecture.IsMinMaxSupported)
                    {
                        return cmpeq_epi32(a, min_epi32(max_epi32(a, b), c));
                    }
                    else
                    {
                        v128 minGreaterValue = cmpgt_epi32(b, a);
                        v128 valueGreaterMax = cmpgt_epi32(a, c);

                        return nor_si128(minGreaterValue, valueGreaterMax);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_epi64(v128 a, v128 b, v128 c)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return cmpeq_epi64(a, min_epi64(max_epi64(a, b), c));
                //}
                //else
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(b) && constexpr.ALL_NEQ_EPI64(b, long.MinValue)
                     && constexpr.IS_CONST(c) && constexpr.ALL_NEQ_EPI64(c, long.MaxValue))
                    {
                        return and_si128(cmpgt_epi64(a, dec_epi64(b)), cmpgt_epi64(inc_epi64(c), a));
                    }

                    v128 minGreaterValue = cmpgt_epi64(b, a);
                    v128 valueGreaterMax = cmpgt_epi64(a, c);

                    return nor_si128(minGreaterValue, valueGreaterMax);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_pq(v128 a, v128 b, v128 c, byte elements = 16, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return and_si128(cmpge_pq(a, b, promiseNeitherNaN: promiseNeitherNaN, promiseNeitherZero: promiseNeitherZero, elements: elements), cmple_pq(a, c, promiseNeitherNaN: promiseNeitherNaN, promiseNeitherZero: promiseNeitherZero, elements: elements));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_ph(v128 a, v128 b, v128 c, byte elements = 8, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return and_si128(cmpge_ph(a, b, promiseNeitherNaN: promiseNeitherNaN, promiseNeitherZero: promiseNeitherZero, elements: elements), cmple_ph(a, c, promiseNeitherNaN: promiseNeitherNaN, promiseNeitherZero: promiseNeitherZero, elements: elements));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_ps(v128 a, v128 b, v128 c)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return and_ps(cmpge_ps(a, b), cmple_ps(a, c));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmprange_pd(v128 a, v128 b, v128 c)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return and_pd(cmpge_pd(a, b), cmple_pd(a, c));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_epu8(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_cmpeq_epi8(a, Avx2.mm256_min_epu8(Avx2.mm256_max_epu8(a, b), c));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_epu16(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_cmpeq_epi16(a, Avx2.mm256_min_epu16(Avx2.mm256_max_epu16(a, b), c));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_epu32(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_min_epu32(Avx2.mm256_max_epu32(a, b), c));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_epu64(v256 a, v256 b, v256 c, byte elements = 4)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return Avx2.mm256_cmpeq_epi64(a, mm256_min_epu64(mm256_max_epu64(a, b), c));
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    v256 minGreaterValue = mm256_cmpgt_epu64(b, a, elements);
                    v256 valueGreaterMax = mm256_cmpgt_epu64(a, c, elements);

                    return mm256_not_si256(Avx2.mm256_or_si256(minGreaterValue, valueGreaterMax));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_epi8(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b) && constexpr.ALL_NEQ_EPI8(b, sbyte.MinValue)
                     && constexpr.IS_CONST(c) && constexpr.ALL_NEQ_EPI8(c, sbyte.MaxValue))
                    {
                        return Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi8(a, mm256_dec_epi8(b)), Avx2.mm256_cmpgt_epi8(mm256_inc_epi8(c), a));
                    }

                    return Avx2.mm256_cmpeq_epi8(a, Avx2.mm256_min_epi8(Avx2.mm256_max_epi8(a, b), c));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_epi16(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b) && constexpr.ALL_NEQ_EPI16(b, short.MinValue)
                     && constexpr.IS_CONST(c) && constexpr.ALL_NEQ_EPI16(c, short.MaxValue))
                    {
                        return Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi16(a, mm256_dec_epi16(b)), Avx2.mm256_cmpgt_epi16(mm256_inc_epi16(c), a));
                    }

                    return Avx2.mm256_cmpeq_epi16(a, Avx2.mm256_min_epi16(Avx2.mm256_max_epi16(a, b), c));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_epi32(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b) && constexpr.ALL_NEQ_EPI32(b, int.MinValue)
                     && constexpr.IS_CONST(c) && constexpr.ALL_NEQ_EPI32(c, int.MaxValue))
                    {
                        return Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi32(a, mm256_dec_epi32(b)), Avx2.mm256_cmpgt_epi32(mm256_inc_epi32(c), a));
                    }

                    return Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_min_epi32(Avx2.mm256_max_epi32(a, b), c));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_epi64(v256 a, v256 b, v256 c, byte elements = 4)
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return Avx2.mm256_cmpeq_epi64(a, mm256_min_epi64(mm256_max_epi64(a, b), c));
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b) && constexpr.ALL_NEQ_EPI64(b, long.MinValue, elements)
                     && constexpr.IS_CONST(c) && constexpr.ALL_NEQ_EPI64(c, long.MaxValue, elements))
                    {
                        return Avx2.mm256_and_si256(mm256_cmpgt_epi64(a, mm256_dec_epi64(b), elements), mm256_cmpgt_epi64(mm256_inc_epi64(c), a, elements));
                    }

                    v256 minGreaterValue = mm256_cmpgt_epi64(b, a, elements);
                    v256 valueGreaterMax = mm256_cmpgt_epi64(a, c, elements);

                    return mm256_not_si256(Avx2.mm256_or_si256(minGreaterValue, valueGreaterMax));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_ps(v256 a, v256 b, v256 c)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_and_ps(mm256_cmpge_ps(a, b), mm256_cmple_ps(a, c));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmprange_pd(v256 a, v256 b, v256 c)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_and_pd(mm256_cmpge_pd(a, b), mm256_cmple_pd(a, c));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true"/> if an <see cref="UInt128"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="UInt128"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(UInt128 x, UInt128 min, UInt128 max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns <see langword="true"/> if an <see cref="Int128"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="Int128"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(Int128 x, Int128 min, Int128 max)
        {
            return x >= min & x <= max;
        }


        /// <summary>       Returns <see langword="true"/> if an <see cref="byte"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="byte"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(byte x, byte min, byte max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.byte2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(byte2 x, byte2 min, byte2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.cmprange_epu8(x, min, max)));
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.byte3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(byte3 x, byte3 min, byte3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.cmprange_epu8(x, min, max)));
            }
            else
            {
                return new bool3(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y), isinrange(x.z, min.z, max.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.byte4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(byte4 x, byte4 min, byte4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.cmprange_epu8(x, min, max)));
            }
            else
            {
                return new bool4(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y), isinrange(x.z, min.z, max.z), isinrange(x.w, min.w, max.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.byte8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(byte8 x, byte8 min, byte8 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmprange_epu8(x, min, max));
            }
            else
            {
                return new bool8(isinrange(x.x0, min.x0, max.x0),
                                 isinrange(x.x1, min.x1, max.x1),
                                 isinrange(x.x2, min.x2, max.x2),
                                 isinrange(x.x3, min.x3, max.x3),
                                 isinrange(x.x4, min.x4, max.x4),
                                 isinrange(x.x5, min.x5, max.x5),
                                 isinrange(x.x6, min.x6, max.x6),
                                 isinrange(x.x7, min.x7, max.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.byte16"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isinrange(byte16 x, byte16 min, byte16 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmprange_epu8(x, min, max));
            }
            else
            {
                return new bool16(isinrange(x.x0,  min.x0,  max.x0),
                                  isinrange(x.x1,  min.x1,  max.x1),
                                  isinrange(x.x2,  min.x2,  max.x2),
                                  isinrange(x.x3,  min.x3,  max.x3),
                                  isinrange(x.x4,  min.x4,  max.x4),
                                  isinrange(x.x5,  min.x5,  max.x5),
                                  isinrange(x.x6,  min.x6,  max.x6),
                                  isinrange(x.x7,  min.x7,  max.x7),
                                  isinrange(x.x8,  min.x8,  max.x8),
                                  isinrange(x.x9,  min.x9,  max.x9),
                                  isinrange(x.x10, min.x10, max.x10),
                                  isinrange(x.x11, min.x11, max.x11),
                                  isinrange(x.x12, min.x12, max.x12),
                                  isinrange(x.x13, min.x13, max.x13),
                                  isinrange(x.x14, min.x14, max.x14),
                                  isinrange(x.x15, min.x15, max.x15));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> indicating for each component of a <see cref="MaxMath.byte32"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.byte32"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isinrange(byte32 x, byte32 min, byte32 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_cmprange_epu8(x, min, max));
            }
            else
            {
                return new bool32(isinrange(x.v16_0, min.v16_0, max.v16_0), isinrange(x.v16_16, min.v16_16, max.v16_16));
            }
        }


        /// <summary>       Returns <see langword="true"/> if an <see cref="sbyte"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="sbyte"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(sbyte x, sbyte min, sbyte max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of an <see cref="MaxMath.sbyte2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(sbyte2 x, sbyte2 min, sbyte2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.cmprange_epi8(x, min, max, 2)));
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of an <see cref="MaxMath.sbyte3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(sbyte3 x, sbyte3 min, sbyte3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.cmprange_epi8(x, min, max, 3)));
            }
            else
            {
                return new bool3(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y), isinrange(x.z, min.z, max.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of an <see cref="MaxMath.sbyte4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(sbyte4 x, sbyte4 min, sbyte4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.cmprange_epi8(x, min, max, 4)));
            }
            else
            {
                return new bool4(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y), isinrange(x.z, min.z, max.z), isinrange(x.w, min.w, max.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of an <see cref="MaxMath.sbyte8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(sbyte8 x, sbyte8 min, sbyte8 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmprange_epi8(x, min, max, 8));
            }
            else
            {
                return new bool8(isinrange(x.x0, min.x0, max.x0),
                                 isinrange(x.x1, min.x1, max.x1),
                                 isinrange(x.x2, min.x2, max.x2),
                                 isinrange(x.x3, min.x3, max.x3),
                                 isinrange(x.x4, min.x4, max.x4),
                                 isinrange(x.x5, min.x5, max.x5),
                                 isinrange(x.x6, min.x6, max.x6),
                                 isinrange(x.x7, min.x7, max.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> indicating for each component of an <see cref="MaxMath.sbyte16"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isinrange(sbyte16 x, sbyte16 min, sbyte16 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmprange_epi8(x, min, max, 16));
            }
            else
            {
                return new bool16(isinrange(x.x0,  min.x0,  max.x0),
                                  isinrange(x.x1,  min.x1,  max.x1),
                                  isinrange(x.x2,  min.x2,  max.x2),
                                  isinrange(x.x3,  min.x3,  max.x3),
                                  isinrange(x.x4,  min.x4,  max.x4),
                                  isinrange(x.x5,  min.x5,  max.x5),
                                  isinrange(x.x6,  min.x6,  max.x6),
                                  isinrange(x.x7,  min.x7,  max.x7),
                                  isinrange(x.x8,  min.x8,  max.x8),
                                  isinrange(x.x9,  min.x9,  max.x9),
                                  isinrange(x.x10, min.x10, max.x10),
                                  isinrange(x.x11, min.x11, max.x11),
                                  isinrange(x.x12, min.x12, max.x12),
                                  isinrange(x.x13, min.x13, max.x13),
                                  isinrange(x.x14, min.x14, max.x14),
                                  isinrange(x.x15, min.x15, max.x15));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> indicating for each component of an <see cref="MaxMath.sbyte32"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.sbyte32"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isinrange(sbyte32 x, sbyte32 min, sbyte32 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_cmprange_epi8(x, min, max));
            }
            else
            {
                return new bool32(isinrange(x.v16_0, min.v16_0, max.v16_0), isinrange(x.v16_16, min.v16_16, max.v16_16));
            }
        }


        /// <summary>       Returns <see langword="true"/> if an <see cref="short"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="short"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(short x, short min, short max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.short2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(short2 x, short2 min, short2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.cmprange_epi16(x, min, max, 2)));
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.short3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(short3 x, short3 min, short3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.cmprange_epi16(x, min, max, 3)));
            }
            else
            {
                return new bool3(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y), isinrange(x.z, min.z, max.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.short4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(short4 x, short4 min, short4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.cmprange_epi16(x, min, max, 4)));
            }
            else
            {
                return new bool4(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y), isinrange(x.z, min.z, max.z), isinrange(x.w, min.w, max.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.short8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(short8 x, short8 min, short8 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Xse.cmprange_epi16(x, min, max, 8));
            }
            else
            {
                return new bool8(isinrange(x.x0, min.x0, max.x0),
                                 isinrange(x.x1, min.x1, max.x1),
                                 isinrange(x.x2, min.x2, max.x2),
                                 isinrange(x.x3, min.x3, max.x3),
                                 isinrange(x.x4, min.x4, max.x4),
                                 isinrange(x.x5, min.x5, max.x5),
                                 isinrange(x.x6, min.x6, max.x6),
                                 isinrange(x.x7, min.x7, max.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.short16"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.short16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isinrange(short16 x, short16 min, short16 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.mm256_cmprange_epi16(x, min, max));
            }
            else
            {
                return new bool16(isinrange(x.v8_0, min.v8_0, max.v8_0), isinrange(x.v8_8, min.v8_8, max.v8_8));
            }
        }


        /// <summary>       Returns <see langword="true"/> if an <see cref="ushort"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="ushort"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(ushort x, ushort min, ushort max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.ushort2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(ushort2 x, ushort2 min, ushort2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.cmprange_epu16(x, min, max)));
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.ushort3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(ushort3 x, ushort3 min, ushort3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.cmprange_epu16(x, min, max)));
            }
            else
            {
                return new bool3(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y), isinrange(x.z, min.z, max.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.ushort4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(ushort4 x, ushort4 min, ushort4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.cmprange_epu16(x, min, max)));
            }
            else
            {
                return new bool4(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y), isinrange(x.z, min.z, max.z), isinrange(x.w, min.w, max.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.ushort8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(ushort8 x, ushort8 min, ushort8 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Xse.cmprange_epu16(x, min, max));
            }
            else
            {
                return new bool8(isinrange(x.x0, min.x0, max.x0),
                                 isinrange(x.x1, min.x1, max.x1),
                                 isinrange(x.x2, min.x2, max.x2),
                                 isinrange(x.x3, min.x3, max.x3),
                                 isinrange(x.x4, min.x4, max.x4),
                                 isinrange(x.x5, min.x5, max.x5),
                                 isinrange(x.x6, min.x6, max.x6),
                                 isinrange(x.x7, min.x7, max.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.ushort16"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ushort16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isinrange(ushort16 x, ushort16 min, ushort16 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.mm256_cmprange_epu16(x, min, max));
            }
            else
            {
                return new bool16(isinrange(x.v8_0, min.v8_0, max.v8_0), isinrange(x.v8_8, min.v8_8, max.v8_8));
            }
        }


        /// <summary>       Returns <see langword="true"/> if an <see cref="int"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="int"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(int x, int min, int max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of an <see cref="int2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="int2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(int2 x, int2 min, int2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue32(Xse.cmprange_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max), 2)));
            }
            else
            {
                return math.min(math.max(x, min), max) == x;
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of an <see cref="int3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="int3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(int3 x, int3 min, int3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(Xse.cmprange_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max), 3)));
            }
            else
            {
                return math.min(math.max(x, min), max) == x;
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of an <see cref="int4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="int4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(int4 x, int4 min, int4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue32(Xse.cmprange_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max), 4)));
            }
            else
            {
                return math.min(math.max(x, min), max) == x;
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of an <see cref="MaxMath.int8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.int8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(int8 x, int8 min, int8 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmprange_epi32(x, min, max));
            }
            else
            {
                return new bool8(isinrange(x.v4_0, min.v4_0, max.v4_0), isinrange(x.v4_4, min.v4_4, max.v4_4));
            }
        }


        /// <summary>       Returns <see langword="true"/> if a <see cref="uint"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="uint"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(uint x, uint min, uint max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="uint2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="uint2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(uint2 x, uint2 min, uint2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue32(Xse.cmprange_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max))));
            }
            else
            {
                return math.min(math.max(x, min), max) == x;
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="uint3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="uint3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(uint3 x, uint3 min, uint3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(Xse.cmprange_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max))));
            }
            else
            {
                return math.min(math.max(x, min), max) == x;
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="uint4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="uint4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(uint4 x, uint4 min, uint4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue32(Xse.cmprange_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max))));
            }
            else
            {
                return math.min(math.max(x, min), max) == x;
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.uint8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.uint8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(uint8 x, uint8 min, uint8 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmprange_epu32(x, min, max));
            }
            else
            {
                return new bool8(isinrange(x.v4_0, min.v4_0, max.v4_0), isinrange(x.v4_4, min.v4_4, max.v4_4));
            }
        }


        /// <summary>       Returns <see langword="true"/> if a <see cref="long"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="long"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(long x, long min, long max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.long2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.long2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(long2 x, long2 min, long2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.cmprange_epi64(x, min, max)));
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x), isinrange(x.y, min.y, max.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.long3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.long3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(long3 x, long3 min, long3 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmprange_epi64(x, min, max)));
            }
            else
            {
                return new bool3(isinrange(x.xy, min.xy, max.xy), isinrange(x.z, min.z, max.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.long4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.long4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(long4 x, long4 min, long4 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_cmprange_epi64(x, min, max)));
            }
            else
            {
                return new bool4(isinrange(x.xy, min.xy, max.xy), isinrange(x.zw, min.zw, max.zw));
            }
        }


        /// <summary>       Returns <see langword="true"/> if a <see cref="ulong"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="ulong"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(ulong x, ulong min, ulong max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.ulong2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ulong2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(ulong2 x, ulong2 min, ulong2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.cmprange_epu64(x, min, max)));
            }
            else
            {
                return maxmath.min(maxmath.max(x, min), max) == x;
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.ulong3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ulong3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(ulong3 x, ulong3 min, ulong3 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmprange_epu64(x, min, max)));
            }
            else
            {
                return new bool3(isinrange(x.xy, min.xy, max.xy), isinrange(x.z, min.z, max.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.ulong4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.ulong4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(ulong4 x, ulong4 min, ulong4 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_cmprange_epu64(x, min, max)));
            }
            else
            {
                return new bool4(isinrange(x.xy, min.xy, max.xy), isinrange(x.zw, min.zw, max.zw));
            }
        }



        /// <summary>       Returns <see langword="true"/> if a <see cref="quarter"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="quarter"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(quarter x, quarter min, quarter max, Promise promises = Promise.Nothing)
        {
            return x.IsGreaterThanOrEqualTo(min, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero)) & x.IsLessThanOrEqualTo(max, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.quarter2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.quarter2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(quarter2 x, quarter2 min, quarter2 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.cmprange_pq(x, min, max, promiseNeitherNaN: promises.Promises(Promise.Unsafe0), promiseNeitherZero: promises.Promises(Promise.NonZero), elements: 2)));
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x, promises), isinrange(x.y, min.y, max.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.quarter3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.quarter3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(quarter3 x, quarter3 min, quarter3 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.cmprange_pq(x, min, max, promiseNeitherNaN: promises.Promises(Promise.Unsafe0), promiseNeitherZero: promises.Promises(Promise.NonZero), elements: 3)));
            }
            else
            {
                return new bool3(isinrange(x.x, min.x, max.x, promises), isinrange(x.y, min.y, max.y, promises), isinrange(x.z, min.z, max.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.quarter4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.quarter4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(quarter4 x, quarter4 min, quarter4 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.cmprange_pq(x, min, max, promiseNeitherNaN: promises.Promises(Promise.Unsafe0), promiseNeitherZero: promises.Promises(Promise.NonZero), elements: 4)));
            }
            else
            {
                return new bool4(isinrange(x.x, min.x, max.x, promises), isinrange(x.y, min.y, max.y, promises), isinrange(x.z, min.z, max.z, promises), isinrange(x.w, min.w, max.w, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.quarter8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.quarter8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(quarter8 x, quarter8 min, quarter8 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmprange_pq(x, min, max, promiseNeitherNaN: promises.Promises(Promise.Unsafe0), promiseNeitherZero: promises.Promises(Promise.NonZero), elements: 8));
            }
            else
            {
                return new bool8(isinrange(x.x0, min.x0, max.x0, promises),
                                 isinrange(x.x1, min.x1, max.x1, promises),
                                 isinrange(x.x2, min.x2, max.x2, promises),
                                 isinrange(x.x3, min.x3, max.x3, promises),
                                 isinrange(x.x4, min.x4, max.x4, promises),
                                 isinrange(x.x5, min.x5, max.x5, promises),
                                 isinrange(x.x6, min.x6, max.x6, promises),
                                 isinrange(x.x7, min.x7, max.x7, promises));
            }
        }


        /// <summary>       Returns <see langword="true"/> if a <see cref="half"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="half"/><see langword="sbyte"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(half x, half min, half max, Promise promises = Promise.Nothing)
        {
            return x.IsGreaterThanOrEqualTo(min, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero)) & x.IsLessThanOrEqualTo(max, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="half2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="half2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(half2 x, half2 min, half2 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.cmprange_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max), promiseNeitherNaN: promises.Promises(Promise.Unsafe0), promiseNeitherZero: promises.Promises(Promise.NonZero), elements: 2)));
            }
            else
            {
                return new bool2(isinrange(x.x, min.x, max.x, promises), isinrange(x.y, min.y, max.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="half3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="half3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(half3 x, half3 min, half3 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.cmprange_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max), promiseNeitherNaN: promises.Promises(Promise.Unsafe0), promiseNeitherZero: promises.Promises(Promise.NonZero), elements: 3)));
            }
            else
            {
                return new bool3(isinrange(x.x, min.x, max.x, promises), isinrange(x.y, min.y, max.y, promises), isinrange(x.z, min.z, max.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="half4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="half4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(half4 x, half4 min, half4 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.cmprange_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(min), RegisterConversion.ToV128(max), promiseNeitherNaN: promises.Promises(Promise.Unsafe0), promiseNeitherZero: promises.Promises(Promise.NonZero), elements: 4)));
            }
            else
            {
                return new bool4(isinrange(x.x, min.x, max.x, promises), isinrange(x.y, min.y, max.y, promises), isinrange(x.z, min.z, max.z, promises), isinrange(x.w, min.w, max.w, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.half8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.half8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="min"/> or <paramref name="max"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(half8 x, half8 min, half8 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Xse.cmprange_ph(x, min, max, promiseNeitherNaN: promises.Promises(Promise.Unsafe0), promiseNeitherZero: promises.Promises(Promise.NonZero), elements: 8));
            }
            else
            {
                return new bool8(isinrange(x.x0, min.x0, max.x0, promises),
                                 isinrange(x.x1, min.x1, max.x1, promises),
                                 isinrange(x.x2, min.x2, max.x2, promises),
                                 isinrange(x.x3, min.x3, max.x3, promises),
                                 isinrange(x.x4, min.x4, max.x4, promises),
                                 isinrange(x.x5, min.x5, max.x5, promises),
                                 isinrange(x.x6, min.x6, max.x6, promises),
                                 isinrange(x.x7, min.x7, max.x7, promises));
            }
        }


        /// <summary>       Returns <see langword="true"/> if a <see cref="float"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="float"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(float x, float min, float max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="float2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="float2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(float2 x, float2 min, float2 max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="float3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="float3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(float3 x, float3 min, float3 max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="float4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="float4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(float4 x, float4 min, float4 max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="MaxMath.float8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinrange(float8 x, float8 min, float8 max)
        {
            return x >= min & x <= max;
        }


        /// <summary>       Returns <see langword="true"/> if a <see cref="double"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="double"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(double x, double min, double max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="double2"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="double2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinrange(double2 x, double2 min, double2 max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="double3"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="double3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinrange(double3 x, double3 min, double3 max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="double4"/> whether it is within the corresponding interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="double4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinrange(double4 x, double4 min, double4 max)
        {
            return x >= min & x <= max;
        }
    }
}