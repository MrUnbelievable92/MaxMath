using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_PROMISE_nexttoward
    {
        [Test]
        public static void _quarter()
        {
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)float.PositiveInfinity), math.nexttoward((quarter)1.747f,    (quarter)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)0f),                     math.nexttoward((quarter)1.747f,    (quarter)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)1.748f),                 math.nexttoward((quarter)1.747f,    (quarter)1.748f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)1.746f),                 math.nexttoward((quarter)1.747f,    (quarter)1.746f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)float.NegativeInfinity), math.nexttoward((quarter)1.747f,    (quarter)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)float.PositiveInfinity), math.nexttoward((quarter)(-1.747f), (quarter)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)0f),                     math.nexttoward((quarter)(-1.747f), (quarter)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)(-1.748f)),              math.nexttoward((quarter)(-1.747f), (quarter)(-1.748f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)(-1.746f)),              math.nexttoward((quarter)(-1.747f), (quarter)(-1.746f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)float.NegativeInfinity), math.nexttoward((quarter)(-1.747f), (quarter)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)float.PositiveInfinity), math.nexttoward((quarter)1.747f,    (quarter)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)0f),                     math.nexttoward((quarter)1.747f,    (quarter)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)1.748f),                 math.nexttoward((quarter)1.747f,    (quarter)1.748f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)1.746f),                 math.nexttoward((quarter)1.747f,    (quarter)1.746f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)float.NegativeInfinity), math.nexttoward((quarter)1.747f,    (quarter)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)float.PositiveInfinity), math.nexttoward((quarter)(-1.747f), (quarter)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)0f),                     math.nexttoward((quarter)(-1.747f), (quarter)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)(-1.748f)),              math.nexttoward((quarter)(-1.747f), (quarter)(-1.748f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)(-1.746f)),              math.nexttoward((quarter)(-1.747f), (quarter)(-1.746f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)float.NegativeInfinity), math.nexttoward((quarter)(-1.747f), (quarter)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)float.PositiveInfinity), math.nexttoward((quarter)1.747f,    (quarter)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)0f),                     math.nexttoward((quarter)1.747f,    (quarter)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)1.748f),                 math.nexttoward((quarter)1.747f,    (quarter)1.748f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)1.746f),                 math.nexttoward((quarter)1.747f,    (quarter)1.746f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)float.NegativeInfinity), math.nexttoward((quarter)1.747f,    (quarter)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)float.PositiveInfinity), math.nexttoward((quarter)(-1.747f), (quarter)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)0f),                     math.nexttoward((quarter)(-1.747f), (quarter)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)(-1.748f)),              math.nexttoward((quarter)(-1.747f), (quarter)(-1.748f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)(-1.746f)),              math.nexttoward((quarter)(-1.747f), (quarter)(-1.746f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)float.NegativeInfinity), math.nexttoward((quarter)(-1.747f), (quarter)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)float.PositiveInfinity), math.nexttoward((quarter)1.747f,    (quarter)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)0f),                     math.nexttoward((quarter)1.747f,    (quarter)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)1.748f),                 math.nexttoward((quarter)1.747f,    (quarter)1.748f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)1.746f),                 math.nexttoward((quarter)1.747f,    (quarter)1.746f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)1.747f,    (quarter)float.NegativeInfinity), math.nexttoward((quarter)1.747f,    (quarter)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)float.PositiveInfinity), math.nexttoward((quarter)(-1.747f), (quarter)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)0f),                     math.nexttoward((quarter)(-1.747f), (quarter)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)(-1.748f)),              math.nexttoward((quarter)(-1.747f), (quarter)(-1.748f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)(-1.746f)),              math.nexttoward((quarter)(-1.747f), (quarter)(-1.746f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter)(-1.747f), (quarter)float.NegativeInfinity), math.nexttoward((quarter)(-1.747f), (quarter)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)float.PositiveInfinity), math.nexttoward((quarter2)1.747f,    (quarter2)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)0f),                     math.nexttoward((quarter2)1.747f,    (quarter2)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)1.748f),                 math.nexttoward((quarter2)1.747f,    (quarter2)1.748f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)1.746f),                 math.nexttoward((quarter2)1.747f,    (quarter2)1.746f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)float.NegativeInfinity), math.nexttoward((quarter2)1.747f,    (quarter2)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)float.PositiveInfinity), math.nexttoward((quarter2)(-1.747f), (quarter2)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)0f),                     math.nexttoward((quarter2)(-1.747f), (quarter2)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.748f)),              math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.748f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.746f)),              math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.746f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)float.NegativeInfinity), math.nexttoward((quarter2)(-1.747f), (quarter2)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)float.PositiveInfinity), math.nexttoward((quarter2)1.747f,    (quarter2)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)0f),                     math.nexttoward((quarter2)1.747f,    (quarter2)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)1.748f),                 math.nexttoward((quarter2)1.747f,    (quarter2)1.748f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)1.746f),                 math.nexttoward((quarter2)1.747f,    (quarter2)1.746f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)float.NegativeInfinity), math.nexttoward((quarter2)1.747f,    (quarter2)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)float.PositiveInfinity), math.nexttoward((quarter2)(-1.747f), (quarter2)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)0f),                     math.nexttoward((quarter2)(-1.747f), (quarter2)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.748f)),              math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.748f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.746f)),              math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.746f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)float.NegativeInfinity), math.nexttoward((quarter2)(-1.747f), (quarter2)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)float.PositiveInfinity), math.nexttoward((quarter2)1.747f,    (quarter2)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)0f),                     math.nexttoward((quarter2)1.747f,    (quarter2)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)1.748f),                 math.nexttoward((quarter2)1.747f,    (quarter2)1.748f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)1.746f),                 math.nexttoward((quarter2)1.747f,    (quarter2)1.746f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)float.NegativeInfinity), math.nexttoward((quarter2)1.747f,    (quarter2)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)float.PositiveInfinity), math.nexttoward((quarter2)(-1.747f), (quarter2)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)0f),                     math.nexttoward((quarter2)(-1.747f), (quarter2)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.748f)),              math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.748f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.746f)),              math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.746f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)float.NegativeInfinity), math.nexttoward((quarter2)(-1.747f), (quarter2)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)float.PositiveInfinity), math.nexttoward((quarter2)1.747f,    (quarter2)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)0f),                     math.nexttoward((quarter2)1.747f,    (quarter2)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)1.748f),                 math.nexttoward((quarter2)1.747f,    (quarter2)1.748f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)1.746f),                 math.nexttoward((quarter2)1.747f,    (quarter2)1.746f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)1.747f,    (quarter2)float.NegativeInfinity), math.nexttoward((quarter2)1.747f,    (quarter2)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)float.PositiveInfinity), math.nexttoward((quarter2)(-1.747f), (quarter2)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)0f),                     math.nexttoward((quarter2)(-1.747f), (quarter2)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.748f)),              math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.748f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.746f)),              math.nexttoward((quarter2)(-1.747f), (quarter2)(-1.746f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter2)(-1.747f), (quarter2)float.NegativeInfinity), math.nexttoward((quarter2)(-1.747f), (quarter2)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _quarter3()
        {
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)float.PositiveInfinity), math.nexttoward((quarter3)1.747f,    (quarter3)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)0f),                     math.nexttoward((quarter3)1.747f,    (quarter3)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)1.748f),                 math.nexttoward((quarter3)1.747f,    (quarter3)1.748f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)1.746f),                 math.nexttoward((quarter3)1.747f,    (quarter3)1.746f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)float.NegativeInfinity), math.nexttoward((quarter3)1.747f,    (quarter3)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)float.PositiveInfinity), math.nexttoward((quarter3)(-1.747f), (quarter3)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)0f),                     math.nexttoward((quarter3)(-1.747f), (quarter3)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.748f)),              math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.748f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.746f)),              math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.746f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)float.NegativeInfinity), math.nexttoward((quarter3)(-1.747f), (quarter3)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)float.PositiveInfinity), math.nexttoward((quarter3)1.747f,    (quarter3)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)0f),                     math.nexttoward((quarter3)1.747f,    (quarter3)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)1.748f),                 math.nexttoward((quarter3)1.747f,    (quarter3)1.748f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)1.746f),                 math.nexttoward((quarter3)1.747f,    (quarter3)1.746f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)float.NegativeInfinity), math.nexttoward((quarter3)1.747f,    (quarter3)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)float.PositiveInfinity), math.nexttoward((quarter3)(-1.747f), (quarter3)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)0f),                     math.nexttoward((quarter3)(-1.747f), (quarter3)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.748f)),              math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.748f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.746f)),              math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.746f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)float.NegativeInfinity), math.nexttoward((quarter3)(-1.747f), (quarter3)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)float.PositiveInfinity), math.nexttoward((quarter3)1.747f,    (quarter3)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)0f),                     math.nexttoward((quarter3)1.747f,    (quarter3)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)1.748f),                 math.nexttoward((quarter3)1.747f,    (quarter3)1.748f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)1.746f),                 math.nexttoward((quarter3)1.747f,    (quarter3)1.746f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)float.NegativeInfinity), math.nexttoward((quarter3)1.747f,    (quarter3)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)float.PositiveInfinity), math.nexttoward((quarter3)(-1.747f), (quarter3)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)0f),                     math.nexttoward((quarter3)(-1.747f), (quarter3)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.748f)),              math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.748f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.746f)),              math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.746f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)float.NegativeInfinity), math.nexttoward((quarter3)(-1.747f), (quarter3)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)float.PositiveInfinity), math.nexttoward((quarter3)1.747f,    (quarter3)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)0f),                     math.nexttoward((quarter3)1.747f,    (quarter3)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)1.748f),                 math.nexttoward((quarter3)1.747f,    (quarter3)1.748f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)1.746f),                 math.nexttoward((quarter3)1.747f,    (quarter3)1.746f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)1.747f,    (quarter3)float.NegativeInfinity), math.nexttoward((quarter3)1.747f,    (quarter3)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)float.PositiveInfinity), math.nexttoward((quarter3)(-1.747f), (quarter3)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)0f),                     math.nexttoward((quarter3)(-1.747f), (quarter3)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.748f)),              math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.748f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.746f)),              math.nexttoward((quarter3)(-1.747f), (quarter3)(-1.746f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter3)(-1.747f), (quarter3)float.NegativeInfinity), math.nexttoward((quarter3)(-1.747f), (quarter3)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)float.PositiveInfinity), math.nexttoward((quarter4)1.747f,    (quarter4)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)0f),                     math.nexttoward((quarter4)1.747f,    (quarter4)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)1.748f),                 math.nexttoward((quarter4)1.747f,    (quarter4)1.748f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)1.746f),                 math.nexttoward((quarter4)1.747f,    (quarter4)1.746f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)float.NegativeInfinity), math.nexttoward((quarter4)1.747f,    (quarter4)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)float.PositiveInfinity), math.nexttoward((quarter4)(-1.747f), (quarter4)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)0f),                     math.nexttoward((quarter4)(-1.747f), (quarter4)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.748f)),              math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.748f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.746f)),              math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.746f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)float.NegativeInfinity), math.nexttoward((quarter4)(-1.747f), (quarter4)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)float.PositiveInfinity), math.nexttoward((quarter4)1.747f,    (quarter4)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)0f),                     math.nexttoward((quarter4)1.747f,    (quarter4)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)1.748f),                 math.nexttoward((quarter4)1.747f,    (quarter4)1.748f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)1.746f),                 math.nexttoward((quarter4)1.747f,    (quarter4)1.746f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)float.NegativeInfinity), math.nexttoward((quarter4)1.747f,    (quarter4)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)float.PositiveInfinity), math.nexttoward((quarter4)(-1.747f), (quarter4)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)0f),                     math.nexttoward((quarter4)(-1.747f), (quarter4)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.748f)),              math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.748f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.746f)),              math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.746f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)float.NegativeInfinity), math.nexttoward((quarter4)(-1.747f), (quarter4)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)float.PositiveInfinity), math.nexttoward((quarter4)1.747f,    (quarter4)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)0f),                     math.nexttoward((quarter4)1.747f,    (quarter4)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)1.748f),                 math.nexttoward((quarter4)1.747f,    (quarter4)1.748f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)1.746f),                 math.nexttoward((quarter4)1.747f,    (quarter4)1.746f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)float.NegativeInfinity), math.nexttoward((quarter4)1.747f,    (quarter4)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)float.PositiveInfinity), math.nexttoward((quarter4)(-1.747f), (quarter4)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)0f),                     math.nexttoward((quarter4)(-1.747f), (quarter4)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.748f)),              math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.748f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.746f)),              math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.746f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)float.NegativeInfinity), math.nexttoward((quarter4)(-1.747f), (quarter4)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)float.PositiveInfinity), math.nexttoward((quarter4)1.747f,    (quarter4)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)0f),                     math.nexttoward((quarter4)1.747f,    (quarter4)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)1.748f),                 math.nexttoward((quarter4)1.747f,    (quarter4)1.748f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)1.746f),                 math.nexttoward((quarter4)1.747f,    (quarter4)1.746f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)1.747f,    (quarter4)float.NegativeInfinity), math.nexttoward((quarter4)1.747f,    (quarter4)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)float.PositiveInfinity), math.nexttoward((quarter4)(-1.747f), (quarter4)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)0f),                     math.nexttoward((quarter4)(-1.747f), (quarter4)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.748f)),              math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.748f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.746f)),              math.nexttoward((quarter4)(-1.747f), (quarter4)(-1.746f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter4)(-1.747f), (quarter4)float.NegativeInfinity), math.nexttoward((quarter4)(-1.747f), (quarter4)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)float.PositiveInfinity), math.nexttoward((quarter8)1.747f,    (quarter8)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)0f),                     math.nexttoward((quarter8)1.747f,    (quarter8)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)1.748f),                 math.nexttoward((quarter8)1.747f,    (quarter8)1.748f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)1.746f),                 math.nexttoward((quarter8)1.747f,    (quarter8)1.746f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)float.NegativeInfinity), math.nexttoward((quarter8)1.747f,    (quarter8)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)float.PositiveInfinity), math.nexttoward((quarter8)(-1.747f), (quarter8)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)0f),                     math.nexttoward((quarter8)(-1.747f), (quarter8)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.748f)),              math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.748f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.746f)),              math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.746f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)float.NegativeInfinity), math.nexttoward((quarter8)(-1.747f), (quarter8)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)float.PositiveInfinity), math.nexttoward((quarter8)1.747f,    (quarter8)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)0f),                     math.nexttoward((quarter8)1.747f,    (quarter8)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)1.748f),                 math.nexttoward((quarter8)1.747f,    (quarter8)1.748f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)1.746f),                 math.nexttoward((quarter8)1.747f,    (quarter8)1.746f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)float.NegativeInfinity), math.nexttoward((quarter8)1.747f,    (quarter8)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)float.PositiveInfinity), math.nexttoward((quarter8)(-1.747f), (quarter8)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)0f),                     math.nexttoward((quarter8)(-1.747f), (quarter8)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.748f)),              math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.748f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.746f)),              math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.746f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)float.NegativeInfinity), math.nexttoward((quarter8)(-1.747f), (quarter8)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)float.PositiveInfinity), math.nexttoward((quarter8)1.747f,    (quarter8)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)0f),                     math.nexttoward((quarter8)1.747f,    (quarter8)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)1.748f),                 math.nexttoward((quarter8)1.747f,    (quarter8)1.748f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)1.746f),                 math.nexttoward((quarter8)1.747f,    (quarter8)1.746f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)float.NegativeInfinity), math.nexttoward((quarter8)1.747f,    (quarter8)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)float.PositiveInfinity), math.nexttoward((quarter8)(-1.747f), (quarter8)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)0f),                     math.nexttoward((quarter8)(-1.747f), (quarter8)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.748f)),              math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.748f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.746f)),              math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.746f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)float.NegativeInfinity), math.nexttoward((quarter8)(-1.747f), (quarter8)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)float.PositiveInfinity), math.nexttoward((quarter8)1.747f,    (quarter8)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)0f),                     math.nexttoward((quarter8)1.747f,    (quarter8)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)1.748f),                 math.nexttoward((quarter8)1.747f,    (quarter8)1.748f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)1.746f),                 math.nexttoward((quarter8)1.747f,    (quarter8)1.746f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)1.747f,    (quarter8)float.NegativeInfinity), math.nexttoward((quarter8)1.747f,    (quarter8)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)float.PositiveInfinity), math.nexttoward((quarter8)(-1.747f), (quarter8)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)0f),                     math.nexttoward((quarter8)(-1.747f), (quarter8)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.748f)),              math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.748f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.746f)),              math.nexttoward((quarter8)(-1.747f), (quarter8)(-1.746f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter8)(-1.747f), (quarter8)float.NegativeInfinity), math.nexttoward((quarter8)(-1.747f), (quarter8)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _quarter16()
        {
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)float.PositiveInfinity), math.nexttoward((quarter16)1.747f,    (quarter16)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)0f),                     math.nexttoward((quarter16)1.747f,    (quarter16)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)1.748f),                 math.nexttoward((quarter16)1.747f,    (quarter16)1.748f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)1.746f),                 math.nexttoward((quarter16)1.747f,    (quarter16)1.746f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)float.NegativeInfinity), math.nexttoward((quarter16)1.747f,    (quarter16)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)float.PositiveInfinity), math.nexttoward((quarter16)(-1.747f), (quarter16)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)0f),                     math.nexttoward((quarter16)(-1.747f), (quarter16)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.748f)),              math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.748f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.746f)),              math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.746f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)float.NegativeInfinity), math.nexttoward((quarter16)(-1.747f), (quarter16)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)float.PositiveInfinity), math.nexttoward((quarter16)1.747f,    (quarter16)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)0f),                     math.nexttoward((quarter16)1.747f,    (quarter16)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)1.748f),                 math.nexttoward((quarter16)1.747f,    (quarter16)1.748f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)1.746f),                 math.nexttoward((quarter16)1.747f,    (quarter16)1.746f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)float.NegativeInfinity), math.nexttoward((quarter16)1.747f,    (quarter16)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)float.PositiveInfinity), math.nexttoward((quarter16)(-1.747f), (quarter16)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)0f),                     math.nexttoward((quarter16)(-1.747f), (quarter16)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.748f)),              math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.748f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.746f)),              math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.746f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)float.NegativeInfinity), math.nexttoward((quarter16)(-1.747f), (quarter16)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)float.PositiveInfinity), math.nexttoward((quarter16)1.747f,    (quarter16)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)0f),                     math.nexttoward((quarter16)1.747f,    (quarter16)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)1.748f),                 math.nexttoward((quarter16)1.747f,    (quarter16)1.748f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)1.746f),                 math.nexttoward((quarter16)1.747f,    (quarter16)1.746f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)float.NegativeInfinity), math.nexttoward((quarter16)1.747f,    (quarter16)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)float.PositiveInfinity), math.nexttoward((quarter16)(-1.747f), (quarter16)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)0f),                     math.nexttoward((quarter16)(-1.747f), (quarter16)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.748f)),              math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.748f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.746f)),              math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.746f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)float.NegativeInfinity), math.nexttoward((quarter16)(-1.747f), (quarter16)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)float.PositiveInfinity), math.nexttoward((quarter16)1.747f,    (quarter16)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)0f),                     math.nexttoward((quarter16)1.747f,    (quarter16)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)1.748f),                 math.nexttoward((quarter16)1.747f,    (quarter16)1.748f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)1.746f),                 math.nexttoward((quarter16)1.747f,    (quarter16)1.746f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)1.747f,    (quarter16)float.NegativeInfinity), math.nexttoward((quarter16)1.747f,    (quarter16)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)float.PositiveInfinity), math.nexttoward((quarter16)(-1.747f), (quarter16)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)0f),                     math.nexttoward((quarter16)(-1.747f), (quarter16)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.748f)),              math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.748f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.746f)),              math.nexttoward((quarter16)(-1.747f), (quarter16)(-1.746f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter16)(-1.747f), (quarter16)float.NegativeInfinity), math.nexttoward((quarter16)(-1.747f), (quarter16)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _quarter32()
        {
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)float.PositiveInfinity), math.nexttoward((quarter32)1.747f,    (quarter32)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)0f),                     math.nexttoward((quarter32)1.747f,    (quarter32)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)1.748f),                 math.nexttoward((quarter32)1.747f,    (quarter32)1.748f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)1.746f),                 math.nexttoward((quarter32)1.747f,    (quarter32)1.746f,                 Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)float.NegativeInfinity), math.nexttoward((quarter32)1.747f,    (quarter32)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)float.PositiveInfinity), math.nexttoward((quarter32)(-1.747f), (quarter32)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)0f),                     math.nexttoward((quarter32)(-1.747f), (quarter32)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.748f)),              math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.748f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.746f)),              math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.746f),              Promise.NonZero));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)float.NegativeInfinity), math.nexttoward((quarter32)(-1.747f), (quarter32)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)float.PositiveInfinity), math.nexttoward((quarter32)1.747f,    (quarter32)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)0f),                     math.nexttoward((quarter32)1.747f,    (quarter32)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)1.748f),                 math.nexttoward((quarter32)1.747f,    (quarter32)1.748f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)1.746f),                 math.nexttoward((quarter32)1.747f,    (quarter32)1.746f,                 Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)float.NegativeInfinity), math.nexttoward((quarter32)1.747f,    (quarter32)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)float.PositiveInfinity), math.nexttoward((quarter32)(-1.747f), (quarter32)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)0f),                     math.nexttoward((quarter32)(-1.747f), (quarter32)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.748f)),              math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.748f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.746f)),              math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.746f),              Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)float.NegativeInfinity), math.nexttoward((quarter32)(-1.747f), (quarter32)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)float.PositiveInfinity), math.nexttoward((quarter32)1.747f,    (quarter32)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)0f),                     math.nexttoward((quarter32)1.747f,    (quarter32)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)1.748f),                 math.nexttoward((quarter32)1.747f,    (quarter32)1.748f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)1.746f),                 math.nexttoward((quarter32)1.747f,    (quarter32)1.746f,                 Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)float.NegativeInfinity), math.nexttoward((quarter32)1.747f,    (quarter32)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)float.PositiveInfinity), math.nexttoward((quarter32)(-1.747f), (quarter32)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)0f),                     math.nexttoward((quarter32)(-1.747f), (quarter32)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.748f)),              math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.748f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.746f)),              math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.746f),              Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)float.NegativeInfinity), math.nexttoward((quarter32)(-1.747f), (quarter32)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)float.PositiveInfinity), math.nexttoward((quarter32)1.747f,    (quarter32)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)0f),                     math.nexttoward((quarter32)1.747f,    (quarter32)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)1.748f),                 math.nexttoward((quarter32)1.747f,    (quarter32)1.748f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)1.746f),                 math.nexttoward((quarter32)1.747f,    (quarter32)1.746f,                 Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)1.747f,    (quarter32)float.NegativeInfinity), math.nexttoward((quarter32)1.747f,    (quarter32)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)float.PositiveInfinity), math.nexttoward((quarter32)(-1.747f), (quarter32)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)0f),                     math.nexttoward((quarter32)(-1.747f), (quarter32)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.748f)),              math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.748f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.746f)),              math.nexttoward((quarter32)(-1.747f), (quarter32)(-1.746f),              Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((quarter32)(-1.747f), (quarter32)float.NegativeInfinity), math.nexttoward((quarter32)(-1.747f), (quarter32)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }


        [Test]
        public static void _half()
        {
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)float.PositiveInfinity), math.nexttoward((half)1747f,    (half)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)0f),                     math.nexttoward((half)1747f,    (half)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)1748f),                  math.nexttoward((half)1747f,    (half)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)1746f),                  math.nexttoward((half)1747f,    (half)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)float.NegativeInfinity), math.nexttoward((half)1747f,    (half)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)float.PositiveInfinity), math.nexttoward((half)(-1747f), (half)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)0f),                     math.nexttoward((half)(-1747f), (half)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)(-1748f)),               math.nexttoward((half)(-1747f), (half)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)(-1746f)),               math.nexttoward((half)(-1747f), (half)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)float.NegativeInfinity), math.nexttoward((half)(-1747f), (half)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((half)1747f,    (half)float.PositiveInfinity), math.nexttoward((half)1747f,    (half)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)0f),                     math.nexttoward((half)1747f,    (half)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)1748f),                  math.nexttoward((half)1747f,    (half)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)1746f),                  math.nexttoward((half)1747f,    (half)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)float.NegativeInfinity), math.nexttoward((half)1747f,    (half)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)float.PositiveInfinity), math.nexttoward((half)(-1747f), (half)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)0f),                     math.nexttoward((half)(-1747f), (half)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)(-1748f)),               math.nexttoward((half)(-1747f), (half)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)(-1746f)),               math.nexttoward((half)(-1747f), (half)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)float.NegativeInfinity), math.nexttoward((half)(-1747f), (half)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((half)1747f,    (half)float.PositiveInfinity), math.nexttoward((half)1747f,    (half)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)0f),                     math.nexttoward((half)1747f,    (half)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)1748f),                  math.nexttoward((half)1747f,    (half)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)1746f),                  math.nexttoward((half)1747f,    (half)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)float.NegativeInfinity), math.nexttoward((half)1747f,    (half)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)float.PositiveInfinity), math.nexttoward((half)(-1747f), (half)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)0f),                     math.nexttoward((half)(-1747f), (half)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)(-1748f)),               math.nexttoward((half)(-1747f), (half)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)(-1746f)),               math.nexttoward((half)(-1747f), (half)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)float.NegativeInfinity), math.nexttoward((half)(-1747f), (half)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((half)1747f,    (half)float.PositiveInfinity), math.nexttoward((half)1747f,    (half)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)0f),                     math.nexttoward((half)1747f,    (half)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)1748f),                  math.nexttoward((half)1747f,    (half)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)1746f),                  math.nexttoward((half)1747f,    (half)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)1747f,    (half)float.NegativeInfinity), math.nexttoward((half)1747f,    (half)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)float.PositiveInfinity), math.nexttoward((half)(-1747f), (half)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)0f),                     math.nexttoward((half)(-1747f), (half)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)(-1748f)),               math.nexttoward((half)(-1747f), (half)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)(-1746f)),               math.nexttoward((half)(-1747f), (half)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half)(-1747f), (half)float.NegativeInfinity), math.nexttoward((half)(-1747f), (half)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _half2()
        {
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)float.PositiveInfinity), math.nexttoward((half2)1747f,    (half2)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)0f),                     math.nexttoward((half2)1747f,    (half2)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)1748f),                  math.nexttoward((half2)1747f,    (half2)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)1746f),                  math.nexttoward((half2)1747f,    (half2)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)float.NegativeInfinity), math.nexttoward((half2)1747f,    (half2)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)float.PositiveInfinity), math.nexttoward((half2)(-1747f), (half2)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)0f),                     math.nexttoward((half2)(-1747f), (half2)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)(-1748f)),               math.nexttoward((half2)(-1747f), (half2)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)(-1746f)),               math.nexttoward((half2)(-1747f), (half2)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)float.NegativeInfinity), math.nexttoward((half2)(-1747f), (half2)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)float.PositiveInfinity), math.nexttoward((half2)1747f,    (half2)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)0f),                     math.nexttoward((half2)1747f,    (half2)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)1748f),                  math.nexttoward((half2)1747f,    (half2)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)1746f),                  math.nexttoward((half2)1747f,    (half2)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)float.NegativeInfinity), math.nexttoward((half2)1747f,    (half2)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)float.PositiveInfinity), math.nexttoward((half2)(-1747f), (half2)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)0f),                     math.nexttoward((half2)(-1747f), (half2)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)(-1748f)),               math.nexttoward((half2)(-1747f), (half2)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)(-1746f)),               math.nexttoward((half2)(-1747f), (half2)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)float.NegativeInfinity), math.nexttoward((half2)(-1747f), (half2)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)float.PositiveInfinity), math.nexttoward((half2)1747f,    (half2)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)0f),                     math.nexttoward((half2)1747f,    (half2)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)1748f),                  math.nexttoward((half2)1747f,    (half2)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)1746f),                  math.nexttoward((half2)1747f,    (half2)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)float.NegativeInfinity), math.nexttoward((half2)1747f,    (half2)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)float.PositiveInfinity), math.nexttoward((half2)(-1747f), (half2)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)0f),                     math.nexttoward((half2)(-1747f), (half2)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)(-1748f)),               math.nexttoward((half2)(-1747f), (half2)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)(-1746f)),               math.nexttoward((half2)(-1747f), (half2)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)float.NegativeInfinity), math.nexttoward((half2)(-1747f), (half2)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)float.PositiveInfinity), math.nexttoward((half2)1747f,    (half2)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)0f),                     math.nexttoward((half2)1747f,    (half2)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)1748f),                  math.nexttoward((half2)1747f,    (half2)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)1746f),                  math.nexttoward((half2)1747f,    (half2)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)1747f,    (half2)float.NegativeInfinity), math.nexttoward((half2)1747f,    (half2)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)float.PositiveInfinity), math.nexttoward((half2)(-1747f), (half2)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)0f),                     math.nexttoward((half2)(-1747f), (half2)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)(-1748f)),               math.nexttoward((half2)(-1747f), (half2)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)(-1746f)),               math.nexttoward((half2)(-1747f), (half2)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half2)(-1747f), (half2)float.NegativeInfinity), math.nexttoward((half2)(-1747f), (half2)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _half3()
        {
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)float.PositiveInfinity), math.nexttoward((half3)1747f,    (half3)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)0f),                     math.nexttoward((half3)1747f,    (half3)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)1748f),                  math.nexttoward((half3)1747f,    (half3)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)1746f),                  math.nexttoward((half3)1747f,    (half3)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)float.NegativeInfinity), math.nexttoward((half3)1747f,    (half3)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)float.PositiveInfinity), math.nexttoward((half3)(-1747f), (half3)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)0f),                     math.nexttoward((half3)(-1747f), (half3)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)(-1748f)),               math.nexttoward((half3)(-1747f), (half3)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)(-1746f)),               math.nexttoward((half3)(-1747f), (half3)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)float.NegativeInfinity), math.nexttoward((half3)(-1747f), (half3)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)float.PositiveInfinity), math.nexttoward((half3)1747f,    (half3)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)0f),                     math.nexttoward((half3)1747f,    (half3)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)1748f),                  math.nexttoward((half3)1747f,    (half3)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)1746f),                  math.nexttoward((half3)1747f,    (half3)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)float.NegativeInfinity), math.nexttoward((half3)1747f,    (half3)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)float.PositiveInfinity), math.nexttoward((half3)(-1747f), (half3)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)0f),                     math.nexttoward((half3)(-1747f), (half3)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)(-1748f)),               math.nexttoward((half3)(-1747f), (half3)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)(-1746f)),               math.nexttoward((half3)(-1747f), (half3)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)float.NegativeInfinity), math.nexttoward((half3)(-1747f), (half3)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)float.PositiveInfinity), math.nexttoward((half3)1747f,    (half3)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)0f),                     math.nexttoward((half3)1747f,    (half3)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)1748f),                  math.nexttoward((half3)1747f,    (half3)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)1746f),                  math.nexttoward((half3)1747f,    (half3)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)float.NegativeInfinity), math.nexttoward((half3)1747f,    (half3)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)float.PositiveInfinity), math.nexttoward((half3)(-1747f), (half3)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)0f),                     math.nexttoward((half3)(-1747f), (half3)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)(-1748f)),               math.nexttoward((half3)(-1747f), (half3)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)(-1746f)),               math.nexttoward((half3)(-1747f), (half3)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)float.NegativeInfinity), math.nexttoward((half3)(-1747f), (half3)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)float.PositiveInfinity), math.nexttoward((half3)1747f,    (half3)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)0f),                     math.nexttoward((half3)1747f,    (half3)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)1748f),                  math.nexttoward((half3)1747f,    (half3)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)1746f),                  math.nexttoward((half3)1747f,    (half3)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)1747f,    (half3)float.NegativeInfinity), math.nexttoward((half3)1747f,    (half3)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)float.PositiveInfinity), math.nexttoward((half3)(-1747f), (half3)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)0f),                     math.nexttoward((half3)(-1747f), (half3)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)(-1748f)),               math.nexttoward((half3)(-1747f), (half3)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)(-1746f)),               math.nexttoward((half3)(-1747f), (half3)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half3)(-1747f), (half3)float.NegativeInfinity), math.nexttoward((half3)(-1747f), (half3)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _half4()
        {
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)float.PositiveInfinity), math.nexttoward((half4)1747f,    (half4)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)0f),                     math.nexttoward((half4)1747f,    (half4)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)1748f),                  math.nexttoward((half4)1747f,    (half4)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)1746f),                  math.nexttoward((half4)1747f,    (half4)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)float.NegativeInfinity), math.nexttoward((half4)1747f,    (half4)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)float.PositiveInfinity), math.nexttoward((half4)(-1747f), (half4)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)0f),                     math.nexttoward((half4)(-1747f), (half4)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)(-1748f)),               math.nexttoward((half4)(-1747f), (half4)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)(-1746f)),               math.nexttoward((half4)(-1747f), (half4)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)float.NegativeInfinity), math.nexttoward((half4)(-1747f), (half4)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)float.PositiveInfinity), math.nexttoward((half4)1747f,    (half4)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)0f),                     math.nexttoward((half4)1747f,    (half4)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)1748f),                  math.nexttoward((half4)1747f,    (half4)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)1746f),                  math.nexttoward((half4)1747f,    (half4)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)float.NegativeInfinity), math.nexttoward((half4)1747f,    (half4)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)float.PositiveInfinity), math.nexttoward((half4)(-1747f), (half4)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)0f),                     math.nexttoward((half4)(-1747f), (half4)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)(-1748f)),               math.nexttoward((half4)(-1747f), (half4)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)(-1746f)),               math.nexttoward((half4)(-1747f), (half4)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)float.NegativeInfinity), math.nexttoward((half4)(-1747f), (half4)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)float.PositiveInfinity), math.nexttoward((half4)1747f,    (half4)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)0f),                     math.nexttoward((half4)1747f,    (half4)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)1748f),                  math.nexttoward((half4)1747f,    (half4)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)1746f),                  math.nexttoward((half4)1747f,    (half4)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)float.NegativeInfinity), math.nexttoward((half4)1747f,    (half4)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)float.PositiveInfinity), math.nexttoward((half4)(-1747f), (half4)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)0f),                     math.nexttoward((half4)(-1747f), (half4)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)(-1748f)),               math.nexttoward((half4)(-1747f), (half4)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)(-1746f)),               math.nexttoward((half4)(-1747f), (half4)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)float.NegativeInfinity), math.nexttoward((half4)(-1747f), (half4)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)float.PositiveInfinity), math.nexttoward((half4)1747f,    (half4)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)0f),                     math.nexttoward((half4)1747f,    (half4)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)1748f),                  math.nexttoward((half4)1747f,    (half4)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)1746f),                  math.nexttoward((half4)1747f,    (half4)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)1747f,    (half4)float.NegativeInfinity), math.nexttoward((half4)1747f,    (half4)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)float.PositiveInfinity), math.nexttoward((half4)(-1747f), (half4)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)0f),                     math.nexttoward((half4)(-1747f), (half4)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)(-1748f)),               math.nexttoward((half4)(-1747f), (half4)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)(-1746f)),               math.nexttoward((half4)(-1747f), (half4)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half4)(-1747f), (half4)float.NegativeInfinity), math.nexttoward((half4)(-1747f), (half4)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _half8()
        {
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)float.PositiveInfinity), math.nexttoward((half8)1747f,    (half8)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)0f),                     math.nexttoward((half8)1747f,    (half8)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)1748f),                  math.nexttoward((half8)1747f,    (half8)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)1746f),                  math.nexttoward((half8)1747f,    (half8)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)float.NegativeInfinity), math.nexttoward((half8)1747f,    (half8)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)float.PositiveInfinity), math.nexttoward((half8)(-1747f), (half8)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)0f),                     math.nexttoward((half8)(-1747f), (half8)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)(-1748f)),               math.nexttoward((half8)(-1747f), (half8)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)(-1746f)),               math.nexttoward((half8)(-1747f), (half8)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)float.NegativeInfinity), math.nexttoward((half8)(-1747f), (half8)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)float.PositiveInfinity), math.nexttoward((half8)1747f,    (half8)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)0f),                     math.nexttoward((half8)1747f,    (half8)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)1748f),                  math.nexttoward((half8)1747f,    (half8)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)1746f),                  math.nexttoward((half8)1747f,    (half8)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)float.NegativeInfinity), math.nexttoward((half8)1747f,    (half8)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)float.PositiveInfinity), math.nexttoward((half8)(-1747f), (half8)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)0f),                     math.nexttoward((half8)(-1747f), (half8)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)(-1748f)),               math.nexttoward((half8)(-1747f), (half8)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)(-1746f)),               math.nexttoward((half8)(-1747f), (half8)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)float.NegativeInfinity), math.nexttoward((half8)(-1747f), (half8)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)float.PositiveInfinity), math.nexttoward((half8)1747f,    (half8)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)0f),                     math.nexttoward((half8)1747f,    (half8)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)1748f),                  math.nexttoward((half8)1747f,    (half8)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)1746f),                  math.nexttoward((half8)1747f,    (half8)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)float.NegativeInfinity), math.nexttoward((half8)1747f,    (half8)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)float.PositiveInfinity), math.nexttoward((half8)(-1747f), (half8)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)0f),                     math.nexttoward((half8)(-1747f), (half8)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)(-1748f)),               math.nexttoward((half8)(-1747f), (half8)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)(-1746f)),               math.nexttoward((half8)(-1747f), (half8)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)float.NegativeInfinity), math.nexttoward((half8)(-1747f), (half8)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)float.PositiveInfinity), math.nexttoward((half8)1747f,    (half8)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)0f),                     math.nexttoward((half8)1747f,    (half8)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)1748f),                  math.nexttoward((half8)1747f,    (half8)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)1746f),                  math.nexttoward((half8)1747f,    (half8)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)1747f,    (half8)float.NegativeInfinity), math.nexttoward((half8)1747f,    (half8)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)float.PositiveInfinity), math.nexttoward((half8)(-1747f), (half8)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)0f),                     math.nexttoward((half8)(-1747f), (half8)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)(-1748f)),               math.nexttoward((half8)(-1747f), (half8)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)(-1746f)),               math.nexttoward((half8)(-1747f), (half8)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half8)(-1747f), (half8)float.NegativeInfinity), math.nexttoward((half8)(-1747f), (half8)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _half16()
        {
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)float.PositiveInfinity), math.nexttoward((half16)1747f,    (half16)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)0f),                     math.nexttoward((half16)1747f,    (half16)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)1748f),                  math.nexttoward((half16)1747f,    (half16)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)1746f),                  math.nexttoward((half16)1747f,    (half16)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)float.NegativeInfinity), math.nexttoward((half16)1747f,    (half16)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)float.PositiveInfinity), math.nexttoward((half16)(-1747f), (half16)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)0f),                     math.nexttoward((half16)(-1747f), (half16)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)(-1748f)),               math.nexttoward((half16)(-1747f), (half16)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)(-1746f)),               math.nexttoward((half16)(-1747f), (half16)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)float.NegativeInfinity), math.nexttoward((half16)(-1747f), (half16)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)float.PositiveInfinity), math.nexttoward((half16)1747f,    (half16)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)0f),                     math.nexttoward((half16)1747f,    (half16)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)1748f),                  math.nexttoward((half16)1747f,    (half16)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)1746f),                  math.nexttoward((half16)1747f,    (half16)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)float.NegativeInfinity), math.nexttoward((half16)1747f,    (half16)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)float.PositiveInfinity), math.nexttoward((half16)(-1747f), (half16)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)0f),                     math.nexttoward((half16)(-1747f), (half16)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)(-1748f)),               math.nexttoward((half16)(-1747f), (half16)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)(-1746f)),               math.nexttoward((half16)(-1747f), (half16)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)float.NegativeInfinity), math.nexttoward((half16)(-1747f), (half16)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)float.PositiveInfinity), math.nexttoward((half16)1747f,    (half16)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)0f),                     math.nexttoward((half16)1747f,    (half16)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)1748f),                  math.nexttoward((half16)1747f,    (half16)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)1746f),                  math.nexttoward((half16)1747f,    (half16)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)float.NegativeInfinity), math.nexttoward((half16)1747f,    (half16)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)float.PositiveInfinity), math.nexttoward((half16)(-1747f), (half16)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)0f),                     math.nexttoward((half16)(-1747f), (half16)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)(-1748f)),               math.nexttoward((half16)(-1747f), (half16)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)(-1746f)),               math.nexttoward((half16)(-1747f), (half16)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)float.NegativeInfinity), math.nexttoward((half16)(-1747f), (half16)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)float.PositiveInfinity), math.nexttoward((half16)1747f,    (half16)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)0f),                     math.nexttoward((half16)1747f,    (half16)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)1748f),                  math.nexttoward((half16)1747f,    (half16)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)1746f),                  math.nexttoward((half16)1747f,    (half16)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)1747f,    (half16)float.NegativeInfinity), math.nexttoward((half16)1747f,    (half16)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)float.PositiveInfinity), math.nexttoward((half16)(-1747f), (half16)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)0f),                     math.nexttoward((half16)(-1747f), (half16)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)(-1748f)),               math.nexttoward((half16)(-1747f), (half16)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)(-1746f)),               math.nexttoward((half16)(-1747f), (half16)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((half16)(-1747f), (half16)float.NegativeInfinity), math.nexttoward((half16)(-1747f), (half16)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }


        [Test]
        public static void _float()
        {
            Assert.AreEqual(math.nexttoward(1747f,    float.PositiveInfinity), math.nexttoward(1747f,    float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward(1747f,    0f),                     math.nexttoward(1747f,    0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward(1747f,    1748f),                  math.nexttoward(1747f,    1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward(1747f,    1746f),                  math.nexttoward(1747f,    1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward(1747f,    float.NegativeInfinity), math.nexttoward(1747f,    float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), float.PositiveInfinity), math.nexttoward((-1747f), float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), 0f),                     math.nexttoward((-1747f), 0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), (-1748f)),               math.nexttoward((-1747f), (-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), (-1746f)),               math.nexttoward((-1747f), (-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), float.NegativeInfinity), math.nexttoward((-1747f), float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward(1747f,    float.PositiveInfinity), math.nexttoward(1747f,    float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    0f),                     math.nexttoward(1747f,    0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    1748f),                  math.nexttoward(1747f,    1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    1746f),                  math.nexttoward(1747f,    1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    float.NegativeInfinity), math.nexttoward(1747f,    float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((-1747f), float.PositiveInfinity), math.nexttoward((-1747f), float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), 0f),                     math.nexttoward((-1747f), 0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), (-1748f)),               math.nexttoward((-1747f), (-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), (-1746f)),               math.nexttoward((-1747f), (-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), float.NegativeInfinity), math.nexttoward((-1747f), float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward(1747f,    float.PositiveInfinity), math.nexttoward(1747f,    float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward(1747f,    0f),                     math.nexttoward(1747f,    0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward(1747f,    1748f),                  math.nexttoward(1747f,    1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward(1747f,    1746f),                  math.nexttoward(1747f,    1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward(1747f,    float.NegativeInfinity), math.nexttoward(1747f,    float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), float.PositiveInfinity), math.nexttoward((-1747f), float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), 0f),                     math.nexttoward((-1747f), 0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), (-1748f)),               math.nexttoward((-1747f), (-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), (-1746f)),               math.nexttoward((-1747f), (-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), float.NegativeInfinity), math.nexttoward((-1747f), float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward(1747f,    float.PositiveInfinity), math.nexttoward(1747f,    float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    0f),                     math.nexttoward(1747f,    0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    1748f),                  math.nexttoward(1747f,    1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    1746f),                  math.nexttoward(1747f,    1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    float.NegativeInfinity), math.nexttoward(1747f,    float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((-1747f), float.PositiveInfinity), math.nexttoward((-1747f), float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), 0f),                     math.nexttoward((-1747f), 0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), (-1748f)),               math.nexttoward((-1747f), (-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), (-1746f)),               math.nexttoward((-1747f), (-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), float.NegativeInfinity), math.nexttoward((-1747f), float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _float2()
        {
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)float.PositiveInfinity), math.nexttoward((float2)1747f,    (float2)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)0f),                     math.nexttoward((float2)1747f,    (float2)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)1748f),                  math.nexttoward((float2)1747f,    (float2)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)1746f),                  math.nexttoward((float2)1747f,    (float2)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)float.NegativeInfinity), math.nexttoward((float2)1747f,    (float2)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)float.PositiveInfinity), math.nexttoward((float2)(-1747f), (float2)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)0f),                     math.nexttoward((float2)(-1747f), (float2)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)(-1748f)),               math.nexttoward((float2)(-1747f), (float2)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)(-1746f)),               math.nexttoward((float2)(-1747f), (float2)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)float.NegativeInfinity), math.nexttoward((float2)(-1747f), (float2)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)float.PositiveInfinity), math.nexttoward((float2)1747f,    (float2)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)0f),                     math.nexttoward((float2)1747f,    (float2)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)1748f),                  math.nexttoward((float2)1747f,    (float2)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)1746f),                  math.nexttoward((float2)1747f,    (float2)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)float.NegativeInfinity), math.nexttoward((float2)1747f,    (float2)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)float.PositiveInfinity), math.nexttoward((float2)(-1747f), (float2)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)0f),                     math.nexttoward((float2)(-1747f), (float2)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)(-1748f)),               math.nexttoward((float2)(-1747f), (float2)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)(-1746f)),               math.nexttoward((float2)(-1747f), (float2)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)float.NegativeInfinity), math.nexttoward((float2)(-1747f), (float2)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)float.PositiveInfinity), math.nexttoward((float2)1747f,    (float2)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)0f),                     math.nexttoward((float2)1747f,    (float2)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)1748f),                  math.nexttoward((float2)1747f,    (float2)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)1746f),                  math.nexttoward((float2)1747f,    (float2)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)float.NegativeInfinity), math.nexttoward((float2)1747f,    (float2)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)float.PositiveInfinity), math.nexttoward((float2)(-1747f), (float2)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)0f),                     math.nexttoward((float2)(-1747f), (float2)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)(-1748f)),               math.nexttoward((float2)(-1747f), (float2)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)(-1746f)),               math.nexttoward((float2)(-1747f), (float2)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)float.NegativeInfinity), math.nexttoward((float2)(-1747f), (float2)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)float.PositiveInfinity), math.nexttoward((float2)1747f,    (float2)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)0f),                     math.nexttoward((float2)1747f,    (float2)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)1748f),                  math.nexttoward((float2)1747f,    (float2)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)1746f),                  math.nexttoward((float2)1747f,    (float2)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)1747f,    (float2)float.NegativeInfinity), math.nexttoward((float2)1747f,    (float2)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)float.PositiveInfinity), math.nexttoward((float2)(-1747f), (float2)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)0f),                     math.nexttoward((float2)(-1747f), (float2)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)(-1748f)),               math.nexttoward((float2)(-1747f), (float2)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)(-1746f)),               math.nexttoward((float2)(-1747f), (float2)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float2)(-1747f), (float2)float.NegativeInfinity), math.nexttoward((float2)(-1747f), (float2)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _float3()
        {
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)float.PositiveInfinity), math.nexttoward((float3)1747f,    (float3)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)0f),                     math.nexttoward((float3)1747f,    (float3)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)1748f),                  math.nexttoward((float3)1747f,    (float3)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)1746f),                  math.nexttoward((float3)1747f,    (float3)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)float.NegativeInfinity), math.nexttoward((float3)1747f,    (float3)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)float.PositiveInfinity), math.nexttoward((float3)(-1747f), (float3)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)0f),                     math.nexttoward((float3)(-1747f), (float3)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)(-1748f)),               math.nexttoward((float3)(-1747f), (float3)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)(-1746f)),               math.nexttoward((float3)(-1747f), (float3)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)float.NegativeInfinity), math.nexttoward((float3)(-1747f), (float3)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)float.PositiveInfinity), math.nexttoward((float3)1747f,    (float3)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)0f),                     math.nexttoward((float3)1747f,    (float3)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)1748f),                  math.nexttoward((float3)1747f,    (float3)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)1746f),                  math.nexttoward((float3)1747f,    (float3)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)float.NegativeInfinity), math.nexttoward((float3)1747f,    (float3)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)float.PositiveInfinity), math.nexttoward((float3)(-1747f), (float3)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)0f),                     math.nexttoward((float3)(-1747f), (float3)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)(-1748f)),               math.nexttoward((float3)(-1747f), (float3)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)(-1746f)),               math.nexttoward((float3)(-1747f), (float3)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)float.NegativeInfinity), math.nexttoward((float3)(-1747f), (float3)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)float.PositiveInfinity), math.nexttoward((float3)1747f,    (float3)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)0f),                     math.nexttoward((float3)1747f,    (float3)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)1748f),                  math.nexttoward((float3)1747f,    (float3)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)1746f),                  math.nexttoward((float3)1747f,    (float3)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)float.NegativeInfinity), math.nexttoward((float3)1747f,    (float3)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)float.PositiveInfinity), math.nexttoward((float3)(-1747f), (float3)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)0f),                     math.nexttoward((float3)(-1747f), (float3)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)(-1748f)),               math.nexttoward((float3)(-1747f), (float3)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)(-1746f)),               math.nexttoward((float3)(-1747f), (float3)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)float.NegativeInfinity), math.nexttoward((float3)(-1747f), (float3)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)float.PositiveInfinity), math.nexttoward((float3)1747f,    (float3)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)0f),                     math.nexttoward((float3)1747f,    (float3)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)1748f),                  math.nexttoward((float3)1747f,    (float3)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)1746f),                  math.nexttoward((float3)1747f,    (float3)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)1747f,    (float3)float.NegativeInfinity), math.nexttoward((float3)1747f,    (float3)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)float.PositiveInfinity), math.nexttoward((float3)(-1747f), (float3)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)0f),                     math.nexttoward((float3)(-1747f), (float3)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)(-1748f)),               math.nexttoward((float3)(-1747f), (float3)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)(-1746f)),               math.nexttoward((float3)(-1747f), (float3)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float3)(-1747f), (float3)float.NegativeInfinity), math.nexttoward((float3)(-1747f), (float3)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _float4()
        {
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)float.PositiveInfinity), math.nexttoward((float4)1747f,    (float4)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)0f),                     math.nexttoward((float4)1747f,    (float4)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)1748f),                  math.nexttoward((float4)1747f,    (float4)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)1746f),                  math.nexttoward((float4)1747f,    (float4)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)float.NegativeInfinity), math.nexttoward((float4)1747f,    (float4)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)float.PositiveInfinity), math.nexttoward((float4)(-1747f), (float4)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)0f),                     math.nexttoward((float4)(-1747f), (float4)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)(-1748f)),               math.nexttoward((float4)(-1747f), (float4)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)(-1746f)),               math.nexttoward((float4)(-1747f), (float4)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)float.NegativeInfinity), math.nexttoward((float4)(-1747f), (float4)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)float.PositiveInfinity), math.nexttoward((float4)1747f,    (float4)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)0f),                     math.nexttoward((float4)1747f,    (float4)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)1748f),                  math.nexttoward((float4)1747f,    (float4)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)1746f),                  math.nexttoward((float4)1747f,    (float4)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)float.NegativeInfinity), math.nexttoward((float4)1747f,    (float4)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)float.PositiveInfinity), math.nexttoward((float4)(-1747f), (float4)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)0f),                     math.nexttoward((float4)(-1747f), (float4)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)(-1748f)),               math.nexttoward((float4)(-1747f), (float4)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)(-1746f)),               math.nexttoward((float4)(-1747f), (float4)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)float.NegativeInfinity), math.nexttoward((float4)(-1747f), (float4)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)float.PositiveInfinity), math.nexttoward((float4)1747f,    (float4)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)0f),                     math.nexttoward((float4)1747f,    (float4)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)1748f),                  math.nexttoward((float4)1747f,    (float4)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)1746f),                  math.nexttoward((float4)1747f,    (float4)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)float.NegativeInfinity), math.nexttoward((float4)1747f,    (float4)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)float.PositiveInfinity), math.nexttoward((float4)(-1747f), (float4)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)0f),                     math.nexttoward((float4)(-1747f), (float4)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)(-1748f)),               math.nexttoward((float4)(-1747f), (float4)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)(-1746f)),               math.nexttoward((float4)(-1747f), (float4)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)float.NegativeInfinity), math.nexttoward((float4)(-1747f), (float4)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)float.PositiveInfinity), math.nexttoward((float4)1747f,    (float4)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)0f),                     math.nexttoward((float4)1747f,    (float4)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)1748f),                  math.nexttoward((float4)1747f,    (float4)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)1746f),                  math.nexttoward((float4)1747f,    (float4)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)1747f,    (float4)float.NegativeInfinity), math.nexttoward((float4)1747f,    (float4)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)float.PositiveInfinity), math.nexttoward((float4)(-1747f), (float4)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)0f),                     math.nexttoward((float4)(-1747f), (float4)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)(-1748f)),               math.nexttoward((float4)(-1747f), (float4)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)(-1746f)),               math.nexttoward((float4)(-1747f), (float4)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float4)(-1747f), (float4)float.NegativeInfinity), math.nexttoward((float4)(-1747f), (float4)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _float8()
        {
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)float.PositiveInfinity), math.nexttoward((float8)1747f,    (float8)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)0f),                     math.nexttoward((float8)1747f,    (float8)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)1748f),                  math.nexttoward((float8)1747f,    (float8)1748f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)1746f),                  math.nexttoward((float8)1747f,    (float8)1746f,                  Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)float.NegativeInfinity), math.nexttoward((float8)1747f,    (float8)float.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)float.PositiveInfinity), math.nexttoward((float8)(-1747f), (float8)float.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)0f),                     math.nexttoward((float8)(-1747f), (float8)0f,                     Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)(-1748f)),               math.nexttoward((float8)(-1747f), (float8)(-1748f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)(-1746f)),               math.nexttoward((float8)(-1747f), (float8)(-1746f),               Promise.NonZero));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)float.NegativeInfinity), math.nexttoward((float8)(-1747f), (float8)float.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)float.PositiveInfinity), math.nexttoward((float8)1747f,    (float8)float.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)0f),                     math.nexttoward((float8)1747f,    (float8)0f,                     Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)1748f),                  math.nexttoward((float8)1747f,    (float8)1748f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)1746f),                  math.nexttoward((float8)1747f,    (float8)1746f,                  Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)float.NegativeInfinity), math.nexttoward((float8)1747f,    (float8)float.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)float.PositiveInfinity), math.nexttoward((float8)(-1747f), (float8)float.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)0f),                     math.nexttoward((float8)(-1747f), (float8)0f,                     Promise.Negative));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)(-1748f)),               math.nexttoward((float8)(-1747f), (float8)(-1748f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)(-1746f)),               math.nexttoward((float8)(-1747f), (float8)(-1746f),               Promise.Negative));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)float.NegativeInfinity), math.nexttoward((float8)(-1747f), (float8)float.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)float.PositiveInfinity), math.nexttoward((float8)1747f,    (float8)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)0f),                     math.nexttoward((float8)1747f,    (float8)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)1748f),                  math.nexttoward((float8)1747f,    (float8)1748f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)1746f),                  math.nexttoward((float8)1747f,    (float8)1746f,                  Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)float.NegativeInfinity), math.nexttoward((float8)1747f,    (float8)float.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)float.PositiveInfinity), math.nexttoward((float8)(-1747f), (float8)float.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)0f),                     math.nexttoward((float8)(-1747f), (float8)0f,                     Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)(-1748f)),               math.nexttoward((float8)(-1747f), (float8)(-1748f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)(-1746f)),               math.nexttoward((float8)(-1747f), (float8)(-1746f),               Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)float.NegativeInfinity), math.nexttoward((float8)(-1747f), (float8)float.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)float.PositiveInfinity), math.nexttoward((float8)1747f,    (float8)float.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)0f),                     math.nexttoward((float8)1747f,    (float8)0f,                     Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)1748f),                  math.nexttoward((float8)1747f,    (float8)1748f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)1746f),                  math.nexttoward((float8)1747f,    (float8)1746f,                  Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)1747f,    (float8)float.NegativeInfinity), math.nexttoward((float8)1747f,    (float8)float.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)float.PositiveInfinity), math.nexttoward((float8)(-1747f), (float8)float.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)0f),                     math.nexttoward((float8)(-1747f), (float8)0f,                     Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)(-1748f)),               math.nexttoward((float8)(-1747f), (float8)(-1748f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)(-1746f)),               math.nexttoward((float8)(-1747f), (float8)(-1746f),               Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((float8)(-1747f), (float8)float.NegativeInfinity), math.nexttoward((float8)(-1747f), (float8)float.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }


        [Test]
        public static void _double()
        {
            Assert.AreEqual(math.nexttoward(1747f,    double.PositiveInfinity), math.nexttoward(1747f,    double.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward(1747f,    0f),                      math.nexttoward(1747f,    0f,                      Promise.NonZero));
            Assert.AreEqual(math.nexttoward(1747f,    1748f),                   math.nexttoward(1747f,    1748f,                   Promise.NonZero));
            Assert.AreEqual(math.nexttoward(1747f,    1746f),                   math.nexttoward(1747f,    1746f,                   Promise.NonZero));
            Assert.AreEqual(math.nexttoward(1747f,    double.NegativeInfinity), math.nexttoward(1747f,    double.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), double.PositiveInfinity), math.nexttoward((-1747f), double.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), 0f),                      math.nexttoward((-1747f), 0f,                      Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), (-1748f)),                math.nexttoward((-1747f), (-1748f),                Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), (-1746f)),                math.nexttoward((-1747f), (-1746f),                Promise.NonZero));
            Assert.AreEqual(math.nexttoward((-1747f), double.NegativeInfinity), math.nexttoward((-1747f), double.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward(1747f,    double.PositiveInfinity), math.nexttoward(1747f,    double.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    0f),                      math.nexttoward(1747f,    0f,                      Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    1748f),                   math.nexttoward(1747f,    1748f,                   Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    1746f),                   math.nexttoward(1747f,    1746f,                   Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    double.NegativeInfinity), math.nexttoward(1747f,    double.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((-1747f), double.PositiveInfinity), math.nexttoward((-1747f), double.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), 0f),                      math.nexttoward((-1747f), 0f,                      Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), (-1748f)),                math.nexttoward((-1747f), (-1748f),                Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), (-1746f)),                math.nexttoward((-1747f), (-1746f),                Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), double.NegativeInfinity), math.nexttoward((-1747f), double.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward(1747f,    double.PositiveInfinity), math.nexttoward(1747f,    double.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward(1747f,    0f),                      math.nexttoward(1747f,    0f,                      Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward(1747f,    1748f),                   math.nexttoward(1747f,    1748f,                   Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward(1747f,    1746f),                   math.nexttoward(1747f,    1746f,                   Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward(1747f,    double.NegativeInfinity), math.nexttoward(1747f,    double.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), double.PositiveInfinity), math.nexttoward((-1747f), double.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), 0f),                      math.nexttoward((-1747f), 0f,                      Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), (-1748f)),                math.nexttoward((-1747f), (-1748f),                Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), (-1746f)),                math.nexttoward((-1747f), (-1746f),                Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((-1747f), double.NegativeInfinity), math.nexttoward((-1747f), double.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward(1747f,    double.PositiveInfinity), math.nexttoward(1747f,    double.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    0f),                      math.nexttoward(1747f,    0f,                      Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    1748f),                   math.nexttoward(1747f,    1748f,                   Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    1746f),                   math.nexttoward(1747f,    1746f,                   Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward(1747f,    double.NegativeInfinity), math.nexttoward(1747f,    double.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((-1747f), double.PositiveInfinity), math.nexttoward((-1747f), double.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), 0f),                      math.nexttoward((-1747f), 0f,                      Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), (-1748f)),                math.nexttoward((-1747f), (-1748f),                Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), (-1746f)),                math.nexttoward((-1747f), (-1746f),                Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((-1747f), double.NegativeInfinity), math.nexttoward((-1747f), double.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _double2()
        {
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)double.PositiveInfinity), math.nexttoward((double2)1747f,    (double2)double.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)0f),                      math.nexttoward((double2)1747f,    (double2)0f,                      Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)1748f),                   math.nexttoward((double2)1747f,    (double2)1748f,                   Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)1746f),                   math.nexttoward((double2)1747f,    (double2)1746f,                   Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)double.NegativeInfinity), math.nexttoward((double2)1747f,    (double2)double.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)double.PositiveInfinity), math.nexttoward((double2)(-1747f), (double2)double.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)0f),                      math.nexttoward((double2)(-1747f), (double2)0f,                      Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)(-1748f)),                math.nexttoward((double2)(-1747f), (double2)(-1748f),                Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)(-1746f)),                math.nexttoward((double2)(-1747f), (double2)(-1746f),                Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)double.NegativeInfinity), math.nexttoward((double2)(-1747f), (double2)double.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)double.PositiveInfinity), math.nexttoward((double2)1747f,    (double2)double.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)0f),                      math.nexttoward((double2)1747f,    (double2)0f,                      Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)1748f),                   math.nexttoward((double2)1747f,    (double2)1748f,                   Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)1746f),                   math.nexttoward((double2)1747f,    (double2)1746f,                   Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)double.NegativeInfinity), math.nexttoward((double2)1747f,    (double2)double.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)double.PositiveInfinity), math.nexttoward((double2)(-1747f), (double2)double.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)0f),                      math.nexttoward((double2)(-1747f), (double2)0f,                      Promise.Negative));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)(-1748f)),                math.nexttoward((double2)(-1747f), (double2)(-1748f),                Promise.Negative));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)(-1746f)),                math.nexttoward((double2)(-1747f), (double2)(-1746f),                Promise.Negative));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)double.NegativeInfinity), math.nexttoward((double2)(-1747f), (double2)double.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)double.PositiveInfinity), math.nexttoward((double2)1747f,    (double2)double.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)0f),                      math.nexttoward((double2)1747f,    (double2)0f,                      Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)1748f),                   math.nexttoward((double2)1747f,    (double2)1748f,                   Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)1746f),                   math.nexttoward((double2)1747f,    (double2)1746f,                   Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)double.NegativeInfinity), math.nexttoward((double2)1747f,    (double2)double.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)double.PositiveInfinity), math.nexttoward((double2)(-1747f), (double2)double.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)0f),                      math.nexttoward((double2)(-1747f), (double2)0f,                      Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)(-1748f)),                math.nexttoward((double2)(-1747f), (double2)(-1748f),                Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)(-1746f)),                math.nexttoward((double2)(-1747f), (double2)(-1746f),                Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)double.NegativeInfinity), math.nexttoward((double2)(-1747f), (double2)double.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)double.PositiveInfinity), math.nexttoward((double2)1747f,    (double2)double.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)0f),                      math.nexttoward((double2)1747f,    (double2)0f,                      Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)1748f),                   math.nexttoward((double2)1747f,    (double2)1748f,                   Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)1746f),                   math.nexttoward((double2)1747f,    (double2)1746f,                   Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)1747f,    (double2)double.NegativeInfinity), math.nexttoward((double2)1747f,    (double2)double.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)double.PositiveInfinity), math.nexttoward((double2)(-1747f), (double2)double.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)0f),                      math.nexttoward((double2)(-1747f), (double2)0f,                      Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)(-1748f)),                math.nexttoward((double2)(-1747f), (double2)(-1748f),                Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)(-1746f)),                math.nexttoward((double2)(-1747f), (double2)(-1746f),                Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double2)(-1747f), (double2)double.NegativeInfinity), math.nexttoward((double2)(-1747f), (double2)double.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _double3()
        {
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)double.PositiveInfinity), math.nexttoward((double3)1747f,    (double3)double.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)0f),                      math.nexttoward((double3)1747f,    (double3)0f,                      Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)1748f),                   math.nexttoward((double3)1747f,    (double3)1748f,                   Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)1746f),                   math.nexttoward((double3)1747f,    (double3)1746f,                   Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)double.NegativeInfinity), math.nexttoward((double3)1747f,    (double3)double.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)double.PositiveInfinity), math.nexttoward((double3)(-1747f), (double3)double.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)0f),                      math.nexttoward((double3)(-1747f), (double3)0f,                      Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)(-1748f)),                math.nexttoward((double3)(-1747f), (double3)(-1748f),                Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)(-1746f)),                math.nexttoward((double3)(-1747f), (double3)(-1746f),                Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)double.NegativeInfinity), math.nexttoward((double3)(-1747f), (double3)double.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)double.PositiveInfinity), math.nexttoward((double3)1747f,    (double3)double.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)0f),                      math.nexttoward((double3)1747f,    (double3)0f,                      Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)1748f),                   math.nexttoward((double3)1747f,    (double3)1748f,                   Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)1746f),                   math.nexttoward((double3)1747f,    (double3)1746f,                   Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)double.NegativeInfinity), math.nexttoward((double3)1747f,    (double3)double.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)double.PositiveInfinity), math.nexttoward((double3)(-1747f), (double3)double.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)0f),                      math.nexttoward((double3)(-1747f), (double3)0f,                      Promise.Negative));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)(-1748f)),                math.nexttoward((double3)(-1747f), (double3)(-1748f),                Promise.Negative));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)(-1746f)),                math.nexttoward((double3)(-1747f), (double3)(-1746f),                Promise.Negative));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)double.NegativeInfinity), math.nexttoward((double3)(-1747f), (double3)double.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)double.PositiveInfinity), math.nexttoward((double3)1747f,    (double3)double.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)0f),                      math.nexttoward((double3)1747f,    (double3)0f,                      Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)1748f),                   math.nexttoward((double3)1747f,    (double3)1748f,                   Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)1746f),                   math.nexttoward((double3)1747f,    (double3)1746f,                   Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)double.NegativeInfinity), math.nexttoward((double3)1747f,    (double3)double.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)double.PositiveInfinity), math.nexttoward((double3)(-1747f), (double3)double.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)0f),                      math.nexttoward((double3)(-1747f), (double3)0f,                      Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)(-1748f)),                math.nexttoward((double3)(-1747f), (double3)(-1748f),                Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)(-1746f)),                math.nexttoward((double3)(-1747f), (double3)(-1746f),                Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)double.NegativeInfinity), math.nexttoward((double3)(-1747f), (double3)double.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)double.PositiveInfinity), math.nexttoward((double3)1747f,    (double3)double.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)0f),                      math.nexttoward((double3)1747f,    (double3)0f,                      Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)1748f),                   math.nexttoward((double3)1747f,    (double3)1748f,                   Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)1746f),                   math.nexttoward((double3)1747f,    (double3)1746f,                   Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)1747f,    (double3)double.NegativeInfinity), math.nexttoward((double3)1747f,    (double3)double.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)double.PositiveInfinity), math.nexttoward((double3)(-1747f), (double3)double.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)0f),                      math.nexttoward((double3)(-1747f), (double3)0f,                      Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)(-1748f)),                math.nexttoward((double3)(-1747f), (double3)(-1748f),                Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)(-1746f)),                math.nexttoward((double3)(-1747f), (double3)(-1746f),                Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double3)(-1747f), (double3)double.NegativeInfinity), math.nexttoward((double3)(-1747f), (double3)double.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }

        [Test]
        public static void _double4()
        {
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)double.PositiveInfinity), math.nexttoward((double4)1747f,    (double4)double.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)0f),                      math.nexttoward((double4)1747f,    (double4)0f,                      Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)1748f),                   math.nexttoward((double4)1747f,    (double4)1748f,                   Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)1746f),                   math.nexttoward((double4)1747f,    (double4)1746f,                   Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)double.NegativeInfinity), math.nexttoward((double4)1747f,    (double4)double.NegativeInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)double.PositiveInfinity), math.nexttoward((double4)(-1747f), (double4)double.PositiveInfinity, Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)0f),                      math.nexttoward((double4)(-1747f), (double4)0f,                      Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)(-1748f)),                math.nexttoward((double4)(-1747f), (double4)(-1748f),                Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)(-1746f)),                math.nexttoward((double4)(-1747f), (double4)(-1746f),                Promise.NonZero));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)double.NegativeInfinity), math.nexttoward((double4)(-1747f), (double4)double.NegativeInfinity, Promise.NonZero));

            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)double.PositiveInfinity), math.nexttoward((double4)1747f,    (double4)double.PositiveInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)0f),                      math.nexttoward((double4)1747f,    (double4)0f,                      Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)1748f),                   math.nexttoward((double4)1747f,    (double4)1748f,                   Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)1746f),                   math.nexttoward((double4)1747f,    (double4)1746f,                   Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)double.NegativeInfinity), math.nexttoward((double4)1747f,    (double4)double.NegativeInfinity, Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)double.PositiveInfinity), math.nexttoward((double4)(-1747f), (double4)double.PositiveInfinity, Promise.Negative));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)0f),                      math.nexttoward((double4)(-1747f), (double4)0f,                      Promise.Negative));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)(-1748f)),                math.nexttoward((double4)(-1747f), (double4)(-1748f),                Promise.Negative));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)(-1746f)),                math.nexttoward((double4)(-1747f), (double4)(-1746f),                Promise.Negative));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)double.NegativeInfinity), math.nexttoward((double4)(-1747f), (double4)double.NegativeInfinity, Promise.Negative));

            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)double.PositiveInfinity), math.nexttoward((double4)1747f,    (double4)double.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)0f),                      math.nexttoward((double4)1747f,    (double4)0f,                      Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)1748f),                   math.nexttoward((double4)1747f,    (double4)1748f,                   Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)1746f),                   math.nexttoward((double4)1747f,    (double4)1746f,                   Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)double.NegativeInfinity), math.nexttoward((double4)1747f,    (double4)double.NegativeInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)double.PositiveInfinity), math.nexttoward((double4)(-1747f), (double4)double.PositiveInfinity, Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)0f),                      math.nexttoward((double4)(-1747f), (double4)0f,                      Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)(-1748f)),                math.nexttoward((double4)(-1747f), (double4)(-1748f),                Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)(-1746f)),                math.nexttoward((double4)(-1747f), (double4)(-1746f),                Promise.Unsafe0));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)double.NegativeInfinity), math.nexttoward((double4)(-1747f), (double4)double.NegativeInfinity, Promise.Unsafe0));

            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)double.PositiveInfinity), math.nexttoward((double4)1747f,    (double4)double.PositiveInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)0f),                      math.nexttoward((double4)1747f,    (double4)0f,                      Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)1748f),                   math.nexttoward((double4)1747f,    (double4)1748f,                   Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)1746f),                   math.nexttoward((double4)1747f,    (double4)1746f,                   Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)1747f,    (double4)double.NegativeInfinity), math.nexttoward((double4)1747f,    (double4)double.NegativeInfinity, Promise.Unsafe0 | Promise.Positive));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)double.PositiveInfinity), math.nexttoward((double4)(-1747f), (double4)double.PositiveInfinity, Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)0f),                      math.nexttoward((double4)(-1747f), (double4)0f,                      Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)(-1748f)),                math.nexttoward((double4)(-1747f), (double4)(-1748f),                Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)(-1746f)),                math.nexttoward((double4)(-1747f), (double4)(-1746f),                Promise.Unsafe0 | Promise.Negative));
            Assert.AreEqual(math.nexttoward((double4)(-1747f), (double4)double.NegativeInfinity), math.nexttoward((double4)(-1747f), (double4)double.NegativeInfinity, Promise.Unsafe0 | Promise.Negative));
        }
    }
}
