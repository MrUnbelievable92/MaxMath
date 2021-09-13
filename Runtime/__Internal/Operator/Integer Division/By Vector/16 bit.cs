using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        //// Let this test run for a few weeks LOL - I've validated the unambigious accuracy of division of every single (u)short value by every single (u)short value (except 0)
        //// both with div_ps and mul_ps(rcp_ps, x) - by burst-compiling both functions and using varying float precision
        //
        //static void FullTest()
        //{
        //    NativeArray<bool> x = new NativeArray<bool>(1, Allocator.Persistent);
        //    NativeArray<bool> y = new NativeArray<bool>(1, Allocator.Persistent);
        //
        //    JobHandle unsigned = new TestUnsignedJob { r = x }.Schedule();
        //    JobHandle signed = new TestSignedJob { r = y }.Schedule();
        //
        //    JobHandle.ScheduleBatchedJobs();
        //
        //    unsigned.Complete();
        //    signed.Complete();
        //
        //    print(x[0]);
        //    print(y[0]);
        //
        //    x.Dispose();
        //    y.Dispose();
        //
        //}
        //
        //[BurstCompile(FloatMode = FloatMode.Fast, FloatPrecision = FloatPrecision.Low)]
        //struct TestUnsignedJob : IJob
        //{
        //    internal NativeArray<bool> r;
        //
        //    internal void Execute()
        //    {
        //        bool result = true;
        //
        //        ushort8 dividendStart = new ushort8(0, 1, 2, 3, 4, 5, 6, 7);
        //        
        //        for (int i = 0; i < 65529; i += 8, dividendStart += 8)
        //        {
        //            ushort8 divisorStart = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
        //
        //            for (int j = 0; j < 65528; j++, divisorStart += 1)
        //            {
        //                result &= vdiv_ushort(dividendStart, divisorStart).Equals(new ushort8((ushort)(dividendStart.x0 / divisorStart.x0),
        //                                                                                      (ushort)(dividendStart.x1 / divisorStart.x1),
        //                                                                                      (ushort)(dividendStart.x2 / divisorStart.x2),
        //                                                                                      (ushort)(dividendStart.x3 / divisorStart.x3),
        //                                                                                      (ushort)(dividendStart.x4 / divisorStart.x4),
        //                                                                                      (ushort)(dividendStart.x5 / divisorStart.x5),
        //                                                                                      (ushort)(dividendStart.x6 / divisorStart.x6),
        //                                                                                      (ushort)(dividendStart.x7 / divisorStart.x7)));
        //            }
        //        }
        //
        //        r[0] = result;
        //    }
        //}
        //
        //[BurstCompile(FloatMode = FloatMode.Fast, FloatPrecision = FloatPrecision.Low)]
        //struct TestSignedJob : IJob
        //{
        //    internal NativeArray<bool> r;
        //
        //    internal void Execute()
        //    {
        //        bool result = true;
        //
        //        short8 dividendStart = short.MinValue + new short8(0, 1, 2, 3, 4, 5, 6, 7);
        //
        //        for (int i = 0; i < 65529; i += 8, dividendStart += 8)
        //        {
        //            short8 divisorStart = short.MinValue + new short8(0, 1, 2, 3, 4, 5, 6, 7);
        //
        //            for (int j = 0; j < 32761; j++, divisorStart += 1)
        //            {
        //                result &= vdiv_short(dividendStart, divisorStart).Equals(new short8((short)(dividendStart.x0 / divisorStart.x0),
        //                                                                                    (short)(dividendStart.x1 / divisorStart.x1),
        //                                                                                    (short)(dividendStart.x2 / divisorStart.x2),
        //                                                                                    (short)(dividendStart.x3 / divisorStart.x3),
        //                                                                                    (short)(dividendStart.x4 / divisorStart.x4),
        //                                                                                    (short)(dividendStart.x5 / divisorStart.x5),
        //                                                                                    (short)(dividendStart.x6 / divisorStart.x6),
        //                                                                                    (short)(dividendStart.x7 / divisorStart.x7)));
        //            }
        //
        //            divisorStart = new short8(1, 2, 3, 4, 5, 6, 7, 8);
        //
        //            for (int j = 0; j < 32760; j++, divisorStart += 1)
        //            {
        //                result &= vdiv_short(dividendStart, divisorStart).Equals(new short8((short)(dividendStart.x0 / divisorStart.x0),
        //                                                                                    (short)(dividendStart.x1 / divisorStart.x1),
        //                                                                                    (short)(dividendStart.x2 / divisorStart.x2),
        //                                                                                    (short)(dividendStart.x3 / divisorStart.x3),
        //                                                                                    (short)(dividendStart.x4 / divisorStart.x4),
        //                                                                                    (short)(dividendStart.x5 / divisorStart.x5),
        //                                                                                    (short)(dividendStart.x6 / divisorStart.x6),
        //                                                                                    (short)(dividendStart.x7 / divisorStart.x7)));
        //            }
        //        }
        //
        //        r[0] = result;
        //    }
        //}


        private const int PRECISION_ADJUSTMENT_FACTOR = 0x4000_0002;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float8 vdiv_byte_quotient(int8 dividend, int8 divisor)
        {
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);

            if (Avx.IsAvxSupported)
            {
                float8 dividend_f32 = dividend;
                float8 divisor_f32 = divisor;

                float8 divisor_f32_rcp = Avx.mm256_rcp_ps(divisor_f32);


                float8 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.mm256_fnmadd_ps(divisor_f32_rcp, divisor_f32, new v256(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    precisionLossCompensation = maxmath.mad(-divisor_f32_rcp, divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));
                }

                precisionLossCompensation *= divisor_f32_rcp;
                precisionLossCompensation *= dividend_f32;

                return precisionLossCompensation;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vdiv_byte(byte8 dividend, byte8 divisor)
        {
            if (Avx.IsAvxSupported)
            {
                v256 ints = Avx.mm256_cvttps_epi32(vdiv_byte_quotient((int8)dividend, (int8)divisor));
                v128 shorts;

                if (Avx2.IsAvx2Supported)
                {
                    shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(ints), Avx2.mm256_extracti128_si256(ints, 1));
                }
                else
                {
                    shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(ints), Avx.mm256_extractf128_si256(ints, 1));
                }

                return Sse2.packus_epi16(shorts, shorts);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vdiv_sbyte(sbyte8 dividend, sbyte8 divisor, bool saturated = false)
        {
            if (Avx.IsAvxSupported)
            {
                if (saturated)
                {
                    v256 ints = Avx.mm256_cvttps_epi32(vdiv_byte_quotient((int8)dividend, (int8)divisor));
                    v128 shorts;

                    if (Avx2.IsAvx2Supported)
                    {
                        shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(ints), Avx2.mm256_extracti128_si256(ints, 1));
                    }
                    else
                    {
                        shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(ints), Avx.mm256_extractf128_si256(ints, 1));
                    }

                    return Sse2.packs_epi16(shorts, shorts);
                }
                else
                {
                    return (sbyte8)vdiv_byte_quotient((int8)dividend, (int8)divisor);
                }
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vrem_byte(byte8 dividend, byte8 divisor)
        {
            if (Avx.IsAvxSupported)
            {
                int8 castDividend = dividend;
                int8 castDivisor = divisor;

                v256 rem = castDividend - ((int8)vdiv_byte_quotient(castDividend, castDivisor) * castDivisor);
                v128 shorts;
                
                if (Avx2.IsAvx2Supported)
                {
                    shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(rem), Avx2.mm256_extracti128_si256(rem, 1));
                }
                else
                {
                    shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(rem), Avx.mm256_extractf128_si256(rem, 1));
                }

                return Sse2.packus_epi16(shorts, shorts);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vrem_sbyte(sbyte8 dividend, sbyte8 divisor)
        {
            if (Avx.IsAvxSupported)
            {
                int8 castDividend = dividend;
                int8 castDivisor = divisor;

                v256 rem = castDividend - ((int8)vdiv_byte_quotient(castDividend, castDivisor) * castDivisor);
                v128 shorts;
                
                if (Avx2.IsAvx2Supported)
                {
                    shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(rem), Avx2.mm256_extracti128_si256(rem, 1));
                }
                else
                {
                    shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(rem), Avx.mm256_extractf128_si256(rem, 1));
                }

                return Sse2.packs_epi16(shorts, shorts);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vdivrem_byte(byte8 dividend, byte8 divisor, out byte8 remainder)
        {
            if (Avx.IsAvxSupported)
            {
                int8 castDividend = dividend;
                int8 castDivisor = divisor;

                int8 quotientCast = (int8)vdiv_byte_quotient(castDividend, castDivisor);
                v256 remCast = castDividend - (quotientCast * castDivisor);

                v128 qShorts;
                v128 rShorts;
                
                if (Avx2.IsAvx2Supported)
                {
                    qShorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(quotientCast), Avx2.mm256_extracti128_si256(quotientCast, 1));
                    rShorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(remCast),      Avx2.mm256_extracti128_si256(remCast, 1));
                }
                else
                {
                    qShorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(quotientCast), Avx.mm256_extractf128_si256(quotientCast, 1));
                    rShorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(remCast),      Avx.mm256_extractf128_si256(remCast, 1));
                }

                remainder = Sse2.packus_epi16(rShorts, rShorts);
                return Sse2.packus_epi16(qShorts, qShorts);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vdivrem_sbyte(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            if (Avx.IsAvxSupported)
            {
                int8 castDividend = dividend;
                int8 castDivisor = divisor;

                int8 quotientCast = (int8)vdiv_byte_quotient(castDividend, castDivisor);
                v256 remCast = castDividend - (quotientCast * castDivisor);

                v128 rShorts;
                
                if (Avx2.IsAvx2Supported)
                {
                    rShorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(remCast),      Avx2.mm256_extracti128_si256(remCast, 1));
                }
                else
                {
                    rShorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(remCast),      Avx.mm256_extractf128_si256(remCast, 1));
                }

                remainder = Sse2.packs_epi16(rShorts, rShorts);
                return (sbyte8)quotientCast;
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_byte_quotient(int4 dividend, int4 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
                float4 dividend_f32 = dividend;
                float4 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float4 temp = math.mad(*(float4*)&divisor_f32_rcp, -divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));

                return precisionLossCompensation;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_byte_quotient(int3 dividend, int3 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
                float3 dividend_f32 = dividend;
                float3 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float3 temp = math.mad(*(float3*)&divisor_f32_rcp, -divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));

                return precisionLossCompensation;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_byte_quotient(int2 dividend, int2 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
                float2 dividend_f32 = dividend;
                float2 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float2 temp = math.mad(-(*(float2*)&divisor_f32_rcp), divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));

                return precisionLossCompensation;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte4 vdiv_byte(byte4 dividend, byte4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            v128 floatResult = vdiv_byte_quotient((int4)dividend, (int4)divisor);

            if (Ssse3.IsSsse3Supported)
            {
                return (byte4)(*(float4*)&floatResult);
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(floatResult);
                    v128 shorts = Sse2.packs_epi32(ints, ints);
                    return Sse2.packus_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte4 vdiv_sbyte(sbyte4 dividend, sbyte4 divisor, bool saturated = false)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            v128 floatResult = vdiv_byte_quotient((int4)dividend, (int4)divisor);

            if (saturated)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(floatResult);
                    v128 shorts = Sse2.packs_epi32(ints, ints);
                    return Sse2.packs_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
            else
            {
                return (sbyte4)(*(float4*)&floatResult);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte3 vdiv_byte(byte3 dividend, byte3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            v128 floatResult = vdiv_byte_quotient((int3)dividend, (int3)divisor);
            
            if (Ssse3.IsSsse3Supported)
            {
                return (byte3)(*(float3*)&floatResult);
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(floatResult);
                    v128 shorts = Sse2.packs_epi32(ints, ints);
                    return Sse2.packus_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte3 vdiv_sbyte(sbyte3 dividend, sbyte3 divisor, bool saturated = false)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            v128 floatResult = vdiv_byte_quotient((int3)dividend, (int3)divisor);
            
            if (saturated)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(floatResult);
                    v128 shorts = Sse2.packs_epi32(ints, ints);
                    return Sse2.packs_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
            else
            {
                return (sbyte3)(*(float3*)&floatResult);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte2 vdiv_byte(byte2 dividend, byte2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            v128 floatResult = vdiv_byte_quotient((int2)dividend, (int2)divisor);
            
            if (Ssse3.IsSsse3Supported)
            {
                return (byte2)(*(float2*)&floatResult);
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(floatResult);
                    v128 shorts = Sse2.packs_epi32(ints, ints);
                    return Sse2.packus_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte2 vdiv_sbyte(sbyte2 dividend, sbyte2 divisor, bool saturated = false)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            v128 floatResult = vdiv_byte_quotient((int2)dividend, (int2)divisor);
            
            if (saturated)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(floatResult);
                    v128 shorts = Sse2.packs_epi32(ints, ints);
                    return Sse2.packs_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
            else
            {
                return (sbyte2)(*(float2*)&floatResult);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte4 vrem_byte(byte4 dividend, byte4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            int4 castDividend = dividend;
            int4 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);

            int4 intRem = castDividend - ((int4)(*(float4*)&floatResult) * castDivisor);
            
            if (Ssse3.IsSsse3Supported)
            {
                return (byte4)intRem;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(intRem);

                    v128 shorts = Sse2.packs_epi32(_intRem, _intRem);
                    return Sse2.packus_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte4 vrem_sbyte(sbyte4 dividend, sbyte4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            int4 castDividend = dividend;
            int4 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            
            int4 intRem = castDividend - ((int4)(*(float4*)&floatResult) * castDivisor);
            
            if (Ssse3.IsSsse3Supported)
            {
                return (sbyte4)intRem;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(intRem);

                    v128 shorts = Sse2.packs_epi32(_intRem, _intRem);
                    return Sse2.packs_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte3 vrem_byte(byte3 dividend, byte3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            int3 castDividend = dividend;
            int3 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            
            int3 intRem = castDividend - ((int3)(*(float3*)&floatResult) * castDivisor);
            
            if (Ssse3.IsSsse3Supported)
            {
                return (byte3)intRem;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(intRem);

                    v128 shorts = Sse2.packs_epi32(_intRem, _intRem);
                    return Sse2.packus_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte3 vrem_sbyte(sbyte3 dividend, sbyte3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            int3 castDividend = dividend;
            int3 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            
            int3 intRem = castDividend - ((int3)(*(float3*)&floatResult) * castDivisor);
            
            if (Ssse3.IsSsse3Supported)
            {
                return (sbyte3)intRem;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(intRem);

                    v128 shorts = Sse2.packs_epi32(_intRem, _intRem);
                    return Sse2.packs_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte2 vrem_byte(byte2 dividend, byte2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            int2 castDividend = dividend;
            int2 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            
            int2 intRem = castDividend - ((int2)(*(float2*)&floatResult) * castDivisor);
            
            if (Ssse3.IsSsse3Supported)
            {
                return (byte2)intRem;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(intRem);

                    v128 shorts = Sse2.packs_epi32(_intRem, _intRem);
                    return Sse2.packus_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte2 vrem_sbyte(sbyte2 dividend, sbyte2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            int2 castDividend = dividend;
            int2 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            
            int2 intRem = castDividend - ((int2)(*(float2*)&floatResult) * castDivisor);
            
            if (Ssse3.IsSsse3Supported)
            {
                return (sbyte2)intRem;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(intRem);

                    v128 shorts = Sse2.packs_epi32(_intRem, _intRem);
                    return Sse2.packs_epi16(shorts, shorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte4 vdivrem_byte(byte4 dividend, byte4 divisor, out byte4 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            int4 castDividend = dividend;
            int4 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            int4 quotientCast = (int4)(*(float4*)&floatResult);
            int4 remCast = castDividend - quotientCast * castDivisor;
            
            if (Ssse3.IsSsse3Supported)
            {
                remainder = (byte4)remCast;
                return (byte4)quotientCast;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(remCast);
                    v128 _intQ = UnityMathematicsLink.Tov128(quotientCast);

                    v128 rShorts = Sse2.packs_epi32(_intRem, _intRem);
                    v128 qShorts = Sse2.packs_epi32(_intQ, _intQ);

                    remainder = Sse2.packus_epi16(rShorts, rShorts);
                    return Sse2.packus_epi16(qShorts, qShorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte4 vdivrem_sbyte(sbyte4 dividend, sbyte4 divisor, out sbyte4 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            int4 castDividend = dividend;
            int4 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            int4 quotientCast = (int4)(*(float4*)&floatResult);
            int4 remCast = castDividend - quotientCast * castDivisor;
            
            sbyte4 quotients = (sbyte4)quotientCast;

            if (Ssse3.IsSsse3Supported)
            {
                remainder = (sbyte4)remCast;
                return quotients;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(remCast);

                    v128 rShorts = Sse2.packs_epi32(_intRem, _intRem);

                    remainder = Sse2.packs_epi16(rShorts, rShorts);
                    return quotients;
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte3 vdivrem_byte(byte3 dividend, byte3 divisor, out byte3 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            int3 castDividend = dividend;
            int3 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            int3 quotientCast = (int3)(*(float3*)&floatResult);
            int3 remCast = castDividend - quotientCast * castDivisor;
            
            if (Ssse3.IsSsse3Supported)
            {
                remainder = (byte3)remCast;
                return (byte3)quotientCast;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(remCast);
                    v128 _intQ = UnityMathematicsLink.Tov128(quotientCast);

                    v128 rShorts = Sse2.packs_epi32(_intRem, _intRem);
                    v128 qShorts = Sse2.packs_epi32(_intQ, _intQ);

                    remainder = Sse2.packus_epi16(rShorts, rShorts);
                    return Sse2.packus_epi16(qShorts, qShorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte3 vdivrem_sbyte(sbyte3 dividend, sbyte3 divisor, out sbyte3 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            int3 castDividend = dividend;
            int3 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            int3 quotientCast = (int3)(*(float3*)&floatResult);
            int3 remCast = castDividend - quotientCast * castDivisor;
            
            sbyte3 quotients = (sbyte3)quotientCast;

            if (Ssse3.IsSsse3Supported)
            {
                remainder = (sbyte3)remCast;
                return quotients;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(remCast);

                    v128 rShorts = Sse2.packs_epi32(_intRem, _intRem);

                    remainder = Sse2.packs_epi16(rShorts, rShorts);
                    return quotients;
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte2 vdivrem_byte(byte2 dividend, byte2 divisor, out byte2 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            int2 castDividend = dividend;
            int2 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            int2 quotientCast = (int2)(*(float2*)&floatResult);
            int2 remCast = castDividend - quotientCast * castDivisor;
            
            if (Ssse3.IsSsse3Supported)
            {
                remainder = (byte2)remCast;
                return (byte2)quotientCast;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(remCast);
                    v128 _intQ = UnityMathematicsLink.Tov128(quotientCast);

                    v128 rShorts = Sse2.packs_epi32(_intRem, _intRem);
                    v128 qShorts = Sse2.packs_epi32(_intQ, _intQ);

                    remainder = Sse2.packus_epi16(rShorts, rShorts);
                    return Sse2.packus_epi16(qShorts, qShorts);
                }
                else throw new CPUFeatureCheckException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte2 vdivrem_sbyte(sbyte2 dividend, sbyte2 divisor, out sbyte2 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            int2 castDividend = dividend;
            int2 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            int2 quotientCast = (int2)(*(float2*)&floatResult);
            int2 remCast = castDividend - quotientCast * castDivisor;
            
            sbyte2 quotients = (sbyte2)quotientCast;

            if (Ssse3.IsSsse3Supported)
            {
                remainder = (sbyte2)remCast;
                return quotients;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 _intRem = UnityMathematicsLink.Tov128(remCast);

                    v128 rShorts = Sse2.packs_epi32(_intRem, _intRem);

                    remainder = Sse2.packs_epi16(rShorts, rShorts);
                    return quotients;
                }
                else throw new CPUFeatureCheckException();
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float8 vdiv_short_AVX(short8 dividend, short8 divisor)
        {
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);

            if (Avx.IsAvxSupported)
            {
                float8 dividend_f32 = dividend;
                float8 divisor_f32 = divisor;

                float8 divisor_f32_rcp = Avx.mm256_rcp_ps(divisor_f32);


                float8 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.mm256_fnmadd_ps(divisor_f32_rcp, divisor_f32, new v256(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    precisionLossCompensation = maxmath.mad(-divisor_f32_rcp, divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));
                }

                precisionLossCompensation *= divisor_f32_rcp;
                precisionLossCompensation *= dividend_f32;

                return precisionLossCompensation;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float8 vdiv_ushort_AVX(ushort8 dividend, ushort8 divisor)
        {
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);

            if (Avx.IsAvxSupported)
            {
                float8 dividend_f32 = dividend;
                float8 divisor_f32 = divisor;

                float8 divisor_f32_rcp = Avx.mm256_rcp_ps(divisor_f32);


                float8 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.mm256_fnmadd_ps(divisor_f32_rcp, divisor_f32, new v256(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    precisionLossCompensation = maxmath.mad(-divisor_f32_rcp, divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));
                }

                precisionLossCompensation *= divisor_f32_rcp;
                precisionLossCompensation *= dividend_f32;

                return precisionLossCompensation;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short2 vdiv_short(short2 dividend, short2 divisor, bool saturated = false)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            if (Sse2.IsSse2Supported)
            {
                float2 dividend_f32 = dividend;
                float2 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float2 temp = math.mad(-(*(float2*)&divisor_f32_rcp), divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));
                
                if (saturated)
                {
                    v128 ints = Sse2.cvttps_epi32(precisionLossCompensation);

                    return Sse2.packs_epi32(ints, ints);
                }
                else
                {
                    return (short2)(*(float2*)&precisionLossCompensation);
                }
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort2 vdiv_ushort(ushort2 dividend, ushort2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            if (Sse2.IsSse2Supported)
            {
                float2 dividend_f32 = dividend;
                float2 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float2 temp = math.mad(-(*(float2*)&divisor_f32_rcp), divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));

                if (Sse4_1.IsSse41Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(precisionLossCompensation);

                    return Sse4_1.packus_epi32(ints, ints);
                }
                else
                {
                    return (ushort2)(*(float2*)&precisionLossCompensation);
                }
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short3 vdiv_short(short3 dividend, short3 divisor, bool saturated = false)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            if (Sse2.IsSse2Supported)
            {
                float3 dividend_f32 = dividend;
                float3 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float3 temp = math.mad(*(float3*)&divisor_f32_rcp, -divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));
                
                if (saturated)
                {
                    v128 ints = Sse2.cvttps_epi32(precisionLossCompensation);

                    return Sse2.packs_epi32(ints, ints);
                }
                else
                {
                    return (short3)(*(float3*)&precisionLossCompensation);
                }
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort3 vdiv_ushort(ushort3 dividend, ushort3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            if (Sse2.IsSse2Supported)
            {
                float3 dividend_f32 = dividend;
                float3 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float3 temp = math.mad(*(float3*)&divisor_f32_rcp, -divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));
                
                if (Sse4_1.IsSse41Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(precisionLossCompensation);

                    return Sse4_1.packus_epi32(ints, ints);
                }
                else
                {
                    return (ushort3)(*(float3*)&precisionLossCompensation);
                }
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short4 vdiv_short(short4 dividend, short4 divisor, bool saturated = false)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            if (Sse2.IsSse2Supported)
            {
                float4 dividend_f32 = dividend;
                float4 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float4 temp = math.mad(*(float4*)&divisor_f32_rcp, -divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));

                if (saturated)
                {
                    v128 ints = Sse2.cvttps_epi32(precisionLossCompensation);

                    return Sse2.packs_epi32(ints, ints);
                }
                else
                {
                    return (short4)(*(float4*)&precisionLossCompensation);
                }
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort4 vdiv_ushort(ushort4 dividend, ushort4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            if (Sse2.IsSse2Supported)
            {
                float4 dividend_f32 = dividend;
                float4 divisor_f32 = divisor;

                v128 divisor_f32_rcp = Sse.rcp_ps(UnityMathematicsLink.Tov128(divisor_f32));


                v128 precisionLossCompensation;

                if (Avx2.IsAvx2Supported)
                {
                    precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, UnityMathematicsLink.Tov128(divisor_f32), new v128(PRECISION_ADJUSTMENT_FACTOR));
                }
                else
                {
                    float4 temp = math.mad(*(float4*)&divisor_f32_rcp, -divisor_f32, math.asfloat(PRECISION_ADJUSTMENT_FACTOR));

                    precisionLossCompensation = UnityMathematicsLink.Tov128(temp);
                }

                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
                precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, UnityMathematicsLink.Tov128(dividend_f32));
                
                if (Sse4_1.IsSse41Supported)
                {
                    v128 ints = Sse2.cvttps_epi32(precisionLossCompensation);

                    return Sse4_1.packus_epi32(ints, ints);
                }
                else
                {
                    return (ushort4)(*(float4*)&precisionLossCompensation);
                }
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short8 vdiv_short(short8 dividend, short8 divisor, bool saturated = false) 
        {
            if (saturated)
            {
                v256 ints = (int8)vdiv_short_AVX(dividend, divisor);

                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.packs_epi32(Avx.mm256_castsi256_si128(ints), Avx2.mm256_extracti128_si256(ints, 1));
                }
                else if (Avx.IsAvxSupported)
                {
                    return Sse2.packs_epi32(Avx.mm256_castsi256_si128(ints), Avx.mm256_extractf128_ps(ints, 1));
                }
                else throw new CPUFeatureCheckException();
            }
            else
            {
                return (short8)vdiv_short_AVX(dividend, divisor);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort8 vdiv_ushort(ushort8 dividend, ushort8 divisor)
        {
            v256 ints = (int8)vdiv_ushort_AVX(dividend, divisor);

            if (Avx2.IsAvx2Supported)
            {
                return Sse4_1.packus_epi32(Avx.mm256_castsi256_si128(ints), Avx2.mm256_extracti128_si256(ints, 1));
            }
            else if (Avx.IsAvxSupported)
            {
                return Sse4_1.packus_epi32(Avx.mm256_castsi256_si128(ints), Avx.mm256_extractf128_ps(ints, 1));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 vdiv_short(short16 dividend, short16 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                float8 lo = vdiv_short_AVX(dividend.v8_0, divisor.v8_0);
                float8 hi = vdiv_short_AVX(dividend.v8_8, divisor.v8_8);

                if (saturated)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi32((int8)lo, (int8)hi),
                                                        Sse.SHUFFLE(3, 1, 2, 0));
                }
                else
                {
                    return new v256(Cast.Int8ToShort8((int8)lo), Cast.Int8ToShort8((int8)hi));
                }
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort16 vdiv_ushort(ushort16 dividend, ushort16 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                float8 lo = vdiv_ushort_AVX(dividend.v8_0, divisor.v8_0);
                float8 hi = vdiv_ushort_AVX(dividend.v8_8, divisor.v8_8);

                return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi32((uint8)lo, (uint8)hi),
                                                    Sse.SHUFFLE(3, 1, 2, 0));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short2 vrem_short(short2 dividend, short2 divisor)
        {
            return dividend - (vdiv_short(dividend, divisor) * divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort2 vrem_ushort(ushort2 dividend, ushort2 divisor)
        {
            return dividend - (vdiv_ushort(dividend, divisor) * divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short3 vrem_short(short3 dividend, short3 divisor)
        {
            return dividend - (vdiv_short(dividend, divisor) * divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort3 vrem_ushort(ushort3 dividend, ushort3 divisor)
        {
            return dividend - (vdiv_ushort(dividend, divisor) * divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short4 vrem_short(short4 dividend, short4 divisor)
        {
            return dividend - (vdiv_short(dividend, divisor) * divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort4 vrem_ushort(ushort4 dividend, ushort4 divisor)
        {
            return dividend - (vdiv_ushort(dividend, divisor) * divisor);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short8 vrem_short(short8 dividend, short8 divisor) 
        {
            return dividend - (vdiv_short(dividend, divisor) * divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort8 vrem_ushort(ushort8 dividend, ushort8 divisor)
        {
            return dividend - (vdiv_ushort(dividend, divisor) * divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 vrem_short(short16 dividend, short16 divisor)
        {
            return dividend - (vdiv_short(dividend, divisor) * divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort16 vrem_ushort(ushort16 dividend, ushort16 divisor)
        {
            return dividend - (vdiv_ushort(dividend, divisor) * divisor);
        }
    }
}