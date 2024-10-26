using Unity.Burst.Intrinsics;
using NUnit.Framework;
using MaxMath;
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
        public static void cmpgt128ux64u_x2()
        {
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
        public static void srli_x2()
        {
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
    }
}
