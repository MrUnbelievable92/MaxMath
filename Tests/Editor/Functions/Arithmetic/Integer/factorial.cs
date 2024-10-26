using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_factorial
    {
        private static UInt128 truefactorial(UInt128 x)
        {
            UInt128 result = 1;

            while (x > 1)
            {
                result *= x--;
            }

            return result;
        }

        private static bool overflows<T>(UInt128 x)
        {
            if (typeof(T) == typeof(byte))      return x > 5;
            if (typeof(T) == typeof(sbyte))     return x > 5;
            if (typeof(T) == typeof(short))     return x > 7;
            if (typeof(T) == typeof(ushort))    return x > 8;
            if (typeof(T) == typeof(int))       return x > 12;
            if (typeof(T) == typeof(uint))      return x > 12;
            if (typeof(T) == typeof(long))      return x > 20;
            if (typeof(T) == typeof(ulong))     return x > 20;
            if (typeof(T) == typeof(Int128))    return x > 33;
            if (typeof(T) == typeof(UInt128))   return x > 34;

            return false;
        }


        [Test]
        public static void _UInt128()
        {
            Random128 r = Random128.New;

            for (int i = 0; i < 34; i++)
            {
                UInt128 x = r.NextUInt128(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x), overflows<UInt128>(x) ? UInt128.MaxValue : truefactorial(x));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 r = Random128.New;

            for (int i = 0; i < 34; i++)
            {
                Int128 x = r.NextInt128(0, 40);
                Assert.AreEqual(maxmath.factorial(x), overflows<Int128>((UInt128)x) ? Int128.MaxValue : (Int128)truefactorial((UInt128)x));
            }
        }


        [Test]
        public static void _byte1()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                byte x = r.NextByte(0, 40);

                Assert.AreEqual((UInt128)maxmath.factorial(x), overflows<byte>(x) ? byte.MaxValue : truefactorial(x));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                byte2 x = r.NextByte2(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<byte>(x.x) ? byte.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<byte>(x.y) ? byte.MaxValue : truefactorial(x.y));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                byte3 x = r.NextByte3(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<byte>(x.x) ? byte.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<byte>(x.y) ? byte.MaxValue : truefactorial(x.y));
                Assert.AreEqual((UInt128)maxmath.factorial(x.z), overflows<byte>(x.z) ? byte.MaxValue : truefactorial(x.z));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                byte4 x = r.NextByte4(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<byte>(x.x) ? byte.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<byte>(x.y) ? byte.MaxValue : truefactorial(x.y));
                Assert.AreEqual((UInt128)maxmath.factorial(x.z), overflows<byte>(x.z) ? byte.MaxValue : truefactorial(x.z));
                Assert.AreEqual((UInt128)maxmath.factorial(x.w), overflows<byte>(x.w) ? byte.MaxValue : truefactorial(x.w));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                byte8 x = r.NextByte8(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x0), overflows<byte>(x.x0) ? byte.MaxValue : truefactorial(x.x0));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x1), overflows<byte>(x.x1) ? byte.MaxValue : truefactorial(x.x1));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x2), overflows<byte>(x.x2) ? byte.MaxValue : truefactorial(x.x2));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x3), overflows<byte>(x.x3) ? byte.MaxValue : truefactorial(x.x3));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x4), overflows<byte>(x.x4) ? byte.MaxValue : truefactorial(x.x4));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x5), overflows<byte>(x.x5) ? byte.MaxValue : truefactorial(x.x5));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x6), overflows<byte>(x.x6) ? byte.MaxValue : truefactorial(x.x6));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x7), overflows<byte>(x.x7) ? byte.MaxValue : truefactorial(x.x7));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                byte16 x = r.NextByte16(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x0),  overflows<byte>(x.x0)  ? byte.MaxValue : truefactorial(x.x0));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x1),  overflows<byte>(x.x1)  ? byte.MaxValue : truefactorial(x.x1));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x2),  overflows<byte>(x.x2)  ? byte.MaxValue : truefactorial(x.x2));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x3),  overflows<byte>(x.x3)  ? byte.MaxValue : truefactorial(x.x3));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x4),  overflows<byte>(x.x4)  ? byte.MaxValue : truefactorial(x.x4));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x5),  overflows<byte>(x.x5)  ? byte.MaxValue : truefactorial(x.x5));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x6),  overflows<byte>(x.x6)  ? byte.MaxValue : truefactorial(x.x6));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x7),  overflows<byte>(x.x7)  ? byte.MaxValue : truefactorial(x.x7));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x8),  overflows<byte>(x.x8)  ? byte.MaxValue : truefactorial(x.x8));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x9),  overflows<byte>(x.x9)  ? byte.MaxValue : truefactorial(x.x9));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x10), overflows<byte>(x.x10) ? byte.MaxValue : truefactorial(x.x10));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x11), overflows<byte>(x.x11) ? byte.MaxValue : truefactorial(x.x11));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x12), overflows<byte>(x.x12) ? byte.MaxValue : truefactorial(x.x12));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x13), overflows<byte>(x.x13) ? byte.MaxValue : truefactorial(x.x13));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x14), overflows<byte>(x.x14) ? byte.MaxValue : truefactorial(x.x14));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x15), overflows<byte>(x.x15) ? byte.MaxValue : truefactorial(x.x15));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                byte32 x = r.NextByte32(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x0),  overflows<byte>(x.x0)  ? byte.MaxValue : truefactorial(x.x0));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x1),  overflows<byte>(x.x1)  ? byte.MaxValue : truefactorial(x.x1));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x2),  overflows<byte>(x.x2)  ? byte.MaxValue : truefactorial(x.x2));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x3),  overflows<byte>(x.x3)  ? byte.MaxValue : truefactorial(x.x3));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x4),  overflows<byte>(x.x4)  ? byte.MaxValue : truefactorial(x.x4));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x5),  overflows<byte>(x.x5)  ? byte.MaxValue : truefactorial(x.x5));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x6),  overflows<byte>(x.x6)  ? byte.MaxValue : truefactorial(x.x6));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x7),  overflows<byte>(x.x7)  ? byte.MaxValue : truefactorial(x.x7));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x8),  overflows<byte>(x.x8)  ? byte.MaxValue : truefactorial(x.x8));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x9),  overflows<byte>(x.x9)  ? byte.MaxValue : truefactorial(x.x9));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x10), overflows<byte>(x.x10) ? byte.MaxValue : truefactorial(x.x10));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x11), overflows<byte>(x.x11) ? byte.MaxValue : truefactorial(x.x11));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x12), overflows<byte>(x.x12) ? byte.MaxValue : truefactorial(x.x12));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x13), overflows<byte>(x.x13) ? byte.MaxValue : truefactorial(x.x13));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x14), overflows<byte>(x.x14) ? byte.MaxValue : truefactorial(x.x14));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x15), overflows<byte>(x.x15) ? byte.MaxValue : truefactorial(x.x15));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x16), overflows<byte>(x.x16) ? byte.MaxValue : truefactorial(x.x16));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x17), overflows<byte>(x.x17) ? byte.MaxValue : truefactorial(x.x17));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x18), overflows<byte>(x.x18) ? byte.MaxValue : truefactorial(x.x18));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x19), overflows<byte>(x.x19) ? byte.MaxValue : truefactorial(x.x19));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x20), overflows<byte>(x.x20) ? byte.MaxValue : truefactorial(x.x20));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x21), overflows<byte>(x.x21) ? byte.MaxValue : truefactorial(x.x21));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x22), overflows<byte>(x.x22) ? byte.MaxValue : truefactorial(x.x22));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x23), overflows<byte>(x.x23) ? byte.MaxValue : truefactorial(x.x23));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x24), overflows<byte>(x.x24) ? byte.MaxValue : truefactorial(x.x24));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x25), overflows<byte>(x.x25) ? byte.MaxValue : truefactorial(x.x25));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x26), overflows<byte>(x.x26) ? byte.MaxValue : truefactorial(x.x26));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x27), overflows<byte>(x.x27) ? byte.MaxValue : truefactorial(x.x27));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x28), overflows<byte>(x.x28) ? byte.MaxValue : truefactorial(x.x28));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x29), overflows<byte>(x.x29) ? byte.MaxValue : truefactorial(x.x29));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x30), overflows<byte>(x.x30) ? byte.MaxValue : truefactorial(x.x30));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x31), overflows<byte>(x.x31) ? byte.MaxValue : truefactorial(x.x31));
            }
        }


        [Test]
        public static void _sbyte1()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                sbyte x = r.NextSByte(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x), overflows<sbyte>((UInt128)x) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                sbyte2 x = r.NextSByte2(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<sbyte>((UInt128)x.x) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<sbyte>((UInt128)x.y) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.y));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                sbyte3 x = r.NextSByte3(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<sbyte>((UInt128)x.x) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<sbyte>((UInt128)x.y) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.y));
                Assert.AreEqual((Int128)maxmath.factorial(x.z), overflows<sbyte>((UInt128)x.z) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.z));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                sbyte4 x = r.NextSByte4(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<sbyte>((UInt128)x.x) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<sbyte>((UInt128)x.y) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.y));
                Assert.AreEqual((Int128)maxmath.factorial(x.z), overflows<sbyte>((UInt128)x.z) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.z));
                Assert.AreEqual((Int128)maxmath.factorial(x.w), overflows<sbyte>((UInt128)x.w) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.w));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                sbyte8 x = r.NextSByte8(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x0), overflows<sbyte>((UInt128)x.x0) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x0));
                Assert.AreEqual((Int128)maxmath.factorial(x.x1), overflows<sbyte>((UInt128)x.x1) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x1));
                Assert.AreEqual((Int128)maxmath.factorial(x.x2), overflows<sbyte>((UInt128)x.x2) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x2));
                Assert.AreEqual((Int128)maxmath.factorial(x.x3), overflows<sbyte>((UInt128)x.x3) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x3));
                Assert.AreEqual((Int128)maxmath.factorial(x.x4), overflows<sbyte>((UInt128)x.x4) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x4));
                Assert.AreEqual((Int128)maxmath.factorial(x.x5), overflows<sbyte>((UInt128)x.x5) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x5));
                Assert.AreEqual((Int128)maxmath.factorial(x.x6), overflows<sbyte>((UInt128)x.x6) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x6));
                Assert.AreEqual((Int128)maxmath.factorial(x.x7), overflows<sbyte>((UInt128)x.x7) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x7));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                sbyte16 x = r.NextSByte16(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x0),  overflows<sbyte>((UInt128)x.x0)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x0));
                Assert.AreEqual((Int128)maxmath.factorial(x.x1),  overflows<sbyte>((UInt128)x.x1)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x1));
                Assert.AreEqual((Int128)maxmath.factorial(x.x2),  overflows<sbyte>((UInt128)x.x2)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x2));
                Assert.AreEqual((Int128)maxmath.factorial(x.x3),  overflows<sbyte>((UInt128)x.x3)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x3));
                Assert.AreEqual((Int128)maxmath.factorial(x.x4),  overflows<sbyte>((UInt128)x.x4)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x4));
                Assert.AreEqual((Int128)maxmath.factorial(x.x5),  overflows<sbyte>((UInt128)x.x5)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x5));
                Assert.AreEqual((Int128)maxmath.factorial(x.x6),  overflows<sbyte>((UInt128)x.x6)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x6));
                Assert.AreEqual((Int128)maxmath.factorial(x.x7),  overflows<sbyte>((UInt128)x.x7)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x7));
                Assert.AreEqual((Int128)maxmath.factorial(x.x8),  overflows<sbyte>((UInt128)x.x8)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x8));
                Assert.AreEqual((Int128)maxmath.factorial(x.x9),  overflows<sbyte>((UInt128)x.x9)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x9));
                Assert.AreEqual((Int128)maxmath.factorial(x.x10), overflows<sbyte>((UInt128)x.x10) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x10));
                Assert.AreEqual((Int128)maxmath.factorial(x.x11), overflows<sbyte>((UInt128)x.x11) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x11));
                Assert.AreEqual((Int128)maxmath.factorial(x.x12), overflows<sbyte>((UInt128)x.x12) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x12));
                Assert.AreEqual((Int128)maxmath.factorial(x.x13), overflows<sbyte>((UInt128)x.x13) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x13));
                Assert.AreEqual((Int128)maxmath.factorial(x.x14), overflows<sbyte>((UInt128)x.x14) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x14));
                Assert.AreEqual((Int128)maxmath.factorial(x.x15), overflows<sbyte>((UInt128)x.x15) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x15));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 34; i++)
            {
                sbyte32 x = r.NextSByte32(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x0),  overflows<sbyte>((UInt128)x.x0)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x0));
                Assert.AreEqual((Int128)maxmath.factorial(x.x1),  overflows<sbyte>((UInt128)x.x1)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x1));
                Assert.AreEqual((Int128)maxmath.factorial(x.x2),  overflows<sbyte>((UInt128)x.x2)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x2));
                Assert.AreEqual((Int128)maxmath.factorial(x.x3),  overflows<sbyte>((UInt128)x.x3)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x3));
                Assert.AreEqual((Int128)maxmath.factorial(x.x4),  overflows<sbyte>((UInt128)x.x4)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x4));
                Assert.AreEqual((Int128)maxmath.factorial(x.x5),  overflows<sbyte>((UInt128)x.x5)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x5));
                Assert.AreEqual((Int128)maxmath.factorial(x.x6),  overflows<sbyte>((UInt128)x.x6)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x6));
                Assert.AreEqual((Int128)maxmath.factorial(x.x7),  overflows<sbyte>((UInt128)x.x7)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x7));
                Assert.AreEqual((Int128)maxmath.factorial(x.x8),  overflows<sbyte>((UInt128)x.x8)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x8));
                Assert.AreEqual((Int128)maxmath.factorial(x.x9),  overflows<sbyte>((UInt128)x.x9)  ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x9));
                Assert.AreEqual((Int128)maxmath.factorial(x.x10), overflows<sbyte>((UInt128)x.x10) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x10));
                Assert.AreEqual((Int128)maxmath.factorial(x.x11), overflows<sbyte>((UInt128)x.x11) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x11));
                Assert.AreEqual((Int128)maxmath.factorial(x.x12), overflows<sbyte>((UInt128)x.x12) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x12));
                Assert.AreEqual((Int128)maxmath.factorial(x.x13), overflows<sbyte>((UInt128)x.x13) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x13));
                Assert.AreEqual((Int128)maxmath.factorial(x.x14), overflows<sbyte>((UInt128)x.x14) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x14));
                Assert.AreEqual((Int128)maxmath.factorial(x.x15), overflows<sbyte>((UInt128)x.x15) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x15));
                Assert.AreEqual((Int128)maxmath.factorial(x.x16), overflows<sbyte>((UInt128)x.x16) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x16));
                Assert.AreEqual((Int128)maxmath.factorial(x.x17), overflows<sbyte>((UInt128)x.x17) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x17));
                Assert.AreEqual((Int128)maxmath.factorial(x.x18), overflows<sbyte>((UInt128)x.x18) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x18));
                Assert.AreEqual((Int128)maxmath.factorial(x.x19), overflows<sbyte>((UInt128)x.x19) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x19));
                Assert.AreEqual((Int128)maxmath.factorial(x.x20), overflows<sbyte>((UInt128)x.x20) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x20));
                Assert.AreEqual((Int128)maxmath.factorial(x.x21), overflows<sbyte>((UInt128)x.x21) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x21));
                Assert.AreEqual((Int128)maxmath.factorial(x.x22), overflows<sbyte>((UInt128)x.x22) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x22));
                Assert.AreEqual((Int128)maxmath.factorial(x.x23), overflows<sbyte>((UInt128)x.x23) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x23));
                Assert.AreEqual((Int128)maxmath.factorial(x.x24), overflows<sbyte>((UInt128)x.x24) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x24));
                Assert.AreEqual((Int128)maxmath.factorial(x.x25), overflows<sbyte>((UInt128)x.x25) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x25));
                Assert.AreEqual((Int128)maxmath.factorial(x.x26), overflows<sbyte>((UInt128)x.x26) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x26));
                Assert.AreEqual((Int128)maxmath.factorial(x.x27), overflows<sbyte>((UInt128)x.x27) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x27));
                Assert.AreEqual((Int128)maxmath.factorial(x.x28), overflows<sbyte>((UInt128)x.x28) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x28));
                Assert.AreEqual((Int128)maxmath.factorial(x.x29), overflows<sbyte>((UInt128)x.x29) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x29));
                Assert.AreEqual((Int128)maxmath.factorial(x.x30), overflows<sbyte>((UInt128)x.x30) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x30));
                Assert.AreEqual((Int128)maxmath.factorial(x.x31), overflows<sbyte>((UInt128)x.x31) ? sbyte.MaxValue : (Int128)truefactorial((UInt128)x.x31));
            }
        }

        [Test]
        public static void _ushort1()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                ushort x = r.NextUShort(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x), overflows<ushort>(x) ? ushort.MaxValue : truefactorial(x));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                ushort2 x = r.NextUShort2(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<ushort>(x.x) ? ushort.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<ushort>(x.y) ? ushort.MaxValue : truefactorial(x.y));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                ushort3 x = r.NextUShort3(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<ushort>(x.x) ? ushort.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<ushort>(x.y) ? ushort.MaxValue : truefactorial(x.y));
                Assert.AreEqual((UInt128)maxmath.factorial(x.z), overflows<ushort>(x.z) ? ushort.MaxValue : truefactorial(x.z));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                ushort4 x = r.NextUShort4(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<ushort>(x.x) ? ushort.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<ushort>(x.y) ? ushort.MaxValue : truefactorial(x.y));
                Assert.AreEqual((UInt128)maxmath.factorial(x.z), overflows<ushort>(x.z) ? ushort.MaxValue : truefactorial(x.z));
                Assert.AreEqual((UInt128)maxmath.factorial(x.w), overflows<ushort>(x.w) ? ushort.MaxValue : truefactorial(x.w));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                ushort8 x = r.NextUShort8(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x0), overflows<ushort>(x.x0) ? ushort.MaxValue : truefactorial(x.x0));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x1), overflows<ushort>(x.x1) ? ushort.MaxValue : truefactorial(x.x1));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x2), overflows<ushort>(x.x2) ? ushort.MaxValue : truefactorial(x.x2));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x3), overflows<ushort>(x.x3) ? ushort.MaxValue : truefactorial(x.x3));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x4), overflows<ushort>(x.x4) ? ushort.MaxValue : truefactorial(x.x4));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x5), overflows<ushort>(x.x5) ? ushort.MaxValue : truefactorial(x.x5));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x6), overflows<ushort>(x.x6) ? ushort.MaxValue : truefactorial(x.x6));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x7), overflows<ushort>(x.x7) ? ushort.MaxValue : truefactorial(x.x7));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                ushort16 x = r.NextUShort16(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x0),  overflows<ushort>(x.x0)  ? ushort.MaxValue : truefactorial(x.x0));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x1),  overflows<ushort>(x.x1)  ? ushort.MaxValue : truefactorial(x.x1));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x2),  overflows<ushort>(x.x2)  ? ushort.MaxValue : truefactorial(x.x2));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x3),  overflows<ushort>(x.x3)  ? ushort.MaxValue : truefactorial(x.x3));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x4),  overflows<ushort>(x.x4)  ? ushort.MaxValue : truefactorial(x.x4));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x5),  overflows<ushort>(x.x5)  ? ushort.MaxValue : truefactorial(x.x5));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x6),  overflows<ushort>(x.x6)  ? ushort.MaxValue : truefactorial(x.x6));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x7),  overflows<ushort>(x.x7)  ? ushort.MaxValue : truefactorial(x.x7));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x8),  overflows<ushort>(x.x8)  ? ushort.MaxValue : truefactorial(x.x8));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x9),  overflows<ushort>(x.x9)  ? ushort.MaxValue : truefactorial(x.x9));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x10), overflows<ushort>(x.x10) ? ushort.MaxValue : truefactorial(x.x10));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x11), overflows<ushort>(x.x11) ? ushort.MaxValue : truefactorial(x.x11));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x12), overflows<ushort>(x.x12) ? ushort.MaxValue : truefactorial(x.x12));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x13), overflows<ushort>(x.x13) ? ushort.MaxValue : truefactorial(x.x13));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x14), overflows<ushort>(x.x14) ? ushort.MaxValue : truefactorial(x.x14));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x15), overflows<ushort>(x.x15) ? ushort.MaxValue : truefactorial(x.x15));
            }
        }


        [Test]
        public static void _short1()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                short x = r.NextShort(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x), overflows<short>((UInt128)x) ? short.MaxValue : (Int128)truefactorial((UInt128)x));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                short2 x = r.NextShort2(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<short>((UInt128)x.x) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<short>((UInt128)x.y) ? short.MaxValue : (Int128)truefactorial((UInt128)x.y));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                short3 x = r.NextShort3(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<short>((UInt128)x.x) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<short>((UInt128)x.y) ? short.MaxValue : (Int128)truefactorial((UInt128)x.y));
                Assert.AreEqual((Int128)maxmath.factorial(x.z), overflows<short>((UInt128)x.z) ? short.MaxValue : (Int128)truefactorial((UInt128)x.z));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                short4 x = r.NextShort4(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<short>((UInt128)x.x) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<short>((UInt128)x.y) ? short.MaxValue : (Int128)truefactorial((UInt128)x.y));
                Assert.AreEqual((Int128)maxmath.factorial(x.z), overflows<short>((UInt128)x.z) ? short.MaxValue : (Int128)truefactorial((UInt128)x.z));
                Assert.AreEqual((Int128)maxmath.factorial(x.w), overflows<short>((UInt128)x.w) ? short.MaxValue : (Int128)truefactorial((UInt128)x.w));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                short8 x = r.NextShort8(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x0), overflows<short>((UInt128)x.x0) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x0));
                Assert.AreEqual((Int128)maxmath.factorial(x.x1), overflows<short>((UInt128)x.x1) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x1));
                Assert.AreEqual((Int128)maxmath.factorial(x.x2), overflows<short>((UInt128)x.x2) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x2));
                Assert.AreEqual((Int128)maxmath.factorial(x.x3), overflows<short>((UInt128)x.x3) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x3));
                Assert.AreEqual((Int128)maxmath.factorial(x.x4), overflows<short>((UInt128)x.x4) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x4));
                Assert.AreEqual((Int128)maxmath.factorial(x.x5), overflows<short>((UInt128)x.x5) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x5));
                Assert.AreEqual((Int128)maxmath.factorial(x.x6), overflows<short>((UInt128)x.x6) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x6));
                Assert.AreEqual((Int128)maxmath.factorial(x.x7), overflows<short>((UInt128)x.x7) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x7));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 34; i++)
            {
                short16 x = r.NextShort16(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x0),  overflows<short>((UInt128)x.x0)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x0));
                Assert.AreEqual((Int128)maxmath.factorial(x.x1),  overflows<short>((UInt128)x.x1)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x1));
                Assert.AreEqual((Int128)maxmath.factorial(x.x2),  overflows<short>((UInt128)x.x2)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x2));
                Assert.AreEqual((Int128)maxmath.factorial(x.x3),  overflows<short>((UInt128)x.x3)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x3));
                Assert.AreEqual((Int128)maxmath.factorial(x.x4),  overflows<short>((UInt128)x.x4)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x4));
                Assert.AreEqual((Int128)maxmath.factorial(x.x5),  overflows<short>((UInt128)x.x5)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x5));
                Assert.AreEqual((Int128)maxmath.factorial(x.x6),  overflows<short>((UInt128)x.x6)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x6));
                Assert.AreEqual((Int128)maxmath.factorial(x.x7),  overflows<short>((UInt128)x.x7)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x7));
                Assert.AreEqual((Int128)maxmath.factorial(x.x8),  overflows<short>((UInt128)x.x8)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x8));
                Assert.AreEqual((Int128)maxmath.factorial(x.x9),  overflows<short>((UInt128)x.x9)  ? short.MaxValue : (Int128)truefactorial((UInt128)x.x9));
                Assert.AreEqual((Int128)maxmath.factorial(x.x10), overflows<short>((UInt128)x.x10) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x10));
                Assert.AreEqual((Int128)maxmath.factorial(x.x11), overflows<short>((UInt128)x.x11) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x11));
                Assert.AreEqual((Int128)maxmath.factorial(x.x12), overflows<short>((UInt128)x.x12) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x12));
                Assert.AreEqual((Int128)maxmath.factorial(x.x13), overflows<short>((UInt128)x.x13) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x13));
                Assert.AreEqual((Int128)maxmath.factorial(x.x14), overflows<short>((UInt128)x.x14) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x14));
                Assert.AreEqual((Int128)maxmath.factorial(x.x15), overflows<short>((UInt128)x.x15) ? short.MaxValue : (Int128)truefactorial((UInt128)x.x15));
            }
        }


        [Test]
        public static void _uint1()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                uint x = r.NextUInt(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x), overflows<uint>(x) ? uint.MaxValue : truefactorial(x));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                uint2 x = r.NextUInt2(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<uint>(x.x) ? uint.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<uint>(x.y) ? uint.MaxValue : truefactorial(x.y));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                uint3 x = r.NextUInt3(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<uint>(x.x) ? uint.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<uint>(x.y) ? uint.MaxValue : truefactorial(x.y));
                Assert.AreEqual((UInt128)maxmath.factorial(x.z), overflows<uint>(x.z) ? uint.MaxValue : truefactorial(x.z));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                uint4 x = r.NextUInt4(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<uint>(x.x) ? uint.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<uint>(x.y) ? uint.MaxValue : truefactorial(x.y));
                Assert.AreEqual((UInt128)maxmath.factorial(x.z), overflows<uint>(x.z) ? uint.MaxValue : truefactorial(x.z));
                Assert.AreEqual((UInt128)maxmath.factorial(x.w), overflows<uint>(x.w) ? uint.MaxValue : truefactorial(x.w));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                uint8 x = r.NextUInt8(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x0), overflows<uint>(x.x0) ? uint.MaxValue : truefactorial(x.x0));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x1), overflows<uint>(x.x1) ? uint.MaxValue : truefactorial(x.x1));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x2), overflows<uint>(x.x2) ? uint.MaxValue : truefactorial(x.x2));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x3), overflows<uint>(x.x3) ? uint.MaxValue : truefactorial(x.x3));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x4), overflows<uint>(x.x4) ? uint.MaxValue : truefactorial(x.x4));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x5), overflows<uint>(x.x5) ? uint.MaxValue : truefactorial(x.x5));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x6), overflows<uint>(x.x6) ? uint.MaxValue : truefactorial(x.x6));
                Assert.AreEqual((UInt128)maxmath.factorial(x.x7), overflows<uint>(x.x7) ? uint.MaxValue : truefactorial(x.x7));
            }
        }


        [Test]
        public static void _int1()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                int x = r.NextInt(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x), overflows<int>((UInt128)x) ? int.MaxValue : (Int128)truefactorial((UInt128)x));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                int2 x = r.NextInt2(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<int>((UInt128)x.x) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<int>((UInt128)x.y) ? int.MaxValue : (Int128)truefactorial((UInt128)x.y));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                int3 x = r.NextInt3(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<int>((UInt128)x.x) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<int>((UInt128)x.y) ? int.MaxValue : (Int128)truefactorial((UInt128)x.y));
                Assert.AreEqual((Int128)maxmath.factorial(x.z), overflows<int>((UInt128)x.z) ? int.MaxValue : (Int128)truefactorial((UInt128)x.z));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                int4 x = r.NextInt4(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<int>((UInt128)x.x) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<int>((UInt128)x.y) ? int.MaxValue : (Int128)truefactorial((UInt128)x.y));
                Assert.AreEqual((Int128)maxmath.factorial(x.z), overflows<int>((UInt128)x.z) ? int.MaxValue : (Int128)truefactorial((UInt128)x.z));
                Assert.AreEqual((Int128)maxmath.factorial(x.w), overflows<int>((UInt128)x.w) ? int.MaxValue : (Int128)truefactorial((UInt128)x.w));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 34; i++)
            {
                int8 x = r.NextInt8(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x0), overflows<int>((UInt128)x.x0) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x0));
                Assert.AreEqual((Int128)maxmath.factorial(x.x1), overflows<int>((UInt128)x.x1) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x1));
                Assert.AreEqual((Int128)maxmath.factorial(x.x2), overflows<int>((UInt128)x.x2) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x2));
                Assert.AreEqual((Int128)maxmath.factorial(x.x3), overflows<int>((UInt128)x.x3) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x3));
                Assert.AreEqual((Int128)maxmath.factorial(x.x4), overflows<int>((UInt128)x.x4) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x4));
                Assert.AreEqual((Int128)maxmath.factorial(x.x5), overflows<int>((UInt128)x.x5) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x5));
                Assert.AreEqual((Int128)maxmath.factorial(x.x6), overflows<int>((UInt128)x.x6) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x6));
                Assert.AreEqual((Int128)maxmath.factorial(x.x7), overflows<int>((UInt128)x.x7) ? int.MaxValue : (Int128)truefactorial((UInt128)x.x7));
            }
        }


        [Test]
        public static void _ulong1()
        {
            Random64 r = Random64.New;

            for (long i = 0; i < 34; i++)
            {
                ulong x = r.NextULong(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x), overflows<ulong>(x) ? ulong.MaxValue : truefactorial(x));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 r = Random64.New;

            for (long i = 0; i < 34; i++)
            {
                ulong2 x = r.NextULong2(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<ulong>(x.x) ? ulong.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<ulong>(x.y) ? ulong.MaxValue : truefactorial(x.y));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 r = Random64.New;

            for (long i = 0; i < 34; i++)
            {
                ulong3 x = r.NextULong3(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<ulong>(x.x) ? ulong.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<ulong>(x.y) ? ulong.MaxValue : truefactorial(x.y));
                Assert.AreEqual((UInt128)maxmath.factorial(x.z), overflows<ulong>(x.z) ? ulong.MaxValue : truefactorial(x.z));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 r = Random64.New;

            for (long i = 0; i < 34; i++)
            {
                ulong4 x = r.NextULong4(0, 40);
                Assert.AreEqual((UInt128)maxmath.factorial(x.x), overflows<ulong>(x.x) ? ulong.MaxValue : truefactorial(x.x));
                Assert.AreEqual((UInt128)maxmath.factorial(x.y), overflows<ulong>(x.y) ? ulong.MaxValue : truefactorial(x.y));
                Assert.AreEqual((UInt128)maxmath.factorial(x.z), overflows<ulong>(x.z) ? ulong.MaxValue : truefactorial(x.z));
                Assert.AreEqual((UInt128)maxmath.factorial(x.w), overflows<ulong>(x.w) ? ulong.MaxValue : truefactorial(x.w));
            }
        }


        [Test]
        public static void _long1()
        {
            Random64 r = Random64.New;

            for (long i = 0; i < 34; i++)
            {
                long x = r.NextLong(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x), overflows<long>((UInt128)x) ? long.MaxValue : (Int128)truefactorial((UInt128)x));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 r = Random64.New;

            for (long i = 0; i < 34; i++)
            {
                long2 x = r.NextLong2(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<long>((UInt128)x.x) ? long.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<long>((UInt128)x.y) ? long.MaxValue : (Int128)truefactorial((UInt128)x.y));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 r = Random64.New;

            for (long i = 0; i < 34; i++)
            {
                long3 x = r.NextLong3(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<long>((UInt128)x.x) ? long.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<long>((UInt128)x.y) ? long.MaxValue : (Int128)truefactorial((UInt128)x.y));
                Assert.AreEqual((Int128)maxmath.factorial(x.z), overflows<long>((UInt128)x.z) ? long.MaxValue : (Int128)truefactorial((UInt128)x.z));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 r = Random64.New;

            for (long i = 0; i < 34; i++)
            {
                long4 x = r.NextLong4(0, 40);
                Assert.AreEqual((Int128)maxmath.factorial(x.x), overflows<long>((UInt128)x.x) ? long.MaxValue : (Int128)truefactorial((UInt128)x.x));
                Assert.AreEqual((Int128)maxmath.factorial(x.y), overflows<long>((UInt128)x.y) ? long.MaxValue : (Int128)truefactorial((UInt128)x.y));
                Assert.AreEqual((Int128)maxmath.factorial(x.z), overflows<long>((UInt128)x.z) ? long.MaxValue : (Int128)truefactorial((UInt128)x.z));
                Assert.AreEqual((Int128)maxmath.factorial(x.w), overflows<long>((UInt128)x.w) ? long.MaxValue : (Int128)truefactorial((UInt128)x.w));
            }
        }
    }
}