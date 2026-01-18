using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics;

#pragma warning disable CS1718 // comparison to same variable is a test case

namespace MaxMath.Tests
{
    unsafe public static class t_quarter
    {
        private static bool IsZero(quarter value)
        {
            return value.value == 0 || value.value == (1 << 7);
        }

        private static float Exponent(quarter value)
        {
            return math.clamp(((byte)(value.value << 1) >> 5) - 3, -2, 3);
        }

        private static float Mantissa(quarter value)
        {
            Dictionary<byte, float> map = new Dictionary<byte, float>();

            map.Add(0b0000_0000, 0f);

            map.Add(0b0000_0001, 1f/16f);
            map.Add(0b0000_0010, 1f/8f);
            map.Add(0b0000_0100, 1f/4f);
            map.Add(0b0000_1000, 1f/2f);


            map.TryGetValue((byte)(value.value & (1 << 0)), out float _1over16);
            map.TryGetValue((byte)(value.value & (1 << 1)), out float _1over8);
            map.TryGetValue((byte)(value.value & (1 << 2)), out float _1over4);
            map.TryGetValue((byte)(value.value & (1 << 3)), out float _1over2);

            return _1over16 + _1over8 + _1over4 + _1over2;
        }

        private static bool IsDenormalOrZero(quarter value)
        {
            return (value.value & 0b0111_0000) == 0;
        }

        private static bool IsPositive(quarter value)
        {
            return (value.value & 0b1000_0000) == 0;
        }

        [Test]
        public static void Equals()
        {
            Assert.IsFalse(quarter.NaN == quarter.NaN);
            Assert.IsFalse(quarter.NaN == (quarter)1f);

            Assert.IsTrue(maxmath.asquarter(1 << 7) == maxmath.asquarter(1 << 7));
            Assert.IsTrue(maxmath.asquarter(1 << 7) == (quarter)0f);
            Assert.IsTrue((quarter)0f == maxmath.asquarter(1 << 7));
            Assert.IsTrue((quarter)0f == (quarter)0f);

            Assert.IsTrue((quarter)1f == (quarter)1f);
        }

        [Test]
        public static void NotEquals()
        {
            Assert.IsTrue(quarter.NaN != quarter.NaN);
            Assert.IsTrue(quarter.NaN != (quarter)1f);

            Assert.IsTrue((quarter)1f != (quarter)0f);

            Assert.IsTrue((quarter)1f != (quarter)(-1f));

            Assert.IsFalse((quarter)1f != (quarter)1f);
            Assert.IsFalse((quarter)maxmath.asquarter((byte)(1 << 7)) != (quarter)maxmath.asquarter((byte)(1 << 7)));
            Assert.IsFalse((quarter)maxmath.asquarter((byte)(1 << 7)) != maxmath.asquarter((byte)0));
            Assert.IsFalse((quarter)maxmath.asquarter((byte)0) != (quarter)maxmath.asquarter((byte)(1 << 7)));
            Assert.IsFalse(maxmath.asquarter((byte)0) != maxmath.asquarter((byte)0));
        }


        [Test]
        public static void LessThan()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse((quarter)quarter.NaN < (quarter)0f);
            Assert.IsFalse((quarter)0f < (quarter)quarter.NaN);
            Assert.IsFalse((quarter)quarter.PositiveInfinity < (quarter)quarter.NaN);
            Assert.IsFalse((quarter)quarter.NegativeInfinity < (quarter)quarter.NaN);

            for (int i = 0; i < 25; i++)
            {
                quarter lhs = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);
                quarter rhs = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs < rhs, (float)lhs < (float)rhs);
                Assert.AreEqual(lhs < lhs, (float)lhs < (float)lhs);

                lhs = (quarter)0f;

