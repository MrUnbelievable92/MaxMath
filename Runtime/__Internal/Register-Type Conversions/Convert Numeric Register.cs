using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class RegisterConversion
    {
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 ToV256(double3 input)
        {
            if (Avx.IsAvxSupported)
            {
                v256 result = Avx.mm256_undefined_pd();

                result.Double0 = input.x;
                result.Double1 = input.y;
                result.Double2 = input.z;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 ToV256(double4 input)
        {
            if (Avx.IsAvxSupported)
            {
                return new v256
                {
                    Double0 = input.x,
                    Double1 = input.y,
                    Double2 = input.z,
                    Double3 = input.w
                };
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(double2 input)
        {
            return new v128
            {
                Double0 = input.x,
                Double1 = input.y
            };
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(double input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_pd();

                result.Double0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Double0 = input;

                return result;
            }
        }
        
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(float input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_ps();

                result.Float0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Float0 = input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(float2 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_ps();

                result.Float0 = input.x;
                result.Float1 = input.y;

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Float0 = input.x;
                result.Float1 = input.y;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(float3 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_ps();

                result.Float0 = input.x;
                result.Float1 = input.y;
                result.Float2 = input.z;

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Float0 = input.x;
                result.Float1 = input.y;
                result.Float2 = input.z;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(float4 input)
        {
            return new v128
            {
                Float0 = input.x,
                Float1 = input.y,
                Float2 = input.z,
                Float3 = input.w
            };
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(int input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.SInt0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.SInt0 = input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(int2 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.SInt0 = input.x;
                result.SInt1 = input.y;

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.SInt0 = input.x;
                result.SInt1 = input.y;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(int3 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.SInt0 = input.x;
                result.SInt1 = input.y;
                result.SInt2 = input.z;

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.SInt0 = input.x;
                result.SInt1 = input.y;
                result.SInt2 = input.z;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(int4 input)
        {
            return new v128
            {
                SInt0 = input.x,
                SInt1 = input.y,
                SInt2 = input.z,
                SInt3 = input.w
            };
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(uint input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.UInt0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.UInt0 = input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(uint2 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.UInt0 = input.x;
                result.UInt1 = input.y;

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.UInt0 = input.x;
                result.UInt1 = input.y;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(uint3 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.UInt0 = input.x;
                result.UInt1 = input.y;
                result.UInt2 = input.z;

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.UInt0 = input.x;
                result.UInt1 = input.y;
                result.UInt2 = input.z;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(uint4 input)
        {
            return new v128
            {
                UInt0 = input.x,
                UInt1 = input.y,
                UInt2 = input.z,
                UInt3 = input.w
            };
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(half input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.UShort0 = input.value;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.UShort0 = input.value;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(half2 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.UShort0 = input.x.value;
                result.UShort1 = input.y.value;

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.UShort0 = input.x.value;
                result.UShort1 = input.y.value;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(half3 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.UShort0 = input.x.value;
                result.UShort1 = input.y.value;
                result.UShort2 = input.z.value;

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.UShort0 = input.x.value;
                result.UShort1 = input.y.value;
                result.UShort2 = input.z.value;

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(half4 input)
        {
            return new v128
            {
                UShort0 = input.x.value,
                UShort1 = input.y.value,
                UShort2 = input.z.value,
                UShort3 = input.w.value
            };
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(bool input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.Byte0 = *(byte*)&input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Byte0 = *(byte*)&input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(bool2 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.Byte0 = maxmath.tobyte(input.x);
                result.Byte1 = maxmath.tobyte(input.y);

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Byte0 = maxmath.tobyte(input.x);
                result.Byte1 = maxmath.tobyte(input.y);

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(bool3 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.Byte0 = maxmath.tobyte(input.x);
                result.Byte1 = maxmath.tobyte(input.y);
                result.Byte2 = maxmath.tobyte(input.z);

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Byte0 = maxmath.tobyte(input.x);
                result.Byte1 = maxmath.tobyte(input.y);
                result.Byte2 = maxmath.tobyte(input.z);

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(bool4 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.Byte0 = maxmath.tobyte(input.x);
                result.Byte1 = maxmath.tobyte(input.y);
                result.Byte2 = maxmath.tobyte(input.z);
                result.Byte3 = maxmath.tobyte(input.w);

                return result;
            }
            else if (Sse.IsSseSupported)
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Byte0 = maxmath.tobyte(input.x);
                result.Byte1 = maxmath.tobyte(input.y);
                result.Byte2 = maxmath.tobyte(input.z);
                result.Byte3 = maxmath.tobyte(input.w);

                return result;
            }
            else throw new IllegalInstructionException();
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(byte input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.Byte0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.Byte0 = input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(sbyte input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.SByte0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.SByte0 = input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(ushort input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.UShort0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.UShort0 = input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(short input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.SShort0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.SShort0 = input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(ulong input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.ULong0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.ULong0 = input;

                return result;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128(long input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Avx.undefined_si128();

                result.SLong0 = input;

                return result;
            }
            else
            {
                v128 result;
                v128* dummyPtr = &result;

                result.SLong0 = input;

                return result;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half ToHalf(v128 input)
        {
            return maxmath.ashalf(input.UShort0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half2 ToHalf2(v128 input)
        {
            return new half2(maxmath.ashalf(input.UShort0), maxmath.ashalf(input.UShort1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half3 ToHalf3(v128 input)
        {
            return new half3(maxmath.ashalf(input.UShort0), maxmath.ashalf(input.UShort1), maxmath.ashalf(input.UShort2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half4 ToHalf4(v128 input)
        {
            return new half4(maxmath.ashalf(input.UShort0), maxmath.ashalf(input.UShort1), maxmath.ashalf(input.UShort2), maxmath.ashalf(input.UShort3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float ToFloat(v128 input)
        {
            return input.Float0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float2 ToFloat2(v128 input)
        {
            return new float2(input.Float0, input.Float1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float3 ToFloat3(v128 input)
        {
            return new float3(input.Float0, input.Float1, input.Float2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float4 ToFloat4(v128 input)
        {
            return new float4(input.Float0, input.Float1, input.Float2, input.Float3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double ToDouble(v128 input)
        {
            return input.Double0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double2 ToDouble2(v128 input)
        {
            return new double2(input.Double0, input.Double1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double3 ToDouble3(v256 input)
        {
            return new double3(input.Double0, input.Double1, input.Double2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 ToDouble4(v256 input)
        {
            return new double4(input.Double0, input.Double1, input.Double2, input.Double3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int ToInt(v128 input)
        {
            return input.SInt0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int2 ToInt2(v128 input)
        {
            return new int2(input.SInt0, input.SInt1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int3 ToInt3(v128 input)
        {
            return new int3(input.SInt0, input.SInt1, input.SInt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int4 ToInt4(v128 input)
        {
            return new int4(input.SInt0, input.SInt1, input.SInt2, input.SInt3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint ToUInt(v128 input)
        {
            return input.UInt0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint2 ToUInt2(v128 input)
        {
            return new uint2(input.UInt0, input.UInt1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint3 ToUInt3(v128 input)
        {
            return new uint3(input.UInt0, input.UInt1, input.UInt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint4 ToUInt4(v128 input)
        {
            return new uint4(input.UInt0, input.UInt1, input.UInt2, input.UInt3);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte ToByte(v128 input)
        {
            return input.Byte0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte ToSByte(v128 input)
        {
            return input.SByte0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort ToUShort(v128 input)
        {
            return input.UShort0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short ToShort(v128 input)
        {
            return input.SShort0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong ToULong(v128 input)
        {
            return input.ULong0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long ToLong(v128 input)
        {
            return input.SLong0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool ToBool(v128 input)
        {
            return maxmath.tobool(input.Byte0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool2 ToBool2(v128 input)
        {
            return new bool2(maxmath.tobool(input.Byte0), maxmath.tobool(input.Byte1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool3 ToBool3(v128 input)
        {
            return new bool3(maxmath.tobool(input.Byte0), maxmath.tobool(input.Byte1), maxmath.tobool(input.Byte2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool4 ToBool4(v128 input)
        {
            return new bool4(maxmath.tobool(input.Byte0), maxmath.tobool(input.Byte1), maxmath.tobool(input.Byte2), maxmath.tobool(input.Byte3));
        }
    }
}
