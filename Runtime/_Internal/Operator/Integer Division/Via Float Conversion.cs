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
        //    public NativeArray<bool> r;
        //
        //    public void Execute()
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
        //    public NativeArray<bool> r;
        //
        //    public void Execute()
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


        private const float PRECISION_ADJUSTMENT_FACTOR = 2.00000051757f;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float8 vdiv_byte_quotient(uint8 dividend, uint8 divisor)
        {
Assert.AreNotEqual(divisor.x0, 0u);
Assert.AreNotEqual(divisor.x1, 0u);
Assert.AreNotEqual(divisor.x2, 0u);
Assert.AreNotEqual(divisor.x3, 0u);
Assert.AreNotEqual(divisor.x4, 0u);
Assert.AreNotEqual(divisor.x5, 0u);
Assert.AreNotEqual(divisor.x6, 0u);
Assert.AreNotEqual(divisor.x7, 0u);

            float8 dividend_f32 = dividend;
            float8 divisor_f32 = divisor;

            float8 divisor_f32_rcp = Avx.mm256_rcp_ps(divisor_f32);

            float8 precisionLossCompensation = Fma.mm256_fnmadd_ps(divisor_f32_rcp, divisor_f32, new float8(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation *= divisor_f32_rcp;
            precisionLossCompensation *= dividend_f32;

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float8 vdiv_sbyte_quotient(int8 dividend, int8 divisor)
        {
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);

            float8 dividend_f32 = dividend;
            float8 divisor_f32 = divisor;

            float8 divisor_f32_rcp = Avx.mm256_rcp_ps(divisor_f32);

            float8 precisionLossCompensation = Fma.mm256_fnmadd_ps(divisor_f32_rcp, divisor_f32, new float8(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation *= divisor_f32_rcp;
            precisionLossCompensation *= dividend_f32;

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vdiv_byte(byte8 dividend, byte8 divisor)
        {
            return (byte8)vdiv_byte_quotient((uint8)dividend, (uint8)divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vdiv_sbyte(sbyte8 dividend, sbyte8 divisor)
        {
            return (sbyte8)vdiv_sbyte_quotient((int8)dividend, (int8)divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vrem_byte(byte8 dividend, byte8 divisor)
        {
            uint8 castDividend = dividend;
            uint8 castDivisor = divisor;

            return (byte8)(castDividend - ((uint8)vdiv_byte_quotient(castDividend, castDivisor) * castDivisor));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vrem_sbyte(sbyte8 dividend, sbyte8 divisor)
        {
            int8 castDividend = dividend;
            int8 castDivisor = divisor;

            return (sbyte8)(castDividend - ((int8)vdiv_sbyte_quotient(castDividend, castDivisor) * castDivisor));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vdivrem_byte(byte8 dividend, byte8 divisor, out byte8 remainder)
        {
            uint8 castDividend = dividend;
            uint8 castDivisor = divisor;
            uint8 quotientCast = (uint8)vdiv_byte_quotient(castDividend, castDivisor);

            remainder = (byte8)(castDividend - quotientCast * castDivisor);
            return (byte8)quotientCast;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vdivrem_sbyte(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            int8 castDividend = dividend;
            int8 castDivisor = divisor;
            int8 quotientCast = (int8)vdiv_sbyte_quotient(castDividend, castDivisor);

            remainder = (sbyte8)(castDividend - quotientCast * castDivisor);
            return (sbyte8)quotientCast;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_byte_quotient(uint4 dividend, uint4 divisor)
        {
            float4 dividend_f32 = dividend;
            float4 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_byte_quotient(uint3 dividend, uint3 divisor)
        {
            float3 dividend_f32 = dividend;
            float3 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_byte_quotient(uint2 dividend, uint2 divisor)
        {
            float2 dividend_f32 = dividend;
            float2 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_sbyte_quotient(int4 dividend, int4 divisor)
        {
            float4 dividend_f32 = dividend;
            float4 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_sbyte_quotient(int3 dividend, int3 divisor)
        {
            float3 dividend_f32 = dividend;
            float3 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_sbyte_quotient(int2 dividend, int2 divisor)
        {
            float2 dividend_f32 = dividend;
            float2 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte4 vdiv_byte(byte4 dividend, byte4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            v128 floatResult = vdiv_byte_quotient(dividend, divisor);

            return (byte4)(*(float4*)&floatResult);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte4 vdiv_sbyte(sbyte4 dividend, sbyte4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            v128 floatResult = vdiv_sbyte_quotient(dividend, divisor);

            return (sbyte4)(*(float4*)&floatResult);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte3 vdiv_byte(byte3 dividend, byte3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            v128 floatResult = vdiv_byte_quotient(dividend, divisor);

            return (byte3)(*(float3*)&floatResult);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte3 vdiv_sbyte(sbyte3 dividend, sbyte3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            v128 floatResult = vdiv_sbyte_quotient(dividend, divisor);

            return (sbyte3)(*(float3*)&floatResult);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte2 vdiv_byte(byte2 dividend, byte2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            v128 floatResult = vdiv_byte_quotient(dividend, divisor);

            return (byte2)(*(float2*)&floatResult);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte2 vdiv_sbyte(sbyte2 dividend, sbyte2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            v128 floatResult = vdiv_sbyte_quotient(dividend, divisor);

            return (sbyte2)(*(float2*)&floatResult);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte4 vrem_byte(byte4 dividend, byte4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            uint4 castDividend = dividend;
            uint4 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);

            return (byte4)(castDividend - ((uint4)(*(float4*)&floatResult) * castDivisor));
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
            v128 floatResult = vdiv_sbyte_quotient(castDividend, castDivisor);

            return (sbyte4)(castDividend - ((int4)(*(float4*)&floatResult) * castDivisor));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte3 vrem_byte(byte3 dividend, byte3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            uint3 castDividend = dividend;
            uint3 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);

            return (byte3)(castDividend - ((uint3)(*(float3*)&floatResult) * castDivisor));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte3 vrem_sbyte(sbyte3 dividend, sbyte3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            int3 castDividend = dividend;
            int3 castDivisor = divisor;
            v128 floatResult = vdiv_sbyte_quotient(castDividend, castDivisor);

            return (sbyte3)(castDividend - ((int3)(*(float3*)&floatResult) * castDivisor));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte2 vrem_byte(byte2 dividend, byte2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            uint2 castDividend = dividend;
            uint2 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);

            return (byte2)(castDividend - ((uint2)(*(float2*)&floatResult) * castDivisor));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte2 vrem_sbyte(sbyte2 dividend, sbyte2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            int2 castDividend = dividend;
            int2 castDivisor = divisor;
            v128 floatResult = vdiv_sbyte_quotient(castDividend, castDivisor);

            return (sbyte2)(castDividend - ((int2)(*(float2*)&floatResult) * castDivisor));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte4 vdivrem_byte(byte4 dividend, byte4 divisor, out byte4 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            uint4 castDividend = dividend;
            uint4 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            uint4 quotientCast = (uint4)(*(float4*)&floatResult);

            remainder = (byte4)(castDividend - quotientCast * castDivisor);
            return (byte4)quotientCast;
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
            v128 floatResult = vdiv_sbyte_quotient(castDividend, castDivisor);
            int4 quotientCast = (int4)(*(float4*)&floatResult);

            remainder = (sbyte4)(castDividend - quotientCast * castDivisor);
            return (sbyte4)quotientCast;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte3 vdivrem_byte(byte3 dividend, byte3 divisor, out byte3 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            uint3 castDividend = dividend;
            uint3 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            uint3 quotientCast = (uint3)(*(float3*)&floatResult);

            remainder = (byte3)(castDividend - quotientCast * castDivisor);
            return (byte3)quotientCast;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte3 vdivrem_sbyte(sbyte3 dividend, sbyte3 divisor, out sbyte3 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            int3 castDividend = dividend;
            int3 castDivisor = divisor;
            v128 floatResult = vdiv_sbyte_quotient(castDividend, castDivisor);
            int3 quotientCast = (int3)(*(float3*)&floatResult);

            remainder = (sbyte3)(castDividend - quotientCast * castDivisor);
            return (sbyte3)quotientCast;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte2 vdivrem_byte(byte2 dividend, byte2 divisor, out byte2 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            uint2 castDividend = dividend;
            uint2 castDivisor = divisor;
            v128 floatResult = vdiv_byte_quotient(castDividend, castDivisor);
            uint2 quotientCast = (uint2)(*(float2*)&floatResult);

            remainder = (byte2)(castDividend - quotientCast * castDivisor);
            return (byte2)quotientCast;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte2 vdivrem_sbyte(sbyte2 dividend, sbyte2 divisor, out sbyte2 remainder)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            int2 castDividend = dividend;
            int2 castDivisor = divisor;
            v128 floatResult = vdiv_sbyte_quotient(castDividend, castDivisor);
            int2 quotientCast = (int2)(*(float2*)&floatResult);

            remainder = (sbyte2)(castDividend - quotientCast * castDivisor);
            return (sbyte2)quotientCast;
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

            float8 dividend_f32 = dividend;
            float8 divisor_f32 = divisor;

            float8 divisor_f32_rcp = Avx.mm256_rcp_ps(divisor_f32);

            float8 precisionLossCompensation = Fma.mm256_fnmadd_ps(divisor_f32_rcp, divisor_f32, new float8(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation *= divisor_f32_rcp;
            precisionLossCompensation *= dividend_f32;

            return precisionLossCompensation;
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

            float8 dividend_f32 = dividend;
            float8 divisor_f32 = divisor;

            float8 divisor_f32_rcp = Avx.mm256_rcp_ps(divisor_f32);

            float8 precisionLossCompensation = Fma.mm256_fnmadd_ps(divisor_f32_rcp, divisor_f32, new float8(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation *= divisor_f32_rcp;
            precisionLossCompensation *= dividend_f32;

            return precisionLossCompensation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short2 vdiv_short(short2 dividend, short2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            float2 dividend_f32 = dividend;
            float2 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return (short2)(*(float2*)&precisionLossCompensation);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort2 vdiv_ushort(ushort2 dividend, ushort2 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);

            float2 dividend_f32 = dividend;
            float2 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return (ushort2)(*(float2*)&precisionLossCompensation);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short3 vdiv_short(short3 dividend, short3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            float3 dividend_f32 = dividend;
            float3 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return (short3)(*(float3*)&precisionLossCompensation);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort3 vdiv_ushort(ushort3 dividend, ushort3 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);

            float3 dividend_f32 = dividend;
            float3 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return (ushort3)(*(float3*)&precisionLossCompensation);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short4 vdiv_short(short4 dividend, short4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            float4 dividend_f32 = dividend;
            float4 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return (short4)(*(float4*)&precisionLossCompensation);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort4 vdiv_ushort(ushort4 dividend, ushort4 divisor)
        {
Assert.AreNotEqual(divisor.x, 0);
Assert.AreNotEqual(divisor.y, 0);
Assert.AreNotEqual(divisor.z, 0);
Assert.AreNotEqual(divisor.w, 0);

            float4 dividend_f32 = dividend;
            float4 divisor_f32 = divisor;

            v128 divisor_f32_rcp = Sse.rcp_ps(*(v128*)&divisor_f32);

            v128 precisionLossCompensation = Fma.fnmadd_ps(divisor_f32_rcp, *(v128*)&divisor_f32, new v128(PRECISION_ADJUSTMENT_FACTOR));
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, divisor_f32_rcp);
            precisionLossCompensation = Sse.mul_ps(precisionLossCompensation, *(v128*)&dividend_f32);

            return (ushort4)(*(float4*)&precisionLossCompensation);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short8 vdiv_short(short8 dividend, short8 divisor) 
        {
            return (short8)vdiv_short_AVX(dividend, divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort8 vdiv_ushort(ushort8 dividend, ushort8 divisor)
        {
            return (ushort8)vdiv_ushort_AVX(dividend, divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 vdiv_short(short16 dividend, short16 divisor)
        {
            float8 lo = vdiv_short_AVX(dividend.v8_0, divisor.v8_0);
            float8 hi = vdiv_short_AVX(dividend.v8_8, divisor.v8_8);

            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi32((int8)lo, (int8)hi),
                                                Sse.SHUFFLE(3, 1, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort16 vdiv_ushort(ushort16 dividend, ushort16 divisor)
        {
            float8 lo = vdiv_ushort_AVX(dividend.v8_0, divisor.v8_0);
            float8 hi = vdiv_ushort_AVX(dividend.v8_8, divisor.v8_8);

            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi32((uint8)lo, (uint8)hi),
                                                Sse.SHUFFLE(3, 1, 2, 0));
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
