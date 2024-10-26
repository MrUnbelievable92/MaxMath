using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.LUT.FACTORIAL;

namespace MaxMath.Tests
{
    public static class f_PROMISE_perm
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;
            byte2 n;
            byte2 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte2(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextByte2(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextByte2(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));

                n = rng.NextByte2(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe3));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;
            byte3 n;
            byte3 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte3(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextByte3(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextByte3(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));

                n = rng.NextByte3(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe3));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;
            byte4 n;
            byte4 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte4(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextByte4(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextByte4(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));

                n = rng.NextByte4(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe3));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;
            byte8 n;
            byte8 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte8(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextByte8(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextByte8(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));

                n = rng.NextByte8(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe3));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;
            byte16 n;
            byte16 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte16(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte16(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextByte16(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte16(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextByte16(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte16(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));

                n = rng.NextByte16(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte16(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe3));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;
            byte32 n;
            byte32 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte32(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte32(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextByte32(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte32(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextByte32(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte32(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));

                n = rng.NextByte32(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte32(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe3));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;
            ushort2 n;
            ushort2 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort2(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUShort2(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextUShort2(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;
            ushort3 n;
            ushort3 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort3(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUShort3(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextUShort3(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;
            ushort4 n;
            ushort4 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort4(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUShort4(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextUShort4(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;
            ushort8 n;
            ushort8 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort8(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUShort8(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextUShort8(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;
            ushort16 n;
            ushort16 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort16(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort16(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUShort16(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort16(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));

                n = rng.NextUShort16(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort16(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe2));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;
            uint n;
            uint k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUInt(0, MAX_INVERSE_FACTORIAL_U128 + 1);
                k = rng.NextUInt(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUInt(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;
            uint2 n;
            uint2 k;

            for (uint i = 0; i < 24; i++)
            {
                n = rng.NextUInt2(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUInt2(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;
            uint3 n;
            uint3 k;

            for (uint i = 0; i < 24; i++)
            {
                n = rng.NextUInt3(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUInt3(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;
            uint4 n;
            uint4 k;

            for (uint i = 0; i < 24; i++)
            {
                n = rng.NextUInt4(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUInt4(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;
            uint8 n;
            uint8 k;

            for (uint i = 0; i < 24; i++)
            {
                n = rng.NextUInt8(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUInt8(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt8(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;
            ulong n;
            ulong k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextULong(0, MAX_INVERSE_FACTORIAL_U128 + 1);
                k = rng.NextULong(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextULong(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextULong(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;
            ulong2 n;
            ulong2 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextULong2(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextULong2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextULong2(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextULong2(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;
            ulong3 n;
            ulong3 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextULong3(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextULong3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextULong3(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextULong3(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;
            ulong4 n;
            ulong4 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextULong4(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextULong4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextULong4(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextULong4(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;
            UInt128 n;
            UInt128 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUInt128(0, MAX_INVERSE_FACTORIAL_U128 + 1);
                k = rng.NextUInt128(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe0));

                n = rng.NextUInt128(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt128(0, n + 1);
                Assert.AreEqual(maxmath.perm(n, k), maxmath.perm(n, k, Promise.Unsafe1));
            }
        }
    }
}
