using System;
using System.Numerics;
using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class dll_asm128
    {
        private static Func<UInt128, UInt128, bool> UNSAFE_UDIV128_IS_ALLOWED => (l, r) => r.hi64 == 0 && l / r.lo64 <= ulong.MaxValue;
        private static Func<Int128, Int128, bool> UNSAFE_IDIV128_IS_ALLOWED => (l, r) => asm128.usf__sdivrem128x64_fits64(l, (long)r.lo64);
        private static Func<__UInt256__, __UInt256__, bool> UNSAFE_UDIV256_IS_ALLOWED => (l, r) => r.hi128 == 0 && l / r.lo128 <= UInt128.MaxValue;

        
        private static void UTest(Func<__UInt256__, __UInt256__, __UInt256__> standardOp, Func<__UInt256__, __UInt256__, __UInt256__> testOp, Func<__UInt256__, __UInt256__, bool> testif = null)
        {
            static void TestWithBounds(ref Random128 rng, __UInt256__ minL, __UInt256__ maxL, __UInt256__ minR, __UInt256__ maxR, Func<__UInt256__, __UInt256__, __UInt256__> standardOp, Func<__UInt256__, __UInt256__, __UInt256__> testOp, Func<__UInt256__, __UInt256__, bool> testif)
            {
                __UInt256__ next;
                next = new __UInt256__(rng.NextUInt128(), rng.NextUInt128());
                __UInt256__ l = __UInt256__.Next__UInt256__(next, minL, maxL);
                next = new __UInt256__(rng.NextUInt128(), rng.NextUInt128());
                __UInt256__ r = __UInt256__.Next__UInt256__(next, minR, maxR);
        
                if (testif == null || testif(l, r))
                {
                    Assert.AreEqual(standardOp(l, r), testOp(l, r));
                }
            }
        
            Random128 rng = Random128.New;
        
            for (int i = 0; i < 128; i++)
            {
                TestWithBounds(ref rng, ulong.MaxValue, __UInt256__.MaxValue, ulong.MaxValue, __UInt256__.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, ulong.MaxValue, __UInt256__.MaxValue, 1,              100,              standardOp, testOp, testif);
                TestWithBounds(ref rng, ulong.MaxValue, __UInt256__.MaxValue, 1,              ulong.MaxValue,   standardOp, testOp, testif);
                TestWithBounds(ref rng, ulong.MaxValue, __UInt256__.MaxValue, 1,              __UInt256__.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              __UInt256__.MaxValue, ulong.MaxValue, __UInt256__.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              __UInt256__.MaxValue, 1,              100,              standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              __UInt256__.MaxValue, 1,              ulong.MaxValue,   standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              __UInt256__.MaxValue, 1,              __UInt256__.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,   ulong.MaxValue, __UInt256__.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,   1,              100,              standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,   1,              ulong.MaxValue,   standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,   1,              __UInt256__.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,              ulong.MaxValue, __UInt256__.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,              1,              100,              standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,              1,              ulong.MaxValue,   standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,              1,              __UInt256__.MaxValue, standardOp, testOp, testif);
            }
        }

        private static void UTest(Func<UInt128, UInt128, UInt128> standardOp, Func<UInt128, UInt128, UInt128> testOp, Func<UInt128, UInt128, bool> testif = null)
        {
            static void TestWithBounds(ref Random128 rng, UInt128 minL, UInt128 maxL, UInt128 minR, UInt128 maxR, Func<UInt128, UInt128, UInt128> standardOp, Func<UInt128, UInt128, UInt128> testOp, Func<UInt128, UInt128, bool> testif)
            {
                UInt128 l = rng.NextUInt128(minL, maxL);
                UInt128 r = rng.NextUInt128(minR, maxR);

                if (testif == null || testif(l, r))
                {
                    Assert.AreEqual(standardOp(l, r), testOp(l, r));
                }
            }

            Random128 rng = Random128.New;

            for (int i = 0; i < 128; i++)
            {
                TestWithBounds(ref rng, ulong.MaxValue, UInt128.MaxValue, ulong.MaxValue, UInt128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, ulong.MaxValue, UInt128.MaxValue, 1,              100,              standardOp, testOp, testif);
                TestWithBounds(ref rng, ulong.MaxValue, UInt128.MaxValue, 1,              ulong.MaxValue,   standardOp, testOp, testif);
                TestWithBounds(ref rng, ulong.MaxValue, UInt128.MaxValue, 1,              UInt128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              UInt128.MaxValue, ulong.MaxValue, UInt128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              UInt128.MaxValue, 1,              100,              standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              UInt128.MaxValue, 1,              ulong.MaxValue,   standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              UInt128.MaxValue, 1,              UInt128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,   ulong.MaxValue, UInt128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,   1,              100,              standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,   1,              ulong.MaxValue,   standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,   1,              UInt128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,              ulong.MaxValue, UInt128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,              1,              100,              standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,              1,              ulong.MaxValue,   standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,              1,              UInt128.MaxValue, standardOp, testOp, testif);
            }
        }
        
        private static void ITest(Func<Int128, Int128, Int128> standardOp, Func<Int128, Int128, Int128> testOp, Func<Int128, Int128, bool> testif = null)
        {
            static void TestWithBounds(ref Random128 rng, Int128 minL, Int128 maxL, Int128 minR, Int128 maxR, Func<Int128, Int128, Int128> standardOp, Func<Int128, Int128, Int128> testOp, Func<Int128, Int128, bool> testif)
            {
                Int128 l = rng.NextInt128(minL, maxL);
                Int128 r = rng.NextInt128(minR, maxR);
        
                if (testif == null || testif(l, r))
                {
                    Assert.AreEqual(standardOp(l, r), testOp(l, r));
                }
            }
        
            Random128 rng = Random128.New;
        
            for (int i = 0; i < 128; i++)
            {
                TestWithBounds(ref rng,  ulong.MaxValue, Int128.MaxValue,  ulong.MaxValue, Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng,  ulong.MaxValue, Int128.MaxValue,  1,              100,             standardOp, testOp, testif);
                TestWithBounds(ref rng,  ulong.MaxValue, Int128.MaxValue,  1,              ulong.MaxValue,  standardOp, testOp, testif);
                TestWithBounds(ref rng,  ulong.MaxValue, Int128.MaxValue,  1,              Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              Int128.MaxValue,  ulong.MaxValue, Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              Int128.MaxValue,  1,              100,             standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              Int128.MaxValue,  1,              ulong.MaxValue,  standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              Int128.MaxValue,  1,              Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              ulong.MaxValue,   ulong.MaxValue, Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              ulong.MaxValue,   1,              100,             standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              ulong.MaxValue,   1,              ulong.MaxValue,  standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              ulong.MaxValue,   1,              Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              100,              ulong.MaxValue, Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              100,              1,              100,             standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              100,              1,              ulong.MaxValue,  standardOp, testOp, testif);
                TestWithBounds(ref rng,  0,              100,              1,              Int128.MaxValue, standardOp, testOp, testif);
        
                TestWithBounds(ref rng, Int128.MinValue,  long.MinValue,  ulong.MaxValue, Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, Int128.MinValue,  long.MinValue,  1,              100,             standardOp, testOp, testif);
                TestWithBounds(ref rng, Int128.MinValue,  long.MinValue,  1,              ulong.MaxValue,  standardOp, testOp, testif);
                TestWithBounds(ref rng, Int128.MinValue,  -1,             1,              Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, long.MinValue, 0,                 ulong.MaxValue, Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, long.MinValue, 0,                 1,              100,             standardOp, testOp, testif);
                TestWithBounds(ref rng, long.MinValue, 0,                 1,              ulong.MaxValue,  standardOp, testOp, testif);
                TestWithBounds(ref rng, long.MinValue, 0,                 1,              Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, -100,            0,               ulong.MaxValue, Int128.MaxValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, -100,            0,               1,              100,             standardOp, testOp, testif);
                TestWithBounds(ref rng, -100,            0,               1,              ulong.MaxValue,  standardOp, testOp, testif);
                TestWithBounds(ref rng, -100,            0,               1,              Int128.MaxValue, standardOp, testOp, testif);
        
                TestWithBounds(ref rng, ulong.MaxValue, Int128.MaxValue, Int128.MinValue, long.MinValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, ulong.MaxValue, Int128.MaxValue, -100,            -1,            standardOp, testOp, testif);
                TestWithBounds(ref rng, ulong.MaxValue, Int128.MaxValue, long.MinValue,   -1,            standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              Int128.MaxValue, Int128.MinValue, -1,            standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              ulong.MaxValue,  Int128.MinValue, long.MinValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, 0,              100,             Int128.MinValue, -1,            standardOp, testOp, testif);
        
                TestWithBounds(ref rng, Int128.MinValue, long.MinValue, Int128.MinValue, long.MinValue, standardOp, testOp, testif);
                TestWithBounds(ref rng, Int128.MinValue, long.MinValue, -100,            -1,            standardOp, testOp, testif);
                TestWithBounds(ref rng, Int128.MinValue, -1,            long.MinValue,   -1,            standardOp, testOp, testif);
                TestWithBounds(ref rng, long.MinValue,   0,             Int128.MinValue, -1,            standardOp, testOp, testif);
                TestWithBounds(ref rng, long.MinValue,   0,             long.MinValue,   -1,            standardOp, testOp, testif);
                TestWithBounds(ref rng, -100,            0,             -100,            -1,            standardOp, testOp, testif);
            }
        }

        [Test]
        public static void Div128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r), asm128.__udiv128x128);
        }

        [Test]
        public static void Rem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l % r), asm128.__urem128x128);
        }

        [Test]
        public static void DivRem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r), (l, r) => asm128.__udivrem128x128(l, r, out _));
            UTest((l, r) => (UInt128)((BigInteger)l % r), (l, r) => { asm128.__udivrem128x128(l, r, out UInt128 rem); return rem; } );
        }


        [Test]
        public static void R_GreaterU64max_Div128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r), (l, r) => asm128.__udiv128x128_rGTu64max(l, r), (l, r) => r.hi64 != 0);
        }

        [Test]
        public static void R_GreaterU64max_Rem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l % r), asm128.__urem128x128_rGTu64max, (l, r) => r.hi64 != 0);
        }

        [Test]
        public static void R_GreaterU64max_DivRem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r), (l, r) => asm128.__udivrem128x128_rGTu64max(l, r, out _), (l, r) => r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)l % r), (l, r) => { asm128.__udivrem128x128_rGTu64max(l, r, out UInt128 rem); return rem; }, (l, r) => r.hi64 != 0);
        }


        [Test]
        public static void R_LessThanOrEqual_L_Div128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r), asm128.__udiv128x128_rLEl, (l, r) => r <= l);
            UTest((l, r) => (UInt128)((BigInteger)r / r), (l, r) => asm128.__udiv128x128_rLEl(r, r));
        }

        [Test]
        public static void R_LessThanOrEqual_L_Rem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l % r), asm128.__urem128x128_rLEl, (l, r) => r <= l);
            UTest((l, r) => (UInt128)((BigInteger)r % r), (l, r) => asm128.__urem128x128_rLEl(r, r));
        }

        [Test]
        public static void R_LessThanOrEqual_L_DivRem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r), (l, r) => asm128.__udivrem128x128_rLEl(l, r, out _), (l, r) => r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r / r), (l, r) => asm128.__udivrem128x128_rLEl(r, r, out _));
            UTest((l, r) => (UInt128)((BigInteger)l % r), (l, r) => { asm128.__udivrem128x128_rLEl(l, r, out UInt128 rem); return rem; }, (l, r) => r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r % r), (l, r) => { asm128.__udivrem128x128_rLEl(r, r, out UInt128 rem); return rem; });
        }


        [Test]
        public static void R_LessThanOrEqual_L_AND_R_GreaterU64max_Div128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r), (l, r) => asm128.__udiv128x128_rGTu64max_rLEl(l, r), (l, r) => r <= l && r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r / r), (l, r) => asm128.__udiv128x128_rGTu64max_rLEl(r, r), (l, r) => r.hi64 != 0);
        }

        [Test]
        public static void R_LessThanOrEqual_L_AND_R_GreaterU64max_Rem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l % r), (l, r) => asm128.__urem128x128_rGTu64max_rLEl(l, r), (l, r) => r <= l && r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r % r), (l, r) => asm128.__urem128x128_rGTu64max_rLEl(r, r), (l, r) => r.hi64 != 0);
        }

        [Test]
        public static void R_LessThanOrEqual_L_AND_R_GreaterU64max_DivRem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r), (l, r) => asm128.__udivrem128x128_rGTu64max_rLEl(l, r, out _), (l, r) => r <= l && r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r / r), (l, r) => asm128.__udivrem128x128_rGTu64max_rLEl(r, r, out _), (l, r) => r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)l % r), (l, r) => { asm128.__udivrem128x128_rGTu64max_rLEl(l, r, out UInt128 rem); return rem; }, (l, r) => r <= l && r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r % r), (l, r) => { asm128.__udivrem128x128_rGTu64max_rLEl(r, r, out UInt128 rem); return rem; }, (l, r) => r.hi64 != 0);
        }


        [Test]
        public static void Div64()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r.lo64), (l, r) => asm128.__udiv128x64(l, r.lo64));
        }

        [Test]
        public static void Rem64()
        {
            UTest((l, r) => (UInt128)((BigInteger)l % r.lo64), (l, r) => asm128.__urem128x64(l, r.lo64));
        }

        [Test]
        public static void DivRem64()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r.lo64), (l, r) => asm128.__udivrem128x64(l, r.lo64, out _));
            UTest((l, r) => (UInt128)((BigInteger)l % r.lo64), (l, r) => { asm128.__udivrem128x64(l, r.lo64, out ulong rem); return rem; } );
        }


        [Test]
        public static void R_LessThanOrEqual_L_Hi64_Div64()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r.lo64), (l, r) => asm128.__udiv128x64_rLEhi(l, r.lo64), (l, r) => r.lo64 <= l.hi64 && r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r / r.hi64), (l, r) => asm128.__udiv128x64_rLEhi(r, r.hi64), (l, r) => r.hi64 != 0);
        }

        [Test]
        public static void R_LessThanOrEqual_L_Hi64_Rem64()
        {
            UTest((l, r) => (UInt128)((BigInteger)l % r.lo64), (l, r) => asm128.__urem128x64_rLEhi(l, r.lo64), (l, r) => r.lo64 <= l.hi64 && r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r % r.hi64), (l, r) => asm128.__urem128x64_rLEhi(r, r.hi64), (l, r) => r.hi64 != 0);
        }

        [Test]
        public static void R_LessThanOrEqual_L_Hi64_DivRem64()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r.lo64), (l, r) => asm128.__udivrem128x64_rLEhi(l, r.lo64, out _), (l, r) => r.lo64 <= l.hi64 && r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r / r.hi64), (l, r) => asm128.__udivrem128x64_rLEhi(r, r.hi64, out _), (l, r) => r.hi64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)l % r.lo64), (l, r) => { asm128.__udivrem128x64_rLEhi(l, r.lo64, out ulong rem); return rem; }, (l, r) => r.lo64 <= l.hi64 && r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)r % r.hi64), (l, r) => { asm128.__udivrem128x64_rLEhi(r, r.hi64, out ulong rem); return rem; }, (l, r) => r.hi64 != 0);
        }


        [Test]
        public static void x2_DivHighBy64ReturnLow()
        {
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__2xudiv128hiXloRlo(new ulong2(l.hi64, 1), new ulong2(r.lo64, 2)).x, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__2xudiv128hiXloRlo(new ulong2(1, l.hi64), new ulong2(2, r.lo64)).y, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
        }

        [Test]
        public static void x3_DivHighBy64ReturnLow()
        {
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__3xudiv128hiXloRlo(new ulong3(l.hi64, 1, 1), new ulong3(r.lo64, 2, 2)).x, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__3xudiv128hiXloRlo(new ulong3(1, l.hi64, 1), new ulong3(2, r.lo64, 2)).y, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__3xudiv128hiXloRlo(new ulong3(1, 1, l.hi64), new ulong3(2, 2, r.lo64)).z, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
        }

        [Test]
        public static void x4_DivHighBy64ReturnLow()
        {
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__4xudiv128hiXloRlo(new ulong4(l.hi64, 1, 1, 1), new ulong4(r.lo64, 2, 2, 2)).x, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__4xudiv128hiXloRlo(new ulong4(1, l.hi64, 1, 1), new ulong4(2, r.lo64, 2, 2)).y, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__4xudiv128hiXloRlo(new ulong4(1, 1, l.hi64, 1), new ulong4(2, 2, r.lo64, 2)).z, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
            UTest((l, r) => ((UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64)).lo64, (l, r) => asm128.__spc__4xudiv128hiXloRlo(new ulong4(1, 1, 1, l.hi64), new ulong4(2, 2, 2, r.lo64)).w, (l, r) => r.lo64 != 0 && (UInt128)((BigInteger)new UInt128(0, l.hi64) / r.lo64) <= ulong.MaxValue);
        }


        [Test]
        public static void x1_DivU128MaxBy64AndIncrement()
        {
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => asm128.__spc__udivmax128x64_inc(r.lo64), (l, r) => r.lo64 != 0);
        }

        [Test]
        public static void x2_DivU128MaxBy64AndIncrement()
        {
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__2xudivmax128x64_inc(r.lo64, out UInt128 res, r.lo64, out _);           return res; }, (l, r) => r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__2xudivmax128x64_inc(r.lo64, out _,           r.lo64, out UInt128 res); return res; }, (l, r) => r.lo64 != 0);
        }

        [Test]
        public static void x3_DivU128MaxBy64AndIncrement()
        {
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__3xudivmax128x64_inc(r.lo64, out UInt128 res, r.lo64, out _,           r.lo64, out _);           return res; }, (l, r) => r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__3xudivmax128x64_inc(r.lo64, out _,           r.lo64, out UInt128 res, r.lo64, out _);           return res; }, (l, r) => r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__3xudivmax128x64_inc(r.lo64, out _,           r.lo64, out _,           r.lo64, out UInt128 res); return res; }, (l, r) => r.lo64 != 0);
        }

        [Test]
        public static void x4_DivU128MaxBy64AndIncrement()
        {
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__4xudivmax128x64_inc(r.lo64, out UInt128 res, r.lo64, out _,           r.lo64, out _,           r.lo64, out _);           return res; }, (l, r) => r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__4xudivmax128x64_inc(r.lo64, out _,           r.lo64, out UInt128 res, r.lo64, out _,           r.lo64, out _);           return res; }, (l, r) => r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__4xudivmax128x64_inc(r.lo64, out _,           r.lo64, out _,           r.lo64, out UInt128 res, r.lo64, out _);           return res; }, (l, r) => r.lo64 != 0);
            UTest((l, r) => (UInt128)((BigInteger)UInt128.MaxValue / r.lo64 + 1), (l, r) => { asm128.__spc__4xudivmax128x64_inc(r.lo64, out _,           r.lo64, out _,           r.lo64, out _,           r.lo64, out UInt128 res); return res; }, (l, r) => r.lo64 != 0);
        }


        [Test]
        public static void UsfUDivRem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r.lo64), (l, r) => asm128.__usf__udivrem128x64(l, r.lo64, out _),                          UNSAFE_UDIV128_IS_ALLOWED);
            UTest((l, r) => (UInt128)((BigInteger)l % r.lo64), (l, r) => { asm128.__usf__udivrem128x64(l, r.lo64, out ulong rem); return rem; }, UNSAFE_UDIV128_IS_ALLOWED);
        }

        [Test]
        public static void UsfUDiv128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r.lo64), (l, r) => asm128.__usf__udiv128x64(l, r.lo64), UNSAFE_UDIV128_IS_ALLOWED);
        }

        [Test]
        public static void UsfURem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l % r.lo64), (l, r) => asm128.__usf__urem128x64(l, r.lo64), UNSAFE_UDIV128_IS_ALLOWED);
        }

        [Test]
        public static void UsfIDivRem128()
        {
            ITest((l, r) => (Int128)((BigInteger)l / (long)r.lo64), (l, r) => asm128.__usf__idivrem128x64(l, (long)r.lo64, out _),                         UNSAFE_IDIV128_IS_ALLOWED);
            ITest((l, r) => (Int128)((BigInteger)l % (long)r.lo64), (l, r) => { asm128.__usf__idivrem128x64(l, (long)r.lo64, out long rem); return rem; }, UNSAFE_IDIV128_IS_ALLOWED);
        }

        [Test]
        public static void UsfIDiv128()
        {
            ITest((l, r) => (Int128)((BigInteger)l / (long)r.lo64), (l, r) => asm128.__usf__idiv128x64(l, (long)r.lo64), UNSAFE_IDIV128_IS_ALLOWED);
        }

        [Test]
        public static void UsfIRem128()
        {
            ITest((l, r) => (Int128)((BigInteger)l % (long)r.lo64), (l, r) => asm128.__usf__irem128x64(l, (long)r.lo64), UNSAFE_IDIV128_IS_ALLOWED);
        }

        [Test]
        public static void UDiv256x128()
        {
            UTest((l, r) => (__UInt256__)((BigInteger)l / r.lo128), (l, r) => asm128.__usf__udiv256x128(l, r.lo128), UNSAFE_UDIV256_IS_ALLOWED);
        }
    }
}