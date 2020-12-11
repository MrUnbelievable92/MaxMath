using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 cvt_uint8(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return *(byte2*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 cvt_uint8(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return *(byte3*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 cvt_uint8(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return *(byte4*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 cvt_uint8(bool8 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);

            return (v128)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 cvt_uint8(bool16 v)
        {
Assert.IsBetween(*(byte*)&v.x0,  0, 1);
Assert.IsBetween(*(byte*)&v.x1,  0, 1);
Assert.IsBetween(*(byte*)&v.x2,  0, 1);
Assert.IsBetween(*(byte*)&v.x3,  0, 1);
Assert.IsBetween(*(byte*)&v.x4,  0, 1);
Assert.IsBetween(*(byte*)&v.x5,  0, 1);
Assert.IsBetween(*(byte*)&v.x6,  0, 1);
Assert.IsBetween(*(byte*)&v.x7,  0, 1);
Assert.IsBetween(*(byte*)&v.x8,  0, 1);
Assert.IsBetween(*(byte*)&v.x9,  0, 1);
Assert.IsBetween(*(byte*)&v.x10, 0, 1);
Assert.IsBetween(*(byte*)&v.x11, 0, 1);
Assert.IsBetween(*(byte*)&v.x12, 0, 1);
Assert.IsBetween(*(byte*)&v.x13, 0, 1);
Assert.IsBetween(*(byte*)&v.x14, 0, 1);
Assert.IsBetween(*(byte*)&v.x15, 0, 1);

            return (v128)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 cvt_uint8(bool32 v)
        {
Assert.IsBetween(*(byte*)&v.x0,  0, 1);
Assert.IsBetween(*(byte*)&v.x1,  0, 1);
Assert.IsBetween(*(byte*)&v.x2,  0, 1);
Assert.IsBetween(*(byte*)&v.x3,  0, 1);
Assert.IsBetween(*(byte*)&v.x4,  0, 1);
Assert.IsBetween(*(byte*)&v.x5,  0, 1);
Assert.IsBetween(*(byte*)&v.x6,  0, 1);
Assert.IsBetween(*(byte*)&v.x7,  0, 1);
Assert.IsBetween(*(byte*)&v.x8,  0, 1);
Assert.IsBetween(*(byte*)&v.x9,  0, 1);
Assert.IsBetween(*(byte*)&v.x10, 0, 1);
Assert.IsBetween(*(byte*)&v.x11, 0, 1);
Assert.IsBetween(*(byte*)&v.x12, 0, 1);
Assert.IsBetween(*(byte*)&v.x13, 0, 1);
Assert.IsBetween(*(byte*)&v.x14, 0, 1);
Assert.IsBetween(*(byte*)&v.x15, 0, 1);
Assert.IsBetween(*(byte*)&v.x16, 0, 1);
Assert.IsBetween(*(byte*)&v.x17, 0, 1);
Assert.IsBetween(*(byte*)&v.x18, 0, 1);
Assert.IsBetween(*(byte*)&v.x19, 0, 1);
Assert.IsBetween(*(byte*)&v.x20, 0, 1);
Assert.IsBetween(*(byte*)&v.x21, 0, 1);
Assert.IsBetween(*(byte*)&v.x22, 0, 1);
Assert.IsBetween(*(byte*)&v.x23, 0, 1);
Assert.IsBetween(*(byte*)&v.x24, 0, 1);
Assert.IsBetween(*(byte*)&v.x25, 0, 1);
Assert.IsBetween(*(byte*)&v.x26, 0, 1);
Assert.IsBetween(*(byte*)&v.x27, 0, 1);
Assert.IsBetween(*(byte*)&v.x28, 0, 1);
Assert.IsBetween(*(byte*)&v.x29, 0, 1);
Assert.IsBetween(*(byte*)&v.x30, 0, 1);
Assert.IsBetween(*(byte*)&v.x31, 0, 1);

            return (v256)v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 cvt_int8(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return *(sbyte2*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 cvt_int8(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return *(sbyte3*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 cvt_int8(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return *(sbyte4*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 cvt_int8(bool8 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);

            return (v128)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 cvt_int8(bool16 v)
        {
Assert.IsBetween(*(byte*)&v.x0,  0, 1);
Assert.IsBetween(*(byte*)&v.x1,  0, 1);
Assert.IsBetween(*(byte*)&v.x2,  0, 1);
Assert.IsBetween(*(byte*)&v.x3,  0, 1);
Assert.IsBetween(*(byte*)&v.x4,  0, 1);
Assert.IsBetween(*(byte*)&v.x5,  0, 1);
Assert.IsBetween(*(byte*)&v.x6,  0, 1);
Assert.IsBetween(*(byte*)&v.x7,  0, 1);
Assert.IsBetween(*(byte*)&v.x8,  0, 1);
Assert.IsBetween(*(byte*)&v.x9,  0, 1);
Assert.IsBetween(*(byte*)&v.x10, 0, 1);
Assert.IsBetween(*(byte*)&v.x11, 0, 1);
Assert.IsBetween(*(byte*)&v.x12, 0, 1);
Assert.IsBetween(*(byte*)&v.x13, 0, 1);
Assert.IsBetween(*(byte*)&v.x14, 0, 1);
Assert.IsBetween(*(byte*)&v.x15, 0, 1);

            return (v128)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 cvt_int8(bool32 v)
        {
Assert.IsBetween(*(byte*)&v.x0,  0, 1);
Assert.IsBetween(*(byte*)&v.x1,  0, 1);
Assert.IsBetween(*(byte*)&v.x2,  0, 1);
Assert.IsBetween(*(byte*)&v.x3,  0, 1);
Assert.IsBetween(*(byte*)&v.x4,  0, 1);
Assert.IsBetween(*(byte*)&v.x5,  0, 1);
Assert.IsBetween(*(byte*)&v.x6,  0, 1);
Assert.IsBetween(*(byte*)&v.x7,  0, 1);
Assert.IsBetween(*(byte*)&v.x8,  0, 1);
Assert.IsBetween(*(byte*)&v.x9,  0, 1);
Assert.IsBetween(*(byte*)&v.x10, 0, 1);
Assert.IsBetween(*(byte*)&v.x11, 0, 1);
Assert.IsBetween(*(byte*)&v.x12, 0, 1);
Assert.IsBetween(*(byte*)&v.x13, 0, 1);
Assert.IsBetween(*(byte*)&v.x14, 0, 1);
Assert.IsBetween(*(byte*)&v.x15, 0, 1);
Assert.IsBetween(*(byte*)&v.x16, 0, 1);
Assert.IsBetween(*(byte*)&v.x17, 0, 1);
Assert.IsBetween(*(byte*)&v.x18, 0, 1);
Assert.IsBetween(*(byte*)&v.x19, 0, 1);
Assert.IsBetween(*(byte*)&v.x20, 0, 1);
Assert.IsBetween(*(byte*)&v.x21, 0, 1);
Assert.IsBetween(*(byte*)&v.x22, 0, 1);
Assert.IsBetween(*(byte*)&v.x23, 0, 1);
Assert.IsBetween(*(byte*)&v.x24, 0, 1);
Assert.IsBetween(*(byte*)&v.x25, 0, 1);
Assert.IsBetween(*(byte*)&v.x26, 0, 1);
Assert.IsBetween(*(byte*)&v.x27, 0, 1);
Assert.IsBetween(*(byte*)&v.x28, 0, 1);
Assert.IsBetween(*(byte*)&v.x29, 0, 1);
Assert.IsBetween(*(byte*)&v.x30, 0, 1);
Assert.IsBetween(*(byte*)&v.x31, 0, 1);

            return (v256)v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 cvt_uint16(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return (ushort2)(*(byte2*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 cvt_uint16(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return (ushort3)(*(byte3*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 cvt_uint16(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return (ushort4)(*(byte4*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 cvt_uint16(bool8 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);

            return (ushort8)((byte8)(v128)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 cvt_uint16(bool16 v)
        {
Assert.IsBetween(*(byte*)&v.x0,  0, 1);
Assert.IsBetween(*(byte*)&v.x1,  0, 1);
Assert.IsBetween(*(byte*)&v.x2,  0, 1);
Assert.IsBetween(*(byte*)&v.x3,  0, 1);
Assert.IsBetween(*(byte*)&v.x4,  0, 1);
Assert.IsBetween(*(byte*)&v.x5,  0, 1);
Assert.IsBetween(*(byte*)&v.x6,  0, 1);
Assert.IsBetween(*(byte*)&v.x7,  0, 1);
Assert.IsBetween(*(byte*)&v.x8,  0, 1);
Assert.IsBetween(*(byte*)&v.x9,  0, 1);
Assert.IsBetween(*(byte*)&v.x10, 0, 1);
Assert.IsBetween(*(byte*)&v.x11, 0, 1);
Assert.IsBetween(*(byte*)&v.x12, 0, 1);
Assert.IsBetween(*(byte*)&v.x13, 0, 1);
Assert.IsBetween(*(byte*)&v.x14, 0, 1);
Assert.IsBetween(*(byte*)&v.x15, 0, 1);

            return (ushort16)((byte16)(v128)v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 cvt_int16(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return (short2)(*(byte2*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 cvt_int16(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return (short3)(*(byte3*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 cvt_int16(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return (short4)(*(byte4*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 cvt_int16(bool8 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);

            return (short8)((byte8)(v128)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 cvt_int16(bool16 v)
        {
Assert.IsBetween(*(byte*)&v.x0,  0, 1);
Assert.IsBetween(*(byte*)&v.x1,  0, 1);
Assert.IsBetween(*(byte*)&v.x2,  0, 1);
Assert.IsBetween(*(byte*)&v.x3,  0, 1);
Assert.IsBetween(*(byte*)&v.x4,  0, 1);
Assert.IsBetween(*(byte*)&v.x5,  0, 1);
Assert.IsBetween(*(byte*)&v.x6,  0, 1);
Assert.IsBetween(*(byte*)&v.x7,  0, 1);
Assert.IsBetween(*(byte*)&v.x8,  0, 1);
Assert.IsBetween(*(byte*)&v.x9,  0, 1);
Assert.IsBetween(*(byte*)&v.x10, 0, 1);
Assert.IsBetween(*(byte*)&v.x11, 0, 1);
Assert.IsBetween(*(byte*)&v.x12, 0, 1);
Assert.IsBetween(*(byte*)&v.x13, 0, 1);
Assert.IsBetween(*(byte*)&v.x14, 0, 1);
Assert.IsBetween(*(byte*)&v.x15, 0, 1);

            return (short16)((byte16)(v128)v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 cvt_uint32(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return (uint2)(*(byte2*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 cvt_uint32(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return (uint3)(*(byte3*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 cvt_uint32(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return (uint4)(*(byte4*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 cvt_uint32(bool8 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);

            return (uint8)((byte8)(v128)v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 cvt_int32(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return (int2)(*(byte2*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 cvt_int32(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return (int3)(*(byte3*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 cvt_int32(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return (int4)(*(byte4*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 cvt_int32(bool8 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);

            return (int8)((byte8)(v128)v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 cvt_uint64(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return (ulong2)(*(byte2*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 cvt_uint64(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return (ulong3)(*(byte3*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 cvt_uint64(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return (ulong4)(*(byte4*)&v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 cvt_int64(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return (long2)(*(byte2*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 cvt_int64(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return (long3)(*(byte3*)&v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 cvt_int64(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return (long4)(*(byte4*)&v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 cvt_f16(bool2 v)
        {
            ushort2 backingFields = select((ushort2)0, (ushort2)new half(1f).value, v);
            
            return *(half2*)&backingFields;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 cvt_f16(bool3 v)
        {
            ushort3 backingFields = select((ushort3)0, (ushort3)new half(1f).value, v);

            return *(half3*)&backingFields;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 cvt_f16(bool4 v)
        {
            ushort4 backingFields = select((ushort4)0, (ushort4)new half(1f).value, v);

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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(byte2 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);

            return *(bool2*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(sbyte2 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);

            return *(bool2*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(short2 v)
        {
            return cvt_boolean((byte2)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(ushort2 v)
        {
            return cvt_boolean((byte2)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(int2 v)
        {
            return cvt_boolean((byte2)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(uint2 v)
        {
            return cvt_boolean((byte2)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(long2 v)
        {
            return cvt_boolean((byte2)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(ulong2 v)
        {
            return cvt_boolean((byte2)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(float2 v)
        {
Assert.IsTrue(v.x == 0f || v.x == 1f);
Assert.IsTrue(v.y == 0f || v.y == 1f);

            return v == 1f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 cvt_boolean(double2 v)
        {
Assert.IsTrue(v.x == 0d || v.x == 1d);
Assert.IsTrue(v.y == 0d || v.y == 1d);

            return v == 1d; 
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(byte3 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);
Assert.IsBetween(v.z, 0, 1);

            return *(bool3*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(sbyte3 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);
Assert.IsBetween(v.z, 0, 1);

            return *(bool3*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(short3 v)
        {
            return cvt_boolean((byte3)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(ushort3 v)
        {
            return cvt_boolean((byte3)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(int3 v)
        {
            return cvt_boolean((byte3)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(uint3 v)
        {
            return cvt_boolean((byte3)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(long3 v)
        {
            return cvt_boolean((byte3)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(ulong3 v)
        {
            return cvt_boolean((byte3)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(float3 v)
        {
Assert.IsTrue(v.x == 0f || v.x == 1f);
Assert.IsTrue(v.y == 0f || v.y == 1f);
Assert.IsTrue(v.z == 0f || v.z == 1f);

            return v == 1f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 cvt_boolean(double3 v)
        {
Assert.IsTrue(v.x == 0d || v.x == 1d);
Assert.IsTrue(v.y == 0d || v.y == 1d);
Assert.IsTrue(v.z == 0d || v.z == 1d);

            return v == 1d; 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(byte4 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);
Assert.IsBetween(v.z, 0, 1);
Assert.IsBetween(v.w, 0, 1);

            return *(bool4*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(sbyte4 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);
Assert.IsBetween(v.z, 0, 1);
Assert.IsBetween(v.w, 0, 1);

            return *(bool4*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(short4 v)
        {
            return cvt_boolean((byte4)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(ushort4 v)
        {
            return cvt_boolean((byte4)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(int4 v)
        {
            return cvt_boolean((byte4)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(uint4 v)
        {
            return cvt_boolean((byte4)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(long4 v)
        {
            return cvt_boolean((byte4)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(ulong4 v)
        {
            return cvt_boolean((byte4)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(float4 v)
        {
Assert.IsTrue(v.x == 0f || v.x == 1f);
Assert.IsTrue(v.y == 0f || v.y == 1f);
Assert.IsTrue(v.z == 0f || v.z == 1f);
Assert.IsTrue(v.w == 0f || v.w == 1f);

            return v == 1f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 cvt_boolean(double4 v)
        {
Assert.IsTrue(v.x == 0d || v.x == 1d);
Assert.IsTrue(v.y == 0d || v.y == 1d);
Assert.IsTrue(v.z == 0d || v.z == 1d);
Assert.IsTrue(v.w == 0d || v.w == 1d);

            return v == 1d; 
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 cvt_boolean(byte8 v)
        {
Assert.IsBetween(v.x0,  0, 1);
Assert.IsBetween(v.x1,  0, 1);
Assert.IsBetween(v.x2,  0, 1);
Assert.IsBetween(v.x3,  0, 1);
Assert.IsBetween(v.x4,  0, 1);
Assert.IsBetween(v.x5,  0, 1);
Assert.IsBetween(v.x6,  0, 1);
Assert.IsBetween(v.x7,  0, 1);

            return (v128)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 cvt_boolean(sbyte8 v)
        {
Assert.IsBetween(v.x0,  0, 1);
Assert.IsBetween(v.x1,  0, 1);
Assert.IsBetween(v.x2,  0, 1);
Assert.IsBetween(v.x3,  0, 1);
Assert.IsBetween(v.x4,  0, 1);
Assert.IsBetween(v.x5,  0, 1);
Assert.IsBetween(v.x6,  0, 1);
Assert.IsBetween(v.x7,  0, 1);

            return (v128)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 cvt_boolean(short8 v)
        {
            return cvt_boolean((byte8)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 cvt_boolean(ushort8 v)
        {
            return cvt_boolean((byte8)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 cvt_boolean(int8 v)
        {
            return cvt_boolean((byte8)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 cvt_boolean(uint8 v)
        {
            return cvt_boolean((byte8)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 cvt_boolean(float8 v)
        {
Assert.IsTrue(v.x0 == 0f || v.x0 == 1f);
Assert.IsTrue(v.x1 == 0f || v.x1 == 1f);
Assert.IsTrue(v.x2 == 0f || v.x2 == 1f);
Assert.IsTrue(v.x3 == 0f || v.x3 == 1f);
Assert.IsTrue(v.x4 == 0f || v.x4 == 1f);
Assert.IsTrue(v.x5 == 0f || v.x5 == 1f);
Assert.IsTrue(v.x6 == 0f || v.x6 == 1f);
Assert.IsTrue(v.x7 == 0f || v.x7 == 1f);

            return v == 1f;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 cvt_boolean(byte16 v)
        {
Assert.IsBetween(v.x0,  0, 1);
Assert.IsBetween(v.x1,  0, 1);
Assert.IsBetween(v.x2,  0, 1);
Assert.IsBetween(v.x3,  0, 1);
Assert.IsBetween(v.x4,  0, 1);
Assert.IsBetween(v.x5,  0, 1);
Assert.IsBetween(v.x6,  0, 1);
Assert.IsBetween(v.x7,  0, 1);
Assert.IsBetween(v.x8,  0, 1);
Assert.IsBetween(v.x9,  0, 1);
Assert.IsBetween(v.x10, 0, 1);
Assert.IsBetween(v.x11, 0, 1);
Assert.IsBetween(v.x12, 0, 1);
Assert.IsBetween(v.x13, 0, 1);
Assert.IsBetween(v.x14, 0, 1);
Assert.IsBetween(v.x15, 0, 1);

            return (v128)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 cvt_boolean(sbyte16 v)
        {
Assert.IsBetween(v.x0,  0, 1);
Assert.IsBetween(v.x1,  0, 1);
Assert.IsBetween(v.x2,  0, 1);
Assert.IsBetween(v.x3,  0, 1);
Assert.IsBetween(v.x4,  0, 1);
Assert.IsBetween(v.x5,  0, 1);
Assert.IsBetween(v.x6,  0, 1);
Assert.IsBetween(v.x7,  0, 1);
Assert.IsBetween(v.x8,  0, 1);
Assert.IsBetween(v.x9,  0, 1);
Assert.IsBetween(v.x10, 0, 1);
Assert.IsBetween(v.x11, 0, 1);
Assert.IsBetween(v.x12, 0, 1);
Assert.IsBetween(v.x13, 0, 1);
Assert.IsBetween(v.x14, 0, 1);
Assert.IsBetween(v.x15, 0, 1);

            return (v128)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 cvt_boolean(short16 v)
        {
            return cvt_boolean((byte16)v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 cvt_boolean(ushort16 v)
        {
            return cvt_boolean((byte16)v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 cvt_boolean(byte32 v)
        {
Assert.IsBetween(v.x0,  0, 1);
Assert.IsBetween(v.x1,  0, 1);
Assert.IsBetween(v.x2,  0, 1);
Assert.IsBetween(v.x3,  0, 1);
Assert.IsBetween(v.x4,  0, 1);
Assert.IsBetween(v.x5,  0, 1);
Assert.IsBetween(v.x6,  0, 1);
Assert.IsBetween(v.x7,  0, 1);
Assert.IsBetween(v.x8,  0, 1);
Assert.IsBetween(v.x9,  0, 1);
Assert.IsBetween(v.x10, 0, 1);
Assert.IsBetween(v.x11, 0, 1);
Assert.IsBetween(v.x12, 0, 1);
Assert.IsBetween(v.x13, 0, 1);
Assert.IsBetween(v.x14, 0, 1);
Assert.IsBetween(v.x15, 0, 1);
Assert.IsBetween(v.x16, 0, 1);
Assert.IsBetween(v.x17, 0, 1);
Assert.IsBetween(v.x18, 0, 1);
Assert.IsBetween(v.x19, 0, 1);
Assert.IsBetween(v.x20, 0, 1);
Assert.IsBetween(v.x21, 0, 1);
Assert.IsBetween(v.x22, 0, 1);
Assert.IsBetween(v.x23, 0, 1);
Assert.IsBetween(v.x24, 0, 1);
Assert.IsBetween(v.x25, 0, 1);
Assert.IsBetween(v.x26, 0, 1);
Assert.IsBetween(v.x27, 0, 1);
Assert.IsBetween(v.x28, 0, 1);
Assert.IsBetween(v.x29, 0, 1);
Assert.IsBetween(v.x30, 0, 1);
Assert.IsBetween(v.x31, 0, 1);

            return (v256)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 cvt_boolean(sbyte32 v)
        {
Assert.IsBetween(v.x0,  0, 1);
Assert.IsBetween(v.x1,  0, 1);
Assert.IsBetween(v.x2,  0, 1);
Assert.IsBetween(v.x3,  0, 1);
Assert.IsBetween(v.x4,  0, 1);
Assert.IsBetween(v.x5,  0, 1);
Assert.IsBetween(v.x6,  0, 1);
Assert.IsBetween(v.x7,  0, 1);
Assert.IsBetween(v.x8,  0, 1);
Assert.IsBetween(v.x9,  0, 1);
Assert.IsBetween(v.x10, 0, 1);
Assert.IsBetween(v.x11, 0, 1);
Assert.IsBetween(v.x12, 0, 1);
Assert.IsBetween(v.x13, 0, 1);
Assert.IsBetween(v.x14, 0, 1);
Assert.IsBetween(v.x15, 0, 1);
Assert.IsBetween(v.x16, 0, 1);
Assert.IsBetween(v.x17, 0, 1);
Assert.IsBetween(v.x18, 0, 1);
Assert.IsBetween(v.x19, 0, 1);
Assert.IsBetween(v.x20, 0, 1);
Assert.IsBetween(v.x21, 0, 1);
Assert.IsBetween(v.x22, 0, 1);
Assert.IsBetween(v.x23, 0, 1);
Assert.IsBetween(v.x24, 0, 1);
Assert.IsBetween(v.x25, 0, 1);
Assert.IsBetween(v.x26, 0, 1);
Assert.IsBetween(v.x27, 0, 1);
Assert.IsBetween(v.x28, 0, 1);
Assert.IsBetween(v.x29, 0, 1);
Assert.IsBetween(v.x30, 0, 1);
Assert.IsBetween(v.x31, 0, 1);

            return (v256)v;
        }
    }
}