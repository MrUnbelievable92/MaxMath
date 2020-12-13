using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts each value in a bool2 vector to its integer representation as a byte2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 touint8(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return *(byte2*)&v;
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a byte3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 touint8(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return *(byte3*)&v;
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a byte4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 touint8(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return *(byte4*)&v;
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a byte6 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 touint8(bool8 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);

            return (v128)v;
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a byte16 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 touint8(bool16 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);
Assert.IsSafeBoolean(v.x8);
Assert.IsSafeBoolean(v.x9);
Assert.IsSafeBoolean(v.x10);
Assert.IsSafeBoolean(v.x11);
Assert.IsSafeBoolean(v.x12);
Assert.IsSafeBoolean(v.x13);
Assert.IsSafeBoolean(v.x14);
Assert.IsSafeBoolean(v.x15);

            return (v128)v;
        }

        /// <summary>       Converts each value in a bool32 vector to its integer representation as a byte32 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 touint8(bool32 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);
Assert.IsSafeBoolean(v.x8);
Assert.IsSafeBoolean(v.x9);
Assert.IsSafeBoolean(v.x10);
Assert.IsSafeBoolean(v.x11);
Assert.IsSafeBoolean(v.x12);
Assert.IsSafeBoolean(v.x13);
Assert.IsSafeBoolean(v.x14);
Assert.IsSafeBoolean(v.x15);
Assert.IsSafeBoolean(v.x16);
Assert.IsSafeBoolean(v.x17);
Assert.IsSafeBoolean(v.x18);
Assert.IsSafeBoolean(v.x19);
Assert.IsSafeBoolean(v.x20);
Assert.IsSafeBoolean(v.x21);
Assert.IsSafeBoolean(v.x22);
Assert.IsSafeBoolean(v.x23);
Assert.IsSafeBoolean(v.x24);
Assert.IsSafeBoolean(v.x25);
Assert.IsSafeBoolean(v.x26);
Assert.IsSafeBoolean(v.x27);
Assert.IsSafeBoolean(v.x28);
Assert.IsSafeBoolean(v.x29);
Assert.IsSafeBoolean(v.x30);
Assert.IsSafeBoolean(v.x31);

            return (v256)v;
        }

        /// <summary>       Converts each value in a bool2 vector to its integer representation as an sbyte2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 toint8(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return *(sbyte2*)&v;
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as an sbyte3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 toint8(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return *(sbyte3*)&v;
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as an sbyte4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 toint8(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return *(sbyte4*)&v;
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as an sbyte8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 toint8(bool8 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);

            return (v128)v;
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as an sbyte16 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 toint8(bool16 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);
Assert.IsSafeBoolean(v.x8);
Assert.IsSafeBoolean(v.x9);
Assert.IsSafeBoolean(v.x10);
Assert.IsSafeBoolean(v.x11);
Assert.IsSafeBoolean(v.x12);
Assert.IsSafeBoolean(v.x13);
Assert.IsSafeBoolean(v.x14);
Assert.IsSafeBoolean(v.x15);

            return (v128)v;
        }

        /// <summary>       Converts each value in a bool32 vector to its integer representation as an sbyte32 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 toint8(bool32 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);
Assert.IsSafeBoolean(v.x8);
Assert.IsSafeBoolean(v.x9);
Assert.IsSafeBoolean(v.x10);
Assert.IsSafeBoolean(v.x11);
Assert.IsSafeBoolean(v.x12);
Assert.IsSafeBoolean(v.x13);
Assert.IsSafeBoolean(v.x14);
Assert.IsSafeBoolean(v.x15);
Assert.IsSafeBoolean(v.x16);
Assert.IsSafeBoolean(v.x17);
Assert.IsSafeBoolean(v.x18);
Assert.IsSafeBoolean(v.x19);
Assert.IsSafeBoolean(v.x20);
Assert.IsSafeBoolean(v.x21);
Assert.IsSafeBoolean(v.x22);
Assert.IsSafeBoolean(v.x23);
Assert.IsSafeBoolean(v.x24);
Assert.IsSafeBoolean(v.x25);
Assert.IsSafeBoolean(v.x26);
Assert.IsSafeBoolean(v.x27);
Assert.IsSafeBoolean(v.x28);
Assert.IsSafeBoolean(v.x29);
Assert.IsSafeBoolean(v.x30);
Assert.IsSafeBoolean(v.x31);

            return (v256)v;
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a ushort2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 touint16(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return (ushort2)(*(byte2*)&v);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a ushort3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 touint16(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return (ushort3)(*(byte3*)&v);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a ushort4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 touint16(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return (ushort4)(*(byte4*)&v);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a ushort8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 touint16(bool8 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);

            return (ushort8)((byte8)(v128)v);
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a ushort16 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 touint16(bool16 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);
Assert.IsSafeBoolean(v.x8);
Assert.IsSafeBoolean(v.x9);
Assert.IsSafeBoolean(v.x10);
Assert.IsSafeBoolean(v.x11);
Assert.IsSafeBoolean(v.x12);
Assert.IsSafeBoolean(v.x13);
Assert.IsSafeBoolean(v.x14);
Assert.IsSafeBoolean(v.x15);

            return (ushort16)((byte16)(v128)v);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a short2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toint16(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return (short2)(*(byte2*)&v);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a short3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toint16(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return (short3)(*(byte3*)&v);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a short4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toint16(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return (short4)(*(byte4*)&v);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a short8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toint16(bool8 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);

            return (short8)((byte8)(v128)v);
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a short16 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toint16(bool16 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);
Assert.IsSafeBoolean(v.x8);
Assert.IsSafeBoolean(v.x9);
Assert.IsSafeBoolean(v.x10);
Assert.IsSafeBoolean(v.x11);
Assert.IsSafeBoolean(v.x12);
Assert.IsSafeBoolean(v.x13);
Assert.IsSafeBoolean(v.x14);
Assert.IsSafeBoolean(v.x15);

            return (short16)((byte16)(v128)v);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a uint2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint32(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return (uint2)(*(byte2*)&v);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a uint3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint32(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return (uint3)(*(byte3*)&v);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a uint4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint32(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return (uint4)(*(byte4*)&v);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a uint8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touint32(bool8 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);

            return (uint8)((byte8)(v128)v);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as an int2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint32(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return (int2)(*(byte2*)&v);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as an int3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint32(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return (int3)(*(byte3*)&v);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as an int4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint32(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return (int4)(*(byte4*)&v);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as an int8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 toint32(bool8 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);

            return (int8)((byte8)(v128)v);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a ulong2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 touint64(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return (ulong2)(*(byte2*)&v);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a ulong3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 touint64(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return (ulong3)(*(byte3*)&v);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a ulong4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 touint64(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return (ulong4)(*(byte4*)&v);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a long2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 toint64(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return (long2)(*(byte2*)&v);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a long3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 toint64(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return (long3)(*(byte3*)&v);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a long4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 toint64(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return (long4)(*(byte4*)&v);
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a half2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tof16(bool2 v)
        {
            return ashalf(select((ushort2)0, (ushort2)new half(1f).value, v));
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a half3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tof16(bool3 v)
        {
            return ashalf(select((ushort3)0, (ushort3)new half(1f).value, v));
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a half4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tof16(bool4 v)
        {
            return ashalf(select((ushort4)0, (ushort4)new half(1f).value, v));
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a float2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tof32(bool2 v)
        {
            return math.select(default(float2), new float2(1f), v);
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a float3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tof32(bool3 v)
        {
            return math.select(default(float3), new float3(1f), v);
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a float4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tof32(bool4 v)
        {
            return math.select(default(float4), new float4(1f), v);
        }

        /// <summary>       Converts each value in a bool8 vector to its floating point representation as a float8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tof32(bool8 v)
        {
            return select(new float8(0f), new float8(1f), v);
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a double2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 tof64(bool2 v)
        {
            return math.select(default(double2), new double2(1d), v);
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a double3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 tof64(bool3 v)
        {
            return math.select(default(double3), new double3(1d), v);
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a double4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 tof64(bool4 v)
        {
            return math.select(default(double4), new double4(1d), v);
        }


        /// <summary>       Converts each value in a byte2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(byte2 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);

            return *(bool2*)&v;
        }

        /// <summary>       Converts each value in an sbyte2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(sbyte2 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);

            return *(bool2*)&v;
        }

        /// <summary>       Converts each value in a short2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(short2 v)
        {
            return tobool((byte2)v);
        }

        /// <summary>       Converts each value in a ushort2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(ushort2 v)
        {
            return tobool((byte2)v);
        }

        /// <summary>       Converts each value in an int2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(int2 v)
        {
            return tobool((byte2)v);
        }

        /// <summary>       Converts each value in a uint2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(uint2 v)
        {
            return tobool((byte2)v);
        }

        /// <summary>       Converts each value in a long2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(long2 v)
        {
            return tobool((byte2)v);
        }

        /// <summary>       Converts each value in a ulong2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(ulong2 v)
        {
            return tobool((byte2)v);
        }

        /// <summary>       Converts each value in a half2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(half2 v)
        {
Assert.IsTrue(v.x == (half)0f || v.x == (half)1f);
Assert.IsTrue(v.y == (half)0f || v.y == (half)1f);

            return asushort(v) == new half(1f).value;
        }

        /// <summary>       Converts each value in a float2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(float2 v)
        {
Assert.IsTrue(v.x == 0f || v.x == 1f);
Assert.IsTrue(v.y == 0f || v.y == 1f);

            return math.asint(v) == math.asint(1f);
        }

        /// <summary>       Converts each value in a double2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(double2 v)
        {
Assert.IsTrue(v.x == 0d || v.x == 1d);
Assert.IsTrue(v.y == 0d || v.y == 1d);

            return aslong(v) == math.aslong(1d);
        }


        /// <summary>       Converts each value in a byte3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(byte3 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);
Assert.IsBetween(v.z, 0, 1);

            return *(bool3*)&v;
        }

        /// <summary>       Converts each value in an sbyte3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(sbyte3 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);
Assert.IsBetween(v.z, 0, 1);

            return *(bool3*)&v;
        }

        /// <summary>       Converts each value in a short3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(short3 v)
        {
            return tobool((byte3)v);
        }

        /// <summary>       Converts each value in a ushort3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(ushort3 v)
        {
            return tobool((byte3)v);
        }

        /// <summary>       Converts each value in an int3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(int3 v)
        {
            return tobool((byte3)v);
        }

        /// <summary>       Converts each value in a uint3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(uint3 v)
        {
            return tobool((byte3)v);
        }

        /// <summary>       Converts each value in a long3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(long3 v)
        {
            return tobool((byte3)v);
        }

        /// <summary>       Converts each value in a ulong3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(ulong3 v)
        {
            return tobool((byte3)v);
        }

        /// <summary>       Converts each value in a half3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(half3 v)
        {
Assert.IsTrue(v.x == (half)0f || v.x == (half)1f);
Assert.IsTrue(v.y == (half)0f || v.y == (half)1f);
Assert.IsTrue(v.z == (half)0f || v.z == (half)1f);

            return asushort(v) == new half(1f).value;
        }

        /// <summary>       Converts each value in a float3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(float3 v)
        {
Assert.IsTrue(v.x == 0f || v.x == 1f);
Assert.IsTrue(v.y == 0f || v.y == 1f);
Assert.IsTrue(v.z == 0f || v.z == 1f);

            return math.asint(v) == math.asint(1f);
        }

        /// <summary>       Converts each value in a double3 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(double3 v)
        {
Assert.IsTrue(v.x == 0d || v.x == 1d);
Assert.IsTrue(v.y == 0d || v.y == 1d);
Assert.IsTrue(v.z == 0d || v.z == 1d);

            return aslong(v) == math.aslong(1d);
        }

        /// <summary>       Converts each value in a byte4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(byte4 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);
Assert.IsBetween(v.z, 0, 1);
Assert.IsBetween(v.w, 0, 1);

            return *(bool4*)&v;
        }

        /// <summary>       Converts each value in an sbyte4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(sbyte4 v)
        {
Assert.IsBetween(v.x, 0, 1);
Assert.IsBetween(v.y, 0, 1);
Assert.IsBetween(v.z, 0, 1);
Assert.IsBetween(v.w, 0, 1);

            return *(bool4*)&v;
        }

        /// <summary>       Converts each value in a short4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(short4 v)
        {
            return tobool((byte4)v);
        }

        /// <summary>       Converts each value in a ushor4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(ushort4 v)
        {
            return tobool((byte4)v);
        }

        /// <summary>       Converts each value in an int4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(int4 v)
        {
            return tobool((byte4)v);
        }

        /// <summary>       Converts each value in a uint4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(uint4 v)
        {
            return tobool((byte4)v);
        }

        /// <summary>       Converts each value in a long4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(long4 v)
        {
            return tobool((byte4)v);
        }

        /// <summary>       Converts each value in a ulong4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(ulong4 v)
        {
            return tobool((byte4)v);
        }

        /// <summary>       Converts each value in a half4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(half4 v)
        {
Assert.IsTrue(v.x == (half)0f || v.x == (half)1f);
Assert.IsTrue(v.y == (half)0f || v.y == (half)1f);
Assert.IsTrue(v.z == (half)0f || v.z == (half)1f);
Assert.IsTrue(v.w == (half)0f || v.w == (half)1f);

            return asushort(v) == new half(1f).value;
        }

        /// <summary>       Converts each value in a float4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(float4 v)
        {
Assert.IsTrue(v.x == 0f || v.x == 1f);
Assert.IsTrue(v.y == 0f || v.y == 1f);
Assert.IsTrue(v.z == 0f || v.z == 1f);
Assert.IsTrue(v.w == 0f || v.w == 1f);

            return math.asint(v) == math.asint(1f);
        }

        /// <summary>       Converts each value in a double4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(double4 v)
        {
Assert.IsTrue(v.x == 0d || v.x == 1d);
Assert.IsTrue(v.y == 0d || v.y == 1d);
Assert.IsTrue(v.z == 0d || v.z == 1d);
Assert.IsTrue(v.w == 0d || v.w == 1d);

            return aslong(v) == math.aslong(1d);
        }


        /// <summary>       Converts each value in a byte8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(byte8 v)
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

        /// <summary>       Converts each value in an sbyte8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(sbyte8 v)
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

        /// <summary>       Converts each value in a short8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(short8 v)
        {
            return tobool((byte8)v);
        }

        /// <summary>       Converts each value in a ushort8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(ushort8 v)
        {
            return tobool((byte8)v);
        }

        /// <summary>       Converts each value in an int8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(int8 v)
        {
            return tobool((byte8)v);
        }

        /// <summary>       Converts each value in a uint8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(uint8 v)
        {
            return tobool((byte8)v);
        }

        /// <summary>       Converts each value in a float8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(float8 v)
        {
Assert.IsTrue(v.x0 == 0f || v.x0 == 1f);
Assert.IsTrue(v.x1 == 0f || v.x1 == 1f);
Assert.IsTrue(v.x2 == 0f || v.x2 == 1f);
Assert.IsTrue(v.x3 == 0f || v.x3 == 1f);
Assert.IsTrue(v.x4 == 0f || v.x4 == 1f);
Assert.IsTrue(v.x5 == 0f || v.x5 == 1f);
Assert.IsTrue(v.x6 == 0f || v.x6 == 1f);
Assert.IsTrue(v.x7 == 0f || v.x7 == 1f);

            return asint(v) == math.asint(1f);
        }


        /// <summary>       Converts each value in a byte16 vector to its boolean representation as a bool16 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(byte16 v)
        {
Assert.IsBetween(v.x0,  0, 1);
Assert.IsBetween(v.x1,  0, 1);
Assert.IsBetween(v.x2,  0, 1);
Assert.IsBetween(v.x3,  0, 1);
Assert.IsBetween(v.x4,  0, 1);
Assert.IsBetween(v.x5,  0, 1);
Assert.IsBetween(v.x6,  0, 1);
Assert.IsBetween(v.x7,  0, 1);
Assert.IsBetween(v.x2,  0, 1);
Assert.IsBetween(v.x9,  0, 1);
Assert.IsBetween(v.x10, 0, 1);
Assert.IsBetween(v.x11, 0, 1);
Assert.IsBetween(v.x12, 0, 1);
Assert.IsBetween(v.x13, 0, 1);
Assert.IsBetween(v.x14, 0, 1);
Assert.IsBetween(v.x15, 0, 1);

            return (v128)v;
        }

        /// <summary>       Converts each value in an sbyte16 vector to its boolean representation as a bool16 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(sbyte16 v)
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

        /// <summary>       Converts each value in a short16 vector to its boolean representation as a bool16 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(short16 v)
        {
            return tobool((byte16)v);
        }

        /// <summary>       Converts each value in a ushort16 vector to its boolean representation as a bool16 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(ushort16 v)
        {
            return tobool((byte16)v);
        }


        /// <summary>       Converts each value in a byte32 vector to its boolean representation as a bool32 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool(byte32 v)
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

        /// <summary>       Converts each value in an sbyte32 vector to its boolean representation as a bool32 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool(sbyte32 v)
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