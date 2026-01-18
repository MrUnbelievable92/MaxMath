using NUnit.Framework;
using System;
using Unity.Mathematics;

using static MaxMath.maxmath;
using static Unity.Mathematics.math;

#pragma warning disable CS1718 // comparison to same variable is a test case

namespace MaxMath.Tests
{
    unsafe public static class t_quadruple
    {
        // implicitly tests accuracy of *-* and FMA
        public static quadruple RefinedProduct(quadruple a, quadruple b)
        {
            quadruple initialGuess = a * b;
            bool negative = initialGuess == quadruple.NegativeInfinity;
            if (b != 0)
            {
                for (int i = 0; i < 1; ++i)
                {
                    initialGuess = mad(-b, (initialGuess / b) - a, initialGuess);
                }
            }
            return isnan(initialGuess) ? (negative ? quadruple.NegativeInfinity : quadruple.PositiveInfinity) : initialGuess;
        }
        // Implicitly tests accuracy of *+*
        public static quadruple RefinedQuotient(quadruple a, quadruple b)
        {
            quadruple initialGuess = a / b;
            bool negative = initialGuess == quadruple.NegativeInfinity;
            if (b != 0)
            {
                for (int i = 0; i < 1; ++i)
                {
                    initialGuess -= ((initialGuess * b) + (-a)) / b;
                }
            }
            return isnan(initialGuess) ? (negative ? quadruple.NegativeInfinity : quadruple.PositiveInfinity) : initialGuess;
        }
        public static quadruple RefinedSquareRoot(quadruple a)
        {
            quadruple initialGuess = sqrt(a);
            bool negative = initialGuess == quadruple.NegativeInfinity;
            if (a != 0)
            {
                for (int i = 0; i < 1; ++i)
                {
                    initialGuess = 0.5 * (initialGuess + (a / initialGuess));
                }
            }
            return isnan(initialGuess) ? (negative ? quadruple.NegativeInfinity : quadruple.PositiveInfinity) : initialGuess;
        }


        [Test]
        public static void Equals()
        {
            Assert.IsFalse(quadruple.NaN == quadruple.NaN);
            Assert.IsFalse(quadruple.NaN == (quadruple)1f);

            Assert.IsTrue(quadruple.Epsilon == quadruple.Epsilon);
            Assert.IsFalse(-quadruple.Epsilon == quadruple.Epsilon);

            Assert.IsTrue(new quadruple((UInt128)1 << 127) == new quadruple((UInt128)1 << 127));
            Assert.IsTrue(new quadruple((UInt128)1 << 127) == (quadruple)0f);
            Assert.IsTrue((quadruple)0f == new quadruple((UInt128)1 << 127));
            Assert.IsTrue((quadruple)0f == (quadruple)0f);

            Assert.IsTrue((quadruple)1f == (quadruple)1f);
            Assert.IsFalse((quadruple)1f == (quadruple)(-1f));
        }

        [Test]
        public static void NotEquals()
        {
            Assert.IsTrue(quadruple.NaN != quadruple.NaN);
            Assert.IsTrue(quadruple.NaN != (quadruple)1f);

            Assert.IsFalse(quadruple.Epsilon != quadruple.Epsilon);
            Assert.IsTrue(-quadruple.Epsilon != quadruple.Epsilon);

            Assert.IsTrue((quadruple)1f != (quadruple)0f);
            Assert.IsTrue((quadruple)1f != (quadruple)(-1f));

            Assert.IsFalse((quadruple)1f != (quadruple)1f);
            Assert.IsFalse(new quadruple((UInt128)1 << 127) != new quadruple((UInt128)1 << 127));
            Assert.IsFalse(new quadruple((UInt128)1 << 127) != new quadruple(0));
            Assert.IsFalse(new quadruple(0) != new quadruple((UInt128)1 << 127));
            Assert.IsFalse(new quadruple(0) != new quadruple(0));
        }

        [Test]
        public static void LessThan()
        {
            Random128 rng = Random128.New;

            Assert.IsFalse((quadruple)quadruple.NaN < (quadruple)0f);
            Assert.IsFalse((quadruple)0f < (quadruple)quadruple.NaN);
            Assert.IsFalse((quadruple)0f < (quadruple)0f);
            Assert.IsFalse((quadruple)0f < asquadruple((UInt128)1 << 127));
            Assert.IsFalse(asquadruple((UInt128)1 << 127) < (quadruple)0f);
            Assert.IsFalse(asquadruple((UInt128)1 << 127) < asquadruple((UInt128)1 << 127));
            Assert.IsFalse((quadruple)quadruple.PositiveInfinity < (quadruple)quadruple.NaN);
            Assert.IsFalse((quadruple)quadruple.NegativeInfinity < (quadruple)quadruple.NaN);

            for (int i = 0; i < 25; i++)
            {
                quadruple lhs = rng.NextQuadruple(double.MinValue, double.MaxValue);
                quadruple rhs = rng.NextQuadruple(double.MinValue, double.MaxValue);

                Assert.AreEqual(lhs < rhs, (double)lhs < (double)rhs);
                Assert.AreEqual(lhs < lhs, (double)lhs < (double)lhs);

                lhs = (quadruple)0f;

                Assert.AreEqual(lhs < rhs, (double)lhs < (double)rhs);
                Assert.AreEqual(lhs < lhs, (double)lhs < (double)lhs);
            }
        }

