using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts each value in a bool2 vector to its integer representation as a byte2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 touint8safe(bool2 x)
        {
            return clamp(*(byte2*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a byte3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 touint8safe(bool3 x)
        {
            return clamp(*(byte3*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a byte4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 touint8safe(bool4 x)
        {
            return clamp(*(byte4*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a byte6 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 touint8safe(bool8 x)
        {
            return clamp(*(byte8*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a byte16 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 touint8safe(bool16 x)
        {
            return clamp(*(byte16*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool32 vector to its integer representation as a byte32 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 touint8safe(bool32 x)
        {
            return clamp(*(byte32*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool2 vector to its integer representation as an sbyte2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 toint8safe(bool2 x)
        {
            return clamp(*(sbyte2*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as an sbyte3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 toint8safe(bool3 x)
        {
            return clamp(*(sbyte3*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as an sbyte4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 toint8safe(bool4 x)
        {
            return clamp(*(sbyte4*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as an sbyte8 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 toint8safe(bool8 x)
        {
            return clamp(*(sbyte8*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as an sbyte16 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 toint8safe(bool16 x)
        {
            return clamp(*(sbyte16*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool32 vector to its integer representation as an sbyte32 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 toint8safe(bool32 x)
        {
            return clamp(*(sbyte32*)&x, 0, 1);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a ushort2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 touint16safe(bool2 x)
        {
            return (ushort2)clamp(*(byte2*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a ushort3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 touint16safe(bool3 x)
        {
            return (ushort3)clamp(*(byte3*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a ushort4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 touint16safe(bool4 x)
        {
            return (ushort4)clamp(*(byte4*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a ushort8 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 touint16safe(bool8 x)
        {
            return (ushort8)clamp(*(byte8*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a ushort16 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 touint16safe(bool16 x)
        {
            return (ushort16)clamp(*(byte16*)&x, 0, 1);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a short2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toint16safe(bool2 x)
        {
            return (short2)clamp(*(byte2*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a short3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toint16safe(bool3 x)
        {
            return (short3)clamp(*(byte3*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a short4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toint16safe(bool4 x)
        {
            return (short4)clamp(*(byte4*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a short8 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toint16safe(bool8 x)
        {
            return (short8)clamp(*(byte8*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a short16 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toint16safe(bool16 x)
        {
            return (short16)clamp(*(byte16*)&x, 0, 1);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a uint2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint32safe(bool2 x)
        {
            return (uint2)clamp(*(byte2*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a uint3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint32safe(bool3 x)
        {
            return (uint3)clamp(*(byte3*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a uint4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint32safe(bool4 x)
        {
            return (uint4)clamp(*(byte4*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a uint8 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touint32safe(bool8 x)
        {
            return (uint8)clamp(*(byte8*)&x, 0, 1);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as an int2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint32safe(bool2 x)
        {
            return (int2)clamp(*(byte2*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as an int3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint32safe(bool3 x)
        {
            return (int3)clamp(*(byte3*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as an int4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint32safe(bool4 x)
        {
            return (int4)clamp(*(byte4*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as an int8 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 toint32safe(bool8 x)
        {
            return (int8)clamp(*(byte8*)&x, 0, 1);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a ulong2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 touint64safe(bool2 x)
        {
            return (ulong2)clamp(*(byte2*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a ulong3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 touint64safe(bool3 x)
        {
            return (ulong3)clamp(*(byte3*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a ulong4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 touint64safe(bool4 x)
        {
            return (ulong4)clamp(*(byte4*)&x, 0, 1);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a long2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 toint64safe(bool2 x)
        {
            return (long2)clamp(*(byte2*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a long3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 toint64safe(bool3 x)
        {
            return (long3)clamp(*(byte3*)&x, 0, 1);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a long4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 toint64safe(bool4 x)
        {
            return (long4)clamp(*(byte4*)&x, 0, 1);
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a half2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tof16safe(bool2 x)
        {
            return ashalf(select((ushort2)0, (ushort2)new half(1f).value, x));
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a half3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tof16safe(bool3 x)
        {
            return ashalf(select((ushort3)0, (ushort3)new half(1f).value, x));
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a half4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tof16safe(bool4 x)
        {
            return ashalf(select((ushort4)0, (ushort4)new half(1f).value, x));
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a float2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tof32safe(bool2 x)
        {
            return math.select(default(float2), new float2(1f), x);
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a float3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tof32safe(bool3 x)
        {
            return math.select(default(float3), new float3(1f), x);
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a float4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tof32safe(bool4 x)
        {
            return math.select(default(float4), new float4(1f), x);
        }

        /// <summary>       Converts each value in a bool8 vector to its floating point representation as a float8 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tof32safe(bool8 x)
        {
            return select(new float8(0f), new float8(1f), x);
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a double2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 tof64safe(bool2 x)
        {
            return math.select(default(double2), new double2(1d), x);
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a double3 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 tof64safe(bool3 x)
        {
            return math.select(default(double3), new double3(1d), x);
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a double4 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 tof64safe(bool4 x)
        {
            return math.select(default(double4), new double4(1d), x);
        }


        /// <summary>       Converts each value in a byte2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(byte2 x)
        {
            byte2 clamped = clamp(x, 0, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in an sbyte2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(sbyte2 x)
        {
            sbyte2 clamped = clamp(x, 0, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a short2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(short2 x)
        {
            byte2 clamped = (byte2)clamp(x, 0, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a ushort2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(ushort2 x)
        {
            byte2 clamped = (byte2)clamp(x, 0, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in an int2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(int2 x)
        {
            byte2 clamped = (byte2)math.clamp(x, 0, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a uint2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(uint2 x)
        {
            byte2 clamped = (byte2)math.clamp(x, 0, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a long2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(long2 x)
        {
            byte2 clamped = (byte2)clamp(x, 0, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a ulong2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(ulong2 x)
        {
            byte2 clamped = (byte2)clamp(x, 0, 1);

            return *(bool2*)&clamped;
        }

        /// <summary>       Converts each value in a half2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(half2 x)
        {
            return x != (half)0f;
        }

        /// <summary>       Converts each value in a float2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(float2 x)
        {
            return x != 0f;
        }

        /// <summary>       Converts each value in a double2 vector to its boolean representation as a bool2 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 toboolsafe(double2 x)
        {
            return x != 0d; 
        }


        /// <summary>       Converts each value in a byte3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(byte3 x)
        {
            byte3 clamped = clamp(x, 0, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in an sbyte3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(sbyte3 x)
        {
            sbyte3 clamped = clamp(x, 0, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a short3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(short3 x)
        {
            byte3 clamped = (byte3)clamp(x, 0, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a ushort3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(ushort3 x)
        {
            byte3 clamped = (byte3)clamp(x, 0, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in an int3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(int3 x)
        {
            byte3 clamped = (byte3)math.clamp(x, 0, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a uint3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(uint3 x)
        {
            byte3 clamped = (byte3)math.clamp(x, 0, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a long3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(long3 x)
        {
            byte3 clamped = (byte3)clamp(x, 0, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a ulong3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(ulong3 x)
        {
            byte3 clamped = (byte3)clamp(x, 0, 1);

            return *(bool3*)&clamped;
        }

        /// <summary>       Converts each value in a half3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(half3 x)
        {
            return x != (half)0f;
        }

        /// <summary>       Converts each value in a float3 vector to its boolean representation as a bool3 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(float3 x)
        {
            return x != 0f;
        }

        /// <summary>       Converts each value in a double3 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 toboolsafe(double3 x)
        {
            return x != 0d;
        }

        /// <summary>       Converts each value in a byte4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(byte4 x)
        {
            byte4 clamped = clamp(x, 0, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in an sbyte4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(sbyte4 x)
        {
            sbyte4 clamped = clamp(x, 0, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a short4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(short4 x)
        {
            byte4 clamped = (byte4)clamp(x, 0, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a ushor4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(ushort4 x)
        {
            byte4 clamped = (byte4)clamp(x, 0, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in an int4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(int4 x)
        {
            byte4 clamped = (byte4)math.clamp(x, 0, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a uint4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(uint4 x)
        {
            byte4 clamped = (byte4)math.clamp(x, 0, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a long4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(long4 x)
        {
            byte4 clamped = (byte4)clamp(x, 0, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a ulong4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(ulong4 x)
        {
            byte4 clamped = (byte4)clamp(x, 0, 1);

            return *(bool4*)&clamped;
        }

        /// <summary>       Converts each value in a half4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(half4 x)
        {
            return x != (half)0f;
        }

        /// <summary>       Converts each value in a float4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(float4 x)
        {
            return x != 0f;
        }

        /// <summary>       Converts each value in a double4 vector to its boolean representation as a bool4 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 toboolsafe(double4 x)
        {
            return x != 1d; 
        }


        /// <summary>       Converts each value in a byte8 vector to its boolean representation as a bool8 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(byte8 x)
        {
            return (v128)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in an sbyte8 vector to its boolean representation as a bool8 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(sbyte8 x)
        {
            return (v128)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in a short8 vector to its boolean representation as a bool8 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(short8 x)
        {
            return (v128)(byte8)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in a ushort8 vector to its boolean representation as a bool8 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(ushort8 x)
        {
            return (v128)(byte8)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in an int8 vector to its boolean representation as a bool8 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(int8 x)
        {
            return (v128)(byte8)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in a uint8 vector to its boolean representation as a bool8 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(uint8 x)
        {
            return (v128)(byte8)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in a half8 vector to its boolean representation as a bool8 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(half8 x)
        {
            return x != (half)0f;
        }

        /// <summary>       Converts each value in a float8 vector to its boolean representation as a bool8 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 toboolsafe(float8 x)
        {
            return x != 0f;
        }


        /// <summary>       Converts each value in a byte16 vector to its boolean representation as a bool16 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(byte16 x)
        {
            return (v128)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in an sbyte16 vector to its boolean representation as a bool16 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(sbyte16 x)
        {
            return (v128)(byte16)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in a short16 vector to its boolean representation as a bool16 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(short16 x)
        {
            return (v128)(byte16)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in a ushort16 vector to its boolean representation as a bool16 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 toboolsafe(ushort16 x)
        {
            return (v128)(byte16)clamp(x, 0, 1);
        }


        /// <summary>       Converts each value in a byte32 vector to its boolean representation as a bool32 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 toboolsafe(byte32 x)
        {
            return (v256)(byte32)clamp(x, 0, 1);
        }

        /// <summary>       Converts each value in an sbyte32 vector to its boolean representation as a bool32 vector. The underlying value is being clamped to the interval[0, 1]. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 toboolsafe(sbyte32 x)
        {
            return (v256)(byte32)clamp(x, 0, 1);
        }
    }
}