using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class compareto
    {
        [Test]
        public static void Int()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int8.NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result &= maxmath.compareto(Tests.__int8.TestData_LHS[i][j], Tests.__int8.TestData_RHS[i][j]) 
                              ==
                              Tests.__int8.TestData_LHS[i][j].CompareTo(Tests.__int8.TestData_RHS[i][j]);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UInt()
        {
            bool result = true;

            for (int i = 0; i < Tests.__uint8.NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result &= maxmath.compareto(Tests.__uint8.TestData_LHS[i][j], Tests.__uint8.TestData_RHS[i][j])
                              ==
                              Tests.__uint8.TestData_LHS[i][j].CompareTo(Tests.__uint8.TestData_RHS[i][j]);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long4.NUM_TESTS; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result &= maxmath.compareto(Tests.__long4.TestData_LHS[i][j], Tests.__long4.TestData_RHS[i][j])
                              ==
                              Tests.__long4.TestData_LHS[i][j].CompareTo(Tests.__long4.TestData_RHS[i][j]);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ulong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result &= maxmath.compareto(Tests.__ulong4.TestData_LHS[i][j], Tests.__ulong4.TestData_RHS[i][j])
                              ==
                              Tests.__ulong4.TestData_LHS[i][j].CompareTo(Tests.__ulong4.TestData_RHS[i][j]);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int128()
        {
            Random128 rng = new Random128("3941235716937519735");

            for (int i = 0; i < Tests.__ulong4.NUM_TESTS; i++)
            {
                Int128 left = rng.NextInt128();
                Int128 right = rng.NextInt128();

                if (left < right)
                {
                    Assert.AreEqual(-1, maxmath.compareto(left, right));
                }
                else if (left > right)
                {
                    Assert.AreEqual(1, maxmath.compareto(left, right));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right));
            }
        }

        [Test]
        public static void UInt128()
        {
            Random128 rng = new Random128("3941235716937519735");

            for (int i = 0; i < Tests.__ulong4.NUM_TESTS; i++)
            {
                UInt128 left = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();

                if (left < right)
                {
                    Assert.AreEqual(-1, maxmath.compareto(left, right));
                }
                else if (left > right)
                {
                    Assert.AreEqual(1, maxmath.compareto(left, right));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right));
            }
        }

        [Test]
        public static void Float()
        {
            bool result = true;

            for (int i = 0; i < Tests.__float4.NUM_TESTS; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result &= maxmath.compareto(Tests.__float4.TestData_LHS[i][j], Tests.__float4.TestData_RHS[i][j])
                              ==
                              Tests.__float4.TestData_LHS[i][j].CompareTo(Tests.__float4.TestData_RHS[i][j]);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Double()
        {
            bool result = true;

            for (int i = 0; i < Tests.__double4.NUM_TESTS; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result &= maxmath.compareto(Tests.__double4.TestData_LHS[i][j], Tests.__double4.TestData_RHS[i][j])
                              ==
                              Tests.__double4.TestData_LHS[i][j].CompareTo(Tests.__double4.TestData_RHS[i][j]);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Byte2()
        {
            Random8 rng = new Random8(123);

            for (int i = 0; i < 16; i++)
            {
                byte2 left = rng.NextByte2();
                byte2 right = rng.NextByte2();

                sbyte2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Byte3()
        {
            Random8 rng = new Random8(133);

            for (int i = 0; i < 16; i++)
            {
                byte3 left = rng.NextByte3();
                byte3 right = rng.NextByte3();

                sbyte3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Byte4()
        {
            Random8 rng = new Random8(143);

            for (int i = 0; i < 16; i++)
            {
                byte4 left = rng.NextByte4();
                byte4 right = rng.NextByte4();

                sbyte4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Byte8()
        {
            Random8 rng = new Random8(183);

            for (int i = 0; i < 16; i++)
            {
                byte8 left = rng.NextByte8();
                byte8 right = rng.NextByte8();

                sbyte8 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 8;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }

        [Test]
        public static void Byte16()
        {
            Random8 rng = new Random8(113);

            for (int i = 0; i < 16; i++)
            {
                byte16 left = rng.NextByte16();
                byte16 right = rng.NextByte16();

                sbyte16 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 16;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }

        [Test]
        public static void Byte32()
        {
            Random8 rng = new Random8(132);

            for (int i = 0; i < 16; i++)
            {
                byte32 left = rng.NextByte32();
                byte32 right = rng.NextByte32();

                sbyte32 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 32;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }


        [Test]
        public static void SByte2()
        {
            Random8 rng = new Random8(122);

            for (int i = 0; i < 16; i++)
            {
                sbyte2 left = rng.NextSByte2();
                sbyte2 right = rng.NextSByte2();

                sbyte2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void SByte3()
        {
            Random8 rng = new Random8(133);

            for (int i = 0; i < 16; i++)
            {
                sbyte3 left = rng.NextSByte3();
                sbyte3 right = rng.NextSByte3();

                sbyte3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void SByte4()
        {
            Random8 rng = new Random8(143);

            for (int i = 0; i < 16; i++)
            {
                sbyte4 left = rng.NextSByte4();
                sbyte4 right = rng.NextSByte4();

                sbyte4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void SByte8()
        {
            Random8 rng = new Random8(183);

            for (int i = 0; i < 16; i++)
            {
                sbyte8 left = rng.NextSByte8();
                sbyte8 right = rng.NextSByte8();

                sbyte8 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 8;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }

        [Test]
        public static void SByte16()
        {
            Random8 rng = new Random8(113);

            for (int i = 0; i < 16; i++)
            {
                sbyte16 left = rng.NextSByte16();
                sbyte16 right = rng.NextSByte16();

                sbyte16 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 16;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }

        [Test]
        public static void SByte32()
        {
            Random8 rng = new Random8(132);

            for (int i = 0; i < 16; i++)
            {
                sbyte32 left = rng.NextSByte32();
                sbyte32 right = rng.NextSByte32();

                sbyte32 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 32;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }


        [Test]
        public static void UShort2()
        {
            Random16 rng = new Random16(123);

            for (int i = 0; i < 16; i++)
            {
                ushort2 left = rng.NextUShort2();
                ushort2 right = rng.NextUShort2();

                short2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void UShort3()
        {
            Random16 rng = new Random16(133);

            for (int i = 0; i < 16; i++)
            {
                ushort3 left = rng.NextUShort3();
                ushort3 right = rng.NextUShort3();

                short3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void UShort4()
        {
            Random16 rng = new Random16(143);

            for (int i = 0; i < 16; i++)
            {
                ushort4 left = rng.NextUShort4();
                ushort4 right = rng.NextUShort4();

                short4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void UShort8()
        {
            Random16 rng = new Random16(183);

            for (int i = 0; i < 16; i++)
            {
                ushort8 left = rng.NextUShort8();
                ushort8 right = rng.NextUShort8();

                short8 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 8;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }

        [Test]
        public static void UShort16()
        {
            Random16 rng = new Random16(113);

            for (int i = 0; i < 16; i++)
            {
                ushort16 left = rng.NextUShort16();
                ushort16 right = rng.NextUShort16();

                short16 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 16;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }


        [Test]
        public static void Short2()
        {
            Random16 rng = new Random16(123);

            for (int i = 0; i < 16; i++)
            {
                short2 left = rng.NextShort2();
                short2 right = rng.NextShort2();

                short2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Short3()
        {
            Random16 rng = new Random16(133);

            for (int i = 0; i < 16; i++)
            {
                short3 left = rng.NextShort3();
                short3 right = rng.NextShort3();

                short3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Short4()
        {
            Random16 rng = new Random16(143);

            for (int i = 0; i < 16; i++)
            {
                short4 left = rng.NextShort4();
                short4 right = rng.NextShort4();

                short4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Short8()
        {
            Random16 rng = new Random16(183);

            for (int i = 0; i < 16; i++)
            {
                short8 left = rng.NextShort8();
                short8 right = rng.NextShort8();

                short8 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 8;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }

        [Test]
        public static void Short16()
        {
            Random16 rng = new Random16(113);

            for (int i = 0; i < 16; i++)
            {
                short16 left = rng.NextShort16();
                short16 right = rng.NextShort16();

                short16 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 16;k++)
                {
                    Assert.AreEqual((int)cmp[k], ((int)left[k]).CompareTo((int)right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }


        [Test]
        public static void UInt2()
        {
            Random32 rng = new Random32(123);

            for (int i = 0; i < 16; i++)
            {
                uint2 left = rng.NextUInt2();
                uint2 right = rng.NextUInt2();

                int2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void UInt3()
        {
            Random32 rng = new Random32(133);

            for (int i = 0; i < 16; i++)
            {
                uint3 left = rng.NextUInt3();
                uint3 right = rng.NextUInt3();

                int3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void UInt4()
        {
            Random32 rng = new Random32(143);

            for (int i = 0; i < 16; i++)
            {
                uint4 left = rng.NextUInt4();
                uint4 right = rng.NextUInt4();

                int4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void UInt8()
        {
            Random32 rng = new Random32(183);

            for (int i = 0; i < 16; i++)
            {
                uint8 left = rng.NextUInt8();
                uint8 right = rng.NextUInt8();

                int8 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 8;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }


        [Test]
        public static void Int2()
        {
            Random32 rng = new Random32(123);

            for (int i = 0; i < 16; i++)
            {
                int2 left = rng.NextInt2();
                int2 right = rng.NextInt2();

                int2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Int3()
        {
            Random32 rng = new Random32(133);

            for (int i = 0; i < 16; i++)
            {
                int3 left = rng.NextInt3();
                int3 right = rng.NextInt3();

                int3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Int4()
        {
            Random32 rng = new Random32(143);

            for (int i = 0; i < 16; i++)
            {
                int4 left = rng.NextInt4();
                int4 right = rng.NextInt4();

                int4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Int8()
        {
            Random32 rng = new Random32(183);

            for (int i = 0; i < 16; i++)
            {
                int8 left = rng.NextInt8();
                int8 right = rng.NextInt8();

                int8 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 8;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }


        [Test]
        public static void ULong2()
        {
            Random64 rng = new Random64(123);

            for (int i = 0; i < 16; i++)
            {
                ulong2 left = rng.NextULong2();
                ulong2 right = rng.NextULong2();

                long2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void ULong3()
        {
            Random64 rng = new Random64(133);

            for (int i = 0; i < 16; i++)
            {
                ulong3 left = rng.NextULong3();
                ulong3 right = rng.NextULong3();

                long3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void ULong4()
        {
            Random64 rng = new Random64(143);

            for (int i = 0; i < 16; i++)
            {
                ulong4 left = rng.NextULong4();
                ulong4 right = rng.NextULong4();

                long4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }


        [Test]
        public static void Long2()
        {
            Random64 rng = new Random64(123);

            for (int i = 0; i < 16; i++)
            {
                long2 left = rng.NextLong2();
                long2 right = rng.NextLong2();

                long2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Long3()
        {
            Random64 rng = new Random64(133);

            for (int i = 0; i < 16; i++)
            {
                long3 left = rng.NextLong3();
                long3 right = rng.NextLong3();

                long3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Long4()
        {
            Random64 rng = new Random64(143);

            for (int i = 0; i < 16; i++)
            {
                long4 left = rng.NextLong4();
                long4 right = rng.NextLong4();

                long4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }


        [Test]
        public static void Float2()
        {
            Random32 rng = new Random32(123);

            for (int i = 0; i < 16; i++)
            {
                float2 left = rng.NextFloat2();
                float2 right = rng.NextFloat2();

                int2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Float3()
        {
            Random32 rng = new Random32(133);

            for (int i = 0; i < 16; i++)
            {
                float3 left = rng.NextFloat3();
                float3 right = rng.NextFloat3();

                int3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Float4()
        {
            Random32 rng = new Random32(143);

            for (int i = 0; i < 16; i++)
            {
                float4 left = rng.NextFloat4();
                float4 right = rng.NextFloat4();

                int4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Float8()
        {
            Random32 rng = new Random32(183);

            for (int i = 0; i < 16; i++)
            {
                float8 left = rng.NextFloat8();
                float8 right = rng.NextFloat8();

                int8 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 8;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x0);
            }
        }


        [Test]
        public static void Double2()
        {
            Random64 rng = new Random64(123);

            for (int i = 0; i < 16; i++)
            {
                double2 left = rng.NextDouble2();
                double2 right = rng.NextDouble2();

                long2 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 2;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Double3()
        {
            Random64 rng = new Random64(133);

            for (int i = 0; i < 16; i++)
            {
                double3 left = rng.NextDouble3();
                double3 right = rng.NextDouble3();

                long3 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 3;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }

        [Test]
        public static void Double4()
        {
            Random64 rng = new Random64(143);

            for (int i = 0; i < 16; i++)
            {
                double4 left = rng.NextDouble4();
                double4 right = rng.NextDouble4();

                long4 cmp = maxmath.compareto(left, right);

                for (int k = 0;k < 4;k++)
                {
                    Assert.AreEqual((int)cmp[k], left[k].CompareTo(right[k]));
                }

                left = right;

                Assert.AreEqual(0, maxmath.compareto(left, right).x);
            }
        }
    }
}