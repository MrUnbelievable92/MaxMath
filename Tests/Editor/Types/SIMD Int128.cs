using Unity.Burst.Intrinsics;
using NUnit.Framework;
using MaxMath.Intrinsics;

using static MaxMath.maxmath;
using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Tests
{
    internal class SIMD_Int128
    {
        [Test]
        public static void neg_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    Int128 test0 = rng128.NextInt128();
                    Int128 test1 = rng128.NextInt128();

                    v128 testvLo = new v128(test0.lo64, test1.lo64);
                    v128 testvHi = new v128(test0.hi64, test1.hi64);
                    Xse.neg_epi128(testvLo, testvHi, out v128 rLo, out v128 rHi);

                    Assert.AreEqual(-test0, new Int128(rLo.ULong0, rHi.ULong0));
                    Assert.AreEqual(-test1, new Int128(rLo.ULong1, rHi.ULong1));
                }
            }
        }

        [Test]
        public static void neg_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    Int128 test0 = rng128.NextInt128();
                    Int128 test1 = rng128.NextInt128();
                    Int128 test2 = rng128.NextInt128();
                    Int128 test3 = rng128.NextInt128();

                    v256 testvLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testvHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    Xse.mm256_neg_epi128(testvLo, testvHi, out v256 rLo, out v256 rHi);

                    Assert.AreEqual(-test0, new Int128(rLo.ULong0, rHi.ULong0));
                    Assert.AreEqual(-test1, new Int128(rLo.ULong1, rHi.ULong1));
                    Assert.AreEqual(-test2, new Int128(rLo.ULong2, rHi.ULong2));
                    Assert.AreEqual(-test3, new Int128(rLo.ULong3, rHi.ULong3));
                }
            }
        }

        [Test]
        public static void sub_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 testbLo = new v128(test2.lo64, test3.lo64);
                    v128 testbHi = new v128(test2.hi64, test3.hi64);
                    Xse.sub_epi128(testaLo, testaHi, testbLo, testbHi, out v128 r0, out v128 r1);

                    Assert.AreEqual(new UInt128(r0.ULong0, r1.ULong0), test0 - test2);
                    Assert.AreEqual(new UInt128(r0.ULong1, r1.ULong1), test1 - test3);
                }
            }
        }

        [Test]
        public static void sub_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128();
                    UInt128 test5 = rng128.NextUInt128();
                    UInt128 test6 = rng128.NextUInt128();
                    UInt128 test7 = rng128.NextUInt128();

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 testbLo = new v256(test4.lo64, test5.lo64, test6.lo64, test7.lo64);
                    v256 testbHi = new v256(test4.hi64, test5.hi64, test6.hi64, test7.hi64);
                    Xse.mm256_sub_epi128(testaLo, testaHi, testbLo, testbHi, out v256 r0, out v256 r1);

                    Assert.AreEqual(new UInt128(r0.ULong0, r1.ULong0), test0 - test4);
                    Assert.AreEqual(new UInt128(r0.ULong1, r1.ULong1), test1 - test5);
                    Assert.AreEqual(new UInt128(r0.ULong2, r1.ULong2), test2 - test6);
                    Assert.AreEqual(new UInt128(r0.ULong3, r1.ULong3), test3 - test7);
                }
            }
        }

        [Test]
        public static void add_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 testbLo = new v128(test2.lo64, test3.lo64);
                    v128 testbHi = new v128(test2.hi64, test3.hi64);
                    Xse.add_epi128(testaLo, testaHi, testbLo, testbHi, out v128 r0, out v128 r1);

                    Assert.AreEqual(new UInt128(r0.ULong0, r1.ULong0), test0 + test2);
                    Assert.AreEqual(new UInt128(r0.ULong1, r1.ULong1), test1 + test3);
                }
            }
        }

        [Test]
        public static void add_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128();
                    UInt128 test5 = rng128.NextUInt128();
                    UInt128 test6 = rng128.NextUInt128();
                    UInt128 test7 = rng128.NextUInt128();

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 testbLo = new v256(test4.lo64, test5.lo64, test6.lo64, test7.lo64);
                    v256 testbHi = new v256(test4.hi64, test5.hi64, test6.hi64, test7.hi64);
                    Xse.mm256_add_epi128(testaLo, testaHi, testbLo, testbHi, out v256 r0, out v256 r1);

                    Assert.AreEqual(new UInt128(r0.ULong0, r1.ULong0), test0 + test4);
                    Assert.AreEqual(new UInt128(r0.ULong1, r1.ULong1), test1 + test5);
                    Assert.AreEqual(new UInt128(r0.ULong2, r1.ULong2), test2 + test6);
                    Assert.AreEqual(new UInt128(r0.ULong3, r1.ULong3), test3 + test7);
                }
            }
        }

        [Test]
        public static void divrem64_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    ulong test2 = rng128.NextUInt128(1, (UInt128)ulong.MaxValue + 1).lo64;
                    ulong test3 = rng128.NextUInt128(1, (UInt128)ulong.MaxValue + 1).lo64;

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 testb = new v128(test2, test3);
                    Xse.divremepu128_epu64(testaLo, testaHi, testb, out v128 r0, out v128 r1, out v128 rem0);

                    Assert.AreEqual(new UInt128(r0.ULong0, r1.ULong0), test0 / test2);
                    Assert.AreEqual(new UInt128(r0.ULong1, r1.ULong1), test1 / test3);
                    Assert.AreEqual((UInt128)rem0.ULong0, test0 % test2);
                    Assert.AreEqual((UInt128)rem0.ULong1, test1 % test3);
                }
            }
        }

        [Test]
        public static void divrem64_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    ulong test4 = rng128.NextUInt128(1, (UInt128)ulong.MaxValue + 1).lo64;
                    ulong test5 = rng128.NextUInt128(1, (UInt128)ulong.MaxValue + 1).lo64;
                    ulong test6 = rng128.NextUInt128(1, (UInt128)ulong.MaxValue + 1).lo64;
                    ulong test7 = rng128.NextUInt128(1, (UInt128)ulong.MaxValue + 1).lo64;

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 testb = new v256(test4, test5, test6, test7);
                    Xse.mm256_divremepu128_epu64(testaLo, testaHi, testb, out v256 r0, out v256 r1, out v256 rem0);

                    Assert.AreEqual(new UInt128(r0.ULong0, r1.ULong0), test0 / test4);
                    Assert.AreEqual(new UInt128(r0.ULong1, r1.ULong1), test1 / test5);
                    Assert.AreEqual(new UInt128(r0.ULong2, r1.ULong2), test2 / test6);
                    Assert.AreEqual(new UInt128(r0.ULong3, r1.ULong3), test3 / test7);
                    Assert.AreEqual((UInt128)rem0.ULong0, test0 % test4);
                    Assert.AreEqual((UInt128)rem0.ULong1, test1 % test5);
                    Assert.AreEqual((UInt128)rem0.ULong2, test2 % test6);
                    Assert.AreEqual((UInt128)rem0.ULong3, test3 % test7);
                }
            }
        }

        [Test]
        public static void cmpgt128ux64u_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 testbLo = new v128(test2.lo64, test3.lo64);
                    v128 result = Xse.cmpgt_epu128xepu64(testaLo, testaHi, testbLo);

                    Assert.AreEqual(test0 > test2.lo64, result.ULong0 != 0);
                    Assert.AreEqual(test1 > test3.lo64, result.ULong1 != 0);
                }
            }
        }

        [Test]
        public static void cmpgt128ux64u_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128();
                    UInt128 test5 = rng128.NextUInt128();
                    UInt128 test6 = rng128.NextUInt128();
                    UInt128 test7 = rng128.NextUInt128();

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 testbLo = new v256(test4.lo64, test5.lo64, test6.lo64, test7.lo64);
                    v256 result = Xse.mm256_cmpgt_epu128xepu64(testaLo, testaHi, testbLo);

                    Assert.AreEqual(test0 > test4.lo64, result.ULong0 != 0);
                    Assert.AreEqual(test1 > test5.lo64, result.ULong1 != 0);
                    Assert.AreEqual(test2 > test6.lo64, result.ULong2 != 0);
                    Assert.AreEqual(test3 > test7.lo64, result.ULong3 != 0);
                }
            }
        }

        [Test]
        public static void cmpgt64ux28u_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 testbLo = new v128(test2.lo64, test3.lo64);
                    v128 result = Xse.cmpgt_epu64xepu128(testbLo, testaLo, testaHi);

                    Assert.AreEqual(test2.lo64 > test0, result.ULong0 != 0);
                    Assert.AreEqual(test3.lo64 > test1, result.ULong1 != 0);
                }
            }
        }

        [Test]
        public static void cmpgt64ux128u_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128();
                    UInt128 test5 = rng128.NextUInt128();
                    UInt128 test6 = rng128.NextUInt128();
                    UInt128 test7 = rng128.NextUInt128();

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 testbLo = new v256(test4.lo64, test5.lo64, test6.lo64, test7.lo64);
                    v256 result = Xse.mm256_cmpgt_epu64xepu128(testbLo, testaLo, testaHi);

                    Assert.AreEqual(test4.lo64 > test0, result.ULong0 != 0);
                    Assert.AreEqual(test5.lo64 > test1, result.ULong1 != 0);
                    Assert.AreEqual(test6.lo64 > test2, result.ULong2 != 0);
                    Assert.AreEqual(test7.lo64 > test3, result.ULong3 != 0);
                }
            }
        }

        [Test]
        public static void cmpgtu_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 testbLo = new v128(test2.lo64, test3.lo64);
                    v128 testbHi = new v128(test2.hi64, test3.hi64);
                    v128 result = Xse.cmpgt_epu128(testaLo, testaHi, testbLo, testbHi);

                    Assert.AreEqual(test0 > test2, result.ULong0 != 0);
                    Assert.AreEqual(test1 > test3, result.ULong1 != 0);
                }
            }
        }

        [Test]
        public static void cmpgtu_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128();
                    UInt128 test5 = rng128.NextUInt128();
                    UInt128 test6 = rng128.NextUInt128();
                    UInt128 test7 = rng128.NextUInt128();

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 testbLo = new v256(test4.lo64, test5.lo64, test6.lo64, test7.lo64);
                    v256 testbHi = new v256(test4.hi64, test5.hi64, test6.hi64, test7.hi64);
                    v256 result = Xse.mm256_cmpgt_epu128(testaLo, testaHi, testbLo, testbHi);

                    Assert.AreEqual(test0 > test4, result.ULong0 != 0);
                    Assert.AreEqual(test1 > test5, result.ULong1 != 0);
                    Assert.AreEqual(test2 > test6, result.ULong2 != 0);
                    Assert.AreEqual(test3 > test7, result.ULong3 != 0);
                }
            }
        }

        [Test]
        public static void cmpgti_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    Int128 test0 = rng128.NextInt128();
                    Int128 test1 = rng128.NextInt128();
                    Int128 test2 = rng128.NextInt128();
                    Int128 test3 = rng128.NextInt128();

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 testbLo = new v128(test2.lo64, test3.lo64);
                    v128 testbHi = new v128(test2.hi64, test3.hi64);
                    v128 result = Xse.cmpgt_epi128(testaLo, testaHi, testbLo, testbHi);

                    Assert.AreEqual(test0 > test2, result.ULong0 != 0);
                    Assert.AreEqual(test1 > test3, result.ULong1 != 0);
                }
            }
        }

        [Test]
        public static void cmpgti_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    Int128 test0 = rng128.NextInt128();
                    Int128 test1 = rng128.NextInt128();
                    Int128 test2 = rng128.NextInt128();
                    Int128 test3 = rng128.NextInt128();
                    Int128 test4 = rng128.NextInt128();
                    Int128 test5 = rng128.NextInt128();
                    Int128 test6 = rng128.NextInt128();
                    Int128 test7 = rng128.NextInt128();

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 testbLo = new v256(test4.lo64, test5.lo64, test6.lo64, test7.lo64);
                    v256 testbHi = new v256(test4.hi64, test5.hi64, test6.hi64, test7.hi64);
                    v256 result = Xse.mm256_cmpgt_epi128(testaLo, testaHi, testbLo, testbHi);

                    Assert.AreEqual(test0 > test4, result.ULong0 != 0);
                    Assert.AreEqual(test1 > test5, result.ULong1 != 0);
                    Assert.AreEqual(test2 > test6, result.ULong2 != 0);
                    Assert.AreEqual(test3 > test7, result.ULong3 != 0);
                }
            }
        }

        [Test]
        public static void slli_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128(0, 128);

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    Xse.slli_epi128(testaLo, testaHi, (int)test2.lo64, out v128 shiftLo, out v128 shiftHi);

                    Assert.AreEqual(test0 << (int)test2.lo64, new UInt128(shiftLo.ULong0, shiftHi.ULong0));
                    Assert.AreEqual(test1 << (int)test2.lo64, new UInt128(shiftLo.ULong1, shiftHi.ULong1));
                }
            }
        }

        [Test]
        public static void square_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    Xse.square_epi128(testaLo, testaHi, out v128 squareLo, out v128 squareHi);

                    Assert.AreEqual(square(test0), new UInt128(squareLo.ULong0, squareHi.ULong0));
                    Assert.AreEqual(square(test1), new UInt128(squareLo.ULong1, squareHi.ULong1));
                }
            }
        }

        [Test]
        public static void square_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    Xse.mm256_square_epi128(testaLo, testaHi, out v256 squareLo, out v256 squareHi);

                    Assert.AreEqual(square(test0), new UInt128(squareLo.ULong0, squareHi.ULong0));
                    Assert.AreEqual(square(test1), new UInt128(squareLo.ULong1, squareHi.ULong1));
                    Assert.AreEqual(square(test2), new UInt128(squareLo.ULong2, squareHi.ULong2));
                    Assert.AreEqual(square(test3), new UInt128(squareLo.ULong3, squareHi.ULong3));
                }
            }
        }

        [Test]
        public static void slli_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128(0, 128);

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    Xse.mm256_slli_epi128(testaLo, testaHi, (int)test4.lo64, out v256 shiftLo, out v256 shiftHi);

                    Assert.AreEqual(test0 << (int)test4.lo64, new UInt128(shiftLo.ULong0, shiftHi.ULong0));
                    Assert.AreEqual(test1 << (int)test4.lo64, new UInt128(shiftLo.ULong1, shiftHi.ULong1));
                    Assert.AreEqual(test2 << (int)test4.lo64, new UInt128(shiftLo.ULong2, shiftHi.ULong2));
                    Assert.AreEqual(test3 << (int)test4.lo64, new UInt128(shiftLo.ULong3, shiftHi.ULong3));
                }
            }
        }

        [Test]
        public static void sllv_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128(0, 128);
                    UInt128 test3 = rng128.NextUInt128(0, 128);

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 shift = new v128(test2.lo64, test3.lo64);
                    Xse.sllv_epi128(testaLo, testaHi, shift, out v128 shiftLo, out v128 shiftHi);

                    Assert.AreEqual(test0 << (int)test2.lo64, new UInt128(shiftLo.ULong0, shiftHi.ULong0));
                    Assert.AreEqual(test1 << (int)test3.lo64, new UInt128(shiftLo.ULong1, shiftHi.ULong1));
                }
            }
        }

        [Test]
        public static void sllv_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128(0, 128);
                    UInt128 test5 = rng128.NextUInt128(0, 128);
                    UInt128 test6 = rng128.NextUInt128(0, 128);
                    UInt128 test7 = rng128.NextUInt128(0, 128);

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 shift = new v256(test4.lo64, test5.lo64, test6.lo64, test7.lo64);
                    Xse.mm256_sllv_epi128(testaLo, testaHi, shift, out v256 shiftLo, out v256 shiftHi);

                    Assert.AreEqual(test0 << (int)test4.lo64, new UInt128(shiftLo.ULong0, shiftHi.ULong0));
                    Assert.AreEqual(test1 << (int)test5.lo64, new UInt128(shiftLo.ULong1, shiftHi.ULong1));
                    Assert.AreEqual(test2 << (int)test6.lo64, new UInt128(shiftLo.ULong2, shiftHi.ULong2));
                    Assert.AreEqual(test3 << (int)test7.lo64, new UInt128(shiftLo.ULong3, shiftHi.ULong3));
                }
            }
        }

        [Test]
        public static void srli_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128(0, 128);

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    Xse.srli_epi128(testaLo, testaHi, (int)test2.lo64, out v128 shiftLo, out v128 shiftHi);

                    Assert.AreEqual(test0 >> (int)test2.lo64, new UInt128(shiftLo.ULong0, shiftHi.ULong0));
                    Assert.AreEqual(test1 >> (int)test2.lo64, new UInt128(shiftLo.ULong1, shiftHi.ULong1));
                }
            }
        }

        [Test]
        public static void srli_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128(0, 128);

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    Xse.mm256_srli_epi128(testaLo, testaHi, (int)test4.lo64, out v256 shiftLo, out v256 shiftHi);

                    Assert.AreEqual(test0 >> (int)test4.lo64, new UInt128(shiftLo.ULong0, shiftHi.ULong0));
                    Assert.AreEqual(test1 >> (int)test4.lo64, new UInt128(shiftLo.ULong1, shiftHi.ULong1));
                    Assert.AreEqual(test2 >> (int)test4.lo64, new UInt128(shiftLo.ULong2, shiftHi.ULong2));
                    Assert.AreEqual(test3 >> (int)test4.lo64, new UInt128(shiftLo.ULong3, shiftHi.ULong3));
                }
            }
        }

        [Test]
        public static void srlv_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128(0, 128);
                    UInt128 test3 = rng128.NextUInt128(0, 128);

                    v128 testaLo = new v128(test0.lo64, test1.lo64);
                    v128 testaHi = new v128(test0.hi64, test1.hi64);
                    v128 shift = new v128(test2.lo64, test3.lo64);
                    Xse.srlv_epi128(testaLo, testaHi, shift, out v128 shiftLo, out v128 shiftHi);

                    Assert.AreEqual(test0 >> (int)test2.lo64, new UInt128(shiftLo.ULong0, shiftHi.ULong0));
                    Assert.AreEqual(test1 >> (int)test3.lo64, new UInt128(shiftLo.ULong1, shiftHi.ULong1));
                }
            }
        }

        [Test]
        public static void srlv_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();
                    UInt128 test4 = rng128.NextUInt128(0, 128);
                    UInt128 test5 = rng128.NextUInt128(0, 128);
                    UInt128 test6 = rng128.NextUInt128(0, 128);
                    UInt128 test7 = rng128.NextUInt128(0, 128);

                    v256 testaLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testaHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 shift = new v256(test4.lo64, test5.lo64, test6.lo64, test7.lo64);
                    Xse.mm256_srlv_epi128(testaLo, testaHi, shift, out v256 shiftLo, out v256 shiftHi);

                    Assert.AreEqual(test0 >> (int)test4.lo64, new UInt128(shiftLo.ULong0, shiftHi.ULong0));
                    Assert.AreEqual(test1 >> (int)test5.lo64, new UInt128(shiftLo.ULong1, shiftHi.ULong1));
                    Assert.AreEqual(test2 >> (int)test6.lo64, new UInt128(shiftLo.ULong2, shiftHi.ULong2));
                    Assert.AreEqual(test3 >> (int)test7.lo64, new UInt128(shiftLo.ULong3, shiftHi.ULong3));
                }
            }
        }

        [Test]
        public static void lzcnt_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();

                    v128 testvLo = new v128(test0.lo64, test1.lo64);
                    v128 testvHi = new v128(test0.hi64, test1.hi64);
                    v128 result = Xse.lzcnt_epi128(testvLo, testvHi);

                    Assert.AreEqual((ulong)lzcnt(test0), result.ULong0);
                    Assert.AreEqual((ulong)lzcnt(test1), result.ULong1);
                }
            }
        }

        [Test]
        public static void lzcnt_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();

                    v256 testvLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testvHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 result = Xse.mm256_lzcnt_epi128(testvLo, testvHi);

                    Assert.AreEqual((ulong)lzcnt(test0), result.ULong0);
                    Assert.AreEqual((ulong)lzcnt(test1), result.ULong1);
                    Assert.AreEqual((ulong)lzcnt(test2), result.ULong2);
                    Assert.AreEqual((ulong)lzcnt(test3), result.ULong3);
                }
            }
        }

        [Test]
        public static void todoubleunsigned_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();

                    v128 testvLo = new v128(test0.lo64, test1.lo64);
                    v128 testvHi = new v128(test0.hi64, test1.hi64);
                    v128 result = Xse.cvtepu128_pd(testvLo, testvHi);

                    Assert.AreEqual((double)test0, result.Double0);
                    Assert.AreEqual((double)test1, result.Double1);
                }
            }
        }

        [Test]
        public static void todoubleunsigned_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random128 rng128 = Random128.New;

                for (int i = 0; i < 128; i++)
                {
                    UInt128 test0 = rng128.NextUInt128();
                    UInt128 test1 = rng128.NextUInt128();
                    UInt128 test2 = rng128.NextUInt128();
                    UInt128 test3 = rng128.NextUInt128();

                    v256 testvLo = new v256(test0.lo64, test1.lo64, test2.lo64, test3.lo64);
                    v256 testvHi = new v256(test0.hi64, test1.hi64, test2.hi64, test3.hi64);
                    v256 result = Xse.mm256_cvtepu128_pd(testvLo, testvHi);

                    Assert.AreEqual((double)test0, result.Double0);
                    Assert.AreEqual((double)test1, result.Double1);
                    Assert.AreEqual((double)test2, result.Double2);
                    Assert.AreEqual((double)test3, result.Double3);
                }
            }
        }

        [Test]
        public static void fromdoubleunsigned_x2()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Random64 rng64 = Random64.New;

                for (int i = 0; i < 128; i++)
                {
                    double test0 = rng64.NextDouble();
                    double test1 = rng64.NextDouble();

                    v128 testv = new v128(test0, test1);
                    Xse.cvttpd_epu128(testv, out v128 testLo, out v128 testHi);

                    Assert.AreEqual((UInt128)test0, new UInt128(testLo.ULong0, testHi.ULong0));
                    Assert.AreEqual((UInt128)test1, new UInt128(testLo.ULong1, testHi.ULong1));
                }
            }
        }

        [Test]
        public static void fromdoubleunsigned_x4()
        {
            if (Avx2.IsAvx2Supported)
            {
                Random64 rng64 = Random64.New;

                for (int i = 0; i < 128; i++)
                {
                    double test0 = rng64.NextDouble();
                    double test1 = rng64.NextDouble();
                    double test2 = rng64.NextDouble();
                    double test3 = rng64.NextDouble();

                    v256 testv = new v256(test0, test1, test2, test3);
                    Xse.mm256_cvttpd_epu128(testv, out v256 testLo, out v256 testHi);

                    Assert.AreEqual((UInt128)test0, new UInt128(testLo.ULong0, testHi.ULong0));
                    Assert.AreEqual((UInt128)test1, new UInt128(testLo.ULong1, testHi.ULong1));
                    Assert.AreEqual((UInt128)test2, new UInt128(testLo.ULong2, testHi.ULong2));
                    Assert.AreEqual((UInt128)test3, new UInt128(testLo.ULong3, testHi.ULong3));
                }
            }
        }
    }
}
