using NUnit.Framework;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Tests
{
    unsafe public static class f_intsqrt
    {
        //[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast)]
        //unsafe public struct a : IJob
        //{
        //    public NativeArray<int> ints;
        //
        //    public void _Execute()
        //    {
        //        for (int i = 0; i < ints.Length; i++)
        //        {
        //            ints[i] = X86.Sse2.cvttps_epi32(X86.Sse.rcp_ss(X86.Sse.rsqrt_ss(X86.Sse2.cvtepi32_ps(X86.Sse2.cvtsi32_si128(ints[i]))))).SInt0;
        //        }
        //    }
        //}

        public static ulong _intsqrt(UInt128 x)
        {
            UInt128 result = 0;
            UInt128 mask = (UInt128)1 << 126;

            while (mask > x)
            {
                mask >>= 2;
            }

            while (mask != 0)
            {
                UInt128 resultShifted = result >> 1;
                UInt128 resultAdded = result + mask;

                if (x >= resultAdded)
                {
                    x -= resultAdded;
                    result = resultShifted + mask;
                }
                else
                {
                    result = resultShifted;
                }

                mask >>= 2;
            }

            return result.lo64;
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                UInt128 x = rng.NextUInt128();

                Assert.AreEqual(_intsqrt(x), maxmath.intsqrt(x));

                x = rng.NextUInt128(0, 16);

                Assert.AreEqual(_intsqrt(x), maxmath.intsqrt(x));
            }
        }


        [Test]
        public static void _byte()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    byte x = rng.NextByte();

                    Assert.AreEqual((byte)_intsqrt(x), maxmath.intsqrt(x));
                }
            }
        }

        [Test]
        public static void _byte2()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    byte2 x = rng.NextByte2();
                    byte2 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 2; j++)
                    {
                        Assert.AreEqual((byte)_intsqrt(x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    byte3 x = rng.NextByte3();
                    byte3 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 3; j++)
                    {
                        Assert.AreEqual((byte)_intsqrt(x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    byte4 x = rng.NextByte4();
                    byte4 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 4; j++)
                    {
                        Assert.AreEqual((byte)_intsqrt(x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    byte8 x = rng.NextByte8();
                    byte8 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 8; j++)
                    {
                        Assert.AreEqual((byte)_intsqrt(x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    byte16 x = rng.NextByte16();
                    byte16 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 16; j++)
                    {
                        Assert.AreEqual((byte)_intsqrt(x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            if (Avx2.IsAvx2Supported)
            {

            }
            else if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    byte32 x = rng.NextByte32();
                    byte32 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 32; j++)
                    {
                        Assert.AreEqual((byte)_intsqrt(x[j]), sqrt[j]);
                    }
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort x = rng.NextUShort();

                Assert.AreEqual((ushort)_intsqrt(x), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)_intsqrt(x.x), (ushort)_intsqrt(x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)_intsqrt(x.x), (ushort)_intsqrt(x.y), (ushort)_intsqrt(x.z)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)_intsqrt(x.x), (ushort)_intsqrt(x.y), (ushort)_intsqrt(x.z), (ushort)_intsqrt(x.w)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)_intsqrt(x.x0),
                                            (ushort)_intsqrt(x.x1),
                                            (ushort)_intsqrt(x.x2),
                                            (ushort)_intsqrt(x.x3),
                                            (ushort)_intsqrt(x.x4),
                                            (ushort)_intsqrt(x.x5),
                                            (ushort)_intsqrt(x.x6),
                                            (ushort)_intsqrt(x.x7)),
                                maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)_intsqrt(x.x0),
                                             (ushort)_intsqrt(x.x1),
                                             (ushort)_intsqrt(x.x2),
                                             (ushort)_intsqrt(x.x3),
                                             (ushort)_intsqrt(x.x4),
                                             (ushort)_intsqrt(x.x5),
                                             (ushort)_intsqrt(x.x6),
                                             (ushort)_intsqrt(x.x7),
                                             (ushort)_intsqrt(x.x8),
                                             (ushort)_intsqrt(x.x9),
                                             (ushort)_intsqrt(x.x10),
                                             (ushort)_intsqrt(x.x11),
                                             (ushort)_intsqrt(x.x12),
                                             (ushort)_intsqrt(x.x13),
                                             (ushort)_intsqrt(x.x14),
                                             (ushort)_intsqrt(x.x15)),
                                maxmath.intsqrt(x));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                uint x = rng.NextUInt();

                Assert.AreEqual((uint)_intsqrt(x), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();

                Assert.AreEqual(new uint2((uint)_intsqrt(x.x), (uint)_intsqrt(x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();

                Assert.AreEqual(new uint3((uint)_intsqrt(x.x), (uint)_intsqrt(x.y), (uint)_intsqrt(x.z)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();

                Assert.AreEqual(new uint4((uint)_intsqrt(x.x), (uint)_intsqrt(x.y), (uint)_intsqrt(x.z), (uint)_intsqrt(x.w)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();

                Assert.AreEqual(new uint8((uint)_intsqrt(x.x0),
                                          (uint)_intsqrt(x.x1),
                                          (uint)_intsqrt(x.x2),
                                          (uint)_intsqrt(x.x3),
                                          (uint)_intsqrt(x.x4),
                                          (uint)_intsqrt(x.x5),
                                          (uint)_intsqrt(x.x6),
                                          (uint)_intsqrt(x.x7)),
                                maxmath.intsqrt(x));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong x = rng.NextULong();

                Assert.AreEqual((ulong)_intsqrt(x), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)_intsqrt(x.x), (ulong)_intsqrt(x.y)), maxmath.intsqrt(x));

                x = rng.NextULong2(0, 32);

                Assert.AreEqual(new ulong2((ulong)_intsqrt(x.x), (ulong)_intsqrt(x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)_intsqrt(x.x), (ulong)_intsqrt(x.y), (ulong)_intsqrt(x.z)), maxmath.intsqrt(x));

                x = rng.NextULong3(0, 32);

                Assert.AreEqual(new ulong3((ulong)_intsqrt(x.x), (ulong)_intsqrt(x.y), (ulong)_intsqrt(x.z)), maxmath.intsqrt(x));
            }

                ulong3 y = ulong.MaxValue;

                Assert.AreEqual(new ulong3((ulong)_intsqrt(y.x), (ulong)_intsqrt(y.y), (ulong)_intsqrt(y.z)), maxmath.intsqrt(y));
                y = 1ul << 63;

                Assert.AreEqual(new ulong3((ulong)_intsqrt(y.x), (ulong)_intsqrt(y.y), (ulong)_intsqrt(y.z)), maxmath.intsqrt(y));
                y = 1ul << 62;

                Assert.AreEqual(new ulong3((ulong)_intsqrt(y.x), (ulong)_intsqrt(y.y), (ulong)_intsqrt(y.z)), maxmath.intsqrt(y));
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)_intsqrt(x.x), (ulong)_intsqrt(x.y), (ulong)_intsqrt(x.z), (ulong)_intsqrt(x.w)), maxmath.intsqrt(x));

                x = rng.NextULong4(0, 32);

                Assert.AreEqual(new ulong4((ulong)_intsqrt(x.x), (ulong)_intsqrt(x.y), (ulong)_intsqrt(x.z), (ulong)_intsqrt(x.w)), maxmath.intsqrt(x));
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                Int128 x = rng.NextInt128(0, Int128.MaxValue);

                Assert.AreEqual(_intsqrt((UInt128)x), maxmath.intsqrt(x));

                x = rng.NextInt128(0, 16);

                Assert.AreEqual(_intsqrt((UInt128)x), maxmath.intsqrt(x));
            }
        }


        [Test]
        public static void _sbyte()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    sbyte x = rng.NextSByte(0, sbyte.MaxValue);

                    Assert.AreEqual((sbyte)_intsqrt((byte)x), maxmath.intsqrt(x));
                }
            }
        }

        [Test]
        public static void _sbyte2()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    sbyte2 x = rng.NextSByte2(0, sbyte.MaxValue);
                    sbyte2 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 2; j++)
                    {
                        Assert.AreEqual((sbyte)_intsqrt((byte)x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    sbyte3 x = rng.NextSByte3(0, sbyte.MaxValue);
                    sbyte3 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 3; j++)
                    {
                        Assert.AreEqual((sbyte)_intsqrt((byte)x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    sbyte4 x = rng.NextSByte4(0, sbyte.MaxValue);
                    sbyte4 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 4; j++)
                    {
                        Assert.AreEqual((sbyte)_intsqrt((byte)x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    sbyte8 x = rng.NextSByte8(0, sbyte.MaxValue);
                    sbyte8 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 8; j++)
                    {
                        Assert.AreEqual((sbyte)_intsqrt((byte)x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    sbyte16 x = rng.NextSByte16(0, sbyte.MaxValue);
                    sbyte16 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 16; j++)
                    {
                        Assert.AreEqual((sbyte)_intsqrt((byte)x[j]), sqrt[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            if (Avx2.IsAvx2Supported)
            {

            }
            else if (Sse2.IsSse2Supported)
            {
                //NativeArray<int> arr = new NativeArray<int>(256, Allocator.TempJob);
                //JobHandle j = new a { ints = arr }.Schedule();
                //JobHandle.ScheduleBatchedJobs();
                //j.Complete();
                //
                //int wrong = 0;
                //for (int i = 0; i < 256; i++)
                //{
                //    if (maxmath.intsqrt(i) != arr[i])
                //    {
                //        UnityEngine.Debug.Log("AT: " + i.ToString() + " EXPECTED: " + maxmath.intsqrt(i).ToString() + " ACTUAL: " + arr[i].ToString());
                //        wrong++;
                //    }
                //}
                //UnityEngine.Debug.Log(wrong);
            }
            else
            {
                Random8 rng = Random8.New;

                for (int i = 0; i < 64; i++)
                {
                    sbyte32 x = rng.NextSByte32(0, sbyte.MaxValue);
                    sbyte32 sqrt = maxmath.intsqrt(x);

                    for (int j = 0; j < 32; j++)
                    {
                        Assert.AreEqual((sbyte)_intsqrt((byte)x[j]), sqrt[j]);
                    }
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short x = rng.NextShort(0, short.MaxValue);

                Assert.AreEqual((short)_intsqrt((ushort)x), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2(0, short.MaxValue);

                Assert.AreEqual(new short2((short)_intsqrt((UInt128)x.x), (short)_intsqrt((UInt128)x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3(0, short.MaxValue);

                Assert.AreEqual(new short3((short)_intsqrt((UInt128)x.x), (short)_intsqrt((UInt128)x.y), (short)_intsqrt((UInt128)x.z)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4(0, short.MaxValue);

                Assert.AreEqual(new short4((short)_intsqrt((UInt128)x.x), (short)_intsqrt((UInt128)x.y), (short)_intsqrt((UInt128)x.z), (short)_intsqrt((UInt128)x.w)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8(0, short.MaxValue);

                Assert.AreEqual(new short8((short)_intsqrt((UInt128)x.x0),
                                           (short)_intsqrt((UInt128)x.x1),
                                           (short)_intsqrt((UInt128)x.x2),
                                           (short)_intsqrt((UInt128)x.x3),
                                           (short)_intsqrt((UInt128)x.x4),
                                           (short)_intsqrt((UInt128)x.x5),
                                           (short)_intsqrt((UInt128)x.x6),
                                           (short)_intsqrt((UInt128)x.x7)),
                                maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16(0, short.MaxValue);

                Assert.AreEqual(new short16((short)_intsqrt((UInt128)x.x0),
                                            (short)_intsqrt((UInt128)x.x1),
                                            (short)_intsqrt((UInt128)x.x2),
                                            (short)_intsqrt((UInt128)x.x3),
                                            (short)_intsqrt((UInt128)x.x4),
                                            (short)_intsqrt((UInt128)x.x5),
                                            (short)_intsqrt((UInt128)x.x6),
                                            (short)_intsqrt((UInt128)x.x7),
                                            (short)_intsqrt((UInt128)x.x8),
                                            (short)_intsqrt((UInt128)x.x9),
                                            (short)_intsqrt((UInt128)x.x10),
                                            (short)_intsqrt((UInt128)x.x11),
                                            (short)_intsqrt((UInt128)x.x12),
                                            (short)_intsqrt((UInt128)x.x13),
                                            (short)_intsqrt((UInt128)x.x14),
                                            (short)_intsqrt((UInt128)x.x15)),
                                maxmath.intsqrt(x));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int x = rng.NextInt(0, int.MaxValue);

                Assert.AreEqual((int)_intsqrt((uint)x), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2(0, int.MaxValue);

                Assert.AreEqual(new int2((int)_intsqrt((UInt128)x.x), (int)_intsqrt((UInt128)x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3(0, int.MaxValue);

                Assert.AreEqual(new int3((int)_intsqrt((UInt128)x.x), (int)_intsqrt((UInt128)x.y), (int)_intsqrt((UInt128)x.z)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4(0, int.MaxValue);

                Assert.AreEqual(new int4((int)_intsqrt((UInt128)x.x), (int)_intsqrt((UInt128)x.y), (int)_intsqrt((UInt128)x.z), (int)_intsqrt((UInt128)x.w)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int8 x = rng.NextInt8(0, int.MaxValue);

                Assert.AreEqual(new int8((int)_intsqrt((UInt128)x.x0),
                                         (int)_intsqrt((UInt128)x.x1),
                                         (int)_intsqrt((UInt128)x.x2),
                                         (int)_intsqrt((UInt128)x.x3),
                                         (int)_intsqrt((UInt128)x.x4),
                                         (int)_intsqrt((UInt128)x.x5),
                                         (int)_intsqrt((UInt128)x.x6),
                                         (int)_intsqrt((UInt128)x.x7)),
                                maxmath.intsqrt(x));
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                long x = rng.NextLong(0, long.MaxValue);

                Assert.AreEqual((long)_intsqrt((ulong)x), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2(0, long.MaxValue);

                Assert.AreEqual(new long2((long)_intsqrt((UInt128)x.x), (long)_intsqrt((UInt128)x.y)), maxmath.intsqrt(x));

                x = rng.NextLong2(0, 32);

                Assert.AreEqual(new long2((long)_intsqrt((UInt128)x.x), (long)_intsqrt((UInt128)x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3(0, long.MaxValue);

                Assert.AreEqual(new long3((long)_intsqrt((UInt128)x.x), (long)_intsqrt((UInt128)x.y), (long)_intsqrt((UInt128)x.z)), maxmath.intsqrt(x));

                x = rng.NextLong3(0, 32);

                Assert.AreEqual(new long3((long)_intsqrt((UInt128)x.x), (long)_intsqrt((UInt128)x.y), (long)_intsqrt((UInt128)x.z)), maxmath.intsqrt(x));
            }

                long3 y = long.MaxValue;

                Assert.AreEqual(new long3((long)_intsqrt((UInt128)y.x), (long)_intsqrt((UInt128)y.y), (long)_intsqrt((UInt128)y.z)), maxmath.intsqrt(y));
                y = 1u << 63;

                Assert.AreEqual(new long3((long)_intsqrt((UInt128)y.x), (long)_intsqrt((UInt128)y.y), (long)_intsqrt((UInt128)y.z)), maxmath.intsqrt(y));
                y = 1u << 62;

                Assert.AreEqual(new long3((long)_intsqrt((UInt128)y.x), (long)_intsqrt((UInt128)y.y), (long)_intsqrt((UInt128)y.z)), maxmath.intsqrt(y));
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4(0, long.MaxValue);

                Assert.AreEqual(new long4((long)_intsqrt((UInt128)x.x), (long)_intsqrt((UInt128)x.y), (long)_intsqrt((UInt128)x.z), (long)_intsqrt((UInt128)x.w)), maxmath.intsqrt(x));

                x = rng.NextLong4(0, 32);

                Assert.AreEqual(new long4((long)_intsqrt((UInt128)x.x), (long)_intsqrt((UInt128)x.y), (long)_intsqrt((UInt128)x.z), (long)_intsqrt((UInt128)x.w)), maxmath.intsqrt(x));
            }
        }
    }
}