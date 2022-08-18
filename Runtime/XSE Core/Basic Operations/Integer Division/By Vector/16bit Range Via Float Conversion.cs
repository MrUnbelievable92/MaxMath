using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
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
        //    public void Execute()
        //    {
        //        bool result = true;
        //
        //        ushort8 dividendStart = new ushort8(0, 1, 2, 3, 4, 5, 6, 7);
        //        
        //        for (int i = 1; i < ushort.MaxValue + 1; i += 8, dividendStart += 8)
        //        {
        //            ushort8 divisorStart = new ushort8(1, 2, 3, 4, 5, 6, 7, 8);
        //
        //            for (int j = 1; j < 65529; j += 8, divisorStart += 8)
        //            {
        //                result &= div_epu16(dividendStart, divisorStart).Equals(new ushort8((ushort)(dividendStart.x0 / divisorStart.x0),
        //                                                                                    (ushort)(dividendStart.x1 / divisorStart.x1),
        //                                                                                    (ushort)(dividendStart.x2 / divisorStart.x2),
        //                                                                                    (ushort)(dividendStart.x3 / divisorStart.x3),
        //                                                                                    (ushort)(dividendStart.x4 / divisorStart.x4),
        //                                                                                    (ushort)(dividendStart.x5 / divisorStart.x5),
        //                                                                                    (ushort)(dividendStart.x6 / divisorStart.x6),
        //                                                                                    (ushort)(dividendStart.x7 / divisorStart.x7)));
        //            }
        //
        //            for (int j = 65529; j <= ushort.MaxValue; j++)
        //            {
        //                divisorStart = new ushort8((ushort)j);
        //                
        //                result &= div_epu16(dividendStart, divisorStart).Equals(new ushort8((ushort)(dividendStart.x0 / divisorStart.x0),
        //                                                                                    (ushort)(dividendStart.x1 / divisorStart.x1),
        //                                                                                    (ushort)(dividendStart.x2 / divisorStart.x2),
        //                                                                                    (ushort)(dividendStart.x3 / divisorStart.x3),
        //                                                                                    (ushort)(dividendStart.x4 / divisorStart.x4),
        //                                                                                    (ushort)(dividendStart.x5 / divisorStart.x5),
        //                                                                                    (ushort)(dividendStart.x6 / divisorStart.x6),
        //                                                                                    (ushort)(dividendStart.x7 / divisorStart.x7)));
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
        //    public void Execute()
        //    {
        //        bool result = true;
        //
        //        short8 dividendStart = short.MinValue + new short8(0, 1, 2, 3, 4, 5, 6, 7);
        //
        //        for (int i = 1; i < ushort.MaxValue + 1; i += 8, dividendStart += 8)
        //        {
        //            short8 divisorStart = short.MinValue + new short8(0, 1, 2, 3, 4, 5, 6, 7);
        //
        //            for (int j = short.MinValue + 7; j < 0; j += 8, divisorStart += 8)
        //            {
        //                result &= div_epi16(dividendStart, divisorStart).Equals(new short8((short)(dividendStart.x0 / divisorStart.x0),
        //                                                                                   (short)(dividendStart.x1 / divisorStart.x1),
        //                                                                                   (short)(dividendStart.x2 / divisorStart.x2),
        //                                                                                   (short)(dividendStart.x3 / divisorStart.x3),
        //                                                                                   (short)(dividendStart.x4 / divisorStart.x4),
        //                                                                                   (short)(dividendStart.x5 / divisorStart.x5),
        //                                                                                   (short)(dividendStart.x6 / divisorStart.x6),
        //                                                                                   (short)(dividendStart.x7 / divisorStart.x7)));
        //            }
        //
        //            divisorStart = new short8(-8, -7, -6, -5, -4, -3, -2, -1);
        //
        //            result &= div_epi16(dividendStart, divisorStart).Equals(new short8((short)(dividendStart.x0 / divisorStart.x0),
        //                                                                               (short)(dividendStart.x1 / divisorStart.x1),
        //                                                                               (short)(dividendStart.x2 / divisorStart.x2),
        //                                                                               (short)(dividendStart.x3 / divisorStart.x3),
        //                                                                               (short)(dividendStart.x4 / divisorStart.x4),
        //                                                                               (short)(dividendStart.x5 / divisorStart.x5),
        //                                                                               (short)(dividendStart.x6 / divisorStart.x6),
        //                                                                               (short)(dividendStart.x7 / divisorStart.x7)));
        //
        //            divisorStart = new short8(1, 2, 3, 4, 5, 6, 7, 8);
        //
        //            for (int j = 1; j < short.MaxValue + 1; j += 8, divisorStart += 8)
        //            {
        //                result &= div_epi16(dividendStart, divisorStart).Equals(new short8((short)(dividendStart.x0 / divisorStart.x0),
        //                                                                                   (short)(dividendStart.x1 / divisorStart.x1),
        //                                                                                   (short)(dividendStart.x2 / divisorStart.x2),
        //                                                                                   (short)(dividendStart.x3 / divisorStart.x3),
        //                                                                                   (short)(dividendStart.x4 / divisorStart.x4),
        //                                                                                   (short)(dividendStart.x5 / divisorStart.x5),
        //                                                                                   (short)(dividendStart.x6 / divisorStart.x6),
        //                                                                                   (short)(dividendStart.x7 / divisorStart.x7)));
        //            }
        //        }
        //
        //        r[0] = result;
        //    }
        //}

        
        private const int PRECISION_ADJUSTMENT = 0x4000_0002;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DIV_FLOATV_USHORT_RANGE_RET_INT(v256 dividend_f32, v256 divisor_f32)
        {
            if (Avx.IsAvxSupported)
            {
                v256 divisor_f32_rcp = Avx.mm256_rcp_ps(divisor_f32);
                v256 rawQuotient = Avx.mm256_mul_ps(dividend_f32, divisor_f32_rcp);
                v256 precisionLossCompensation = mm256_fnmadd_ps(divisor_f32_rcp, divisor_f32, Avx.mm256_set1_epi32(PRECISION_ADJUSTMENT));

                return Avx.mm256_cvttps_epi32(Avx.mm256_mul_ps(precisionLossCompensation, rawQuotient));
            } 
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DIV_FLOATV_USHORT_RANGE_RET_INT(v128 dividend_f32, v128 divisor_f32)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 divisor_f32_rcp = Sse.rcp_ps(divisor_f32);
                v128 rawQuotient = Sse.mul_ps(dividend_f32, divisor_f32_rcp);
                v128 precisionLossCompensation = fnmadd_ps(divisor_f32_rcp, divisor_f32, Sse2.set1_epi32(PRECISION_ADJUSTMENT));

                return Sse2.cvttps_epi32(Sse.mul_ps(precisionLossCompensation, rawQuotient));
            }
            else throw new IllegalInstructionException();
        }
    }
}