using NUnit.Framework;

namespace MaxMath.Tests
{
    public static class f_PROMISE_cmp_scalar_quarter
    {
        [Test]
        public static void _equal()
        {
            quarter lhs;
            quarter rhs;

            lhs = (quarter)0f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsEqualTo(rhs), lhs.IsEqualTo(rhs, neitherNaN: true));

            lhs = (quarter)0f;
            rhs = (quarter)0f;
            Assert.AreEqual(lhs.IsEqualTo(rhs), lhs.IsEqualTo(rhs, neitherNaN: true));

            lhs = (quarter)1f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsEqualTo(rhs), lhs.IsEqualTo(rhs, neitherNaN: true, neitherZero: true));

            lhs = (quarter)2f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsEqualTo(rhs), lhs.IsEqualTo(rhs, neitherNaN: true, neitherZero: true));
        }

        [Test]
        public static void _notequal()
        {
            quarter lhs;
            quarter rhs;

            lhs = (quarter)0f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsNotEqualTo(rhs), lhs.IsNotEqualTo(rhs, neitherNaN: true));

            lhs = (quarter)0f;
            rhs = (quarter)0f;
            Assert.AreEqual(lhs.IsNotEqualTo(rhs), lhs.IsNotEqualTo(rhs, neitherNaN: true));

            lhs = (quarter)1f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsNotEqualTo(rhs), lhs.IsNotEqualTo(rhs, neitherNaN: true, neitherZero: true));

            lhs = (quarter)2f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsNotEqualTo(rhs), lhs.IsNotEqualTo(rhs, neitherNaN: true, neitherZero: true));
        }

        [Test]
        public static void _greater()
        {
            quarter lhs;
            quarter rhs;

            lhs = (quarter)0f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsGreaterThan(rhs), lhs.IsGreaterThan(rhs, neitherNaN: true));

            lhs = (quarter)0f;
            rhs = (quarter)0f;
            Assert.AreEqual(lhs.IsGreaterThan(rhs), lhs.IsGreaterThan(rhs, neitherNaN: true));

            lhs = (quarter)1f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsGreaterThan(rhs), lhs.IsGreaterThan(rhs, neitherNaN: true, neitherZero: true));

            lhs = (quarter)2f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsGreaterThan(rhs), lhs.IsGreaterThan(rhs, neitherNaN: true, neitherZero: true));
        }

        [Test]
        public static void _greaterequal()
        {
            quarter lhs;
            quarter rhs;

            lhs = (quarter)0f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsGreaterThanOrEqualTo(rhs), lhs.IsGreaterThanOrEqualTo(rhs, neitherNaN: true));

            lhs = (quarter)0f;
            rhs = (quarter)0f;
            Assert.AreEqual(lhs.IsGreaterThanOrEqualTo(rhs), lhs.IsGreaterThanOrEqualTo(rhs, neitherNaN: true));

            lhs = (quarter)1f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsGreaterThanOrEqualTo(rhs), lhs.IsGreaterThanOrEqualTo(rhs, neitherNaN: true, neitherZero: true));

            lhs = (quarter)2f;
            rhs = (quarter)1f;
            Assert.AreEqual(lhs.IsGreaterThanOrEqualTo(rhs), lhs.IsGreaterThanOrEqualTo(rhs, neitherNaN: true, neitherZero: true));
        }
    }
}