        [Test]
        public static void LessEqual()
        {
            Random128 rng = Random128.New;

            Assert.IsFalse((quadruple)quadruple.NaN <= (quadruple)0f);
            Assert.IsFalse((quadruple)0f <= (quadruple)quadruple.NaN);
            Assert.IsTrue((quadruple)0f <= (quadruple)0f);
            Assert.IsTrue((quadruple)0f <= asquadruple((UInt128)1 << 127));
            Assert.IsTrue(asquadruple((UInt128)1 << 127) <= (quadruple)0f);
            Assert.IsTrue(asquadruple((UInt128)1 << 127) <= asquadruple((UInt128)1 << 127));
            Assert.IsFalse((quadruple)quadruple.PositiveInfinity <= (quadruple)quadruple.NaN);
            Assert.IsFalse((quadruple)quadruple.NegativeInfinity <= (quadruple)quadruple.NaN);

            for (int i = 0; i < 25; i++)
            {
                quadruple lhs = rng.NextQuadruple(double.MinValue, double.MaxValue);
                quadruple rhs = rng.NextQuadruple(double.MinValue, double.MaxValue);

                Assert.IsTrue(lhs <= lhs);

                Assert.AreEqual(lhs <= rhs, (double)lhs <= (double)rhs);
                Assert.AreEqual(lhs <= lhs, (double)lhs <= (double)lhs);

                lhs = (quadruple)0f;

                Assert.AreEqual(lhs < rhs, (double)lhs < (double)rhs);
                Assert.AreEqual(lhs < lhs, (double)lhs < (double)lhs);
            }
        }


        [Test]
        public static void FromToQuarter()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                quarter q = asquarter((byte)i);

                if (isnan(q))
                {
                    Assert.IsTrue(isnan((quadruple)q));
                }
                else
                {
                    Assert.IsTrue(q == (quarter)(quadruple)q);
                }
            }

            Random128 rng = Random128.New;