                Assert.AreEqual(lhs < rhs, (float)lhs < (float)rhs);
                Assert.AreEqual(lhs < lhs, (float)lhs < (float)lhs);
            }
        }

        [Test]
        public static void LessEqual()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse((quarter)quarter.NaN <= (quarter)0f);
            Assert.IsFalse((quarter)0f <= (quarter)quarter.NaN);
            Assert.IsFalse((quarter)quarter.PositiveInfinity <= (quarter)quarter.NaN);
            Assert.IsFalse((quarter)quarter.NegativeInfinity <= (quarter)quarter.NaN);

            for (int i = 0; i < 25; i++)
            {
                quarter lhs = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);
                quarter rhs = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs <= rhs, (float)lhs <= (float)rhs);
                Assert.AreEqual(lhs <= lhs, (float)lhs <= (float)lhs);

                lhs = (quarter)0f;

                Assert.AreEqual(lhs < rhs, (float)lhs < (float)rhs);
                Assert.AreEqual(lhs < lhs, (float)lhs < (float)lhs);
            }
        }


        [Test]
        public static void ToHalf()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter q = maxmath.asquarter((byte)i);

                if (IsZero(q))
                {
                    Assert.AreEqual(0f, (float)(half)q);
                    continue;
                }
                if (maxmath.isnan(q))
                {
                    Assert.IsTrue(math.isnan((half)q));
                    continue;
                }
                if (q == quarter.PositiveInfinity)
                {
                    Assert.IsTrue(math.isinf((half)q) && (half)q > 0f);
                    continue;
                }
                if (q == quarter.NegativeInfinity)
                {
                    Assert.IsTrue(math.isinf((half)q) && (half)q < 0f);
                    continue;
                }

                float lead = IsDenormalOrZero(q) ? 0f : 1f;
                float mantissa = Mantissa(q);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q));
                calculated = IsPositive(q) ? calculated : -calculated;

                Assert.AreEqual((half)calculated, (half)q);
            }
        }

        [Test]
        public static void ToFloat()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter q = maxmath.asquarter((byte)i);

                if (IsZero(q))
                {
                    Assert.AreEqual(0f, (float)q);
                    continue;
                }
                if (maxmath.isnan(q))
                {
                    Assert.IsTrue(math.isnan((float)q));
                    continue;
                }
                if (q == quarter.PositiveInfinity)
                {
                    Assert.IsTrue(math.isinf((float)q) && (float)q > 0f);
                    continue;
                }
                if (q == quarter.NegativeInfinity)
                {
                    Assert.IsTrue(math.isinf((float)q) && (float)q < 0f);
                    continue;
                }

                float lead = IsDenormalOrZero(q) ? 0f : 1f;
                float mantissa = Mantissa(q);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q));
                calculated = IsPositive(q) ? calculated : -calculated;

                Assert.AreEqual(calculated, (float)q);
            }
        }

        [Test]
        public static void ToDouble()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter q = maxmath.asquarter((byte)i);

                if (IsZero(q))
                {
                    Assert.AreEqual(0f, (double)q);
                    continue;
                }
                if (maxmath.isnan(q))
                {
                    Assert.IsTrue(math.isnan((double)q));
                    continue;
                }
                if (q == quarter.PositiveInfinity)
                {
                    Assert.IsTrue(math.isinf((double)q) && (double)q > 0d);
                    continue;
                }
                if (q == quarter.NegativeInfinity)
                {
                    Assert.IsTrue(math.isinf((double)q) && (double)q < 0d);
                    continue;
                }

                double lead = IsDenormalOrZero(q) ? 0d : 1d;
                double mantissa = Mantissa(q);

                double calculated = (lead + mantissa) * math.pow(2d, Exponent(q));
                calculated = IsPositive(q) ? calculated : -calculated;

                Assert.AreEqual(calculated, (double)q);
            }
        }


        [Test]
        public static void ToByte()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((byte)(float)maxmath.asquarter((byte)i), (byte)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToShort()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((short)i, (short)(quarter)i);
            }
        }

        [Test]
        public static void ToInt()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((int)i, (int)(quarter)i);
            }
        }

        [Test]
        public static void ToLong()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((long)i, (long)(quarter)i);
            }
        }

        [Test]
        public static void ToInt128()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((Int128)i, (Int128)(quarter)i);
            }
        }


        [Test]
        public static void ToSByte()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((sbyte)(float)maxmath.asquarter((byte)i), (sbyte)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUShort()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ushort)i, (ushort)(quarter)i);
            }
        }

        [Test]
        public static void ToUInt()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((uint)i, (uint)(quarter)i);
            }
        }

        [Test]
        public static void ToULong()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ulong)i, (ulong)(quarter)i);
            }
        }

        [Test]
        public static void ToUInt128()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((UInt128)i, (UInt128)(quarter)i);
            }
        }


        [Test]
        public static void FromHalf()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q))
                {
                    Assert.IsNaN((half)q);
                }
                else
                {
                    Assert.AreEqual(q, (quarter)(half)q);
                }
            }
        }

        [Test]
        public static void FromHalf_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                half f = subnormalQuarter ? (half)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                          : (half)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter q = (quarter)f;
                quarter qm1 = maxmath.nextsmaller(q);
                quarter qp1 = maxmath.nextgreater(q);

                Assert.IsFalse(math.abs(f - qm1) < math.abs(f - q));
                Assert.IsFalse(math.abs(f - qp1) < math.abs(f - q));
            }
        }

        [Test]
        public static void FromFloat()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q))
                {
                    Assert.IsNaN((float)q);
                }
                else
                {
                    Assert.AreEqual(q, (quarter)(float)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                float f = subnormalQuarter ? rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                           : rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter q = (quarter)f;
                quarter qm1 = maxmath.nextsmaller(q);
                quarter qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.abs(f - qm1) < math.abs(f - q));
                Assert.IsFalse(math.abs(f - qp1) < math.abs(f - q));
            }
        }

        [Test]
        public static void FromDouble()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q))
                {
                    Assert.IsNaN((double)q);
                }
                else
                {
                    Assert.AreEqual(q, (quarter)(double)q);
                }
            }
        }
        
        [Test]
        public static void FromDouble_RoundToNearest()
        {
            Random64 rng = Random64.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                double f = subnormalQuarter ? rng.NextDouble(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                            : rng.NextDouble(quarter.MinValue, quarter.MaxValue);

                quarter q = (quarter)f;
                quarter qm1 = maxmath.nextsmaller(q);
                quarter qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.abs(f - qm1) < math.abs(f - q));
                Assert.IsFalse(math.abs(f - qp1) < math.abs(f - q));
            }
        }

        [Test]
        public static void FromByte()
        {
            for (byte i = 0; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(byte)i);
            }

            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(byte)16);
        }

        [Test]
        public static void FromShort()
        {
            for (short i = -15; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(short)i);
            }

            Assert.AreEqual((float)quarter.NegativeInfinity, (float)(quarter)(short)-16);
            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(short)16);
        }

        [Test]
        public static void FromInt()
        {
            for (int i = -15; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(int)i);
            }

            Assert.AreEqual((float)quarter.NegativeInfinity, (float)(quarter)(int)-16);
            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(int)16);
        }

        [Test]
        public static void FromLong()
        {
            for (long i = -15; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(long)i);
            }

            Assert.AreEqual((float)quarter.NegativeInfinity, (float)(quarter)(long)-16);
            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(long)16);
        }

        [Test]
        public static void FromInt128()
        {
            for (Int128 i = -15; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(Int128)i);
            }

            Assert.AreEqual((float)quarter.NegativeInfinity, (float)(quarter)(Int128)(-16));
            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(Int128)16);
        }


        [Test]
        public static void FromSByte()
        {
            for (sbyte i = -15; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(sbyte)i);
            }

            Assert.AreEqual((float)quarter.NegativeInfinity, (float)(quarter)(sbyte)-16);
            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(sbyte)16);
        }

        [Test]
        public static void FromUShort()
        {
            for (ushort i = 0; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(ushort)i);
            }

            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(ushort)16);
        }

        [Test]
        public static void FromUInt()
        {
            for (uint i = 0; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(uint)i);
            }

            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(uint)16);
        }

        [Test]
        public static void FromULong()
        {
            for (ulong i = 0; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(ulong)i);
            }

            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(ulong)16);
        }

        [Test]
        public static void FromUInt128()
        {
            for (UInt128 i = 0; i < 16; i++)
            {
                Assert.AreEqual((float)i, (float)(quarter)(UInt128)i);
            }

            Assert.AreEqual((float)quarter.PositiveInfinity, (float)(quarter)(UInt128)16);
        }


        [Test]
        public static void Equals2()
        {
            Assert.IsFalse(math.any((quarter2)quarter.NaN == (quarter2)quarter.NaN));
            Assert.IsFalse(math.any((quarter2)quarter.NaN == (quarter2)(quarter)1f));

            Assert.IsTrue(math.all((quarter2)maxmath.asquarter(1 << 7) == (quarter2)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(math.all((quarter2)maxmath.asquarter(1 << 7) == (quarter2)(quarter)0f));
            Assert.IsTrue(math.all((quarter2)(quarter)0f == (quarter2)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(math.all((quarter2)(quarter)0f == (quarter2)(quarter)0f));

            Assert.IsTrue(math.all((quarter2)(quarter)1f == (quarter2)(quarter)1f));
        }

        [Test]
        public static void NotEquals2()
        {
            Assert.IsTrue(math.all((quarter2)quarter.NaN != quarter.NaN));
            Assert.IsTrue(math.all((quarter2)quarter.NaN != (quarter)1f));

            Assert.IsTrue(math.all((quarter2)(quarter)1f != (quarter)0f));

            Assert.IsTrue(math.all((quarter2)(quarter)1f != (quarter)(-1f)));

            Assert.IsFalse(math.any((quarter2)(quarter)1f != (quarter2)(quarter)1f));
            Assert.IsFalse(math.any((quarter2)maxmath.asquarter((byte)(1 << 7)) != (quarter2)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter2)maxmath.asquarter((byte)(1 << 7)) != (quarter2)0f));
            Assert.IsFalse(math.any((quarter2)0f != (quarter2)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter2)0f != (quarter2)0f));
        }

        [Test]
        public static void LessThan2()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter2)quarter.NaN < (quarter2)0f).x);
            Assert.IsFalse(((quarter2)0f < (quarter2)quarter.NaN).x);
            Assert.IsFalse(((quarter2)quarter.PositiveInfinity < (quarter2)quarter.NaN).x);
            Assert.IsFalse(((quarter2)quarter.NegativeInfinity < (quarter2)quarter.NaN).x);

            for (int i = 0; i < 25; i++)
            {
                quarter2 lhs = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);
                quarter2 rhs = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs < rhs, (float2)lhs < (float2)rhs);
                Assert.AreEqual(lhs < lhs, (float2)lhs < (float2)lhs);

                lhs = (quarter2)0f;

                Assert.AreEqual(lhs < rhs, (float2)lhs < (float2)rhs);
                Assert.AreEqual(lhs < lhs, (float2)lhs < (float2)lhs);
            }
        }

        [Test]
        public static void LessEqual2()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter2)quarter.NaN <= (quarter2)0f).x);
            Assert.IsFalse(((quarter2)0f <= (quarter2)quarter.NaN).x);
            Assert.IsFalse(((quarter2)quarter.PositiveInfinity <= (quarter2)quarter.NaN).x);
            Assert.IsFalse(((quarter2)quarter.NegativeInfinity <= (quarter2)quarter.NaN).x);

            for (int i = 0; i < 25; i++)
            {
                quarter2 lhs = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);
                quarter2 rhs = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs <= rhs, (float2)lhs <= (float2)rhs);
                Assert.AreEqual(lhs <= lhs, (float2)lhs <= (float2)lhs);

                lhs = (quarter2)0f;

                Assert.AreEqual(lhs < rhs, (float2)lhs < (float2)rhs);
                Assert.AreEqual(lhs < lhs, (float2)lhs < (float2)lhs);
            }
        }

        [Test]
        public static void ToHalf2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((float2)0f, (float2)(half2)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((half2)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((half2)q) & ((float2)(half2)q > 0f)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((half2)q) & ((float2)(half2)q < 0f)));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float mantissa = Mantissa(q.x);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((half2)calculated, (half2)q);
            }
        }

        [Test]
        public static void ToFloat2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((float2)0f, (float2)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((float2)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((float2)q) & ((float2)q > 0f)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((float2)q) & ((float2)q < 0f)));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float mantissa = Mantissa(q.x);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((float2)calculated, (float2)q);
            }
        }

        [Test]
        public static void ToDouble2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((double2)0d, (double2)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((double2)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((double2)q) & ((double2)q > 0d)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((double2)q) & ((double2)q < 0d)));
                    continue;
                }

                double2 lead = IsDenormalOrZero(q.x) ? 0d : 1d;
                double2 mantissa = Mantissa(q.x);

                double2 calculated = (lead + mantissa) * math.pow(2d, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((double2)calculated, (double2)q);
            }
        }


        [Test]
        public static void ToByte2()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((byte2)(float2)(quarter2)maxmath.asquarter((byte)i), (byte2)(quarter2)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToShort2()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((short2)(float2)(quarter2)maxmath.asquarter((byte)i), (short2)(quarter2)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToInt2()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((int2)(float2)(quarter2)maxmath.asquarter((byte)i), (int2)(quarter2)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToLong2()
        {
            for (long i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((long2)(float2)(quarter2)maxmath.asquarter((byte)i), (long2)(quarter2)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void ToSByte2()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((sbyte2)(float2)(quarter2)maxmath.asquarter((byte)i), (sbyte2)(quarter2)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUShort2()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((ushort2)(float2)(quarter2)maxmath.asquarter((byte)i), (ushort2)(quarter2)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUInt2()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((uint2)(float2)(quarter2)maxmath.asquarter((byte)i), (uint2)(quarter2)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToULong2()
        {
            for (long i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((ulong2)(float2)(quarter2)maxmath.asquarter((byte)i), (ulong2)(quarter2)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void FromHalf2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(maxmath.isnan((half2)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter2)(half2)q);
                }
            }
        }
        
        [Test]
        public static void FromHalf2_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                half2 f = subnormalQuarter ? (half)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                           : (half)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter2 q = (quarter2)f;
                quarter2 qm1 = maxmath.nextsmaller(q);
                quarter2 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs((float2)f - qm1) < math.abs((float2)f - q)));
                Assert.IsFalse(math.any(math.abs((float2)f - qp1) < math.abs((float2)f - q)));
            }
        }

        [Test]
        public static void FromFloat2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((float2)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter2)(float2)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat2_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                float2 f = subnormalQuarter ? (float)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                            : (float)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter2 q = (quarter2)f;
                quarter2 qm1 = maxmath.nextsmaller(q);
                quarter2 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromDouble2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((double2)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter2)(double2)q);
                }
            }
        }
        
        [Test]
        public static void FromDouble2_RoundToNearest()
        {
            Random64 rng = Random64.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                double2 f = subnormalQuarter ? (double)rng.NextDouble(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                             : (double)rng.NextDouble(quarter.MinValue, quarter.MaxValue);

                quarter2 q = (quarter2)f;
                quarter2 qm1 = maxmath.nextsmaller(q);
                quarter2 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }


        [Test]
        public static void FromByte2()
        {
            for (byte i = 0; i < 16; i++)
            {
                Assert.AreEqual((float2)(float)i, (float2)(quarter2)(byte2)i);
            }

            Assert.AreEqual((float2)(quarter2)quarter.PositiveInfinity, (float2)(quarter2)(byte2)16);
        }

        [Test]
        public static void FromShort2()
        {
            for (short i = -15; i < 16; i++)
            {
                Assert.AreEqual((float2)(float)i, (float2)(quarter2)(short2)i);
            }

            Assert.AreEqual((float2)(quarter2)quarter.NegativeInfinity, (float2)(quarter2)(short2)(-16));
            Assert.AreEqual((float2)(quarter2)quarter.PositiveInfinity, (float2)(quarter2)(short2)16);
        }

        [Test]
        public static void FromInt2()
        {
            for (int i = -15; i < 16; i++)
            {
                Assert.AreEqual((float2)(float)i, (float2)(quarter2)(int2)i);
            }

            Assert.AreEqual((float2)(quarter2)quarter.NegativeInfinity, (float2)(quarter2)(int2)(-16));
            Assert.AreEqual((float2)(quarter2)quarter.PositiveInfinity, (float2)(quarter2)(int2)16);
        }

        [Test]
        public static void FromLong2()
        {
            for (long i = -15; i < 16; i++)
            {
                Assert.AreEqual((float2)(float)i, (float2)(quarter2)(long2)i);
            }

            Assert.AreEqual((float2)(quarter2)quarter.NegativeInfinity, (float2)(quarter2)(long2)(-16));
            Assert.AreEqual((float2)(quarter2)quarter.PositiveInfinity, (float2)(quarter2)(long2)16);
        }


        [Test]
        public static void FromSByte2()
        {
            for (sbyte i = -15; i < 16; i++)
            {
                Assert.AreEqual((float2)(float)i, (float2)(quarter2)(sbyte2)i);
            }

            Assert.AreEqual((float2)(quarter2)quarter.NegativeInfinity, (float2)(quarter2)(sbyte2)(-16));
            Assert.AreEqual((float2)(quarter2)quarter.PositiveInfinity, (float2)(quarter2)(sbyte2)16);
        }

        [Test]
        public static void FromUShort2()
        {
            for (ushort i = 0; i < 16; i++)
            {
                Assert.AreEqual((float2)(float)i, (float2)(quarter2)(ushort2)i);
            }

            Assert.AreEqual((float2)(quarter2)quarter.PositiveInfinity, (float2)(quarter2)(ushort2)16);
        }

        [Test]
        public static void FromUInt2()
        {
            for (uint i = 0; i < 16; i++)
            {
                Assert.AreEqual((float2)(float)i, (float2)(quarter2)(uint2)i);
            }

            Assert.AreEqual((float2)(quarter2)quarter.PositiveInfinity, (float2)(quarter2)(uint2)16);
        }

        [Test]
        public static void FromULong2()
        {
            for (ulong i = 0; i < 16; i++)
            {
                Assert.AreEqual((float2)(float)i, (float2)(quarter2)(ulong2)i);
            }

            Assert.AreEqual((float2)(quarter2)quarter.PositiveInfinity, (float2)(quarter2)(ulong2)16);
        }


        [Test]
        public static void Equals3()
        {
            Assert.IsFalse(math.any((quarter3)quarter.NaN == (quarter3)quarter.NaN));
            Assert.IsFalse(math.any((quarter3)quarter.NaN == (quarter3)(quarter)1f));

            Assert.IsTrue(math.all((quarter3)maxmath.asquarter(1 << 7) == (quarter3)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(math.all((quarter3)maxmath.asquarter(1 << 7) == (quarter3)(quarter)0f));
            Assert.IsTrue(math.all((quarter3)(quarter)0f == (quarter3)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(math.all((quarter3)(quarter)0f == (quarter3)(quarter)0f));

            Assert.IsTrue(math.all((quarter3)(quarter)1f == (quarter3)(quarter)1f));
        }

        [Test]
        public static void NotEquals3()
        {
            Assert.IsTrue(math.all((quarter3)quarter.NaN != quarter.NaN));
            Assert.IsTrue(math.all((quarter3)quarter.NaN != (quarter)1f));

            Assert.IsTrue(math.all((quarter3)(quarter)1f != (quarter)0f));

            Assert.IsTrue(math.all((quarter3)(quarter)1f != (quarter)(-1f)));

            Assert.IsFalse(math.any((quarter3)(quarter)1f != (quarter3)(quarter)1f));
            Assert.IsFalse(math.any((quarter3)maxmath.asquarter((byte)(1 << 7)) != (quarter3)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter3)maxmath.asquarter((byte)(1 << 7)) != (quarter3)0f));
            Assert.IsFalse(math.any((quarter3)0f != (quarter3)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter3)0f != (quarter3)0f));
        }

        [Test]
        public static void LessThan3()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter3)quarter.NaN < (quarter3)0f).x);
            Assert.IsFalse(((quarter3)0f < (quarter3)quarter.NaN).x);
            Assert.IsFalse(((quarter3)quarter.PositiveInfinity < (quarter3)quarter.NaN).x);
            Assert.IsFalse(((quarter3)quarter.NegativeInfinity < (quarter3)quarter.NaN).x);

            for (int i = 0; i < 25; i++)
            {
                quarter3 lhs = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);
                quarter3 rhs = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs < rhs, (float3)lhs < (float3)rhs);
                Assert.AreEqual(lhs < lhs, (float3)lhs < (float3)lhs);

                lhs = (quarter3)0f;

                Assert.AreEqual(lhs < rhs, (float3)lhs < (float3)rhs);
                Assert.AreEqual(lhs < lhs, (float3)lhs < (float3)lhs);
            }
        }

        [Test]
        public static void LessEqual3()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter3)quarter.NaN <= (quarter3)0f).x);
            Assert.IsFalse(((quarter3)0f <= (quarter3)quarter.NaN).x);
            Assert.IsFalse(((quarter3)quarter.PositiveInfinity <= (quarter3)quarter.NaN).x);
            Assert.IsFalse(((quarter3)quarter.NegativeInfinity <= (quarter3)quarter.NaN).x);

            for (int i = 0; i < 35; i++)
            {
                quarter3 lhs = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);
                quarter3 rhs = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs <= rhs, (float3)lhs <= (float3)rhs);
                Assert.AreEqual(lhs <= lhs, (float3)lhs <= (float3)lhs);

                lhs = (quarter3)0f;

                Assert.AreEqual(lhs < rhs, (float3)lhs < (float3)rhs);
                Assert.AreEqual(lhs < lhs, (float3)lhs < (float3)lhs);
            }
        }


        [Test]
        public static void ToHalf3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((float3)0f, (float3)(half3)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((half3)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((half3)q) & ((float3)(half3)q > 0f)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((half3)q) & ((float3)(half3)q < 0f)));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float mantissa = Mantissa(q.x);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((half3)calculated, (half3)q);
            }
        }

        [Test]
        public static void ToFloat3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((float3)0f, (float3)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((float3)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((float3)q) & ((float3)q > 0f)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((float3)q) & ((float3)q < 0f)));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float mantissa = Mantissa(q.x);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((float3)calculated, (float3)q);
            }
        }

        [Test]
        public static void ToDouble3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((double3)0d, (double3)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((double3)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((double3)q) & ((double3)q > 0d)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((double3)q) & ((double3)q < 0d)));
                    continue;
                }

                double3 lead = IsDenormalOrZero(q.x) ? 0d : 1d;
                double3 mantissa = Mantissa(q.x);

                double3 calculated = (lead + mantissa) * math.pow(2d, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((double3)calculated, (double3)q);
            }
        }



        [Test]
        public static void ToByte3()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((byte3)(float3)(quarter3)maxmath.asquarter((byte)i), (byte3)(quarter3)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToShort3()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((short3)(float3)(quarter3)maxmath.asquarter((byte)i), (short3)(quarter3)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToInt3()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((int3)(float3)(quarter3)maxmath.asquarter((byte)i), (int3)(quarter3)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToLong3()
        {
            for (long i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((long3)(float3)(quarter3)maxmath.asquarter((byte)i), (long3)(quarter3)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void ToSByte3()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((sbyte3)(float3)(quarter3)maxmath.asquarter((byte)i), (sbyte3)(quarter3)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUShort3()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((ushort3)(float3)(quarter3)maxmath.asquarter((byte)i), (ushort3)(quarter3)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUInt3()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((uint3)(float3)(quarter3)maxmath.asquarter((byte)i), (uint3)(quarter3)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToULong3()
        {
            for (long i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((ulong3)(float3)(quarter3)maxmath.asquarter((byte)i), (ulong3)(quarter3)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void FromHalf3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(maxmath.isnan((half3)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter3)(half3)q);
                }
            }
        }
        
        [Test]
        public static void FromHalf3_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 138) subnormalQuarter = true;

                half3 f = subnormalQuarter ? (half)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                           : (half)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter3 q = (quarter3)f;
                quarter3 qm1 = maxmath.nextsmaller(q);
                quarter3 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs((float3)f - qm1) < math.abs((float3)f - q)));
                Assert.IsFalse(math.any(math.abs((float3)f - qp1) < math.abs((float3)f - q)));
            }
        }

        [Test]
        public static void FromFloat3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((float3)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter3)(float3)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat3_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 138) subnormalQuarter = true;

                float3 f = subnormalQuarter ? (float)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                            : (float)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter3 q = (quarter3)f;
                quarter3 qm1 = maxmath.nextsmaller(q);
                quarter3 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromDouble3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((double3)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter3)(double3)q);
                }
            }
        }
        
        [Test]
        public static void FromDouble3_RoundToNearest()
        {
            Random64 rng = Random64.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 138) subnormalQuarter = true;

                double3 f = subnormalQuarter ? (double)rng.NextDouble(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                             : (double)rng.NextDouble(quarter.MinValue, quarter.MaxValue);

                quarter3 q = (quarter3)f;
                quarter3 qm1 = maxmath.nextsmaller(q);
                quarter3 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromByte3()
        {
            for (byte i = 0; i < 16; i++)
            {
                Assert.AreEqual((float3)(float)i, (float3)(quarter3)(byte3)i);
            }

            Assert.AreEqual((float3)(quarter3)quarter.PositiveInfinity, (float3)(quarter3)(byte3)16);
        }

        [Test]
        public static void FromShort3()
        {
            for (short i = -15; i < 16; i++)
            {
                Assert.AreEqual((float3)(float)i, (float3)(quarter3)(short3)i);
            }

            Assert.AreEqual((float3)(quarter3)quarter.NegativeInfinity, (float3)(quarter3)(short3)(-16));
            Assert.AreEqual((float3)(quarter3)quarter.PositiveInfinity, (float3)(quarter3)(short3)16);
        }

        [Test]
        public static void FromInt3()
        {
            for (int i = -15; i < 16; i++)
            {
                Assert.AreEqual((float3)(float)i, (float3)(quarter3)(int3)i);
            }

            Assert.AreEqual((float3)(quarter3)quarter.NegativeInfinity, (float3)(quarter3)(int3)(-16));
            Assert.AreEqual((float3)(quarter3)quarter.PositiveInfinity, (float3)(quarter3)(int3)16);
        }

        [Test]
        public static void FromLong3()
        {
            for (long i = -15; i < 16; i++)
            {
                Assert.AreEqual((float3)(float)i, (float3)(quarter3)(long3)i);
            }

            Assert.AreEqual((float3)(quarter3)quarter.NegativeInfinity, (float3)(quarter3)(long3)(-16));
            Assert.AreEqual((float3)(quarter3)quarter.PositiveInfinity, (float3)(quarter3)(long3)16);
        }


        [Test]
        public static void FromSByte3()
        {
            for (sbyte i = -15; i < 16; i++)
            {
                Assert.AreEqual((float3)(float)i, (float3)(quarter3)(sbyte3)i);
            }

            Assert.AreEqual((float3)(quarter3)quarter.NegativeInfinity, (float3)(quarter3)(sbyte3)(-16));
            Assert.AreEqual((float3)(quarter3)quarter.PositiveInfinity, (float3)(quarter3)(sbyte3)16);
        }

        [Test]
        public static void FromUShort3()
        {
            for (ushort i = 0; i < 16; i++)
            {
                Assert.AreEqual((float3)(float)i, (float3)(quarter3)(ushort3)i);
            }

            Assert.AreEqual((float3)(quarter3)quarter.PositiveInfinity, (float3)(quarter3)(ushort3)16);
        }

        [Test]
        public static void FromUInt3()
        {
            for (uint i = 0; i < 16; i++)
            {
                Assert.AreEqual((float3)(float)i, (float3)(quarter3)(uint3)i);
            }

            Assert.AreEqual((float3)(quarter3)quarter.PositiveInfinity, (float3)(quarter3)(uint3)16);
        }

        [Test]
        public static void FromULong3()
        {
            for (ulong i = 0; i < 16; i++)
            {
                Assert.AreEqual((float3)(float)i, (float3)(quarter3)(ulong3)i);
            }

            Assert.AreEqual((float3)(quarter3)quarter.PositiveInfinity, (float3)(quarter3)(ulong3)16);
        }


        [Test]
        public static void Equals4()
        {
            Assert.IsFalse(math.any((quarter4)quarter.NaN == (quarter4)quarter.NaN));
            Assert.IsFalse(math.any((quarter4)quarter.NaN == (quarter4)(quarter)1f));

            Assert.IsTrue(math.all((quarter4)maxmath.asquarter(1 << 7) == (quarter4)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(math.all((quarter4)maxmath.asquarter(1 << 7) == (quarter4)(quarter)0f));
            Assert.IsTrue(math.all((quarter4)(quarter)0f == (quarter4)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(math.all((quarter4)(quarter)0f == (quarter4)(quarter)0f));

            Assert.IsTrue(math.all((quarter4)(quarter)1f == (quarter4)(quarter)1f));
        }

        [Test]
        public static void NotEquals4()
        {
            Assert.IsTrue(math.all((quarter4)quarter.NaN != quarter.NaN));
            Assert.IsTrue(math.all((quarter4)quarter.NaN != (quarter)1f));

            Assert.IsTrue(math.all((quarter4)(quarter)1f != (quarter)0f));

            Assert.IsTrue(math.all((quarter4)(quarter)1f != (quarter)(-1f)));

            Assert.IsFalse(math.any((quarter4)(quarter)1f != (quarter4)(quarter)1f));
            Assert.IsFalse(math.any((quarter4)maxmath.asquarter((byte)(1 << 7)) != (quarter4)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter4)maxmath.asquarter((byte)(1 << 7)) != (quarter4)0f));
            Assert.IsFalse(math.any((quarter4)0f != (quarter4)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter4)0f != (quarter4)0f));
        }

        [Test]
        public static void LessThan4()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter4)quarter.NaN < (quarter4)0f).x);
            Assert.IsFalse(((quarter4)0f < (quarter4)quarter.NaN).x);
            Assert.IsFalse(((quarter4)quarter.PositiveInfinity < (quarter4)quarter.NaN).x);
            Assert.IsFalse(((quarter4)quarter.NegativeInfinity < (quarter4)quarter.NaN).x);

            for (int i = 0; i < 25; i++)
            {
                quarter4 lhs = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);
                quarter4 rhs = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs < rhs, (float4)lhs < (float4)rhs);
                Assert.AreEqual(lhs < lhs, (float4)lhs < (float4)lhs);

                lhs = (quarter4)0f;

                Assert.AreEqual(lhs < rhs, (float4)lhs < (float4)rhs);
                Assert.AreEqual(lhs < lhs, (float4)lhs < (float4)lhs);
            }
        }

        [Test]
        public static void LessEqual4()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter4)quarter.NaN <= (quarter4)0f).x);
            Assert.IsFalse(((quarter4)0f <= (quarter4)quarter.NaN).x);
            Assert.IsFalse(((quarter4)quarter.PositiveInfinity <= (quarter4)quarter.NaN).x);
            Assert.IsFalse(((quarter4)quarter.NegativeInfinity <= (quarter4)quarter.NaN).x);

            for (int i = 0; i < 45; i++)
            {
                quarter4 lhs = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);
                quarter4 rhs = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs <= rhs, (float4)lhs <= (float4)rhs);
                Assert.AreEqual(lhs <= lhs, (float4)lhs <= (float4)lhs);

                lhs = (quarter4)0f;

                Assert.AreEqual(lhs < rhs, (float4)lhs < (float4)rhs);
                Assert.AreEqual(lhs < lhs, (float4)lhs < (float4)lhs);
            }
        }


        [Test]
        public static void ToHalf4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((float4)0f, (float4)(half4)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((half4)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((half4)q) & ((float4)(half4)q > 0f)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((half4)q) & ((float4)(half4)q < 0f)));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float mantissa = Mantissa(q.x);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((half4)calculated, (half4)q);
            }
        }

        [Test]
        public static void ToFloat4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((float4)0f, (float4)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((float4)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((float4)q) & ((float4)q > 0f)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((float4)q) & ((float4)q < 0f)));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float mantissa = Mantissa(q.x);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((float4)calculated, (float4)q);
            }
        }

        [Test]
        public static void ToDouble4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x))
                {
                    Assert.AreEqual((double4)0d, (double4)q);
                    continue;
                }
                if (math.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(math.all(math.isnan((double4)q)));
                    continue;
                }
                if (math.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((double4)q) & ((double4)q > 0d)));
                    continue;
                }
                if (math.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(math.all(math.isinf((double4)q) & ((double4)q < 0d)));
                    continue;
                }

                double4 lead = IsDenormalOrZero(q.x) ? 0d : 1d;
                double4 mantissa = Mantissa(q.x);

                double4 calculated = (lead + mantissa) * math.pow(2d, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((double4)calculated, (double4)q);
            }
        }


        [Test]
        public static void ToByte4()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((byte4)(float4)(quarter4)maxmath.asquarter((byte)i), (byte4)(quarter4)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToShort4()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((short4)(float4)(quarter4)maxmath.asquarter((byte)i), (short4)(quarter4)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToInt4()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((int4)(float4)(quarter4)maxmath.asquarter((byte)i), (int4)(quarter4)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToLong4()
        {
            for (long i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((long4)(float4)(quarter4)maxmath.asquarter((byte)i), (long4)(quarter4)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void ToSByte4()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((sbyte4)(float4)(quarter4)maxmath.asquarter((byte)i), (sbyte4)(quarter4)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUShort4()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((ushort4)(float4)(quarter4)maxmath.asquarter((byte)i), (ushort4)(quarter4)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUInt4()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((uint4)(float4)(quarter4)maxmath.asquarter((byte)i), (uint4)(quarter4)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToULong4()
        {
            for (long i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((ulong4)(float4)(quarter4)maxmath.asquarter((byte)i), (ulong4)(quarter4)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void FromHalf4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(maxmath.isnan((half4)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter4)(half4)q);
                }
            }
        }
        
        [Test]
        public static void FromHalf4_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 148) subnormalQuarter = true;

                half4 f = subnormalQuarter ? (half)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                           : (half)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter4 q = (quarter4)f;
                quarter4 qm1 = maxmath.nextsmaller(q);
                quarter4 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs((float4)f - qm1) < math.abs((float4)f - q)));
                Assert.IsFalse(math.any(math.abs((float4)f - qp1) < math.abs((float4)f - q)));
            }
        }

        [Test]
        public static void FromFloat4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((float4)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter4)(float4)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat4_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 148) subnormalQuarter = true;

                float4 f = subnormalQuarter ? (float)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                            : (float)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter4 q = (quarter4)f;
                quarter4 qm1 = maxmath.nextsmaller(q);
                quarter4 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromDouble4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((double4)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter4)(double4)q);
                }
            }
        }
        
        [Test]
        public static void FromDouble4_RoundToNearest()
        {
            Random64 rng = Random64.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 148) subnormalQuarter = true;

                double4 f = subnormalQuarter ? (double)rng.NextDouble(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                             : (double)rng.NextDouble(quarter.MinValue, quarter.MaxValue);

                quarter4 q = (quarter4)f;
                quarter4 qm1 = maxmath.nextsmaller(q);
                quarter4 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }


        [Test]
        public static void FromByte4()
        {
            for (byte i = 0; i < 16; i++)
            {
                Assert.AreEqual((float4)(float)i, (float4)(quarter4)(byte4)i);
            }

            Assert.AreEqual((float4)(quarter4)quarter.PositiveInfinity, (float4)(quarter4)(byte4)16);
        }

        [Test]
        public static void FromShort4()
        {
            for (short i = -15; i < 16; i++)
            {
                Assert.AreEqual((float4)(float)i, (float4)(quarter4)(short4)i);
            }

            Assert.AreEqual((float4)(quarter4)quarter.NegativeInfinity, (float4)(quarter4)(short4)(-16));
            Assert.AreEqual((float4)(quarter4)quarter.PositiveInfinity, (float4)(quarter4)(short4)16);
        }

        [Test]
        public static void FromInt4()
        {
            for (int i = -15; i < 16; i++)
            {
                Assert.AreEqual((float4)(float)i, (float4)(quarter4)(int4)i);
            }

            Assert.AreEqual((float4)(quarter4)quarter.NegativeInfinity, (float4)(quarter4)(int4)(-16));
            Assert.AreEqual((float4)(quarter4)quarter.PositiveInfinity, (float4)(quarter4)(int4)16);
        }

        [Test]
        public static void FromLong4()
        {
            for (long i = -15; i < 16; i++)
            {
                Assert.AreEqual((float4)(float)i, (float4)(quarter4)(long4)i);
            }

            Assert.AreEqual((float4)(quarter4)quarter.NegativeInfinity, (float4)(quarter4)(long4)(-16));
            Assert.AreEqual((float4)(quarter4)quarter.PositiveInfinity, (float4)(quarter4)(long4)16);
        }


        [Test]
        public static void FromSByte4()
        {
            for (sbyte i = -15; i < 16; i++)
            {
                Assert.AreEqual((float4)(float)i, (float4)(quarter4)(sbyte4)i);
            }

            Assert.AreEqual((float4)(quarter4)quarter.NegativeInfinity, (float4)(quarter4)(sbyte4)(-16));
            Assert.AreEqual((float4)(quarter4)quarter.PositiveInfinity, (float4)(quarter4)(sbyte4)16);
        }

        [Test]
        public static void FromUShort4()
        {
            for (ushort i = 0; i < 16; i++)
            {
                Assert.AreEqual((float4)(float)i, (float4)(quarter4)(ushort4)i);
            }

            Assert.AreEqual((float4)(quarter4)quarter.PositiveInfinity, (float4)(quarter4)(ushort4)16);
        }

        [Test]
        public static void FromUInt4()
        {
            for (uint i = 0; i < 16; i++)
            {
                Assert.AreEqual((float4)(float)i, (float4)(quarter4)(uint4)i);
            }

            Assert.AreEqual((float4)(quarter4)quarter.PositiveInfinity, (float4)(quarter4)(uint4)16);
        }

        [Test]
        public static void FromULong4()
        {
            for (ulong i = 0; i < 16; i++)
            {
                Assert.AreEqual((float4)(float)i, (float4)(quarter4)(ulong4)i);
            }

            Assert.AreEqual((float4)(quarter4)quarter.PositiveInfinity, (float4)(quarter4)(ulong4)16);
        }


        [Test]
        public static void Equals8()
        {
            Assert.IsFalse(maxmath.any((quarter8)quarter.NaN == (quarter8)quarter.NaN));
            Assert.IsFalse(maxmath.any((quarter8)quarter.NaN == (quarter8)(quarter)1f));

            Assert.IsTrue(maxmath.all((quarter8)maxmath.asquarter(1 << 7) == (quarter8)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(maxmath.all((quarter8)maxmath.asquarter(1 << 7) == (quarter8)(quarter)0f));
            Assert.IsTrue(maxmath.all((quarter8)(quarter)0f == (quarter8)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(maxmath.all((quarter8)(quarter)0f == (quarter8)(quarter)0f));

            Assert.IsTrue(maxmath.all((quarter8)(quarter)1f == (quarter8)(quarter)1f));
        }

        [Test]
        public static void NotEquals8()
        {
            Assert.IsTrue(maxmath.all((quarter8)quarter.NaN != quarter.NaN));
            Assert.IsTrue(maxmath.all((quarter8)quarter.NaN != (quarter)1f));

            Assert.IsTrue(maxmath.all((quarter8)(quarter)1f != (quarter)0f));

            Assert.IsTrue(maxmath.all((quarter8)(quarter)1f != (quarter)(-1f)));

            Assert.IsFalse(maxmath.any((quarter8)(quarter)1f != (quarter8)(quarter)1f));
            Assert.IsFalse(maxmath.any((quarter8)maxmath.asquarter((byte)(1 << 7)) != (quarter8)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(maxmath.any((quarter8)maxmath.asquarter((byte)(1 << 7)) != (quarter8)0f));
            Assert.IsFalse(maxmath.any((quarter8)0f != (quarter8)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(maxmath.any((quarter8)0f != (quarter8)0f));
        }
        [Test]
        public static void LessThan8()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter8)quarter.NaN < (quarter8)0f).x0);
            Assert.IsFalse(((quarter8)0f < (quarter8)quarter.NaN).x0);
            Assert.IsFalse(((quarter8)quarter.PositiveInfinity < (quarter8)quarter.NaN).x0);
            Assert.IsFalse(((quarter8)quarter.NegativeInfinity < (quarter8)quarter.NaN).x0);

            for (int i = 0; i < 25; i++)
            {
                quarter8 lhs = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);
                quarter8 rhs = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs < rhs, (float8)lhs < (float8)rhs);
                Assert.AreEqual(lhs < lhs, (float8)lhs < (float8)lhs);

                lhs = (quarter8)0f;

                Assert.AreEqual(lhs < rhs, (float8)lhs < (float8)rhs);
                Assert.AreEqual(lhs < lhs, (float8)lhs < (float8)lhs);
            }
        }

        [Test]
        public static void LessEqual8()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter8)quarter.NaN <= (quarter8)0f).x0);
            Assert.IsFalse(((quarter8)0f <= (quarter8)quarter.NaN).x0);
            Assert.IsFalse(((quarter8)quarter.PositiveInfinity <= (quarter8)quarter.NaN).x0);
            Assert.IsFalse(((quarter8)quarter.NegativeInfinity <= (quarter8)quarter.NaN).x0);

            for (int i = 0; i < 85; i++)
            {
                quarter8 lhs = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);
                quarter8 rhs = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(lhs <= rhs, (float8)lhs <= (float8)rhs);
                Assert.AreEqual(lhs <= lhs, (float8)lhs <= (float8)lhs);

                lhs = (quarter8)0f;

                Assert.AreEqual(lhs < rhs, (float8)lhs < (float8)rhs);
                Assert.AreEqual(lhs < lhs, (float8)lhs < (float8)lhs);
            }
        }



        [Test]
        public static void ToHalf8()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter8 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x0))
                {
                    Assert.AreEqual((float8)0f, (float8)(half8)q);
                    continue;
                }
                if (maxmath.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isnan((half8)q)));
                    continue;
                }
                if (maxmath.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isinf((half8)q) & ((float8)(half8)q > 0f)));
                    continue;
                }
                if (maxmath.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isinf((half8)q) & ((float8)(half8)q < 0f)));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x0) ? 0f : 1f;
                float mantissa = Mantissa(q.x0);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x0));
                calculated = IsPositive(q.x0) ? calculated : -calculated;

                Assert.AreEqual((half8)calculated, (half8)q);
            }
        }

        [Test]
        public static void ToFloat8()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter8 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x0))
                {
                    Assert.AreEqual((float8)0f, (float8)q);
                    continue;
                }
                if (maxmath.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isnan((float8)q)));
                    continue;
                }
                if (maxmath.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isinf((float8)q) & ((float8)q > 0f)));
                    continue;
                }
                if (maxmath.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isinf((float8)q) & ((float8)q < 0f)));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x0) ? 0f : 1f;
                float mantissa = Mantissa(q.x0);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x0));
                calculated = IsPositive(q.x0) ? calculated : -calculated;

                Assert.AreEqual((float8)calculated, (float8)q);
            }
        }


        [Test]
        public static void ToByte8()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((byte8)(float8)(quarter8)maxmath.asquarter((byte)i), (byte8)(quarter8)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToShort8()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((short8)(float8)(quarter8)maxmath.asquarter((byte)i), (short8)(quarter8)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToInt8()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((int8)(float8)(quarter8)maxmath.asquarter((byte)i), (int8)(quarter8)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void ToSByte8()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual((sbyte8)(float8)(quarter8)maxmath.asquarter((byte)i), (sbyte8)(quarter8)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUShort8()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((ushort8)(float8)(quarter8)maxmath.asquarter((byte)i), (ushort8)(quarter8)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUInt8()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual((uint8)(float8)(quarter8)maxmath.asquarter((byte)i), (uint8)(quarter8)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void FromHalf8()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter8 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x0))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isnan((half8)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter8)(half8)q);
                }
            }
        }
        
        [Test]
        public static void FromHalf8_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                half8 f = subnormalQuarter ? (half)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                           : (half)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter8 q = (quarter8)f;
                quarter8 qm1 = maxmath.nextsmaller(q);
                quarter8 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(maxmath.any(maxmath.abs((float8)f - qm1) < maxmath.abs((float8)f - q)));
                Assert.IsFalse(maxmath.any(maxmath.abs((float8)f - qp1) < maxmath.abs((float8)f - q)));
            }
        }

        [Test]
        public static void FromFloat8()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter8 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x0))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isnan((float8)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter8)(float8)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat8_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                float8 f = subnormalQuarter ? (float)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                            : (float)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter8 q = (quarter8)f;
                quarter8 qm1 = maxmath.nextsmaller(q);
                quarter8 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(maxmath.any(maxmath.abs(f - qm1) < maxmath.abs(f - q)));
                Assert.IsFalse(maxmath.any(maxmath.abs(f - qp1) < maxmath.abs(f - q)));
            }
        }


        [Test]
        public static void FromByte8()
        {
            for (byte i = 0; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)(quarter8)(byte8)i);
            }

            Assert.AreEqual((float8)(quarter8)quarter.PositiveInfinity, (float8)(quarter8)(byte8)16);
        }

        [Test]
        public static void FromShort8()
        {
            for (short i = -15; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)(quarter8)(short8)i);
            }

            Assert.AreEqual((float8)(quarter8)quarter.NegativeInfinity, (float8)(quarter8)(short8)(-16));
            Assert.AreEqual((float8)(quarter8)quarter.PositiveInfinity, (float8)(quarter8)(short8)16);
        }

        [Test]
        public static void FromInt8()
        {
            for (int i = -15; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)(quarter8)(int8)i);
            }

            Assert.AreEqual((float8)(quarter8)quarter.NegativeInfinity, (float8)(quarter8)(int8)(-16));
            Assert.AreEqual((float8)(quarter8)quarter.PositiveInfinity, (float8)(quarter8)(int8)16);
        }


        [Test]
        public static void FromSByte8()
        {
            for (sbyte i = -15; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)(quarter8)(sbyte8)i);
            }

            Assert.AreEqual((float8)(quarter8)quarter.NegativeInfinity, (float8)(quarter8)(sbyte8)(-16));
            Assert.AreEqual((float8)(quarter8)quarter.PositiveInfinity, (float8)(quarter8)(sbyte8)16);
        }

        [Test]
        public static void FromUShort8()
        {
            for (ushort i = 0; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)(quarter8)(ushort8)i);
            }

            Assert.AreEqual((float8)(quarter8)quarter.PositiveInfinity, (float8)(quarter8)(ushort8)16);
        }

        [Test]
        public static void FromUInt8()
        {
            for (uint i = 0; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)(quarter8)(uint8)i);
            }

            Assert.AreEqual((float8)(quarter8)quarter.PositiveInfinity, (float8)(quarter8)(uint8)16);
        }


        [Test]
        public static void Equals16()
        {
            Assert.IsFalse(maxmath.any((quarter16)quarter.NaN == (quarter16)quarter.NaN));
            Assert.IsFalse(maxmath.any((quarter16)quarter.NaN == (quarter16)(quarter)1f));

            Assert.IsTrue(maxmath.all((quarter16)maxmath.asquarter(1 << 7) == (quarter16)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(maxmath.all((quarter16)maxmath.asquarter(1 << 7) == (quarter16)(quarter)0f));
            Assert.IsTrue(maxmath.all((quarter16)(quarter)0f == (quarter16)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(maxmath.all((quarter16)(quarter)0f == (quarter16)(quarter)0f));

            Assert.IsTrue(maxmath.all((quarter16)(quarter)1f == (quarter16)(quarter)1f));
        }

        [Test]
        public static void NotEquals16()
        {
            Assert.IsTrue(maxmath.all((quarter16)quarter.NaN != quarter.NaN));
            Assert.IsTrue(maxmath.all((quarter16)quarter.NaN != (quarter)1f));

            Assert.IsTrue(maxmath.all((quarter16)(quarter)1f != (quarter)0f));

            Assert.IsTrue(maxmath.all((quarter16)(quarter)1f != (quarter)(-1f)));

            Assert.IsFalse(maxmath.any((quarter16)(quarter)1f != (quarter16)(quarter)1f));
            Assert.IsFalse(maxmath.any((quarter16)maxmath.asquarter((byte)(1 << 7)) != (quarter16)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(maxmath.any((quarter16)maxmath.asquarter((byte)(1 << 7)) != (quarter16)0f));
            Assert.IsFalse(maxmath.any((quarter16)0f != (quarter16)maxmath.asquarter((byte)(1 << 7))));
            Assert.IsFalse(maxmath.any((quarter16)0f != (quarter16)0f));
        }
        [Test]
        public static void LessThan16()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter16)quarter.NaN < (quarter16)0f).x0);
            Assert.IsFalse(((quarter16)0f < (quarter16)quarter.NaN).x0);
            Assert.IsFalse(((quarter16)quarter.PositiveInfinity < (quarter16)quarter.NaN).x0);
            Assert.IsFalse(((quarter16)quarter.NegativeInfinity < (quarter16)quarter.NaN).x0);

            for (int i = 0; i < 25; i++)
            {
                quarter16 lhs = new quarter16((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));
                quarter16 rhs = new quarter16((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));

                Assert.AreEqual((lhs < rhs).v8_0, (float8)lhs.v8_0 < (float8)rhs.v8_0);
                Assert.AreEqual((lhs < rhs).v8_8, (float8)lhs.v8_8 < (float8)rhs.v8_8);

                Assert.AreEqual((lhs < lhs).v8_0, (float8)lhs.v8_0 < (float8)lhs.v8_0);
                Assert.AreEqual((lhs < lhs).v8_8, (float8)lhs.v8_8 < (float8)lhs.v8_8);

                lhs = (quarter16)0f;

                Assert.AreEqual((lhs < rhs).v8_0, (float8)lhs.v8_0 < (float8)rhs.v8_0);
                Assert.AreEqual((lhs < rhs).v8_8, (float8)lhs.v8_8 < (float8)rhs.v8_8);

                Assert.AreEqual((lhs < lhs).v8_0, (float8)lhs.v8_0 < (float8)lhs.v8_0);
                Assert.AreEqual((lhs < lhs).v8_8, (float8)lhs.v8_8 < (float8)lhs.v8_8);
            }
        }

        [Test]
        public static void LessEqual16()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter16)quarter.NaN <= (quarter16)0f).x0);
            Assert.IsFalse(((quarter16)0f <= (quarter16)quarter.NaN).x0);
            Assert.IsFalse(((quarter16)quarter.PositiveInfinity <= (quarter16)quarter.NaN).x0);
            Assert.IsFalse(((quarter16)quarter.NegativeInfinity <= (quarter16)quarter.NaN).x0);

            for (int i = 0; i < 25; i++)
            {
                quarter16 lhs = new quarter16((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));
                quarter16 rhs = new quarter16((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));

                Assert.AreEqual((lhs <= rhs).v8_0, (float8)lhs.v8_0 <= (float8)rhs.v8_0);
                Assert.AreEqual((lhs <= rhs).v8_8, (float8)lhs.v8_8 <= (float8)rhs.v8_8);

                Assert.AreEqual((lhs <= lhs).v8_0, (float8)lhs.v8_0 <= (float8)lhs.v8_0);
                Assert.AreEqual((lhs <= lhs).v8_8, (float8)lhs.v8_8 <= (float8)lhs.v8_8);

                lhs = (quarter16)0f;

                Assert.AreEqual((lhs <= rhs).v8_0, (float8)lhs.v8_0 <= (float8)rhs.v8_0);
                Assert.AreEqual((lhs <= rhs).v8_8, (float8)lhs.v8_8 <= (float8)rhs.v8_8);

                Assert.AreEqual((lhs <= lhs).v8_0, (float8)lhs.v8_0 <= (float8)lhs.v8_0);
                Assert.AreEqual((lhs <= lhs).v8_8, (float8)lhs.v8_8 <= (float8)lhs.v8_8);
            }
        }



        [Test]
        public static void ToHalf16()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter16 q = maxmath.asquarter((byte)i);

                if (IsZero(q.x0))
                {
                    Assert.AreEqual((float8)0f, (float8)((half16)q).v8_0);
                    Assert.AreEqual((float8)0f, (float8)((half16)q).v8_8);
                    continue;
                }
                if (maxmath.all(maxmath.isnan(q)))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isnan((half16)q)));
                    continue;
                }
                if (maxmath.all(q == quarter.PositiveInfinity))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isinf((half16)q)) && maxmath.all((float8)((half16)q).v8_0 > 0f) && maxmath.all((float8)((half16)q).v8_8 > 0f));
                    continue;
                }
                if (maxmath.all(q == quarter.NegativeInfinity))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isinf((half16)q)) && maxmath.all((float8)((half16)q).v8_0 < 0f) && maxmath.all((float8)((half16)q).v8_8 < 0f));
                    continue;
                }

                float lead = IsDenormalOrZero(q.x0) ? 0f : 1f;
                float mantissa = Mantissa(q.x0);

                float calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x0));
                calculated = IsPositive(q.x0) ? calculated : -calculated;

                Assert.AreEqual((half16)calculated, (half16)q);
            }
        }


        [Test]
        public static void ToByte16()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual(new byte16((byte8)(float8)(quarter8)maxmath.asquarter((byte)i), (byte8)(float8)(quarter8)maxmath.asquarter((byte)i)), (byte16)(quarter16)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToShort16()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual(new short16((short8)(float8)(quarter8)maxmath.asquarter((byte)i), (short8)(float8)(quarter8)maxmath.asquarter((byte)i)), (short16)(quarter16)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void ToSByte16()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual(new sbyte16((sbyte8)(float8)(quarter8)maxmath.asquarter((byte)i), (sbyte8)(float8)(quarter8)maxmath.asquarter((byte)i)), (sbyte16)(quarter16)maxmath.asquarter((byte)i));
                }
            }
        }

        [Test]
        public static void ToUShort16()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual(new ushort16((ushort8)(float8)(quarter8)maxmath.asquarter((byte)i), (ushort8)(float8)(quarter8)maxmath.asquarter((byte)i)), (ushort16)(quarter16)maxmath.asquarter((byte)i));
                }
            }
        }

        
        [Test]
        public static void FromHalf16()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter16 q = maxmath.asquarter((byte)i);

                if (maxmath.isnan(q.x0))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isnan((half16)q)));
                }
                else
                {
                    Assert.AreEqual(q, (quarter16)(half16)q);
                }
            }
        }
        
        [Test]
        public static void FromHalf16_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                half16 f = subnormalQuarter ? (half)rng.NextFloat(-maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS)), maxmath.asquarter(maxmath.bitmask8(quarter.MANTISSA_BITS))) 
                                           : (half)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                quarter16 q = (quarter16)f;
                quarter16 qm1 = maxmath.nextsmaller(q);
                quarter16 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(maxmath.any(maxmath.abs((float8)f.v8_0 - qm1.v8_0) < maxmath.abs((float8)f.v8_0 - q.v8_0)));
                Assert.IsFalse(maxmath.any(maxmath.abs((float8)f.v8_8 - qm1.v8_8) < maxmath.abs((float8)f.v8_8 - q.v8_8)));
                Assert.IsFalse(maxmath.any(maxmath.abs((float8)f.v8_0 - qp1.v8_0) < maxmath.abs((float8)f.v8_0 - q.v8_0)));
                Assert.IsFalse(maxmath.any(maxmath.abs((float8)f.v8_8 - qp1.v8_8) < maxmath.abs((float8)f.v8_8 - q.v8_8)));
            }
        }

        [Test]
        public static void FromByte16()
        {
            for (byte i = 0; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(byte16)i).v8_0);
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(byte16)i).v8_8);
            }

            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_0, (float8)((quarter16)(byte16)16).v8_0);
            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_8, (float8)((quarter16)(byte16)16).v8_8);
        }

        [Test]
        public static void FromShort16()
        {
            for (short i = -15; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(short16)i).v8_0);
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(short16)i).v8_8);
            }

            Assert.AreEqual((float8)((quarter16)quarter.NegativeInfinity).v8_0, (float8)((quarter16)(short16)(-16)).v8_0);
            Assert.AreEqual((float8)((quarter16)quarter.NegativeInfinity).v8_8, (float8)((quarter16)(short16)(-16)).v8_8);
            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_0, (float8)((quarter16)(short16)16).v8_0);
            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_8, (float8)((quarter16)(short16)16).v8_8);
        }


        [Test]
        public static void FromSByte16()
        {
            for (sbyte i = -15; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(sbyte16)i).v8_0);
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(sbyte16)i).v8_8);
            }

            Assert.AreEqual((float8)((quarter16)quarter.NegativeInfinity).v8_0, (float8)((quarter16)(sbyte16)(-16)).v8_0);
            Assert.AreEqual((float8)((quarter16)quarter.NegativeInfinity).v8_8, (float8)((quarter16)(sbyte16)(-16)).v8_8);
            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_0, (float8)((quarter16)(sbyte16)16).v8_0);
            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_8, (float8)((quarter16)(sbyte16)16).v8_8);
        }

        [Test]
        public static void FromUShort16()
        {
            for (ushort i = 0; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(ushort16)i).v8_0);
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(ushort16)i).v8_8);
            }

            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_0, (float8)((quarter16)(ushort16)16).v8_0);
            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_8, (float8)((quarter16)(ushort16)16).v8_8);
        }


        [Test]
        public static void Equals32()
        {
            Assert.IsFalse(maxmath.any((quarter32)quarter.NaN == (quarter32)quarter.NaN));
            Assert.IsFalse(maxmath.any((quarter32)quarter.NaN == (quarter32)(quarter)1f));

            Assert.IsTrue(maxmath.all((quarter32)maxmath.asquarter(1 << 7) == (quarter32)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(maxmath.all((quarter32)maxmath.asquarter(1 << 7) == (quarter32)(quarter)0f));
            Assert.IsTrue(maxmath.all((quarter32)(quarter)0f == (quarter32)maxmath.asquarter(1 << 7)));
            Assert.IsTrue(maxmath.all((quarter32)(quarter)0f == (quarter32)(quarter)0f));

            Assert.IsTrue(maxmath.all((quarter32)(quarter)1f == (quarter32)(quarter)1f));
        }

        [Test]
        public static void LessThan32()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter32)quarter.NaN < (quarter32)0f).x0);
            Assert.IsFalse(((quarter32)0f < (quarter32)quarter.NaN).x0);
            Assert.IsFalse(((quarter32)quarter.PositiveInfinity < (quarter32)quarter.NaN).x0);
            Assert.IsFalse(((quarter32)quarter.NegativeInfinity < (quarter32)quarter.NaN).x0);

            for (int i = 0; i < 25; i++)
            {
                quarter32 lhs = new quarter32((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));
                quarter32 rhs = new quarter32((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));

                Assert.AreEqual((lhs < rhs).v8_0,  (float8)lhs.v8_0  < (float8)rhs.v8_0);
                Assert.AreEqual((lhs < rhs).v8_8,  (float8)lhs.v8_8  < (float8)rhs.v8_8);
                Assert.AreEqual((lhs < rhs).v8_16, (float8)lhs.v8_16 < (float8)rhs.v8_16);
                Assert.AreEqual((lhs < rhs).v8_24, (float8)lhs.v8_24 < (float8)rhs.v8_24);

                Assert.AreEqual((lhs < lhs).v8_0,  (float8)lhs.v8_0  < (float8)lhs.v8_0);
                Assert.AreEqual((lhs < lhs).v8_8,  (float8)lhs.v8_8  < (float8)lhs.v8_8);
                Assert.AreEqual((lhs < lhs).v8_16, (float8)lhs.v8_16 < (float8)lhs.v8_16);
                Assert.AreEqual((lhs < lhs).v8_24, (float8)lhs.v8_24 < (float8)lhs.v8_24);

                lhs = (quarter32)0f;

                Assert.AreEqual((lhs < rhs).v8_0,  (float8)lhs.v8_0  < (float8)rhs.v8_0);
                Assert.AreEqual((lhs < rhs).v8_8,  (float8)lhs.v8_8  < (float8)rhs.v8_8);
                Assert.AreEqual((lhs < rhs).v8_16, (float8)lhs.v8_16 < (float8)rhs.v8_16);
                Assert.AreEqual((lhs < rhs).v8_24, (float8)lhs.v8_24 < (float8)rhs.v8_24);

                Assert.AreEqual((lhs < lhs).v8_0,  (float8)lhs.v8_0  < (float8)lhs.v8_0);
                Assert.AreEqual((lhs < lhs).v8_8,  (float8)lhs.v8_8  < (float8)lhs.v8_8);
                Assert.AreEqual((lhs < lhs).v8_16, (float8)lhs.v8_16 < (float8)lhs.v8_16);
                Assert.AreEqual((lhs < lhs).v8_24, (float8)lhs.v8_24 < (float8)lhs.v8_24);
            }
        }

        [Test]
        public static void LessEqual32()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(((quarter32)quarter.NaN <= (quarter32)0f).x0);
            Assert.IsFalse(((quarter32)0f <= (quarter32)quarter.NaN).x0);
            Assert.IsFalse(((quarter32)quarter.PositiveInfinity <= (quarter32)quarter.NaN).x0);
            Assert.IsFalse(((quarter32)quarter.NegativeInfinity <= (quarter32)quarter.NaN).x0);

            for (int i = 0; i < 25; i++)
            {
                quarter32 lhs = new quarter32((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));
                quarter32 rhs = new quarter32((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));

                Assert.AreEqual((lhs <= rhs).v8_0,  (float8)lhs.v8_0  <= (float8)rhs.v8_0);
                Assert.AreEqual((lhs <= rhs).v8_8,  (float8)lhs.v8_8  <= (float8)rhs.v8_8);
                Assert.AreEqual((lhs <= rhs).v8_16, (float8)lhs.v8_16 <= (float8)rhs.v8_16);
                Assert.AreEqual((lhs <= rhs).v8_24, (float8)lhs.v8_24 <= (float8)rhs.v8_24);

                Assert.AreEqual((lhs <= lhs).v8_0,  (float8)lhs.v8_0  <= (float8)lhs.v8_0);
                Assert.AreEqual((lhs <= lhs).v8_8,  (float8)lhs.v8_8  <= (float8)lhs.v8_8);
                Assert.AreEqual((lhs <= lhs).v8_16, (float8)lhs.v8_16 <= (float8)lhs.v8_16);
                Assert.AreEqual((lhs <= lhs).v8_24, (float8)lhs.v8_24 <= (float8)lhs.v8_24);

                lhs = (quarter32)0f;

                Assert.AreEqual((lhs <= rhs).v8_0,  (float8)lhs.v8_0  <= (float8)rhs.v8_0);
                Assert.AreEqual((lhs <= rhs).v8_8,  (float8)lhs.v8_8  <= (float8)rhs.v8_8);
                Assert.AreEqual((lhs <= rhs).v8_16, (float8)lhs.v8_16 <= (float8)rhs.v8_16);
                Assert.AreEqual((lhs <= rhs).v8_24, (float8)lhs.v8_24 <= (float8)rhs.v8_24);

                Assert.AreEqual((lhs <= lhs).v8_0,  (float8)lhs.v8_0  <= (float8)lhs.v8_0);
                Assert.AreEqual((lhs <= lhs).v8_8,  (float8)lhs.v8_8  <= (float8)lhs.v8_8);
                Assert.AreEqual((lhs <= lhs).v8_16, (float8)lhs.v8_16 <= (float8)lhs.v8_16);
                Assert.AreEqual((lhs <= lhs).v8_24, (float8)lhs.v8_24 <= (float8)lhs.v8_24);
            }
        }



        [Test]
        public static void ToByte32()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i))
                 && 0 <= maxmath.asquarter((byte)i))
                {
                    Assert.AreEqual(new byte32((byte8)(float8)(quarter8)maxmath.asquarter((byte)i), (byte8)(float8)(quarter8)maxmath.asquarter((byte)i), (byte8)(float8)(quarter8)maxmath.asquarter((byte)i), (byte8)(float8)(quarter8)maxmath.asquarter((byte)i)), (byte32)(quarter32)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void ToSByte32()
        {
            for (int i = 0; i < 256; i++)
            {
                if (!maxmath.isnan(maxmath.asquarter((byte)i))
                 && !maxmath.isinf(maxmath.asquarter((byte)i)))
                {
                    Assert.AreEqual(new sbyte32((sbyte8)(float8)(quarter8)maxmath.asquarter((byte)i), (sbyte8)(float8)(quarter8)maxmath.asquarter((byte)i), (sbyte8)(float8)(quarter8)maxmath.asquarter((byte)i), (sbyte8)(float8)(quarter8)maxmath.asquarter((byte)i)), (sbyte32)(quarter32)maxmath.asquarter((byte)i));
                }
            }
        }


        [Test]
        public static void FromByte32()
        {
            for (byte i = 0; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)((quarter32)(byte32)i).v8_0);
                Assert.AreEqual((float8)(float)i, (float8)((quarter32)(byte32)i).v8_8);
                Assert.AreEqual((float8)(float)i, (float8)((quarter32)(byte32)i).v8_16);
                Assert.AreEqual((float8)(float)i, (float8)((quarter32)(byte32)i).v8_24);
            }

            Assert.AreEqual((float8)((quarter32)quarter.PositiveInfinity).v8_0, (float8)((quarter32)(byte32)32).v8_0);
            Assert.AreEqual((float8)((quarter32)quarter.PositiveInfinity).v8_8, (float8)((quarter32)(byte32)32).v8_8);
            Assert.AreEqual((float8)((quarter32)quarter.PositiveInfinity).v8_16, (float8)((quarter32)(byte32)32).v8_16);
            Assert.AreEqual((float8)((quarter32)quarter.PositiveInfinity).v8_24, (float8)((quarter32)(byte32)32).v8_24);
        }


        [Test]
        public static void FromSByte32()
        {
            for (short i = -15; i < 16; i++)
            {
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(sbyte16)i).v8_0);
                Assert.AreEqual((float8)(float)i, (float8)((quarter16)(sbyte16)i).v8_8);
            }

            Assert.AreEqual((float8)((quarter16)quarter.NegativeInfinity).v8_0, (float8)((quarter16)(sbyte16)(-16)).v8_0);
            Assert.AreEqual((float8)((quarter16)quarter.NegativeInfinity).v8_8, (float8)((quarter16)(sbyte16)(-16)).v8_8);
            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_0, (float8)((quarter16)(sbyte16)16).v8_0);
            Assert.AreEqual((float8)((quarter16)quarter.PositiveInfinity).v8_8, (float8)((quarter16)(sbyte16)16).v8_8);
        }
    }
}