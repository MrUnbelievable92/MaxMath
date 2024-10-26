using DevTools;
using System;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class Helper
    {
        internal const ulong MAX_MONO_RUNTIME_CVT_DOUBLE_LONG = 0x7FFF_FFFF_FFFF_FE00;
        
        private static float NEXT_AFTER_MAX_SUBNORMAL_F32 => math.asfloat(1 << 23);
        private static double NEXT_AFTER_MAX_SUBNORMAL_F64 => math.asdouble(1ul << 52);
        private static quadruple NEXT_AFTER_MAX_SUBNORMAL_F128 => maxmath.asquadruple((UInt128)1 << 112);

        private static (float, float)[] ALL_RANGES_F32 => new (float, float)[]
        {
            (NEXT_AFTER_MAX_SUBNORMAL_F32, float.MaxValue),
            (float.MinValue, -NEXT_AFTER_MAX_SUBNORMAL_F32),
            (int.MinValue, int.MaxValue),
            (NEXT_AFTER_MAX_SUBNORMAL_F32, 0.001f),
            (-0.001f, -NEXT_AFTER_MAX_SUBNORMAL_F32),
            (0f, NEXT_AFTER_MAX_SUBNORMAL_F32),
            (-NEXT_AFTER_MAX_SUBNORMAL_F32, 0f),
        };
        private static (double, double)[] ALL_RANGES_F64 => new (double, double)[]
        {
            (NEXT_AFTER_MAX_SUBNORMAL_F64, double.MaxValue),
            (double.MinValue, -NEXT_AFTER_MAX_SUBNORMAL_F64),
            (int.MinValue, int.MaxValue),
            (NEXT_AFTER_MAX_SUBNORMAL_F64, 0.001f),
            (-0.001f, -NEXT_AFTER_MAX_SUBNORMAL_F64),
            (0f, NEXT_AFTER_MAX_SUBNORMAL_F64),
            (-NEXT_AFTER_MAX_SUBNORMAL_F64, 0f),
        };
        private static (quadruple, quadruple)[] ALL_RANGES_F128 => new (quadruple, quadruple)[]
        {
            (NEXT_AFTER_MAX_SUBNORMAL_F128, quadruple.MaxValue),
            (quadruple.MinValue, -NEXT_AFTER_MAX_SUBNORMAL_F128),
            (int.MinValue, int.MaxValue),
            (NEXT_AFTER_MAX_SUBNORMAL_F128, 0.001f),
            (-0.001f, -NEXT_AFTER_MAX_SUBNORMAL_F128),
            (0f, NEXT_AFTER_MAX_SUBNORMAL_F128),
            (-NEXT_AFTER_MAX_SUBNORMAL_F128, 0f),
        };

        public static void TestFloat(Action<float> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) range in ALL_RANGES_F32)
                {
                    float test = rng.NextFloat(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }

        public static void TestFloat2(Action<float2> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) range in ALL_RANGES_F32)
                {
                    float2 test = rng.NextFloat2(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }

        public static void TestFloat3(Action<float3> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) range in ALL_RANGES_F32)
                {
                    float3 test = rng.NextFloat3(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }

        public static void TestFloat4(Action<float4> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) range in ALL_RANGES_F32)
                {
                    float4 test = rng.NextFloat4(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }

        public static void TestFloat8(Action<float8> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) range in ALL_RANGES_F32)
                {
                    float8 test = rng.NextFloat8(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }
        
        public static void TestDouble(Action<double> assert)
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((double, double) range in ALL_RANGES_F64)
                {
                    double test = rng.NextDouble(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }

        public static void TestDouble2(Action<double2> assert)
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((double, double) range in ALL_RANGES_F64)
                {
                    double2 test = rng.NextDouble2(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }

        public static void TestDouble3(Action<double3> assert)
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((double, double) range in ALL_RANGES_F64)
                {
                    double3 test = rng.NextDouble3(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }

        public static void TestDouble4(Action<double4> assert)
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((double, double) range in ALL_RANGES_F64)
                {
                    double4 test = rng.NextDouble4(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }
        
        public static void TestQuadruple(Action<quadruple> assert)
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((quadruple, quadruple) range in ALL_RANGES_F128)
                {
                    quadruple test = rng.NextQuadruple(range.Item1, range.Item2);
                    assert(test);
                }
            }
        }
        public static void TestFloat(Action<float, float> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) rangeL in ALL_RANGES_F32)
                {
                    float testL = rng.NextFloat(rangeL.Item1, rangeL.Item2);

                    foreach ((float, float) rangeR in ALL_RANGES_F32)
                    {
                        float testR = rng.NextFloat(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }

        public static void TestFloat2(Action<float2, float2> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) rangeL in ALL_RANGES_F32)
                {
                    float2 testL = rng.NextFloat2(rangeL.Item1, rangeL.Item2);

                    foreach ((float, float) rangeR in ALL_RANGES_F32)
                    {
                        float2 testR = rng.NextFloat2(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }

        public static void TestFloat3(Action<float3, float3> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) rangeL in ALL_RANGES_F32)
                {
                    float3 testL = rng.NextFloat3(rangeL.Item1, rangeL.Item2);

                    foreach ((float, float) rangeR in ALL_RANGES_F32)
                    {
                        float3 testR = rng.NextFloat3(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }

        public static void TestFloat4(Action<float4, float4> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) rangeL in ALL_RANGES_F32)
                {
                    float4 testL = rng.NextFloat4(rangeL.Item1, rangeL.Item2);

                    foreach ((float, float) rangeR in ALL_RANGES_F32)
                    {
                        float4 testR = rng.NextFloat4(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }

        public static void TestFloat8(Action<float8, float8> assert)
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((float, float) rangeL in ALL_RANGES_F32)
                {
                    float8 testL = rng.NextFloat8(rangeL.Item1, rangeL.Item2);

                    foreach ((float, float) rangeR in ALL_RANGES_F32)
                    {
                        float8 testR = rng.NextFloat8(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }
        
        public static void TestDouble(Action<double, double> assert)
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((double, double) rangeL in ALL_RANGES_F64)
                {
                    double testL = rng.NextDouble(rangeL.Item1, rangeL.Item2);

                    foreach ((double, double) rangeR in ALL_RANGES_F64)
                    {
                        double testR = rng.NextDouble(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }

        public static void TestDouble2(Action<double2, double2> assert)
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((double, double) rangeL in ALL_RANGES_F64)
                {
                    double2 testL = rng.NextDouble2(rangeL.Item1, rangeL.Item2);

                    foreach ((double, double) rangeR in ALL_RANGES_F64)
                    {
                        double2 testR = rng.NextDouble2(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }

        public static void TestDouble3(Action<double3, double3> assert)
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((double, double) rangeL in ALL_RANGES_F64)
                {
                    double3 testL = rng.NextDouble3(rangeL.Item1, rangeL.Item2);

                    foreach ((double, double) rangeR in ALL_RANGES_F64)
                    {
                        double3 testR = rng.NextDouble3(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }

        public static void TestDouble4(Action<double4, double4> assert)
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((double, double) rangeL in ALL_RANGES_F64)
                {
                    double4 testL = rng.NextDouble4(rangeL.Item1, rangeL.Item2);

                    foreach ((double, double) rangeR in ALL_RANGES_F64)
                    {
                        double4 testR = rng.NextDouble4(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }

        public static void TestQuadruple(Action<quadruple, quadruple> assert)
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                foreach ((quadruple, quadruple) rangeL in ALL_RANGES_F128)
                {
                    quadruple testL = rng.NextQuadruple(rangeL.Item1, rangeL.Item2);

                    foreach ((quadruple, quadruple) rangeR in ALL_RANGES_F128)
                    {
                        quadruple testR = rng.NextQuadruple(rangeR.Item1, rangeR.Item2);
                        assert(testL, testR);
                    }
                }
            }
        }
    }
}
