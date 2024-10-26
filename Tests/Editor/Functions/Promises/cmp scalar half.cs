using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_cmp_scalar_half
    {
        [Test]
        public static void _equal()
        {
            half lhs;
            half rhs;

            lhs = (half)0f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsEqualTo(rhs), lhs.IsEqualTo(rhs, neitherNaN: true));

            lhs = (half)0f;
            rhs = (half)0f;
            Assert.AreEqual(lhs.IsEqualTo(rhs), lhs.IsEqualTo(rhs, neitherNaN: true));

            lhs = (half)1f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsEqualTo(rhs), lhs.IsEqualTo(rhs, neitherNaN: true, neitherZero: true));

            lhs = (half)2f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsEqualTo(rhs), lhs.IsEqualTo(rhs, neitherNaN: true, neitherZero: true));
        }

        [Test]
        public static void _notequal()
        {
            half lhs;
            half rhs;

            lhs = (half)0f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsNotEqualTo(rhs), lhs.IsNotEqualTo(rhs, neitherNaN: true));

            lhs = (half)0f;
            rhs = (half)0f;
            Assert.AreEqual(lhs.IsNotEqualTo(rhs), lhs.IsNotEqualTo(rhs, neitherNaN: true));

            lhs = (half)1f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsNotEqualTo(rhs), lhs.IsNotEqualTo(rhs, neitherNaN: true, neitherZero: true));

            lhs = (half)2f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsNotEqualTo(rhs), lhs.IsNotEqualTo(rhs, neitherNaN: true, neitherZero: true));
        }

        [Test]
        public static void _greater()
        {
            half lhs;
            half rhs;

            lhs = (half)0f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsGreaterThan(rhs), lhs.IsGreaterThan(rhs, neitherNaN: true));

            lhs = (half)0f;
            rhs = (half)0f;
            Assert.AreEqual(lhs.IsGreaterThan(rhs), lhs.IsGreaterThan(rhs, neitherNaN: true));

            lhs = (half)1f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsGreaterThan(rhs), lhs.IsGreaterThan(rhs, neitherNaN: true, neitherZero: true));

            lhs = (half)2f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsGreaterThan(rhs), lhs.IsGreaterThan(rhs, neitherNaN: true, neitherZero: true));
        }

        [Test]
        public static void _greaterequal()
        {
            half lhs;
            half rhs;

            lhs = (half)0f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsGreaterThanOrEqualTo(rhs), lhs.IsGreaterThanOrEqualTo(rhs, neitherNaN: true));

            lhs = (half)0f;
            rhs = (half)0f;
            Assert.AreEqual(lhs.IsGreaterThanOrEqualTo(rhs), lhs.IsGreaterThanOrEqualTo(rhs, neitherNaN: true));

            lhs = (half)1f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsGreaterThanOrEqualTo(rhs), lhs.IsGreaterThanOrEqualTo(rhs, neitherNaN: true, neitherZero: true));

            lhs = (half)2f;
            rhs = (half)1f;
            Assert.AreEqual(lhs.IsGreaterThanOrEqualTo(rhs), lhs.IsGreaterThanOrEqualTo(rhs, neitherNaN: true, neitherZero: true));
        }
    }
}
