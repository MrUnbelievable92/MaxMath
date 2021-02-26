using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class countbits
    {
        [Test]
        public static void countbits_in_memory()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 8; i++)
            {
                byte[] test = new byte[((Random32)rng).NextInt(1, 10_000_000)];

                for (int j = 0; j < test.Length; j++)
                {
                    test[j] = rng.NextByte();
                }


                fixed (void* ptr = &test[0])
                {
                    ulong bits = 0;
                    ulong bytes = (ulong)test.Length;


                    ulong longs = maxmath.divrem(bytes, 8, out ulong residuals);


                    for (ulong j = 0; j < longs; j++)
                    {
                        bits += (ulong)math.countbits(*((ulong*)ptr + j));
                    }

                    void* ptr2 = (ulong*)ptr + longs;

                    while (residuals != 0)
                    {
                        bits += (ulong)math.countbits((uint)(*(byte*)ptr2));

                        ptr2 = (byte*)ptr2 + 1;
                        residuals--;
                    }

                    Assert.AreEqual(bits, maxmath.countbits(ptr, bytes));
                }
            }
        }
    }
}
