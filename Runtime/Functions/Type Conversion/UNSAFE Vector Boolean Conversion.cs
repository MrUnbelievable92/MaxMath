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
        public static byte2 touint8(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return *(byte2*)&x;
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a byte3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 touint8(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return *(byte3*)&x;
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a byte4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 touint8(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return *(byte4*)&x;
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a byte6 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 touint8(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return (v128)x;
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a byte16 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 touint8(bool16 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

            return (v128)x;
        }

        /// <summary>       Converts each value in a bool32 vector to its integer representation as a byte32 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 touint8(bool32 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);
Assert.IsSafeBoolean(x.x16);
Assert.IsSafeBoolean(x.x17);
Assert.IsSafeBoolean(x.x18);
Assert.IsSafeBoolean(x.x19);
Assert.IsSafeBoolean(x.x20);
Assert.IsSafeBoolean(x.x21);
Assert.IsSafeBoolean(x.x22);
Assert.IsSafeBoolean(x.x23);
Assert.IsSafeBoolean(x.x24);
Assert.IsSafeBoolean(x.x25);
Assert.IsSafeBoolean(x.x26);
Assert.IsSafeBoolean(x.x27);
Assert.IsSafeBoolean(x.x28);
Assert.IsSafeBoolean(x.x29);
Assert.IsSafeBoolean(x.x30);
Assert.IsSafeBoolean(x.x31);

            return (v256)x;
        }

        /// <summary>       Converts each value in a bool2 vector to its integer representation as an sbyte2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 toint8(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return *(sbyte2*)&x;
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as an sbyte3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 toint8(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return *(sbyte3*)&x;
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as an sbyte4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 toint8(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return *(sbyte4*)&x;
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as an sbyte8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 toint8(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return (v128)x;
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as an sbyte16 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 toint8(bool16 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

            return (v128)x;
        }

        /// <summary>       Converts each value in a bool32 vector to its integer representation as an sbyte32 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 toint8(bool32 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);
Assert.IsSafeBoolean(x.x16);
Assert.IsSafeBoolean(x.x17);
Assert.IsSafeBoolean(x.x18);
Assert.IsSafeBoolean(x.x19);
Assert.IsSafeBoolean(x.x20);
Assert.IsSafeBoolean(x.x21);
Assert.IsSafeBoolean(x.x22);
Assert.IsSafeBoolean(x.x23);
Assert.IsSafeBoolean(x.x24);
Assert.IsSafeBoolean(x.x25);
Assert.IsSafeBoolean(x.x26);
Assert.IsSafeBoolean(x.x27);
Assert.IsSafeBoolean(x.x28);
Assert.IsSafeBoolean(x.x29);
Assert.IsSafeBoolean(x.x30);
Assert.IsSafeBoolean(x.x31);

            return (v256)x;
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a ushort2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 touint16(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (ushort2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a ushort3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 touint16(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (ushort3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a ushort4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 touint16(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (ushort4)(*(byte4*)&x);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a ushort8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 touint16(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return (ushort8)((byte8)(v128)x);
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a ushort16 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 touint16(bool16 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

            return (ushort16)((byte16)(v128)x);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a short2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toint16(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (short2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a short3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toint16(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (short3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a short4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toint16(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (short4)(*(byte4*)&x);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a short8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toint16(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return (short8)((byte8)(v128)x);
        }

        /// <summary>       Converts each value in a bool16 vector to its integer representation as a short16 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toint16(bool16 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

            return (short16)((byte16)(v128)x);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a uint2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint32(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (uint2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a uint3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint32(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (uint3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a uint4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint32(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (uint4)(*(byte4*)&x);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as a uint8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touint32(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return (uint8)((byte8)(v128)x);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as an int2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint32(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (int2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as an int3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint32(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (int3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as an int4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint32(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (int4)(*(byte4*)&x);
        }

        /// <summary>       Converts each value in a bool8 vector to its integer representation as an int8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 toint32(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return (int8)((byte8)(v128)x);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a ulong2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 touint64(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (ulong2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a ulong3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 touint64(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (ulong3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a ulong4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 touint64(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (ulong4)(*(byte4*)&x);
        }


        /// <summary>       Converts each value in a bool2 vector to its integer representation as a long2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 toint64(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (long2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a bool3 vector to its integer representation as a long3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 toint64(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (long3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a bool4 vector to its integer representation as a long4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 toint64(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (long4)(*(byte4*)&x);
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a half2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tof16(bool2 x)
        {
            return ashalf(select((ushort2)0, (ushort2)new half(1f).value, x));
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a half3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tof16(bool3 x)
        {
            return ashalf(select((ushort3)0, (ushort3)new half(1f).value, x));
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a half4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tof16(bool4 x)
        {
            return ashalf(select((ushort4)0, (ushort4)new half(1f).value, x));
        }

        /// <summary>       Converts each value in a bool8 vector to its floating point representation as a half8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tof16(bool8 x)
        {
            return ashalf(select((ushort8)0, (ushort8)new half(1f).value, x));
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a float2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tof32(bool2 x)
        {
            return math.select(default(float2), new float2(1f), x);
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a float3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tof32(bool3 x)
        {
            return math.select(default(float3), new float3(1f), x);
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a float4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tof32(bool4 x)
        {
            return math.select(default(float4), new float4(1f), x);
        }

        /// <summary>       Converts each value in a bool8 vector to its floating point representation as a float8 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tof32(bool8 x)
        {
            return select(new float8(0f), new float8(1f), x);
        }


        /// <summary>       Converts each value in a bool2 vector to its floating point representation as a double2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 tof64(bool2 x)
        {
            return math.select(default(double2), new double2(1d), x);
        }

        /// <summary>       Converts each value in a bool3 vector to its floating point representation as a double3 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 tof64(bool3 x)
        {
            return math.select(default(double3), new double3(1d), x);
        }

        /// <summary>       Converts each value in a bool4 vector to its floating point representation as a double4 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 tof64(bool4 x)
        {
            return math.select(default(double4), new double4(1d), x);
        }


        /// <summary>       Converts each value in a byte2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(byte2 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);

            return *(bool2*)&x;
        }

        /// <summary>       Converts each value in an sbyte2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(sbyte2 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);

            return *(bool2*)&x;
        }

        /// <summary>       Converts each value in a short2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(short2 x)
        {
            return tobool((byte2)x);
        }

        /// <summary>       Converts each value in a ushort2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(ushort2 x)
        {
            return tobool((byte2)x);
        }

        /// <summary>       Converts each value in an int2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(int2 x)
        {
            return tobool((byte2)x);
        }

        /// <summary>       Converts each value in a uint2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(uint2 x)
        {
            return tobool((byte2)x);
        }

        /// <summary>       Converts each value in a long2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(long2 x)
        {
            return tobool((byte2)x);
        }

        /// <summary>       Converts each value in a ulong2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(ulong2 x)
        {
            return tobool((byte2)x);
        }

        /// <summary>       Converts each value in a half2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(half2 x)
        {
Assert.IsTrue(x.x == (half)0f || x.x == (half)1f);
Assert.IsTrue(x.y == (half)0f || x.y == (half)1f);

            return asushort(x) == new half(1f).value;
        }

        /// <summary>       Converts each value in a float2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(float2 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);

            return math.asint(x) == math.asint(1f);
        }

        /// <summary>       Converts each value in a double2 vector to its boolean representation as a bool2 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(double2 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);

            return aslong(x) == math.aslong(1d);
        }


        /// <summary>       Converts each value in a byte3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(byte3 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);

            return *(bool3*)&x;
        }

        /// <summary>       Converts each value in an sbyte3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(sbyte3 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);

            return *(bool3*)&x;
        }

        /// <summary>       Converts each value in a short3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(short3 x)
        {
            return tobool((byte3)x);
        }

        /// <summary>       Converts each value in a ushort3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(ushort3 x)
        {
            return tobool((byte3)x);
        }

        /// <summary>       Converts each value in an int3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(int3 x)
        {
            return tobool((byte3)x);
        }

        /// <summary>       Converts each value in a uint3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(uint3 x)
        {
            return tobool((byte3)x);
        }

        /// <summary>       Converts each value in a long3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(long3 x)
        {
            return tobool((byte3)x);
        }

        /// <summary>       Converts each value in a ulong3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(ulong3 x)
        {
            return tobool((byte3)x);
        }

        /// <summary>       Converts each value in a half3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(half3 x)
        {
Assert.IsTrue(x.x == (half)0f || x.x == (half)1f);
Assert.IsTrue(x.y == (half)0f || x.y == (half)1f);
Assert.IsTrue(x.z == (half)0f || x.z == (half)1f);

            return asushort(x) == new half(1f).value;
        }

        /// <summary>       Converts each value in a float3 vector to its boolean representation as a bool3 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(float3 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);
Assert.IsTrue(x.z == 0f || x.z == 1f);

            return math.asint(x) == math.asint(1f);
        }

        /// <summary>       Converts each value in a double3 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(double3 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);
Assert.IsTrue(x.z == 0d || x.z == 1d);

            return aslong(x) == math.aslong(1d);
        }

        /// <summary>       Converts each value in a byte4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(byte4 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);
Assert.IsBetween(x.w, 0, 1);

            return *(bool4*)&x;
        }

        /// <summary>       Converts each value in an sbyte4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(sbyte4 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);
Assert.IsBetween(x.w, 0, 1);

            return *(bool4*)&x;
        }

        /// <summary>       Converts each value in a short4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(short4 x)
        {
            return tobool((byte4)x);
        }

        /// <summary>       Converts each value in a ushor4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(ushort4 x)
        {
            return tobool((byte4)x);
        }

        /// <summary>       Converts each value in an int4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(int4 x)
        {
            return tobool((byte4)x);
        }

        /// <summary>       Converts each value in a uint4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(uint4 x)
        {
            return tobool((byte4)x);
        }

        /// <summary>       Converts each value in a long4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(long4 x)
        {
            return tobool((byte4)x);
        }

        /// <summary>       Converts each value in a ulong4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(ulong4 x)
        {
            return tobool((byte4)x);
        }

        /// <summary>       Converts each value in a half4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(half4 x)
        {
Assert.IsTrue(x.x == (half)0f || x.x == (half)1f);
Assert.IsTrue(x.y == (half)0f || x.y == (half)1f);
Assert.IsTrue(x.z == (half)0f || x.z == (half)1f);
Assert.IsTrue(x.w == (half)0f || x.w == (half)1f);

            return asushort(x) == new half(1f).value;
        }

        /// <summary>       Converts each value in a float4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(float4 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);
Assert.IsTrue(x.z == 0f || x.z == 1f);
Assert.IsTrue(x.w == 0f || x.w == 1f);

            return math.asint(x) == math.asint(1f);
        }

        /// <summary>       Converts each value in a double4 vector to its boolean representation as a bool4 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(double4 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);
Assert.IsTrue(x.z == 0d || x.z == 1d);
Assert.IsTrue(x.w == 0d || x.w == 1d);

            return aslong(x) == math.aslong(1d);
        }


        /// <summary>       Converts each value in a byte8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(byte8 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);

            return (v128)x;
        }

        /// <summary>       Converts each value in an sbyte8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(sbyte8 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);

            return (v128)x;
        }

        /// <summary>       Converts each value in a short8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(short8 x)
        {
            return tobool((byte8)x);
        }

        /// <summary>       Converts each value in a ushort8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(ushort8 x)
        {
            return tobool((byte8)x);
        }

        /// <summary>       Converts each value in an int8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(int8 x)
        {
            return tobool((byte8)x);
        }

        /// <summary>       Converts each value in a uint8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(uint8 x)
        {
            return tobool((byte8)x);
        }

        /// <summary>       Converts each value in a float8 vector to its boolean representation as a bool8 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(float8 x)
        {
Assert.IsTrue(x.x0 == 0f || x.x0 == 1f);
Assert.IsTrue(x.x1 == 0f || x.x1 == 1f);
Assert.IsTrue(x.x2 == 0f || x.x2 == 1f);
Assert.IsTrue(x.x3 == 0f || x.x3 == 1f);
Assert.IsTrue(x.x4 == 0f || x.x4 == 1f);
Assert.IsTrue(x.x5 == 0f || x.x5 == 1f);
Assert.IsTrue(x.x6 == 0f || x.x6 == 1f);
Assert.IsTrue(x.x7 == 0f || x.x7 == 1f);

            return asint(x) == math.asint(1f);
        }


        /// <summary>       Converts each value in a byte16 vector to its boolean representation as a bool16 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(byte16 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);

            return (v128)x;
        }

        /// <summary>       Converts each value in an sbyte16 vector to its boolean representation as a bool16 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(sbyte16 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x8,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);

            return (v128)x;
        }

        /// <summary>       Converts each value in a short16 vector to its boolean representation as a bool16 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(short16 x)
        {
            return tobool((byte16)x);
        }

        /// <summary>       Converts each value in a ushort16 vector to its boolean representation as a bool16 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(ushort16 x)
        {
            return tobool((byte16)x);
        }


        /// <summary>       Converts each value in a byte32 vector to its boolean representation as a bool32 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool(byte32 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x8,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);
Assert.IsBetween(x.x16, 0, 1);
Assert.IsBetween(x.x17, 0, 1);
Assert.IsBetween(x.x18, 0, 1);
Assert.IsBetween(x.x19, 0, 1);
Assert.IsBetween(x.x20, 0, 1);
Assert.IsBetween(x.x21, 0, 1);
Assert.IsBetween(x.x22, 0, 1);
Assert.IsBetween(x.x23, 0, 1);
Assert.IsBetween(x.x24, 0, 1);
Assert.IsBetween(x.x25, 0, 1);
Assert.IsBetween(x.x26, 0, 1);
Assert.IsBetween(x.x27, 0, 1);
Assert.IsBetween(x.x28, 0, 1);
Assert.IsBetween(x.x29, 0, 1);
Assert.IsBetween(x.x30, 0, 1);
Assert.IsBetween(x.x31, 0, 1);

            return (v256)x;
        }

        /// <summary>       Converts each value in an sbyte32 vector to its boolean representation as a bool32 vector. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool(sbyte32 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x8,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);
Assert.IsBetween(x.x16, 0, 1);
Assert.IsBetween(x.x17, 0, 1);
Assert.IsBetween(x.x18, 0, 1);
Assert.IsBetween(x.x19, 0, 1);
Assert.IsBetween(x.x20, 0, 1);
Assert.IsBetween(x.x21, 0, 1);
Assert.IsBetween(x.x22, 0, 1);
Assert.IsBetween(x.x23, 0, 1);
Assert.IsBetween(x.x24, 0, 1);
Assert.IsBetween(x.x25, 0, 1);
Assert.IsBetween(x.x26, 0, 1);
Assert.IsBetween(x.x27, 0, 1);
Assert.IsBetween(x.x28, 0, 1);
Assert.IsBetween(x.x29, 0, 1);
Assert.IsBetween(x.x30, 0, 1);
Assert.IsBetween(x.x31, 0, 1);

            return (v256)x;
        }
    }
}