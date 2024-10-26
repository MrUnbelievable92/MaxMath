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
            public static v128 avg_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (elements <= 8)
                    {
                        a = cvtepi8_epi16(a);
                        b = cvtepi8_epi16(b);

                        v128 avg = add_epi16(and_si128(a, b), srai_epi16(xor_si128(a, b), 1));

                        v128 sum = adds_epi16(a, b);
                        v128 addOneMask = cmpgt_epi16(sum, setall_si128());
                        avg = add_epi16(avg, and_si128(negmask_epi16(addOneMask), add_epi16(a, b)));

                        return packs_epi16(avg, avg);
                    }
                    else
                    {
                        v128 a16Lo = cvt2x2epi8_epi16(a, out v128 a16Hi);
                        v128 b16Lo = cvt2x2epi8_epi16(b, out v128 b16Hi);

                        v128 sumLo = add_epi16(a16Lo, b16Lo);
                        v128 sumHi = add_epi16(a16Hi, b16Hi);
                        v128 addOneMaskLo = cmpgt_epi16(sumLo, setall_si128());
                        v128 addOneMaskHi = cmpgt_epi16(sumHi, setall_si128());
                        sumLo = sub_epi16(sumLo, addOneMaskLo);
                        sumHi = sub_epi16(sumHi, addOneMaskHi);

                        v128 avgLo = srai_epi16(sumLo, 1);
                        v128 avgHi = srai_epi16(sumHi, 1);

                        return packs_epi16(avgLo, avgHi);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_avg_epi8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 a16Lo = mm256_cvt2x2epi8_epi16(a, out v256 a16Hi);
                    v256 b16Lo = mm256_cvt2x2epi8_epi16(b, out v256 b16Hi);

                    v256 sumLo = Avx2.mm256_add_epi16(a16Lo, b16Lo);
                    v256 sumHi = Avx2.mm256_add_epi16(a16Hi, b16Hi);
                    v256 addOneMaskLo = Avx2.mm256_cmpgt_epi16(sumLo, mm256_setall_si256());
                    v256 addOneMaskHi = Avx2.mm256_cmpgt_epi16(sumHi, mm256_setall_si256());
                    sumLo = Avx2.mm256_sub_epi16(sumLo, addOneMaskLo);
                    sumHi = Avx2.mm256_sub_epi16(sumHi, addOneMaskHi);

                    v256 avgLo = Avx2.mm256_srai_epi16(sumLo, 1);
                    v256 avgHi = Avx2.mm256_srai_epi16(sumHi, 1);

                    return Avx2.mm256_packs_epi16(avgLo, avgHi);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 avg_epi16(v128 a, v128 b, bool promise = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        v128 sum = adds_epi16(a, b);
                        v128 addOneMask = cmpgt_epi16(sum, setall_si128());
                        sum = subs_epi16(sum, addOneMask);

                        return srai_epi16(sum, 1);
                    }
                    else
                    {
                        v128 avg = add_epi16(and_si128(a, b), srai_epi16(xor_si128(a, b), 1));

                        v128 sum = adds_epi16(a, b);
                        v128 addOneMask = cmpgt_epi16(sum, setall_si128());
                        avg = add_epi16(avg, and_si128(negmask_epi16(addOneMask, elements), add_epi16(a, b)));

                        return avg;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_avg_epi16(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        v256 sum = Avx2.mm256_adds_epi16(a, b);
                        v256 addOneMask = Avx2.mm256_cmpgt_epi16(sum, mm256_setall_si256());
                        sum = Avx2.mm256_subs_epi16(sum, addOneMask);

                        return Avx2.mm256_srai_epi16(sum, 1);
                    }
                    else
                    {
                        v256 avg = Avx2.mm256_add_epi16(Avx2.mm256_and_si256(a, b), Avx2.mm256_srai_epi16(Avx2.mm256_xor_si256(a, b), 1));

                        v256 sum = Avx2.mm256_adds_epi16(a, b);
                        v256 addOneMask = Avx2.mm256_cmpgt_epi16(sum, mm256_setall_si256());
                        avg = Avx2.mm256_add_epi16(avg, Avx2.mm256_and_si256(mm256_abs_epi16(addOneMask), Avx2.mm256_add_epi16(a, b)));

                        return avg;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 avg_epi32(v128 a, v128 b, bool promise = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        v128 sum = add_epi32(a, b);
                        v128 addOneMask = cmpgt_epi32(sum, setall_si128());
                        sum = sub_epi32(sum, addOneMask);

                        return srai_epi32(sum, 1);
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            v128 sum = add_epi64(cvtepi32_epi64(a), cvtepi32_epi64(b));
                            sum = sub_epi64(sum, cmpgt_epi64(sum, setall_si128()));

                            sum = srai_epi64(sum, 1);

                            return cvtepi64_epi32(sum);
                        }
                        else
                        {
                            v128 a64Lo = cvt2x2epi32_epi64(a, out v128 a64Hi);
                            v128 b64Lo = cvt2x2epi32_epi64(b, out v128 b64Hi);

                            v128 sumLo = add_epi64(a64Lo, b64Lo);
                            v128 sumHi = add_epi64(a64Hi, b64Hi);
                            sumLo = sub_epi64(sumLo, cmpgt_epi64(sumLo, setall_si128()));
                            sumHi = sub_epi64(sumHi, cmpgt_epi64(sumHi, setall_si128()));

                            sumLo = srai_epi64(sumLo, 1);
                            sumHi = srai_epi64(sumHi, 1);

                            return cvt2x2epi64_epi32(sumLo, sumHi);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_avg_epi32(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        v256 sum = Avx2.mm256_add_epi32(a, b);
                        v256 addOneMask = Avx2.mm256_cmpgt_epi32(sum, mm256_setall_si256());
                        sum = Avx2.mm256_sub_epi32(sum, addOneMask);

                        return Avx2.mm256_srai_epi32(sum, 1);
                    }
                    else
                    {
                        v256 a64Lo = mm256_cvt2x2epi32_epi64(a, out v256 a64Hi);
                        v256 b64Lo = mm256_cvt2x2epi32_epi64(b, out v256 b64Hi);

                        v256 sumLo = Avx2.mm256_add_epi64(a64Lo, b64Lo);
                        v256 sumHi = Avx2.mm256_add_epi64(a64Hi, b64Hi);
                        sumLo = Avx2.mm256_sub_epi64(sumLo, mm256_cmpgt_epi64(sumLo, mm256_setall_si256()));
                        sumHi = Avx2.mm256_sub_epi64(sumHi, mm256_cmpgt_epi64(sumHi, mm256_setall_si256()));

                        sumLo = mm256_srai_epi64(sumLo, 1);
                        sumHi = mm256_srai_epi64(sumHi, 1);

                        return mm256_cvt2x2epi64_epi32(sumLo, sumHi);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 avg_epi64(v128 a, v128 b, bool promise = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        v128 sum = add_epi64(a, b);
                        v128 addOneMask = cmpgt_epi64(sum, setall_si128());
                        sum = sub_epi64(sum, addOneMask);

                        return srai_epi64(sum, 1);
                    }
                    else
                    {
                        v128 avg = add_epi64(and_si128(a, b), srai_epi64(xor_si128(a, b), 1));

                        v128 sum = adds_epi64(a, b);
                        v128 addOneMask = cmpgt_epi64(sum, setall_si128());
                        avg = add_epi64(avg, and_si128(negmask_epi64(addOneMask), add_epi64(a, b)));

                        return avg;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_avg_epi64(v256 a, v256 b, byte elements = 4, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        v256 sum = Avx2.mm256_add_epi64(a, b);
                        v256 addOneMask = mm256_cmpgt_epi64(sum, mm256_setall_si256(), elements);
                        sum = Avx2.mm256_sub_epi64(sum, addOneMask);

                        return mm256_srai_epi64(sum, 1, elements);
                    }
                    else
                    {
                        v256 avg = Avx2.mm256_add_epi64(Avx2.mm256_and_si256(a, b), mm256_srai_epi64(Avx2.mm256_xor_si256(a, b), 1, elements));

                        v256 sum = mm256_adds_epi64(a, b);
                        v256 addOneMask = mm256_cmpgt_epi64(sum, mm256_setall_si256());
                        avg = Avx2.mm256_add_epi64(avg, Avx2.mm256_and_si256(mm256_negmask_epi64(addOneMask), Avx2.mm256_add_epi64(a, b)));

                        return avg;
                    }
                }
                else throw new IllegalInstructionException();
            }

            
		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 avg_epu8(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.avg_epu8(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrhaddq_u8(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }
		    
		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 avg_epu16(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.avg_epu16(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrhaddq_u16(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 avg_epu32(v128 a, v128 b, bool promise = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (promise)
                    {
                        if (constexpr.IS_CONST(a))
                        {
                            a = inc_epi32(a);
                        }
                        else
                        {
                            b = inc_epi32(b);
                        }

                        return srli_epi32(add_epi32(a, b), 1);
                    }
                    else
                    {
                        if (constexpr.IS_CONST(a))
                        {
                            v128 abtToOverflow = cmpeq_epi32(a, setall_si128());
                            a = sub_epi32(a, andnot_si128(abtToOverflow, setall_si128()));
                        }
                        else
                        {
                            v128 abtToOverflow = cmpeq_epi32(b, setall_si128());
                            b = sub_epi32(b, andnot_si128(abtToOverflow, setall_si128()));
                        }

                        return add_epi32(and_si128(a, b), srli_epi32(xor_si128(a, b), 1));
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrhaddq_u32(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_avg_epu32(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        if (constexpr.IS_CONST(a))
                        {
                            a = mm256_inc_epi32(a);
                        }
                        else
                        {
                            b = mm256_inc_epi32(b);
                        }

                        return Avx2.mm256_srli_epi32(Avx2.mm256_add_epi32(a, b), 1);
                    }
                    else
                    {
                        if (constexpr.IS_CONST(a))
                        {
                            v256 abtToOverflow = Avx2.mm256_cmpeq_epi32(a, mm256_setall_si256());
                            a = Avx2.mm256_sub_epi32(a, Avx2.mm256_andnot_si256(abtToOverflow, mm256_setall_si256()));
                        }
                        else
                        {
                            v256 abtToOverflow = Avx2.mm256_cmpeq_epi32(b, mm256_setall_si256());
                            b = Avx2.mm256_sub_epi32(b, Avx2.mm256_andnot_si256(abtToOverflow, mm256_setall_si256()));
                        }

                        return Avx2.mm256_add_epi32(Avx2.mm256_and_si256(a, b), Avx2.mm256_srli_epi32(Avx2.mm256_xor_si256(a, b), 1));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 avg_epu64(v128 a, v128 b, bool promise = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        if (constexpr.IS_CONST(a))
                        {
                            a = inc_epi64(a);
                        }
                        else
                        {
                            b = inc_epi64(b);
                        }

                        return srli_epi64(add_epi64(a, b), 1);
                    }
                    else
                    {
                        return add_epi64(and_si128(set1_epi64x(1), add_epi64(a, b)), add_epi64(and_si128(a, b), srli_epi64(xor_si128(a, b), 1)));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_avg_epu64(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        if (constexpr.IS_CONST(a))
                        {
                            a = mm256_inc_epi64(a);
                        }
                        else
                        {
                            b = mm256_inc_epi64(b);
                        }

                        return Avx2.mm256_srli_epi64(Avx2.mm256_add_epi64(a, b), 1);
                    }
                    else
                    {
                        return Avx2.mm256_add_epi64(Avx2.mm256_and_si256(mm256_set1_epi64x(1), Avx2.mm256_add_epi64(a, b)), Avx2.mm256_add_epi64(Avx2.mm256_and_si256(a, b), Avx2.mm256_srli_epi64(Avx2.mm256_xor_si256(a, b), 1)));
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the average value of two <see cref="Int128"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 that overflows. It is only recommended to use this overload if <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 avg(Int128 x, Int128 y, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                Int128 intermediate = x + y;
                ulong isGreaterEqualZero = 1 - (intermediate.hi64 >> 63);

                return (intermediate + isGreaterEqualZero) >> 1;
            }
            else
            {
                Int128 sumS = addsaturated(x, y);

                if (constexpr.IS_CONST(x))
                {
                    x += andnot(tobyte(x != Int128.MaxValue), sumS.hi64 >> 63);
                }
                else
                {
                    y += andnot(tobyte(y != Int128.MaxValue), sumS.hi64 >> 63);
                }

                return (x & y) + ((x ^ y) >> 1);
            }
        }

        /// <summary>       Returns the ceiling of the average value of two <see cref="UInt128"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 that overflow. It is only recommended to use this overload if <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 avg(UInt128 x, UInt128 y, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (x + y + 1u) >> 1;
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    x = addsaturated(x, 1);
                }
                else
                {
                    y = addsaturated(y, 1);
                }

                return (x & y) + ((x ^ y) >> 1);
            }
        }


        /// <summary>       Returns the ceiling of the average value of two <see cref="byte"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte avg(byte x, byte y)
        {
            return (byte)(((uint)x + (uint)y + 1u) / 2u);
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.byte2"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 avg(byte2 x, byte2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu8(x, y);
            }
            else
            {
                return new byte2(avg(x.x, y.x), avg(x.y, y.y));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.byte3"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 avg(byte3 x, byte3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu8(x, y);
            }
            else
            {
                return new byte3(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.byte4"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 avg(byte4 x, byte4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu8(x, y);
            }
            else
            {
                return new byte4(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z), avg(x.w, y.w));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.byte8"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 avg(byte8 x, byte8 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu8(x, y);
            }
            else
            {
                return new byte8(avg(x.x0, y.x0), avg(x.x1, y.x1), avg(x.x2, y.x2), avg(x.x3, y.x3), avg(x.x4, y.x4), avg(x.x5, y.x5), avg(x.x6, y.x6), avg(x.x7, y.x7));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.byte16"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 avg(byte16 x, byte16 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu8(x, y);
            }
            else
            {
                return new byte16(avg(x.x0, y.x0), avg(x.x1, y.x1), avg(x.x2, y.x2), avg(x.x3, y.x3), avg(x.x4, y.x4), avg(x.x5, y.x5), avg(x.x6, y.x6), avg(x.x7, y.x7), avg(x.x8, y.x8), avg(x.x9, y.x9), avg(x.x10, y.x10), avg(x.x11, y.x11), avg(x.x12, y.x12), avg(x.x13, y.x13), avg(x.x14, y.x14), avg(x.x15, y.x15));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.byte32"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
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


        /// <summary>       Returns the average value of two <see cref="sbyte"/>s where fractional results round away from zero; equivalent to (<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte avg(sbyte x, sbyte y)
        {
            int intermediate = x + y;

            return (sbyte)((intermediate + (int)((uint)~intermediate >> 31)) >> 1);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte2"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 avg(sbyte2 x, sbyte2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi8(x, y, 2);
            }
            else
            {
                return new sbyte2(avg(x.x, y.x), avg(x.y, y.y));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte3"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 avg(sbyte3 x, sbyte3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi8(x, y, 3);
            }
            else
            {
                return new sbyte3(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte4"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 avg(sbyte4 x, sbyte4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi8(x, y, 4);
            }
            else
            {
                return new sbyte4(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z), avg(x.w, y.w));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte8"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 avg(sbyte8 x, sbyte8 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi8(x, y, 8);
            }
            else
            {
                return new sbyte8(avg(x.x0, y.x0), avg(x.x1, y.x1), avg(x.x2, y.x2), avg(x.x3, y.x3), avg(x.x4, y.x4), avg(x.x5, y.x5), avg(x.x6, y.x6), avg(x.x7, y.x7));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte16"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 avg(sbyte16 x, sbyte16 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi8(x, y, 16);
            }
            else
            {
                return new sbyte16(avg(x.x0, y.x0), avg(x.x1, y.x1), avg(x.x2, y.x2), avg(x.x3, y.x3), avg(x.x4, y.x4), avg(x.x5, y.x5), avg(x.x6, y.x6), avg(x.x7, y.x7), avg(x.x8, y.x8), avg(x.x9, y.x9), avg(x.x10, y.x10), avg(x.x11, y.x11), avg(x.x12, y.x12), avg(x.x13, y.x13), avg(x.x14, y.x14), avg(x.x15, y.x15));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.sbyte32"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 avg(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_avg_epi8(x, y);
            }
            else
            {
                return new sbyte32(avg(x.v16_0, y.v16_0), avg(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns the ceiling of the average value of two <see cref="ushort"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort avg(ushort x, ushort y)
        {
            return (ushort)(((uint)x + (uint)y + 1u) / 2u);
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.ushort2"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 avg(ushort2 x, ushort2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu16(x, y);
            }
            else
            {
                return new ushort2(avg(x.x, y.x), avg(x.y, y.y));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.ushort3"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 avg(ushort3 x, ushort3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu16(x, y);
            }
            else
            {
                return new ushort3(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.ushort4"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 avg(ushort4 x, ushort4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu16(x, y);
            }
            else
            {
                return new ushort4(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z), avg(x.w, y.w));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.ushort4"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 avg(ushort8 x, ushort8 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu16(x, y);
            }
            else
            {
                return new ushort8(avg(x.x0, y.x0), avg(x.x1, y.x1), avg(x.x2, y.x2), avg(x.x3, y.x3), avg(x.x4, y.x4), avg(x.x5, y.x5), avg(x.x6, y.x6), avg(x.x7, y.x7));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.ushort16"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
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


        /// <summary>       Returns the average value of two <see cref="short"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short avg(short x, short y)
        {
            int intermediate = x + y;

            return (short)((intermediate + (int)((uint)~intermediate >> 31)) >> 1);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short2"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 avg(short2 x, short2 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi16(x, y, noOverflow.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new short2(avg(x.x, y.x), avg(x.y, y.y));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short3"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 avg(short3 x, short3 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi16(x, y, noOverflow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new short3(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short4"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 avg(short4 x, short4 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi16(x, y, noOverflow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new short4(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z), avg(x.w, y.w));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short8"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 avg(short8 x, short8 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi16(x, y, noOverflow.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new short8(avg(x.x0, y.x0), avg(x.x1, y.x1), avg(x.x2, y.x2), avg(x.x3, y.x3), avg(x.x4, y.x4), avg(x.x5, y.x5), avg(x.x6, y.x6), avg(x.x7, y.x7));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.short16"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 avg(short16 x, short16 y, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_avg_epi16(x, y, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short16(avg(x.v8_0, y.v8_0, noOverflow), avg(x.v8_8, y.v8_8, noOverflow));
            }
        }


        /// <summary>       Returns the ceiling of the average value of two <see cref="uint"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint avg(uint x, uint y)
        {
            return (uint)(((ulong)x + (ulong)y + 1u) / 2);
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="uint2"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 avg(uint2 x, uint2 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.avg_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow)));
            }
            else
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return (x + y + 1u) >> 1;
                }
                else
                {
                    return (uint2)(((ulong2)x + (ulong2)y + 1u) >> 1);
                }
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="uint3"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 avg(uint3 x, uint3 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.avg_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow)));
            }
            else
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return (x + y + 1u) >> 1;
                }
                else
                {
                    return (uint3)(((ulong3)x + (ulong3)y + 1u) >> 1);
                }
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="uint4"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 avg(uint4 x, uint4 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.avg_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow)));
            }
            else
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return (x + y + 1u) >> 1;
                }
                else
                {
                    return (uint4)(((ulong4)x + (ulong4)y + 1u) >> 1);
                }
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.uint8"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 avg(uint8 x, uint8 y, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_avg_epu32(x, y, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint8(avg(x.v4_0, y.v4_0, noOverflow), avg(x.v4_4, y.v4_4, noOverflow));
            }
        }


        /// <summary>       Returns the average value of two <see cref="int"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int avg(int x, int y)
        {
            long intermediate = (long)x + (long)y;

            return (int)((intermediate + (long)((ulong)~intermediate >> 63)) >> 1);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="int2"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 avg(int2 x, int2 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.avg_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow), 2));
            }
            else
            {
                return new int2(avg(x.x, y.x), avg(x.y, y.y));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="int3"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 avg(int3 x, int3 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.avg_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow), 3));
            }
            else
            {
                return new int3(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="int4"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 avg(int4 x, int4 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.avg_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow), 4));
            }
            else
            {
                return new int4(avg(x.x, y.x), avg(x.y, y.y), avg(x.z, y.z), avg(x.w, y.w));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.int8"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 avg(int8 x, int8 y, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_avg_epi32(x, y, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(avg(x.v4_0, y.v4_0, noOverflow), avg(x.v4_4, y.v4_4, noOverflow));
            }
        }


        /// <summary>       Returns the ceiling of the average value of two <see cref="ulong"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 that overflow. It is only recommended to use this overload if <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong avg(ulong x, ulong y, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (x + y + 1u) / 2;
            }
            else
            {
                return (1 & (x + y)) + (x & y) + ((x ^ y) >> 1);
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.ulong2"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 avg(ulong2 x, ulong2 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epu64(x, y, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return (x + y + 1u) >> 1;
                }
                else
                {
                    return (1 & (x + y)) + (x & y) + ((x ^ y) >> 1);
                }
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.ulong3"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 avg(ulong3 x, ulong3 y, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_avg_epu64(x, y, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong3(avg(x.xy, y.xy, noOverflow), avg(x.z, y.z, noOverflow));
            }
        }

        /// <summary>       Returns the componentwise ceiling of the average value of two <see cref="MaxMath.ulong4"/>s, equivalent to ⌈(<paramref name="x"/> + <paramref name="y"/>) / 2⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 avg(ulong4 x, ulong4 y, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_avg_epu64(x, y, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong4(avg(x.xy, y.xy, noOverflow), avg(x.zw, y.zw, noOverflow));
            }
        }


        /// <summary>       Returns the average value of two <see cref="long"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 that overflow. It is only recommended to use this overload if <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, <paramref name="x"/> or <paramref name="y"/> <see langword="-"/> 1, as well as <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/> or <see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long avg(long x, long y, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                long sum = x + y;
                sum += (long)((ulong)~sum >> 63);

                return sum >> 1;
            }
            else
            {
                Int128 sum = (Int128)x + y;
                sum += (long)((ulong)~sum.hi64 >> 63);

                return (long)(sum >> 1);
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.long2"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 avg(long2 x, long2 y, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.avg_epi64(x, y, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(avg(x.x, y.x, noOverflow), avg(x.y, y.y, noOverflow));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.long3"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 avg(long3 x, long3 y, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_avg_epi64(x, y, 3, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long3(avg(x.xy, y.xy, noOverflow), avg(x.z, y.z, noOverflow));
            }
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.long4"/>s where fractional results round away from zero; equivalent to ((<paramref name="x"/> + <paramref name="y"/>) / 2 >= 0 ? 1 : -1) * ⌈|(<paramref name="x"/> + <paramref name="y"/>) / 2|⌉.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1 component pair that overflows. It is only recommended to use this overload if each <paramref name="x"/> or <paramref name="y"/> <see langword="+"/>/<see langword="-"/> 1, as well as each <see langword="("/><paramref name="x"/> <see langword="+"/> <paramref name="y"/><see langword=")"/> <see langword="+"/>/<see langword="-"/> 1 is guaranteed not to overflow.      </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 avg(long4 x, long4 y, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_avg_epi64(x, y, 4, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long4(avg(x.xy, y.xy, noOverflow), avg(x.zw, y.zw, noOverflow));
            }
        }


        /// <summary>       Returns the average value of two <see cref="float"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float avg(float x, float y)
        {
            if (constexpr.IS_CONST(x))
            {
                return math.mad(0.5f, y, 0.5f * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return math.mad(0.5f, x, 0.5f * y);
            }

            return 0.5f * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="float2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 avg(float2 x, float2 y)
        {
            if (constexpr.IS_CONST(x))
            {
                return math.mad(0.5f, y, 0.5f * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return math.mad(0.5f, x, 0.5f * y);
            }

            return 0.5f * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="float3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 avg(float3 x, float3 y)
        {
            if (constexpr.IS_CONST(x))
            {
                return math.mad(0.5f, y, 0.5f * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return math.mad(0.5f, x, 0.5f * y);
            }

            return 0.5f * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="float4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 avg(float4 x, float4 y)
        {
            if (constexpr.IS_CONST(x))
            {
                return math.mad(0.5f, y, 0.5f * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return math.mad(0.5f, x, 0.5f * y);
            }

            return 0.5f * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="MaxMath.float8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 avg(float8 x, float8 y)
        {
            if (constexpr.IS_CONST(x))
            {
                return mad(0.5f, y, 0.5f * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return mad(0.5f, x, 0.5f * y);
            }

            return 0.5f * (x + y);
        }


        /// <summary>       Returns the average value of two <see cref="double"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double avg(double x, double y)
        {
            if (constexpr.IS_CONST(x))
            {
                return math.mad(0.5d, y, 0.5d * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return math.mad(0.5d, x, 0.5d * y);
            }

            return 0.5d * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="double2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 avg(double2 x, double2 y)
        {
            if (constexpr.IS_CONST(x))
            {
                return math.mad(0.5d, y, 0.5d * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return math.mad(0.5d, x, 0.5d * y);
            }

            return 0.5d * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="double3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 avg(double3 x, double3 y)
        {
            if (constexpr.IS_CONST(x))
            {
                return math.mad(0.5d, y, 0.5d * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return math.mad(0.5d, x, 0.5d * y);
            }

            return 0.5d * (x + y);
        }

        /// <summary>       Returns the componentwise average value of two <see cref="double4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 avg(double4 x, double4 y)
        {
            if (constexpr.IS_CONST(x))
            {
                return math.mad(0.5d, y, 0.5d * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return math.mad(0.5d, x, 0.5d * y);
            }

            return 0.5d * (x + y);
        }
    }
}