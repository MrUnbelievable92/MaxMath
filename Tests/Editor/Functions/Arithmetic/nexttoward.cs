using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class nexttoward
    {
        [Test]
        public static void _uint128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 l = rng.NextUInt128();
                UInt128 r = rng.NextUInt128();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        
        [Test]
        public static void _int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 l = rng.NextInt128();
                Int128 r = rng.NextInt128();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        

        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte l = rng.NextByte();
                byte r = rng.NextByte();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte2 l = rng.NextByte2();
                byte2 r = rng.NextByte2();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte3 l = rng.NextByte3();
                byte3 r = rng.NextByte3();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte4 l = rng.NextByte4();
                byte4 r = rng.NextByte4();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte8 l = rng.NextByte8();
                byte8 r = rng.NextByte8();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte16 l = rng.NextByte16();
                byte16 r = rng.NextByte16();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte32 l = rng.NextByte32();
                byte32 r = rng.NextByte32();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        

        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte l = rng.NextSByte();
                sbyte r = rng.NextSByte();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        

        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short l = rng.NextShort();
                short r = rng.NextShort();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        

        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort l = rng.NextUShort();
                ushort r = rng.NextUShort();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 l = rng.NextUShort2();
                ushort2 r = rng.NextUShort2();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 l = rng.NextUShort3();
                ushort3 r = rng.NextUShort3();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 l = rng.NextUShort4();
                ushort4 r = rng.NextUShort4();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 l = rng.NextUShort8();
                ushort8 r = rng.NextUShort8();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 l = rng.NextUShort16();
                ushort16 r = rng.NextUShort16();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int l = rng.NextInt();
                int r = rng.NextInt();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2();

                Assert.AreEqual(maxmath.nexttoward(l, r), math.select(math.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3();

                Assert.AreEqual(maxmath.nexttoward(l, r), math.select(math.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4();

                Assert.AreEqual(maxmath.nexttoward(l, r), math.select(math.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        

        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint l = rng.NextUInt();
                uint r = rng.NextUInt();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 l = rng.NextUInt2();
                uint2 r = rng.NextUInt2();

                Assert.AreEqual(maxmath.nexttoward(l, r), math.select(math.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 l = rng.NextUInt3();
                uint3 r = rng.NextUInt3();

                Assert.AreEqual(maxmath.nexttoward(l, r), math.select(math.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 l = rng.NextUInt4();
                uint4 r = rng.NextUInt4();

                Assert.AreEqual(maxmath.nexttoward(l, r), math.select(math.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 l = rng.NextUInt8();
                uint8 r = rng.NextUInt8();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                long l = rng.NextLong();
                long r = rng.NextLong();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                ulong l = rng.NextULong();
                ulong r = rng.NextULong();

                Assert.AreEqual(maxmath.nexttoward(l, r), l == r ? l : (l < r ? l + 1 : l - 1));
            }
        }
        
        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                ulong2 l = rng.NextULong2();
                ulong2 r = rng.NextULong2();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                ulong3 l = rng.NextULong3();
                ulong3 r = rng.NextULong3();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }
        
        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 25; i++)
            {
                ulong4 l = rng.NextULong4();
                ulong4 r = rng.NextULong4();

                Assert.AreEqual(maxmath.nexttoward(l, r), maxmath.select(maxmath.select(l + 1, l - 1, l > r), l, l == r));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((quarter)rng.NextFloat(), (quarter)quarter.NaN));
            Assert.IsNaN(maxmath.nexttoward((quarter)quarter.NaN, (quarter)rng.NextFloat()));
            Assert.IsNaN(maxmath.nexttoward((quarter)0f, (quarter)quarter.NaN));
            Assert.IsNaN(maxmath.nexttoward((quarter)quarter.NaN, (quarter)0f));
            Assert.IsNaN(maxmath.nexttoward((quarter)quarter.NaN, (quarter)quarter.NaN));
                
            Assert.AreEqual(maxmath.nexttoward((quarter)quarter.NegativeInfinity, (quarter)quarter.NegativeInfinity), (quarter)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter)quarter.NegativeInfinity, (quarter)quarter.PositiveInfinity), (quarter)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter)quarter.PositiveInfinity, (quarter)quarter.NegativeInfinity), (quarter)quarter.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter)quarter.PositiveInfinity, (quarter)quarter.PositiveInfinity), (quarter)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter)quarter.MinValue, (quarter)quarter.NegativeInfinity), (quarter)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter)quarter.MinValue, (quarter)quarter.PositiveInfinity), (quarter)maxmath.nextgreater(quarter.MinValue));
            Assert.AreEqual(maxmath.nexttoward((quarter)quarter.MaxValue, (quarter)quarter.NegativeInfinity), (quarter)maxmath.nextsmaller(quarter.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((quarter)quarter.MaxValue, (quarter)quarter.PositiveInfinity), (quarter)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter)0f, (quarter)quarter.PositiveInfinity), (quarter)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter)0f, (quarter)quarter.NegativeInfinity), (quarter)(-quarter.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((quarter)maxmath.asquarter(0x80), (quarter)quarter.PositiveInfinity), (quarter)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter)maxmath.asquarter(0x80), (quarter)quarter.NegativeInfinity), (quarter)(-quarter.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                quarter from = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);
                quarter to = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);
                quarter next = maxmath.nexttoward(from, to);

                Assert.AreEqual(from, maxmath.nexttoward(from, from));

                if (from < to)
                {
                    Assert.AreEqual(maxmath.nextgreater(from), next);
                }
                else if (from > to)
                {
                    Assert.AreEqual(maxmath.nextsmaller(from), next);
                }
                else
                {
                    Assert.AreEqual(from, next);
                }
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((quarter2)rng.NextFloat2(), (quarter2)quarter.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((quarter2)quarter.NaN, (quarter2)rng.NextFloat2()).x);
            Assert.IsNaN(maxmath.nexttoward((quarter2)0f, (quarter2)quarter.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((quarter2)quarter.NaN, (quarter2)0f).x);
            Assert.IsNaN(maxmath.nexttoward((quarter2)quarter.NaN, (quarter2)quarter.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((quarter2)quarter.NegativeInfinity, (quarter2)quarter.NegativeInfinity), (quarter2)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter2)quarter.NegativeInfinity, (quarter2)quarter.PositiveInfinity), (quarter2)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter2)quarter.PositiveInfinity, (quarter2)quarter.NegativeInfinity), (quarter2)quarter.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter2)quarter.PositiveInfinity, (quarter2)quarter.PositiveInfinity), (quarter2)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter2)quarter.MinValue, (quarter2)quarter.NegativeInfinity), (quarter2)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter2)quarter.MinValue, (quarter2)quarter.PositiveInfinity), (quarter2)maxmath.nextgreater(quarter.MinValue));
            Assert.AreEqual(maxmath.nexttoward((quarter2)quarter.MaxValue, (quarter2)quarter.NegativeInfinity), (quarter2)maxmath.nextsmaller(quarter.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((quarter2)quarter.MaxValue, (quarter2)quarter.PositiveInfinity), (quarter2)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter2)0f, (quarter2)quarter.PositiveInfinity), (quarter2)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter2)0f, (quarter2)quarter.NegativeInfinity), (quarter2)(-quarter.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((quarter2)maxmath.asquarter(0x80), (quarter2)quarter.PositiveInfinity), (quarter2)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter2)maxmath.asquarter(0x80), (quarter2)quarter.NegativeInfinity), (quarter2)(-quarter.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                quarter2 from = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);
                quarter2 to = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);
                quarter2 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((quarter3)rng.NextFloat3(), (quarter3)quarter.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((quarter3)quarter.NaN, (quarter3)rng.NextFloat3()).x);
            Assert.IsNaN(maxmath.nexttoward((quarter3)0f, (quarter3)quarter.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((quarter3)quarter.NaN, (quarter3)0f).x);
            Assert.IsNaN(maxmath.nexttoward((quarter3)quarter.NaN, (quarter3)quarter.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((quarter3)quarter.NegativeInfinity, (quarter3)quarter.NegativeInfinity), (quarter3)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter3)quarter.NegativeInfinity, (quarter3)quarter.PositiveInfinity), (quarter3)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter3)quarter.PositiveInfinity, (quarter3)quarter.NegativeInfinity), (quarter3)quarter.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter3)quarter.PositiveInfinity, (quarter3)quarter.PositiveInfinity), (quarter3)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter3)quarter.MinValue, (quarter3)quarter.NegativeInfinity), (quarter3)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter3)quarter.MinValue, (quarter3)quarter.PositiveInfinity), (quarter3)maxmath.nextgreater(quarter.MinValue));
            Assert.AreEqual(maxmath.nexttoward((quarter3)quarter.MaxValue, (quarter3)quarter.NegativeInfinity), (quarter3)maxmath.nextsmaller(quarter.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((quarter3)quarter.MaxValue, (quarter3)quarter.PositiveInfinity), (quarter3)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter3)0f, (quarter3)quarter.PositiveInfinity), (quarter3)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter3)0f, (quarter3)quarter.NegativeInfinity), (quarter3)(-quarter.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((quarter3)maxmath.asquarter(0x80), (quarter3)quarter.PositiveInfinity), (quarter3)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter3)maxmath.asquarter(0x80), (quarter3)quarter.NegativeInfinity), (quarter3)(-quarter.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                quarter3 from = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);
                quarter3 to = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);
                quarter3 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((quarter4)rng.NextFloat4(), (quarter4)quarter.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((quarter4)quarter.NaN, (quarter4)rng.NextFloat4()).x);
            Assert.IsNaN(maxmath.nexttoward((quarter4)0f, (quarter4)quarter.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((quarter4)quarter.NaN, (quarter4)0f).x);
            Assert.IsNaN(maxmath.nexttoward((quarter4)quarter.NaN, (quarter4)quarter.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((quarter4)quarter.NegativeInfinity, (quarter4)quarter.NegativeInfinity), (quarter4)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter4)quarter.NegativeInfinity, (quarter4)quarter.PositiveInfinity), (quarter4)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter4)quarter.PositiveInfinity, (quarter4)quarter.NegativeInfinity), (quarter4)quarter.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter4)quarter.PositiveInfinity, (quarter4)quarter.PositiveInfinity), (quarter4)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter4)quarter.MinValue, (quarter4)quarter.NegativeInfinity), (quarter4)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter4)quarter.MinValue, (quarter4)quarter.PositiveInfinity), (quarter4)maxmath.nextgreater(quarter.MinValue));
            Assert.AreEqual(maxmath.nexttoward((quarter4)quarter.MaxValue, (quarter4)quarter.NegativeInfinity), (quarter4)maxmath.nextsmaller(quarter.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((quarter4)quarter.MaxValue, (quarter4)quarter.PositiveInfinity), (quarter4)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter4)0f, (quarter4)quarter.PositiveInfinity), (quarter4)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter4)0f, (quarter4)quarter.NegativeInfinity), (quarter4)(-quarter.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((quarter4)maxmath.asquarter(0x80), (quarter4)quarter.PositiveInfinity), (quarter4)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter4)maxmath.asquarter(0x80), (quarter4)quarter.NegativeInfinity), (quarter4)(-quarter.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                quarter4 from = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);
                quarter4 to = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);
                quarter4 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((quarter8)rng.NextFloat8(), (quarter8)quarter.NaN).x0);
            Assert.IsNaN(maxmath.nexttoward((quarter8)quarter.NaN, (quarter8)rng.NextFloat8()).x0);
            Assert.IsNaN(maxmath.nexttoward((quarter8)0f, (quarter8)quarter.NaN).x0);
            Assert.IsNaN(maxmath.nexttoward((quarter8)quarter.NaN, (quarter8)0f).x0);
            Assert.IsNaN(maxmath.nexttoward((quarter8)quarter.NaN, (quarter8)quarter.NaN).x0);
                
            Assert.AreEqual(maxmath.nexttoward((quarter8)quarter.NegativeInfinity, (quarter8)quarter.NegativeInfinity), (quarter8)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter8)quarter.NegativeInfinity, (quarter8)quarter.PositiveInfinity), (quarter8)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter8)quarter.PositiveInfinity, (quarter8)quarter.NegativeInfinity), (quarter8)quarter.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter8)quarter.PositiveInfinity, (quarter8)quarter.PositiveInfinity), (quarter8)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter8)quarter.MinValue, (quarter8)quarter.NegativeInfinity), (quarter8)quarter.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((quarter8)quarter.MinValue, (quarter8)quarter.PositiveInfinity), (quarter8)maxmath.nextgreater(quarter.MinValue));
            Assert.AreEqual(maxmath.nexttoward((quarter8)quarter.MaxValue, (quarter8)quarter.NegativeInfinity), (quarter8)maxmath.nextsmaller(quarter.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((quarter8)quarter.MaxValue, (quarter8)quarter.PositiveInfinity), (quarter8)quarter.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((quarter8)0f, (quarter8)quarter.PositiveInfinity), (quarter8)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter8)0f, (quarter8)quarter.NegativeInfinity), (quarter8)(-quarter.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((quarter8)maxmath.asquarter(0x80), (quarter8)quarter.PositiveInfinity), (quarter8)quarter.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((quarter8)maxmath.asquarter(0x80), (quarter8)quarter.NegativeInfinity), (quarter8)(-quarter.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                quarter8 from = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);
                quarter8 to = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);
                quarter8 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((half)rng.NextFloat(), (half)float.NaN));
            Assert.IsNaN(maxmath.nexttoward((half)float.NaN, (half)rng.NextFloat()));
            Assert.IsNaN(maxmath.nexttoward((half)0f, (half)float.NaN));
            Assert.IsNaN(maxmath.nexttoward((half)float.NaN, (half)0f));
            Assert.IsNaN(maxmath.nexttoward((half)float.NaN, (half)float.NaN));
                
            Assert.AreEqual(maxmath.nexttoward((half)float.NegativeInfinity, (half)float.NegativeInfinity), (half)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half)float.NegativeInfinity, (half)float.PositiveInfinity), (half)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half)float.PositiveInfinity, (half)float.NegativeInfinity), (half)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((half)float.PositiveInfinity, (half)float.PositiveInfinity), (half)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half)half.MinValueAsHalf, (half)float.NegativeInfinity), (half)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half)half.MinValueAsHalf, (half)float.PositiveInfinity), (half)maxmath.nextgreater(half.MinValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half)half.MaxValueAsHalf, (half)float.NegativeInfinity), (half)maxmath.nextsmaller(half.MaxValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half)half.MaxValueAsHalf, (half)float.PositiveInfinity), (half)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half)0f, (half)float.PositiveInfinity), maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half)0f, (half)float.NegativeInfinity), maxmath.ashalf((ushort)0x8001));
            Assert.AreEqual(maxmath.nexttoward((half)maxmath.ashalf((ushort)0x8000), (half)float.PositiveInfinity), maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half)maxmath.ashalf((ushort)0x8000), (half)float.NegativeInfinity), maxmath.ashalf((ushort)0x8001));

            for (int i = 0; i < 25; i++)
            {
                half from = (half)rng.NextFloat(half.MinValueAsHalf, half.MaxValueAsHalf);
                half to = (half)rng.NextFloat(half.MinValueAsHalf, half.MaxValueAsHalf);
                half next = maxmath.nexttoward(from, to);

                Assert.AreEqual(from, maxmath.nexttoward(from, from));

                if (from < to)
                {
                    Assert.AreEqual(maxmath.nextgreater(from), next);
                }
                else if (from > to)
                {
                    Assert.AreEqual(maxmath.nextsmaller(from), next);
                }
                else
                {
                    Assert.AreEqual(from, next);
                }
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((half2)rng.NextFloat2(), (half2)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((half2)float.NaN, (half2)rng.NextFloat2()).x);
            Assert.IsNaN(maxmath.nexttoward((half2)0f, (half2)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((half2)float.NaN, (half2)0f).x);
            Assert.IsNaN(maxmath.nexttoward((half2)float.NaN, (half2)float.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((half2)float.NegativeInfinity, (half2)float.NegativeInfinity), (half2)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half2)float.NegativeInfinity, (half2)float.PositiveInfinity), (half2)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half2)float.PositiveInfinity, (half2)float.NegativeInfinity), (half2)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((half2)float.PositiveInfinity, (half2)float.PositiveInfinity), (half2)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half2)half.MinValueAsHalf, (half2)float.NegativeInfinity), (half2)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half2)half.MinValueAsHalf, (half2)float.PositiveInfinity), (half2)maxmath.nextgreater(half.MinValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half2)half.MaxValueAsHalf, (half2)float.NegativeInfinity), (half2)maxmath.nextsmaller(half.MaxValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half2)half.MaxValueAsHalf, (half2)float.PositiveInfinity), (half2)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half2)0f, (half2)float.PositiveInfinity), (half2)maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half2)0f, (half2)float.NegativeInfinity), (half2)maxmath.ashalf((ushort)0x8001));
            Assert.AreEqual(maxmath.nexttoward((half2)maxmath.ashalf((ushort)0x8000), (half2)float.PositiveInfinity), (half2)maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half2)maxmath.ashalf((ushort)0x8000), (half2)float.NegativeInfinity), (half2)maxmath.ashalf((ushort)0x8001));

            for (int i = 0; i < 25; i++)
            {
                half2 from = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);
                half2 to = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);
                half2 next = maxmath.nexttoward(from, to);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((half3)rng.NextFloat3(), (half3)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((half3)float.NaN, (half3)rng.NextFloat3()).x);
            Assert.IsNaN(maxmath.nexttoward((half3)0f, (half3)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((half3)float.NaN, (half3)0f).x);
            Assert.IsNaN(maxmath.nexttoward((half3)float.NaN, (half3)float.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((half3)float.NegativeInfinity, (half3)float.NegativeInfinity), (half3)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half3)float.NegativeInfinity, (half3)float.PositiveInfinity), (half3)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half3)float.PositiveInfinity, (half3)float.NegativeInfinity), (half3)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((half3)float.PositiveInfinity, (half3)float.PositiveInfinity), (half3)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half3)half.MinValueAsHalf, (half3)float.NegativeInfinity), (half3)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half3)half.MinValueAsHalf, (half3)float.PositiveInfinity), (half3)maxmath.nextgreater(half.MinValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half3)half.MaxValueAsHalf, (half3)float.NegativeInfinity), (half3)maxmath.nextsmaller(half.MaxValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half3)half.MaxValueAsHalf, (half3)float.PositiveInfinity), (half3)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half3)0f, (half3)float.PositiveInfinity), (half3)maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half3)0f, (half3)float.NegativeInfinity), (half3)maxmath.ashalf((ushort)0x8001));
            Assert.AreEqual(maxmath.nexttoward((half3)maxmath.ashalf((ushort)0x8000), (half3)float.PositiveInfinity), (half3)maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half3)maxmath.ashalf((ushort)0x8000), (half3)float.NegativeInfinity), (half3)maxmath.ashalf((ushort)0x8001));

            for (int i = 0; i < 25; i++)
            {
                half3 from = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);
                half3 to = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);
                half3 next = maxmath.nexttoward(from, to);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((half4)rng.NextFloat4(), (half4)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((half4)float.NaN, (half4)rng.NextFloat4()).x);
            Assert.IsNaN(maxmath.nexttoward((half4)0f, (half4)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((half4)float.NaN, (half4)0f).x);
            Assert.IsNaN(maxmath.nexttoward((half4)float.NaN, (half4)float.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((half4)float.NegativeInfinity, (half4)float.NegativeInfinity), (half4)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half4)float.NegativeInfinity, (half4)float.PositiveInfinity), (half4)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half4)float.PositiveInfinity, (half4)float.NegativeInfinity), (half4)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((half4)float.PositiveInfinity, (half4)float.PositiveInfinity), (half4)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half4)half.MinValueAsHalf, (half4)float.NegativeInfinity), (half4)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half4)half.MinValueAsHalf, (half4)float.PositiveInfinity), (half4)maxmath.nextgreater(half.MinValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half4)half.MaxValueAsHalf, (half4)float.NegativeInfinity), (half4)maxmath.nextsmaller(half.MaxValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half4)half.MaxValueAsHalf, (half4)float.PositiveInfinity), (half4)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half4)0f, (half4)float.PositiveInfinity), (half4)maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half4)0f, (half4)float.NegativeInfinity), (half4)maxmath.ashalf((ushort)0x8001));
            Assert.AreEqual(maxmath.nexttoward((half4)maxmath.ashalf((ushort)0x8000), (half4)float.PositiveInfinity), (half4)maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half4)maxmath.ashalf((ushort)0x8000), (half4)float.NegativeInfinity), (half4)maxmath.ashalf((ushort)0x8001));

            for (int i = 0; i < 25; i++)
            {
                half4 from = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);
                half4 to = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);
                half4 next = maxmath.nexttoward(from, to);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward((half8)rng.NextFloat8(), (half8)float.NaN).x0);
            Assert.IsNaN(maxmath.nexttoward((half8)float.NaN, (half8)rng.NextFloat8()).x0);
            Assert.IsNaN(maxmath.nexttoward((half8)0f, (half8)float.NaN).x0);
            Assert.IsNaN(maxmath.nexttoward((half8)float.NaN, (half8)0f).x0);
            Assert.IsNaN(maxmath.nexttoward((half8)float.NaN, (half8)float.NaN).x0);
                
            Assert.AreEqual(maxmath.nexttoward((half8)float.NegativeInfinity, (half8)float.NegativeInfinity), (half8)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half8)float.NegativeInfinity, (half8)float.PositiveInfinity), (half8)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half8)float.PositiveInfinity, (half8)float.NegativeInfinity), (half8)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((half8)float.PositiveInfinity, (half8)float.PositiveInfinity), (half8)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half8)half.MinValueAsHalf, (half8)float.NegativeInfinity), (half8)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((half8)half.MinValueAsHalf, (half8)float.PositiveInfinity), (half8)maxmath.nextgreater(half.MinValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half8)half.MaxValueAsHalf, (half8)float.NegativeInfinity), (half8)maxmath.nextsmaller(half.MaxValueAsHalf));
            Assert.AreEqual(maxmath.nexttoward((half8)half.MaxValueAsHalf, (half8)float.PositiveInfinity), (half8)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((half8)0f, (half8)float.PositiveInfinity), (half8)maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half8)0f, (half8)float.NegativeInfinity), (half8)maxmath.ashalf((ushort)0x8001));
            Assert.AreEqual(maxmath.nexttoward((half8)maxmath.ashalf((ushort)0x8000), (half8)float.PositiveInfinity), (half8)maxmath.ashalf((ushort)1));
            Assert.AreEqual(maxmath.nexttoward((half8)maxmath.ashalf((ushort)0x8000), (half8)float.NegativeInfinity), (half8)maxmath.ashalf((ushort)0x8001));

            for (int i = 0; i < 25; i++)
            {
                half8 from = (half8)rng.NextFloat8(half.MinValue, half.MaxValue);
                half8 to = (half8)rng.NextFloat8(half.MinValue, half.MaxValue);
                half8 next = maxmath.nexttoward(from, to);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextFloat(), float.NaN));
            Assert.IsNaN(maxmath.nexttoward(float.NaN, rng.NextFloat()));
            Assert.IsNaN(maxmath.nexttoward(0f, float.NaN));
            Assert.IsNaN(maxmath.nexttoward(float.NaN, 0f));
            Assert.IsNaN(maxmath.nexttoward(float.NaN, float.NaN));
                
            Assert.AreEqual(maxmath.nexttoward(float.NegativeInfinity, float.NegativeInfinity), float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward(float.NegativeInfinity, float.PositiveInfinity), float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward(float.PositiveInfinity, float.NegativeInfinity), float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward(float.PositiveInfinity, float.PositiveInfinity), float.PositiveInfinity);
            
            Assert.AreEqual(maxmath.nexttoward(float.MinValue, float.NegativeInfinity), float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward(float.MinValue, float.PositiveInfinity), maxmath.nextgreater(float.MinValue));
            Assert.AreEqual(maxmath.nexttoward(float.MaxValue, float.NegativeInfinity), maxmath.nextsmaller(float.MaxValue));
            Assert.AreEqual(maxmath.nexttoward(float.MaxValue, float.PositiveInfinity), float.PositiveInfinity);
            
            Assert.AreEqual(maxmath.nexttoward(0f, float.PositiveInfinity), float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward(0f, float.NegativeInfinity), -float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward(math.asfloat(0x8000_0000), float.PositiveInfinity), float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward(math.asfloat(0x8000_0000), float.NegativeInfinity), -float.Epsilon);

            for (int i = 0; i < 25; i++)
            {
                float from = rng.NextFloat(float.MinValue / 2, float.MaxValue / 2);
                float to = rng.NextFloat(float.MinValue / 2, float.MaxValue / 2);
                float next = maxmath.nexttoward(from, to);
                
                Assert.AreEqual(from, maxmath.nexttoward(from, from));

                if (from < to)
                {
                    Assert.AreEqual(maxmath.nextgreater(from), next);
                }
                else if (from > to)
                {
                    Assert.AreEqual(maxmath.nextsmaller(from), next);
                }
                else
                {
                    Assert.AreEqual(from, next);
                }
            }
        }
        
        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextFloat2(), (float2)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((float2)float.NaN, rng.NextFloat2()).x);
            Assert.IsNaN(maxmath.nexttoward((float2)0f, (float2)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((float2)float.NaN, (float2)0f).x);
            Assert.IsNaN(maxmath.nexttoward((float2)float.NaN, (float2)float.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((float2)float.NegativeInfinity, (float2)float.NegativeInfinity), (float2)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float2)float.NegativeInfinity, (float2)float.PositiveInfinity), (float2)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float2)float.PositiveInfinity, (float2)float.NegativeInfinity), (float2)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((float2)float.PositiveInfinity, (float2)float.PositiveInfinity), (float2)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((float2)float.MinValue, (float2)float.NegativeInfinity), (float2)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float2)float.MinValue, (float2)float.PositiveInfinity), (float2)maxmath.nextgreater(float.MinValue));
            Assert.AreEqual(maxmath.nexttoward((float2)float.MaxValue, (float2)float.NegativeInfinity), (float2)maxmath.nextsmaller(float.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((float2)float.MaxValue, (float2)float.PositiveInfinity), (float2)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((float2)0f, (float2)float.PositiveInfinity), (float2)float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((float2)0f, (float2)float.NegativeInfinity), (float2)(-float.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((float2)math.asfloat(0x8000_0000), (float2)float.PositiveInfinity), (float2)float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((float2)math.asfloat(0x8000_0000), (float2)float.NegativeInfinity), (float2)(-float.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                float2 from = rng.NextFloat2(float.MinValue / 2, float.MaxValue / 2);
                float2 to = rng.NextFloat2(float.MinValue / 2, float.MaxValue / 2);
                float2 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextFloat3(), (float3)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((float3)float.NaN, rng.NextFloat3()).x);
            Assert.IsNaN(maxmath.nexttoward((float3)0f, (float3)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((float3)float.NaN, (float3)0f).x);
            Assert.IsNaN(maxmath.nexttoward((float3)float.NaN, (float3)float.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((float3)float.NegativeInfinity, (float3)float.NegativeInfinity), (float3)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float3)float.NegativeInfinity, (float3)float.PositiveInfinity), (float3)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float3)float.PositiveInfinity, (float3)float.NegativeInfinity), (float3)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((float3)float.PositiveInfinity, (float3)float.PositiveInfinity), (float3)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((float3)float.MinValue, (float3)float.NegativeInfinity), (float3)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float3)float.MinValue, (float3)float.PositiveInfinity), (float3)maxmath.nextgreater(float.MinValue));
            Assert.AreEqual(maxmath.nexttoward((float3)float.MaxValue, (float3)float.NegativeInfinity), (float3)maxmath.nextsmaller(float.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((float3)float.MaxValue, (float3)float.PositiveInfinity), (float3)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((float3)0f, (float3)float.PositiveInfinity), (float3)float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((float3)0f, (float3)float.NegativeInfinity), (float3)(-float.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((float3)math.asfloat(0x8000_0000), (float3)float.PositiveInfinity), (float3)float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((float3)math.asfloat(0x8000_0000), (float3)float.NegativeInfinity), (float3)(-float.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                float3 from = rng.NextFloat3(float.MinValue / 2, float.MaxValue / 2);
                float3 to = rng.NextFloat3(float.MinValue / 2, float.MaxValue / 2);
                float3 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextFloat4(), (float4)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((float4)float.NaN, rng.NextFloat4()).x);
            Assert.IsNaN(maxmath.nexttoward((float4)0f, (float4)float.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((float4)float.NaN, (float4)0f).x);
            Assert.IsNaN(maxmath.nexttoward((float4)float.NaN, (float4)float.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((float4)float.NegativeInfinity, (float4)float.NegativeInfinity), (float4)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float4)float.NegativeInfinity, (float4)float.PositiveInfinity), (float4)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float4)float.PositiveInfinity, (float4)float.NegativeInfinity), (float4)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((float4)float.PositiveInfinity, (float4)float.PositiveInfinity), (float4)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((float4)float.MinValue, (float4)float.NegativeInfinity), (float4)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float4)float.MinValue, (float4)float.PositiveInfinity), (float4)maxmath.nextgreater(float.MinValue));
            Assert.AreEqual(maxmath.nexttoward((float4)float.MaxValue, (float4)float.NegativeInfinity), (float4)maxmath.nextsmaller(float.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((float4)float.MaxValue, (float4)float.PositiveInfinity), (float4)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((float4)0f, (float4)float.PositiveInfinity), (float4)float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((float4)0f, (float4)float.NegativeInfinity), (float4)(-float.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((float4)math.asfloat(0x8000_0000), (float4)float.PositiveInfinity), (float4)float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((float4)math.asfloat(0x8000_0000), (float4)float.NegativeInfinity), (float4)(-float.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                float4 from = rng.NextFloat4(float.MinValue / 2, float.MaxValue / 2);
                float4 to = rng.NextFloat4(float.MinValue / 2, float.MaxValue / 2);
                float4 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextFloat8(), (float8)float.NaN).x0);
            Assert.IsNaN(maxmath.nexttoward((float8)float.NaN, rng.NextFloat8()).x0);
            Assert.IsNaN(maxmath.nexttoward((float8)0f, (float8)float.NaN).x0);
            Assert.IsNaN(maxmath.nexttoward((float8)float.NaN, (float8)0f).x0);
            Assert.IsNaN(maxmath.nexttoward((float8)float.NaN, (float8)float.NaN).x0);
                
            Assert.AreEqual(maxmath.nexttoward((float8)float.NegativeInfinity, (float8)float.NegativeInfinity), (float8)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float8)float.NegativeInfinity, (float8)float.PositiveInfinity), (float8)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float8)float.PositiveInfinity, (float8)float.NegativeInfinity), (float8)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((float8)float.PositiveInfinity, (float8)float.PositiveInfinity), (float8)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((float8)float.MinValue, (float8)float.NegativeInfinity), (float8)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((float8)float.MinValue, (float8)float.PositiveInfinity), (float8)maxmath.nextgreater(float.MinValue));
            Assert.AreEqual(maxmath.nexttoward((float8)float.MaxValue, (float8)float.NegativeInfinity), (float8)maxmath.nextsmaller(float.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((float8)float.MaxValue, (float8)float.PositiveInfinity), (float8)float.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((float8)0f, (float8)float.PositiveInfinity), (float8)float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((float8)0f, (float8)float.NegativeInfinity), (float8)(-float.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((float8)math.asfloat(0x8000_0000), (float8)float.PositiveInfinity), (float8)float.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((float8)math.asfloat(0x8000_0000), (float8)float.NegativeInfinity), (float8)(-float.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                float8 from = rng.NextFloat8(float.MinValue / 2, float.MaxValue / 2);
                float8 to = rng.NextFloat8(float.MinValue / 2, float.MaxValue / 2);
                float8 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        
        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextDouble(), double.NaN));
            Assert.IsNaN(maxmath.nexttoward(double.NaN, rng.NextDouble()));
            Assert.IsNaN(maxmath.nexttoward(0f, double.NaN));
            Assert.IsNaN(maxmath.nexttoward(double.NaN, 0f));
            Assert.IsNaN(maxmath.nexttoward(double.NaN, double.NaN));
                
            Assert.AreEqual(maxmath.nexttoward(double.NegativeInfinity, double.NegativeInfinity), double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward(double.NegativeInfinity, double.PositiveInfinity), double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward(double.PositiveInfinity, double.NegativeInfinity), double.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward(double.PositiveInfinity, double.PositiveInfinity), double.PositiveInfinity);
            
            Assert.AreEqual(maxmath.nexttoward(double.MinValue, double.NegativeInfinity), double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward(double.MinValue, double.PositiveInfinity), maxmath.nextgreater(double.MinValue));
            Assert.AreEqual(maxmath.nexttoward(double.MaxValue, double.NegativeInfinity), maxmath.nextsmaller(double.MaxValue));
            Assert.AreEqual(maxmath.nexttoward(double.MaxValue, double.PositiveInfinity), double.PositiveInfinity);
            
            Assert.AreEqual(maxmath.nexttoward(0f, double.PositiveInfinity), double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward(0f, double.NegativeInfinity), -double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward(math.asdouble(0x8000_0000_0000_0000), double.PositiveInfinity), double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward(math.asdouble(0x8000_0000_0000_0000), double.NegativeInfinity), -double.Epsilon);

            for (int i = 0; i < 25; i++)
            {
                double from = rng.NextDouble(double.MinValue / 2, double.MaxValue / 2);
                double to = rng.NextDouble(double.MinValue / 2, double.MaxValue / 2);
                double next = maxmath.nexttoward(from, to);
                
                Assert.AreEqual(from, maxmath.nexttoward(from, from));

                if (from < to)
                {
                    Assert.AreEqual(maxmath.nextgreater(from), next);
                }
                else if (from > to)
                {
                    Assert.AreEqual(maxmath.nextsmaller(from), next);
                }
                else
                {
                    Assert.AreEqual(from, next);
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextDouble2(), (double2)double.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((double2)double.NaN, rng.NextDouble2()).x);
            Assert.IsNaN(maxmath.nexttoward((double2)0f, (double2)double.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((double2)double.NaN, (double2)0f).x);
            Assert.IsNaN(maxmath.nexttoward((double2)double.NaN, (double2)double.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((double2)double.NegativeInfinity, (double2)double.NegativeInfinity), (double2)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double2)double.NegativeInfinity, (double2)double.PositiveInfinity), (double2)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double2)double.PositiveInfinity, (double2)double.NegativeInfinity), (double2)double.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((double2)double.PositiveInfinity, (double2)double.PositiveInfinity), (double2)double.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((double2)double.MinValue, (double2)double.NegativeInfinity), (double2)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double2)double.MinValue, (double2)double.PositiveInfinity), (double2)maxmath.nextgreater(double.MinValue));
            Assert.AreEqual(maxmath.nexttoward((double2)double.MaxValue, (double2)double.NegativeInfinity), (double2)maxmath.nextsmaller(double.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((double2)double.MaxValue, (double2)double.PositiveInfinity), (double2)double.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((double2)0f, (double2)double.PositiveInfinity), (double2)double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((double2)0f, (double2)double.NegativeInfinity), (double2)(-double.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((double2)math.asdouble(0x8000_0000_0000_0000), (double2)double.PositiveInfinity), (double2)double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((double2)math.asdouble(0x8000_0000_0000_0000), (double2)double.NegativeInfinity), (double2)(-double.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                double2 from = rng.NextDouble2(double.MinValue / 2, double.MaxValue / 2);
                double2 to = rng.NextDouble2(double.MinValue / 2, double.MaxValue / 2);
                double2 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextDouble3(), (double3)double.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((double3)double.NaN, rng.NextDouble3()).x);
            Assert.IsNaN(maxmath.nexttoward((double3)0f, (double3)double.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((double3)double.NaN, (double3)0f).x);
            Assert.IsNaN(maxmath.nexttoward((double3)double.NaN, (double3)double.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((double3)double.NegativeInfinity, (double3)double.NegativeInfinity), (double3)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double3)double.NegativeInfinity, (double3)double.PositiveInfinity), (double3)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double3)double.PositiveInfinity, (double3)double.NegativeInfinity), (double3)double.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((double3)double.PositiveInfinity, (double3)double.PositiveInfinity), (double3)double.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((double3)double.MinValue, (double3)double.NegativeInfinity), (double3)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double3)double.MinValue, (double3)double.PositiveInfinity), (double3)maxmath.nextgreater(double.MinValue));
            Assert.AreEqual(maxmath.nexttoward((double3)double.MaxValue, (double3)double.NegativeInfinity), (double3)maxmath.nextsmaller(double.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((double3)double.MaxValue, (double3)double.PositiveInfinity), (double3)double.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((double3)0f, (double3)double.PositiveInfinity), (double3)double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((double3)0f, (double3)double.NegativeInfinity), (double3)(-double.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((double3)math.asdouble(0x8000_0000_0000_0000), (double3)double.PositiveInfinity), (double3)double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((double3)math.asdouble(0x8000_0000_0000_0000), (double3)double.NegativeInfinity), (double3)(-double.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                double3 from = rng.NextDouble3(double.MinValue / 2, double.MaxValue / 2);
                double3 to = rng.NextDouble3(double.MinValue / 2, double.MaxValue / 2);
                double3 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;
            
            Assert.IsNaN(maxmath.nexttoward(rng.NextDouble4(), (double4)double.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((double4)double.NaN, rng.NextDouble4()).x);
            Assert.IsNaN(maxmath.nexttoward((double4)0f, (double4)double.NaN).x);
            Assert.IsNaN(maxmath.nexttoward((double4)double.NaN, (double4)0f).x);
            Assert.IsNaN(maxmath.nexttoward((double4)double.NaN, (double4)double.NaN).x);
                
            Assert.AreEqual(maxmath.nexttoward((double4)double.NegativeInfinity, (double4)double.NegativeInfinity), (double4)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double4)double.NegativeInfinity, (double4)double.PositiveInfinity), (double4)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double4)double.PositiveInfinity, (double4)double.NegativeInfinity), (double4)double.PositiveInfinity);
            Assert.AreEqual(maxmath.nexttoward((double4)double.PositiveInfinity, (double4)double.PositiveInfinity), (double4)double.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((double4)double.MinValue, (double4)double.NegativeInfinity), (double4)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nexttoward((double4)double.MinValue, (double4)double.PositiveInfinity), (double4)maxmath.nextgreater(double.MinValue));
            Assert.AreEqual(maxmath.nexttoward((double4)double.MaxValue, (double4)double.NegativeInfinity), (double4)maxmath.nextsmaller(double.MaxValue));
            Assert.AreEqual(maxmath.nexttoward((double4)double.MaxValue, (double4)double.PositiveInfinity), (double4)double.PositiveInfinity);

            Assert.AreEqual(maxmath.nexttoward((double4)0f, (double4)double.PositiveInfinity), (double4)double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((double4)0f, (double4)double.NegativeInfinity), (double4)(-double.Epsilon));
            Assert.AreEqual(maxmath.nexttoward((double4)math.asdouble(0x8000_0000_0000_0000), (double4)double.PositiveInfinity), (double4)double.Epsilon);
            Assert.AreEqual(maxmath.nexttoward((double4)math.asdouble(0x8000_0000_0000_0000), (double4)double.NegativeInfinity), (double4)(-double.Epsilon));

            for (int i = 0; i < 25; i++)
            {
                double4 from = rng.NextDouble4(double.MinValue / 2, double.MaxValue / 2);
                double4 to = rng.NextDouble4(double.MinValue / 2, double.MaxValue / 2);
                double4 next = maxmath.nexttoward(from, to);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(from[j], maxmath.nexttoward(from, from)[j]);

                    if (from[j] < to[j])
                    {
                        Assert.AreEqual(maxmath.nextgreater(from)[j], next[j]);
                    }
                    else if (from[j] > to[j])
                    {
                        Assert.AreEqual(maxmath.nextsmaller(from)[j], next[j]);
                    }
                    else
                    {
                        Assert.AreEqual(from[j], next[j]);
                    }
                }
            }
        }
    }
}
