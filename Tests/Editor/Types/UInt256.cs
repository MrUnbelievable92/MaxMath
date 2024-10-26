using System.Numerics;
using NUnit.Framework;

namespace MaxMath.Tests
{
    internal static class t___UInt256__
    {
        private static __UInt256__ Random(ref Random128 rng)
        {
            return new __UInt256__(rng.NextUInt128(), rng.NextUInt128());
        }
        private static BigInteger Clamp256(BigInteger value)
        {
            return value & (((BigInteger)1 << 256) - 1);
        }

        [Test]
        public static void AND()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l & r), Clamp256((BigInteger)l & (BigInteger)r));
            }
        }

        [Test]
        public static void OR()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l | r), Clamp256((BigInteger)l | (BigInteger)r));
            }
        }

        [Test]
        public static void XOR()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l ^ r), Clamp256((BigInteger)l ^ (BigInteger)r));
            }
        }

        [Test]
        public static void cmpeq()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l == r, (BigInteger)l == (BigInteger)r);
                Assert.AreEqual(r == l, (BigInteger)r == (BigInteger)l);
            }
        }

        [Test]
        public static void cmpneq()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l != r, (BigInteger)l != (BigInteger)r);
                Assert.AreEqual(r != l, (BigInteger)r != (BigInteger)l);
            }
        }

        [Test]
        public static void cmpgteq()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l >= r, (BigInteger)l >= (BigInteger)r);
                Assert.AreEqual(r >= l, (BigInteger)r >= (BigInteger)l);
            }
        }

        [Test]
        public static void cmplteq()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l <= r, (BigInteger)l <= (BigInteger)r);
                Assert.AreEqual(r <= l, (BigInteger)r <= (BigInteger)l);
            }
        }

        [Test]
        public static void cmpgt()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l > r, (BigInteger)l > (BigInteger)r);
                Assert.AreEqual(r > l, (BigInteger)r > (BigInteger)l);
            }
        }

        [Test]
        public static void cmplt()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l < r, (BigInteger)l < (BigInteger)r);
                Assert.AreEqual(r < l, (BigInteger)r < (BigInteger)l);
            }
        }

        [Test]
        public static void cmpeq128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l == r.lo128, (BigInteger)l == (BigInteger)r.lo128);
                Assert.AreEqual(r == l.lo128, (BigInteger)r == (BigInteger)l.lo128);
            }
        }

        [Test]
        public static void cmpneq128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l != r.lo128, (BigInteger)l != (BigInteger)r.lo128);
                Assert.AreEqual(r != l.lo128, (BigInteger)r != (BigInteger)l.lo128);
            }
        }

        [Test]
        public static void cmpgteq128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l >= r.lo128, (BigInteger)l >= (BigInteger)r.lo128);
                Assert.AreEqual(r >= l.lo128, (BigInteger)r >= (BigInteger)l.lo128);
            }
        }

        [Test]
        public static void cmplteq128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l <= r.lo128, (BigInteger)l <= (BigInteger)r.lo128);
                Assert.AreEqual(r <= l.lo128, (BigInteger)r <= (BigInteger)l.lo128);
            }
        }

        [Test]
        public static void cmpgt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l > r.lo128, (BigInteger)l > (BigInteger)r.lo128);
                Assert.AreEqual(r > l.lo128, (BigInteger)r > (BigInteger)l.lo128);
            }
        }

        [Test]
        public static void cmplt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual(l < r.lo128, (BigInteger)l < (BigInteger)r.lo128);
                Assert.AreEqual(r < l.lo128, (BigInteger)r < (BigInteger)l.lo128);
            }
        }

        [Test]
        public static void Add()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l + r), Clamp256((BigInteger)l + (BigInteger)r));
            }
        }

        [Test]
        public static void Subtract()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l - r), Clamp256((BigInteger)l - (BigInteger)r));
            }
        }
        
        [Test]
        public static void Add128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l + r.lo128), Clamp256((BigInteger)l + (BigInteger)r.lo128));
                Assert.AreEqual((BigInteger)(l.lo128 + r), Clamp256((BigInteger)l.lo128 + (BigInteger)r));
            }
        }

        [Test]
        public static void Subtract128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l - r.lo128), Clamp256((BigInteger)l - (BigInteger)r.lo128));
                Assert.AreEqual((BigInteger)(l.lo128 - r), Clamp256((BigInteger)l.lo128 - (BigInteger)r));
            }
        }

        [Test]
        public static void Multiply128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l * r.lo128), Clamp256((BigInteger)l * (BigInteger)r.lo128));
            }
        }

        [Test]
        public static void Divide128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l / r.lo128), Clamp256((BigInteger)l / (BigInteger)r.lo128));
            }
        }

        [Test]
        public static void Modulus128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l % r.lo128), Clamp256((BigInteger)l % (BigInteger)r.lo128));
            }
        }

        [Test]
        public static void SHL()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l << (byte)(UInt128)r), Clamp256((BigInteger)l << (byte)(UInt128)r));
            }
        }

        [Test]
        public static void SHR()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);
                __UInt256__ r = Random(ref rng);

                Assert.AreEqual((BigInteger)(l >> (byte)(UInt128)r), (BigInteger)l >> (byte)(UInt128)r);
            }
        }

        [Test]
        public static void intsqrt()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 200; i++)
            {
                __UInt256__ l = Random(ref rng);

                Assert.AreEqual((BigInteger)(__UInt256__.intsqrt(l)), ((BigInteger)l).Sqrt());
            }
        }
    }
}
