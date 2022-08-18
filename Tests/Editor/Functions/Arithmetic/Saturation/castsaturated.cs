#pragma warning disable CS0652

using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class SaturatedCast
    {
        #region To byte
        [Test]
        public static void sbytetobyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }

        [Test]
        public static void shorttobyte()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }
        
        [Test]
        public static void inttobyte()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }
        
        [Test]
        public static void longtobyte()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }
        
        [Test]
        public static void int128tobyte()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }


        [Test]
        public static void ushorttobyte()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }
        
        [Test]
        public static void uinttobyte()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }
        
        [Test]
        public static void ulongtobyte()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }
        
        [Test]
        public static void uint128tobyte()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }

        
        [Test]
        public static void quartertobyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter sb = new quarter(rng.NextByte());

                while (maxmath.isnan(sb))
                {
                    sb = new quarter(rng.NextByte());
                }

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }
        
        [Test]
        public static void halftobyte()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }
        
        [Test]
        public static void floattobyte()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }

        [Test]
        public static void doubletobyte()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb)); 
            }
        }


        [Test]
        public static void sbyte2tobyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short2tobyte2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int2tobyte2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2tobyte2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort2tobyte2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint2tobyte2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong2tobyte2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter2tobyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter2 sb = maxmath.asquarter(rng.NextByte2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half2tobyte2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float2tobyte2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2tobyte2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte3tobyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short3tobyte3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int3tobyte3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long3tobyte3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort3tobyte3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint3tobyte3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong3tobyte3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter3tobyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter3 sb = maxmath.asquarter(rng.NextByte3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half3tobyte3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float3tobyte3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3tobyte3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte4tobyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short4tobyte4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int4tobyte4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long4tobyte4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort4tobyte4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint4tobyte4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong4tobyte4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter4tobyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 sb = maxmath.asquarter(rng.NextByte4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half4tobyte4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4tobyte4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4tobyte4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte8tobyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 sb = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short8tobyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int8tobyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void ushort8tobyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint8tobyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void quarter8tobyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 sb = maxmath.asquarter(rng.NextByte8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half8tobyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float8tobyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte16tobyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte16 sb = rng.NextSByte16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short16tobyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 sb = rng.NextShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ushort16tobyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 sb = rng.NextUShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort8x2tobyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 _0 = rng.NextUShort8();
                ushort8 _1 = rng.NextUShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void short8x2tobyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 _0 = rng.NextShort8();
                short8 _1 = rng.NextShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }

        [Test]
        public static void ushort16x2tobyte32()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 _0 = rng.NextUShort16();
                ushort16 _1 = rng.NextUShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 16], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void short16x2tobyte32()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 _0 = rng.NextShort16();
                short16 _1 = rng.NextShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 16], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }

        [Test]
        public static void uint8x2tobyte16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void int8x2tobyte16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }

        [Test]
        public static void uint8x4tobyte32()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();
                uint8 _2 = rng.NextUInt8();
                uint8 _3 = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void int8x4tobyte32()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();
                int8 _2 = rng.NextInt8();
                int8 _3 = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
            }
        }

        [Test]
        public static void uint4x2tobyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 _0 = rng.NextUInt4();
                uint4 _1 = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void int4x2tobyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 _0 = rng.NextInt4();
                int4 _1 = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x2tobyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x2tobyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x4tobyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x4tobyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x8tobyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();
                ulong4 _4 = rng.NextULong4();
                ulong4 _5 = rng.NextULong4();
                ulong4 _6 = rng.NextULong4();
                ulong4 _7 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (byte)(_4[j] < byte.MinValue ? byte.MinValue : _4[j] > byte.MaxValue ? byte.MaxValue : (byte)_4[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (byte)(_5[j] < byte.MinValue ? byte.MinValue : _5[j] > byte.MaxValue ? byte.MaxValue : (byte)_5[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (byte)(_6[j] < byte.MinValue ? byte.MinValue : _6[j] > byte.MaxValue ? byte.MaxValue : (byte)_6[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (byte)(_7[j] < byte.MinValue ? byte.MinValue : _7[j] > byte.MaxValue ? byte.MaxValue : (byte)_7[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x8tobyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();
                long4 _4 = rng.NextLong4();
                long4 _5 = rng.NextLong4();
                long4 _6 = rng.NextLong4();
                long4 _7 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (byte)(_4[j] < byte.MinValue ? byte.MinValue : _4[j] > byte.MaxValue ? byte.MaxValue : (byte)_4[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (byte)(_5[j] < byte.MinValue ? byte.MinValue : _5[j] > byte.MaxValue ? byte.MaxValue : (byte)_5[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (byte)(_6[j] < byte.MinValue ? byte.MinValue : _6[j] > byte.MaxValue ? byte.MaxValue : (byte)_6[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (byte)(_7[j] < byte.MinValue ? byte.MinValue : _7[j] > byte.MaxValue ? byte.MaxValue : (byte)_7[j])); 
                }
            }
        }

        [Test]
        public static void quarter8x2tobyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void quarter8x4tobyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());
                quarter8 _2 = maxmath.asquarter(rng.NextByte8());
                quarter8 _3 = maxmath.asquarter(rng.NextByte8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_2[j]))
                    {
                        _2[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_3[j]))
                    {
                        _3[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void quarter4x2tobyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 _0 = maxmath.asquarter(rng.NextByte4());
                quarter4 _1 = maxmath.asquarter(rng.NextByte4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }


        [Test]
        public static void half8x2tobyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void half8x4tobyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());
                half8 _2 = maxmath.ashalf(rng.NextUShort8());
                half8 _3 = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_2[j]))
                    {
                        _2[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_3[j]))
                    {
                        _3[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void half4x2tobyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 _0 = maxmath.ashalf(rng.NextUShort4());
                half4 _1 = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }

        [Test]
        public static void float8x2tobyte16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void float8x4tobyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _2 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _3 = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void float4x2tobyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 _0 = rng.NextFloat4(float.MinValue, float.MaxValue);
                float4 _1 = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x2tobyte8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x4tobyte8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
            }
        }

        [Test]
        public static void double4x8tobyte8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _4 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _5 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _6 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _7 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (byte)(_4[j] < byte.MinValue ? byte.MinValue : _4[j] > byte.MaxValue ? byte.MaxValue : (byte)_4[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (byte)(_5[j] < byte.MinValue ? byte.MinValue : _5[j] > byte.MaxValue ? byte.MaxValue : (byte)_5[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (byte)(_6[j] < byte.MinValue ? byte.MinValue : _6[j] > byte.MaxValue ? byte.MaxValue : (byte)_6[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (byte)(_7[j] < byte.MinValue ? byte.MinValue : _7[j] > byte.MaxValue ? byte.MaxValue : (byte)_7[j])); 
                }
            }
        }
        #endregion

        #region To sbyte
        [Test]
        public static void bytetosbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte sb = rng.NextByte();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }

        [Test]
        public static void shorttosbyte()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }
        
        [Test]
        public static void inttosbyte()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }
        
        [Test]
        public static void longtosbyte()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }
        
        [Test]
        public static void int128tosbyte()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }


        [Test]
        public static void ushorttosbyte()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }
        
        [Test]
        public static void uinttosbyte()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }
        
        [Test]
        public static void ulongtosbyte()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)((Int128)sb < sbyte.MinValue ? sbyte.MinValue : (Int128)sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }
        
        [Test]
        public static void uint128tosbyte()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)((BigInteger)sb < sbyte.MinValue ? sbyte.MinValue : (BigInteger)sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }

        
        [Test]
        public static void halftosbyte()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }
        
        [Test]
        public static void floattosbyte()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }

        [Test]
        public static void doubletosbyte()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb)); 
            }
        }


        [Test]
        public static void byte2tosbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte2 sb = rng.NextByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short2tosbyte2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int2tosbyte2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2tosbyte2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort2tosbyte2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint2tosbyte2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong2tosbyte2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)((Int128)sb[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half2tosbyte2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float2tosbyte2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2tosbyte2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }


        [Test]
        public static void byte3tosbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte3 sb = rng.NextByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short3tosbyte3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int3tosbyte3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long3tosbyte3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort3tosbyte3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint3tosbyte3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong3tosbyte3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)((Int128)sb[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half3tosbyte3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float3tosbyte3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3tosbyte3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }


        [Test]
        public static void byte4tosbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte4 sb = rng.NextByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short4tosbyte4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int4tosbyte4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long4tosbyte4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort4tosbyte4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint4tosbyte4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong4tosbyte4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)((Int128)sb[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half4tosbyte4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4tosbyte4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4tosbyte4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }


        [Test]
        public static void byte8tosbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte8 sb = rng.NextByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short8tosbyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int8tosbyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void ushort8tosbyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint8tosbyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void half8tosbyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float8tosbyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }


        [Test]
        public static void byte16tosbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte16 sb = rng.NextByte16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }

        [Test]
        public static void short16tosbyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 sb = rng.NextShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ushort16tosbyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 sb = rng.NextUShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort8x2tosbyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 _0 = rng.NextUShort8();
                ushort8 _1 = rng.NextUShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void short8x2tosbyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 _0 = rng.NextShort8();
                short8 _1 = rng.NextShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }

        [Test]
        public static void ushort16x2tosbyte32()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 _0 = rng.NextUShort16();
                ushort16 _1 = rng.NextUShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 16], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void short16x2tosbyte32()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 _0 = rng.NextShort16();
                short16 _1 = rng.NextShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 16], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }

        [Test]
        public static void uint8x2tosbyte16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void int8x2tosbyte16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }

        [Test]
        public static void uint8x4tosbyte32()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();
                uint8 _2 = rng.NextUInt8();
                uint8 _3 = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void int8x4tosbyte32()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();
                int8 _2 = rng.NextInt8();
                int8 _3 = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
            }
        }

        [Test]
        public static void uint4x2tosbyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 _0 = rng.NextUInt4();
                uint4 _1 = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void int4x2tosbyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 _0 = rng.NextInt4();
                int4 _1 = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x2tosbyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)((Int128)_0[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)((Int128)_1[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x2tosbyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x4tosbyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)((Int128)_0[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 4], (sbyte)((Int128)_1[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)((Int128)_2[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 12], (sbyte)((Int128)_3[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x4tosbyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 12], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x8tosbyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();
                ulong4 _4 = rng.NextULong4();
                ulong4 _5 = rng.NextULong4();
                ulong4 _6 = rng.NextULong4();
                ulong4 _7 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (sbyte)((Int128)_0[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (sbyte)((Int128)_1[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (sbyte)((Int128)_2[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (sbyte)((Int128)_3[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (sbyte)((Int128)_4[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_4[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_4[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (sbyte)((Int128)_5[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_5[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_5[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (sbyte)((Int128)_6[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_6[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_6[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (sbyte)((Int128)_7[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_7[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_7[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x8tosbyte8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();
                long4 _4 = rng.NextLong4();
                long4 _5 = rng.NextLong4();
                long4 _6 = rng.NextLong4();
                long4 _7 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (sbyte)(_4[j] < sbyte.MinValue ? sbyte.MinValue : _4[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_4[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (sbyte)(_5[j] < sbyte.MinValue ? sbyte.MinValue : _5[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_5[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (sbyte)(_6[j] < sbyte.MinValue ? sbyte.MinValue : _6[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_6[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (sbyte)(_7[j] < sbyte.MinValue ? sbyte.MinValue : _7[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_7[j])); 
                }
            }
        }


        [Test]
        public static void quarter8x2tosbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void quarter8x4tosbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());
                quarter8 _2 = maxmath.asquarter(rng.NextByte8());
                quarter8 _3 = maxmath.asquarter(rng.NextByte8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_2[j]))
                    {
                        _2[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_3[j]))
                    {
                        _3[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void quarter4x2tosbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 _0 = maxmath.asquarter(rng.NextByte4());
                quarter4 _1 = maxmath.asquarter(rng.NextByte4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }


        [Test]
        public static void half8x2tosbyte16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void half8x4tosbyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());
                half8 _2 = maxmath.ashalf(rng.NextUShort8());
                half8 _3 = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_2[j]))
                    {
                        _2[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_3[j]))
                    {
                        _3[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void half4x2tosbyte8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 _0 = maxmath.ashalf(rng.NextUShort4());
                half4 _1 = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }

        [Test]
        public static void float8x2tosbyte16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void float8x4tosbyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _2 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _3 = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void float4x2tosbyte8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 _0 = rng.NextFloat4(float.MinValue, float.MaxValue);
                float4 _1 = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x2tosbyte8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x4tosbyte8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 12], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
            }
        }

        [Test]
        public static void double4x8tosbyte8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _4 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _5 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _6 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _7 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (sbyte)(_4[j] < sbyte.MinValue ? sbyte.MinValue : _4[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_4[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (sbyte)(_5[j] < sbyte.MinValue ? sbyte.MinValue : _5[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_5[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (sbyte)(_6[j] < sbyte.MinValue ? sbyte.MinValue : _6[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_6[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (sbyte)(_7[j] < sbyte.MinValue ? sbyte.MinValue : _7[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_7[j])); 
                }
            }
        }
        #endregion

        #region To ushort
        [Test]
        public static void sbytetoushort()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }

        [Test]
        public static void shorttoushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }
        
        [Test]
        public static void inttoushort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }
        
        [Test]
        public static void longtoushort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }
        
        [Test]
        public static void int128toushort()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }


        [Test]
        public static void ushorttoushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }
        
        [Test]
        public static void uinttoushort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }
        
        [Test]
        public static void ulongtoushort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }
        
        [Test]
        public static void uint128toushort()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }

        
        [Test]
        public static void quartertoushort()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter sb = new quarter(rng.NextByte());

                while (maxmath.isnan(sb))
                {
                    sb = new quarter(rng.NextByte());
                }

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }
        
        [Test]
        public static void halftoushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }
        
        [Test]
        public static void floattoushort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }

        [Test]
        public static void doubletoushort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb)); 
            }
        }


        [Test]
        public static void sbyte2toushort2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void short2toushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int2toushort2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2toushort2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void uint2toushort2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong2toushort2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter2toushort2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter2 sb = maxmath.asquarter(rng.NextByte2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half2toushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float2toushort2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2toushort2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte3toushort3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void short3toushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int3toushort3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long3toushort3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void uint3toushort3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong3toushort3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter3toushort3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter3 sb = maxmath.asquarter(rng.NextByte3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half3toushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float3toushort3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3toushort3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte4toushort4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void short4toushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int4toushort4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long4toushort4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void uint4toushort4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong4toushort4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter4toushort4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 sb = maxmath.asquarter(rng.NextByte4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half4toushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4toushort4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4toushort4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte8toushort8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 sb = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void short8toushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int8toushort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void uint8toushort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void quarter8toushort8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 sb = maxmath.asquarter(rng.NextByte8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half8toushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float8toushort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte16toushort16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte16 sb = rng.NextSByte16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }

        [Test]
        public static void short16toushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 sb = rng.NextShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void short8x2toushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 _0 = rng.NextShort8();
                short8 _1 = rng.NextShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }

        [Test]
        public static void uint8x2toushort16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void int8x2toushort16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }

        [Test]
        public static void uint4x2toushort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 _0 = rng.NextUInt4();
                uint4 _1 = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void int4x2toushort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 _0 = rng.NextInt4();
                int4 _1 = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x2toushort8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x2toushort8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x4toushort8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 8], (ushort)(_2[j] < ushort.MinValue ? ushort.MinValue : _2[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 12], (ushort)(_3[j] < ushort.MinValue ? ushort.MinValue : _3[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x4toushort8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 8], (ushort)(_2[j] < ushort.MinValue ? ushort.MinValue : _2[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 12], (ushort)(_3[j] < ushort.MinValue ? ushort.MinValue : _3[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_3[j])); 
                }
            }
        }

        [Test]
        public static void quarter8x2toushort16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void quarter4x2toushort8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 _0 = maxmath.asquarter(rng.NextByte4());
                quarter4 _1 = maxmath.asquarter(rng.NextByte4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }


        [Test]
        public static void half8x2toushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void half4x2toushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 _0 = maxmath.ashalf(rng.NextUShort4());
                half4 _1 = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }

        [Test]
        public static void float8x2toushort16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void float4x2toushort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 _0 = rng.NextFloat4(float.MinValue, float.MaxValue);
                float4 _1 = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x2toushort8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x4toushort8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 8], (ushort)(_2[j] < ushort.MinValue ? ushort.MinValue : _2[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 12], (ushort)(_3[j] < ushort.MinValue ? ushort.MinValue : _3[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_3[j])); 
                }
            }
        }
        #endregion

        #region To short
        [Test]
        public static void inttoshort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }
        
        [Test]
        public static void longtoshort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }
        
        [Test]
        public static void int128toshort()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }


        [Test]
        public static void ushorttoshort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }
        
        [Test]
        public static void uinttoshort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }
        
        [Test]
        public static void ulongtoshort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)((Int128)sb < short.MinValue ? short.MinValue : (Int128)sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }
        
        [Test]
        public static void uint128toshort()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)((BigInteger)sb < short.MinValue ? short.MinValue : (BigInteger)sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }

        
        [Test]
        public static void halftoshort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }
        
        [Test]
        public static void floattoshort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }

        [Test]
        public static void doubletoshort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb)); 
            }
        }


        [Test]
        public static void int2toshort2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2toshort2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort2toshort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint2toshort2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong2toshort2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)((Int128)sb[j] < short.MinValue ? short.MinValue : (Int128)sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half2toshort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float2toshort2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2toshort2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }


        [Test]
        public static void int3toshort3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long3toshort3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort3toshort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint3toshort3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong3toshort3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)((Int128)sb[j] < short.MinValue ? short.MinValue : (Int128)sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half3toshort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float3toshort3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3toshort3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }


        [Test]
        public static void int4toshort4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long4toshort4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort4toshort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint4toshort4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong4toshort4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)((Int128)sb[j] < short.MinValue ? short.MinValue : (Int128)sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half4toshort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4toshort4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4toshort4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }


        [Test]
        public static void int8toshort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }

        [Test]
        public static void ushort8toshort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint8toshort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void half8toshort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float8toshort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }


        [Test]
        public static void ushort16toshort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 sb = rng.NextUShort16();
                
                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void uint8x2toshort16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 8], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void int8x2toshort16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 8], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }

        [Test]
        public static void uint4x2toshort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 _0 = rng.NextUInt4();
                uint4 _1 = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void int4x2toshort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 _0 = rng.NextInt4();
                int4 _1 = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x2toshort8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)((Int128)_0[j] < short.MinValue ? short.MinValue : (Int128)_0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)((Int128)_1[j] < short.MinValue ? short.MinValue : (Int128)_1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x2toshort8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }

        [Test]
        public static void ulong4x4toshort8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j], (short)((Int128)_0[j] < short.MinValue ? short.MinValue : (Int128)_0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 4], (short)((Int128)_1[j] < short.MinValue ? short.MinValue : (Int128)_1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 8], (short)((Int128)_2[j] < short.MinValue ? short.MinValue : (Int128)_2[j] > short.MaxValue ? short.MaxValue : (short)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 12], (short)((Int128)_3[j] < short.MinValue ? short.MinValue : (Int128)_3[j] > short.MaxValue ? short.MaxValue : (short)_3[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x4toshort8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 8], (short)(_2[j] < short.MinValue ? short.MinValue : _2[j] > short.MaxValue ? short.MaxValue : (short)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 12], (short)(_3[j] < short.MinValue ? short.MinValue : _3[j] > short.MaxValue ? short.MaxValue : (short)_3[j])); 
                }
            }
        }


        [Test]
        public static void half8x2toshort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 8], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void half4x2toshort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 _0 = maxmath.ashalf(rng.NextUShort4());
                half4 _1 = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }

        [Test]
        public static void float8x2toshort16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 8], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void float4x2toshort8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 _0 = rng.NextFloat4(float.MinValue, float.MaxValue);
                float4 _1 = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x2toshort8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x4toshort8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 8], (short)(_2[j] < short.MinValue ? short.MinValue : _2[j] > short.MaxValue ? short.MaxValue : (short)_2[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 12], (short)(_3[j] < short.MinValue ? short.MinValue : _3[j] > short.MaxValue ? short.MaxValue : (short)_3[j])); 
                }
            }
        }
        #endregion

        #region To uint
        [Test]
        public static void sbytetouint()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }

        [Test]
        public static void shorttouint()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }
        
        [Test]
        public static void inttouint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }
        
        [Test]
        public static void longtouint()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }
        
        [Test]
        public static void int128touint()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }


        [Test]
        public static void ulongtouint()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }
        
        [Test]
        public static void uint128touint()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }

        
        [Test]
        public static void quartertouint()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter sb = new quarter(rng.NextByte());

                while (maxmath.isnan(sb))
                {
                    sb = new quarter(rng.NextByte());
                }

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }
        
        [Test]
        public static void halftouint()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }
        
        [Test]
        public static void floattouint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }

        [Test]
        public static void doubletouint()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb)); 
            }
        }


        [Test]
        public static void sbyte2touint2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        [Test]
        public static void short2touint2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int2touint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2touint2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ulong2touint2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter2touint2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter2 sb = maxmath.asquarter(rng.NextByte2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half2touint2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float2touint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2touint2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte3touint3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        [Test]
        public static void short3touint3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int3touint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long3touint3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void ulong3touint3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter3touint3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter3 sb = maxmath.asquarter(rng.NextByte3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half3touint3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float3touint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3touint3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte4touint4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        [Test]
        public static void short4touint4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int4touint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long4touint4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void ulong4touint4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter4touint4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 sb = maxmath.asquarter(rng.NextByte4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half4touint4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4touint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4touint4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte8touint8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 sb = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        [Test]
        public static void short8touint8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int8touint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }

        [Test]
        public static void quarter8touint8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 sb = maxmath.asquarter(rng.NextByte8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half8touint8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float8touint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j])); 
                }
            }
        }


        [Test]
        public static void ulong4x2touint8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j], (uint)(_0[j] < uint.MinValue ? uint.MinValue : _0[j] > uint.MaxValue ? uint.MaxValue : (uint)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j + 4], (uint)(_1[j] < uint.MinValue ? uint.MinValue : _1[j] > uint.MaxValue ? uint.MaxValue : (uint)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x2touint8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j], (uint)(_0[j] < uint.MinValue ? uint.MinValue : _0[j] > uint.MaxValue ? uint.MaxValue : (uint)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j + 4], (uint)(_1[j] < uint.MinValue ? uint.MinValue : _1[j] > uint.MaxValue ? uint.MaxValue : (uint)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x2touint8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j], (uint)(_0[j] < uint.MinValue ? uint.MinValue : _0[j] > uint.MaxValue ? uint.MaxValue : (uint)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j + 4], (uint)(_1[j] < uint.MinValue ? uint.MinValue : _1[j] > uint.MaxValue ? uint.MaxValue : (uint)_1[j])); 
                }
            }
        }
        #endregion

        #region To int
        [Test]
        public static void longtoint()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb)); 
            }
        }
        
        [Test]
        public static void int128toint()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb)); 
            }
        }


        [Test]
        public static void uinttoint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb)); 
            }
        }
        
        [Test]
        public static void ulongtoint()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)((Int128)sb < int.MinValue ? int.MinValue : (Int128)sb > int.MaxValue ? int.MaxValue : (int)sb)); 
            }
        }
        
        [Test]
        public static void uint128toint()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)((BigInteger)sb < int.MinValue ? int.MinValue : (BigInteger)sb > int.MaxValue ? int.MaxValue : (int)sb)); 
            }
        }

        
        [Test]
        public static void halftoint()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb)); 
            }
        }
        
        [Test]
        public static void floattoint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb)); 
            }
        }

        [Test]
        public static void doubletoint()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb)); 
            }
        }


        [Test]
        public static void int2toint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2toint2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void uint2toint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong2toint2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)((Int128)sb[j] < int.MinValue ? int.MinValue : (Int128)sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half2toint2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float2toint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2toint2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }


        [Test]
        public static void long3toint3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void uint3toint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong3toint3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)((Int128)sb[j] < int.MinValue ? int.MinValue : (Int128)sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half3toint3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float3toint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3toint3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }


        [Test]
        public static void long4toint4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void uint4toint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong4toint4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)((Int128)sb[j] < int.MinValue ? int.MinValue : (Int128)sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half4toint4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4toint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4toint4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }


        [Test]
        public static void uint8toint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void half8toint8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float8toint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j])); 
                }
            }
        }


        [Test]
        public static void ulong4x2toint8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j], (int)((Int128)_0[j] < int.MinValue ? int.MinValue : (Int128)_0[j] > int.MaxValue ? int.MaxValue : (int)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j + 4], (int)((Int128)_1[j] < int.MinValue ? int.MinValue : (Int128)_1[j] > int.MaxValue ? int.MaxValue : (int)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x2toint8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j], (int)(_0[j] < int.MinValue ? int.MinValue : _0[j] > int.MaxValue ? int.MaxValue : (int)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j + 4], (int)(_1[j] < int.MinValue ? int.MinValue : _1[j] > int.MaxValue ? int.MaxValue : (int)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x2toint8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j], (int)(_0[j] < int.MinValue ? int.MinValue : _0[j] > int.MaxValue ? int.MaxValue : (int)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j + 4], (int)(_1[j] < int.MinValue ? int.MinValue : _1[j] > int.MaxValue ? int.MaxValue : (int)_1[j])); 
                }
            }
        }
        #endregion
        
        #region To ulong
        [Test]
        public static void sbytetoulong()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)((Int128)sb < ulong.MinValue ? ulong.MinValue : (Int128)sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }

        [Test]
        public static void shorttoulong()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)((Int128)sb < ulong.MinValue ? ulong.MinValue : (Int128)sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }
        
        [Test]
        public static void inttoulong()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)((Int128)sb < ulong.MinValue ? ulong.MinValue : (Int128)sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }
        
        [Test]
        public static void longtoulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)((Int128)sb < ulong.MinValue ? ulong.MinValue : (Int128)sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }
        
        [Test]
        public static void int128toulong()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }


        [Test]
        public static void uint128toulong()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }

        
        [Test]
        public static void quartertoulong()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter sb = new quarter(rng.NextByte());

                while (maxmath.isnan(sb))
                {
                    sb = new quarter(rng.NextByte());
                }

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }
        
        [Test]
        public static void halftoulong()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }
        
        [Test]
        public static void floattoulong()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }

        [Test]
        public static void doubletoulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb)); 
            }
        }


        [Test]
        public static void sbyte2toulong2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }

        [Test]
        public static void short2toulong2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int2toulong2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2toulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void quarter2toulong2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter2 sb = maxmath.asquarter(rng.NextByte2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half2toulong2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float2toulong2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2toulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte3toulong3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }

        [Test]
        public static void short3toulong3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int3toulong3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long3toulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void quarter3toulong3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter3 sb = maxmath.asquarter(rng.NextByte3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half3toulong3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float3toulong3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3toulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte4toulong4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }

        [Test]
        public static void short4toulong4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int4toulong4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long4toulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void quarter4toulong4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 sb = maxmath.asquarter(rng.NextByte4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void half4toulong4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4toulong4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4toulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j])); 
                }
            }
        }
        #endregion

        #region To long
        [Test]
        public static void int128tolong()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)(sb < long.MinValue ? long.MinValue : sb > long.MaxValue ? long.MaxValue : (long)sb)); 
            }
        }

        [Test]
        public static void ulongtolong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)((Int128)sb < long.MinValue ? long.MinValue : (Int128)sb > long.MaxValue ? long.MaxValue : (long)sb)); 
            }
        }
        
        [Test]
        public static void uint128tolong()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)((BigInteger)sb < long.MinValue ? long.MinValue : (BigInteger)sb > long.MaxValue ? long.MaxValue : (long)sb)); 
            }
        }

        [Test]
        public static void floattolong()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)(sb < long.MinValue ? long.MinValue : sb > long.MaxValue ? long.MaxValue : (long)sb)); 
            }
        }

        [Test]
        public static void doubletolong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)(sb < long.MinValue ? long.MinValue : sb > long.MaxValue ? long.MaxValue : (long)sb)); 
            }
        }

        [Test]
        public static void ulong2tolong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)((Int128)sb[j] < long.MinValue ? long.MinValue : (Int128)sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }

        [Test]
        public static void float2tolong2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2tolong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }


        [Test]
        public static void ulong3tolong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)((Int128)sb[j] < long.MinValue ? long.MinValue : (Int128)sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }

        [Test]
        public static void float3tolong3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3tolong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }


        [Test]
        public static void ulong4tolong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)((Int128)sb[j] < long.MinValue ? long.MinValue : (Int128)sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half4tolong4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4tolong4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4tolong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j])); 
                }
            }
        }
        #endregion

        #region To UInt128
        [Test]
        public static void floattouint128()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.touint128saturated(sb), (UInt128)(sb < UInt128.MinValue ? UInt128.MinValue : (UInt128)sb)); 
            }
        }

        [Test]
        public static void doubletouint128()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.touint128saturated(sb), (UInt128)(sb < UInt128.MinValue ? UInt128.MinValue : sb > UInt128.MaxValue ? UInt128.MaxValue : (UInt128)sb)); 
            }
        }
        #endregion

        #region To Int128
        [Test]
        public static void floattoint128()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toint128saturated(sb), (Int128)(sb < Int128.MinValue ? Int128.MinValue : sb > Int128.MaxValue ? Int128.MaxValue : (Int128)sb)); 
            }
        }

        [Test]
        public static void doubletoint128()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toint128saturated(sb), (Int128)(sb < Int128.MinValue ? Int128.MinValue : sb > Int128.MaxValue ? Int128.MaxValue : (Int128)sb)); 
            }
        }
        #endregion


        #region To quarter
        [Test]
        public static void sbytetoquarter()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }
        
        [Test]
        public static void bytetoquarter()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte sb = rng.NextByte();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }

        [Test]
        public static void shorttoquarter()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }
        
        [Test]
        public static void inttoquarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }
        
        [Test]
        public static void longtoquarter()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }
        
        [Test]
        public static void int128toquarter()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }


        [Test]
        public static void ushorttoquarter()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }
        
        [Test]
        public static void uinttoquarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }
        
        [Test]
        public static void ulongtoquarter()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }
        
        [Test]
        public static void uint128toquarter()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }

        
        [Test]
        public static void halftoquarter()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }
        
        [Test]
        public static void floattoquarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }

        [Test]
        public static void doubletoquarter()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb)); 
            }
        }


        [Test]
        public static void sbyte2toquarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void byte2toquarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte2 sb = rng.NextByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void short2toquarter2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int2toquarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2toquarter2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort2toquarter2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint2toquarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong2toquarter2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half2toquarter2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());
                
                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float2toquarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2toquarter2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte3toquarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void byte3toquarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte3 sb = rng.NextByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void short3toquarter3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int3toquarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long3toquarter3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort3toquarter3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint3toquarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong3toquarter3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void half3toquarter3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());
                
                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float3toquarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3toquarter3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte4toquarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }


        [Test]
        public static void byte4toquarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte4 sb = rng.NextByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void short4toquarter4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int4toquarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long4toquarter4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort4toquarter4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint4toquarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong4toquarter4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void half4toquarter4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());
                
                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float4toquarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4toquarter4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }


        [Test]
        public static void sbyte8toquarter8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 sb = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void byte8toquarter8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte8 sb = rng.NextByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void short8toquarter8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void int8toquarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }

        [Test]
        public static void ushort8toquarter8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint8toquarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void half8toquarter8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());
                
                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void float8toquarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j])); 
                }
            }
        }


        [Test]
        public static void ulong4x2toquarter8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j], (quarter)(_0[j] < quarter.MinValue ? quarter.MinValue : _0[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j + 4], (quarter)(_1[j] < quarter.MinValue ? quarter.MinValue : _1[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x2toquarter8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j], (quarter)(_0[j] < quarter.MinValue ? quarter.MinValue : _0[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j + 4], (quarter)(_1[j] < quarter.MinValue ? quarter.MinValue : _1[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x2toquarter8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j], (quarter)(_0[j] < quarter.MinValue ? quarter.MinValue : _0[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j + 4], (quarter)(_1[j] < quarter.MinValue ? quarter.MinValue : _1[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_1[j])); 
                }
            }
        }
        #endregion

        #region To half
        [Test]
        public static void inttohalf()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }
        
        [Test]
        public static void longtohalf()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }
        
        [Test]
        public static void int128tohalf()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }


        [Test]
        public static void ushorttohalf()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }
        
        [Test]
        public static void uinttohalf()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }
        
        [Test]
        public static void ulongtohalf()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }
        
        [Test]
        public static void uint128tohalf()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }

        [Test]
        public static void floattohalf()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }

        [Test]
        public static void doubletohalf()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb)); 
            }
        }


        [Test]
        public static void int2tohalf2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long2tohalf2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort2tohalf2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint2tohalf2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong2tohalf2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void float2tohalf2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }

        [Test]
        public static void double2tohalf2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }


        [Test]
        public static void int3tohalf3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long3tohalf3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort3tohalf3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint3tohalf3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong3tohalf3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }


        [Test]
        public static void float3tohalf3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3tohalf3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void int4tohalf4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void long4tohalf4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        

        [Test]
        public static void ushort4tohalf4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint4tohalf4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void ulong4tohalf4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void float4tohalf4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4tohalf4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }

        
        [Test]
        public static void int8tohalf8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }

        [Test]
        public static void ushort8tohalf8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        [Test]
        public static void uint8tohalf8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }
        
        
        [Test]
        public static void float8tohalf8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);
                
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j])); 
                }
            }
        }


        [Test]
        public static void ulong4x2tohalf8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j], (half)(_0[j] < half.MinValue ? half.MinValue : _0[j] > half.MaxValue ? half.MaxValue : (half)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j + 4], (half)(_1[j] < half.MinValue ? half.MinValue : _1[j] > half.MaxValue ? half.MaxValue : (half)_1[j])); 
                }
            }
        }
        
        [Test]
        public static void long4x2tohalf8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j], (half)(_0[j] < half.MinValue ? half.MinValue : _0[j] > half.MaxValue ? half.MaxValue : (half)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j + 4], (half)(_1[j] < half.MinValue ? half.MinValue : _1[j] > half.MaxValue ? half.MaxValue : (half)_1[j])); 
                }
            }
        }

        [Test]
        public static void double4x2tohalf8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j], (half)(_0[j] < half.MinValue ? half.MinValue : _0[j] > half.MaxValue ? half.MaxValue : (half)_0[j])); 
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j + 4], (half)(_1[j] < half.MinValue ? half.MinValue : _1[j] > half.MaxValue ? half.MaxValue : (half)_1[j])); 
                }
            }
        }
        #endregion

        #region To float
        [Test]
        public static void uint128tofloat()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tofloatsaturated(sb), (math.isinf((float)sb) ? float.MaxValue : (float)sb));
            }
        }


        [Test]
        public static void doubletofloat()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tofloatsaturated(sb), (float)(sb < float.MinValue ? float.MinValue : sb > float.MaxValue ? float.MaxValue : (float)sb)); 
            }
        }


        [Test]
        public static void double2tofloat()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(sb)[j], (float)(sb[j] < float.MinValue ? float.MinValue : sb[j] > float.MaxValue ? float.MaxValue : (float)sb[j])); 
                }
            }
        }

        [Test]
        public static void double3tofloat()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(sb)[j], (float)(sb[j] < float.MinValue ? float.MinValue : sb[j] > float.MaxValue ? float.MaxValue : (float)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4tofloat()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(sb)[j], (float)(sb[j] < float.MinValue ? float.MinValue : sb[j] > float.MaxValue ? float.MaxValue : (float)sb[j])); 
                }
            }
        }

        [Test]
        public static void double4x2tofloat()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(_0)[j], (float)(_0[j] < float.MinValue ? float.MinValue : _0[j] > float.MaxValue ? float.MaxValue : (float)_0[j])); 
                }
                
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(_1)[j], (float)(_1[j] < float.MinValue ? float.MinValue : _1[j] > float.MaxValue ? float.MaxValue : (float)_1[j])); 
                }
            }
        }
        #endregion
    }
}