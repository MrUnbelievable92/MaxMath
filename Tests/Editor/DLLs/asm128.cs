using System;
using System.Numerics;
using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class dll_asm128
    {
        private static Func<UInt128, UInt128, bool> UNSAFE_UDIV_IS_ALLOWED => (l, r) => r.hi64 == 0 && l / r.lo64 <= ulong.MaxValue;
        private static Func<Int128, Int128, bool> UNSAFE_IDIV_IS_ALLOWED => (l, r) => (r.hi64 == 0 || r.hi64 == ulong.MaxValue) && (l / r <= long.MaxValue && l / r >= long.MinValue);


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
            UTest((l, r) => (UInt128)((BigInteger)l / r.lo64), (l, r) => asm128.__usf__udivrem128x64(l, r.lo64, out _),                          UNSAFE_UDIV_IS_ALLOWED);
            UTest((l, r) => (UInt128)((BigInteger)l % r.lo64), (l, r) => { asm128.__usf__udivrem128x64(l, r.lo64, out ulong rem); return rem; }, UNSAFE_UDIV_IS_ALLOWED);
        }

        [Test]
        public static void UsfUDiv128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l / r.lo64), (l, r) => asm128.__usf__udiv128x64(l, r.lo64), UNSAFE_UDIV_IS_ALLOWED);
        }

        [Test]
        public static void UsfURem128()
        {
            UTest((l, r) => (UInt128)((BigInteger)l % r.lo64), (l, r) => asm128.__usf__urem128x64(l, r.lo64), UNSAFE_UDIV_IS_ALLOWED);
        }

        [Test]
        public static void UsfIDivRem128()
        {
            Random128 r128 = Random128.New;
            Random64 r64 = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                Int128 l = r128.NextInt128();
                long r = r64.NextLong();

                Int128 quo = maxmath.divrem(l, r, out Int128 rem);

                if (quo >= long.MinValue && quo <= long.MaxValue)
                {
                    long quo64 = asm128.__usf__idivrem128x64(l, r, out long rem64);

                    Assert.AreEqual(quo, (Int128)quo64);
                    Assert.AreEqual(rem, (Int128)rem64);
                }
                else
                {
                    i--;
                }
            }
        }

        [Test]
        public static void UsfIDiv128()
        {
            Random128 r128 = Random128.New;
            Random64 r64 = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                Int128 l = r128.NextInt128();
                long r = r64.NextLong();

                Int128 quo = maxmath.divrem(l, r, out Int128 rem);

                if (quo >= long.MinValue && quo <= long.MaxValue)
                {
                    long quo64 = asm128.__usf__idiv128x64(l, r);

                    Assert.AreEqual(quo, (Int128)quo64);
                }
                else
                {
                    i--;
                }
            }
        }

        [Test]
        public static void UsfIRem128()
        {
            Random128 r128 = Random128.New;
            Random64 r64 = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                Int128 l = r128.NextInt128();
                long r = r64.NextLong();

                Int128 quo = maxmath.divrem(l, r, out Int128 rem);

                if (quo >= long.MinValue && quo <= long.MaxValue)
                {
                    long rem64 = asm128.__usf__irem128x64(l, r);

                    Assert.AreEqual(rem, (Int128)rem64);
                }
                else
                {
                    i--;
                }
            }
        }
    }
}