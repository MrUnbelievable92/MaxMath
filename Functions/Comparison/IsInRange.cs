using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(byte2 x, byte2 min, byte2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(byte3 x, byte3 min, byte3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(byte4 x, byte4 min, byte4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 inrange(byte8 x, byte8 min, byte8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 inrange(byte16 x, byte16 min, byte16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 inrange(byte32 x, byte32 min, byte32 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(sbyte2 x, sbyte2 min, sbyte2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(sbyte3 x, sbyte3 min, sbyte3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(sbyte4 x, sbyte4 min, sbyte4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 inrange(sbyte8 x, sbyte8 min, sbyte8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 inrange(sbyte16 x, sbyte16 min, sbyte16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 inrange(sbyte32 x, sbyte32 min, sbyte32 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(short2 x, short2 min, short2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(short3 x, short3 min, short3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(short4 x, short4 min, short4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 inrange(short8 x, short8 min, short8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 inrange(short16 x, short16 min, short16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(ushort2 x, ushort2 min, ushort2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(ushort3 x, ushort3 min, ushort3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(ushort4 x, ushort4 min, ushort4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 inrange(ushort8 x, ushort8 min, ushort8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 inrange(ushort16 x, ushort16 min, ushort16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(int x, int min, int max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(int2 x, int2 min, int2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(int3 x, int3 min, int3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(int4 x, int4 min, int4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 inrange(int8 x, int8 min, int8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(uint x, uint min, uint max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(uint2 x, uint2 min, uint2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(uint3 x, uint3 min, uint3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(uint4 x, uint4 min, uint4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 inrange(uint8 x, uint8 min, uint8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(long x, long min, long max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(long2 x, long2 min, long2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(long3 x, long3 min, long3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(long4 x, long4 min, long4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(ulong x, ulong min, ulong max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(ulong2 x, ulong2 min, ulong2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(ulong3 x, ulong3 min, ulong3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(ulong4 x, ulong4 min, ulong4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(float x, float min, float max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(float2 x, float2 min, float2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(float3 x, float3 min, float3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(float4 x, float4 min, float4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 inrange(float8 x, float8 min, float8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(double x, double min, double max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(double2 x, double2 min, double2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(double3 x, double3 min, double3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary> Inclusive </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(double4 x, double4 min, double4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }
    }
}