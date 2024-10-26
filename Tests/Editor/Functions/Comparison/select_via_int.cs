using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;
using static Unity.Mathematics.math;

namespace MaxMath.Tests
{
    unsafe public static class f_select_via_int
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2 l = rng.NextByte2();
                byte2 r = rng.NextByte2();
                int b = ((Random32)rng).NextInt();

                byte2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3 l = rng.NextByte3();
                byte3 r = rng.NextByte3();
                int b = ((Random32)rng).NextInt();

                byte3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4 l = rng.NextByte4();
                byte4 r = rng.NextByte4();
                int b = ((Random32)rng).NextInt();

                byte4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte8 l = rng.NextByte8();
                byte8 r = rng.NextByte8();
                int b = ((Random32)rng).NextInt();

                byte8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte16 l = rng.NextByte16();
                byte16 r = rng.NextByte16();
                int b = ((Random32)rng).NextInt();

                byte16 test = select(l, r, b);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte32 l = rng.NextByte32();
                byte32 r = rng.NextByte32();
                int b = ((Random32)rng).NextInt();

                byte32 test = select(l, r, b);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort2 l = rng.NextUShort2();
                ushort2 r = rng.NextUShort2();
                int b = ((Random32)rng).NextInt();

                ushort2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3 l = rng.NextUShort3();
                ushort3 r = rng.NextUShort3();
                int b = ((Random32)rng).NextInt();

                ushort3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort4 l = rng.NextUShort4();
                ushort4 r = rng.NextUShort4();
                int b = ((Random32)rng).NextInt();

                ushort4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort8 l = rng.NextUShort8();
                ushort8 r = rng.NextUShort8();
                int b = ((Random32)rng).NextInt();

                ushort8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort16 l = rng.NextUShort16();
                ushort16 r = rng.NextUShort16();
                int b = ((Random32)rng).NextInt();

                ushort16 test = select(l, r, b);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint2 l = rng.NextUInt2();
                uint2 r = rng.NextUInt2();
                int b = ((Random32)rng).NextInt();

                uint2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint3 l = rng.NextUInt3();
                uint3 r = rng.NextUInt3();
                int b = ((Random32)rng).NextInt();

                uint3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint4 l = rng.NextUInt4();
                uint4 r = rng.NextUInt4();
                int b = ((Random32)rng).NextInt();

                uint4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint8 l = rng.NextUInt8();
                uint8 r = rng.NextUInt8();
                int b = ((Random32)rng).NextInt();

                uint8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2 l = rng.NextULong2();
                ulong2 r = rng.NextULong2();
                int b = ((Random32)rng).NextInt();

                ulong2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3 l = rng.NextULong3();
                ulong3 r = rng.NextULong3();
                int b = ((Random32)rng).NextInt();

                ulong3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong4 l = rng.NextULong4();
                ulong4 r = rng.NextULong4();
                int b = ((Random32)rng).NextInt();

                ulong4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2();
                int b = ((Random32)rng).NextInt();

                sbyte2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3();
                int b = ((Random32)rng).NextInt();

                sbyte3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4();
                int b = ((Random32)rng).NextInt();

                sbyte4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8();
                int b = ((Random32)rng).NextInt();

                sbyte8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16();
                int b = ((Random32)rng).NextInt();

                sbyte16 test = select(l, r, b);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32();
                int b = ((Random32)rng).NextInt();

                sbyte32 test = select(l, r, b);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2();
                int b = ((Random32)rng).NextInt();

                short2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3();
                int b = ((Random32)rng).NextInt();

                short3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4();
                int b = ((Random32)rng).NextInt();

                short4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8();
                int b = ((Random32)rng).NextInt();

                short8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16();
                int b = ((Random32)rng).NextInt();

                short16 test = select(l, r, b);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2();
                int b = ((Random32)rng).NextInt();

                int2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3();
                int b = ((Random32)rng).NextInt();

                int3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4();
                int b = ((Random32)rng).NextInt();

                int4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8();
                int b = ((Random32)rng).NextInt();

                int8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2();
                int b = ((Random32)rng).NextInt();

                long2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3();
                int b = ((Random32)rng).NextInt();

                long3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4();
                int b = ((Random32)rng).NextInt();

                long4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], testbit(b, j) ? r[j] : l[j]);
                }
            }
        }


        [Test]
        public static void _quarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                quarter2 l = asquarter(rng.NextSByte2());
                quarter2 r = asquarter(rng.NextSByte2());
                int b = ((Random32)rng).NextInt();

                quarter2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(asbyte(test[j]), asbyte(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                quarter3 l = asquarter(rng.NextSByte3());
                quarter3 r = asquarter(rng.NextSByte3());
                int b = ((Random32)rng).NextInt();

                quarter3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(asbyte(test[j]), asbyte(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                quarter4 l = asquarter(rng.NextSByte4());
                quarter4 r = asquarter(rng.NextSByte4());
                int b = ((Random32)rng).NextInt();

                quarter4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(asbyte(test[j]), asbyte(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                quarter8 l = asquarter(rng.NextSByte8());
                quarter8 r = asquarter(rng.NextSByte8());
                int b = ((Random32)rng).NextInt();

                quarter8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(asbyte(test[j]), asbyte(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }


        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                half2 l = ashalf(rng.NextShort2());
                half2 r = ashalf(rng.NextShort2());
                int b = ((Random32)rng).NextInt();

                half2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(asshort(test[j]), asshort(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                half3 l = ashalf(rng.NextShort3());
                half3 r = ashalf(rng.NextShort3());
                int b = ((Random32)rng).NextInt();

                half3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(asshort(test[j]), asshort(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                half4 l = ashalf(rng.NextShort4());
                half4 r = ashalf(rng.NextShort4());
                int b = ((Random32)rng).NextInt();

                half4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(asshort(test[j]), asshort(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                half8 l = ashalf(rng.NextShort8());
                half8 r = ashalf(rng.NextShort8());
                int b = ((Random32)rng).NextInt();

                half8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(asshort(test[j]), asshort(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }


        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float2 l = asfloat(rng.NextInt2());
                float2 r = asfloat(rng.NextInt2());
                int b = ((Random32)rng).NextInt();

                float2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(asint(test[j]), asint(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3 l = asfloat(rng.NextInt3());
                float3 r = asfloat(rng.NextInt3());
                int b = ((Random32)rng).NextInt();

                float3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(asint(test[j]), asint(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float4 l = asfloat(rng.NextInt4());
                float4 r = asfloat(rng.NextInt4());
                int b = ((Random32)rng).NextInt();

                float4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(asint(test[j]), asint(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float8 l = asfloat(rng.NextInt8());
                float8 r = asfloat(rng.NextInt8());
                int b = ((Random32)rng).NextInt();

                float8 test = select(l, r, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(asint(test[j]), asint(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }


        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double2 l = asdouble(rng.NextLong2());
                double2 r = asdouble(rng.NextLong2());
                int b = ((Random32)rng).NextInt();

                double2 test = select(l, r, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(aslong(test[j]), aslong(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3 l = asdouble(rng.NextLong3());
                double3 r = asdouble(rng.NextLong3());
                int b = ((Random32)rng).NextInt();

                double3 test = select(l, r, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(aslong(test[j]), aslong(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double4 l = asdouble(rng.NextLong4());
                double4 r = asdouble(rng.NextLong4());
                int b = ((Random32)rng).NextInt();

                double4 test = select(l, r, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(aslong(test[j]), aslong(testbit(b, j) ? r[j] : l[j]));
                }
            }
        }
    }
}