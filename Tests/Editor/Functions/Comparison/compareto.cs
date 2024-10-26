using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_compareto
    {
        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 16; i++)
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
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 16; i++)
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
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte left = rng.NextByte();
                byte right = rng.NextByte();

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
        public static void _byte2()
        {
            Random8 rng = Random8.New;

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
        public static void _byte3()
        {
            Random8 rng = Random8.New;

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
        public static void _byte4()
        {
            Random8 rng = Random8.New;

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
        public static void _byte8()
        {
            Random8 rng = Random8.New;

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
        public static void _byte16()
        {
            Random8 rng = Random8.New;

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
        public static void _byte32()
        {
            Random8 rng = Random8.New;

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
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte left = rng.NextSByte();
                sbyte right = rng.NextSByte();

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
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

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
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

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
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

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
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

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
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

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
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

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
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort left = rng.NextUShort();
                ushort right = rng.NextUShort();

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
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

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
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

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
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

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
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

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
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

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
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short left = rng.NextShort();
                short right = rng.NextShort();

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
        public static void _short2()
        {
            Random16 rng = Random16.New;

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
        public static void _short3()
        {
            Random16 rng = Random16.New;

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
        public static void _short4()
        {
            Random16 rng = Random16.New;

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
        public static void _short8()
        {
            Random16 rng = Random16.New;

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
        public static void _short16()
        {
            Random16 rng = Random16.New;

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
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint left = rng.NextUInt();
                uint right = rng.NextUInt();

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
        public static void _uint2()
        {
            Random32 rng = Random32.New;

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
        public static void _uint3()
        {
            Random32 rng = Random32.New;

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
        public static void _uint4()
        {
            Random32 rng = Random32.New;

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
        public static void _uint8()
        {
            Random32 rng = Random32.New;

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
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int left = rng.NextInt();
                int right = rng.NextInt();

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
        public static void _int2()
        {
            Random32 rng = Random32.New;

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
        public static void _int3()
        {
            Random32 rng = Random32.New;

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
        public static void _int4()
        {
            Random32 rng = Random32.New;

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
        public static void _int8()
        {
            Random32 rng = Random32.New;

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
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong left = rng.NextULong();
                ulong right = rng.NextULong();

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
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

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
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

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
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

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
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long left = rng.NextLong();
                long right = rng.NextLong();

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
        public static void _long2()
        {
            Random64 rng = Random64.New;

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
        public static void _long3()
        {
            Random64 rng = Random64.New;

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
        public static void _long4()
        {
            Random64 rng = Random64.New;

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
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                quarter l = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);
                quarter r = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(((float)l).CompareTo(r), maxmath.compareto(l, r));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                quarter2 l = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);
                quarter2 r = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(((float)l[j]).CompareTo(r[j]), maxmath.compareto(l, r)[j]);
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                quarter3 l = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);
                quarter3 r = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(((float)l[j]).CompareTo(r[j]), maxmath.compareto(l, r)[j]);
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                quarter4 l = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);
                quarter4 r = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(((float)l[j]).CompareTo(r[j]), maxmath.compareto(l, r)[j]);
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                quarter8 l = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);
                quarter8 r = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(((float)l[j]).CompareTo(r[j]), maxmath.compareto(l, r)[j]);
                }
            }
        }

        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                half l = (half)rng.NextFloat(half.MinValue, half.MaxValue);
                half r = (half)rng.NextFloat(half.MinValue, half.MaxValue);

                Assert.AreEqual(((float)l).CompareTo(r), maxmath.compareto(l, r));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                half2 l = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);
                half2 r = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(((float)l[j]).CompareTo(r[j]), maxmath.compareto(l, r)[j]);
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                half3 l = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);
                half3 r = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(((float)l[j]).CompareTo(r[j]), maxmath.compareto(l, r)[j]);
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                half4 l = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);
                half4 r = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(((float)l[j]).CompareTo(r[j]), maxmath.compareto(l, r)[j]);
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                half8 l = (half8)rng.NextFloat8(half.MinValue, half.MaxValue);
                half8 r = (half8)rng.NextFloat8(half.MinValue, half.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(((float)l[j]).CompareTo(r[j]), maxmath.compareto(l, r)[j]);
                }
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                float l = rng.NextFloat(float.MinValue / 2, float.MaxValue / 2);
                float r = rng.NextFloat(float.MinValue / 2, float.MaxValue / 2);

                Assert.AreEqual(l.CompareTo(r), maxmath.compareto(l, r));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

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
        public static void _float3()
        {
            Random32 rng = Random32.New;

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
        public static void _float4()
        {
            Random32 rng = Random32.New;

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
        public static void _float8()
        {
            Random32 rng = Random32.New;

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
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 20; i++)
            {
                double l = rng.NextDouble(double.MinValue / 2, double.MaxValue / 2);
                double r = rng.NextDouble(double.MinValue / 2, double.MaxValue / 2);

                Assert.AreEqual(l.CompareTo(r), maxmath.compareto(l, r));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

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
        public static void _double3()
        {
            Random64 rng = Random64.New;

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
        public static void _double4()
        {
            Random64 rng = Random64.New;

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