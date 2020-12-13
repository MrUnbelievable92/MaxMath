using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a bool2 indicating for each component of a byte2 vector whether it is within the corresponding interval [min, max], where min and max are byte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(byte2 x, byte2 min, byte2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a byte3 vector whether it is within the corresponding interval [min, max], where min and max are byte3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(byte3 x, byte3 min, byte3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a byte4 vector whether it is within the corresponding interval [min, max], where min and max are byte4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(byte4 x, byte4 min, byte4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool8 indicating for each component of a byte8 vector whether it is within the corresponding interval [min, max], where min and max are byte8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 inrange(byte8 x, byte8 min, byte8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool16 indicating for each component of a byte16 vector whether it is within the corresponding interval [min, max], where min and max are byte16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 inrange(byte16 x, byte16 min, byte16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool32 indicating for each component of a byte32 vector whether it is within the corresponding interval [min, max], where min and max are byte32 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 inrange(byte32 x, byte32 min, byte32 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns a bool2 indicating for each component of a sbyte2 vector whether it is within the corresponding interval [min, max], where min and max are sbyte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(sbyte2 x, sbyte2 min, sbyte2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a sbyte3 vector whether it is within the corresponding interval [min, max], where min and max are sbyte3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(sbyte3 x, sbyte3 min, sbyte3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a sbyte4 vector whether it is within the corresponding interval [min, max], where min and max are sbyte4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(sbyte4 x, sbyte4 min, sbyte4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool8 indicating for each component of a sbyte8 vector whether it is within the corresponding interval [min, max], where min and max are sbyte8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 inrange(sbyte8 x, sbyte8 min, sbyte8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool16 indicating for each component of a sbyte16 vector whether it is within the corresponding interval [min, max], where min and max are sbyte16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 inrange(sbyte16 x, sbyte16 min, sbyte16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool32 indicating for each component of a sbyte32 vector whether it is within the corresponding interval [min, max], where min and max are sbyte32 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 inrange(sbyte32 x, sbyte32 min, sbyte32 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns a bool2 indicating for each component of a short2 vector whether it is within the corresponding interval [min, max], where min and max are short2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(short2 x, short2 min, short2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a short3 vector whether it is within the corresponding interval [min, max], where min and max are short3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(short3 x, short3 min, short3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a short4 vector whether it is within the corresponding interval [min, max], where min and max are short4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(short4 x, short4 min, short4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool8 indicating for each component of a short8 vector whether it is within the corresponding interval [min, max], where min and max are short8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 inrange(short8 x, short8 min, short8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool16 indicating for each component of a short16 vector whether it is within the corresponding interval [min, max], where min and max are short16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 inrange(short16 x, short16 min, short16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns a bool2 indicating for each component of a ushort2 vector whether it is within the corresponding interval [min, max], where min and max are ushort2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(ushort2 x, ushort2 min, ushort2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a ushort3 vector whether it is within the corresponding interval [min, max], where min and max are ushort3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(ushort3 x, ushort3 min, ushort3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a ushort4 vector whether it is within the corresponding interval [min, max], where min and max are ushort4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(ushort4 x, ushort4 min, ushort4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool8 indicating for each component of a ushort8 vector whether it is within the corresponding interval [min, max], where min and max are ushort8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 inrange(ushort8 x, ushort8 min, ushort8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool16 indicating for each component of a ushort16 vector whether it is within the corresponding interval [min, max], where min and max are ushort16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 inrange(ushort16 x, ushort16 min, ushort16 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns true if an int value is within the interval [min, max], where min and max are int values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(int x, int min, int max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary>       Returns a bool2 indicating for each component of an int2 vector whether it is within the corresponding interval [min, max], where min and max are int2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(int2 x, int2 min, int2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of an int3 vector whether it is within the corresponding interval [min, max], where min and max are int3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(int3 x, int3 min, int3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of an int4 vector whether it is within the corresponding interval [min, max], where min and max are int4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(int4 x, int4 min, int4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool8 indicating for each component of an int8 vector whether it is within the corresponding interval [min, max], where min and max are int8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 inrange(int8 x, int8 min, int8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns true if a uint value is within the interval [min, max], where min and max are uint values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(uint x, uint min, uint max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary>       Returns a bool2 indicating for each component of a uint2 vector whether it is within the corresponding interval [min, max], where min and max are uint2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(uint2 x, uint2 min, uint2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a uint3 vector whether it is within the corresponding interval [min, max], where min and max are uint3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(uint3 x, uint3 min, uint3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a uint4 vector whether it is within the corresponding interval [min, max], where min and max are uint4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(uint4 x, uint4 min, uint4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool8 indicating for each component of a uint8 vector whether it is within the corresponding interval [min, max], where min and max are uint8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 inrange(uint8 x, uint8 min, uint8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns true if a long value is within the interval [min, max], where min and max are long values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(long x, long min, long max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary>       Returns a bool2 indicating for each component of a long2 vector whether it is within the corresponding interval [min, max], where min and max are long2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(long2 x, long2 min, long2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a long3 vector whether it is within the corresponding interval [min, max], where min and max are long3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(long3 x, long3 min, long3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a long4 vector whether it is within the corresponding interval [min, max], where min and max are long4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(long4 x, long4 min, long4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns true if a ulong value is within the interval [min, max], where min and max are ulong values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(ulong x, ulong min, ulong max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary>       Returns a bool2 indicating for each component of a ulong2 vector whether it is within the corresponding interval [min, max], where min and max are ulong2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(ulong2 x, ulong2 min, ulong2 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a ulong3 vector whether it is within the corresponding interval [min, max], where min and max are ulong3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(ulong3 x, ulong3 min, ulong3 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a ulong4 vector whether it is within the corresponding interval [min, max], where min and max are ulong4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(ulong4 x, ulong4 min, ulong4 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns true if a float value is within the interval [min, max], where min and max are float values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(float x, float min, float max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary>       Returns a bool2 indicating for each component of a float2 vector whether it is within the corresponding interval [min, max], where min and max are float2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(float2 x, float2 min, float2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a float3 vector whether it is within the corresponding interval [min, max], where min and max are float3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(float3 x, float3 min, float3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a float4 vector whether it is within the corresponding interval [min, max], where min and max are float4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(float4 x, float4 min, float4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool8 indicating for each component of a float8 vector whether it is within the corresponding interval [min, max], where min and max are float8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 inrange(float8 x, float8 min, float8 max)
        {
            return maxmath.min(maxmath.max(x, min), max) == x;
        }


        /// <summary>       Returns true if a double value is within the interval [min, max], where min and max are double values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool inrange(double x, double min, double max)
        {
            return (x >= min) & (x <= max);
        }

        /// <summary>       Returns a bool2 indicating for each component of a double2 vector whether it is within the corresponding interval [min, max], where min and max are double2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 inrange(double2 x, double2 min, double2 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool3 indicating for each component of a double3 vector whether it is within the corresponding interval [min, max], where min and max are double3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 inrange(double3 x, double3 min, double3 max)
        {
            return math.min(math.max(x, min), max) == x;
        }

        /// <summary>       Returns a bool4 indicating for each component of a double4 vector whether it is within the corresponding interval [min, max], where min and max are double4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 inrange(double4 x, double4 min, double4 max)
        {
            return math.min(math.max(x, min), max) == x;
        }
    }
}