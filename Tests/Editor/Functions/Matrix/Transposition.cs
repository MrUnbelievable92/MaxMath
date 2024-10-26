using NUnit.Framework;

namespace MaxMath.Tests
{
    public static class f_transpose
    {
        [Test]
        public static void _long2x2()
        {
            long2x2 v = new long2x2(t_long2.TestData_LHS[0], t_long2.TestData_LHS[1]);

            Assert.AreEqual(new long2x2(v.c0.x, v.c0.y,
                                        v.c1.x, v.c1.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _long2x3()
        {
            long2x3 v = new long2x3(t_long2.TestData_LHS[0], t_long2.TestData_LHS[1], t_long2.TestData_LHS[2]);

            Assert.AreEqual(new long3x2(v.c0.x, v.c0.y,
                                        v.c1.x, v.c1.y,
                                        v.c2.x, v.c2.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _long2x4()
        {
            long2x4 v = new long2x4(t_long2.TestData_LHS[0], t_long2.TestData_LHS[1], t_long2.TestData_LHS[2], t_long2.TestData_LHS[3]);

            Assert.AreEqual(new long4x2(v.c0.x, v.c0.y,
                                        v.c1.x, v.c1.y,
                                        v.c2.x, v.c2.y,
                                        v.c3.x, v.c3.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _long3x2()
        {
            long3x2 v = new long3x2(t_long3.TestData_LHS[0], t_long3.TestData_LHS[1]);

            Assert.AreEqual(new long2x3(v.c0.x, v.c0.y, v.c0.z,
                                        v.c1.x, v.c1.y, v.c1.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _long3x3()
        {
            long3x3 v = new long3x3(t_long3.TestData_LHS[0], t_long3.TestData_LHS[1], t_long3.TestData_LHS[2]);

            Assert.AreEqual(new long3x3(v.c0.x, v.c0.y, v.c0.z,
                                        v.c1.x, v.c1.y, v.c1.z,
                                        v.c2.x, v.c2.y, v.c2.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _long3x4()
        {
            long3x4 v = new long3x4(t_long3.TestData_LHS[0], t_long3.TestData_LHS[1], t_long3.TestData_LHS[2], t_long3.TestData_LHS[3]);

            Assert.AreEqual(new long4x3(v.c0.x, v.c0.y, v.c0.z,
                                        v.c1.x, v.c1.y, v.c1.z,
                                        v.c2.x, v.c2.y, v.c2.z,
                                        v.c3.x, v.c3.y, v.c3.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _long4x2()
        {
            long4x2 v = new long4x2(t_long4.TestData_LHS[0], t_long4.TestData_LHS[1]);

            Assert.AreEqual(new long2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                        v.c1.x, v.c1.y, v.c1.z, v.c1.w),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _long4x3()
        {
            long4x3 v = new long4x3(t_long4.TestData_LHS[0], t_long4.TestData_LHS[1], t_long4.TestData_LHS[2]);

            Assert.AreEqual(new long3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                        v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                        v.c2.x, v.c2.y, v.c2.z, v.c2.w),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _long4x4()
        {
            long4x4 v = new long4x4(t_long4.TestData_LHS[0], t_long4.TestData_LHS[1], t_long4.TestData_LHS[2], t_long4.TestData_LHS[3]);

            Assert.AreEqual(new long4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                        v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                        v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                                        v.c3.x, v.c3.y, v.c3.z, v.c3.w),
                            maxmath.transpose(v));
        }


        [Test]
        public static void _short2x2()
        {
            short2x2 v = new short2x2(t_short2.TestData_LHS[0], t_short2.TestData_LHS[1]);

            Assert.AreEqual(new short2x2(v.c0.x, v.c0.y,
                                         v.c1.x, v.c1.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _short2x3()
        {
            short2x3 v = new short2x3(t_short2.TestData_LHS[0], t_short2.TestData_LHS[1], t_short2.TestData_LHS[2]);

            Assert.AreEqual(new short3x2(v.c0.x, v.c0.y,
                                         v.c1.x, v.c1.y,
                                         v.c2.x, v.c2.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _short2x4()
        {
            short2x4 v = new short2x4(t_short2.TestData_LHS[0], t_short2.TestData_LHS[1], t_short2.TestData_LHS[2], t_short2.TestData_LHS[3]);

            Assert.AreEqual(new short4x2(v.c0.x, v.c0.y,
                                         v.c1.x, v.c1.y,
                                         v.c2.x, v.c2.y,
                                         v.c3.x, v.c3.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _short3x2()
        {
            short3x2 v = new short3x2(t_short3.TestData_LHS[0], t_short3.TestData_LHS[1]);

            Assert.AreEqual(new short2x3(v.c0.x, v.c0.y, v.c0.z,
                                         v.c1.x, v.c1.y, v.c1.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _short3x3()
        {
            short3x3 v = new short3x3(t_short3.TestData_LHS[0], t_short3.TestData_LHS[1], t_short3.TestData_LHS[2]);

            Assert.AreEqual(new short3x3(v.c0.x, v.c0.y, v.c0.z,
                                         v.c1.x, v.c1.y, v.c1.z,
                                         v.c2.x, v.c2.y, v.c2.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _short3x4()
        {
            short3x4 v = new short3x4(t_short3.TestData_LHS[0], t_short3.TestData_LHS[1], t_short3.TestData_LHS[2], t_short3.TestData_LHS[3]);

            Assert.AreEqual(new short4x3(v.c0.x, v.c0.y, v.c0.z,
                                         v.c1.x, v.c1.y, v.c1.z,
                                         v.c2.x, v.c2.y, v.c2.z,
                                         v.c3.x, v.c3.y, v.c3.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _short4x2()
        {
            short4x2 v = new short4x2(t_short4.TestData_LHS[0], t_short4.TestData_LHS[1]);

            Assert.AreEqual(new short2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                         v.c1.x, v.c1.y, v.c1.z, v.c1.w),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _short4x3()
        {
            short4x3 v = new short4x3(t_short4.TestData_LHS[0], t_short4.TestData_LHS[1], t_short4.TestData_LHS[2]);

            Assert.AreEqual(new short3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                         v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                         v.c2.x, v.c2.y, v.c2.z, v.c2.w),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _short4x4()
        {
            short4x4 v = new short4x4(t_short4.TestData_LHS[0], t_short4.TestData_LHS[1], t_short4.TestData_LHS[2], t_short4.TestData_LHS[3]);

            Assert.AreEqual(new short4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                         v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                         v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                                         v.c3.x, v.c3.y, v.c3.z, v.c3.w),
                            maxmath.transpose(v));
        }


        [Test]
        public static void _sbyte2x2()
        {
            sbyte2x2 v = new sbyte2x2(t_sbyte2.TestData_LHS[0], t_sbyte2.TestData_LHS[1]);

            Assert.AreEqual(new sbyte2x2(v.c0.x, v.c0.y,
                                         v.c1.x, v.c1.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _sbyte2x3()
        {
            sbyte2x3 v = new sbyte2x3(t_sbyte2.TestData_LHS[0], t_sbyte2.TestData_LHS[1], t_sbyte2.TestData_LHS[2]);

            Assert.AreEqual(new sbyte3x2(v.c0.x, v.c0.y,
                                         v.c1.x, v.c1.y,
                                         v.c2.x, v.c2.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _sbyte2x4()
        {
            sbyte2x4 v = new sbyte2x4(t_sbyte2.TestData_LHS[0], t_sbyte2.TestData_LHS[1], t_sbyte2.TestData_LHS[2], t_sbyte2.TestData_LHS[3]);

            Assert.AreEqual(new sbyte4x2(v.c0.x, v.c0.y,
                                         v.c1.x, v.c1.y,
                                         v.c2.x, v.c2.y,
                                         v.c3.x, v.c3.y),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _sbyte3x2()
        {
            sbyte3x2 v = new sbyte3x2(t_sbyte3.TestData_LHS[0], t_sbyte3.TestData_LHS[1]);

            Assert.AreEqual(new sbyte2x3(v.c0.x, v.c0.y, v.c0.z,
                                         v.c1.x, v.c1.y, v.c1.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _sbyte3x3()
        {
            sbyte3x3 v = new sbyte3x3(t_sbyte3.TestData_LHS[0], t_sbyte3.TestData_LHS[1], t_sbyte3.TestData_LHS[2]);

            Assert.AreEqual(new sbyte3x3(v.c0.x, v.c0.y, v.c0.z,
                                         v.c1.x, v.c1.y, v.c1.z,
                                         v.c2.x, v.c2.y, v.c2.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _sbyte3x4()
        {
            sbyte3x4 v = new sbyte3x4(t_sbyte3.TestData_LHS[0], t_sbyte3.TestData_LHS[1], t_sbyte3.TestData_LHS[2], t_sbyte3.TestData_LHS[3]);

            Assert.AreEqual(new sbyte4x3(v.c0.x, v.c0.y, v.c0.z,
                                         v.c1.x, v.c1.y, v.c1.z,
                                         v.c2.x, v.c2.y, v.c2.z,
                                         v.c3.x, v.c3.y, v.c3.z),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _sbyte4x2()
        {
            sbyte4x2 v = new sbyte4x2(t_sbyte4.TestData_LHS[0], t_sbyte4.TestData_LHS[1]);

            Assert.AreEqual(new sbyte2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                         v.c1.x, v.c1.y, v.c1.z, v.c1.w),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _sbyte4x3()
        {
            sbyte4x3 v = new sbyte4x3(t_sbyte4.TestData_LHS[0], t_sbyte4.TestData_LHS[1], t_sbyte4.TestData_LHS[2]);

            Assert.AreEqual(new sbyte3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                         v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                         v.c2.x, v.c2.y, v.c2.z, v.c2.w),
                            maxmath.transpose(v));
        }

        [Test]
        public static void _sbyte4x4()
        {
            sbyte4x4 v = new sbyte4x4(t_sbyte4.TestData_LHS[0], t_sbyte4.TestData_LHS[1], t_sbyte4.TestData_LHS[2], t_sbyte4.TestData_LHS[3]);

            Assert.AreEqual(new sbyte4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                                         v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                                         v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                                         v.c3.x, v.c3.y, v.c3.z, v.c3.w),
                            maxmath.transpose(v));
        }
    }
}