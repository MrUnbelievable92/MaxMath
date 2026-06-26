using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using static MaxMath.math;

namespace MaxMath
{
    [Obsolete("This random number generator is less efficient than Random32 for producing 32-bit values, and less than half as efficient as Random64 for producing double-precision floating-point values. It exists only for compatibility during the transition from Unity.Mathematics to MaxMath; nevertheless, using the aforementioned random number generators is strongly advised.")]
    [Serializable]
    public partial struct Random
    {
        public uint state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random(uint seed)
        {
            state = seed;
            CheckInitState();
            NextState();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Random CreateFromIndex(uint index)
        {
            CheckIndexForHash(index);
            return new Random(WangHash(index + 62u));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint WangHash(uint n)
        {
            n = (n ^ 61u) ^ (n >> 16);
            n *= 9u;
            n = n ^ (n >> 4);
            n *= 0x27d4eb2du;
            n = n ^ (n >> 15);

            return n;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InitState(uint seed = 0x6E624EB7u)
        {
            state = seed;
            NextState();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            return (NextState() & 1) == 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint v = NextState();
            return (new uint2(v) & new uint2(1, 2)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            uint v = NextState();
            return (new uint3(v) & new uint3(1, 2, 4)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4 NextBool4()
        {
            uint v = NextState();
            return (new uint4(v) & new uint4(1, 2, 4, 8)) == 0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt()
        {
            return (int)NextState() ^ -2147483648;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2()
        {
            return new int2((int)NextState(), (int)NextState()) ^ -2147483648;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3()
        {
            return new int3((int)NextState(), (int)NextState(), (int)NextState()) ^ -2147483648;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4()
        {
            return new int4((int)NextState(), (int)NextState(), (int)NextState(), (int)NextState()) ^ -2147483648;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int max)
        {
            CheckNextIntMax(max);
            return (int)((NextState() * (ulong)max) >> 32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2(int2 max)
        {
            CheckNextIntMax(max.x);
            CheckNextIntMax(max.y);
            return new int2((int)(NextState() * (ulong)max.x >> 32),
                            (int)(NextState() * (ulong)max.y >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3(int3 max)
        {
            CheckNextIntMax(max.x);
            CheckNextIntMax(max.y);
            CheckNextIntMax(max.z);
            return new int3((int)(NextState() * (ulong)max.x >> 32),
                            (int)(NextState() * (ulong)max.y >> 32),
                            (int)(NextState() * (ulong)max.z >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4(int4 max)
        {
            CheckNextIntMax(max.x);
            CheckNextIntMax(max.y);
            CheckNextIntMax(max.z);
            CheckNextIntMax(max.w);
            return new int4((int)(NextState() * (ulong)max.x >> 32),
                            (int)(NextState() * (ulong)max.y >> 32),
                            (int)(NextState() * (ulong)max.z >> 32),
                            (int)(NextState() * (ulong)max.w >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int min, int max)
        {
            CheckNextIntMinMax(min, max);
            uint range = (uint)(max - min);
            return (int)(NextState() * (ulong)range >> 32) + min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2(int2 min, int2 max)
        {
            CheckNextIntMinMax(min.x, max.x);
            CheckNextIntMinMax(min.y, max.y);
            uint2 range = (uint2)(max - min);
            return new int2((int)(NextState() * (ulong)range.x >> 32),
                            (int)(NextState() * (ulong)range.y >> 32)) + min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3(int3 min, int3 max)
        {
            CheckNextIntMinMax(min.x, max.x);
            CheckNextIntMinMax(min.y, max.y);
            CheckNextIntMinMax(min.z, max.z);
            uint3 range = (uint3)(max - min);
            return new int3((int)(NextState() * (ulong)range.x >> 32),
                            (int)(NextState() * (ulong)range.y >> 32),
                            (int)(NextState() * (ulong)range.z >> 32)) + min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4(int4 min, int4 max)
        {
            CheckNextIntMinMax(min.x, max.x);
            CheckNextIntMinMax(min.y, max.y);
            CheckNextIntMinMax(min.z, max.z);
            CheckNextIntMinMax(min.w, max.w);
            uint4 range = (uint4)(max - min);
            return new int4((int)(NextState() * (ulong)range.x >> 32),
                            (int)(NextState() * (ulong)range.y >> 32),
                            (int)(NextState() * (ulong)range.z >> 32),
                            (int)(NextState() * (ulong)range.w >> 32)) + min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt()
        {
            return NextState() - 1u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2()
        {
            return new uint2(NextState(), NextState()) - 1u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3()
        {
            return new uint3(NextState(), NextState(), NextState()) - 1u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4()
        {
            return new uint4(NextState(), NextState(), NextState(), NextState()) - 1u;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint max)
        {
            return (uint)((NextState() * (ulong)max) >> 32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2(uint2 max)
        {
            return new uint2((uint)(NextState() * (ulong)max.x >> 32),
                             (uint)(NextState() * (ulong)max.y >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(uint3 max)
        {
            return new uint3((uint)(NextState() * (ulong)max.x >> 32),
                             (uint)(NextState() * (ulong)max.y >> 32),
                             (uint)(NextState() * (ulong)max.z >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(uint4 max)
        {
            return new uint4((uint)(NextState() * (ulong)max.x >> 32),
                             (uint)(NextState() * (ulong)max.y >> 32),
                             (uint)(NextState() * (ulong)max.z >> 32),
                             (uint)(NextState() * (ulong)max.w >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint min, uint max)
        {
            CheckNextUIntMinMax(min, max);
            uint range = max - min;
            return (uint)(NextState() * (ulong)range >> 32) + min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2(uint2 min, uint2 max)
        {
            CheckNextUIntMinMax(min.x, max.x);
            CheckNextUIntMinMax(min.y, max.y);
            uint2 range = max - min;
            return new uint2((uint)(NextState() * (ulong)range.x >> 32),
                             (uint)(NextState() * (ulong)range.y >> 32)) + min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(uint3 min, uint3 max)
        {
            CheckNextUIntMinMax(min.x, max.x);
            CheckNextUIntMinMax(min.y, max.y);
            CheckNextUIntMinMax(min.z, max.z);
            uint3 range = max - min;
            return new uint3((uint)(NextState() * (ulong)range.x >> 32),
                             (uint)(NextState() * (ulong)range.y >> 32),
                             (uint)(NextState() * (ulong)range.z >> 32)) + min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(uint4 min, uint4 max)
        {
            CheckNextUIntMinMax(min.x, max.x);
            CheckNextUIntMinMax(min.y, max.y);
            CheckNextUIntMinMax(min.z, max.z);
            CheckNextUIntMinMax(min.w, max.w);
            uint4 range = (uint4)(max - min);
            return new uint4((uint)(NextState() * (ulong)range.x >> 32),
                             (uint)(NextState() * (ulong)range.y >> 32),
                             (uint)(NextState() * (ulong)range.z >> 32),
                             (uint)(NextState() * (ulong)range.w >> 32)) + min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat()
        {
            return asfloat(0x3f800000 | (NextState() >> 9)) - 1.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2()
        {
            return asfloat(0x3f800000 | (new uint2(NextState(), NextState()) >> 9)) - 1.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3()
        {
            return asfloat(0x3f800000 | (new uint3(NextState(), NextState(), NextState()) >> 9)) - 1.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4()
        {
            return asfloat(0x3f800000 | (new uint4(NextState(), NextState(), NextState(), NextState()) >> 9)) - 1.0f;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat(float max) { return NextFloat() * max; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2(float2 max) { return NextFloat2() * max; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3(float3 max) { return NextFloat3() * max; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4(float4 max) { return NextFloat4() * max; }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat(float min, float max) { return NextFloat() * (max - min) + min; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2(float2 min, float2 max) { return NextFloat2() * (max - min) + min; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3(float3 min, float3 max) { return NextFloat3() * (max - min) + min; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4(float4 min, float4 max) { return NextFloat4() * (max - min) + min; }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble()
        {
            ulong sx = ((ulong)NextState() << 20) ^ NextState();
            return asdouble(0x3ff0000000000000 | sx) - 1.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2 NextDouble2()
        {
            ulong sx = ((ulong)NextState() << 20) ^ NextState();
            ulong sy = ((ulong)NextState() << 20) ^ NextState();
            return new double2(asdouble(0x3ff0000000000000 | sx),
                               asdouble(0x3ff0000000000000 | sy)) - 1.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3()
        {
            ulong sx = ((ulong)NextState() << 20) ^ NextState();
            ulong sy = ((ulong)NextState() << 20) ^ NextState();
            ulong sz = ((ulong)NextState() << 20) ^ NextState();
            return new double3(asdouble(0x3ff0000000000000 | sx),
                               asdouble(0x3ff0000000000000 | sy),
                               asdouble(0x3ff0000000000000 | sz)) - 1.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4()
        {
            ulong sx = ((ulong)NextState() << 20) ^ NextState();
            ulong sy = ((ulong)NextState() << 20) ^ NextState();
            ulong sz = ((ulong)NextState() << 20) ^ NextState();
            ulong sw = ((ulong)NextState() << 20) ^ NextState();
            return new double4(asdouble(0x3ff0000000000000 | sx),
                               asdouble(0x3ff0000000000000 | sy),
                               asdouble(0x3ff0000000000000 | sz),
                               asdouble(0x3ff0000000000000 | sw)) - 1.0;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble(double max) { return NextDouble() * max; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2 NextDouble2(double2 max) { return NextDouble2() * max; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3(double3 max) { return NextDouble3() * max; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4(double4 max) { return NextDouble4() * max; }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble(double min, double max) { return NextDouble() * (max - min) + min; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2 NextDouble2(double2 min, double2 max) { return NextDouble2() * (max - min) + min; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3(double3 min, double3 max) { return NextDouble3() * (max - min) + min; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4(double4 min, double4 max) { return NextDouble4() * (max - min) + min; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2Direction()
        {
            float angle = NextFloat() * PI * 2.0f;
            float s, c;
            sincos(angle, out s, out c);
            return new float2(c, s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2 NextDouble2Direction()
        {
            double angle = NextDouble() * PI_DBL * 2.0;
            double s, c;
            sincos(angle, out s, out c);
            return new double2(c, s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3Direction()
        {
            float2 rnd = NextFloat2();
            float z = rnd.x * 2.0f - 1.0f;
            float r = sqrt(max(1.0f - z * z, 0.0f));
            float angle = rnd.y * PI * 2.0f;
            float s, c;
            sincos(angle, out s, out c);
            return new float3(c*r, s*r, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3Direction()
        {
            double2 rnd = NextDouble2();
            double z = rnd.x * 2.0 - 1.0;
            double r = sqrt(max(1.0 - z * z, 0.0));
            double angle = rnd.y * PI_DBL * 2.0;
            double s, c;
            sincos(angle, out s, out c);
            return new double3(c * r, s * r, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion NextQuaternionRotation()
        {
            float3 rnd = NextFloat3(new float3(2.0f * PI, 2.0f * PI, 1.0f));
            float u1 = rnd.z;
            float2 theta_rho = rnd.xy;

            float i = sqrt(1.0f - u1);
            float j = sqrt(u1);

            sincos(theta_rho, out float2 sin_theta_rho, out float2 cos_theta_rho);

            quaternion q = new quaternion(i * sin_theta_rho.x, i * cos_theta_rho.x, j * sin_theta_rho.y, j * cos_theta_rho.y);
            return new quaternion(select(q.value, -q.value, q.value.w < 0.0f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint NextState()
        {
            CheckState();
            uint t = state;
            state ^= state << 13;
            state ^= state >> 17;
            state ^= state << 5;
            return t;
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void CheckInitState()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (state == 0)
                throw new System.ArgumentException("Seed must be non-zero");
#endif
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        static void CheckIndexForHash(uint index)
        {
            if (index == uint.MaxValue)
                throw new System.ArgumentException("Index must not be uint.MaxValue");
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void CheckState()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if(state == 0)
                throw new System.ArgumentException("Invalid state 0. Random object has not been properly initialized");
#endif
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void CheckNextIntMax(int max)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (max < 0)
                throw new System.ArgumentException("max must be positive");
#endif
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void CheckNextIntMinMax(int min, int max)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (min > max)
                throw new System.ArgumentException("min must be less than or equal to max");
#endif
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void CheckNextUIntMinMax(uint min, uint max)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (min > max)
                throw new System.ArgumentException("min must be less than or equal to max");
#endif
        }

    }
}
