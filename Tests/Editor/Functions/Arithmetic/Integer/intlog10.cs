using System.Collections.Generic;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_intlog10
    {
        private static UInt128 __intlog10(UInt128 x)
        {
            List<UInt128> tens = new List<UInt128>();

            UInt128 ten = 10;
            while (true)
            {
                if (ten == UInt128.MaxValue)
                {
                    break;
                }
                else
                {
                    tens.Add(ten);
                    ten = maxmath.mulsaturated(ten, 10);
                }
            }

            uint result = 0;

            for (int i = 0; i < tens.Count; i++)
            {
                if (x < tens[i])
                {
                    break;
                }

                result++;
            }

            return result;
        }

        private static Int128 __intlog10(Int128 x)
        {
            List<Int128> tens = new List<Int128>();

            Int128 ten = 10;
            while (true)
            {
                if (ten == Int128.MaxValue)
                {
                    break;
                }
                else
                {
                    tens.Add(ten);
                    ten = maxmath.mulsaturated(ten, 10);
                }
            }

            uint result = 0;

            for (int i = 0; i < tens.Count; i++)
            {
                if (x < tens[i])
                {
                    break;
                }

                result++;
            }

            return result;
        }

        [Test]
        public static void _UInt128()
        {
            Assert.AreEqual(0, maxmath.intlog10(0));
            Assert.AreEqual(0, maxmath.intlog10(9));
            Assert.AreEqual(1, maxmath.intlog10(10));
            Assert.AreEqual(1, maxmath.intlog10(11));
            Assert.AreEqual(1, maxmath.intlog10(99));
            Assert.AreEqual(2, maxmath.intlog10(100));
            Assert.AreEqual(2, maxmath.intlog10(101));
            Assert.AreEqual(2, maxmath.intlog10(999));
            Assert.AreEqual(3, maxmath.intlog10(1000));
            Assert.AreEqual(3, maxmath.intlog10(1001));
            Assert.AreEqual(3, maxmath.intlog10(9999));
            Assert.AreEqual(4, maxmath.intlog10(10000));
            Assert.AreEqual(4, maxmath.intlog10(10001));
            Assert.AreEqual(4, maxmath.intlog10(99999));
            Assert.AreEqual(5, maxmath.intlog10(100000));
            Assert.AreEqual(5, maxmath.intlog10(100001));
            Assert.AreEqual(5, maxmath.intlog10(999999));
            Assert.AreEqual(6, maxmath.intlog10(1000000));
            Assert.AreEqual(6, maxmath.intlog10(1000001));
            Assert.AreEqual(6, maxmath.intlog10(9999999));
            Assert.AreEqual(7, maxmath.intlog10(10000000));
            Assert.AreEqual(7, maxmath.intlog10(10000001));
            Assert.AreEqual(7, maxmath.intlog10(99999999));
            Assert.AreEqual(8, maxmath.intlog10(100000000));
            Assert.AreEqual(8, maxmath.intlog10(100000001));
            Assert.AreEqual(8, maxmath.intlog10(999999999));
            Assert.AreEqual(9, maxmath.intlog10(1000000000));
            Assert.AreEqual(9, maxmath.intlog10(1000000001));
            Assert.AreEqual(9, maxmath.intlog10(9999999999));
            Assert.AreEqual(10, maxmath.intlog10(10000000000));
            Assert.AreEqual(10, maxmath.intlog10(10000000001));
            Assert.AreEqual(10, maxmath.intlog10(99999999999));
            Assert.AreEqual(11, maxmath.intlog10(100000000000));
            Assert.AreEqual(11, maxmath.intlog10(100000000001));
            Assert.AreEqual(11, maxmath.intlog10(999999999999));
            Assert.AreEqual(12, maxmath.intlog10(1000000000000));
            Assert.AreEqual(12, maxmath.intlog10(1000000000001));
            Assert.AreEqual(12, maxmath.intlog10(9999999999999));
            Assert.AreEqual(13, maxmath.intlog10(10000000000000));
            Assert.AreEqual(13, maxmath.intlog10(10000000000001));
            Assert.AreEqual(13, maxmath.intlog10(99999999999999));
            Assert.AreEqual(14, maxmath.intlog10(100000000000000));
            Assert.AreEqual(14, maxmath.intlog10(100000000000001));
            Assert.AreEqual(14, maxmath.intlog10(999999999999999));
            Assert.AreEqual(15, maxmath.intlog10(1000000000000000));
            Assert.AreEqual(15, maxmath.intlog10(1000000000000001));
            Assert.AreEqual(15, maxmath.intlog10(9999999999999999));
            Assert.AreEqual(16, maxmath.intlog10(10000000000000000));
            Assert.AreEqual(16, maxmath.intlog10(10000000000000001));
            Assert.AreEqual(16, maxmath.intlog10(99999999999999999));
            Assert.AreEqual(17, maxmath.intlog10(100000000000000000));
            Assert.AreEqual(17, maxmath.intlog10(100000000000000001));
            Assert.AreEqual(17, maxmath.intlog10(999999999999999999));
            Assert.AreEqual(18, maxmath.intlog10(1000000000000000000));
            Assert.AreEqual(18, maxmath.intlog10(1000000000000000001));
            Assert.AreEqual(18, maxmath.intlog10(9999999999999999999));
            Assert.AreEqual(19, maxmath.intlog10(10000000000000000000));
            Assert.AreEqual(19, maxmath.intlog10(10000000000000000001));
            Assert.AreEqual(19, maxmath.intlog10(ulong.MaxValue));
            Assert.AreEqual((UInt128)19, maxmath.intlog10((UInt128)"99999999999999999999"));
            Assert.AreEqual((UInt128)20, maxmath.intlog10((UInt128)"100000000000000000000"));
            Assert.AreEqual((UInt128)20, maxmath.intlog10((UInt128)"100000000000000000001"));
            Assert.AreEqual((UInt128)20, maxmath.intlog10((UInt128)"999999999999999999999"));
            Assert.AreEqual((UInt128)21, maxmath.intlog10((UInt128)"1000000000000000000000"));
            Assert.AreEqual((UInt128)21, maxmath.intlog10((UInt128)"1000000000000000000001"));
            Assert.AreEqual((UInt128)21, maxmath.intlog10((UInt128)"9999999999999999999999"));
            Assert.AreEqual((UInt128)22, maxmath.intlog10((UInt128)"10000000000000000000000"));
            Assert.AreEqual((UInt128)22, maxmath.intlog10((UInt128)"10000000000000000000001"));
            Assert.AreEqual((UInt128)22, maxmath.intlog10((UInt128)"99999999999999999999999"));
            Assert.AreEqual((UInt128)23, maxmath.intlog10((UInt128)"100000000000000000000000"));
            Assert.AreEqual((UInt128)23, maxmath.intlog10((UInt128)"100000000000000000000001"));
            Assert.AreEqual((UInt128)23, maxmath.intlog10((UInt128)"999999999999999999999999"));
            Assert.AreEqual((UInt128)24, maxmath.intlog10((UInt128)"1000000000000000000000000"));
            Assert.AreEqual((UInt128)24, maxmath.intlog10((UInt128)"1000000000000000000000001"));
            Assert.AreEqual((UInt128)24, maxmath.intlog10((UInt128)"9999999999999999999999999"));
            Assert.AreEqual((UInt128)25, maxmath.intlog10((UInt128)"10000000000000000000000000"));
            Assert.AreEqual((UInt128)25, maxmath.intlog10((UInt128)"10000000000000000000000001"));
            Assert.AreEqual((UInt128)25, maxmath.intlog10((UInt128)"99999999999999999999999999"));
            Assert.AreEqual((UInt128)26, maxmath.intlog10((UInt128)"100000000000000000000000000"));
            Assert.AreEqual((UInt128)26, maxmath.intlog10((UInt128)"100000000000000000000000001"));
            Assert.AreEqual((UInt128)26, maxmath.intlog10((UInt128)"999999999999999999999999999"));
            Assert.AreEqual((UInt128)27, maxmath.intlog10((UInt128)"1000000000000000000000000000"));
            Assert.AreEqual((UInt128)27, maxmath.intlog10((UInt128)"1000000000000000000000000001"));
            Assert.AreEqual((UInt128)27, maxmath.intlog10((UInt128)"9999999999999999999999999999"));
            Assert.AreEqual((UInt128)28, maxmath.intlog10((UInt128)"10000000000000000000000000000"));
            Assert.AreEqual((UInt128)28, maxmath.intlog10((UInt128)"10000000000000000000000000001"));
            Assert.AreEqual((UInt128)28, maxmath.intlog10((UInt128)"99999999999999999999999999999"));
            Assert.AreEqual((UInt128)29, maxmath.intlog10((UInt128)"100000000000000000000000000000"));
            Assert.AreEqual((UInt128)29, maxmath.intlog10((UInt128)"100000000000000000000000000001"));
            Assert.AreEqual((UInt128)29, maxmath.intlog10((UInt128)"999999999999999999999999999999"));
            Assert.AreEqual((UInt128)30, maxmath.intlog10((UInt128)"1000000000000000000000000000000"));
            Assert.AreEqual((UInt128)30, maxmath.intlog10((UInt128)"1000000000000000000000000000001"));
            Assert.AreEqual((UInt128)30, maxmath.intlog10((UInt128)"9999999999999999999999999999999"));
            Assert.AreEqual((UInt128)31, maxmath.intlog10((UInt128)"10000000000000000000000000000000"));
            Assert.AreEqual((UInt128)31, maxmath.intlog10((UInt128)"10000000000000000000000000000001"));
            Assert.AreEqual((UInt128)31, maxmath.intlog10((UInt128)"99999999999999999999999999999999"));
            Assert.AreEqual((UInt128)32, maxmath.intlog10((UInt128)"100000000000000000000000000000000"));
            Assert.AreEqual((UInt128)32, maxmath.intlog10((UInt128)"100000000000000000000000000000001"));
            Assert.AreEqual((UInt128)32, maxmath.intlog10((UInt128)"999999999999999999999999999999999"));
            Assert.AreEqual((UInt128)33, maxmath.intlog10((UInt128)"1000000000000000000000000000000000"));
            Assert.AreEqual((UInt128)33, maxmath.intlog10((UInt128)"1000000000000000000000000000000001"));
            Assert.AreEqual((UInt128)33, maxmath.intlog10((UInt128)"9999999999999999999999999999999999"));
            Assert.AreEqual((UInt128)34, maxmath.intlog10((UInt128)"10000000000000000000000000000000000"));
            Assert.AreEqual((UInt128)34, maxmath.intlog10((UInt128)"10000000000000000000000000000000001"));
            Assert.AreEqual((UInt128)34, maxmath.intlog10((UInt128)"99999999999999999999999999999999999"));
            Assert.AreEqual((UInt128)35, maxmath.intlog10((UInt128)"100000000000000000000000000000000000"));
            Assert.AreEqual((UInt128)35, maxmath.intlog10((UInt128)"100000000000000000000000000000000001"));
            Assert.AreEqual((UInt128)35, maxmath.intlog10((UInt128)"999999999999999999999999999999999999"));
            Assert.AreEqual((UInt128)36, maxmath.intlog10((UInt128)"1000000000000000000000000000000000000"));
            Assert.AreEqual((UInt128)36, maxmath.intlog10((UInt128)"1000000000000000000000000000000000001"));
            Assert.AreEqual((UInt128)36, maxmath.intlog10((UInt128)"9999999999999999999999999999999999999"));
            Assert.AreEqual((UInt128)37, maxmath.intlog10((UInt128)"10000000000000000000000000000000000000"));
            Assert.AreEqual((UInt128)37, maxmath.intlog10((UInt128)"10000000000000000000000000000000000001"));
            Assert.AreEqual((UInt128)37, maxmath.intlog10((UInt128)"99999999999999999999999999999999999999"));
            Assert.AreEqual((UInt128)38, maxmath.intlog10((UInt128)"100000000000000000000000000000000000000"));
            Assert.AreEqual((UInt128)38, maxmath.intlog10((UInt128)"100000000000000000000000000000000000001"));
            Assert.AreEqual((UInt128)38, maxmath.intlog10(UInt128.MaxValue));
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 test = rng.NextUInt128();

                Assert.AreEqual(maxmath.intlog10(test), __intlog10(test));
            }

            for (int i = 0; i < 128; i++)
            {
                UInt128 pow2 = (UInt128)1ul << i;

                Assert.AreEqual(maxmath.intlog10(pow2), __intlog10(pow2));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 test = rng.NextInt128(0, Int128.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), __intlog10(test));
            }

            for (int i = 0; i < 127; i++)
            {
                Int128 pow2 = (Int128)1ul << i;

                Assert.AreEqual(maxmath.intlog10(pow2), __intlog10(pow2));
            }
        }


        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte2 test = rng.NextByte2();

                Assert.AreEqual(maxmath.intlog10(test), new byte2((byte)__intlog10((UInt128)test.x),
                                                                  (byte)__intlog10((UInt128)test.y)));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte3 test = rng.NextByte3();

                Assert.AreEqual(maxmath.intlog10(test), new byte3((byte)__intlog10((UInt128)test.x),
                                                                  (byte)__intlog10((UInt128)test.y),
                                                                  (byte)__intlog10((UInt128)test.z)));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte4 test = rng.NextByte4();

                Assert.AreEqual(maxmath.intlog10(test), new byte4((byte)__intlog10((UInt128)test.x),
                                                                  (byte)__intlog10((UInt128)test.y),
                                                                  (byte)__intlog10((UInt128)test.z),
                                                                  (byte)__intlog10((UInt128)test.w)));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte8 test = rng.NextByte8();

                Assert.AreEqual(maxmath.intlog10(test), new byte8((byte)__intlog10((UInt128)test.x0),
                                                                  (byte)__intlog10((UInt128)test.x1),
                                                                  (byte)__intlog10((UInt128)test.x2),
                                                                  (byte)__intlog10((UInt128)test.x3),
                                                                  (byte)__intlog10((UInt128)test.x4),
                                                                  (byte)__intlog10((UInt128)test.x5),
                                                                  (byte)__intlog10((UInt128)test.x6),
                                                                  (byte)__intlog10((UInt128)test.x7)));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte16 test = rng.NextByte16();

                Assert.AreEqual(maxmath.intlog10(test), new byte16((byte)__intlog10((UInt128)test.x0),
                                                                   (byte)__intlog10((UInt128)test.x1),
                                                                   (byte)__intlog10((UInt128)test.x2),
                                                                   (byte)__intlog10((UInt128)test.x3),
                                                                   (byte)__intlog10((UInt128)test.x4),
                                                                   (byte)__intlog10((UInt128)test.x5),
                                                                   (byte)__intlog10((UInt128)test.x6),
                                                                   (byte)__intlog10((UInt128)test.x7),
                                                                   (byte)__intlog10((UInt128)test.x8),
                                                                   (byte)__intlog10((UInt128)test.x9),
                                                                   (byte)__intlog10((UInt128)test.x10),
                                                                   (byte)__intlog10((UInt128)test.x11),
                                                                   (byte)__intlog10((UInt128)test.x12),
                                                                   (byte)__intlog10((UInt128)test.x13),
                                                                   (byte)__intlog10((UInt128)test.x14),
                                                                   (byte)__intlog10((UInt128)test.x15)));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte32 test = rng.NextByte32();

                Assert.AreEqual(maxmath.intlog10(test), new byte32((byte)__intlog10((UInt128)test.x0),
                                                                   (byte)__intlog10((UInt128)test.x1),
                                                                   (byte)__intlog10((UInt128)test.x2),
                                                                   (byte)__intlog10((UInt128)test.x3),
                                                                   (byte)__intlog10((UInt128)test.x4),
                                                                   (byte)__intlog10((UInt128)test.x5),
                                                                   (byte)__intlog10((UInt128)test.x6),
                                                                   (byte)__intlog10((UInt128)test.x7),
                                                                   (byte)__intlog10((UInt128)test.x8),
                                                                   (byte)__intlog10((UInt128)test.x9),
                                                                   (byte)__intlog10((UInt128)test.x10),
                                                                   (byte)__intlog10((UInt128)test.x11),
                                                                   (byte)__intlog10((UInt128)test.x12),
                                                                   (byte)__intlog10((UInt128)test.x13),
                                                                   (byte)__intlog10((UInt128)test.x14),
                                                                   (byte)__intlog10((UInt128)test.x15),
                                                                   (byte)__intlog10((UInt128)test.x16),
                                                                   (byte)__intlog10((UInt128)test.x17),
                                                                   (byte)__intlog10((UInt128)test.x18),
                                                                   (byte)__intlog10((UInt128)test.x19),
                                                                   (byte)__intlog10((UInt128)test.x20),
                                                                   (byte)__intlog10((UInt128)test.x21),
                                                                   (byte)__intlog10((UInt128)test.x22),
                                                                   (byte)__intlog10((UInt128)test.x23),
                                                                   (byte)__intlog10((UInt128)test.x24),
                                                                   (byte)__intlog10((UInt128)test.x25),
                                                                   (byte)__intlog10((UInt128)test.x26),
                                                                   (byte)__intlog10((UInt128)test.x27),
                                                                   (byte)__intlog10((UInt128)test.x28),
                                                                   (byte)__intlog10((UInt128)test.x29),
                                                                   (byte)__intlog10((UInt128)test.x30),
                                                                   (byte)__intlog10((UInt128)test.x31)));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 test = rng.NextSByte2(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new sbyte2((sbyte)__intlog10((UInt128)test.x),
                                                                  (sbyte)__intlog10((UInt128)test.y)));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 test = rng.NextSByte3(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new sbyte3((sbyte)__intlog10((UInt128)test.x),
                                                                  (sbyte)__intlog10((UInt128)test.y),
                                                                  (sbyte)__intlog10((UInt128)test.z)));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 test = rng.NextSByte4(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new sbyte4((sbyte)__intlog10((UInt128)test.x),
                                                                  (sbyte)__intlog10((UInt128)test.y),
                                                                  (sbyte)__intlog10((UInt128)test.z),
                                                                  (sbyte)__intlog10((UInt128)test.w)));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 test = rng.NextSByte8(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new sbyte8((sbyte)__intlog10((UInt128)test.x0),
                                                                  (sbyte)__intlog10((UInt128)test.x1),
                                                                  (sbyte)__intlog10((UInt128)test.x2),
                                                                  (sbyte)__intlog10((UInt128)test.x3),
                                                                  (sbyte)__intlog10((UInt128)test.x4),
                                                                  (sbyte)__intlog10((UInt128)test.x5),
                                                                  (sbyte)__intlog10((UInt128)test.x6),
                                                                  (sbyte)__intlog10((UInt128)test.x7)));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte16 test = rng.NextSByte16(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new sbyte16((sbyte)__intlog10((UInt128)test.x0),
                                                                   (sbyte)__intlog10((UInt128)test.x1),
                                                                   (sbyte)__intlog10((UInt128)test.x2),
                                                                   (sbyte)__intlog10((UInt128)test.x3),
                                                                   (sbyte)__intlog10((UInt128)test.x4),
                                                                   (sbyte)__intlog10((UInt128)test.x5),
                                                                   (sbyte)__intlog10((UInt128)test.x6),
                                                                   (sbyte)__intlog10((UInt128)test.x7),
                                                                   (sbyte)__intlog10((UInt128)test.x8),
                                                                   (sbyte)__intlog10((UInt128)test.x9),
                                                                   (sbyte)__intlog10((UInt128)test.x10),
                                                                   (sbyte)__intlog10((UInt128)test.x11),
                                                                   (sbyte)__intlog10((UInt128)test.x12),
                                                                   (sbyte)__intlog10((UInt128)test.x13),
                                                                   (sbyte)__intlog10((UInt128)test.x14),
                                                                   (sbyte)__intlog10((UInt128)test.x15)));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte32 test = rng.NextSByte32(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new sbyte32((sbyte)__intlog10((UInt128)test.x0),
                                                                   (sbyte)__intlog10((UInt128)test.x1),
                                                                   (sbyte)__intlog10((UInt128)test.x2),
                                                                   (sbyte)__intlog10((UInt128)test.x3),
                                                                   (sbyte)__intlog10((UInt128)test.x4),
                                                                   (sbyte)__intlog10((UInt128)test.x5),
                                                                   (sbyte)__intlog10((UInt128)test.x6),
                                                                   (sbyte)__intlog10((UInt128)test.x7),
                                                                   (sbyte)__intlog10((UInt128)test.x8),
                                                                   (sbyte)__intlog10((UInt128)test.x9),
                                                                   (sbyte)__intlog10((UInt128)test.x10),
                                                                   (sbyte)__intlog10((UInt128)test.x11),
                                                                   (sbyte)__intlog10((UInt128)test.x12),
                                                                   (sbyte)__intlog10((UInt128)test.x13),
                                                                   (sbyte)__intlog10((UInt128)test.x14),
                                                                   (sbyte)__intlog10((UInt128)test.x15),
                                                                   (sbyte)__intlog10((UInt128)test.x16),
                                                                   (sbyte)__intlog10((UInt128)test.x17),
                                                                   (sbyte)__intlog10((UInt128)test.x18),
                                                                   (sbyte)__intlog10((UInt128)test.x19),
                                                                   (sbyte)__intlog10((UInt128)test.x20),
                                                                   (sbyte)__intlog10((UInt128)test.x21),
                                                                   (sbyte)__intlog10((UInt128)test.x22),
                                                                   (sbyte)__intlog10((UInt128)test.x23),
                                                                   (sbyte)__intlog10((UInt128)test.x24),
                                                                   (sbyte)__intlog10((UInt128)test.x25),
                                                                   (sbyte)__intlog10((UInt128)test.x26),
                                                                   (sbyte)__intlog10((UInt128)test.x27),
                                                                   (sbyte)__intlog10((UInt128)test.x28),
                                                                   (sbyte)__intlog10((UInt128)test.x29),
                                                                   (sbyte)__intlog10((UInt128)test.x30),
                                                                   (sbyte)__intlog10((UInt128)test.x31)));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 test = rng.NextUShort2();

                Assert.AreEqual(maxmath.intlog10(test), new ushort2((ushort)__intlog10((UInt128)test.x),
                                                                  (ushort)__intlog10((UInt128)test.y)));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 test = rng.NextUShort3();

                Assert.AreEqual(maxmath.intlog10(test), new ushort3((ushort)__intlog10((UInt128)test.x),
                                                                  (ushort)__intlog10((UInt128)test.y),
                                                                  (ushort)__intlog10((UInt128)test.z)));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 test = rng.NextUShort4();

                Assert.AreEqual(maxmath.intlog10(test), new ushort4((ushort)__intlog10((UInt128)test.x),
                                                                  (ushort)__intlog10((UInt128)test.y),
                                                                  (ushort)__intlog10((UInt128)test.z),
                                                                  (ushort)__intlog10((UInt128)test.w)));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 test = rng.NextUShort8();

                Assert.AreEqual(maxmath.intlog10(test), new ushort8((ushort)__intlog10((UInt128)test.x0),
                                                                  (ushort)__intlog10((UInt128)test.x1),
                                                                  (ushort)__intlog10((UInt128)test.x2),
                                                                  (ushort)__intlog10((UInt128)test.x3),
                                                                  (ushort)__intlog10((UInt128)test.x4),
                                                                  (ushort)__intlog10((UInt128)test.x5),
                                                                  (ushort)__intlog10((UInt128)test.x6),
                                                                  (ushort)__intlog10((UInt128)test.x7)));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 test = rng.NextUShort16();

                Assert.AreEqual(maxmath.intlog10(test), new ushort16((ushort)__intlog10((UInt128)test.x0),
                                                                   (ushort)__intlog10((UInt128)test.x1),
                                                                   (ushort)__intlog10((UInt128)test.x2),
                                                                   (ushort)__intlog10((UInt128)test.x3),
                                                                   (ushort)__intlog10((UInt128)test.x4),
                                                                   (ushort)__intlog10((UInt128)test.x5),
                                                                   (ushort)__intlog10((UInt128)test.x6),
                                                                   (ushort)__intlog10((UInt128)test.x7),
                                                                   (ushort)__intlog10((UInt128)test.x8),
                                                                   (ushort)__intlog10((UInt128)test.x9),
                                                                   (ushort)__intlog10((UInt128)test.x10),
                                                                   (ushort)__intlog10((UInt128)test.x11),
                                                                   (ushort)__intlog10((UInt128)test.x12),
                                                                   (ushort)__intlog10((UInt128)test.x13),
                                                                   (ushort)__intlog10((UInt128)test.x14),
                                                                   (ushort)__intlog10((UInt128)test.x15)));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 test = rng.NextShort2(0, short.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new short2((short)__intlog10((UInt128)test.x),
                                                                  (short)__intlog10((UInt128)test.y)));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 test = rng.NextShort3(0, short.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new short3((short)__intlog10((UInt128)test.x),
                                                                  (short)__intlog10((UInt128)test.y),
                                                                  (short)__intlog10((UInt128)test.z)));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 test = rng.NextShort4(0, short.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new short4((short)__intlog10((UInt128)test.x),
                                                                  (short)__intlog10((UInt128)test.y),
                                                                  (short)__intlog10((UInt128)test.z),
                                                                  (short)__intlog10((UInt128)test.w)));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 test = rng.NextShort8(0, short.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new short8((short)__intlog10((UInt128)test.x0),
                                                                  (short)__intlog10((UInt128)test.x1),
                                                                  (short)__intlog10((UInt128)test.x2),
                                                                  (short)__intlog10((UInt128)test.x3),
                                                                  (short)__intlog10((UInt128)test.x4),
                                                                  (short)__intlog10((UInt128)test.x5),
                                                                  (short)__intlog10((UInt128)test.x6),
                                                                  (short)__intlog10((UInt128)test.x7)));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 test = rng.NextShort16(0, short.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new short16((short)__intlog10((UInt128)test.x0),
                                                                   (short)__intlog10((UInt128)test.x1),
                                                                   (short)__intlog10((UInt128)test.x2),
                                                                   (short)__intlog10((UInt128)test.x3),
                                                                   (short)__intlog10((UInt128)test.x4),
                                                                   (short)__intlog10((UInt128)test.x5),
                                                                   (short)__intlog10((UInt128)test.x6),
                                                                   (short)__intlog10((UInt128)test.x7),
                                                                   (short)__intlog10((UInt128)test.x8),
                                                                   (short)__intlog10((UInt128)test.x9),
                                                                   (short)__intlog10((UInt128)test.x10),
                                                                   (short)__intlog10((UInt128)test.x11),
                                                                   (short)__intlog10((UInt128)test.x12),
                                                                   (short)__intlog10((UInt128)test.x13),
                                                                   (short)__intlog10((UInt128)test.x14),
                                                                   (short)__intlog10((UInt128)test.x15)));
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 test = rng.NextUInt2();

                Assert.AreEqual(maxmath.intlog10(test), new uint2((uint)__intlog10((UInt128)test.x),
                                                                  (uint)__intlog10((UInt128)test.y)));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 test = rng.NextUInt3();

                Assert.AreEqual(maxmath.intlog10(test), new uint3((uint)__intlog10((UInt128)test.x),
                                                                  (uint)__intlog10((UInt128)test.y),
                                                                  (uint)__intlog10((UInt128)test.z)));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 test = rng.NextUInt4();

                Assert.AreEqual(maxmath.intlog10(test), new uint4((uint)__intlog10((UInt128)test.x),
                                                                  (uint)__intlog10((UInt128)test.y),
                                                                  (uint)__intlog10((UInt128)test.z),
                                                                  (uint)__intlog10((UInt128)test.w)));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 test = rng.NextUInt8();

                Assert.AreEqual(maxmath.intlog10(test), new uint8((uint)__intlog10((UInt128)test.x0),
                                                                  (uint)__intlog10((UInt128)test.x1),
                                                                  (uint)__intlog10((UInt128)test.x2),
                                                                  (uint)__intlog10((UInt128)test.x3),
                                                                  (uint)__intlog10((UInt128)test.x4),
                                                                  (uint)__intlog10((UInt128)test.x5),
                                                                  (uint)__intlog10((UInt128)test.x6),
                                                                  (uint)__intlog10((UInt128)test.x7)));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 test = rng.NextInt2(0, int.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new int2((int)__intlog10((UInt128)test.x),
                                                                  (int)__intlog10((UInt128)test.y)));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 test = rng.NextInt3(0, int.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new int3((int)__intlog10((UInt128)test.x),
                                                                  (int)__intlog10((UInt128)test.y),
                                                                  (int)__intlog10((UInt128)test.z)));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 test = rng.NextInt4(0, int.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new int4((int)__intlog10((UInt128)test.x),
                                                                  (int)__intlog10((UInt128)test.y),
                                                                  (int)__intlog10((UInt128)test.z),
                                                                  (int)__intlog10((UInt128)test.w)));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 test = rng.NextInt8(0, int.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new int8((int)__intlog10((UInt128)test.x0),
                                                                  (int)__intlog10((UInt128)test.x1),
                                                                  (int)__intlog10((UInt128)test.x2),
                                                                  (int)__intlog10((UInt128)test.x3),
                                                                  (int)__intlog10((UInt128)test.x4),
                                                                  (int)__intlog10((UInt128)test.x5),
                                                                  (int)__intlog10((UInt128)test.x6),
                                                                  (int)__intlog10((UInt128)test.x7)));
            }
        }



        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                ulong2 test = rng.NextULong2();

                Assert.AreEqual(maxmath.intlog10(test), new ulong2((ulong)__intlog10((UInt128)test.x),
                                                                  (ulong)__intlog10((UInt128)test.y)));
            }

            for (int i = 0; i < 64; i++)
            {
                ulong2 pow2 = 1ul << i;

                Assert.AreEqual(maxmath.intlog10(pow2), new ulong2((ulong)__intlog10((UInt128)pow2.x),
                                                                   (ulong)__intlog10((UInt128)pow2.y)));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                ulong3 test = rng.NextULong3();

                Assert.AreEqual(maxmath.intlog10(test), new ulong3((ulong)__intlog10((UInt128)test.x),
                                                                  (ulong)__intlog10((UInt128)test.y),
                                                                  (ulong)__intlog10((UInt128)test.z)));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                ulong4 test = rng.NextULong4();

                Assert.AreEqual(maxmath.intlog10(test), new ulong4((ulong)__intlog10((UInt128)test.x),
                                                                  (ulong)__intlog10((UInt128)test.y),
                                                                  (ulong)__intlog10((UInt128)test.z),
                                                                  (ulong)__intlog10((UInt128)test.w)));
            }
        }


        [Test]
        public static void _long2()
        {

            maxmath.intlog10(new long());
            //Random64 rng = Random64.New;
            //
            //for (long i = 0; i < 25; i++)
            //{
            //    long2 test = rng.NextLong2(0, long.MaxValue);
            //
            //    Assert.AreEqual(maxmath.intlog10(test), new long2((long)__intlog10((UInt128)test.x),
            //                                                      (long)__intlog10((UInt128)test.y)));
            //}
            //
            //for (int i = 0; i < 63; i++)
            //{
            //    long2 pow2 = 1L << i;
            //
            //    Assert.AreEqual(maxmath.intlog10(pow2), new long2((long)__intlog10((UInt128)pow2.x),
            //                                                      (long)__intlog10((UInt128)pow2.y)));
            //}
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                long3 test = rng.NextLong3(0, long.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new long3((long)__intlog10((UInt128)test.x),
                                                                  (long)__intlog10((UInt128)test.y),
                                                                  (long)__intlog10((UInt128)test.z)));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                long4 test = rng.NextLong4(0, long.MaxValue);

                Assert.AreEqual(maxmath.intlog10(test), new long4((long)__intlog10((UInt128)test.x),
                                                                  (long)__intlog10((UInt128)test.y),
                                                                  (long)__intlog10((UInt128)test.z),
                                                                  (long)__intlog10((UInt128)test.w)));
            }
        }
    }
}