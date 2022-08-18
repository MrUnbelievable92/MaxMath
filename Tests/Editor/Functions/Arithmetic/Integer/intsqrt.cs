using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class intsqrt
    {
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

        //[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast)]
        //unsafe public struct a : IJob
        //{
        //    public NativeArray<int> ints;
        //
        //    public void Execute()
        //    {
        //        for (int i = 0; i < ints.Length; i++)
        //        {
        //            ints[i] = X86.Sse2.cvttps_epi32(X86.Sse.rcp_ss(X86.Sse.rsqrt_ss(X86.Sse2.cvtepi32_ps(X86.Sse2.cvtsi32_si128(ints[i]))))).SInt0;
        //        }
        //    }
        //}
        [Test]
        public static void byte2()
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

        [Test]
        public static void byte3()
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

        [Test]
        public static void byte4()
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

        [Test]
        public static void byte8()
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

        [Test]
        public static void byte16()
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

        [Test]
        public static void byte32()
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


        [Test]
        public static void uint128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                UInt128 x = rng.NextUInt128();

                Assert.AreEqual(_intsqrt(x), maxmath.intsqrt(x));
            }
        }


        [Test]
        public static void ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)_intsqrt(x.x), (ushort)_intsqrt(x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)_intsqrt(x.x), (ushort)_intsqrt(x.y), (ushort)_intsqrt(x.z)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)_intsqrt(x.x), (ushort)_intsqrt(x.y), (ushort)_intsqrt(x.z), (ushort)_intsqrt(x.w)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void ushort8()
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
        public static void ushort16()
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
        public static void uint2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();

                Assert.AreEqual(new uint2((uint)_intsqrt(x.x), (uint)_intsqrt(x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void uint3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();

                Assert.AreEqual(new uint3((uint)_intsqrt(x.x), (uint)_intsqrt(x.y), (uint)_intsqrt(x.z)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void uint4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();

                Assert.AreEqual(new uint4((uint)_intsqrt(x.x), (uint)_intsqrt(x.y), (uint)_intsqrt(x.z), (uint)_intsqrt(x.w)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void uint8()
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
        public static void ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)_intsqrt(x.x), (ulong)_intsqrt(x.y)), maxmath.intsqrt(x));
            }
        }

        [Test]
        public static void ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

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
        public static void ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)_intsqrt(x.x), (ulong)_intsqrt(x.y), (ulong)_intsqrt(x.z), (ulong)_intsqrt(x.w)), maxmath.intsqrt(x));
            }
        }
    }
}