using NUnit.Framework;
using Unity.Mathematics;
using System.Numerics;

namespace MaxMath.Tests
{
    unsafe public static class __uint128
    {
        private static Random8 RNG8 => new Random8(233); 
        private static Random16 RNG16 => new Random16(16347); 
        private static Random32 RNG32 => new Random32(468634842); 
        private static Random64 RNG64 => new Random64(4264524138550143697); 
        private static Random128 RNG128 => new Random128("19447778766103741871339139486"); 

        private const int NUM_TESTS = 200;


        [Test]
        public static void ConvertFromHalf()
        {
            Random16 rng = RNG16;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                half t = (half)math.max(0f, new half { value = rng.NextUShort() });
                t = maxmath.isnan(t) ? (half)1f : t;
                t = t != float.PositiveInfinity ? t : (half)1f;

                Assert.AreEqual((BigInteger)(float)t, (BigInteger)(UInt128)t);
            }
        }

        [Test]
        public static void ConvertFromFloat()
        {
            Random32 rng = RNG32;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float t = rng.NextFloat(0, float.MaxValue);

                Assert.AreEqual((BigInteger)t, (BigInteger)(UInt128)t);
            }
        }

        [Test]
        public static void ConvertFromDouble()
        {
            Random64 rng = RNG64;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                double t = rng.NextDouble(0, UInt128.MaxValue + 1d);

                Assert.AreEqual((BigInteger)t, (BigInteger)(UInt128)t);
            }
        }

        [Test]
        public static void ConvertFromDecimal()
        {
            Random64 rng = RNG64;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                decimal t = (decimal)rng.NextDouble(0, (double)decimal.MaxValue + 1d);

                Assert.AreEqual((BigInteger)t, (BigInteger)(UInt128)t);
            }
        }

        [Test]
        public static void ConvertToBigInteger()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 t = rng.NextUInt128();
                
                Assert.AreEqual((BigInteger)t, (BigInteger)t.lo | (BigInteger)t.hi << 64);
            }
        }

        [Test]
        public static void ConvertToHalf()
        {
            Random16 rng = RNG16;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                half t = (half)math.max(0f, new half { value = rng.NextUShort() });
                t = maxmath.isnan(t) ? (half)1f : t;
                t = t != float.PositiveInfinity ? t : (half)1f;
                
                Assert.AreEqual((half)math.floor(t), (half)(UInt128)t);
            }
        }

        [Test]
        public static void ConvertToFloat()
        {
            Random32 rng = RNG32;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float t = rng.NextFloat(0, UInt128.MaxValue + 1f);
                
                Assert.AreEqual(math.floor(t), (float)(UInt128)t);
            }
        }

        [Test]
        public static void ConvertToDouble()
        {
            Random64 rng = RNG64;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                double t = rng.NextDouble(0, UInt128.MaxValue + 1d);
                
                Assert.AreEqual(math.floor(t), (double)(UInt128)t);
            }
        }

        [Test]
        public static void ConvertToDecimal()
        {
            Random64 rng = RNG64;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                decimal t = (decimal)rng.NextDouble(0, (double)decimal.MaxValue + 1d);
                
                Assert.AreEqual(decimal.Floor(t), (decimal)(UInt128)t);
            }
        }

        [Test]
        public static void AddUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left + (BigInteger)right), 
                                (BigInteger)(left + right));
            }
        }

        [Test]
        public static void SubtractUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left - (BigInteger)right), 
                                (BigInteger)(left - right));
            }
        }

        [Test]
        public static void MultiplyUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }
        }

        [Test]
        public static void DivideUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                right = right != 0 ? right : 1;

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left / (BigInteger)right), 
                                (BigInteger)(left / right));
            }
        }

        [Test]
        public static void ModuloUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                right = right != 0 ? right : 1;

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left % (BigInteger)right), 
                                (BigInteger)(left % right));
            }
        }

        [Test]
        public static void EqualUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                left = right;
                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                Assert.AreEqual((UInt128)0 == left, ((BigInteger)0 == (BigInteger)left));
                Assert.AreEqual(left == (UInt128)0, ((BigInteger)left == (BigInteger)0));
            }
        }

        [Test]
        public static void NotEqualUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                left = right;
                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                Assert.AreEqual((UInt128)0 != left, ((BigInteger)0 != (BigInteger)left));
                Assert.AreEqual(left != (UInt128)0, ((BigInteger)left != (BigInteger)0));
            }
        }

        [Test]
        public static void LessUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                left = right;
                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                Assert.AreEqual((UInt128)0 < left, ((BigInteger)0 < (BigInteger)left));
                Assert.AreEqual(left < (UInt128)0, ((BigInteger)left < (BigInteger)0));
            }
        }

        [Test]
        public static void GreaterUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                left = right;
                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                Assert.AreEqual((UInt128)0 > left, ((BigInteger)0 > (BigInteger)left));
                Assert.AreEqual(left > (UInt128)0, ((BigInteger)left > (BigInteger)0));
            }
        }

        [Test]
        public static void LessEqualUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                left = right;
                Assert.AreEqual(left <= right, ((BigInteger)left >= (BigInteger)right));

                Assert.AreEqual((UInt128)0 <= left, ((BigInteger)0 <= (BigInteger)left));
                Assert.AreEqual(left <= (UInt128)0, ((BigInteger)left <= (BigInteger)0));
            }
        }

        [Test]
        public static void GreaterEqualUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                left = right;
                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                Assert.AreEqual((UInt128)0 >= left, ((BigInteger)0 >= (BigInteger)left));
                Assert.AreEqual(left >= (UInt128)0, ((BigInteger)left >= (BigInteger)0));
            }
        }

        [Test]
        public static void AddULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left + (BigInteger)right), 
                                (BigInteger)(left + right));
            }
        }

        [Test]
        public static void SubtractULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left - (BigInteger)right), 
                                (BigInteger)(left - right));
            }
        }

        [Test]
        public static void MultiplyULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();
                
                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }
        }

        [Test]
        public static void DivideULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();
                right = right != 0 ? right : 1;

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left / (BigInteger)right), 
                                (BigInteger)(left / right));
            }
        }

        [Test]
        public static void ModuloULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();
                right = right != 0 ? right : 1;

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left % (BigInteger)right), 
                                (BigInteger)(left % right));
            }
        }

        [Test]
        public static void EqualULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();

                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                left = right;
                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                Assert.AreEqual((ulong)0 == left, ((BigInteger)0 == (BigInteger)left));
                Assert.AreEqual(left == (ulong)0, ((BigInteger)left == (BigInteger)0));
            }
        }

        [Test]
        public static void NotEqualULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();

                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                left = right;
                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                Assert.AreEqual((ulong)0 != left, ((BigInteger)0 != (BigInteger)left));
                Assert.AreEqual(left != (ulong)0, ((BigInteger)left != (BigInteger)0));
            }
        }

        [Test]
        public static void LessULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();

                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                left = right;
                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                Assert.AreEqual((ulong)0 < left, ((BigInteger)0 < (BigInteger)left));
                Assert.AreEqual(left < (ulong)0, ((BigInteger)left < (BigInteger)0));
            }
        }

        [Test]
        public static void GreaterULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();

                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                left = right;
                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                Assert.AreEqual((ulong)0 > left, ((BigInteger)0 > (BigInteger)left));
                Assert.AreEqual(left > (ulong)0, ((BigInteger)left > (BigInteger)0));
            }
        }

        [Test]
        public static void LessEqualULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();

                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                left = right;
                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                Assert.AreEqual((ulong)0 <= left, ((BigInteger)0 <= (BigInteger)left));
                Assert.AreEqual(left <= (ulong)0, ((BigInteger)left <= (BigInteger)0));
            }
        }

        [Test]
        public static void GreaterEqualULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                ulong right = (ulong)rng.NextUInt128();

                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                left = right;
                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));
                
                Assert.AreEqual((ulong)0 >= left, ((BigInteger)0 >= (BigInteger)left));
                Assert.AreEqual(left >= (ulong)0, ((BigInteger)left >= (BigInteger)0));
            }
        }

        [Test]
        public static void AddUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left + (BigInteger)right), 
                                (BigInteger)(left + right));
            }
        }

        [Test]
        public static void SubtractUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left - (BigInteger)right), 
                                (BigInteger)(left - right));
            }
        }

        [Test]
        public static void MultiplyUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();
                
                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }
        }

        [Test]
        public static void DivideUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();
                right = right != 0 ? right : 1;

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left / (BigInteger)right), 
                                (BigInteger)(left / right));
            }
        }

        [Test]
        public static void ModuloUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();
                right = right != 0 ? right : 1;

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left % (BigInteger)right), 
                                (BigInteger)(left % right));
            }
        }

       [Test]
        public static void EqualUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();

                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                left = right;
                Assert.AreEqual(left == right, ((BigInteger)left == (BigInteger)right));

                Assert.AreEqual((uint)0 == left, ((BigInteger)0 == (BigInteger)left));
                Assert.AreEqual(left == (uint)0, ((BigInteger)left == (BigInteger)0));
            }
        }

        [Test]
        public static void NotEqualUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();

                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                left = right;
                Assert.AreEqual(left != right, ((BigInteger)left != (BigInteger)right));

                Assert.AreEqual((uint)0 != left, ((BigInteger)0 != (BigInteger)left));
                Assert.AreEqual(left != (uint)0, ((BigInteger)left != (BigInteger)0));
            }
        }

        [Test]
        public static void LessUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();

                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                left = right;
                Assert.AreEqual(left < right, ((BigInteger)left < (BigInteger)right));

                Assert.AreEqual((uint)0 < left, ((BigInteger)0 < (BigInteger)left));
                Assert.AreEqual(left < (uint)0, ((BigInteger)left < (BigInteger)0));
            }
        }

        [Test]
        public static void GreaterUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();

                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                left = right;
                Assert.AreEqual(left > right, ((BigInteger)left > (BigInteger)right));

                Assert.AreEqual((uint)0 > left, ((BigInteger)0 > (BigInteger)left));
                Assert.AreEqual(left > (uint)0, ((BigInteger)left > (BigInteger)0));
            }
        }

        [Test]
        public static void LessEqualUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();

                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                left = right;
                Assert.AreEqual(left <= right, ((BigInteger)left <= (BigInteger)right));

                Assert.AreEqual((uint)0 <= left, ((BigInteger)0 <= (BigInteger)left));
                Assert.AreEqual(left <= (uint)0, ((BigInteger)left <= (BigInteger)0));
            }
        }

        [Test]
        public static void GreaterEqualUInt()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                uint right = (uint)rng.NextUInt128();

                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));

                left = right;
                Assert.AreEqual(left >= right, ((BigInteger)left >= (BigInteger)right));
                
                Assert.AreEqual((uint)0 >= left, ((BigInteger)0 >= (BigInteger)left));
                Assert.AreEqual(left >= (uint)0, ((BigInteger)left >= (BigInteger)0));
            }
        }


        [Test]
        public static void ShiftLeft()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();

                Assert.AreEqual(left << 0, left);
                Assert.AreEqual(left << 128, left);

                for (int j = 1;j < 128;j++)
                {
                    Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left << j), 
                                    (BigInteger)(left << j));
                }
            }
        }

        [Test]
        public static void ShiftRight()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();

                Assert.AreEqual(left >> 0, left);
                Assert.AreEqual(left >> 128, left);

                for (int j = 1;j < 128;j++)
                {
                    Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left >> j), 
                                    (BigInteger)(left >> j));
                }
            }
        }


        [Test]
        public static void MulHi()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                UInt128 lo = Operator.umul256(left, right, out UInt128 hi);

                Assert.AreEqual((BigInteger)left * (BigInteger)right, 
                                (BigInteger)lo | ((BigInteger)hi << 128));
            }
        }


        [Test]
        public static void CONST_MultiplyULong()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong left  = (ulong)rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                right = new UInt128(right.lo, 0);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong left  = (ulong)rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                right = new UInt128(right.lo, ulong.MaxValue);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }
        }

        [Test]
        public static void CONST1_MultiplyUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                left = new UInt128(left.lo, 0);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                left = new UInt128(left.lo, ulong.MaxValue);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }
        }

        [Test]
        public static void CONST2_MultiplyUInt128()
        {
            Random128 rng = RNG128;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                left = new UInt128(left.lo, 0);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                left = new UInt128(left.lo, ulong.MaxValue);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                left = new UInt128(left.lo, 0);
                right = new UInt128(right.lo, 0);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                left = new UInt128(left.lo, 0);
                right = new UInt128(right.lo, ulong.MaxValue);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                left = new UInt128(left.lo, ulong.MaxValue);
                right = new UInt128(right.lo, 0);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                left = new UInt128(left.lo, ulong.MaxValue);
                right = new UInt128(right.lo, ulong.MaxValue);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                right = new UInt128(right.lo, 0);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 left  = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                
                right = new UInt128(right.lo, ulong.MaxValue);

                Assert.AreEqual((BigInteger)UInt128.MaxValue & ((BigInteger)left * (BigInteger)right), 
                                (BigInteger)(left * right));
            }
        }
    }
}
