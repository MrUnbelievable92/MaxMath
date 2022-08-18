using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class divrem
    {
        [Test]
        public static void CONSTbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 1; i <= byte.MaxValue; i++)
            {
                byte left  = rng.NextByte();

                byte q = maxmath.divrem(left, (byte)i, out byte r);

                Assert.AreEqual((byte)(left / (byte)i), q);
                Assert.AreEqual((byte)(left % (byte)i), r);
            }
        }

        [Test]
        public static void CONSTbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 1; i <= byte.MaxValue; i++)
            {
                byte2 left  = rng.NextByte2();

                byte2 q = maxmath.divrem(left, (byte)i, out byte2 r);

                Assert.AreEqual(new byte2((byte)(left.x / (byte)i), 
                                          (byte)(left.y / (byte)i)), q);
                Assert.AreEqual(new byte2((byte)(left.x % (byte)i), 
                                          (byte)(left.y % (byte)i)), r);
            }
        }

        [Test]
        public static void CONSTbyte3()
        {
            Random8 rng = Random8.New;
            
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                byte3 left  = rng.NextByte3();

                byte3 q = maxmath.divrem(left, (byte)i, out byte3 r);
                
                Assert.AreEqual(new byte3((byte)(left.x / (byte)i), 
                                          (byte)(left.y / (byte)i), 
                                          (byte)(left.z / (byte)i)), q);
                Assert.AreEqual(new byte3((byte)(left.x % (byte)i), 
                                          (byte)(left.y % (byte)i), 
                                          (byte)(left.z % (byte)i)), r);
            }
        }

        [Test]
        public static void CONSTbyte4()
        {
            Random8 rng = Random8.New;
            
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                byte4 left  = rng.NextByte4();

                byte4 q = maxmath.divrem(left, (byte)i, out byte4 r);
                
                Assert.AreEqual(new byte4((byte)(left.x / (byte)i), 
                                          (byte)(left.y / (byte)i), 
                                          (byte)(left.z / (byte)i), 
                                          (byte)(left.w / (byte)i)), q);
                Assert.AreEqual(new byte4((byte)(left.x % (byte)i), 
                                          (byte)(left.y % (byte)i), 
                                          (byte)(left.z % (byte)i), 
                                          (byte)(left.w % (byte)i)), r);
            }
        }

        [Test]
        public static void CONSTbyte8()
        {
            Random8 rng = Random8.New;
            
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                byte8 left  = rng.NextByte8();

                byte8 q = maxmath.divrem(left, (byte)i, out byte8 r);
                
                Assert.AreEqual(new byte8((byte)(left.x0 / (byte)i), 
                                          (byte)(left.x1 / (byte)i), 
                                          (byte)(left.x2 / (byte)i), 
                                          (byte)(left.x3 / (byte)i), 
                                          (byte)(left.x4 / (byte)i), 
                                          (byte)(left.x5 / (byte)i), 
                                          (byte)(left.x6 / (byte)i), 
                                          (byte)(left.x7 / (byte)i)), q);
                Assert.AreEqual(new byte8((byte)(left.x0 % (byte)i), 
                                          (byte)(left.x1 % (byte)i), 
                                          (byte)(left.x2 % (byte)i), 
                                          (byte)(left.x3 % (byte)i), 
                                          (byte)(left.x4 % (byte)i), 
                                          (byte)(left.x5 % (byte)i), 
                                          (byte)(left.x6 % (byte)i), 
                                          (byte)(left.x7 % (byte)i)), r);
            }
        }

        [Test]
        public static void CONSTbyte16()
        {
            Random8 rng = Random8.New;
            
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                byte16 left  = rng.NextByte16();

                byte16 q = maxmath.divrem(left, (byte)i, out byte16 r);
                
                Assert.AreEqual(new byte16((byte)(left.x0  / (byte)i), 
                                           (byte)(left.x1  / (byte)i), 
                                           (byte)(left.x2  / (byte)i), 
                                           (byte)(left.x3  / (byte)i), 
                                           (byte)(left.x4  / (byte)i), 
                                           (byte)(left.x5  / (byte)i), 
                                           (byte)(left.x6  / (byte)i), 
                                           (byte)(left.x7  / (byte)i),
                                           (byte)(left.x8  / (byte)i), 
                                           (byte)(left.x9  / (byte)i), 
                                           (byte)(left.x10 / (byte)i), 
                                           (byte)(left.x11 / (byte)i), 
                                           (byte)(left.x12 / (byte)i), 
                                           (byte)(left.x13 / (byte)i), 
                                           (byte)(left.x14 / (byte)i), 
                                           (byte)(left.x15 / (byte)i)), q);







                Assert.AreEqual(new byte16((byte)(left.x0  % (byte)i), 
                                           (byte)(left.x1  % (byte)i), 
                                           (byte)(left.x2  % (byte)i), 
                                           (byte)(left.x3  % (byte)i), 
                                           (byte)(left.x4  % (byte)i), 
                                           (byte)(left.x5  % (byte)i), 
                                           (byte)(left.x6  % (byte)i), 
                                           (byte)(left.x7  % (byte)i),
                                           (byte)(left.x8  % (byte)i), 
                                           (byte)(left.x9  % (byte)i), 
                                           (byte)(left.x10 % (byte)i), 
                                           (byte)(left.x11 % (byte)i), 
                                           (byte)(left.x12 % (byte)i), 
                                           (byte)(left.x13 % (byte)i), 
                                           (byte)(left.x14 % (byte)i), 
                                           (byte)(left.x15 % (byte)i)), r);
            }
        }

        [Test]
        public static void CONSTbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 1; i <= byte.MaxValue; i++)
            {
                byte32 left  = rng.NextByte32();

                byte32 q = maxmath.divrem(left, (byte)i, out byte32 r);
                
                Assert.AreEqual(new byte32((byte)(left.x0  / (byte)i), 
                                           (byte)(left.x1  / (byte)i), 
                                           (byte)(left.x2  / (byte)i), 
                                           (byte)(left.x3  / (byte)i), 
                                           (byte)(left.x4  / (byte)i), 
                                           (byte)(left.x5  / (byte)i), 
                                           (byte)(left.x6  / (byte)i), 
                                           (byte)(left.x7  / (byte)i),
                                           (byte)(left.x8  / (byte)i), 
                                           (byte)(left.x9  / (byte)i), 
                                           (byte)(left.x10 / (byte)i), 
                                           (byte)(left.x11 / (byte)i), 
                                           (byte)(left.x12 / (byte)i), 
                                           (byte)(left.x13 / (byte)i), 
                                           (byte)(left.x14 / (byte)i), 
                                           (byte)(left.x15 / (byte)i),
                                           (byte)(left.x16 / (byte)i), 
                                           (byte)(left.x17 / (byte)i), 
                                           (byte)(left.x18 / (byte)i), 
                                           (byte)(left.x19 / (byte)i), 
                                           (byte)(left.x20 / (byte)i), 
                                           (byte)(left.x21 / (byte)i), 
                                           (byte)(left.x22 / (byte)i), 
                                           (byte)(left.x23 / (byte)i),
                                           (byte)(left.x24 / (byte)i), 
                                           (byte)(left.x25 / (byte)i), 
                                           (byte)(left.x26 / (byte)i), 
                                           (byte)(left.x27 / (byte)i), 
                                           (byte)(left.x28 / (byte)i), 
                                           (byte)(left.x29 / (byte)i), 
                                           (byte)(left.x30 / (byte)i), 
                                           (byte)(left.x31 / (byte)i)), q);
                Assert.AreEqual(new byte32((byte)(left.x0  % (byte)i), 
                                           (byte)(left.x1  % (byte)i), 
                                           (byte)(left.x2  % (byte)i), 
                                           (byte)(left.x3  % (byte)i), 
                                           (byte)(left.x4  % (byte)i), 
                                           (byte)(left.x5  % (byte)i), 
                                           (byte)(left.x6  % (byte)i), 
                                           (byte)(left.x7  % (byte)i),
                                           (byte)(left.x8  % (byte)i), 
                                           (byte)(left.x9  % (byte)i), 
                                           (byte)(left.x10 % (byte)i), 
                                           (byte)(left.x11 % (byte)i), 
                                           (byte)(left.x12 % (byte)i), 
                                           (byte)(left.x13 % (byte)i), 
                                           (byte)(left.x14 % (byte)i), 
                                           (byte)(left.x15 % (byte)i),
                                           (byte)(left.x16 % (byte)i), 
                                           (byte)(left.x17 % (byte)i), 
                                           (byte)(left.x18 % (byte)i), 
                                           (byte)(left.x19 % (byte)i), 
                                           (byte)(left.x20 % (byte)i), 
                                           (byte)(left.x21 % (byte)i), 
                                           (byte)(left.x22 % (byte)i), 
                                           (byte)(left.x23 % (byte)i),
                                           (byte)(left.x24 % (byte)i), 
                                           (byte)(left.x25 % (byte)i), 
                                           (byte)(left.x26 % (byte)i), 
                                           (byte)(left.x27 % (byte)i), 
                                           (byte)(left.x28 % (byte)i), 
                                           (byte)(left.x29 % (byte)i), 
                                           (byte)(left.x30 % (byte)i), 
                                           (byte)(left.x31 % (byte)i)), r);
            }
        }

        [Test]
        public static void byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                byte2 left  = rng.NextByte2();
                byte2 right = rng.NextByte2();

                right = maxmath.select(right, 1, right == 0);

                byte2 q = maxmath.divrem(left, right, out byte2 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                byte3 left  = rng.NextByte3();
                byte3 right = rng.NextByte3();

                right = maxmath.select(right, 1, right == 0);

                byte3 q = maxmath.divrem(left, right, out byte3 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                byte4 left  = rng.NextByte4();
                byte4 right = rng.NextByte4();

                right = maxmath.select(right, 1, right == 0);

                byte4 q = maxmath.divrem(left, right, out byte4 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                byte8 left  = rng.NextByte8();
                byte8 right = rng.NextByte8();

                right = maxmath.select(right, 1, right == 0);

                byte8 q = maxmath.divrem(left, right, out byte8 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                byte16 left  = rng.NextByte16();
                byte16 right = rng.NextByte16();

                right = maxmath.select(right, 1, right == 0);

                byte16 q = maxmath.divrem(left, right, out byte16 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                byte32 left  = rng.NextByte32();
                byte32 right = rng.NextByte32();

                right = maxmath.select(right, 1, right == 0);

                byte32 q = maxmath.divrem(left, right, out byte32 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }


        [Test]
        public static void ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                ushort2 left  = rng.NextUShort2();
                ushort2 right = rng.NextUShort2();

                right = maxmath.select(right, 1, right == 0);

                ushort2 q = maxmath.divrem(left, right, out ushort2 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                ushort3 left  = rng.NextUShort3();
                ushort3 right = rng.NextUShort3();

                right = maxmath.select(right, 1, right == 0);

                ushort3 q = maxmath.divrem(left, right, out ushort3 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                ushort4 left  = rng.NextUShort4();
                ushort4 right = rng.NextUShort4();

                right = maxmath.select(right, 1, right == 0);

                ushort4 q = maxmath.divrem(left, right, out ushort4 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                ushort8 left  = rng.NextUShort8();
                ushort8 right = rng.NextUShort8();

                right = maxmath.select(right, 1, right == 0);

                ushort8 q = maxmath.divrem(left, right, out ushort8 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                ushort16 left  = rng.NextUShort16();
                ushort16 right = rng.NextUShort16();

                right = maxmath.select(right, 1, right == 0);

                ushort16 q = maxmath.divrem(left, right, out ushort16 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }


        [Test]
        public static void uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 15; i++)
            {
                uint2 left  = rng.NextUInt2();
                uint2 right = rng.NextUInt2();

                right = math.select(right, 1, right == 0);

                uint2 q = maxmath.divrem(left, right, out uint2 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 15; i++)
            {
                uint3 left  = rng.NextUInt3();
                uint3 right = rng.NextUInt3();

                right = math.select(right, 1, right == 0);

                uint3 q = maxmath.divrem(left, right, out uint3 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 15; i++)
            {
                uint4 left  = rng.NextUInt4();
                uint4 right = rng.NextUInt4();

                right = math.select(right, 1, right == 0);

                uint4 q = maxmath.divrem(left, right, out uint4 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 15; i++)
            {
                uint8 left  = rng.NextUInt8();
                uint8 right = rng.NextUInt8();

                right = maxmath.select(right, 1, right == 0);

                uint8 q = maxmath.divrem(left, right, out uint8 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }


        
        [Test]
        public static void CONSTsbyte()
        {
            Random8 rng = Random8.New;

            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                sbyte left  = rng.NextSByte();

                sbyte q = maxmath.divrem(left, (sbyte)i, out sbyte r);

                Assert.AreEqual((sbyte)(left / (sbyte)i), q);
                Assert.AreEqual((sbyte)(left % (sbyte)i), r);
            }
        }

        [Test]
        public static void CONSTsbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                sbyte2 left  = rng.NextSByte2();

                sbyte2 q = maxmath.divrem(left, (sbyte)i, out sbyte2 r);

                Assert.AreEqual(new sbyte2((sbyte)(left.x / (sbyte)i), 
                                          (sbyte)(left.y / (sbyte)i)), q);
                Assert.AreEqual(new sbyte2((sbyte)(left.x % (sbyte)i), 
                                          (sbyte)(left.y % (sbyte)i)), r);
            }
        }

        [Test]
        public static void CONSTsbyte3()
        {
            Random8 rng = Random8.New;
            
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                sbyte3 left  = rng.NextSByte3();

                sbyte3 q = maxmath.divrem(left, (sbyte)i, out sbyte3 r);
                
                Assert.AreEqual(new sbyte3((sbyte)(left.x / (sbyte)i), 
                                          (sbyte)(left.y / (sbyte)i), 
                                          (sbyte)(left.z / (sbyte)i)), q);
                Assert.AreEqual(new sbyte3((sbyte)(left.x % (sbyte)i), 
                                          (sbyte)(left.y % (sbyte)i), 
                                          (sbyte)(left.z % (sbyte)i)), r);
            }
        }

        [Test]
        public static void CONSTsbyte4()
        {
            Random8 rng = Random8.New;
            
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                sbyte4 left  = rng.NextSByte4();

                sbyte4 q = maxmath.divrem(left, (sbyte)i, out sbyte4 r);
                
                Assert.AreEqual(new sbyte4((sbyte)(left.x / (sbyte)i), 
                                          (sbyte)(left.y / (sbyte)i), 
                                          (sbyte)(left.z / (sbyte)i), 
                                          (sbyte)(left.w / (sbyte)i)), q);
                Assert.AreEqual(new sbyte4((sbyte)(left.x % (sbyte)i), 
                                          (sbyte)(left.y % (sbyte)i), 
                                          (sbyte)(left.z % (sbyte)i), 
                                          (sbyte)(left.w % (sbyte)i)), r);
            }
        }

        [Test]
        public static void CONSTsbyte8()
        {
            Random8 rng = Random8.New;
            
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                sbyte8 left  = rng.NextSByte8();

                sbyte8 q = maxmath.divrem(left, (sbyte)i, out sbyte8 r);
                
                Assert.AreEqual(new sbyte8((sbyte)(left.x0 / (sbyte)i), 
                                          (sbyte)(left.x1 / (sbyte)i), 
                                          (sbyte)(left.x2 / (sbyte)i), 
                                          (sbyte)(left.x3 / (sbyte)i), 
                                          (sbyte)(left.x4 / (sbyte)i), 
                                          (sbyte)(left.x5 / (sbyte)i), 
                                          (sbyte)(left.x6 / (sbyte)i), 
                                          (sbyte)(left.x7 / (sbyte)i)), q);
                Assert.AreEqual(new sbyte8((sbyte)(left.x0 % (sbyte)i), 
                                          (sbyte)(left.x1 % (sbyte)i), 
                                          (sbyte)(left.x2 % (sbyte)i), 
                                          (sbyte)(left.x3 % (sbyte)i), 
                                          (sbyte)(left.x4 % (sbyte)i), 
                                          (sbyte)(left.x5 % (sbyte)i), 
                                          (sbyte)(left.x6 % (sbyte)i), 
                                          (sbyte)(left.x7 % (sbyte)i)), r);
            }
        }

        [Test]
        public static void CONSTsbyte16()
        {
            Random8 rng = Random8.New;
            
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                sbyte16 left  = rng.NextSByte16();

                sbyte16 q = maxmath.divrem(left, (sbyte)i, out sbyte16 r);
                
                Assert.AreEqual(new sbyte16((sbyte)(left.x0  / (sbyte)i), 
                                           (sbyte)(left.x1  / (sbyte)i), 
                                           (sbyte)(left.x2  / (sbyte)i), 
                                           (sbyte)(left.x3  / (sbyte)i), 
                                           (sbyte)(left.x4  / (sbyte)i), 
                                           (sbyte)(left.x5  / (sbyte)i), 
                                           (sbyte)(left.x6  / (sbyte)i), 
                                           (sbyte)(left.x7  / (sbyte)i),
                                           (sbyte)(left.x8  / (sbyte)i), 
                                           (sbyte)(left.x9  / (sbyte)i), 
                                           (sbyte)(left.x10 / (sbyte)i), 
                                           (sbyte)(left.x11 / (sbyte)i), 
                                           (sbyte)(left.x12 / (sbyte)i), 
                                           (sbyte)(left.x13 / (sbyte)i), 
                                           (sbyte)(left.x14 / (sbyte)i), 
                                           (sbyte)(left.x15 / (sbyte)i)), q);
                Assert.AreEqual(new sbyte16((sbyte)(left.x0  % (sbyte)i), 
                                           (sbyte)(left.x1  % (sbyte)i), 
                                           (sbyte)(left.x2  % (sbyte)i), 
                                           (sbyte)(left.x3  % (sbyte)i), 
                                           (sbyte)(left.x4  % (sbyte)i), 
                                           (sbyte)(left.x5  % (sbyte)i), 
                                           (sbyte)(left.x6  % (sbyte)i), 
                                           (sbyte)(left.x7  % (sbyte)i),
                                           (sbyte)(left.x8  % (sbyte)i), 
                                           (sbyte)(left.x9  % (sbyte)i), 
                                           (sbyte)(left.x10 % (sbyte)i), 
                                           (sbyte)(left.x11 % (sbyte)i), 
                                           (sbyte)(left.x12 % (sbyte)i), 
                                           (sbyte)(left.x13 % (sbyte)i), 
                                           (sbyte)(left.x14 % (sbyte)i), 
                                           (sbyte)(left.x15 % (sbyte)i)), r);
            }
        }

        [Test]
        public static void CONSTsbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 1; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                sbyte32 left  = rng.NextSByte32();

                sbyte32 q = maxmath.divrem(left, (sbyte)i, out sbyte32 r);
                
                Assert.AreEqual(new sbyte32((sbyte)(left.x0  / (sbyte)i), 
                                           (sbyte)(left.x1  / (sbyte)i), 
                                           (sbyte)(left.x2  / (sbyte)i), 
                                           (sbyte)(left.x3  / (sbyte)i), 
                                           (sbyte)(left.x4  / (sbyte)i), 
                                           (sbyte)(left.x5  / (sbyte)i), 
                                           (sbyte)(left.x6  / (sbyte)i), 
                                           (sbyte)(left.x7  / (sbyte)i),
                                           (sbyte)(left.x8  / (sbyte)i), 
                                           (sbyte)(left.x9  / (sbyte)i), 
                                           (sbyte)(left.x10 / (sbyte)i), 
                                           (sbyte)(left.x11 / (sbyte)i), 
                                           (sbyte)(left.x12 / (sbyte)i), 
                                           (sbyte)(left.x13 / (sbyte)i), 
                                           (sbyte)(left.x14 / (sbyte)i), 
                                           (sbyte)(left.x15 / (sbyte)i),
                                           (sbyte)(left.x16 / (sbyte)i), 
                                           (sbyte)(left.x17 / (sbyte)i), 
                                           (sbyte)(left.x18 / (sbyte)i), 
                                           (sbyte)(left.x19 / (sbyte)i), 
                                           (sbyte)(left.x20 / (sbyte)i), 
                                           (sbyte)(left.x21 / (sbyte)i), 
                                           (sbyte)(left.x22 / (sbyte)i), 
                                           (sbyte)(left.x23 / (sbyte)i),
                                           (sbyte)(left.x24 / (sbyte)i), 
                                           (sbyte)(left.x25 / (sbyte)i), 
                                           (sbyte)(left.x26 / (sbyte)i), 
                                           (sbyte)(left.x27 / (sbyte)i), 
                                           (sbyte)(left.x28 / (sbyte)i), 
                                           (sbyte)(left.x29 / (sbyte)i), 
                                           (sbyte)(left.x30 / (sbyte)i), 
                                           (sbyte)(left.x31 / (sbyte)i)), q);
                Assert.AreEqual(new sbyte32((sbyte)(left.x0  % (sbyte)i), 
                                           (sbyte)(left.x1  % (sbyte)i), 
                                           (sbyte)(left.x2  % (sbyte)i), 
                                           (sbyte)(left.x3  % (sbyte)i), 
                                           (sbyte)(left.x4  % (sbyte)i), 
                                           (sbyte)(left.x5  % (sbyte)i), 
                                           (sbyte)(left.x6  % (sbyte)i), 
                                           (sbyte)(left.x7  % (sbyte)i),
                                           (sbyte)(left.x8  % (sbyte)i), 
                                           (sbyte)(left.x9  % (sbyte)i), 
                                           (sbyte)(left.x10 % (sbyte)i), 
                                           (sbyte)(left.x11 % (sbyte)i), 
                                           (sbyte)(left.x12 % (sbyte)i), 
                                           (sbyte)(left.x13 % (sbyte)i), 
                                           (sbyte)(left.x14 % (sbyte)i), 
                                           (sbyte)(left.x15 % (sbyte)i),
                                           (sbyte)(left.x16 % (sbyte)i), 
                                           (sbyte)(left.x17 % (sbyte)i), 
                                           (sbyte)(left.x18 % (sbyte)i), 
                                           (sbyte)(left.x19 % (sbyte)i), 
                                           (sbyte)(left.x20 % (sbyte)i), 
                                           (sbyte)(left.x21 % (sbyte)i), 
                                           (sbyte)(left.x22 % (sbyte)i), 
                                           (sbyte)(left.x23 % (sbyte)i),
                                           (sbyte)(left.x24 % (sbyte)i), 
                                           (sbyte)(left.x25 % (sbyte)i), 
                                           (sbyte)(left.x26 % (sbyte)i), 
                                           (sbyte)(left.x27 % (sbyte)i), 
                                           (sbyte)(left.x28 % (sbyte)i), 
                                           (sbyte)(left.x29 % (sbyte)i), 
                                           (sbyte)(left.x30 % (sbyte)i), 
                                           (sbyte)(left.x31 % (sbyte)i)), r);
            }
        }

        [Test]
        public static void sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                sbyte2 left  = rng.NextSByte2();
                sbyte2 right = rng.NextSByte2();

                right = maxmath.select(right, 1, right == 0);

                sbyte2 q = maxmath.divrem(left, right, out sbyte2 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                sbyte3 left  = rng.NextSByte3();
                sbyte3 right = rng.NextSByte3();

                right = maxmath.select(right, 1, right == 0);

                sbyte3 q = maxmath.divrem(left, right, out sbyte3 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                sbyte4 left  = rng.NextSByte4();
                sbyte4 right = rng.NextSByte4();

                right = maxmath.select(right, 1, right == 0);

                sbyte4 q = maxmath.divrem(left, right, out sbyte4 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                sbyte8 left  = rng.NextSByte8();
                sbyte8 right = rng.NextSByte8();

                right = maxmath.select(right, 1, right == 0);

                sbyte8 q = maxmath.divrem(left, right, out sbyte8 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                sbyte16 left  = rng.NextSByte16();
                sbyte16 right = rng.NextSByte16();

                right = maxmath.select(right, 1, right == 0);

                sbyte16 q = maxmath.divrem(left, right, out sbyte16 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 15; i++)
            {
                sbyte32 left  = rng.NextSByte32();
                sbyte32 right = rng.NextSByte32();

                right = maxmath.select(right, 1, right == 0);

                sbyte32 q = maxmath.divrem(left, right, out sbyte32 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }


        [Test]
        public static void short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                short2 left  = rng.NextShort2();
                short2 right = rng.NextShort2();

                right = maxmath.select(right, 1, right == 0);

                short2 q = maxmath.divrem(left, right, out short2 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                short3 left  = rng.NextShort3();
                short3 right = rng.NextShort3();

                right = maxmath.select(right, 1, right == 0);

                short3 q = maxmath.divrem(left, right, out short3 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                short4 left  = rng.NextShort4();
                short4 right = rng.NextShort4();

                right = maxmath.select(right, 1, right == 0);

                short4 q = maxmath.divrem(left, right, out short4 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                short8 left  = rng.NextShort8();
                short8 right = rng.NextShort8();

                right = maxmath.select(right, 1, right == 0);

                short8 q = maxmath.divrem(left, right, out short8 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 15; i++)
            {
                short16 left  = rng.NextShort16();
                short16 right = rng.NextShort16();

                right = maxmath.select(right, 1, right == 0);

                short16 q = maxmath.divrem(left, right, out short16 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }


        [Test]
        public static void int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 15; i++)
            {
                int2 left  = rng.NextInt2();
                int2 right = rng.NextInt2();

                right = math.select(right, 1, right == 0);

                int2 q = maxmath.divrem(left, right, out int2 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 15; i++)
            {
                int3 left  = rng.NextInt3();
                int3 right = rng.NextInt3();

                right = math.select(right, 1, right == 0);

                int3 q = maxmath.divrem(left, right, out int3 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 15; i++)
            {
                int4 left  = rng.NextInt4();
                int4 right = rng.NextInt4();

                right = math.select(right, 1, right == 0);

                int4 q = maxmath.divrem(left, right, out int4 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }

        [Test]
        public static void int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 15; i++)
            {
                int8 left  = rng.NextInt8();
                int8 right = rng.NextInt8();

                right = maxmath.select(right, 1, right == 0);

                int8 q = maxmath.divrem(left, right, out int8 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }


        [Test]
        public static void uint128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 15; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                right = right == 0 ? 1 : right;

                UInt128 q = maxmath.divrem(left, right, out UInt128 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }


        [Test]
        public static void int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 15; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();

                right = right == 0 ? 1 : right;

                Int128 q = maxmath.divrem(left, right, out Int128 r);

                Assert.AreEqual(left / right, q);
                Assert.AreEqual(left % right, r);
            }
        }
    }
}