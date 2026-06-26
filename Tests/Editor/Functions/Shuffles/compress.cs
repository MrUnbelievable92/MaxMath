using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class f_compress
    {
        private const byte INIT_VALUE = 69;
        private const ushort INIT_VALUE_16 = (INIT_VALUE << 8) | INIT_VALUE;
        private const uint INIT_VALUE_32 = (INIT_VALUE_16 << 16) | INIT_VALUE_16;
        private const ulong INIT_VALUE_64 = ((ulong)INIT_VALUE_32 << 32) | INIT_VALUE_32;
        private const byte TEST_VALUE = 47;

        private static int IndexOfNthTrue(bool* bools, int n)
        {
            int i = 0;
            int count = 0;
            while (count != n)
            {
                if (bools[i++])
                {
                    count++;
                }
            }

            return i - 1;
        }

        private static void InitBuffer(byte* buffer, int count)
        {
            for (int i = 0; i < count; i++)
            {
                buffer[i] = INIT_VALUE;
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;
            
            byte* stack = stackalloc byte[2 * 2];

            InitBuffer(stack, 2 * 2 * sizeof(byte));
            int idx = math.compress(stack, 0, new byte2(TEST_VALUE), (bool2)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE);
            }
            
            InitBuffer(stack, 2 * 2 * sizeof(byte));
            idx = math.compress(stack, 0, new byte2(TEST_VALUE), (bool2)true);
            Assert.AreEqual(idx, 2);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer(stack, 2 * 2 * sizeof(byte));
                byte2 test = rng.NextByte2();
                bool2 testMask = rng.NextBool2();
                byte writeIdx = rng.NextByte(0, 2 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 2; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;
            
            byte* stack = stackalloc byte[2 * 3];

            InitBuffer(stack, 2 * 3 * sizeof(byte));
            int idx = math.compress(stack, 0, new byte3(TEST_VALUE), (bool3)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE);
            }
            
            InitBuffer(stack, 2 * 3 * sizeof(byte));
            idx = math.compress(stack, 0, new byte3(TEST_VALUE), (bool3)true);
            Assert.AreEqual(idx, 3);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer(stack, 2 * 3 * sizeof(byte));
                byte3 test = rng.NextByte3();
                bool3 testMask = rng.NextBool3();
                byte writeIdx = rng.NextByte(0, 3 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 3; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;
            
            byte* stack = stackalloc byte[2 * 4];

            InitBuffer(stack, 2 * 4 * sizeof(byte));
            int idx = math.compress(stack, 0, new byte4(TEST_VALUE), (bool4)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE);
            }
            
            InitBuffer(stack, 2 * 4 * sizeof(byte));
            idx = math.compress(stack, 0, new byte4(TEST_VALUE), (bool4)true);
            Assert.AreEqual(idx, 4);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer(stack, 2 * 4 * sizeof(byte));
                byte4 test = rng.NextByte4();
                bool4 testMask = rng.NextBool4();
                byte writeIdx = rng.NextByte(0, 4 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 4; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;
            
            byte* stack = stackalloc byte[2 * 8];

            InitBuffer(stack, 2 * 8 * sizeof(byte));
            int idx = math.compress(stack, 0, new byte8(TEST_VALUE), (bool8)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE);
            }
            
            InitBuffer(stack, 2 * 8 * sizeof(byte));
            idx = math.compress(stack, 0, new byte8(TEST_VALUE), (bool8)true);
            Assert.AreEqual(idx, 8);
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer(stack, 2 * 8 * sizeof(byte));
                byte8 test = rng.NextByte8();
                bool8 testMask = rng.NextBool8();
                byte writeIdx = rng.NextByte(0, 8 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 8; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;
            
            byte* stack = stackalloc byte[2 * 16];

            InitBuffer(stack, 2 * 16 * sizeof(byte));
            int idx = math.compress(stack, 0, new byte16(TEST_VALUE), (bool16)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE);
            }
            
            InitBuffer(stack, 2 * 16 * sizeof(byte));
            idx = math.compress(stack, 0, new byte16(TEST_VALUE), (bool16)true);
            Assert.AreEqual(idx, 16);
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer(stack, 2 * 16 * sizeof(byte));
                byte16 test = rng.NextByte16();
                bool16 testMask = rng.NextBool16();
                byte writeIdx = rng.NextByte(0, 16 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 16; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;
            
            byte* stack = stackalloc byte[2 * 32];

            InitBuffer(stack, 2 * 32 * sizeof(byte));
            int idx = math.compress(stack, 0, new byte32(TEST_VALUE), (bool32)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE);
            }
            
            InitBuffer(stack, 2 * 32 * sizeof(byte));
            idx = math.compress(stack, 0, new byte32(TEST_VALUE), (bool32)true);
            Assert.AreEqual(idx, 32);
            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer(stack, 2 * 32 * sizeof(byte));
                byte32 test = rng.NextByte32();
                bool32 testMask = rng.NextBool32();
                byte writeIdx = rng.NextByte(0, 32 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 32; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE);
                }
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;
            
            ushort* stack = stackalloc ushort[2 * 2];

            InitBuffer((byte*)stack, 2 * 2 * sizeof(ushort));
            int idx = math.compress(stack, 0, new ushort2(TEST_VALUE), (bool2)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_16);
            }
            
            InitBuffer((byte*)stack, 2 * 2 * sizeof(ushort));
            idx = math.compress(stack, 0, new ushort2(TEST_VALUE), (bool2)true);
            Assert.AreEqual(idx, 2);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 2 * sizeof(ushort));
                ushort2 test = rng.NextUShort2();
                bool2 testMask = rng.NextBool2();
                ushort writeIdx = rng.NextUShort(0, 2 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 2; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;
            
            ushort* stack = stackalloc ushort[2 * 3];

            InitBuffer((byte*)stack, 2 * 3 * sizeof(ushort));
            int idx = math.compress(stack, 0, new ushort3(TEST_VALUE), (bool3)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_16);
            }
            
            InitBuffer((byte*)stack, 2 * 3 * sizeof(ushort));
            idx = math.compress(stack, 0, new ushort3(TEST_VALUE), (bool3)true);
            Assert.AreEqual(idx, 3);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 3 * sizeof(ushort));
                ushort3 test = rng.NextUShort3();
                bool3 testMask = rng.NextBool3();
                ushort writeIdx = rng.NextUShort(0, 3 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 3; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;
            
            ushort* stack = stackalloc ushort[2 * 4];

            InitBuffer((byte*)stack, 2 * 4 * sizeof(ushort));
            int idx = math.compress(stack, 0, new ushort4(TEST_VALUE), (bool4)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_16);
            }
            
            InitBuffer((byte*)stack, 2 * 4 * sizeof(ushort));
            idx = math.compress(stack, 0, new ushort4(TEST_VALUE), (bool4)true);
            Assert.AreEqual(idx, 4);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 4 * sizeof(ushort));
                ushort4 test = rng.NextUShort4();
                bool4 testMask = rng.NextBool4();
                ushort writeIdx = rng.NextUShort(0, 4 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 4; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;
            
            ushort* stack = stackalloc ushort[2 * 8];

            InitBuffer((byte*)stack, 2 * 8 * sizeof(ushort));
            int idx = math.compress(stack, 0, new ushort8(TEST_VALUE), (bool8)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_16);
            }
            
            InitBuffer((byte*)stack, 2 * 8 * sizeof(ushort));
            idx = math.compress(stack, 0, new ushort8(TEST_VALUE), (bool8)true);
            Assert.AreEqual(idx, 8);
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 8 * sizeof(ushort));
                ushort8 test = rng.NextUShort8();
                bool8 testMask = rng.NextBool8();
                ushort writeIdx = rng.NextUShort(0, 8 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 8; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;
            
            ushort* stack = stackalloc ushort[2 * 16];

            InitBuffer((byte*)stack, 2 * 16 * sizeof(ushort));
            int idx = math.compress(stack, 0, new ushort16(TEST_VALUE), (bool16)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_16);
            }
            
            InitBuffer((byte*)stack, 2 * 16 * sizeof(ushort));
            idx = math.compress(stack, 0, new ushort16(TEST_VALUE), (bool16)true);
            Assert.AreEqual(idx, 16);
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 16 * sizeof(ushort));
                ushort16 test = rng.NextUShort16();
                bool16 testMask = rng.NextBool16();
                ushort writeIdx = rng.NextUShort(0, 16 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 16; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_16);
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;
            
            uint* stack = stackalloc uint[2 * 2];

            InitBuffer((byte*)stack, 2 * 2 * sizeof(uint));
            int idx = math.compress(stack, 0, new uint2(TEST_VALUE), (bool2)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_32);
            }
            
            InitBuffer((byte*)stack, 2 * 2 * sizeof(uint));
            idx = math.compress(stack, 0, new uint2(TEST_VALUE), (bool2)true);
            Assert.AreEqual(idx, 2);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 2 * sizeof(uint));
                uint2 test = rng.NextUInt2();
                bool2 testMask = rng.NextBool2();
                int writeIdx = rng.NextInt(0, 2 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_32);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 2; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_32);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;
            
            uint* stack = stackalloc uint[2 * 3];

            InitBuffer((byte*)stack, 2 * 3 * sizeof(uint));
            int idx = math.compress(stack, 0, new uint3(TEST_VALUE), (bool3)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_32);
            }
            
            InitBuffer((byte*)stack, 2 * 3 * sizeof(uint));
            idx = math.compress(stack, 0, new uint3(TEST_VALUE), (bool3)true);
            Assert.AreEqual(idx, 3);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 3 * sizeof(uint));
                uint3 test = rng.NextUInt3();
                bool3 testMask = rng.NextBool3();
                int writeIdx = rng.NextInt(0, 3 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_32);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 3; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_32);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;
            
            uint* stack = stackalloc uint[2 * 4];

            InitBuffer((byte*)stack, 2 * 4 * sizeof(uint));
            int idx = math.compress(stack, 0, new uint4(TEST_VALUE), (bool4)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_32);
            }
            
            InitBuffer((byte*)stack, 2 * 4 * sizeof(uint));
            idx = math.compress(stack, 0, new uint4(TEST_VALUE), (bool4)true);
            Assert.AreEqual(idx, 4);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 4 * sizeof(uint));
                uint4 test = rng.NextUInt4();
                bool4 testMask = rng.NextBool4();
                int writeIdx = rng.NextInt(0, 4 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_32);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 4; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_32);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;
            
            uint* stack = stackalloc uint[2 * 8];

            InitBuffer((byte*)stack, 2 * 8 * sizeof(uint));
            int idx = math.compress(stack, 0, new uint8(TEST_VALUE), (bool8)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_32);
            }
            
            InitBuffer((byte*)stack, 2 * 8 * sizeof(uint));
            idx = math.compress(stack, 0, new uint8(TEST_VALUE), (bool8)true);
            Assert.AreEqual(idx, 8);
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 8 * sizeof(uint));
                uint8 test = rng.NextUInt8();
                bool8 testMask = rng.NextBool8();
                int writeIdx = rng.NextInt(0, 8 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_32);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 8; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_32);
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;
            
            ulong* stack = stackalloc ulong[2 * 2];

            InitBuffer((byte*)stack, 2 * 2 * sizeof(ulong));
            int idx = math.compress(stack, 0, new ulong2(TEST_VALUE), (bool2)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_64);
            }
            
            InitBuffer((byte*)stack, 2 * 2 * sizeof(ulong));
            idx = math.compress(stack, 0, new ulong2(TEST_VALUE), (bool2)true);
            Assert.AreEqual(idx, 2);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 2 * sizeof(ulong));
                ulong2 test = rng.NextULong2();
                bool2 testMask = rng.NextBool2();
                int writeIdx = (int)rng.NextULong(0, 2 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_64);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 2; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_64);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;
            
            ulong* stack = stackalloc ulong[2 * 3];

            InitBuffer((byte*)stack, 2 * 3 * sizeof(ulong));
            int idx = math.compress(stack, 0, new ulong3(TEST_VALUE), (bool3)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_64);
            }
            
            InitBuffer((byte*)stack, 2 * 3 * sizeof(ulong));
            idx = math.compress(stack, 0, new ulong3(TEST_VALUE), (bool3)true);
            Assert.AreEqual(idx, 3);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 3 * sizeof(ulong));
                ulong3 test = rng.NextULong3();
                bool3 testMask = rng.NextBool3();
                int writeIdx = (int)rng.NextULong(0, 3 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_64);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 3; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_64);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;
            
            ulong* stack = stackalloc ulong[2 * 4];

            InitBuffer((byte*)stack, 2 * 4 * sizeof(ulong));
            int idx = math.compress(stack, 0, new ulong4(TEST_VALUE), (bool4)false);
            Assert.AreEqual(idx, 0);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stack[i], INIT_VALUE_64);
            }
            
            InitBuffer((byte*)stack, 2 * 4 * sizeof(ulong));
            idx = math.compress(stack, 0, new ulong4(TEST_VALUE), (bool4)true);
            Assert.AreEqual(idx, 4);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(stack[i], TEST_VALUE);
            }

            for (int i = 0; i < 64; i++)
            {
                InitBuffer((byte*)stack, 2 * 4 * sizeof(ulong));
                ulong4 test = rng.NextULong4();
                bool4 testMask = rng.NextBool4();
                int writeIdx = (int)rng.NextULong(0, 4 + 1);
                
                idx = math.compress(stack, writeIdx, test, testMask);
                Assert.AreEqual(idx, writeIdx + math.count(testMask));
                for (int k = 0; k < writeIdx; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_64);
                }
                for (int k = writeIdx; k < idx; k++)
                {
                    int tIdx = IndexOfNthTrue((bool*)&testMask, k - writeIdx + 1);
                    Assert.AreEqual(stack[k], test[tIdx]);
                }
                for (int k = idx; k < 2 * 4; k++)
                {
                    Assert.AreEqual(stack[k], INIT_VALUE_64);
                }
            }
        }
    }
}
