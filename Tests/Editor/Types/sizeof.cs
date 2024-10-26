using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_SizeOf
    {
        [Test]
        public static void Size()
        {
            Assert.AreEqual(128 / 8, sizeof(UInt128));
            Assert.AreEqual(128 / 8, sizeof(Int128));

            Assert.AreEqual(2  * sizeof(byte), sizeof(byte2));
            Assert.AreEqual(3  * sizeof(byte), sizeof(byte3));
            Assert.AreEqual(4  * sizeof(byte), sizeof(byte4));
            Assert.AreEqual(8  * sizeof(byte), sizeof(byte8));
            Assert.AreEqual(16 * sizeof(byte), sizeof(byte16));
            Assert.AreEqual(32 * sizeof(byte), sizeof(byte32));

            Assert.AreEqual(2 * 2 * sizeof(byte), sizeof(byte2x2));
            Assert.AreEqual(2 * 3 * sizeof(byte), sizeof(byte2x3));
            Assert.AreEqual(2 * 4 * sizeof(byte), sizeof(byte2x4));

            Assert.AreEqual(3 * 2 * sizeof(byte), sizeof(byte3x2));
            Assert.AreEqual(3 * 3 * sizeof(byte), sizeof(byte3x3));
            Assert.AreEqual(3 * 4 * sizeof(byte), sizeof(byte3x4));

            Assert.AreEqual(4 * 2 * sizeof(byte), sizeof(byte4x2));
            Assert.AreEqual(4 * 3 * sizeof(byte), sizeof(byte4x3));
            Assert.AreEqual(4 * 4 * sizeof(byte), sizeof(byte4x4));


            Assert.AreEqual(2  * sizeof(sbyte), sizeof(sbyte2));
            Assert.AreEqual(3  * sizeof(sbyte), sizeof(sbyte3));
            Assert.AreEqual(4  * sizeof(sbyte), sizeof(sbyte4));
            Assert.AreEqual(8  * sizeof(sbyte), sizeof(sbyte8));
            Assert.AreEqual(16 * sizeof(sbyte), sizeof(sbyte16));
            Assert.AreEqual(32 * sizeof(sbyte), sizeof(sbyte32));

            Assert.AreEqual(2 * 2 * sizeof(sbyte), sizeof(sbyte2x2));
            Assert.AreEqual(2 * 3 * sizeof(sbyte), sizeof(sbyte2x3));
            Assert.AreEqual(2 * 4 * sizeof(sbyte), sizeof(sbyte2x4));

            Assert.AreEqual(3 * 2 * sizeof(sbyte), sizeof(sbyte3x2));
            Assert.AreEqual(3 * 3 * sizeof(sbyte), sizeof(sbyte3x3));
            Assert.AreEqual(3 * 4 * sizeof(sbyte), sizeof(sbyte3x4));

            Assert.AreEqual(4 * 2 * sizeof(sbyte), sizeof(sbyte4x2));
            Assert.AreEqual(4 * 3 * sizeof(sbyte), sizeof(sbyte4x3));
            Assert.AreEqual(4 * 4 * sizeof(sbyte), sizeof(sbyte4x4));


            Assert.AreEqual(2  * sizeof(ushort), sizeof(ushort2));
            Assert.AreEqual(3  * sizeof(ushort), sizeof(ushort3));
            Assert.AreEqual(4  * sizeof(ushort), sizeof(ushort4));
            Assert.AreEqual(8  * sizeof(ushort), sizeof(ushort8));
            Assert.AreEqual(16 * sizeof(ushort), sizeof(ushort16));

            Assert.AreEqual(2 * 2 * sizeof(ushort), sizeof(ushort2x2));
            Assert.AreEqual(2 * 3 * sizeof(ushort), sizeof(ushort2x3));
            Assert.AreEqual(2 * 4 * sizeof(ushort), sizeof(ushort2x4));

            Assert.AreEqual(3 * 2 * sizeof(ushort), sizeof(ushort3x2));
            Assert.AreEqual(3 * 3 * sizeof(ushort), sizeof(ushort3x3));
            Assert.AreEqual(3 * 4 * sizeof(ushort), sizeof(ushort3x4));

            Assert.AreEqual(4 * 2 * sizeof(ushort), sizeof(ushort4x2));
            Assert.AreEqual(4 * 3 * sizeof(ushort), sizeof(ushort4x3));
            Assert.AreEqual(4 * 4 * sizeof(ushort), sizeof(ushort4x4));


            Assert.AreEqual(2  * sizeof(short), sizeof(short2));
            Assert.AreEqual(3  * sizeof(short), sizeof(short3));
            Assert.AreEqual(4  * sizeof(short), sizeof(short4));
            Assert.AreEqual(8  * sizeof(short), sizeof(short8));
            Assert.AreEqual(16 * sizeof(short), sizeof(short16));

            Assert.AreEqual(2 * 2 * sizeof(short), sizeof(short2x2));
            Assert.AreEqual(2 * 3 * sizeof(short), sizeof(short2x3));
            Assert.AreEqual(2 * 4 * sizeof(short), sizeof(short2x4));

            Assert.AreEqual(3 * 2 * sizeof(short), sizeof(short3x2));
            Assert.AreEqual(3 * 3 * sizeof(short), sizeof(short3x3));
            Assert.AreEqual(3 * 4 * sizeof(short), sizeof(short3x4));

            Assert.AreEqual(4 * 2 * sizeof(short), sizeof(short4x2));
            Assert.AreEqual(4 * 3 * sizeof(short), sizeof(short4x3));
            Assert.AreEqual(4 * 4 * sizeof(short), sizeof(short4x4));



            Assert.AreEqual(8  * sizeof(uint), sizeof(uint8));


            Assert.AreEqual(8  * sizeof(int), sizeof(int8));



            Assert.AreEqual(2  * sizeof(ulong), sizeof(ulong2));
            Assert.AreEqual(3  * sizeof(ulong), sizeof(ulong3));
            Assert.AreEqual(4  * sizeof(ulong), sizeof(ulong4));

            Assert.AreEqual(2 * 2 * sizeof(ulong), sizeof(ulong2x2));
            Assert.AreEqual(2 * 3 * sizeof(ulong), sizeof(ulong2x3));
            Assert.AreEqual(2 * 4 * sizeof(ulong), sizeof(ulong2x4));

            Assert.AreEqual(3 * 2 * sizeof(ulong), sizeof(ulong3x2));
            Assert.AreEqual(3 * 3 * sizeof(ulong), sizeof(ulong3x3));
            Assert.AreEqual(3 * 4 * sizeof(ulong), sizeof(ulong3x4));

            Assert.AreEqual(4 * 2 * sizeof(ulong), sizeof(ulong4x2));
            Assert.AreEqual(4 * 3 * sizeof(ulong), sizeof(ulong4x3));
            Assert.AreEqual(4 * 4 * sizeof(ulong), sizeof(ulong4x4));


            Assert.AreEqual(2  * sizeof(long), sizeof(long2));
            Assert.AreEqual(3  * sizeof(long), sizeof(long3));
            Assert.AreEqual(4  * sizeof(long), sizeof(long4));

            Assert.AreEqual(2 * 2 * sizeof(long), sizeof(long2x2));
            Assert.AreEqual(2 * 3 * sizeof(long), sizeof(long2x3));
            Assert.AreEqual(2 * 4 * sizeof(long), sizeof(long2x4));

            Assert.AreEqual(3 * 2 * sizeof(long), sizeof(long3x2));
            Assert.AreEqual(3 * 3 * sizeof(long), sizeof(long3x3));
            Assert.AreEqual(3 * 4 * sizeof(long), sizeof(long3x4));

            Assert.AreEqual(4 * 2 * sizeof(long), sizeof(long4x2));
            Assert.AreEqual(4 * 3 * sizeof(long), sizeof(long4x3));
            Assert.AreEqual(4 * 4 * sizeof(long), sizeof(long4x4));



            Assert.AreEqual(sizeof(quarter), sizeof(byte));
            Assert.AreEqual(2  * sizeof(quarter), sizeof(quarter2));
            Assert.AreEqual(3  * sizeof(quarter), sizeof(quarter3));
            Assert.AreEqual(4  * sizeof(quarter), sizeof(quarter4));
            Assert.AreEqual(8  * sizeof(quarter), sizeof(quarter8));



            Assert.AreEqual(8  * sizeof(half), sizeof(half8));


            Assert.AreEqual(8  * sizeof(float), sizeof(float8));
        }
    }
}