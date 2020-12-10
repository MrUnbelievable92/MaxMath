using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 cvt_uint8(bool2 v)
        {
            return select(default(byte2), new byte2(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 cvt_uint8(bool3 v)
        {
            return select(default(byte3), new byte3(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 cvt_uint8(bool4 v)
        {
            return select(default(byte4), new byte4(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 cvt_uint8(bool8 v)
        {
            return select(default(byte8), new byte8(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 cvt_uint8(bool16 v)
        {
            return select(default(byte16), new byte16(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 cvt_uint8(bool32 v)
        {
            return select(default(byte32), new byte32(1), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 cvt_int8(bool2 v)
        {
            return select(default(sbyte2), new sbyte2(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 cvt_int8(bool3 v)
        {
            return select(default(sbyte3), new sbyte3(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 cvt_int8(bool4 v)
        {
            return select(default(sbyte4), new sbyte4(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 cvt_int8(bool8 v)
        {
            return select(default(sbyte8), new sbyte8(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 cvt_int8(bool16 v)
        {
            return select(default(sbyte16), new sbyte16(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 cvt_int8(bool32 v)
        {
            return select(default(sbyte32), new sbyte32(1), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 cvt_uint16(bool2 v)
        {
            return select(default(ushort2), new ushort2(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 cvt_uint16(bool3 v)
        {
            return select(default(ushort3), new ushort3(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 cvt_uint16(bool4 v)
        {
            return select(default(ushort4), new ushort4(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 cvt_uint16(bool8 v)
        {
            return select(default(ushort8), new ushort8(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 cvt_uint16(bool16 v)
        {
            return select(default(ushort16), new ushort16(1), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 cvt_int16(bool2 v)
        {
            return select(default(short2), new short2(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 cvt_int16(bool3 v)
        {
            return select(default(short3), new short3(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 cvt_int16(bool4 v)
        {
            return select(default(short4), new short4(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 cvt_int16(bool8 v)
        {
            return select(default(short8), new short8(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 cvt_int16(bool16 v)
        {
            return select(default(short16), new short16(1), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 cvt_uint32(bool2 v)
        {
            return math.select(default(uint2), new uint2(1u), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 cvt_uint32(bool3 v)
        {
            return math.select(default(uint3), new uint3(1u), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 cvt_uint32(bool4 v)
        {
            return math.select(default(uint4), new uint4(1u), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 cvt_uint32(bool8 v)
        {
            return select(default(uint8), new uint8(1u), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 cvt_int32(bool2 v)
        {
            return math.select(default(int2), new int2(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 cvt_int32(bool3 v)
        {
            return math.select(default(int3), new int3(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 cvt_int32(bool4 v)
        {
            return math.select(default(int4), new int4(1), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 cvt_int32(bool8 v)
        {
            return select(default(int8), new int8(1), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 cvt_uint64(bool2 v)
        {
            return select(default(ulong2), new ulong2(1ul), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 cvt_uint64(bool3 v)
        {
            return select(default(ulong3), new ulong3(1ul), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 cvt_uint64(bool4 v)
        {
            return select(default(ulong4), new ulong4(1ul), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 cvt_int64(bool2 v)
        {
            return select(default(long2), new long2(1L), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 cvt_int64(bool3 v)
        {
            return select(default(long3), new long3(1L), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 cvt_int64(bool4 v)
        {
            return select(default(long4), new long4(1L), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 cvt_f16(bool2 v)
        {
            ushort2 backingFields = select(default(ushort2), new ushort2(new half(1f).value), v);

            return *(half2*)&backingFields;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 cvt_f16(bool3 v)
        {
            ushort3 backingFields = select(default(ushort3), new ushort3(new half(1f).value), v);

            return *(half3*)&backingFields;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 cvt_f16(bool4 v)
        {
            ushort4 backingFields = select(default(ushort4), new ushort4(new half(1f).value), v);

            return *(half4*)&backingFields;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cvt_f32(bool2 v)
        {
            return math.select(default(float2), new float2(1f), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cvt_f32(bool3 v)
        {
            return math.select(default(float3), new float3(1f), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 cvt_f32(bool4 v)
        {
            return math.select(default(float4), new float4(1f), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cvt_f32(bool8 v)
        {
            return select(new float8(0f), new float8(1f), v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 cvt_f64(bool2 v)
        {
            return math.select(default(double2), new double2(1d), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cvt_f64(bool3 v)
        {
            return math.select(default(double3), new double3(1d), v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 cvt_f64(bool4 v)
        {
            return math.select(default(double4), new double4(1d), v);
        }
    }
}