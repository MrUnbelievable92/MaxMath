using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class f_floorlog2
    {
        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte16 test = rng.NextByte16();

                Assert.AreEqual(math.floorlog2(test), new byte16((byte)math.floorlog2(test.x0),
                                                                    (byte)math.floorlog2(test.x1),
                                                                    (byte)math.floorlog2(test.x2),
                                                                    (byte)math.floorlog2(test.x3),
                                                                    (byte)math.floorlog2(test.x4),
                                                                    (byte)math.floorlog2(test.x5),
                                                                    (byte)math.floorlog2(test.x6),
                                                                    (byte)math.floorlog2(test.x7),
                                                                    (byte)math.floorlog2(test.x8),
                                                                    (byte)math.floorlog2(test.x9),
                                                                    (byte)math.floorlog2(test.x10),
                                                                    (byte)math.floorlog2(test.x11),
                                                                    (byte)math.floorlog2(test.x12),
                                                                    (byte)math.floorlog2(test.x13),
                                                                    (byte)math.floorlog2(test.x14),
                                                                    (byte)math.floorlog2(test.x15)));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte32 test = rng.NextByte32();

                Assert.AreEqual(math.floorlog2(test), new byte32((byte)math.floorlog2(test.x0),
                                                                    (byte)math.floorlog2(test.x1),
                                                                    (byte)math.floorlog2(test.x2),
                                                                    (byte)math.floorlog2(test.x3),
                                                                    (byte)math.floorlog2(test.x4),
                                                                    (byte)math.floorlog2(test.x5),
                                                                    (byte)math.floorlog2(test.x6),
                                                                    (byte)math.floorlog2(test.x7),
                                                                    (byte)math.floorlog2(test.x8),
                                                                    (byte)math.floorlog2(test.x9),
                                                                    (byte)math.floorlog2(test.x10),
                                                                    (byte)math.floorlog2(test.x11),
                                                                    (byte)math.floorlog2(test.x12),
                                                                    (byte)math.floorlog2(test.x13),
                                                                    (byte)math.floorlog2(test.x14),
                                                                    (byte)math.floorlog2(test.x15),
                                                                    (byte)math.floorlog2(test.x16),
                                                                    (byte)math.floorlog2(test.x17),
                                                                    (byte)math.floorlog2(test.x18),
                                                                    (byte)math.floorlog2(test.x19),
                                                                    (byte)math.floorlog2(test.x20),
                                                                    (byte)math.floorlog2(test.x21),
                                                                    (byte)math.floorlog2(test.x22),
                                                                    (byte)math.floorlog2(test.x23),
                                                                    (byte)math.floorlog2(test.x24),
                                                                    (byte)math.floorlog2(test.x25),
                                                                    (byte)math.floorlog2(test.x26),
                                                                    (byte)math.floorlog2(test.x27),
                                                                    (byte)math.floorlog2(test.x28),
                                                                    (byte)math.floorlog2(test.x29),
                                                                    (byte)math.floorlog2(test.x30),
                                                                    (byte)math.floorlog2(test.x31)));
            }
        }


        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 test = rng.NextUShort8();

                Assert.AreEqual(math.floorlog2(test), new ushort8((ushort)math.floorlog2(test.x0),
                                                                     (ushort)math.floorlog2(test.x1),
                                                                     (ushort)math.floorlog2(test.x2),
                                                                     (ushort)math.floorlog2(test.x3),
                                                                     (ushort)math.floorlog2(test.x4),
                                                                     (ushort)math.floorlog2(test.x5),
                                                                     (ushort)math.floorlog2(test.x6),
                                                                     (ushort)math.floorlog2(test.x7)));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 test = rng.NextUShort16();

                Assert.AreEqual(math.floorlog2(test), new ushort16((ushort)math.floorlog2(test.x0),
                                                                      (ushort)math.floorlog2(test.x1),
                                                                      (ushort)math.floorlog2(test.x2),
                                                                      (ushort)math.floorlog2(test.x3),
                                                                      (ushort)math.floorlog2(test.x4),
                                                                      (ushort)math.floorlog2(test.x5),
                                                                      (ushort)math.floorlog2(test.x6),
                                                                      (ushort)math.floorlog2(test.x7),
                                                                      (ushort)math.floorlog2(test.x8),
                                                                      (ushort)math.floorlog2(test.x9),
                                                                      (ushort)math.floorlog2(test.x10),
                                                                      (ushort)math.floorlog2(test.x11),
                                                                      (ushort)math.floorlog2(test.x12),
                                                                      (ushort)math.floorlog2(test.x13),
                                                                      (ushort)math.floorlog2(test.x14),
                                                                      (ushort)math.floorlog2(test.x15)));
            }
        }
    }
}