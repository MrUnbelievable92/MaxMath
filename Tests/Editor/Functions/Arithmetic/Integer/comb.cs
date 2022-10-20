using NUnit.Framework;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Tests
{
    unsafe public static class comb
    {
        private static UInt128 realbinom(UInt128 n, UInt128 k)
        {
            UInt128 c = 1;

            if (k > n - k)
                k = n - k;

            for (UInt128 i = 1; i <= k; i++, n--) 
            {
                c = c / i * n + c % i * n / i;
            }

            return c;
        }

        private static ulong realbinom(ulong n, ulong k)
        {
            ulong c = 1;

            if (k > n - k)
                k = n - k;

            for (ulong i = 1; i <= k; i++, n--) 
            {
                c = c / i * n + c % i * n / i;
            }

            return c;
        }
        
        private static uint realbinom(uint n, uint k)
        {
            uint c = 1;

            if (k > n - k)
                k = n - k;

            for (uint i = 1; i <= k; i++, n--) 
            {
                c = c / i * n + c % i * n / i;
            }

            return c;
        }

        private static ushort realbinom(ushort n, ushort k)
        {
            ushort c = 1;

            if (k > n - k)
                k = (ushort)(n - k);

            for (ushort i = 1; i <= k; i++, n--) 
            {
                c = (ushort)((ushort)((ushort)(c / i) * n) + (ushort)((ushort)((ushort)(c % i) * n) / i));
            }

            return c;
        }
        
        private static byte realbinom(byte n, byte k)
        {
            byte c = 1;

            if (k > n - k)
                k = (byte)(n - k);

            for (byte i = 1; i <= k; i++, n--) 
            {
                c = (byte)((byte)((byte)(c / i) * n) + (byte)((byte)((byte)(c % i) * n) / i));
            }

            return c;
        }


        [Test]
        public static void _uint128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 8; i++)
            {
                UInt128 n = rng.NextUInt128(1, UInt128.MaxValue);
                UInt128 k = n - 1;
                
                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextUInt128(1, UInt128.MaxValue);
                k = rng.NextUInt128(0, n + 1);
                k = maxmath.select(k, n - 100, n - k > 100);
                
                Assert.AreEqual(maxmath.comb((UInt128)n, (UInt128)k), realbinom((UInt128)n, (UInt128)k));
                Assert.AreEqual(maxmath.comb((UInt128)n, (UInt128)0), realbinom((UInt128)n, (UInt128)0));
                Assert.AreEqual(maxmath.comb((UInt128)n, (UInt128)1), realbinom((UInt128)n, (UInt128)1));
                Assert.AreEqual(maxmath.comb((UInt128)1, (UInt128)0), realbinom((UInt128)1, (UInt128)0));
                Assert.AreEqual(maxmath.comb((UInt128)1, (UInt128)1), realbinom((UInt128)1, (UInt128)1));
            }
        }


        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 18; i++)
            {
                byte2 n = rng.NextByte2(1, 64);
                byte2 k = n - 1;
                byte2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextByte2(1, byte.MaxValue);
                k = rng.NextByte2(0, maxmath.min(rng.NextByte2(1, byte.MaxValue), maxmath.subsaturated(n, 25)));

                if (Sse2.IsSse2Supported)
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, k.y));
                    
                    c = maxmath.comb(n, 0);
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, 0));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 0));
                    
                    c = maxmath.comb(n, new byte2(0, 1));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, 0));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    
                    c = maxmath.comb(n, new byte2(k.x, 1));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    
                    c = maxmath.comb(n, new byte2(k.x, 0));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 0));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, 1));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    
                    c = maxmath.comb(new byte2(1), new byte2(0));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)1, 0));
                    
                    c = maxmath.comb(new byte2(1), new byte2(1));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)1, 1));
                }
                else
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, k.y));
                    
                    c = maxmath.comb(n, 0);
                    Assert.AreEqual(c.x, realbinom(n.x, 0));
                    Assert.AreEqual(c.y, realbinom(n.y, 0));
                    
                    c = maxmath.comb(n, new byte2(0, 1));
                    Assert.AreEqual(c.x, realbinom(n.x, 0));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    
                    c = maxmath.comb(n, new byte2(k.x, 1));
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    
                    c = maxmath.comb(n, new byte2(k.x, 0));
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, 0));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x, realbinom(n.x, 1));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    
                    c = maxmath.comb(new byte2(1), new byte2(0));
                    Assert.AreEqual(c.x, realbinom(1, 0));
                    Assert.AreEqual(c.y, realbinom(1, 0));
                    
                    c = maxmath.comb(new byte2(1), new byte2(1));
                    Assert.AreEqual(c.x, realbinom(1, 1));
                    Assert.AreEqual(c.y, realbinom(1, 1));
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3 n = rng.NextByte3(1, 64);
                byte3 k = n - 1;
                byte3 c;
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextByte3(1, byte.MaxValue);
                k = rng.NextByte3(0, maxmath.min(rng.NextByte3(1, byte.MaxValue), maxmath.subsaturated(n, 25)));
                
                if (Sse2.IsSse2Supported)
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, k.y));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, k.z));
                    
                    c = maxmath.comb(n, 0);
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, 0));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 0));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, 0));
                    
                    c = maxmath.comb(n, new byte3(0, 1, 0));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, 0));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, 0));
                    
                    c = maxmath.comb(n, new byte3(k.x, 1, k.z));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, k.z));
                    
                    c = maxmath.comb(n, new byte3(k.x, 0, k.z));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 0));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, k.z));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, 1));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, 1));
                    
                    c = maxmath.comb(new byte3(1), new byte3(0));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)1, 0));
                    
                    c = maxmath.comb(new byte3(1), new byte3(1));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)1, 1));
                }
                else
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, k.y));
                    Assert.AreEqual(c.z, realbinom(n.z, k.z));
                    
                    c = maxmath.comb(n, 0);
                    Assert.AreEqual(c.x, realbinom(n.x, 0));
                    Assert.AreEqual(c.y, realbinom(n.y, 0));
                    Assert.AreEqual(c.z, realbinom(n.z, 0));
                    
                    c = maxmath.comb(n, new byte3(0, 1, 0));
                    Assert.AreEqual(c.x, realbinom(n.x, 0));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    Assert.AreEqual(c.z, realbinom(n.z, 0));
                    
                    c = maxmath.comb(n, new byte3(k.x, 1, k.z));
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    Assert.AreEqual(c.z, realbinom(n.z, k.z));
                    
                    c = maxmath.comb(n, new byte3(k.x, 0, k.z));
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, 0));
                    Assert.AreEqual(c.z, realbinom(n.z, k.z));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x, realbinom(n.x, 1));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    Assert.AreEqual(c.z, realbinom(n.z, 1));
                    
                    c = maxmath.comb(new byte3(1), new byte3(0));
                    Assert.AreEqual(c.x, realbinom(1, 0));
                    Assert.AreEqual(c.y, realbinom(1, 0));
                    Assert.AreEqual(c.z, realbinom(1, 0));
                    
                    c = maxmath.comb(new byte3(1), new byte3(1));
                    Assert.AreEqual(c.x, realbinom(1, 1));
                    Assert.AreEqual(c.y, realbinom(1, 1));
                    Assert.AreEqual(c.z, realbinom(1, 1));
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 14; i++)
            {
                byte4 n = rng.NextByte4(1, 64);
                byte4 k = n - 1;
                byte4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextByte4(1, byte.MaxValue);
                k = rng.NextByte4(0, maxmath.min(rng.NextByte4(1, byte.MaxValue), maxmath.subsaturated(n, 25)));
                
                if (Sse2.IsSse2Supported)
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, k.y));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, k.z));
                    Assert.AreEqual(c.w, (byte)realbinom((ushort)n.w, k.w));
                    
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(maxmath.comb(n, 0).x, (byte)realbinom((ushort)n.x, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).y, (byte)realbinom((ushort)n.y, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).z, (byte)realbinom((ushort)n.z, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).w, (byte)realbinom((ushort)n.w, 0));
                    
                    c = maxmath.comb(n, new byte4(0, 1, 0, 1));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, 0));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, 0));
                    Assert.AreEqual(c.w, (byte)realbinom((ushort)n.w, 1));
                                         
                    c = maxmath.comb(n, new byte4(k.x, 1, k.z, 1));                    
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, k.z));
                    Assert.AreEqual(c.w, (byte)realbinom((ushort)n.w, 1));
                                          
                    c = maxmath.comb(n, new byte4(k.x, 0, k.z, 0));                   
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, k.x));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 0));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, k.z));
                    Assert.AreEqual(c.w, (byte)realbinom((ushort)n.w, 0));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)n.x, 1));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)n.y, 1));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)n.z, 1));
                    Assert.AreEqual(c.w, (byte)realbinom((ushort)n.w, 1));
                    
                    c = maxmath.comb(new byte4(1), new byte4(0));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.w, (byte)realbinom((ushort)1, 0));
                    
                    c = maxmath.comb(new byte4(1), new byte4(1));
                    Assert.AreEqual(c.x, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.y, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.z, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.w, (byte)realbinom((ushort)1, 1));
                }
                else
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, k.y));
                    Assert.AreEqual(c.z, realbinom(n.z, k.z));
                    Assert.AreEqual(c.w, realbinom(n.w, k.w));
                    
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(maxmath.comb(n, 0).x, realbinom(n.x, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).y, realbinom(n.y, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).z, realbinom(n.z, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).w, realbinom(n.w, 0));
                    
                    c = maxmath.comb(n, new byte4(0, 1, 0, 1));
                    Assert.AreEqual(c.x, realbinom(n.x, 0));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    Assert.AreEqual(c.z, realbinom(n.z, 0));
                    Assert.AreEqual(c.w, realbinom(n.w, 1));
                                         
                    c = maxmath.comb(n, new byte4(k.x, 1, k.z, 1));                    
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    Assert.AreEqual(c.z, realbinom(n.z, k.z));
                    Assert.AreEqual(c.w, realbinom(n.w, 1));
                                          
                    c = maxmath.comb(n, new byte4(k.x, 0, k.z, 0));                   
                    Assert.AreEqual(c.x, realbinom(n.x, k.x));
                    Assert.AreEqual(c.y, realbinom(n.y, 0));
                    Assert.AreEqual(c.z, realbinom(n.z, k.z));
                    Assert.AreEqual(c.w, realbinom(n.w, 0));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x, realbinom(n.x, 1));
                    Assert.AreEqual(c.y, realbinom(n.y, 1));
                    Assert.AreEqual(c.z, realbinom(n.z, 1));
                    Assert.AreEqual(c.w, realbinom(n.w, 1));
                    
                    c = maxmath.comb(new byte4(1), new byte4(0));
                    Assert.AreEqual(c.x, realbinom(1, 0));
                    Assert.AreEqual(c.y, realbinom(1, 0));
                    Assert.AreEqual(c.z, realbinom(1, 0));
                    Assert.AreEqual(c.w, realbinom(1, 0));
                    
                    c = maxmath.comb(new byte4(1), new byte4(1));
                    Assert.AreEqual(c.x, realbinom(1, 1));
                    Assert.AreEqual(c.y, realbinom(1, 1));
                    Assert.AreEqual(c.z, realbinom(1, 1));
                    Assert.AreEqual(c.w, realbinom(1, 1));
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte8 n = rng.NextByte8(1, 64);
                byte8 k = n - 1;
                byte8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);

                n = rng.NextByte8(1, byte.MaxValue);
                k = rng.NextByte8(0, maxmath.min(rng.NextByte8(1, byte.MaxValue), maxmath.subsaturated(n, 25)));
                
                if (Sse2.IsSse2Supported)
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x0, (byte)realbinom((ushort)n.x0, k.x0));
                    Assert.AreEqual(c.x1, (byte)realbinom((ushort)n.x1, k.x1));
                    Assert.AreEqual(c.x2, (byte)realbinom((ushort)n.x2, k.x2));
                    Assert.AreEqual(c.x3, (byte)realbinom((ushort)n.x3, k.x3));
                    Assert.AreEqual(c.x4, (byte)realbinom((ushort)n.x4, k.x4));
                    Assert.AreEqual(c.x5, (byte)realbinom((ushort)n.x5, k.x5));
                    Assert.AreEqual(c.x6, (byte)realbinom((ushort)n.x6, k.x6));
                    Assert.AreEqual(c.x7, (byte)realbinom((ushort)n.x7, k.x7));
                    
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(maxmath.comb(n, 0).x0, (byte)realbinom((ushort)n.x0, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x1, (byte)realbinom((ushort)n.x1, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x2, (byte)realbinom((ushort)n.x2, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x3, (byte)realbinom((ushort)n.x3, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x4, (byte)realbinom((ushort)n.x4, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x5, (byte)realbinom((ushort)n.x5, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x6, (byte)realbinom((ushort)n.x6, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x7, (byte)realbinom((ushort)n.x7, 0));
                    
                    c = maxmath.comb(n, new byte8(0, 1, 0, 1, 0, 1, 0, 1));
                    Assert.AreEqual(c.x0, (byte)realbinom((ushort)n.x0, 0));
                    Assert.AreEqual(c.x1, (byte)realbinom((ushort)n.x1, 1));
                    Assert.AreEqual(c.x2, (byte)realbinom((ushort)n.x2, 0));
                    Assert.AreEqual(c.x3, (byte)realbinom((ushort)n.x3, 1));
                    Assert.AreEqual(c.x4, (byte)realbinom((ushort)n.x4, 0));
                    Assert.AreEqual(c.x5, (byte)realbinom((ushort)n.x5, 1));
                    Assert.AreEqual(c.x6, (byte)realbinom((ushort)n.x6, 0));
                    Assert.AreEqual(c.x7, (byte)realbinom((ushort)n.x7, 1));
                                         
                    c = maxmath.comb(n, new byte8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));                    
                    Assert.AreEqual(c.x0, (byte)realbinom((ushort)n.x0, k.x0));
                    Assert.AreEqual(c.x1, (byte)realbinom((ushort)n.x1, 1));
                    Assert.AreEqual(c.x2, (byte)realbinom((ushort)n.x2, k.x2));
                    Assert.AreEqual(c.x3, (byte)realbinom((ushort)n.x3, 1));                
                    Assert.AreEqual(c.x4, (byte)realbinom((ushort)n.x4, k.x4));
                    Assert.AreEqual(c.x5, (byte)realbinom((ushort)n.x5, 1));
                    Assert.AreEqual(c.x6, (byte)realbinom((ushort)n.x6, k.x6));
                    Assert.AreEqual(c.x7, (byte)realbinom((ushort)n.x7, 1));
                                          
                    c = maxmath.comb(n, new byte8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));                   
                    Assert.AreEqual(c.x0, (byte)realbinom((ushort)n.x0, k.x0));
                    Assert.AreEqual(c.x1, (byte)realbinom((ushort)n.x1, 0));
                    Assert.AreEqual(c.x2, (byte)realbinom((ushort)n.x2, k.x2));
                    Assert.AreEqual(c.x3, (byte)realbinom((ushort)n.x3, 0));           
                    Assert.AreEqual(c.x4, (byte)realbinom((ushort)n.x4, k.x4));
                    Assert.AreEqual(c.x5, (byte)realbinom((ushort)n.x5, 0));
                    Assert.AreEqual(c.x6, (byte)realbinom((ushort)n.x6, k.x6));
                    Assert.AreEqual(c.x7, (byte)realbinom((ushort)n.x7, 0));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x0, (byte)realbinom((ushort)n.x0, 1));
                    Assert.AreEqual(c.x1, (byte)realbinom((ushort)n.x1, 1));
                    Assert.AreEqual(c.x2, (byte)realbinom((ushort)n.x2, 1));
                    Assert.AreEqual(c.x3, (byte)realbinom((ushort)n.x3, 1));
                    Assert.AreEqual(c.x4, (byte)realbinom((ushort)n.x4, 1));
                    Assert.AreEqual(c.x5, (byte)realbinom((ushort)n.x5, 1));
                    Assert.AreEqual(c.x6, (byte)realbinom((ushort)n.x6, 1));
                    Assert.AreEqual(c.x7, (byte)realbinom((ushort)n.x7, 1));
                    
                    c = maxmath.comb(new byte8(1), new byte8(0));
                    Assert.AreEqual(c.x0, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x1, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x2, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x3, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x4, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x5, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x6, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x7, (byte)realbinom((ushort)1, 0));
                    
                    c = maxmath.comb(new byte8(1), new byte8(1));
                    Assert.AreEqual(c.x0, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x1, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x2, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x3, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x4, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x5, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x6, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x7, (byte)realbinom((ushort)1, 1));
                }
                else
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                    Assert.AreEqual(c.x1, realbinom(n.x1, k.x1));
                    Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                    Assert.AreEqual(c.x3, realbinom(n.x3, k.x3));
                    Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                    Assert.AreEqual(c.x5, realbinom(n.x5, k.x5));
                    Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                    Assert.AreEqual(c.x7, realbinom(n.x7, k.x7));
                    
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(maxmath.comb(n, 0).x0, realbinom(n.x0, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x1, realbinom(n.x1, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x2, realbinom(n.x2, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x3, realbinom(n.x3, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x4, realbinom(n.x4, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x5, realbinom(n.x5, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x6, realbinom(n.x6, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x7, realbinom(n.x7, 0));
                    
                    c = maxmath.comb(n, new byte8(0, 1, 0, 1, 0, 1, 0, 1));
                    Assert.AreEqual(c.x0, realbinom(n.x0, 0));
                    Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                    Assert.AreEqual(c.x2, realbinom(n.x2, 0));
                    Assert.AreEqual(c.x3, realbinom(n.x3, 1));
                    Assert.AreEqual(c.x4, realbinom(n.x4, 0));
                    Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                    Assert.AreEqual(c.x6, realbinom(n.x6, 0));
                    Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                                         
                    c = maxmath.comb(n, new byte8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));                    
                    Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                    Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                    Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                    Assert.AreEqual(c.x3, realbinom(n.x3, 1));                
                    Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                    Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                    Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                    Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                                          
                    c = maxmath.comb(n, new byte8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));                   
                    Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                    Assert.AreEqual(c.x1, realbinom(n.x1, 0));
                    Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                    Assert.AreEqual(c.x3, realbinom(n.x3, 0));           
                    Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                    Assert.AreEqual(c.x5, realbinom(n.x5, 0));
                    Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                    Assert.AreEqual(c.x7, realbinom(n.x7, 0));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x0, realbinom(n.x0, 1));
                    Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                    Assert.AreEqual(c.x2, realbinom(n.x2, 1));
                    Assert.AreEqual(c.x3, realbinom(n.x3, 1));
                    Assert.AreEqual(c.x4, realbinom(n.x4, 1));
                    Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                    Assert.AreEqual(c.x6, realbinom(n.x6, 1));
                    Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                    
                    c = maxmath.comb(new byte8(1), new byte8(0));
                    Assert.AreEqual(c.x0, realbinom(1, 0));
                    Assert.AreEqual(c.x1, realbinom(1, 0));
                    Assert.AreEqual(c.x2, realbinom(1, 0));
                    Assert.AreEqual(c.x3, realbinom(1, 0));
                    Assert.AreEqual(c.x4, realbinom(1, 0));
                    Assert.AreEqual(c.x5, realbinom(1, 0));
                    Assert.AreEqual(c.x6, realbinom(1, 0));
                    Assert.AreEqual(c.x7, realbinom(1, 0));
                    
                    c = maxmath.comb(new byte8(1), new byte8(1));
                    Assert.AreEqual(c.x0, realbinom(1, 1));
                    Assert.AreEqual(c.x1, realbinom(1, 1));
                    Assert.AreEqual(c.x2, realbinom(1, 1));
                    Assert.AreEqual(c.x3, realbinom(1, 1));
                    Assert.AreEqual(c.x4, realbinom(1, 1));
                    Assert.AreEqual(c.x5, realbinom(1, 1));
                    Assert.AreEqual(c.x6, realbinom(1, 1));
                    Assert.AreEqual(c.x7, realbinom(1, 1));
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 10; i++)
            {
                byte16 n = rng.NextByte16(1, 64);
                byte16 k = n - 1;
                byte16 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x12, n.x12);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x14, n.x14);
                Assert.AreEqual(c.x15, n.x15);

                n = rng.NextByte16(1, byte.MaxValue);
                k = rng.NextByte16(0, maxmath.min(rng.NextByte16(1, byte.MaxValue), maxmath.subsaturated(n, 25)));
                
                if (Avx2.IsAvx2Supported)
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x0,  (byte)realbinom((ushort)n.x0,  k.x0));
                    Assert.AreEqual(c.x1,  (byte)realbinom((ushort)n.x1,  k.x1));
                    Assert.AreEqual(c.x2,  (byte)realbinom((ushort)n.x2,  k.x2));
                    Assert.AreEqual(c.x3,  (byte)realbinom((ushort)n.x3,  k.x3));
                    Assert.AreEqual(c.x4,  (byte)realbinom((ushort)n.x4,  k.x4));
                    Assert.AreEqual(c.x5,  (byte)realbinom((ushort)n.x5,  k.x5));
                    Assert.AreEqual(c.x6,  (byte)realbinom((ushort)n.x6,  k.x6));
                    Assert.AreEqual(c.x7,  (byte)realbinom((ushort)n.x7,  k.x7));
                    Assert.AreEqual(c.x8,  (byte)realbinom((ushort)n.x8,  k.x8));
                    Assert.AreEqual(c.x9,  (byte)realbinom((ushort)n.x9,  k.x9));
                    Assert.AreEqual(c.x10, (byte)realbinom((ushort)n.x10, k.x10));
                    Assert.AreEqual(c.x11, (byte)realbinom((ushort)n.x11, k.x11));
                    Assert.AreEqual(c.x12, (byte)realbinom((ushort)n.x12, k.x12));
                    Assert.AreEqual(c.x13, (byte)realbinom((ushort)n.x13, k.x13));
                    Assert.AreEqual(c.x14, (byte)realbinom((ushort)n.x14, k.x14));
                    Assert.AreEqual(c.x15, (byte)realbinom((ushort)n.x15, k.x15));
                    
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(maxmath.comb(n, 0).x0,  (byte)realbinom((ushort)n.x0,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x1,  (byte)realbinom((ushort)n.x1,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x2,  (byte)realbinom((ushort)n.x2,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x3,  (byte)realbinom((ushort)n.x3,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x4,  (byte)realbinom((ushort)n.x4,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x5,  (byte)realbinom((ushort)n.x5,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x6,  (byte)realbinom((ushort)n.x6,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x7,  (byte)realbinom((ushort)n.x7,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x8,  (byte)realbinom((ushort)n.x8,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x9,  (byte)realbinom((ushort)n.x9,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x10, (byte)realbinom((ushort)n.x10, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x11, (byte)realbinom((ushort)n.x11, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x12, (byte)realbinom((ushort)n.x12, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x13, (byte)realbinom((ushort)n.x13, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x14, (byte)realbinom((ushort)n.x14, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x15, (byte)realbinom((ushort)n.x15, 0));
                    
                    c = maxmath.comb(n, new byte16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                    Assert.AreEqual(c.x0,  (byte)realbinom((ushort)n.x0,  0));
                    Assert.AreEqual(c.x1,  (byte)realbinom((ushort)n.x1,  1));
                    Assert.AreEqual(c.x2,  (byte)realbinom((ushort)n.x2,  0));
                    Assert.AreEqual(c.x3,  (byte)realbinom((ushort)n.x3,  1));
                    Assert.AreEqual(c.x4,  (byte)realbinom((ushort)n.x4,  0));
                    Assert.AreEqual(c.x5,  (byte)realbinom((ushort)n.x5,  1));
                    Assert.AreEqual(c.x6,  (byte)realbinom((ushort)n.x6,  0));
                    Assert.AreEqual(c.x7,  (byte)realbinom((ushort)n.x7,  1));
                    Assert.AreEqual(c.x8,  (byte)realbinom((ushort)n.x8,  0));
                    Assert.AreEqual(c.x9,  (byte)realbinom((ushort)n.x9,  1));
                    Assert.AreEqual(c.x10, (byte)realbinom((ushort)n.x10, 0));
                    Assert.AreEqual(c.x11, (byte)realbinom((ushort)n.x11, 1));
                    Assert.AreEqual(c.x12, (byte)realbinom((ushort)n.x12, 0));
                    Assert.AreEqual(c.x13, (byte)realbinom((ushort)n.x13, 1));
                    Assert.AreEqual(c.x14, (byte)realbinom((ushort)n.x14, 0));
                    Assert.AreEqual(c.x15, (byte)realbinom((ushort)n.x15, 1));
                                         
                    c = maxmath.comb(n, new byte16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1));                    
                    Assert.AreEqual(c.x0,  (byte)realbinom((ushort)n.x0,  k.x0));
                    Assert.AreEqual(c.x1,  (byte)realbinom((ushort)n.x1,  1));
                    Assert.AreEqual(c.x2,  (byte)realbinom((ushort)n.x2,  k.x2));
                    Assert.AreEqual(c.x3,  (byte)realbinom((ushort)n.x3,  1));                
                    Assert.AreEqual(c.x4,  (byte)realbinom((ushort)n.x4,  k.x4));
                    Assert.AreEqual(c.x5,  (byte)realbinom((ushort)n.x5,  1));
                    Assert.AreEqual(c.x6,  (byte)realbinom((ushort)n.x6,  k.x6));
                    Assert.AreEqual(c.x7,  (byte)realbinom((ushort)n.x7,  1));                 
                    Assert.AreEqual(c.x8,  (byte)realbinom((ushort)n.x8,  k.x8));
                    Assert.AreEqual(c.x9,  (byte)realbinom((ushort)n.x9,  1));
                    Assert.AreEqual(c.x10, (byte)realbinom((ushort)n.x10, k.x10));
                    Assert.AreEqual(c.x11, (byte)realbinom((ushort)n.x11, 1));                
                    Assert.AreEqual(c.x12, (byte)realbinom((ushort)n.x12, k.x12));
                    Assert.AreEqual(c.x13, (byte)realbinom((ushort)n.x13, 1));
                    Assert.AreEqual(c.x14, (byte)realbinom((ushort)n.x14, k.x14));
                    Assert.AreEqual(c.x15, (byte)realbinom((ushort)n.x15, 1));
                                          
                    c = maxmath.comb(n, new byte16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0));                   
                    Assert.AreEqual(c.x0,  (byte)realbinom((ushort)n.x0,  k.x0));
                    Assert.AreEqual(c.x1,  (byte)realbinom((ushort)n.x1,  0));
                    Assert.AreEqual(c.x2,  (byte)realbinom((ushort)n.x2,  k.x2));
                    Assert.AreEqual(c.x3,  (byte)realbinom((ushort)n.x3,  0));           
                    Assert.AreEqual(c.x4,  (byte)realbinom((ushort)n.x4,  k.x4));
                    Assert.AreEqual(c.x5,  (byte)realbinom((ushort)n.x5,  0));
                    Assert.AreEqual(c.x6,  (byte)realbinom((ushort)n.x6,  k.x6));
                    Assert.AreEqual(c.x7,  (byte)realbinom((ushort)n.x7,  0));       
                    Assert.AreEqual(c.x8,  (byte)realbinom((ushort)n.x8,  k.x8));
                    Assert.AreEqual(c.x9,  (byte)realbinom((ushort)n.x9,  0));
                    Assert.AreEqual(c.x10, (byte)realbinom((ushort)n.x10, k.x10));
                    Assert.AreEqual(c.x11, (byte)realbinom((ushort)n.x11, 0));           
                    Assert.AreEqual(c.x12, (byte)realbinom((ushort)n.x12, k.x12));
                    Assert.AreEqual(c.x13, (byte)realbinom((ushort)n.x13, 0));
                    Assert.AreEqual(c.x14, (byte)realbinom((ushort)n.x14, k.x14));
                    Assert.AreEqual(c.x15, (byte)realbinom((ushort)n.x15, 0));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x0,  (byte)realbinom((ushort)n.x0,  1));
                    Assert.AreEqual(c.x1,  (byte)realbinom((ushort)n.x1,  1));
                    Assert.AreEqual(c.x2,  (byte)realbinom((ushort)n.x2,  1));
                    Assert.AreEqual(c.x3,  (byte)realbinom((ushort)n.x3,  1));
                    Assert.AreEqual(c.x4,  (byte)realbinom((ushort)n.x4,  1));
                    Assert.AreEqual(c.x5,  (byte)realbinom((ushort)n.x5,  1));
                    Assert.AreEqual(c.x6,  (byte)realbinom((ushort)n.x6,  1));
                    Assert.AreEqual(c.x7,  (byte)realbinom((ushort)n.x7,  1));
                    Assert.AreEqual(c.x8,  (byte)realbinom((ushort)n.x8,  1));
                    Assert.AreEqual(c.x9,  (byte)realbinom((ushort)n.x9,  1));
                    Assert.AreEqual(c.x10, (byte)realbinom((ushort)n.x10, 1));
                    Assert.AreEqual(c.x11, (byte)realbinom((ushort)n.x11, 1));
                    Assert.AreEqual(c.x12, (byte)realbinom((ushort)n.x12, 1));
                    Assert.AreEqual(c.x13, (byte)realbinom((ushort)n.x13, 1));
                    Assert.AreEqual(c.x14, (byte)realbinom((ushort)n.x14, 1));
                    Assert.AreEqual(c.x15, (byte)realbinom((ushort)n.x15, 1));
                    
                    c = maxmath.comb(new byte16(1), new byte16(0));
                    Assert.AreEqual(c.x0,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x1,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x2,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x3,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x4,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x5,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x6,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x7,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x8,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x9,  (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x10, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x11, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x12, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x13, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x14, (byte)realbinom((ushort)1, 0));
                    Assert.AreEqual(c.x15, (byte)realbinom((ushort)1, 0));
                    
                    c = maxmath.comb(new byte16(1), new byte16(1));
                    Assert.AreEqual(c.x0,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x1,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x2,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x3,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x4,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x5,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x6,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x7,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x8,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x9,  (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x10, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x11, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x12, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x13, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x14, (byte)realbinom((ushort)1, 1));
                    Assert.AreEqual(c.x15, (byte)realbinom((ushort)1, 1));
                }
                else
                {
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                    Assert.AreEqual(c.x1,  realbinom(n.x1,  k.x1));
                    Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                    Assert.AreEqual(c.x3,  realbinom(n.x3,  k.x3));
                    Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                    Assert.AreEqual(c.x5,  realbinom(n.x5,  k.x5));
                    Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                    Assert.AreEqual(c.x7,  realbinom(n.x7,  k.x7));
                    Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                    Assert.AreEqual(c.x9,  realbinom(n.x9,  k.x9));
                    Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                    Assert.AreEqual(c.x11, realbinom(n.x11, k.x11));
                    Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                    Assert.AreEqual(c.x13, realbinom(n.x13, k.x13));
                    Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                    Assert.AreEqual(c.x15, realbinom(n.x15, k.x15));
                    
                    c = maxmath.comb(n, k);
                    Assert.AreEqual(maxmath.comb(n, 0).x0,  realbinom(n.x0,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x1,  realbinom(n.x1,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x2,  realbinom(n.x2,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x3,  realbinom(n.x3,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x4,  realbinom(n.x4,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x5,  realbinom(n.x5,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x6,  realbinom(n.x6,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x7,  realbinom(n.x7,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x8,  realbinom(n.x8,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x9,  realbinom(n.x9,  0));
                    Assert.AreEqual(maxmath.comb(n, 0).x10, realbinom(n.x10, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x11, realbinom(n.x11, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x12, realbinom(n.x12, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x13, realbinom(n.x13, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x14, realbinom(n.x14, 0));
                    Assert.AreEqual(maxmath.comb(n, 0).x15, realbinom(n.x15, 0));
                    
                    c = maxmath.comb(n, new byte16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                    Assert.AreEqual(c.x0,  realbinom(n.x0,  0));
                    Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                    Assert.AreEqual(c.x2,  realbinom(n.x2,  0));
                    Assert.AreEqual(c.x3,  realbinom(n.x3,  1));
                    Assert.AreEqual(c.x4,  realbinom(n.x4,  0));
                    Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                    Assert.AreEqual(c.x6,  realbinom(n.x6,  0));
                    Assert.AreEqual(c.x7,  realbinom(n.x7,  1));
                    Assert.AreEqual(c.x8,  realbinom(n.x8,  0));
                    Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                    Assert.AreEqual(c.x10, realbinom(n.x10, 0));
                    Assert.AreEqual(c.x11, realbinom(n.x11, 1));
                    Assert.AreEqual(c.x12, realbinom(n.x12, 0));
                    Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                    Assert.AreEqual(c.x14, realbinom(n.x14, 0));
                    Assert.AreEqual(c.x15, realbinom(n.x15, 1));
                                         
                    c = maxmath.comb(n, new byte16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1));                    
                    Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                    Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                    Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                    Assert.AreEqual(c.x3,  realbinom(n.x3,  1));                
                    Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                    Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                    Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                    Assert.AreEqual(c.x7,  realbinom(n.x7,  1));                 
                    Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                    Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                    Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                    Assert.AreEqual(c.x11, realbinom(n.x11, 1));                
                    Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                    Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                    Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                    Assert.AreEqual(c.x15, realbinom(n.x15, 1));
                                          
                    c = maxmath.comb(n, new byte16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0));                   
                    Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                    Assert.AreEqual(c.x1,  realbinom(n.x1,  0));
                    Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                    Assert.AreEqual(c.x3,  realbinom(n.x3,  0));           
                    Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                    Assert.AreEqual(c.x5,  realbinom(n.x5,  0));
                    Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                    Assert.AreEqual(c.x7,  realbinom(n.x7,  0));       
                    Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                    Assert.AreEqual(c.x9,  realbinom(n.x9,  0));
                    Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                    Assert.AreEqual(c.x11, realbinom(n.x11, 0));           
                    Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                    Assert.AreEqual(c.x13, realbinom(n.x13, 0));
                    Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                    Assert.AreEqual(c.x15, realbinom(n.x15, 0));
                    
                    c = maxmath.comb(n, 1);
                    Assert.AreEqual(c.x0,  realbinom(n.x0,  1));
                    Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                    Assert.AreEqual(c.x2,  realbinom(n.x2,  1));
                    Assert.AreEqual(c.x3,  realbinom(n.x3,  1));
                    Assert.AreEqual(c.x4,  realbinom(n.x4,  1));
                    Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                    Assert.AreEqual(c.x6,  realbinom(n.x6,  1));
                    Assert.AreEqual(c.x7,  realbinom(n.x7,  1));
                    Assert.AreEqual(c.x8,  realbinom(n.x8,  1));
                    Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                    Assert.AreEqual(c.x10, realbinom(n.x10, 1));
                    Assert.AreEqual(c.x11, realbinom(n.x11, 1));
                    Assert.AreEqual(c.x12, realbinom(n.x12, 1));
                    Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                    Assert.AreEqual(c.x14, realbinom(n.x14, 1));
                    Assert.AreEqual(c.x15, realbinom(n.x15, 1));
                    
                    c = maxmath.comb(new byte16(1), new byte16(0));
                    Assert.AreEqual(c.x0,  realbinom(1, 0));
                    Assert.AreEqual(c.x1,  realbinom(1, 0));
                    Assert.AreEqual(c.x2,  realbinom(1, 0));
                    Assert.AreEqual(c.x3,  realbinom(1, 0));
                    Assert.AreEqual(c.x4,  realbinom(1, 0));
                    Assert.AreEqual(c.x5,  realbinom(1, 0));
                    Assert.AreEqual(c.x6,  realbinom(1, 0));
                    Assert.AreEqual(c.x7,  realbinom(1, 0));
                    Assert.AreEqual(c.x8,  realbinom(1, 0));
                    Assert.AreEqual(c.x9,  realbinom(1, 0));
                    Assert.AreEqual(c.x10, realbinom(1, 0));
                    Assert.AreEqual(c.x11, realbinom(1, 0));
                    Assert.AreEqual(c.x12, realbinom(1, 0));
                    Assert.AreEqual(c.x13, realbinom(1, 0));
                    Assert.AreEqual(c.x14, realbinom(1, 0));
                    Assert.AreEqual(c.x15, realbinom(1, 0));
                    
                    c = maxmath.comb(new byte16(1), new byte16(1));
                    Assert.AreEqual(c.x0,  realbinom(1, 1));
                    Assert.AreEqual(c.x1,  realbinom(1, 1));
                    Assert.AreEqual(c.x2,  realbinom(1, 1));
                    Assert.AreEqual(c.x3,  realbinom(1, 1));
                    Assert.AreEqual(c.x4,  realbinom(1, 1));
                    Assert.AreEqual(c.x5,  realbinom(1, 1));
                    Assert.AreEqual(c.x6,  realbinom(1, 1));
                    Assert.AreEqual(c.x7,  realbinom(1, 1));
                    Assert.AreEqual(c.x8,  realbinom(1, 1));
                    Assert.AreEqual(c.x9,  realbinom(1, 1));
                    Assert.AreEqual(c.x10, realbinom(1, 1));
                    Assert.AreEqual(c.x11, realbinom(1, 1));
                    Assert.AreEqual(c.x12, realbinom(1, 1));
                    Assert.AreEqual(c.x13, realbinom(1, 1));
                    Assert.AreEqual(c.x14, realbinom(1, 1));
                    Assert.AreEqual(c.x15, realbinom(1, 1));
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte32 n = rng.NextByte32(1, 64);
                byte32 k = n - 1;
                byte32 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x12, n.x12);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x14, n.x14);
                Assert.AreEqual(c.x15, n.x15);
                Assert.AreEqual(c.x16, n.x16);
                Assert.AreEqual(c.x17, n.x17);
                Assert.AreEqual(c.x18, n.x18);
                Assert.AreEqual(c.x19, n.x19);
                Assert.AreEqual(c.x20, n.x20);
                Assert.AreEqual(c.x21, n.x21);
                Assert.AreEqual(c.x22, n.x22);
                Assert.AreEqual(c.x23, n.x23);
                Assert.AreEqual(c.x24, n.x24);
                Assert.AreEqual(c.x25, n.x25);
                Assert.AreEqual(c.x26, n.x26);
                Assert.AreEqual(c.x27, n.x27);
                Assert.AreEqual(c.x28, n.x28);
                Assert.AreEqual(c.x29, n.x29);
                Assert.AreEqual(c.x30, n.x30);
                Assert.AreEqual(c.x31, n.x31);

                n = rng.NextByte32(1, byte.MaxValue);
                k = rng.NextByte32(0, maxmath.min(rng.NextByte32(1, byte.MaxValue), maxmath.subsaturated(n, 25)));
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  k.x1));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  k.x3));
                Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  k.x5));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  k.x7));
                Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  k.x9));
                Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                Assert.AreEqual(c.x11, realbinom(n.x11, k.x11));
                Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                Assert.AreEqual(c.x13, realbinom(n.x13, k.x13));
                Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                Assert.AreEqual(c.x15, realbinom(n.x15, k.x15));
                Assert.AreEqual(c.x16, realbinom(n.x16, k.x16));
                Assert.AreEqual(c.x17, realbinom(n.x17, k.x17));
                Assert.AreEqual(c.x18, realbinom(n.x18, k.x18));
                Assert.AreEqual(c.x19, realbinom(n.x19, k.x19));
                Assert.AreEqual(c.x20, realbinom(n.x20, k.x20));
                Assert.AreEqual(c.x21, realbinom(n.x21, k.x21));
                Assert.AreEqual(c.x22, realbinom(n.x22, k.x22));
                Assert.AreEqual(c.x23, realbinom(n.x23, k.x23));
                Assert.AreEqual(c.x24, realbinom(n.x24, k.x24));
                Assert.AreEqual(c.x25, realbinom(n.x25, k.x25));
                Assert.AreEqual(c.x26, realbinom(n.x26, k.x26));
                Assert.AreEqual(c.x27, realbinom(n.x27, k.x27));
                Assert.AreEqual(c.x28, realbinom(n.x28, k.x28));
                Assert.AreEqual(c.x29, realbinom(n.x29, k.x29));
                Assert.AreEqual(c.x30, realbinom(n.x30, k.x30));
                Assert.AreEqual(c.x31, realbinom(n.x31, k.x31));
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(maxmath.comb(n, 0).x0,  realbinom(n.x0,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x1,  realbinom(n.x1,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x2,  realbinom(n.x2,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x3,  realbinom(n.x3,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x4,  realbinom(n.x4,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x5,  realbinom(n.x5,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x6,  realbinom(n.x6,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x7,  realbinom(n.x7,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x8,  realbinom(n.x8,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x9,  realbinom(n.x9,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x10, realbinom(n.x10, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x11, realbinom(n.x11, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x12, realbinom(n.x12, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x13, realbinom(n.x13, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x14, realbinom(n.x14, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x15, realbinom(n.x15, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x16, realbinom(n.x16, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x17, realbinom(n.x17, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x18, realbinom(n.x18, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x19, realbinom(n.x19, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x20, realbinom(n.x20, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x21, realbinom(n.x21, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x22, realbinom(n.x22, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x23, realbinom(n.x23, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x24, realbinom(n.x24, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x25, realbinom(n.x25, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x26, realbinom(n.x26, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x27, realbinom(n.x27, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x28, realbinom(n.x28, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x29, realbinom(n.x29, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x30, realbinom(n.x30, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x31, realbinom(n.x31, 0));
                
                c = maxmath.comb(n, new byte32(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                Assert.AreEqual(c.x0,  realbinom(n.x0,  0));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  0));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  1));
                Assert.AreEqual(c.x4,  realbinom(n.x4,  0));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  0));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  1));
                Assert.AreEqual(c.x8,  realbinom(n.x8,  0));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                Assert.AreEqual(c.x10, realbinom(n.x10, 0));
                Assert.AreEqual(c.x11, realbinom(n.x11, 1));
                Assert.AreEqual(c.x12, realbinom(n.x12, 0));
                Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                Assert.AreEqual(c.x14, realbinom(n.x14, 0));
                Assert.AreEqual(c.x15, realbinom(n.x15, 1));
                Assert.AreEqual(c.x16, realbinom(n.x16, 0));
                Assert.AreEqual(c.x17, realbinom(n.x17, 1));
                Assert.AreEqual(c.x18, realbinom(n.x18, 0));
                Assert.AreEqual(c.x19, realbinom(n.x19, 1));
                Assert.AreEqual(c.x20, realbinom(n.x20, 0));
                Assert.AreEqual(c.x21, realbinom(n.x21, 1));
                Assert.AreEqual(c.x22, realbinom(n.x22, 0));
                Assert.AreEqual(c.x23, realbinom(n.x23, 1));
                Assert.AreEqual(c.x24, realbinom(n.x24, 0));
                Assert.AreEqual(c.x25, realbinom(n.x25, 1));
                Assert.AreEqual(c.x26, realbinom(n.x26, 0));
                Assert.AreEqual(c.x27, realbinom(n.x27, 1));
                Assert.AreEqual(c.x28, realbinom(n.x28, 0));
                Assert.AreEqual(c.x29, realbinom(n.x29, 1));
                Assert.AreEqual(c.x30, realbinom(n.x30, 0));
                Assert.AreEqual(c.x31, realbinom(n.x31, 1));
                                     
                c = maxmath.comb(n, new byte32(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1, k.x16, 1, k.x18, 1, k.x20, 1, k.x22, 1, k.x24, 1, k.x26, 1, k.x28, 1, k.x30, 1));                    
                Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  1));                
                Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  1));                 
                Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                Assert.AreEqual(c.x11, realbinom(n.x11, 1));                
                Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                Assert.AreEqual(c.x15, realbinom(n.x15, 1));         
                Assert.AreEqual(c.x16, realbinom(n.x16, k.x16));
                Assert.AreEqual(c.x17, realbinom(n.x17, 1));
                Assert.AreEqual(c.x18, realbinom(n.x18, k.x18));
                Assert.AreEqual(c.x19, realbinom(n.x19, 1));                
                Assert.AreEqual(c.x20, realbinom(n.x20, k.x20));
                Assert.AreEqual(c.x21, realbinom(n.x21, 1));
                Assert.AreEqual(c.x22, realbinom(n.x22, k.x22));
                Assert.AreEqual(c.x23, realbinom(n.x23, 1));                 
                Assert.AreEqual(c.x24, realbinom(n.x24, k.x24));
                Assert.AreEqual(c.x25, realbinom(n.x25, 1));
                Assert.AreEqual(c.x26, realbinom(n.x26, k.x26));
                Assert.AreEqual(c.x27, realbinom(n.x27, 1));                
                Assert.AreEqual(c.x28, realbinom(n.x28, k.x28));
                Assert.AreEqual(c.x29, realbinom(n.x29, 1));
                Assert.AreEqual(c.x30, realbinom(n.x30, k.x30));
                Assert.AreEqual(c.x31, realbinom(n.x31, 1));
                                      
                c = maxmath.comb(n, new byte32(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0, k.x16, 0, k.x18, 0, k.x20, 0, k.x22, 0, k.x24, 0, k.x26, 0, k.x28, 0, k.x30, 0));                   
                Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  0));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  0));           
                Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  0));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  0));       
                Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  0));
                Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                Assert.AreEqual(c.x11, realbinom(n.x11, 0));           
                Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                Assert.AreEqual(c.x13, realbinom(n.x13, 0));
                Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                Assert.AreEqual(c.x15, realbinom(n.x15, 0));                
                Assert.AreEqual(c.x16, realbinom(n.x16, k.x16));
                Assert.AreEqual(c.x17, realbinom(n.x17, 0));
                Assert.AreEqual(c.x18, realbinom(n.x18, k.x18));
                Assert.AreEqual(c.x19, realbinom(n.x19, 0));           
                Assert.AreEqual(c.x20, realbinom(n.x20, k.x20));
                Assert.AreEqual(c.x21, realbinom(n.x21, 0));
                Assert.AreEqual(c.x22, realbinom(n.x22, k.x22));
                Assert.AreEqual(c.x23, realbinom(n.x23, 0));       
                Assert.AreEqual(c.x24, realbinom(n.x24, k.x24));
                Assert.AreEqual(c.x25, realbinom(n.x25, 0));
                Assert.AreEqual(c.x26, realbinom(n.x26, k.x26));
                Assert.AreEqual(c.x27, realbinom(n.x27, 0));           
                Assert.AreEqual(c.x28, realbinom(n.x28, k.x28));
                Assert.AreEqual(c.x29, realbinom(n.x29, 0));
                Assert.AreEqual(c.x30, realbinom(n.x30, k.x30));
                Assert.AreEqual(c.x31, realbinom(n.x31, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x0,  realbinom(n.x0,  1));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  1));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  1));
                Assert.AreEqual(c.x4,  realbinom(n.x4,  1));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  1));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  1));
                Assert.AreEqual(c.x8,  realbinom(n.x8,  1));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                Assert.AreEqual(c.x10, realbinom(n.x10, 1));
                Assert.AreEqual(c.x11, realbinom(n.x11, 1));
                Assert.AreEqual(c.x12, realbinom(n.x12, 1));
                Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                Assert.AreEqual(c.x14, realbinom(n.x14, 1));
                Assert.AreEqual(c.x15, realbinom(n.x15, 1));
                Assert.AreEqual(c.x16, realbinom(n.x16, 1));
                Assert.AreEqual(c.x17, realbinom(n.x17, 1));
                Assert.AreEqual(c.x18, realbinom(n.x18, 1));
                Assert.AreEqual(c.x19, realbinom(n.x19, 1));
                Assert.AreEqual(c.x20, realbinom(n.x20, 1));
                Assert.AreEqual(c.x21, realbinom(n.x21, 1));
                Assert.AreEqual(c.x22, realbinom(n.x22, 1));
                Assert.AreEqual(c.x23, realbinom(n.x23, 1));
                Assert.AreEqual(c.x24, realbinom(n.x24, 1));
                Assert.AreEqual(c.x25, realbinom(n.x25, 1));
                Assert.AreEqual(c.x26, realbinom(n.x26, 1));
                Assert.AreEqual(c.x27, realbinom(n.x27, 1));
                Assert.AreEqual(c.x28, realbinom(n.x28, 1));
                Assert.AreEqual(c.x29, realbinom(n.x29, 1));
                Assert.AreEqual(c.x30, realbinom(n.x30, 1));
                Assert.AreEqual(c.x31, realbinom(n.x31, 1));
                
                c = maxmath.comb(new byte32(1), new byte32(0));
                Assert.AreEqual(c.x0,  realbinom(1, 0));
                Assert.AreEqual(c.x1,  realbinom(1, 0));
                Assert.AreEqual(c.x2,  realbinom(1, 0));
                Assert.AreEqual(c.x3,  realbinom(1, 0));
                Assert.AreEqual(c.x4,  realbinom(1, 0));
                Assert.AreEqual(c.x5,  realbinom(1, 0));
                Assert.AreEqual(c.x6,  realbinom(1, 0));
                Assert.AreEqual(c.x7,  realbinom(1, 0));
                Assert.AreEqual(c.x8,  realbinom(1, 0));
                Assert.AreEqual(c.x9,  realbinom(1, 0));
                Assert.AreEqual(c.x10, realbinom(1, 0));
                Assert.AreEqual(c.x11, realbinom(1, 0));
                Assert.AreEqual(c.x12, realbinom(1, 0));
                Assert.AreEqual(c.x13, realbinom(1, 0));
                Assert.AreEqual(c.x14, realbinom(1, 0));
                Assert.AreEqual(c.x15, realbinom(1, 0));
                Assert.AreEqual(c.x16, realbinom(1, 0));
                Assert.AreEqual(c.x17, realbinom(1, 0));
                Assert.AreEqual(c.x18, realbinom(1, 0));
                Assert.AreEqual(c.x19, realbinom(1, 0));
                Assert.AreEqual(c.x20, realbinom(1, 0));
                Assert.AreEqual(c.x21, realbinom(1, 0));
                Assert.AreEqual(c.x22, realbinom(1, 0));
                Assert.AreEqual(c.x23, realbinom(1, 0));
                Assert.AreEqual(c.x24, realbinom(1, 0));
                Assert.AreEqual(c.x25, realbinom(1, 0));
                Assert.AreEqual(c.x26, realbinom(1, 0));
                Assert.AreEqual(c.x27, realbinom(1, 0));
                Assert.AreEqual(c.x28, realbinom(1, 0));
                Assert.AreEqual(c.x29, realbinom(1, 0));
                Assert.AreEqual(c.x30, realbinom(1, 0));
                Assert.AreEqual(c.x31, realbinom(1, 0));
                
                c = maxmath.comb(new byte32(1), new byte32(1));
                Assert.AreEqual(c.x0,  realbinom(1, 1));
                Assert.AreEqual(c.x1,  realbinom(1, 1));
                Assert.AreEqual(c.x2,  realbinom(1, 1));
                Assert.AreEqual(c.x3,  realbinom(1, 1));
                Assert.AreEqual(c.x4,  realbinom(1, 1));
                Assert.AreEqual(c.x5,  realbinom(1, 1));
                Assert.AreEqual(c.x6,  realbinom(1, 1));
                Assert.AreEqual(c.x7,  realbinom(1, 1));
                Assert.AreEqual(c.x8,  realbinom(1, 1));
                Assert.AreEqual(c.x9,  realbinom(1, 1));
                Assert.AreEqual(c.x10, realbinom(1, 1));
                Assert.AreEqual(c.x11, realbinom(1, 1));
                Assert.AreEqual(c.x12, realbinom(1, 1));
                Assert.AreEqual(c.x13, realbinom(1, 1));
                Assert.AreEqual(c.x14, realbinom(1, 1));
                Assert.AreEqual(c.x15, realbinom(1, 1));
                Assert.AreEqual(c.x16, realbinom(1, 1));
                Assert.AreEqual(c.x17, realbinom(1, 1));
                Assert.AreEqual(c.x18, realbinom(1, 1));
                Assert.AreEqual(c.x19, realbinom(1, 1));
                Assert.AreEqual(c.x20, realbinom(1, 1));
                Assert.AreEqual(c.x21, realbinom(1, 1));
                Assert.AreEqual(c.x22, realbinom(1, 1));
                Assert.AreEqual(c.x23, realbinom(1, 1));
                Assert.AreEqual(c.x24, realbinom(1, 1));
                Assert.AreEqual(c.x25, realbinom(1, 1));
                Assert.AreEqual(c.x26, realbinom(1, 1));
                Assert.AreEqual(c.x27, realbinom(1, 1));
                Assert.AreEqual(c.x28, realbinom(1, 1));
                Assert.AreEqual(c.x29, realbinom(1, 1));
                Assert.AreEqual(c.x30, realbinom(1, 1));
                Assert.AreEqual(c.x31, realbinom(1, 1));
            }
        }

        
        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 18; i++)
            {
                ushort2 n = rng.NextUShort2(1, 128);
                ushort2 k = n - 1;
                ushort2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                
                n = rng.NextUShort2(1, ushort.MaxValue);
                k = rng.NextUShort2(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                
                c = maxmath.comb(n, 0);
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                
                c = maxmath.comb(n, new ushort2(0, 1));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(n, new ushort2(k.x, 1));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(n, new ushort2(k.x, 0));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(new ushort2(1), new ushort2(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                
                c = maxmath.comb(new ushort2(1), new ushort2(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3 n = rng.NextUShort3(1, 128);
                ushort3 k = n - 1;
                ushort3 c;
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                
                n = rng.NextUShort3(1, ushort.MaxValue);
                k = rng.NextUShort3(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                
                c = maxmath.comb(n, 0);
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                
                c = maxmath.comb(n, new ushort3(0, 1, 0));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                
                c = maxmath.comb(n, new ushort3(k.x, 1, k.z));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                
                c = maxmath.comb(n, new ushort3(k.x, 0, k.z));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 1));
                
                c = maxmath.comb(new ushort3(1), new ushort3(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                Assert.AreEqual(c.z, realbinom(1, 0));
                
                c = maxmath.comb(new ushort3(1), new ushort3(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
                Assert.AreEqual(c.z, realbinom(1, 1));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 14; i++)
            {
                ushort4 n = rng.NextUShort4(1, 128);
                ushort4 k = n - 1;
                ushort4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);
                
                n = rng.NextUShort4(1, ushort.MaxValue);
                k = rng.NextUShort4(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                Assert.AreEqual(c.w, realbinom(n.w, k.w));
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(maxmath.comb(n, 0).x, realbinom(n.x, 0));
                Assert.AreEqual(maxmath.comb(n, 0).y, realbinom(n.y, 0));
                Assert.AreEqual(maxmath.comb(n, 0).z, realbinom(n.z, 0));
                Assert.AreEqual(maxmath.comb(n, 0).w, realbinom(n.w, 0));
                
                c = maxmath.comb(n, new ushort4(0, 1, 0, 1));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                                     
                c = maxmath.comb(n, new ushort4(k.x, 1, k.z, 1));                    
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                                      
                c = maxmath.comb(n, new ushort4(k.x, 0, k.z, 0));                   
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                Assert.AreEqual(c.w, realbinom(n.w, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 1));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                
                c = maxmath.comb(new ushort4(1), new ushort4(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                Assert.AreEqual(c.z, realbinom(1, 0));
                Assert.AreEqual(c.w, realbinom(1, 0));
                
                c = maxmath.comb(new ushort4(1), new ushort4(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
                Assert.AreEqual(c.z, realbinom(1, 1));
                Assert.AreEqual(c.w, realbinom(1, 1));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort8 n = rng.NextUShort8(1, 128);
                ushort8 k = n - 1;
                ushort8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);
                
                n = rng.NextUShort8(1, ushort.MaxValue);
                k = rng.NextUShort8(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                Assert.AreEqual(c.x1, realbinom(n.x1, k.x1));
                Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                Assert.AreEqual(c.x3, realbinom(n.x3, k.x3));
                Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                Assert.AreEqual(c.x5, realbinom(n.x5, k.x5));
                Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                Assert.AreEqual(c.x7, realbinom(n.x7, k.x7));
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(maxmath.comb(n, 0).x0, realbinom(n.x0, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x1, realbinom(n.x1, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x2, realbinom(n.x2, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x3, realbinom(n.x3, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x4, realbinom(n.x4, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x5, realbinom(n.x5, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x6, realbinom(n.x6, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x7, realbinom(n.x7, 0));
                
                c = maxmath.comb(n, new ushort8(0, 1, 0, 1, 0, 1, 0, 1));
                Assert.AreEqual(c.x0, realbinom(n.x0, 0));
                Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                Assert.AreEqual(c.x2, realbinom(n.x2, 0));
                Assert.AreEqual(c.x3, realbinom(n.x3, 1));
                Assert.AreEqual(c.x4, realbinom(n.x4, 0));
                Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                Assert.AreEqual(c.x6, realbinom(n.x6, 0));
                Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                                     
                c = maxmath.comb(n, new ushort8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));                    
                Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                Assert.AreEqual(c.x3, realbinom(n.x3, 1));                
                Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                                      
                c = maxmath.comb(n, new ushort8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));                   
                Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                Assert.AreEqual(c.x1, realbinom(n.x1, 0));
                Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                Assert.AreEqual(c.x3, realbinom(n.x3, 0));           
                Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                Assert.AreEqual(c.x5, realbinom(n.x5, 0));
                Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                Assert.AreEqual(c.x7, realbinom(n.x7, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x0, realbinom(n.x0, 1));
                Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                Assert.AreEqual(c.x2, realbinom(n.x2, 1));
                Assert.AreEqual(c.x3, realbinom(n.x3, 1));
                Assert.AreEqual(c.x4, realbinom(n.x4, 1));
                Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                Assert.AreEqual(c.x6, realbinom(n.x6, 1));
                Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                
                c = maxmath.comb(new ushort8(1), new ushort8(0));
                Assert.AreEqual(c.x0, realbinom(1, 0));
                Assert.AreEqual(c.x1, realbinom(1, 0));
                Assert.AreEqual(c.x2, realbinom(1, 0));
                Assert.AreEqual(c.x3, realbinom(1, 0));
                Assert.AreEqual(c.x4, realbinom(1, 0));
                Assert.AreEqual(c.x5, realbinom(1, 0));
                Assert.AreEqual(c.x6, realbinom(1, 0));
                Assert.AreEqual(c.x7, realbinom(1, 0));
                
                c = maxmath.comb(new ushort8(1), new ushort8(1));
                Assert.AreEqual(c.x0, realbinom(1, 1));
                Assert.AreEqual(c.x1, realbinom(1, 1));
                Assert.AreEqual(c.x2, realbinom(1, 1));
                Assert.AreEqual(c.x3, realbinom(1, 1));
                Assert.AreEqual(c.x4, realbinom(1, 1));
                Assert.AreEqual(c.x5, realbinom(1, 1));
                Assert.AreEqual(c.x6, realbinom(1, 1));
                Assert.AreEqual(c.x7, realbinom(1, 1));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 10; i++)
            {
                ushort16 n = rng.NextUShort16(1, 128);
                ushort16 k = n - 1;
                ushort16 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x12, n.x12);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x14, n.x14);
                Assert.AreEqual(c.x15, n.x15);
                
                n = rng.NextUShort16(1, ushort.MaxValue);
                k = rng.NextUShort16(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  k.x1));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  k.x3));
                Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  k.x5));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  k.x7));
                Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  k.x9));
                Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                Assert.AreEqual(c.x11, realbinom(n.x11, k.x11));
                Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                Assert.AreEqual(c.x13, realbinom(n.x13, k.x13));
                Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                Assert.AreEqual(c.x15, realbinom(n.x15, k.x15));
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(maxmath.comb(n, 0).x0,  realbinom(n.x0,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x1,  realbinom(n.x1,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x2,  realbinom(n.x2,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x3,  realbinom(n.x3,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x4,  realbinom(n.x4,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x5,  realbinom(n.x5,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x6,  realbinom(n.x6,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x7,  realbinom(n.x7,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x8,  realbinom(n.x8,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x9,  realbinom(n.x9,  0));
                Assert.AreEqual(maxmath.comb(n, 0).x10, realbinom(n.x10, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x11, realbinom(n.x11, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x12, realbinom(n.x12, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x13, realbinom(n.x13, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x14, realbinom(n.x14, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x15, realbinom(n.x15, 0));
                
                c = maxmath.comb(n, new ushort16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                Assert.AreEqual(c.x0,  realbinom(n.x0,  0));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  0));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  1));
                Assert.AreEqual(c.x4,  realbinom(n.x4,  0));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  0));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  1));
                Assert.AreEqual(c.x8,  realbinom(n.x8,  0));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                Assert.AreEqual(c.x10, realbinom(n.x10, 0));
                Assert.AreEqual(c.x11, realbinom(n.x11, 1));
                Assert.AreEqual(c.x12, realbinom(n.x12, 0));
                Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                Assert.AreEqual(c.x14, realbinom(n.x14, 0));
                Assert.AreEqual(c.x15, realbinom(n.x15, 1));
                                     
                c = maxmath.comb(n, new ushort16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1));                    
                Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  1));                
                Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  1));                 
                Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                Assert.AreEqual(c.x11, realbinom(n.x11, 1));                
                Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                Assert.AreEqual(c.x15, realbinom(n.x15, 1));
                                      
                c = maxmath.comb(n, new ushort16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0));                   
                Assert.AreEqual(c.x0,  realbinom(n.x0,  k.x0));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  0));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  k.x2));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  0));           
                Assert.AreEqual(c.x4,  realbinom(n.x4,  k.x4));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  0));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  k.x6));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  0));       
                Assert.AreEqual(c.x8,  realbinom(n.x8,  k.x8));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  0));
                Assert.AreEqual(c.x10, realbinom(n.x10, k.x10));
                Assert.AreEqual(c.x11, realbinom(n.x11, 0));           
                Assert.AreEqual(c.x12, realbinom(n.x12, k.x12));
                Assert.AreEqual(c.x13, realbinom(n.x13, 0));
                Assert.AreEqual(c.x14, realbinom(n.x14, k.x14));
                Assert.AreEqual(c.x15, realbinom(n.x15, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x0,  realbinom(n.x0,  1));
                Assert.AreEqual(c.x1,  realbinom(n.x1,  1));
                Assert.AreEqual(c.x2,  realbinom(n.x2,  1));
                Assert.AreEqual(c.x3,  realbinom(n.x3,  1));
                Assert.AreEqual(c.x4,  realbinom(n.x4,  1));
                Assert.AreEqual(c.x5,  realbinom(n.x5,  1));
                Assert.AreEqual(c.x6,  realbinom(n.x6,  1));
                Assert.AreEqual(c.x7,  realbinom(n.x7,  1));
                Assert.AreEqual(c.x8,  realbinom(n.x8,  1));
                Assert.AreEqual(c.x9,  realbinom(n.x9,  1));
                Assert.AreEqual(c.x10, realbinom(n.x10, 1));
                Assert.AreEqual(c.x11, realbinom(n.x11, 1));
                Assert.AreEqual(c.x12, realbinom(n.x12, 1));
                Assert.AreEqual(c.x13, realbinom(n.x13, 1));
                Assert.AreEqual(c.x14, realbinom(n.x14, 1));
                Assert.AreEqual(c.x15, realbinom(n.x15, 1));
                
                c = maxmath.comb(new ushort16(1), new ushort16(0));
                Assert.AreEqual(c.x0,  realbinom(1, 0));
                Assert.AreEqual(c.x1,  realbinom(1, 0));
                Assert.AreEqual(c.x2,  realbinom(1, 0));
                Assert.AreEqual(c.x3,  realbinom(1, 0));
                Assert.AreEqual(c.x4,  realbinom(1, 0));
                Assert.AreEqual(c.x5,  realbinom(1, 0));
                Assert.AreEqual(c.x6,  realbinom(1, 0));
                Assert.AreEqual(c.x7,  realbinom(1, 0));
                Assert.AreEqual(c.x8,  realbinom(1, 0));
                Assert.AreEqual(c.x9,  realbinom(1, 0));
                Assert.AreEqual(c.x10, realbinom(1, 0));
                Assert.AreEqual(c.x11, realbinom(1, 0));
                Assert.AreEqual(c.x12, realbinom(1, 0));
                Assert.AreEqual(c.x13, realbinom(1, 0));
                Assert.AreEqual(c.x14, realbinom(1, 0));
                Assert.AreEqual(c.x15, realbinom(1, 0));
                
                c = maxmath.comb(new ushort16(1), new ushort16(1));
                Assert.AreEqual(c.x0,  realbinom(1, 1));
                Assert.AreEqual(c.x1,  realbinom(1, 1));
                Assert.AreEqual(c.x2,  realbinom(1, 1));
                Assert.AreEqual(c.x3,  realbinom(1, 1));
                Assert.AreEqual(c.x4,  realbinom(1, 1));
                Assert.AreEqual(c.x5,  realbinom(1, 1));
                Assert.AreEqual(c.x6,  realbinom(1, 1));
                Assert.AreEqual(c.x7,  realbinom(1, 1));
                Assert.AreEqual(c.x8,  realbinom(1, 1));
                Assert.AreEqual(c.x9,  realbinom(1, 1));
                Assert.AreEqual(c.x10, realbinom(1, 1));
                Assert.AreEqual(c.x11, realbinom(1, 1));
                Assert.AreEqual(c.x12, realbinom(1, 1));
                Assert.AreEqual(c.x13, realbinom(1, 1));
                Assert.AreEqual(c.x14, realbinom(1, 1));
                Assert.AreEqual(c.x15, realbinom(1, 1));
            }
        }
        

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 10; i++)
            {
                uint2 n = rng.NextUInt2(1, byte.MaxValue);
                uint2 k = n - 1;
                uint2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                
                n = rng.NextUInt2(1, uint.MaxValue);
                k = rng.NextUInt2(0, n + 1);
                k = math.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                
                c = maxmath.comb(n, 0);
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                
                c = maxmath.comb(n, new uint2(0, 1));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(n, new uint2(k.x, 1));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(n, new uint2(k.x, 0));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(new uint2(1), new uint2(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                
                c = maxmath.comb(new uint2(1), new uint2(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint3 n = rng.NextUInt3(1, byte.MaxValue);
                uint3 k = n - 1;
                uint3 c;
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                
                n = rng.NextUInt3(1, uint.MaxValue);
                k = rng.NextUInt3(0, n + 1);
                k = math.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                
                c = maxmath.comb(n, 0);
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                
                c = maxmath.comb(n, new uint3(0, 1, 0));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                
                c = maxmath.comb(n, new uint3(k.x, 1, k.z));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                
                c = maxmath.comb(n, new uint3(k.x, 0, k.z));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 1));
                
                c = maxmath.comb(new uint3(1), new uint3(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                Assert.AreEqual(c.z, realbinom(1, 0));
                
                c = maxmath.comb(new uint3(1), new uint3(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
                Assert.AreEqual(c.z, realbinom(1, 1));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 6; i++)
            {
                uint4 n = rng.NextUInt4(1, byte.MaxValue);
                uint4 k = n - 1;
                uint4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);
                
                n = rng.NextUInt4(1, uint.MaxValue);
                k = rng.NextUInt4(0, n + 1);
                k = math.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                Assert.AreEqual(c.w, realbinom(n.w, k.w));
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(maxmath.comb(n, 0).x, realbinom(n.x, 0));
                Assert.AreEqual(maxmath.comb(n, 0).y, realbinom(n.y, 0));
                Assert.AreEqual(maxmath.comb(n, 0).z, realbinom(n.z, 0));
                Assert.AreEqual(maxmath.comb(n, 0).w, realbinom(n.w, 0));
                
                c = maxmath.comb(n, new uint4(0, 1, 0, 1));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                                     
                c = maxmath.comb(n, new uint4(k.x, 1, k.z, 1));                    
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                                      
                c = maxmath.comb(n, new uint4(k.x, 0, k.z, 0));                   
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                Assert.AreEqual(c.w, realbinom(n.w, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 1));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                
                c = maxmath.comb(new uint4(1), new uint4(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                Assert.AreEqual(c.z, realbinom(1, 0));
                Assert.AreEqual(c.w, realbinom(1, 0));
                
                c = maxmath.comb(new uint4(1), new uint4(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
                Assert.AreEqual(c.z, realbinom(1, 1));
                Assert.AreEqual(c.w, realbinom(1, 1));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 4; i++)
            {
                uint8 n = rng.NextUInt8(1, byte.MaxValue);
                uint8 k = n - 1;
                uint8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);
                
                n = rng.NextUInt8(1, uint.MaxValue);
                k = rng.NextUInt8(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                Assert.AreEqual(c.x1, realbinom(n.x1, k.x1));
                Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                Assert.AreEqual(c.x3, realbinom(n.x3, k.x3));
                Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                Assert.AreEqual(c.x5, realbinom(n.x5, k.x5));
                Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                Assert.AreEqual(c.x7, realbinom(n.x7, k.x7));
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(maxmath.comb(n, 0).x0, realbinom(n.x0, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x1, realbinom(n.x1, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x2, realbinom(n.x2, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x3, realbinom(n.x3, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x4, realbinom(n.x4, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x5, realbinom(n.x5, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x6, realbinom(n.x6, 0));
                Assert.AreEqual(maxmath.comb(n, 0).x7, realbinom(n.x7, 0));
                
                c = maxmath.comb(n, new uint8(0, 1, 0, 1, 0, 1, 0, 1));
                Assert.AreEqual(c.x0, realbinom(n.x0, 0));
                Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                Assert.AreEqual(c.x2, realbinom(n.x2, 0));
                Assert.AreEqual(c.x3, realbinom(n.x3, 1));
                Assert.AreEqual(c.x4, realbinom(n.x4, 0));
                Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                Assert.AreEqual(c.x6, realbinom(n.x6, 0));
                Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                                     
                c = maxmath.comb(n, new uint8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));                    
                Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                Assert.AreEqual(c.x3, realbinom(n.x3, 1));                
                Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                                      
                c = maxmath.comb(n, new uint8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));                   
                Assert.AreEqual(c.x0, realbinom(n.x0, k.x0));
                Assert.AreEqual(c.x1, realbinom(n.x1, 0));
                Assert.AreEqual(c.x2, realbinom(n.x2, k.x2));
                Assert.AreEqual(c.x3, realbinom(n.x3, 0));           
                Assert.AreEqual(c.x4, realbinom(n.x4, k.x4));
                Assert.AreEqual(c.x5, realbinom(n.x5, 0));
                Assert.AreEqual(c.x6, realbinom(n.x6, k.x6));
                Assert.AreEqual(c.x7, realbinom(n.x7, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x0, realbinom(n.x0, 1));
                Assert.AreEqual(c.x1, realbinom(n.x1, 1));
                Assert.AreEqual(c.x2, realbinom(n.x2, 1));
                Assert.AreEqual(c.x3, realbinom(n.x3, 1));
                Assert.AreEqual(c.x4, realbinom(n.x4, 1));
                Assert.AreEqual(c.x5, realbinom(n.x5, 1));
                Assert.AreEqual(c.x6, realbinom(n.x6, 1));
                Assert.AreEqual(c.x7, realbinom(n.x7, 1));
                
                c = maxmath.comb(new uint8(1), new uint8(0));
                Assert.AreEqual(c.x0, realbinom(1, 0));
                Assert.AreEqual(c.x1, realbinom(1, 0));
                Assert.AreEqual(c.x2, realbinom(1, 0));
                Assert.AreEqual(c.x3, realbinom(1, 0));
                Assert.AreEqual(c.x4, realbinom(1, 0));
                Assert.AreEqual(c.x5, realbinom(1, 0));
                Assert.AreEqual(c.x6, realbinom(1, 0));
                Assert.AreEqual(c.x7, realbinom(1, 0));
                
                c = maxmath.comb(new uint8(1), new uint8(1));
                Assert.AreEqual(c.x0, realbinom(1, 1));
                Assert.AreEqual(c.x1, realbinom(1, 1));
                Assert.AreEqual(c.x2, realbinom(1, 1));
                Assert.AreEqual(c.x3, realbinom(1, 1));
                Assert.AreEqual(c.x4, realbinom(1, 1));
                Assert.AreEqual(c.x5, realbinom(1, 1));
                Assert.AreEqual(c.x6, realbinom(1, 1));
                Assert.AreEqual(c.x7, realbinom(1, 1));
            }
        }
        

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 10; i++)
            {
                ulong n = rng.NextULong(1, ulong.MaxValue);
                ulong k = n - 1;
                
                Assert.AreEqual(maxmath.comb(n, k), n);
                
                n = rng.NextULong(1, ulong.MaxValue);
                k = rng.NextULong(0, n + 1);
                k = math.select(k, n - 1000, n - k > 1000);
                
                Assert.AreEqual(maxmath.comb((ulong)n, (ulong)k), realbinom((ulong)n, (ulong)k));
                Assert.AreEqual(maxmath.comb((ulong)n, (ulong)0), realbinom((ulong)n, (ulong)0));
                Assert.AreEqual(maxmath.comb((ulong)n, (ulong)1), realbinom((ulong)n, (ulong)1));
                Assert.AreEqual(maxmath.comb((ulong)1, (ulong)0), realbinom((ulong)1, (ulong)0));
                Assert.AreEqual(maxmath.comb((ulong)1, (ulong)1), realbinom((ulong)1, (ulong)1));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                ulong2 n = rng.NextULong2(1, ulong.MaxValue);
                ulong2 k = n - 1;
                ulong2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                
                n = rng.NextULong2(1, ulong.MaxValue);
                k = rng.NextULong2(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                
                c = maxmath.comb(n, 0);
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                
                c = maxmath.comb(n, new ulong2(0, 1));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(n, new ulong2(k.x, 1));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(n, new ulong2(k.x, 0));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                
                c = maxmath.comb(new ulong2(1), new ulong2(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                
                c = maxmath.comb(new ulong2(1), new ulong2(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 6; i++)
            {
                ulong3 n = rng.NextULong3(1, ulong.MaxValue);
                ulong3 k = n - 1;
                ulong3 c;
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                
                n = rng.NextULong3(1, ulong.MaxValue);
                k = rng.NextULong3(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                
                c = maxmath.comb(n, 0);
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                
                c = maxmath.comb(n, new ulong3(0, 1, 0));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                
                c = maxmath.comb(n, new ulong3(k.x, 1, 0));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                
                c = maxmath.comb(n, new ulong3(k.x, 0, 1));
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, 1));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 1));
                
                c = maxmath.comb(new ulong3(1), new ulong3(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                Assert.AreEqual(c.z, realbinom(1, 0));
                
                c = maxmath.comb(new ulong3(1), new ulong3(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
                Assert.AreEqual(c.z, realbinom(1, 1));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 4; i++)
            {
                ulong4 n = rng.NextULong4(1, ulong.MaxValue);
                ulong4 k = n - 1;
                ulong4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextULong4(1, ulong.MaxValue);
                k = rng.NextULong4(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, k.y));
                Assert.AreEqual(c.z, realbinom(n.z, k.z));
                Assert.AreEqual(c.w, realbinom(n.w, k.w));
                
                c = maxmath.comb(n, k);
                Assert.AreEqual(maxmath.comb(n, 0).x, realbinom(n.x, 0));
                Assert.AreEqual(maxmath.comb(n, 0).y, realbinom(n.y, 0));
                Assert.AreEqual(maxmath.comb(n, 0).z, realbinom(n.z, 0));
                Assert.AreEqual(maxmath.comb(n, 0).w, realbinom(n.w, 0));
                
                c = maxmath.comb(n, new ulong4(0, 1, 0, 1));
                Assert.AreEqual(c.x, realbinom(n.x, 0));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                                     
                c = maxmath.comb(n, new ulong4(k.x, 1, 0, 1));                    
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 0));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                                      
                c = maxmath.comb(n, new ulong4(k.x, 0, 1, 0));                   
                Assert.AreEqual(c.x, realbinom(n.x, k.x));
                Assert.AreEqual(c.y, realbinom(n.y, 0));
                Assert.AreEqual(c.z, realbinom(n.z, 1));
                Assert.AreEqual(c.w, realbinom(n.w, 0));
                
                c = maxmath.comb(n, 1);
                Assert.AreEqual(c.x, realbinom(n.x, 1));
                Assert.AreEqual(c.y, realbinom(n.y, 1));
                Assert.AreEqual(c.z, realbinom(n.z, 1));
                Assert.AreEqual(c.w, realbinom(n.w, 1));
                
                c = maxmath.comb(new ulong4(1), new ulong4(0));
                Assert.AreEqual(c.x, realbinom(1, 0));
                Assert.AreEqual(c.y, realbinom(1, 0));
                Assert.AreEqual(c.z, realbinom(1, 0));
                Assert.AreEqual(c.w, realbinom(1, 0));
                
                c = maxmath.comb(new ulong4(1), new ulong4(1));
                Assert.AreEqual(c.x, realbinom(1, 1));
                Assert.AreEqual(c.y, realbinom(1, 1));
                Assert.AreEqual(c.z, realbinom(1, 1));
                Assert.AreEqual(c.w, realbinom(1, 1));
            }
        }
    }
}
