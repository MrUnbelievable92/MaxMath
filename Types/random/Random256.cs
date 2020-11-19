using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random256
    {
        public v256 state;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random256(ushort16 seed)
        {
Assert.IsTrue(maxmath.all_dif(seed, default(ushort16)));
Assert.IsTrue(maxmath.all_dif(seed));

            state = seed;

            NextState16();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort16 NextState16()
        {
Assert.IsTrue(maxmath.all_dif((ushort16)state, default(ushort16)));
Assert.IsTrue(maxmath.all_dif((ushort16)state));

            ushort16 t = state;

            state = X86.Avx2.mm256_xor_si256(state, X86.Avx2.mm256_slli_epi16(state, 7));
            state = X86.Avx2.mm256_xor_si256(state, X86.Avx2.mm256_srli_epi16(state, 9));
            state = X86.Avx2.mm256_xor_si256(state, X86.Avx2.mm256_slli_epi16(state, 13));

            return t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint8 NextState32()
        {
Assert.IsTrue(maxmath.all_dif((ushort16)state, default(ushort16)));
Assert.IsTrue(maxmath.all_dif((ushort16)state));

            fixed (void* ptr = &this)
            {
                uint8 t = *(uint8*)ptr;
                NextState16();

                t ^= t << 13;
                t ^= t >> 7;
                t ^= t << 5;

                return t;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong4 NextState64()
        {
Assert.IsTrue(maxmath.all_dif((ushort16)state, default(ushort16)));
Assert.IsTrue(maxmath.all_dif((ushort16)state));

            ulong4 t = state;
            NextState16();

            t ^= t << 13;
            t ^= t >> 7;
            t ^= t << 17;

            return t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32 NextBool32()
        {
            ulong4 result = (ulong4)(v256)NextState16() & 0x0101_0101_0101_0101ul;

            return *(bool32*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 NextShort16()
        {
            return short.MinValue ^ (short16)NextState16();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 NextShort16(short16 max)
        {
Assert.IsGreater<short>(max.x0, -1);
Assert.IsGreater<short>(max.x1, -1);
Assert.IsGreater<short>(max.x2, -1);
Assert.IsGreater<short>(max.x3, -1);
Assert.IsGreater<short>(max.x4, -1);
Assert.IsGreater<short>(max.x5, -1);
Assert.IsGreater<short>(max.x6, -1);
Assert.IsGreater<short>(max.x7, -1);
Assert.IsGreater<short>(max.x8, -1);
Assert.IsGreater<short>(max.x9, -1);
Assert.IsGreater<short>(max.x10, -1);
Assert.IsGreater<short>(max.x11, -1);
Assert.IsGreater<short>(max.x12, -1);
Assert.IsGreater<short>(max.x13, -1);
Assert.IsGreater<short>(max.x14, -1);
Assert.IsGreater<short>(max.x15, -1);

            return X86.Avx2.mm256_mulhi_epu16(NextShort16(), max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 NextShort8(short16 min, short16 max)
        {
Assert.IsNotSmaller<short>(max.x0, min.x0);
Assert.IsNotSmaller<short>(max.x1, min.x1);
Assert.IsNotSmaller<short>(max.x2, min.x2);
Assert.IsNotSmaller<short>(max.x3, min.x3);
Assert.IsNotSmaller<short>(max.x4, min.x4);
Assert.IsNotSmaller<short>(max.x5, min.x5);
Assert.IsNotSmaller<short>(max.x6, min.x6);
Assert.IsNotSmaller<short>(max.x7, min.x7);
Assert.IsNotSmaller<short>(max.x8, min.x8);
Assert.IsNotSmaller<short>(max.x9, min.x9);
Assert.IsNotSmaller<short>(max.x10, min.x10);
Assert.IsNotSmaller<short>(max.x11, min.x11);
Assert.IsNotSmaller<short>(max.x12, min.x12);
Assert.IsNotSmaller<short>(max.x13, min.x13);
Assert.IsNotSmaller<short>(max.x14, min.x14);
Assert.IsNotSmaller<short>(max.x15, min.x15);

            max -= min;

            return X86.Avx2.mm256_mulhi_epu16(NextShort16(), max) + min;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16()
        {
            return NextState16() - 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16(ushort16 max)
        {
            return X86.Avx2.mm256_mulhi_epu16(NextUShort16(), max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16(ushort16 min, ushort16 max)
        {
Assert.IsNotSmaller<ushort>(max.x0, min.x0);
Assert.IsNotSmaller<ushort>(max.x1, min.x1);
Assert.IsNotSmaller<ushort>(max.x2, min.x2);
Assert.IsNotSmaller<ushort>(max.x3, min.x3);
Assert.IsNotSmaller<ushort>(max.x4, min.x4);
Assert.IsNotSmaller<ushort>(max.x5, min.x5);
Assert.IsNotSmaller<ushort>(max.x6, min.x6);
Assert.IsNotSmaller<ushort>(max.x7, min.x7);
Assert.IsNotSmaller<ushort>(max.x8, min.x8);
Assert.IsNotSmaller<ushort>(max.x9, min.x9);
Assert.IsNotSmaller<ushort>(max.x10, min.x10);
Assert.IsNotSmaller<ushort>(max.x11, min.x11);
Assert.IsNotSmaller<ushort>(max.x12, min.x12);
Assert.IsNotSmaller<ushort>(max.x13, min.x13);
Assert.IsNotSmaller<ushort>(max.x14, min.x14);
Assert.IsNotSmaller<ushort>(max.x15, min.x15);

            max -= min;

            return X86.Avx2.mm256_mulhi_epu16(NextUShort16(), max) + min;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3()
        {
            return (int.MinValue ^ (int8)NextState32()).v3_0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3(long3 max)
        {
Assert.IsGreater<long>(max.x, -1);
Assert.IsGreater<long>(max.y, -1);
Assert.IsGreater<long>(max.z, -1);

            uint8 n = NextState32();
            ulong4 t = X86.Avx2.mm256_mul_epu32(*(v256*)&n, max);
            t = X86.Avx2.mm256_permutevar8x32_epi32(t, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(int3*)&t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3(long3 min, long3 max)
        {
Assert.IsNotSmaller<long>(max.x, min.x);
Assert.IsNotSmaller<long>(max.y, min.y);
Assert.IsNotSmaller<long>(max.z, min.z);

            max -= min;
            uint8 n = NextState32();
            ulong4 t = X86.Avx2.mm256_mul_epu32(*(v256*)&n, max);
            t = X86.Avx2.mm256_permutevar8x32_epi32(t, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(int3*)&t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3()
        {
            return (NextState32() - 1u).v3_0;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(ulong3 max)
        {
            uint8 n = NextState32();
            ulong4 t = X86.Avx2.mm256_mul_epu32(*(v256*)&n, max);
            t = X86.Avx2.mm256_permutevar8x32_epi32(t, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(uint3*)&t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(ulong3 min, ulong3 max)
        {
Assert.IsNotSmaller<ulong>(max.x, min.x);
Assert.IsNotSmaller<ulong>(max.y, min.y);
Assert.IsNotSmaller<ulong>(max.z, min.z);

            max -= min;
            uint8 n = NextState32();
            ulong4 t = X86.Avx2.mm256_mul_epu32(*(v256*)&n, max);
            t = X86.Avx2.mm256_permutevar8x32_epi32(t, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(uint3*)&t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4()
        {
            return (int.MinValue ^ (int8)NextState32()).v4_0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4(long4 max)
        {
Assert.IsGreater<long>(max.x, -1);
Assert.IsGreater<long>(max.y, -1);
Assert.IsGreater<long>(max.z, -1);
Assert.IsGreater<long>(max.w, -1);

            uint8 n = NextState32();
            ulong4 t = X86.Avx2.mm256_mul_epu32(*(v256*)&n, max);
            t = X86.Avx2.mm256_permutevar8x32_epi32(t, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(int4*)&t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4(long4 min, long4 max)
        {
Assert.IsNotSmaller<long>(max.x, min.x);
Assert.IsNotSmaller<long>(max.y, min.y);
Assert.IsNotSmaller<long>(max.z, min.z);
Assert.IsNotSmaller<long>(max.w, min.w);

            max -= min;
            uint8 n = NextState32();
            ulong4 t = X86.Avx2.mm256_mul_epu32(*(v256*)&n, max);
            t = X86.Avx2.mm256_permutevar8x32_epi32(t, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(int4*)&t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4()
        {
            return NextState32().v4_0 - 1u;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(ulong4 max)
        {
            uint8 n = NextState32();
            ulong4 t = X86.Avx2.mm256_mul_epu32(*(v256*)&n, max);
            t = X86.Avx2.mm256_permutevar8x32_epi32(t, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(uint4*)&t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(ulong4 min, ulong4 max)
        {
Assert.IsNotSmaller<ulong>(max.x, min.x);
Assert.IsNotSmaller<ulong>(max.y, min.y);
Assert.IsNotSmaller<ulong>(max.z, min.z);
Assert.IsNotSmaller<ulong>(max.w, min.w);

            max -= min;
            uint8 n = NextState32();
            ulong4 t = X86.Avx2.mm256_mul_epu32(*(v256*)&n, max);
            t = X86.Avx2.mm256_permutevar8x32_epi32(t, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(uint4*)&t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3 NextLong3()
        {
            return (long.MinValue ^ (long4)NextState64()).xyz;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3 NextLong3(long3 max)
        {
Assert.IsGreater<long>(max.x, -1L);
Assert.IsGreater<long>(max.y, -1L);
Assert.IsGreater<long>(max.z, -1L);

            ulong3 next = NextState64().xyz;

            // swapped to not allocate ANOTHER regiser
            next.x = Common.umul128(next.x, (ulong)max.z, out ulong firstResult);
            next.y = Common.umul128(next.y, (ulong)max.x, out next.x);
            next.z = Common.umul128(next.z, (ulong)max.y, out next.y);

            next.z = firstResult;

            return (long3)next;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3 NextLong3(long3 min, long3 max)
        {
Assert.IsNotSmaller<long>(max.x, min.x);
Assert.IsNotSmaller<long>(max.y, min.y);
Assert.IsNotSmaller<long>(max.z, min.z);

            max -= min;
            ulong3 next = NextState64().xyz;

            // swapped to not allocate ANOTHER regiser
            next.x = Common.umul128(next.x, (ulong)max.z, out ulong firstResult);
            next.y = Common.umul128(next.y, (ulong)max.x, out next.x);
            next.z = Common.umul128(next.z, (ulong)max.y, out next.y);

            next.z = firstResult;

            return min + (long3)next;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3()
        {
            return (NextState64() - 1ul).xyz;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3(ulong3 max)
        {
            ulong3 next = NextState64().xyz;

            // swapped to not allocate ANOTHER regiser
            next.x = Common.umul128(next.x, max.z, out ulong firstResult);
            next.y = Common.umul128(next.y, max.x, out next.x);
            next.z = Common.umul128(next.z, max.y, out next.y);

            next.z = firstResult;

            return next;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3(ulong3 min, ulong3 max)
        {
Assert.IsNotSmaller<ulong>(max.x, min.x);
Assert.IsNotSmaller<ulong>(max.y, min.y);
Assert.IsNotSmaller<ulong>(max.z, min.z);

            max -= min;
            ulong3 next = NextState64().xyz;

            // swapped to not allocate ANOTHER regiser
            next.x = Common.umul128(next.x, max.z, out ulong firstResult);
            next.y = Common.umul128(next.y, max.x, out next.x);
            next.z = Common.umul128(next.z, max.y, out next.y);

            next.z = firstResult;

            return min + next;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4 NextLong4()
        {
            return long.MinValue ^ (long4)NextState64();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4 NextLong4(long4 max)
        {
            ulong4 next = NextState64();

            // swapped to not allocate ANOTHER regiser
            next.x = Common.umul128(next.x, (ulong)max.w, out ulong firstResult);
            next.y = Common.umul128(next.y, (ulong)max.x, out next.x);
            next.z = Common.umul128(next.z, (ulong)max.y, out next.y);
            next.w = Common.umul128(next.w, (ulong)max.z, out next.z);

            next.w = firstResult;

            return (long4)next;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4 NextLong4(long4 min, long4 max)
        {
Assert.IsNotSmaller<long>(max.x, min.x);
Assert.IsNotSmaller<long>(max.y, min.y);
Assert.IsNotSmaller<long>(max.z, min.z);
Assert.IsNotSmaller<long>(max.w, min.w);

            max -= min;
            ulong4 next = NextState64();

            // swapped to not allocate ANOTHER regiser
            next.x = Common.umul128(next.x, (ulong)max.w, out ulong firstResult);
            next.y = Common.umul128(next.y, (ulong)max.x, out next.x);
            next.z = Common.umul128(next.z, (ulong)max.y, out next.y);
            next.w = Common.umul128(next.w, (ulong)max.z, out next.z);

            next.w = firstResult;

            return min + (long4)next;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4()
        {
            return NextState64() - 1ul;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4(ulong4 max)
        {
            ulong4 next = NextState64();

            // swapped to not allocate ANOTHER regiser
            next.x = Common.umul128(next.x, (ulong)max.w, out ulong firstResult);
            next.y = Common.umul128(next.y, (ulong)max.x, out next.x);
            next.z = Common.umul128(next.z, (ulong)max.y, out next.y);
            next.w = Common.umul128(next.w, (ulong)max.z, out next.z);

            next.w = firstResult;

            return next;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4(ulong4 min, ulong4 max)
        {
Assert.IsNotSmaller<ulong>(max.x, min.x);
Assert.IsNotSmaller<ulong>(max.y, min.y);
Assert.IsNotSmaller<ulong>(max.z, min.z);
Assert.IsNotSmaller<ulong>(max.w, min.w);

            max -= min;
            ulong4 next = NextState64();

            // swapped to not allocate ANOTHER regiser
            next.x = Common.umul128(next.x, (ulong)max.w, out ulong firstResult);
            next.y = Common.umul128(next.y, (ulong)max.x, out next.x);
            next.z = Common.umul128(next.z, (ulong)max.y, out next.y);
            next.w = Common.umul128(next.w, (ulong)max.z, out next.z);

            next.w = firstResult;

            return min + next;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8 NextFloat8()
        {
            return (float8)(v256)(0x3f800000 | (NextState32() >> 9)) - 1.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8 NextFloat8(float8 max)
        {
            return NextFloat8() * max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8 NextFloat8(float8 min, float8 max) 
        {
Assert.IsNotSmaller<float>(max.x0, min.x0);
Assert.IsNotSmaller<float>(max.x1, min.x1);
Assert.IsNotSmaller<float>(max.x2, min.x2);
Assert.IsNotSmaller<float>(max.x3, min.x3);
Assert.IsNotSmaller<float>(max.x4, min.x4);
Assert.IsNotSmaller<float>(max.x5, min.x5);
Assert.IsNotSmaller<float>(max.x6, min.x6);
Assert.IsNotSmaller<float>(max.x7, min.x7);

            return maxmath.mad(NextFloat8(), (max - min), min);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3()
        {
            ulong4 asdouble = 0x3FF0_0000_0000_0000 | (NextState64() >> 12);

            return *(double3*)&asdouble - 1d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3(double3 max) 
        { 
            return NextDouble3() * max; 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3(double3 min, double3 max) 
        { 
Assert.IsNotSmaller<double>(max.x, min.x);
Assert.IsNotSmaller<double>(max.y, min.y);
Assert.IsNotSmaller<double>(max.z, min.z);

            return math.mad(NextDouble3(), (max - min), min);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4()
        {
            ulong4 asdouble = 0x3FF0_0000_0000_0000 | (NextState64() >> 12);

            return *(double4*)&asdouble - 1d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4(double4 max) 
        { 
            return NextDouble4() * max; 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4(double4 min, double4 max) 
        { 
Assert.IsNotSmaller<double>(max.x, min.x);
Assert.IsNotSmaller<double>(max.y, min.y);
Assert.IsNotSmaller<double>(max.z, min.z);
Assert.IsNotSmaller<double>(max.w, min.w);

            return math.mad(NextDouble4(), (max - min), min);
        }
    }
}