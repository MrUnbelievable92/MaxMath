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

            Assert.IsTrue(new quarter(1 << 7) == new quarter(1 << 7));
            Assert.IsTrue(new quarter(1 << 7) == (quarter)0f);
            Assert.IsTrue((quarter)0f == new quarter(1 << 7));
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
            Assert.IsFalse((quarter)new quarter((byte)(1 << 7)) != (quarter)new quarter((byte)(1 << 7)));
            Assert.IsFalse((quarter)new quarter((byte)(1 << 7)) != new quarter(0));
            Assert.IsFalse((quarter)new quarter(0) != (quarter)new quarter((byte)(1 << 7)));
            Assert.IsFalse(new quarter(0) != new quarter(0));
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
                quarter q = new quarter((byte)i);

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
                quarter q = new quarter((byte)i);

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
                quarter q = new quarter((byte)i);

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
                if (!maxmath.isnan(new quarter((byte)i)) 
                 && !maxmath.isinf(new quarter((byte)i))
                 && 0 <= new quarter((byte)i))
                {
                    Assert.AreEqual((byte)(float)new quarter((byte)i), (byte)new quarter((byte)i));
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
                if (!maxmath.isnan(new quarter((byte)i)) 
                 && !maxmath.isinf(new quarter((byte)i)))
                {
                    Assert.AreEqual((sbyte)(float)new quarter((byte)i), (sbyte)new quarter((byte)i));
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
                quarter q = new quarter((byte)i);

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
        public static void FromFloat()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter q = new quarter((byte)i);

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
        public static void FromDouble()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter q = new quarter((byte)i);

                if (maxmath.isnan(q))
                {
                    Assert.IsNaN((double)q);
                }
                else
                {
                    try
                    {
                    Assert.AreEqual(q, (quarter)(double)q);
                    }
                    catch
                    {
                        int j = 0;

                        float f = q;

                        string s = DevTools.Dump.Bits(q);
                        string s1 = DevTools.Dump.Bits(f);

                        j++;
                        j++;
                        j++;
                        j++;
                        j++;
                        j++;
                        j++;
                    }
                }
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

            Assert.IsTrue(math.all((quarter2)new quarter(1 << 7) == (quarter2)new quarter(1 << 7)));
            Assert.IsTrue(math.all((quarter2)new quarter(1 << 7) == (quarter2)(quarter)0f));
            Assert.IsTrue(math.all((quarter2)(quarter)0f == (quarter2)new quarter(1 << 7)));
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
            Assert.IsFalse(math.any((quarter2)new quarter((byte)(1 << 7)) != (quarter2)new quarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter2)new quarter((byte)(1 << 7)) != (quarter2)0f));
            Assert.IsFalse(math.any((quarter2)0f != (quarter2)new quarter((byte)(1 << 7))));
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
                quarter2 q = new quarter((byte)i);

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

                float2 lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float2 mantissa = Mantissa(q.x);

                float2 calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((half2)calculated, (half2)q);
            }
        }

        [Test]
        public static void ToFloat2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = new quarter((byte)i);

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

                float2 lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float2 mantissa = Mantissa(q.x);

                float2 calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((float2)calculated, (float2)q);
            }
        }

        [Test]
        public static void ToDouble2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = new quarter((byte)i);

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
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((byte2)(byte)i, (byte2)(quarter2)(quarter)i);
            }
        }

        [Test]
        public static void ToShort2()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((short2)(short)i, (short2)(quarter2)(quarter)i);
            }
        }

        [Test]
        public static void ToInt2()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((int2)(int)i, (int2)(quarter2)(quarter)i);
            }
        }

        [Test]
        public static void ToLong2()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((long2)(long)i, (long2)(quarter2)(quarter)i);
            }
        }


        [Test]
        public static void ToSByte2()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((sbyte2)(sbyte)i, (sbyte2)(quarter2)(quarter)i);
            }
        }

        [Test]
        public static void ToUShort2()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ushort2)(ushort)i, (ushort2)(quarter2)(quarter)i);
            }
        }

        [Test]
        public static void ToUInt2()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((uint2)(uint)i, (uint2)(quarter2)(quarter)i);
            }
        }

        [Test]
        public static void ToULong2()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ulong2)(ulong)i, (ulong2)(quarter2)(quarter)i);
            }
        }


        [Test]
        public static void FromHalf2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = new quarter((byte)i);

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
        public static void FromFloat2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = new quarter((byte)i);

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
        public static void FromDouble2()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter2 q = new quarter((byte)i);

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
            
            Assert.IsTrue(math.all((quarter3)new quarter(1 << 7) == (quarter3)new quarter(1 << 7)));
            Assert.IsTrue(math.all((quarter3)new quarter(1 << 7) == (quarter3)(quarter)0f));
            Assert.IsTrue(math.all((quarter3)(quarter)0f == (quarter3)new quarter(1 << 7)));
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
            Assert.IsFalse(math.any((quarter3)new quarter((byte)(1 << 7)) != (quarter3)new quarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter3)new quarter((byte)(1 << 7)) != (quarter3)0f));
            Assert.IsFalse(math.any((quarter3)0f != (quarter3)new quarter((byte)(1 << 7))));
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
                quarter3 q = new quarter((byte)i);

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

                float3 lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float3 mantissa = Mantissa(q.x);

                float3 calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((half3)calculated, (half3)q);
            }
        }

        [Test]
        public static void ToFloat3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = new quarter((byte)i);

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

                float3 lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float3 mantissa = Mantissa(q.x);

                float3 calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((float3)calculated, (float3)q);
            }
        }

        [Test]
        public static void ToDouble3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = new quarter((byte)i);

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
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((byte3)(byte)i, (byte3)(quarter3)(quarter)i);
            }
        }

        [Test]
        public static void ToShort3()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((short3)(short)i, (short3)(quarter3)(quarter)i);
            }
        }

        [Test]
        public static void ToInt3()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((int3)(int)i, (int3)(quarter3)(quarter)i);
            }
        }

        [Test]
        public static void ToLong3()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((long3)(long)i, (long3)(quarter3)(quarter)i);
            }
        }


        [Test]
        public static void ToSByte3()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((sbyte3)(sbyte)i, (sbyte3)(quarter3)(quarter)i);
            }
        }

        [Test]
        public static void ToUShort3()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ushort3)(ushort)i, (ushort3)(quarter3)(quarter)i);
            }
        }

        [Test]
        public static void ToUInt3()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((uint3)(uint)i, (uint3)(quarter3)(quarter)i);
            }
        }

        [Test]
        public static void ToULong3()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ulong3)(ulong)i, (ulong3)(quarter3)(quarter)i);
            }
        }


        [Test]
        public static void FromHalf3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = new quarter((byte)i);

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
        public static void FromFloat3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = new quarter((byte)i);

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
        public static void FromDouble3()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter3 q = new quarter((byte)i);

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
            
            Assert.IsTrue(math.all((quarter4)new quarter(1 << 7) == (quarter4)new quarter(1 << 7)));
            Assert.IsTrue(math.all((quarter4)new quarter(1 << 7) == (quarter4)(quarter)0f));
            Assert.IsTrue(math.all((quarter4)(quarter)0f == (quarter4)new quarter(1 << 7)));
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
            Assert.IsFalse(math.any((quarter4)new quarter((byte)(1 << 7)) != (quarter4)new quarter((byte)(1 << 7))));
            Assert.IsFalse(math.any((quarter4)new quarter((byte)(1 << 7)) != (quarter4)0f));
            Assert.IsFalse(math.any((quarter4)0f != (quarter4)new quarter((byte)(1 << 7))));
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
                quarter4 q = new quarter((byte)i);

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

                float4 lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float4 mantissa = Mantissa(q.x);

                float4 calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((half4)calculated, (half4)q);
            }
        }

        [Test]
        public static void ToFloat4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = new quarter((byte)i);

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

                float4 lead = IsDenormalOrZero(q.x) ? 0f : 1f;
                float4 mantissa = Mantissa(q.x);

                float4 calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x));
                calculated = IsPositive(q.x) ? calculated : -calculated;

                Assert.AreEqual((float4)calculated, (float4)q);
            }
        }

        [Test]
        public static void ToDouble4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = new quarter((byte)i);

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
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((byte4)(byte)i, (byte4)(quarter4)(quarter)i);
            }
        }

        [Test]
        public static void ToShort4()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((short4)(short)i, (short4)(quarter4)(quarter)i);
            }
        }

        [Test]
        public static void ToInt4()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((int4)(int)i, (int4)(quarter4)(quarter)i);
            }
        }

        [Test]
        public static void ToLong4()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((long4)(long)i, (long4)(quarter4)(quarter)i);
            }
        }


        [Test]
        public static void ToSByte4()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((sbyte4)(sbyte)i, (sbyte4)(quarter4)(quarter)i);
            }
        }

        [Test]
        public static void ToUShort4()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ushort4)(ushort)i, (ushort4)(quarter4)(quarter)i);
            }
        }

        [Test]
        public static void ToUInt4()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((uint4)(uint)i, (uint4)(quarter4)(quarter)i);
            }
        }

        [Test]
        public static void ToULong4()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ulong4)(ulong)i, (ulong4)(quarter4)(quarter)i);
            }
        }


        [Test]
        public static void FromHalf4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = new quarter((byte)i);

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
        public static void FromFloat4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = new quarter((byte)i);

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
        public static void FromDouble4()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter4 q = new quarter((byte)i);

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
            
            Assert.IsTrue(maxmath.all((quarter8)new quarter(1 << 7) == (quarter8)new quarter(1 << 7)));
            Assert.IsTrue(maxmath.all((quarter8)new quarter(1 << 7) == (quarter8)(quarter)0f));
            Assert.IsTrue(maxmath.all((quarter8)(quarter)0f == (quarter8)new quarter(1 << 7)));
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
            Assert.IsFalse(maxmath.any((quarter8)new quarter((byte)(1 << 7)) != (quarter8)new quarter((byte)(1 << 7))));
            Assert.IsFalse(maxmath.any((quarter8)new quarter((byte)(1 << 7)) != (quarter8)0f));
            Assert.IsFalse(maxmath.any((quarter8)0f != (quarter8)new quarter((byte)(1 << 7))));
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
                quarter8 q = new quarter((byte)i);

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

                float8 lead = IsDenormalOrZero(q.x0) ? 0f : 1f;
                float8 mantissa = Mantissa(q.x0);

                float8 calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x0));
                calculated = IsPositive(q.x0) ? calculated : -calculated;

                Assert.AreEqual((half8)calculated, (half8)q);
            }
        }

        [Test]
        public static void ToFloat8()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter8 q = new quarter((byte)i);

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

                float8 lead = IsDenormalOrZero(q.x0) ? 0f : 1f;
                float8 mantissa = Mantissa(q.x0);

                float8 calculated = (lead + mantissa) * math.pow(2f, Exponent(q.x0));
                calculated = IsPositive(q.x0) ? calculated : -calculated;

                Assert.AreEqual((float8)calculated, (float8)q);
            }
        }


        [Test]
        public static void ToByte8()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((byte8)(byte)i, (byte8)(quarter8)(quarter)i);
            }
        }

        [Test]
        public static void ToShort8()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((short8)(short)i, (short8)(quarter8)(quarter)i);
            }
        }

        [Test]
        public static void ToInt8()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((int8)(int)i, (int8)(quarter8)(quarter)i);
            }
        }


        [Test]
        public static void ToSByte8()
        {
            for (float i = -15f; i < 16f; i++)
            {
                Assert.AreEqual((sbyte8)(sbyte)i, (sbyte8)(quarter8)(quarter)i);
            }
        }

        [Test]
        public static void ToUShort8()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((ushort8)(ushort)i, (ushort8)(quarter8)(quarter)i);
            }
        }

        [Test]
        public static void ToUInt8()
        {
            for (float i = 0f; i < 16f; i++)
            {
                Assert.AreEqual((uint8)(uint)i, (uint8)(quarter8)(quarter)i);
            }
        }


        [Test]
        public static void FromHalf8()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter8 q = new quarter((byte)i);

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
        public static void FromFloat8()
        {
            for (int i = 0; i < 256; i++)
            {
                quarter8 q = new quarter((byte)i);

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
    }
}