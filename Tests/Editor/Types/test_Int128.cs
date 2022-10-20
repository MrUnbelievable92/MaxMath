using NUnit.Framework;
using Unity.Mathematics;
using System.Numerics;

namespace MaxMath.Tests
{
    unsafe public static class __int128
    {
        private static Random8 RNG8 => Random8.New; 
        private static Random16 RNG16 => Random16.New; 
        private static Random32 RNG32 => Random32.New; 
        private static Random64 RNG64 => Random64.New; 
        private static Random128 RNG128 => Random128.New; 

        private const int NUM_TESTS = 200;


        [Test]
        public static void ConvertFromHalf()
        {
            Random16 rng = RNG16;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                half t = new half { value = rng.NextUShort() };
                t = maxmath.isnan(t) ? (half)(-1f) : t;
                t = t != float.PositiveInfinity ? t : (half)1f;
                t = t != float.NegativeInfinity ? t : (half)(-1f);

                Assert.AreEqual((BigInteger)(float)t, (BigInteger)(Int128)t);
            }
        }

        [Test]
        public static void ConvertFromFloat()
        {
            Random32 rng = RNG32;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float t = rng.NextFloat(Int128.MinValue / 2, Int128.MaxValue / 2);

                Assert.AreEqual((BigInteger)t, (BigInteger)(Int128)t);
            }
        }

        [Test]
        public static void ConvertFromDouble()
        {
            Random64 rng = RNG64;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                double t = rng.NextDouble(Int128.MinValue, Int128.MaxValue + 1d);

                Assert.AreEqual((BigInteger)t, (BigInteger)(Int128)t);
            }
        }

        [Test]
        public static void ConvertFromDecimal()
        {
            Random64 rng = RNG64;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                decimal t = (decimal)rng.NextDouble((double)decimal.MinValue, (double)decimal.MaxValue + 1d);

                Assert.AreEqual((BigInteger)t, (BigInteger)(Int128)t);
            }
        }

        [Test]
        public static void ConvertToBigInteger()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 t = rng.NextInt128();
                
                Assert.AreEqual((BigInteger)t, t >= 0 ? (UInt128)(t) : -(BigInteger)(UInt128)(-t));
            }
        }

        [Test]
        public static void ConvertToHalf()
        {
            Random16 rng = RNG16;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                half t = new half { value = rng.NextUShort() };
                t = maxmath.isnan(t) ? (half)(-1f) : t;
                t = t != float.PositiveInfinity ? t : (half)1f;
                t = t != float.NegativeInfinity ? t : (half)(-1f);
                
                Assert.AreEqual((float)(half)(t >= 0f ? math.floor(t) : math.ceil(t)), (float)(half)(Int128)t);
            }
        }

        [Test]
        public static void ConvertToFloat()
        {
            Random32 rng = RNG32;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float t = rng.NextFloat(Int128.MinValue / 2, Int128.MaxValue / 2);

                Assert.AreEqual(t >= 0f ? math.floor(t) : math.ceil(t), (float)(Int128)t);
            }
        }

        [Test]
        public static void ConvertToDouble()
        {
            Random64 rng = RNG64;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                double t = rng.NextDouble(Int128.MinValue, Int128.MaxValue + 1d);
                
                Assert.AreEqual(t >= 0f ? math.floor(t) : math.ceil(t), (double)(Int128)t);
            }
        }

        [Test]
        public static void ConvertToDecimal()
        {
            Random64 rng = RNG64;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                decimal t = (decimal)rng.NextDouble((double)decimal.MinValue, (double)decimal.MaxValue + 1d);
                
                Assert.AreEqual(t >= 0m ? decimal.Floor(t) : decimal.Ceiling(t), (decimal)(Int128)t);
            }
        }

        [Test]
        public static void AddInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();

                Assert.AreEqual(left + right, (Int128)((BigInteger)left + (BigInteger)right));
            }
        }

        [Test]
        public static void SubtractInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();
                
                Assert.AreEqual(left - right, (Int128)((BigInteger)left - (BigInteger)right));
            }
        }

        [Test]
        public static void MultiplyInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();
                
                Assert.AreEqual(left * right, (Int128)((BigInteger)left * (BigInteger)right));
            }
        }

        [Test]
        public static void DivideInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left / right, (Int128)((BigInteger)left / (BigInteger)right));
            }
        }

        [Test]
        public static void ModuloInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left % right, (Int128)((BigInteger)left % (BigInteger)right));
            }
        }

        [Test]
        public static void EqualInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();

                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                left = right;
                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                Assert.AreEqual((Int128)0 == right, ((BigInteger)0 == (BigInteger)right));
                Assert.AreEqual(left == (Int128)0, ((BigInteger)left == (BigInteger)0));
            }
        }

        [Test]
        public static void NotEqualInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();

                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                left = right;
                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                Assert.AreEqual((Int128)0 != right, ((BigInteger)0 != (BigInteger)right));
                Assert.AreEqual(left != (Int128)0, ((BigInteger)left != (BigInteger)0));
            }
        }

        [Test]
        public static void LessInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();

                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                left = right;
                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                Assert.AreEqual((Int128)0 < right, ((BigInteger)0 < (BigInteger)right));
                Assert.AreEqual(left < (Int128)0, ((BigInteger)left < (BigInteger)0));
            }
        }

        [Test]
        public static void GreaterInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();

                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                left = right;
                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                Assert.AreEqual((Int128)0 > right, ((BigInteger)0 > (BigInteger)right));
                Assert.AreEqual(left > (Int128)0, ((BigInteger)left > (BigInteger)0));
            }
        }

        [Test]
        public static void LessEqualInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();

                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                left = right;
                Assert.AreEqual(left <= right, ((BigInteger)left >= (BigInteger)right));

                Assert.AreEqual((Int128)0 <= right, ((BigInteger)0 <= (BigInteger)right));
                Assert.AreEqual(left <= (Int128)0, ((BigInteger)left <= (BigInteger)0));
            }
        }

        [Test]
        public static void GreaterEqualInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                Int128 right = rng.NextInt128();

                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                left = right;
                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                Assert.AreEqual((Int128)0 >= right, ((BigInteger)0 >= (BigInteger)right));
                Assert.AreEqual(left >= (Int128)0, ((BigInteger)left >= (BigInteger)0));
            }
        }


        [Test]
        public static void AddULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();
                
                Assert.AreEqual(left + right, (Int128)((BigInteger)left + (BigInteger)right));
            }
        }

        [Test]
        public static void SubtractULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();
                
                Assert.AreEqual(left - right, (Int128)((BigInteger)left - (BigInteger)right));
            }
        }

        [Test]
        public static void MultiplyULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();
                
                Assert.AreEqual(left * right, (Int128)((BigInteger)left * (BigInteger)right));
            }
        }

        [Test]
        public static void DivideULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left / right, (Int128)((BigInteger)left / (BigInteger)right));
            }
        }

        [Test]
        public static void ModuloULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left % right, (Int128)((BigInteger)left % (BigInteger)right));
            }
        }

        [Test]
        public static void EqualULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();

                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                left = right;
                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                Assert.AreEqual((ulong)0 == left, ((ulong)0 == (BigInteger)left));
                Assert.AreEqual(left == (ulong)0, ((BigInteger)left == (ulong)0));
            }
        }

        [Test]
        public static void NotEqualULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();

                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                left = right;
                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                Assert.AreEqual((ulong)0 != left, ((ulong)0 != (BigInteger)left));
                Assert.AreEqual(left != (ulong)0, ((BigInteger)left != (ulong)0));
            }
        }

        [Test]
        public static void LessULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();

                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                left = right;
                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                Assert.AreEqual((ulong)0 < left, ((ulong)0 < (BigInteger)left));
                Assert.AreEqual(left < (ulong)0, ((BigInteger)left < (ulong)0));
            }
        }

        [Test]
        public static void GreaterULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();

                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                left = right;
                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                Assert.AreEqual((ulong)0 > left, ((ulong)0 > (BigInteger)left));
                Assert.AreEqual(left > (ulong)0, ((BigInteger)left > (ulong)0));
            }
        }

        [Test]
        public static void LessEqualULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();

                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                left = right;
                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                Assert.AreEqual((ulong)0 <= left, ((ulong)0 <= (BigInteger)left));
                Assert.AreEqual(left <= (ulong)0, ((BigInteger)left <= (ulong)0));
            }
        }

        [Test]
        public static void GreaterEqualULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                ulong right = (ulong)rng.NextInt128();

                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                left = right;
                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));
                
                Assert.AreEqual((ulong)0 >= left, ((ulong)0 >= (BigInteger)left));
                Assert.AreEqual(left >= (ulong)0, ((BigInteger)left >= (ulong)0));
            }
        }

        [Test]
        public static void AddInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();
                
                Assert.AreEqual(left + right, (Int128)((BigInteger)left + (BigInteger)right));
            }
        }

        [Test]
        public static void SubtractInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();
                
                Assert.AreEqual(left - right, (Int128)((BigInteger)left - (BigInteger)right));
            }
        }

        [Test]
        public static void MultiplyInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();
                
                Assert.AreEqual(left * right, (Int128)((BigInteger)left * (BigInteger)right));
            }
        }

        [Test]
        public static void DivideInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left / right, (Int128)((BigInteger)left / (BigInteger)right));
            }
        }

        [Test]
        public static void ModuloInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left % right, (Int128)((BigInteger)left % (BigInteger)right));
            }
        }

        [Test]
        public static void EqualUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();

                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                left = right;
                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                Assert.AreEqual((uint)0 == left, ((uint)0 == (BigInteger)left));
                Assert.AreEqual(left == (uint)0, ((BigInteger)left == (uint)0));
            }
        }

        [Test]
        public static void NotEqualUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();

                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                left = right;
                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                Assert.AreEqual((uint)0 != left, ((uint)0 != (BigInteger)left));
                Assert.AreEqual(left != (uint)0, ((BigInteger)left != (uint)0));
            }
        }

        [Test]
        public static void LessUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();

                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                left = right;
                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                Assert.AreEqual((uint)0 < left, ((uint)0 < (BigInteger)left));
                Assert.AreEqual(left < (uint)0, ((BigInteger)left < (uint)0));
            }
        }

        [Test]
        public static void GreaterUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();

                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                left = right;
                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                Assert.AreEqual((uint)0 > left, ((uint)0 > (BigInteger)left));
                Assert.AreEqual(left > (uint)0, ((BigInteger)left > (uint)0));
            }
        }

        [Test]
        public static void LessEqualUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();

                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                left = right;
                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                Assert.AreEqual((uint)0 <= left, ((uint)0 <= (BigInteger)left));
                Assert.AreEqual(left <= (uint)0, ((BigInteger)left <= (uint)0));
            }
        }

        [Test]
        public static void GreaterEqualUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();

                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                left = right;
                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));
                
                Assert.AreEqual((uint)0 >= left, ((uint)0 >= (BigInteger)left));
                Assert.AreEqual(left >= (uint)0, ((BigInteger)left >= (uint)0));
            }
        }


        [Test]
        public static void AddLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();
                
                Assert.AreEqual(left + right, (Int128)((BigInteger)left + (BigInteger)right));
            }
        }

        [Test]
        public static void SubtractLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();
                
                Assert.AreEqual(left - right, (Int128)((BigInteger)left - (BigInteger)right));
            }
        }

        [Test]
        public static void MultiplyLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();
                
                Assert.AreEqual(left * right, (Int128)((BigInteger)left * (BigInteger)right));
            }
        }

        [Test]
        public static void DivideLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left / right, (Int128)((BigInteger)left / (BigInteger)right));
            }
        }

        [Test]
        public static void ModuloLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left % right, (Int128)((BigInteger)left % (BigInteger)right));
            }
        }

        [Test]
        public static void EqualLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();

                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                left = right;
                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                Assert.AreEqual((long)0 == left, ((long)0 == (BigInteger)left));
                Assert.AreEqual(left == (long)0, ((BigInteger)left == (long)0));
            }
        }

        [Test]
        public static void NotEqualLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();

                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                left = right;
                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                Assert.AreEqual((long)0 != left, ((long)0 != (BigInteger)left));
                Assert.AreEqual(left != (long)0, ((BigInteger)left != (long)0));
            }
        }

        [Test]
        public static void LessLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();

                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                left = right;
                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                Assert.AreEqual((long)0 < left, ((long)0 < (BigInteger)left));
                Assert.AreEqual(left < (long)0, ((BigInteger)left < (long)0));
            }
        }

        [Test]
        public static void GreaterLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();

                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                left = right;
                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                Assert.AreEqual((long)0 > left, ((long)0 > (BigInteger)left));
                Assert.AreEqual(left > (long)0, ((BigInteger)left > (long)0));
            }
        }

        [Test]
        public static void LessEqualLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();

                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                left = right;
                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                Assert.AreEqual((long)0 <= left, ((long)0 <= (BigInteger)left));
                Assert.AreEqual(left <= (long)0, ((BigInteger)left <= (long)0));
            }
        }

        [Test]
        public static void GreaterEqualLong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                long right = (long)rng.NextInt128();

                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                left = right;
                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));
                
                Assert.AreEqual((long)0 >= left, ((long)0 >= (BigInteger)left));
                Assert.AreEqual(left >= (long)0, ((BigInteger)left >= (long)0));
            }
        }

        [Test]
        public static void AddUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();
                
                Assert.AreEqual(left + right, (Int128)((BigInteger)left + (BigInteger)right));
            }
        }

        [Test]
        public static void SubtractUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();
                
                Assert.AreEqual(left - right, (Int128)((BigInteger)left - (BigInteger)right));
            }
        }

        [Test]
        public static void MultiplyUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();
                
                Assert.AreEqual(left * right, (Int128)((BigInteger)left * (BigInteger)right));
            }
        }

        [Test]
        public static void DivideUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left / right, (Int128)((BigInteger)left / (BigInteger)right));
            }
        }

        [Test]
        public static void ModuloUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                uint right = (uint)rng.NextInt128();
                right = right != 0 ? right : 1;
                
                Assert.AreEqual(left % right, (Int128)((BigInteger)left % (BigInteger)right));
            }
        }

        [Test]
        public static void EqualInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();

                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                left = right;
                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                Assert.AreEqual((int)0 == left, ((int)0 == (BigInteger)left));
                Assert.AreEqual(left == (int)0, ((BigInteger)left == (int)0));
            }
        }

        [Test]
        public static void NotEqualInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();

                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                left = right;
                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                Assert.AreEqual((int)0 != left, ((int)0 != (BigInteger)left));
                Assert.AreEqual(left != (int)0, ((BigInteger)left != (int)0));
            }
        }

        [Test]
        public static void LessInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();

                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                left = right;
                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                Assert.AreEqual((int)0 < left, ((int)0 < (BigInteger)left));
                Assert.AreEqual(left < (int)0, ((BigInteger)left < (int)0));
            }
        }

        [Test]
        public static void GreaterInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();

                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                left = right;
                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                Assert.AreEqual((int)0 > left, ((int)0 > (BigInteger)left));
                Assert.AreEqual(left > (int)0, ((BigInteger)left > (int)0));
            }
        }

        [Test]
        public static void LessEqualInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();

                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                left = right;
                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                Assert.AreEqual((int)0 <= left, ((int)0 <= (BigInteger)left));
                Assert.AreEqual(left <= (int)0, ((BigInteger)left <= (int)0));
            }
        }

        [Test]
        public static void GreaterEqualInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();
                int right = (int)rng.NextInt128();

                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                left = right;
                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));
                
                Assert.AreEqual((int)0 >= left, ((int)0 >= (BigInteger)left));
                Assert.AreEqual(left >= (int)0, ((BigInteger)left >= (int)0));
            }
        }


        [Test]
        public static void ShiftLeft()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();

                Assert.AreEqual(left << 0, left);
                Assert.AreEqual(left << 128, left);

                for (int j = 1; j < 128; j++)
                {
                    Assert.AreEqual((Int128)((BigInteger)UInt128.MaxValue & ((BigInteger)left << j)), 
                                    (Int128)(BigInteger)(left << j));
                }
            }
        }

        [Test]
        public static void ShiftRight()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 left  = rng.NextInt128();

                Assert.AreEqual(left >> 0, left);
                Assert.AreEqual(left >> 128, left);

                for (int j = 1; j < 128; j++)
                {
                    Assert.AreEqual((BigInteger)left >> j, 
                                    (BigInteger)(left >> j));
                }
            }
        }


        [Test]
        new public static void ToString()
        {
            Random128 rng = Random128.New;
            Int128 x = 0;

            Assert.AreEqual(Int128.MAX_DECIMAL_DIGITS, ((BigInteger)Int128.MaxValue).ToString().Length);
            Assert.AreEqual(Int128.MAX_DECIMAL_DIGITS + 1, ((BigInteger)Int128.MinValue).ToString().Length);
            Assert.AreEqual(x.ToString(), "0");
            Assert.AreEqual(Int128.MinValue.ToString(), ((BigInteger)Int128.MinValue).ToString());
            Assert.AreEqual(Int128.MaxValue.ToString(), ((BigInteger)Int128.MaxValue).ToString());

            for (int i = 0; i < 25; i++)
            {
                x = rng.NextInt128();
                Assert.AreEqual(x.ToString(), ((BigInteger)x).ToString());
                x = -x;
                Assert.AreEqual(x.ToString(), ((BigInteger)x).ToString());

                x = rng.NextInt128(0, uint.MaxValue);
                Assert.AreEqual(x.ToString(), ((BigInteger)x).ToString());
                x = -x;
                Assert.AreEqual(x.ToString(), ((BigInteger)x).ToString());

                x = rng.NextInt128(0, 10);
                Assert.AreEqual(x.ToString(), ((BigInteger)x).ToString());
                x = -x;
                Assert.AreEqual(x.ToString(), ((BigInteger)x).ToString());
            }
        }
    }
}