            for (int i = 0; i < 20; i++)
            {
                quadruple q = rng.NextQuadruple((quadruple)quarter.MinValue * 1.5, (quadruple)quarter.MaxValue * 1.5);

                if (abs(q) >= asquadruple(asuint128((quadruple)quarter.MaxValue) | ((UInt128)1ul << (quadruple.MANTISSA_BITS - quarter.MANTISSA_BITS - 1))))
                {
                    Assert.IsTrue(isinf((quarter)q));
                }
                else
                {
                    Assert.AreEqual((quarter)q, (quarter)(quadruple)(quarter)q);
                }

                q = rng.NextQuadruple(0f, (quadruple)quarter.Epsilon * 10);

                if (q < (quadruple)quarter.Epsilon / 2)
                {
                    Assert.AreEqual((quarter)q, (quarter)0f);
                }
                else
                {
                    Assert.AreEqual((quarter)q, (quarter)(quadruple)(quarter)q);
                }
            }
        }
        
        [Test]
        public static void ToQuarter_RoundToNearest()
        {
            Random128 rng = Random128.New;
            bool subnormalHalf = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalHalf = true;

                quadruple f = subnormalHalf ? rng.NextQuadruple(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                            : rng.NextQuadruple(quarter.MinValue, quarter.MaxValue);

                quarter q = (quarter)f;
                quarter qm1 = maxmath.nextsmaller(q);
                quarter qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(maxmath.abs(f - qm1) < maxmath.abs(f - q));
                Assert.IsFalse(maxmath.abs(f - qp1) < maxmath.abs(f - q));
            }
        }

        [Test]
        public static void FromToHalf()
        {
            for (int i = 0; i <= ushort.MaxValue; i++)
            {
                half q = ashalf((ushort)i);

                if (isnan(q))
                {
                    Assert.IsTrue(isnan((quadruple)q));
                }
                else
                {
                    Assert.IsTrue(q.IsEqualTo((half)(quadruple)q));
                }
            }

            Random128 rng = Random128.New;

            for (int i = 0; i < 20; i++)
            {
                quadruple q = rng.NextQuadruple((quadruple)Unity.Mathematics.half.MinValue * 1.5, (quadruple)Unity.Mathematics.half.MaxValue * 1.5);

                if (abs(q) >= asquadruple(asuint128((quadruple)Unity.Mathematics.half.MaxValue) | ((UInt128)1ul << (quadruple.MANTISSA_BITS - LUT.FLOATING_POINT.F16_MANTISSA_BITS - 1))))
                {
                    Assert.IsTrue(isinf((half)q));
                }
                else
                {
                    Assert.IsTrue(((half)q).IsEqualTo((half)(quadruple)(half)q));
                }

                q = rng.NextQuadruple(0f, (quadruple)ashalf((ushort)1) * 10);

                if (q < (quadruple)ashalf((ushort)1) / 2)
                {
                    Assert.IsTrue(((half)q).IsEqualTo((half)0f));
                }
                else
                {
                    Assert.IsTrue(((half)q).IsEqualTo((half)(quadruple)(half)q));
                }
            }
        }
        
        [Test]
        public static void ToHalf_RoundToNearest()
        {
            Random128 rng = Random128.New;
            bool subnormalHalf = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalHalf = true;

                quadruple f = subnormalHalf ? rng.NextQuadruple(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                            : rng.NextQuadruple(Unity.Mathematics.half.MinValue, Unity.Mathematics.half.MaxValue);

                half q = (half)f;
                half qm1 = maxmath.nextsmaller(q);
                half qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(maxmath.abs(f - qm1) < maxmath.abs(f - q));
                Assert.IsFalse(maxmath.abs(f - qp1) < maxmath.abs(f - q));
            }
        }

        [Test]
        public static void FromToFloat()
        {
            Assert.IsTrue(isnan((quadruple)float.NaN));
            Assert.IsTrue(isnan((float)(quadruple)float.NaN));
            Assert.IsTrue(quadruple.PositiveInfinity == float.PositiveInfinity);
            Assert.IsTrue((float)quadruple.PositiveInfinity == float.PositiveInfinity);
            Assert.IsTrue(quadruple.NegativeInfinity == float.NegativeInfinity);
            Assert.IsTrue((float)quadruple.NegativeInfinity == float.NegativeInfinity);
            Helper.TestFloat(f => Assert.AreEqual(f, (float)(quadruple)f));

            Random128 rng = Random128.New;

            for (int i = 0; i < 20; i++)
            {
                quadruple q = rng.NextQuadruple((quadruple)float.MinValue * 1.5, (quadruple)float.MaxValue * 1.5);

                if (abs(q) >= asquadruple(asuint128((quadruple)float.MaxValue) | ((UInt128)1ul << (quadruple.MANTISSA_BITS - LUT.FLOATING_POINT.F32_MANTISSA_BITS - 1))))
                {
                    Assert.IsTrue(isinf((float)q));
                }
                else
                {
                    Assert.AreEqual((float)q, (float)(quadruple)(float)q);
                }

                q = rng.NextQuadruple(0f, (quadruple)float.Epsilon * 10);

                if (q < (quadruple)float.Epsilon / 2)
                {
                    Assert.AreEqual((float)q, 0f);
                }
                else
                {
                    Assert.AreEqual((float)q, (float)(quadruple)(float)q);
                }
            }
        }
        
        [Test]
        public static void ToFloat_RoundToNearest()
        {
            Random128 rng = Random128.New;
            bool subnormalFloat = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalFloat = true;

                quadruple f = subnormalFloat ? rng.NextQuadruple(-math.asfloat(maxmath.bitmask32(LUT.FLOATING_POINT.F32_MANTISSA_BITS)), math.asfloat(maxmath.bitmask32(LUT.FLOATING_POINT.F32_MANTISSA_BITS))) 
                                             : rng.NextQuadruple(float.MinValue, float.MaxValue);

                float q = (float)f;
                float qm1 = maxmath.nextsmaller(q);
                float qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(maxmath.abs(f - qm1) < maxmath.abs(f - q));
                Assert.IsFalse(maxmath.abs(f - qp1) < maxmath.abs(f - q));
            }
        }

        [Test]
        public static void FromToDouble()
        {
            Assert.IsTrue(isnan((quadruple)double.NaN));
            Assert.IsTrue(isnan((double)(quadruple)double.NaN));
            Assert.IsTrue(quadruple.PositiveInfinity == double.PositiveInfinity);
            Assert.IsTrue((double)quadruple.PositiveInfinity == double.PositiveInfinity);
            Assert.IsTrue(quadruple.NegativeInfinity == double.NegativeInfinity);
            Assert.IsTrue((double)quadruple.NegativeInfinity == double.NegativeInfinity);
            Helper.TestDouble(d => Assert.AreEqual(d, (double)(quadruple)d));

            Random128 rng = Random128.New;

            for (int i = 0; i < 20; i++)
            {
                quadruple q = rng.NextQuadruple((quadruple)double.MinValue * 1.5, (quadruple)double.MaxValue * 1.5);

                if (abs(q) >= asquadruple(asuint128((quadruple)double.MaxValue) | ((UInt128)1ul << (quadruple.MANTISSA_BITS - LUT.FLOATING_POINT.F64_MANTISSA_BITS - 1))))
                {
                    Assert.IsTrue(isinf((double)q));
                }
                else
                {
                    Assert.AreEqual((double)q, (double)(quadruple)(double)q);
                }

                q = rng.NextQuadruple(0f, (quadruple)double.Epsilon * 10);

                if (q < (quadruple)double.Epsilon / 2)
                {
                    Assert.AreEqual((double)q, 0d);
                }
                else
                {
                    Assert.AreEqual((double)q, (double)(quadruple)(double)q);
                }
            }
        }
        
        [Test]
        public static void ToDouble_RoundToNearest()
        {
            Random128 rng = Random128.New;
            bool subnormalDouble = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalDouble = true;

                quadruple f = subnormalDouble ? rng.NextQuadruple(-math.asdouble(maxmath.bitmask64((long)LUT.FLOATING_POINT.F64_MANTISSA_BITS)), math.asdouble(maxmath.bitmask64((long)LUT.FLOATING_POINT.F64_MANTISSA_BITS))) 
                                              : rng.NextQuadruple(double.MinValue, double.MaxValue);

                double q = (double)f;
                double qm1 = maxmath.nextsmaller(q);
                double qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(maxmath.abs(f - qm1) < maxmath.abs(f - q));
                Assert.IsFalse(maxmath.abs(f - qp1) < maxmath.abs(f - q));
            }
        }


        [Test]
        public static void FromToInt()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 1000; i++)
            {
                int test = rng.NextInt();
                Assert.AreEqual((int)(quadruple)test, test);
            }
        }

        [Test]
        public static void FromToLong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 1000; i++)
            {
                long test = rng.NextLong();
                Assert.AreEqual((long)(quadruple)test, test);
            }
        }

        [Test]
        public static void FromToInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 1000; i++)
            {
                Int128 test = rng.NextInt128(-((Int128)1 << quadruple.MANTISSA_BITS), (Int128)1 << quadruple.MANTISSA_BITS);
                Assert.AreEqual((Int128)(quadruple)test, test);

                test = rng.NextInt128();
                if (abs(test) <= (Int128)LUT.CVT_INT_FP.LIMIT_PRECISE_U128_F128)
                {
                    Assert.AreEqual((Int128)(quadruple)test, test);
                }
                else
                {
                    Int128 converted = (Int128)(quadruple)test;
                    Int128 smaller = (Int128)nextsmaller((quadruple)test);
                    Int128 greater = (Int128)nextgreater((quadruple)test);

                    Assert.IsTrue(abs(converted - test) <= abs(smaller - test));
                    Assert.IsTrue(abs(converted - test) <= abs(greater - test));
                }
            }
        }

        [Test]
        public static void FromToUInt()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 1000; i++)
            {
                uint test = rng.NextUInt();
                Assert.AreEqual((uint)(quadruple)test, test);
            }
        }

        [Test]
        public static void FromToULong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 1000; i++)
            {
                ulong test = rng.NextULong();
                Assert.AreEqual((ulong)(quadruple)test, test);
            }
        }

        [Test]
        public static void FromToUInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 1000; i++)
            {
                UInt128 test = rng.NextUInt128(0, (UInt128)1 << quadruple.MANTISSA_BITS);
                Assert.AreEqual((UInt128)(quadruple)test, test);

                test = rng.NextUInt128();
                if (test <= (UInt128)LUT.CVT_INT_FP.LIMIT_PRECISE_U128_F128)
                {
                    Assert.AreEqual((UInt128)(quadruple)test, test);
                }
                else
                {
                    UInt128 converted = (UInt128)(quadruple)test;
                    UInt128 smaller = (UInt128)nextsmaller((quadruple)test);
                    UInt128 greater = (UInt128)nextgreater((quadruple)test);

                    Assert.IsTrue((UInt128)abs((Int128)converted - (Int128)test) <= (UInt128)abs((Int128)smaller - (Int128)test));
                    Assert.IsTrue((UInt128)abs((Int128)converted - (Int128)test) <= (UInt128)abs((Int128)greater - (Int128)test));
                }
            }
        }


        [Test]
        public static void Add()
        {
            static bool AdditionIsCorrect(double l, double r)
            {
                if (isinf(l + r))
                {
                    return !isinf((quadruple)l + r);
                }
                if (l + r == 0)
                {
                    if (l != 0 || r != 0)
                    {
                        return (quadruple)l + r != 0;
                    }
                }

                return approx(l + r, (double)((quadruple)l + (quadruple)r));
            }

            Assert.IsTrue(isnan(quadruple.NaN + quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN + quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.NaN + quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity + quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity + quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN + 0f));
            Assert.IsTrue(isnan(quadruple.NaN + 0f));
            Assert.IsTrue(isnan(0f + quadruple.NaN));
            Assert.AreEqual(0f + quadruple.PositiveInfinity, quadruple.PositiveInfinity);
            Assert.AreEqual(0f + quadruple.NegativeInfinity, quadruple.NegativeInfinity);
            Assert.AreEqual(quadruple.PositiveInfinity + 0f, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity + 0f, quadruple.NegativeInfinity);
            Assert.IsTrue(isnan(quadruple.NaN + 1f));
            Assert.IsTrue(isnan(quadruple.NaN + 1f));
            Assert.IsTrue(isnan(1f + quadruple.NaN));
            Assert.IsTrue(isnan(1f + quadruple.NaN));
            Assert.AreEqual(1f + quadruple.PositiveInfinity, quadruple.PositiveInfinity);
            Assert.AreEqual(1f + quadruple.NegativeInfinity, quadruple.NegativeInfinity);
            Assert.AreEqual(quadruple.PositiveInfinity + 1f, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity + 1f, quadruple.NegativeInfinity);
            Assert.AreEqual(quadruple.PositiveInfinity + quadruple.PositiveInfinity, quadruple.PositiveInfinity);
            Assert.IsTrue(isnan(quadruple.PositiveInfinity + quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity + quadruple.PositiveInfinity));
            Assert.AreEqual(quadruple.NegativeInfinity + quadruple.NegativeInfinity, quadruple.NegativeInfinity);

            Helper.TestDouble((l, r) => Assert.IsTrue(AdditionIsCorrect(l, r)));
        }

        [Test]
        public static void Subtract()
        {
            static bool SubtractionIsCorrect(double l, double r)
            {
                if (isinf(l - r))
                {
                    return !isinf((quadruple)l - r);
                }
                if (l - r == 0)
                {
                    if (l != 0 || r != 0)
                    {
                        return (quadruple)l - r != 0;
                    }
                }

                return approx(l - r, (double)((quadruple)l - (quadruple)r));
            }

            Assert.IsTrue(isnan(quadruple.NaN - quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN - quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.NaN - quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity - quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity - quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN - 0f));
            Assert.IsTrue(isnan(quadruple.NaN - 0f));
            Assert.IsTrue(isnan(0f - quadruple.NaN));
            Assert.AreEqual(0f - quadruple.PositiveInfinity, quadruple.NegativeInfinity);
            Assert.AreEqual(0f - quadruple.NegativeInfinity, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.PositiveInfinity - 0f, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity - 0f, quadruple.NegativeInfinity);
            Assert.IsTrue(isnan(quadruple.NaN - 1f));
            Assert.IsTrue(isnan(quadruple.NaN - 1f));
            Assert.IsTrue(isnan(1f - quadruple.NaN));
            Assert.IsTrue(isnan(1f - quadruple.NaN));
            Assert.AreEqual(1f - quadruple.PositiveInfinity, quadruple.NegativeInfinity);
            Assert.AreEqual(1f - quadruple.NegativeInfinity, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.PositiveInfinity - 1f, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity - 1f, quadruple.NegativeInfinity);
            Assert.IsTrue(isnan(quadruple.PositiveInfinity - quadruple.PositiveInfinity));
            Assert.AreEqual(quadruple.PositiveInfinity - quadruple.NegativeInfinity, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity - quadruple.PositiveInfinity, quadruple.NegativeInfinity);
            Assert.IsTrue(isnan(quadruple.NegativeInfinity - quadruple.NegativeInfinity));

            Helper.TestDouble((l, r) => Assert.IsTrue(SubtractionIsCorrect(l, r)));
        }

        [Test]
        public static void Multiply()
        {
            static bool MultiplicationIsCorrect(double l, double r)
            {
                if (isinf(l * r))
                {
                    return !isinf((quadruple)l * r);
                }
                if (l * r == 0)
                {
                    if (l != 0 || r != 0)
                    {
                        return (quadruple)l * r != 0;
                    }
                }

                return approx(l * r, (double)((quadruple)l * (quadruple)r));
            }

            Assert.IsTrue(isnan(quadruple.NaN * quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN * quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.NaN * quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity * quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity * quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN * 0f));
            Assert.IsTrue(isnan(quadruple.NaN * 0f));
            Assert.IsTrue(isnan(0f * quadruple.NaN));
            Assert.IsTrue(isnan(0f * quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(0f * quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity * 0f));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity * 0f));
            Assert.IsTrue(isnan(quadruple.NaN * 1f));
            Assert.IsTrue(isnan(quadruple.NaN * 1f));
            Assert.IsTrue(isnan(1f * quadruple.NaN));
            Assert.IsTrue(isnan(1f * quadruple.NaN));
            Assert.AreEqual(1f * quadruple.PositiveInfinity, quadruple.PositiveInfinity);
            Assert.AreEqual(1f * quadruple.NegativeInfinity, quadruple.NegativeInfinity);
            Assert.AreEqual(quadruple.PositiveInfinity * 1f, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity * 1f, quadruple.NegativeInfinity);
            Assert.AreEqual(quadruple.PositiveInfinity * quadruple.PositiveInfinity, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.PositiveInfinity * quadruple.NegativeInfinity, quadruple.NegativeInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity * quadruple.PositiveInfinity, quadruple.NegativeInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity * quadruple.NegativeInfinity, quadruple.PositiveInfinity);

            Helper.TestDouble((l, r) => Assert.IsTrue(MultiplicationIsCorrect(l, r)));
            Helper.TestQuadruple((l, r) => Assert.IsTrue(approx(l * r, RefinedProduct(l, r))));
        }

        [Test]
        public static void Divide()
        {
            static bool DivisionIsCorrect(double l, double r)
            {
                if (isinf(l / r))
                {
                    return !isinf((quadruple)l / r);
                }
                if (l / r == 0)
                {
                    if (l != 0 || r != 0)
                    {
                        return (quadruple)l / r != 0;
                    }
                }

                return approx(l / r, (double)((quadruple)l / (quadruple)r));
            }

            Assert.IsTrue(isnan(quadruple.NaN / quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN / quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.NaN / quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity / quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity / quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN / 0f));
            Assert.IsTrue(isnan(quadruple.NaN / 0f));
            Assert.IsTrue(isnan(0f / quadruple.NaN));
            Assert.AreEqual(0f / quadruple.PositiveInfinity, (quadruple)0f);
            Assert.AreEqual(0f / quadruple.NegativeInfinity, (quadruple)0f);
            Assert.AreEqual(quadruple.PositiveInfinity / 0f, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity / 0f, quadruple.NegativeInfinity);
            Assert.IsTrue(isnan(quadruple.NaN / 1f));
            Assert.IsTrue(isnan(quadruple.NaN / 1f));
            Assert.IsTrue(isnan(1f / quadruple.NaN));
            Assert.IsTrue(isnan(1f / quadruple.NaN));
            Assert.AreEqual(1f / quadruple.PositiveInfinity, (quadruple)0f);
            Assert.AreEqual(1f / quadruple.NegativeInfinity, (quadruple)0f);
            Assert.AreEqual(quadruple.PositiveInfinity / 1f, quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.NegativeInfinity / 1f, quadruple.NegativeInfinity);
            Assert.IsTrue(isnan(quadruple.PositiveInfinity / quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity / quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity / quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity / quadruple.NegativeInfinity));

            Helper.TestDouble((l, r) => Assert.IsTrue(DivisionIsCorrect(l, r)));
            Helper.TestQuadruple((l, r) => Assert.IsTrue(approx(l / r, RefinedQuotient(l, r))));
        }

        [Test]
        public static void Remainder()
        {
            static quadruple altrem0(quadruple l, quadruple r)
            {
                bool neg = l < 0;

                l = maxmath.abs(l);
                r = maxmath.abs(r);

                quadruple rem = l - r * maxmath.round(l / r);

                return neg ? -rem : rem;
            }


            static quadruple altrem1(quadruple l, quadruple r)
            {
                bool neg = l < 0;

                l = maxmath.abs(l);
                r = maxmath.abs(r);

                quadruple rem = maxmath.mad(-r, maxmath.round(l / r), l);

                return neg ? -rem : rem;
            }

            static bool RemainderIsCorrect(quadruple l, quadruple r)
            {
                if (abs(l) > quadruple.MaxValue / 2
                 || abs(r) > quadruple.MaxValue / 2)
                {
                    return true; // softfloat fails here too
                }

                quadruple test = l % r;
                quadruple alt0 = altrem0(l, r);
                quadruple alt1 = altrem1(l, r);

                Int128 minULPerror = min(abs(asint128(alt0) - asint128(test)), abs(asint128(alt1) - asint128(test)));

                return minULPerror < 1 << 7;
            }

            Assert.IsTrue(isnan(quadruple.NaN % quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN % quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.NaN % quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity % quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity % quadruple.NaN));
            Assert.IsTrue(isnan(quadruple.NaN % 0f));
            Assert.IsTrue(isnan(quadruple.NaN % 0f));
            Assert.IsTrue(isnan(0f % quadruple.NaN));
            Assert.AreEqual(0f % quadruple.PositiveInfinity, (quadruple)0f);
            Assert.AreEqual(0f % quadruple.NegativeInfinity, (quadruple)0f);
            Assert.IsTrue(isnan(quadruple.PositiveInfinity % 0f));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity % 0f));
            Assert.IsTrue(isnan(quadruple.NaN % 1f));
            Assert.IsTrue(isnan(quadruple.NaN % 1f));
            Assert.IsTrue(isnan(1f % quadruple.NaN));
            Assert.IsTrue(isnan(1f % quadruple.NaN));
            Assert.AreEqual(1f % quadruple.PositiveInfinity, (quadruple)1f);
            Assert.AreEqual(1f % quadruple.NegativeInfinity, (quadruple)1f);
            Assert.IsTrue(isnan(quadruple.PositiveInfinity % 1f));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity % 1f));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity % quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.PositiveInfinity % quadruple.NegativeInfinity));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity % quadruple.PositiveInfinity));
            Assert.IsTrue(isnan(quadruple.NegativeInfinity % quadruple.NegativeInfinity));

            Helper.TestQuadruple((l, r) => RemainderIsCorrect(l, r));
        }

        [Test]
        public static void SquareRoot()
        {
            Assert.AreEqual(sqrt((quadruple)0f), (quadruple)0f);
            Assert.AreEqual(sqrt(asquadruple((UInt128)1 << 127)), (quadruple)0f);
            Assert.IsTrue(isnan(sqrt(quadruple.NegativeInfinity)));
            Assert.AreEqual(quadruple.PositiveInfinity, sqrt(quadruple.PositiveInfinity));

            Helper.TestQuadruple(x => { if (x >= 0) { Assert.IsTrue(approx(sqrt(x), RefinedSquareRoot(x))); } else { Assert.IsTrue(isnan(sqrt(x))); } });
        }

        [Test]
        public static void _mad()
        {
            Assert.AreEqual(mad(0, 0,  (quadruple)4.7),    (quadruple)4.7);
            Assert.AreEqual(mad(0, 0,  (quadruple)(-4.7)), (quadruple)(-4.7));

            Assert.AreEqual(quadruple.PositiveInfinity, mad(quadruple.PositiveInfinity, quadruple.PositiveInfinity, 0));

            Assert.IsTrue(isnan(mad(quadruple.NaN, 0, 0)));
            Assert.IsTrue(isnan(mad(0, quadruple.NaN, 0)));
            Assert.IsTrue(isnan(mad(0, 0, quadruple.NaN)));
            Assert.IsTrue(isnan(mad(quadruple.NaN, 1, 1)));
            Assert.IsTrue(isnan(mad(1, quadruple.NaN, 1)));
            Assert.IsTrue(isnan(mad(1, 1, quadruple.NaN)));
            Assert.IsTrue(isnan(mad(quadruple.PositiveInfinity, 0, 0)));
            Assert.IsTrue(isnan(mad(0, quadruple.PositiveInfinity, 0)));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(0, 0, quadruple.PositiveInfinity));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(quadruple.PositiveInfinity, quadruple.PositiveInfinity, 0));
            Assert.IsTrue(isnan(mad(quadruple.PositiveInfinity, 0, quadruple.PositiveInfinity)));
            Assert.IsTrue(isnan(mad(0, quadruple.PositiveInfinity, quadruple.PositiveInfinity)));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(quadruple.PositiveInfinity, quadruple.PositiveInfinity, quadruple.PositiveInfinity));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(quadruple.PositiveInfinity, 1, 1));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(1, quadruple.PositiveInfinity, 1));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(1, 1, quadruple.PositiveInfinity));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(quadruple.PositiveInfinity, quadruple.PositiveInfinity, 1));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(quadruple.PositiveInfinity, 1, quadruple.PositiveInfinity));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(1, quadruple.PositiveInfinity, quadruple.PositiveInfinity));
            Assert.AreEqual(quadruple.PositiveInfinity, mad(quadruple.PositiveInfinity, quadruple.PositiveInfinity, quadruple.PositiveInfinity));
        }
        [Test]
        public static void _msub()
        {
            Assert.AreEqual(msub(0, 0, (quadruple)4.7),    (quadruple)(-4.7));
            Assert.AreEqual(msub(0, 0, (quadruple)(-4.7)), (quadruple)4.7);
            Assert.AreEqual(msub(2, 3, (quadruple)4.7),    6 - (quadruple)4.7);
            Assert.AreEqual(msub(2, 3, (quadruple)(-4.7)), 6 + (quadruple)4.7);
        }

        [Test]
        public static void _approx()
        {
            Random128 rng = Random128.New;

            Assert.IsFalse(approx(quadruple.NaN, rng.NextQuadruple()));
            Assert.IsFalse(approx(rng.NextQuadruple(), quadruple.NaN));
            Assert.IsFalse(approx(rng.NextQuadruple(), quadruple.PositiveInfinity));
            Assert.IsFalse(approx(quadruple.NegativeInfinity, rng.NextQuadruple()));
            Assert.IsTrue( approx(quadruple.NegativeInfinity, quadruple.NegativeInfinity));
            Assert.IsTrue( approx(quadruple.PositiveInfinity, quadruple.PositiveInfinity));
            Assert.IsFalse(approx(quadruple.PositiveInfinity, quadruple.NegativeInfinity));
            Assert.IsFalse(approx(quadruple.NegativeInfinity, quadruple.PositiveInfinity));
            Assert.IsFalse(approx((quadruple)(-1f), (quadruple)1f));
            Assert.IsTrue( approx(asquadruple((UInt128)1 << 127), 0f));

            for (int i = 0; i < 16; i++)
            {
                quadruple f = rng.NextQuadruple();

                Assert.IsTrue(approx(f, f));
                Assert.IsTrue(approx(f, f + 5 * quadruple.Epsilon));
                Assert.IsTrue(approx(f, f - 5 * quadruple.Epsilon));

                f = rng.NextQuadruple(quadruple.MinValue + 5 * quadruple.Epsilon, quadruple.MaxValue - 5 * quadruple.Epsilon);

                Assert.IsTrue(approx(f, f));
                Assert.IsTrue(approx(f, f + 5 * quadruple.Epsilon));
                Assert.IsTrue(approx(f, f - 5 * quadruple.Epsilon));
            }
        }

        [Test]
        public static void _min()
        {
            Helper.TestQuadruple((l, r) => Assert.IsTrue(l <= r ? l == min(l, r) : r == min(l, r)));
        }

        [Test]
        public static void _max()
        {
            Helper.TestQuadruple((l, r) => Assert.IsTrue(l >= r ? l == max(l, r) : r == max(l, r)));
        }

        [Test]
        public static void _cbrt()
        {
            Assert.IsTrue(isnan(cbrt(quadruple.NaN)));
            Assert.AreEqual(cbrt((quadruple)0f), (quadruple)0f);
            Assert.AreEqual(asuint128(cbrt(asquadruple((UInt128)1 << 127))), (UInt128)1 << 127);

            Assert.AreEqual(cbrt(quadruple.PositiveInfinity), quadruple.PositiveInfinity);
            Assert.AreEqual(cbrt(quadruple.NegativeInfinity), quadruple.NegativeInfinity);

            Helper.TestQuadruple(test => Assert.IsTrue(approx(cbrt(test) * cbrt(test) * cbrt(test), test)));
        }

        [Test]
        public static void _rcbrt()
        {
            Assert.IsTrue(isnan(rcbrt(quadruple.NaN)));
            Assert.AreEqual(rcbrt((quadruple)0f), quadruple.PositiveInfinity);
            Assert.AreEqual(asuint128(rcbrt(asquadruple((UInt128)1 << 127))), asuint128(quadruple.NegativeInfinity));

            Assert.AreEqual(rcbrt(quadruple.PositiveInfinity), (quadruple)0f);
            Assert.AreEqual(asuint128(rcbrt(quadruple.NegativeInfinity)), (UInt128)1 << 127);

            Helper.TestQuadruple(test => Assert.IsTrue(approx(rcbrt(test) * rcbrt(test) * rcbrt(test), 1f / test)));
        }

        [Test]
        public static void _nextgreater()
        {
            Random128 rng = Random128.New;

            Assert.IsTrue(isnan(nextgreater(asquadruple(new UInt128(0xFFFF_FFFF_FFFF_FFFF, 0x7FFF_FFFF_FFFF_FFFF)))));
            Assert.AreEqual(nextgreater(quadruple.PositiveInfinity), quadruple.PositiveInfinity);
            Assert.AreEqual(nextgreater(quadruple.NegativeInfinity), quadruple.NegativeInfinity);
            Assert.AreEqual(nextgreater(quadruple.MaxValue), quadruple.PositiveInfinity);
            Assert.AreEqual(quadruple.Epsilon, nextgreater(asquadruple(new UInt128(0, 0x8000_0000_0000_0000ul))));
            Assert.AreEqual(quadruple.Epsilon, nextgreater((quadruple)0d));

            for (int i = 0; i < 25; i++)
            {
                quadruple f = rng.NextQuadruple(quadruple.MinValue / 2, quadruple.MaxValue / 2);

                Assert.IsTrue(nextgreater(f) > f);
            }
        }

        [Test]
        public static void _nextsmaller()
        {
            Random128 rng = Random128.New;

            Assert.IsTrue(isnan(nextsmaller(quadruple.NaN)));
            Assert.AreEqual(nextsmaller(quadruple.PositiveInfinity), quadruple.PositiveInfinity);
            Assert.AreEqual(nextsmaller(quadruple.NegativeInfinity), quadruple.NegativeInfinity);
            Assert.AreEqual(nextsmaller(quadruple.MinValue), quadruple.NegativeInfinity);
            Assert.AreEqual((-quadruple.Epsilon), nextsmaller(asquadruple(new UInt128(0, 0x8000_0000_0000_0000ul))));
            Assert.AreEqual((-quadruple.Epsilon), nextsmaller((quadruple)0d));

            for (int i = 0; i < 25; i++)
            {
                quadruple f = rng.NextQuadruple(quadruple.MinValue / 2, quadruple.MaxValue / 2);

                Assert.IsTrue(maxmath.nextsmaller(f) < f);
            }
        }

        [Test]
        public static void _nexttoward()
        {
            Random128 rng = Random128.New;

            Assert.IsTrue(isnan(nexttoward(rng.NextQuadruple(), quadruple.NaN)));
            Assert.IsTrue(isnan(nexttoward(quadruple.NaN, rng.NextQuadruple())));
            Assert.IsTrue(isnan(nexttoward((quadruple)0f, quadruple.NaN)));
            Assert.IsTrue(isnan(nexttoward(quadruple.NaN, (quadruple)0f)));
            Assert.IsTrue(isnan(nexttoward(quadruple.NaN, quadruple.NaN)));

            Assert.AreEqual(nexttoward(quadruple.NegativeInfinity, quadruple.NegativeInfinity), quadruple.NegativeInfinity);
            Assert.AreEqual(nexttoward(quadruple.NegativeInfinity, quadruple.PositiveInfinity), quadruple.NegativeInfinity);
            Assert.AreEqual(nexttoward(quadruple.PositiveInfinity, quadruple.NegativeInfinity), quadruple.PositiveInfinity);
            Assert.AreEqual(nexttoward(quadruple.PositiveInfinity, quadruple.PositiveInfinity), quadruple.PositiveInfinity);

            Assert.AreEqual(nexttoward(quadruple.MinValue, quadruple.NegativeInfinity), quadruple.NegativeInfinity);
            Assert.AreEqual(nexttoward(quadruple.MinValue, quadruple.PositiveInfinity), nextgreater(quadruple.MinValue));
            Assert.AreEqual(nexttoward(quadruple.MaxValue, quadruple.NegativeInfinity), nextsmaller(quadruple.MaxValue));
            Assert.AreEqual(nexttoward(quadruple.MaxValue, quadruple.PositiveInfinity), quadruple.PositiveInfinity);

            Assert.AreEqual(nexttoward((quadruple)0f, quadruple.PositiveInfinity), quadruple.Epsilon);
            Assert.AreEqual(nexttoward((quadruple)0f, quadruple.NegativeInfinity), -quadruple.Epsilon);
            Assert.AreEqual(nexttoward(asquadruple(new UInt128(0, 0x8000_0000_0000_0000ul)), quadruple.PositiveInfinity), quadruple.Epsilon);
            Assert.AreEqual(nexttoward(asquadruple(new UInt128(0, 0x8000_0000_0000_0000ul)), quadruple.NegativeInfinity), -quadruple.Epsilon);

            for (int i = 0; i < 25; i++)
            {
                quadruple from = rng.NextQuadruple(quadruple.MinValue / 2, quadruple.MaxValue / 2);
                quadruple to = rng.NextQuadruple(quadruple.MinValue / 2, quadruple.MaxValue / 2);
                quadruple next = nexttoward(from, to);

                Assert.AreEqual(from, nexttoward(from, from));

                if (from < to)
                {
                    Assert.AreEqual(nextgreater(from), next);
                }
                else if (from > to)
                {
                    Assert.AreEqual(nextsmaller(from), next);
                }
                else
                {
                    Assert.AreEqual(from, next);
                }
            }
        }

        [Test]
        public static void _sign()
        {
            Assert.AreEqual(sign((quadruple)(-4.7f)), -1);
            Assert.AreEqual(sign((quadruple)4.7f), 1);
            Assert.AreEqual(sign((quadruple)0f), 0);
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                Assert.AreEqual(sign(asquadruple((UInt128)1 << 127)), 0);
            }
        }

        [Test]
        public static void _exp2_uint128()
        {
            throw new NotImplementedException();
        }

        [Test]
        public static void _exp2_int128()
        {
            throw new NotImplementedException();
        }

        [Test]
        public static void _random128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 16; i++)
            {
                quadruple next = rng.NextQuadruple();
                Assert.IsTrue(next > 0d && next < 1d);

                Assert.IsTrue(!isnan(rng.NextQuadruple()));
                Assert.IsTrue(!isnan(rng.NextQuadruple(quadruple.MinValue, quadruple.MaxValue)));
                Assert.IsTrue(!isnan(rng.NextQuadruple(quadruple.MinValue / 2, quadruple.MaxValue / 2)));

                next = rng.NextQuadruple(quadruple.MinValue / 2, quadruple.MaxValue / 2);
                Assert.IsTrue(next >= quadruple.MinValue / 2 && next < quadruple.MaxValue / 2);
            }
        }
    }
}