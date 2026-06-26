using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class half3DebuggerProxy
    {
        public half x;
        public half y;
        public half z;
        
        public half3DebuggerProxy(half3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(half3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct half3 : IEquatable<half3>, IEquatable<Unity.Mathematics.half3>, IEquatable<half>, IEquatable<Unity.Mathematics.half>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.half3 __x0;
        
        public ref half x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half3* ptr = &this) { return ref *((half*)ptr +  0); } } }
        public ref half y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half3* ptr = &this) { return ref *((half*)ptr +  1); } } }
        public ref half z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half3* ptr = &this) { return ref *((half*)ptr +  2); } } }


        public static half3 zero => default;
        

        internal readonly bool3 IsZero => (math.asushort(this) & 0x7FFF) == 0;
        internal readonly bool3 IsNotZero => (math.asushort(this) & 0x7FFF) != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(half x, half y, half z)
        {
            __x0 = new Unity.Mathematics.half3(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(half x, half2 yz)
        {
            __x0 = new Unity.Mathematics.half3(x, yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(half2 xy, half z)
        {
            __x0 = new Unity.Mathematics.half3(xy, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(half3 xyz)
        {
            __x0 = new Unity.Mathematics.half3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(half v)
        {
            __x0 = new Unity.Mathematics.half3(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(Unity.Mathematics.half3 xyz)
        {
            __x0 = new Unity.Mathematics.half3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(Unity.Mathematics.half v)
        {
            __x0 = new Unity.Mathematics.half3(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(bool v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(bool3 v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(mask8x3 v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(mask16x3 v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(mask32x3 v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(mask64x3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(byte v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(byte3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(sbyte v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(sbyte3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(ushort v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(ushort3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(short v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(short3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(uint v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(uint3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(int v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(int3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(ulong v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(ulong3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(long v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(long3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(UInt128 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(Int128 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(quarter v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(quarter3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(float v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(float3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(double v)
        {
            this = (half3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(double3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(quadruple v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(Unity.Mathematics.bool3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(Unity.Mathematics.uint3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(Unity.Mathematics.int3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(Unity.Mathematics.float3 v)
        {
            this = (half3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half3(Unity.Mathematics.double3 v)
        {
            this = (half3)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(v128 v) => math.ashalf((ushort3)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(half3 v) => math.asushort(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(bool x) => (half3)(mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(bool3 x) => (half3)(mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(Unity.Mathematics.bool3 x) => (half3)(mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_ph((half)1f));
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(half3 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(half3 x) => (bool3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(half3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(half3 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(half3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(half3 x) => (mask16x3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(UInt128 x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(Int128 x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(quadruple x) => (half)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(half v) => math.ashalf((ushort3)v.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(Unity.Mathematics.half v) => (half)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(Unity.Mathematics.half3 v) => new half3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half3(half3 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half3(sbyte input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(sbyte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_ph(input, elements: 3);
            }
            else
            {
                return new half3(input.x, input.y, input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(input, 3);
            }
            else
            {
                return new sbyte3((sbyte)input.x, (sbyte)input.y, (sbyte)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half3(byte input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_ph(input, elements: 3);
            }
            else
            {
                return new half3(input.x, input.y, input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(input, 3);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(short input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_ph(input, elements: 3);
            }
            else
            {
                return new half3(input.x, input.y, input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(input, 3);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(ushort input) =>(half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_ph(input, MaxMath.half.PositiveInfinity, elements: 3);
            }
            else
            {
                return new half3((half)input.x, (half)input.y, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(input, 3);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(int input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(int3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_ph(input, MaxMath.half.PositiveInfinity, elements: 3);
            }
            else
            {
                return new half3((half)input.x, (half)input.y, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi32(input, 3);
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(uint input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(uint3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_ph(input, MaxMath.half.PositiveInfinity, elements: 3);
            }
            else
            {
                return new half3((half)input.x, (half)input.y, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu32(input, 3);
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(Unity.Mathematics.int3 input) => (half3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(half3 input) => (Unity.Mathematics.int3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(Unity.Mathematics.uint3 input) => (half3)(uint3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(half3 input) => (Unity.Mathematics.uint3)(uint3)input;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(long input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_ph(input, MaxMath.half.PositiveInfinity, elements: 3);
            }
            else
            {
                return new half3((half2)input.xy, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(half3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi64(input, elements: 3);
            }
            else
            {
                return new long3((long2)input.xy, (long)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(ulong input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_ph(input, MaxMath.half.PositiveInfinity, elements: 3);
            }
            else
            {
                return new half3((half2)input.xy, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(half3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu64(input, elements: 3);
            }
            else
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(float input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(float3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_ph(input, elements: 3);
            }
            else
            {
                return new half3((half)input.x, (half)input.y, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_ps(input, elements: 3);
            }
            else
            {
                return new float3((float)input.x, (float)input.y, (float)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(Unity.Mathematics.float3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float3(half3 input) => (Unity.Mathematics.float3)(float3)input;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(double input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(double3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpd_ph(input, elements: 3);
            }
            else
            {
                return new half3((half2)input.xy, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(half3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_pd(input, elements: 3);
            }
            else
            {
                return new double3((double2)input.xy, (double)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(Unity.Mathematics.double3 input) => (half3)(double3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double3(half3 input) => (Unity.Mathematics.double3)(double3)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 operator + (half3 val) => val;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 operator - (half3 val) => math.ashalf(math.asushort(val) ^ 0x8000);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (half3 lhs, float rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (half3 lhs, float rhs) => (float3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (half3 lhs, float rhs) => (float3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (half3 lhs, float rhs) => (float3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (half3 lhs, float rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float lhs, half3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float lhs, half3 rhs) => lhs - (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float lhs, half3 rhs) => lhs * (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float lhs, half3 rhs) => lhs / (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float lhs, half3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 lhs, half3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 lhs, half3 rhs) => lhs - (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 lhs, half3 rhs) => lhs * (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 lhs, half3 rhs) => lhs / (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 lhs, half3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (half3 lhs, double rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (half3 lhs, double rhs) => (double3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (half3 lhs, double rhs) => (double3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (half3 lhs, double rhs) => (double3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (half3 lhs, double rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double lhs, half3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double lhs, half3 rhs) => lhs - (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double lhs, half3 rhs) => lhs * (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double lhs, half3 rhs) => lhs / (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double lhs, half3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 lhs, half3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 lhs, half3 rhs) => lhs - (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 lhs, half3 rhs) => lhs * (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 lhs, half3 rhs) => lhs / (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 lhs, half3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_ph(lhs, rhs, elements: 3);
            }
            else
            {
                return new mask16x3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, half rhs) => lhs == (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half lhs, half3 rhs) => (half3)lhs == rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_ph(lhs, rhs, elements: 3);
            }
            else
            {
                return new mask16x3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, half rhs) => lhs != (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half lhs, half3 rhs) => (half3)lhs != rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_ph(lhs, rhs, elements: 3);
            }
            else
            {
                return new mask16x3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, half rhs) => lhs < (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half lhs, half3 rhs) => (half3)lhs < rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_ph(lhs, rhs, elements: 3);
            }
            else
            {
                return new mask16x3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, half rhs) => lhs > (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half lhs, half3 rhs) => (half3)lhs > rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_ph(lhs, rhs, elements: 3);
            }
            else
            {
                return new mask16x3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, half rhs) => lhs <= (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half lhs, half3 rhs) => (half3)lhs <= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_ph(lhs, rhs, elements: 3);
            }
            else
            {
                return new mask16x3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, half rhs) => lhs >= (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half lhs, half3 rhs) => (half3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs == rhs;
            }
            else
            {
                return lhs == (half3)rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs != rhs;
            }
            else
            {
                return lhs != (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs < rhs;
            }
            else
            {
                return lhs < (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs > rhs;
            }
            else
            {
                return lhs > (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs <= rhs;
            }
            else
            {
                return lhs <= (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs >= rhs;
            }
            else
            {
                return lhs >= (half3)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (quarter lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float3)rhs;
            }
            else
            {
                return (half3)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (quarter lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float3)rhs;
            }
            else
            {
                return (half3)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (quarter lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float3)rhs;
            }
            else
            {
                return (half3)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (quarter lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float3)rhs;
            }
            else
            {
                return (half3)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (quarter lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float3)rhs;
            }
            else
            {
                return (half3)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (quarter lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float3)rhs;
            }
            else
            {
                return (half3)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, Unity.Mathematics.half3 rhs) => lhs == (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, Unity.Mathematics.half3 rhs) => lhs != (half3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, Unity.Mathematics.half3 rhs) => lhs < (half3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, Unity.Mathematics.half3 rhs) => lhs > (half3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, Unity.Mathematics.half3 rhs) => lhs <= (half3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, Unity.Mathematics.half3 rhs) => lhs >= (half3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.half3 lhs, half3 rhs) => (half3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.half3 lhs, half3 rhs) => (half3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.half3 lhs, half3 rhs) => (half3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.half3 lhs, half3 rhs) => (half3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.half3 lhs, half3 rhs) => (half3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.half3 lhs, half3 rhs) => (half3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.half lhs, half3 rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.half lhs, half3 rhs) => (half)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.half lhs, half3 rhs) => (half)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.half lhs, half3 rhs) => (half)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.half lhs, half3 rhs) => (half)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.half lhs, half3 rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, float rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, float rhs) => (float3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, float rhs) => (float3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, float rhs) => (float3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, float rhs) => (float3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, float rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (float lhs, half3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (float lhs, half3 rhs) => lhs != (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (float lhs, half3 rhs) => lhs < (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (float lhs, half3 rhs) => lhs > (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (float lhs, half3 rhs) => lhs <= (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (float lhs, half3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.float3 lhs, half3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.float3 lhs, half3 rhs) => lhs != (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.float3 lhs, half3 rhs) => lhs < (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.float3 lhs, half3 rhs) => lhs > (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.float3 lhs, half3 rhs) => lhs <= (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.float3 lhs, half3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, double rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, double rhs) => (double3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, double rhs) => (double3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, double rhs) => (double3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, double rhs) => (double3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, double rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (double lhs, half3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (double lhs, half3 rhs) => lhs != (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (double lhs, half3 rhs) => lhs < (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (double lhs, half3 rhs) => lhs > (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (double lhs, half3 rhs) => lhs <= (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (double lhs, half3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.double3 lhs, half3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.double3 lhs, half3 rhs) => lhs != (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.double3 lhs, half3 rhs) => lhs < (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.double3 lhs, half3 rhs) => lhs > (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.double3 lhs, half3 rhs) => lhs <= (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.double3 lhs, half3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, byte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half3)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, byte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs != rhs;
            }
            else
            {
                return lhs != (half3)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, byte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs < rhs;
            }
            else
            {
                return lhs < (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, byte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs > rhs;
            }
            else
            {
                return lhs > (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, byte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs <= rhs;
            }
            else
            {
                return lhs <= (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, byte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs >= rhs;
            }
            else
            {
                return lhs >= (half3)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (byte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float3)rhs;
            }
            else
            {
                return math.andnot((half3)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (byte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float3)rhs;
            }
            else
            {
                return (half3)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (byte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float3)rhs;
            }
            else
            {
                return (half3)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (byte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float3)rhs;
            }
            else
            {
                return (half3)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (byte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float3)rhs;
            }
            else
            {
                return (half3)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (byte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float3)rhs;
            }
            else
            {
                return (half3)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half3)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs != rhs;
            }
            else
            {
                return lhs != (half3)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs < rhs;
            }
            else
            {
                return lhs < (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs > rhs;
            }
            else
            {
                return lhs > (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs <= rhs;
            }
            else
            {
                return lhs <= (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs >= rhs;
            }
            else
            {
                return lhs >= (half3)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (byte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float3)rhs;
            }
            else
            {
                return (half3)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (byte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float3)rhs;
            }
            else
            {
                return (half3)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (byte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float3)rhs;
            }
            else
            {
                return (half3)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (byte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float3)rhs;
            }
            else
            {
                return (half3)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (byte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float3)rhs;
            }
            else
            {
                return (half3)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (byte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float3)rhs;
            }
            else
            {
                return (half3)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, sbyte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half3)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, sbyte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs != rhs;
            }
            else
            {
                return lhs != (half3)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, sbyte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs < rhs;
            }
            else
            {
                return lhs < (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, sbyte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs > rhs;
            }
            else
            {
                return lhs > (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, sbyte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs <= rhs;
            }
            else
            {
                return lhs <= (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, sbyte3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs >= rhs;
            }
            else
            {
                return lhs >= (half3)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (sbyte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float3)rhs;
            }
            else
            {
                return math.andnot((half3)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (sbyte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float3)rhs;
            }
            else
            {
                return (half3)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (sbyte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float3)rhs;
            }
            else
            {
                return (half3)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (sbyte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float3)rhs;
            }
            else
            {
                return (half3)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (sbyte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float3)rhs;
            }
            else
            {
                return (half3)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (sbyte3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float3)rhs;
            }
            else
            {
                return (half3)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half3)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs != rhs;
            }
            else
            {
                return lhs != (half3)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs < rhs;
            }
            else
            {
                return lhs < (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs > rhs;
            }
            else
            {
                return lhs > (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs <= rhs;
            }
            else
            {
                return lhs <= (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs >= rhs;
            }
            else
            {
                return lhs >= (half3)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (sbyte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float3)rhs;
            }
            else
            {
                return (half3)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (sbyte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float3)rhs;
            }
            else
            {
                return (half3)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (sbyte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float3)rhs;
            }
            else
            {
                return (half3)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (sbyte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float3)rhs;
            }
            else
            {
                return (half3)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (sbyte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float3)rhs;
            }
            else
            {
                return (half3)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (sbyte lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float3)rhs;
            }
            else
            {
                return (half3)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, short3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half3)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, short3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs != rhs;
            }
            else
            {
                return lhs != (half3)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, short3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs < rhs;
            }
            else
            {
                return lhs < (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, short3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs > rhs;
            }
            else
            {
                return lhs > (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, short3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs <= rhs;
            }
            else
            {
                return lhs <= (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, short3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs >= rhs;
            }
            else
            {
                return lhs >= (half3)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float3)rhs;
            }
            else
            {
                return math.andnot((half3)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float3)rhs;
            }
            else
            {
                return (half3)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float3)rhs;
            }
            else
            {
                return (half3)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float3)rhs;
            }
            else
            {
                return (half3)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float3)rhs;
            }
            else
            {
                return (half3)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float3)rhs;
            }
            else
            {
                return (half3)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (half3 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half3)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (half3 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs != rhs;
            }
            else
            {
                return lhs != (half3)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (half3 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs < rhs;
            }
            else
            {
                return lhs < (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (half3 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs > rhs;
            }
            else
            {
                return lhs > (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (half3 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs <= rhs;
            }
            else
            {
                return lhs <= (half3)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (half3 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)lhs >= rhs;
            }
            else
            {
                return lhs >= (half3)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float3)rhs;
            }
            else
            {
                return (half3)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float3)rhs;
            }
            else
            {
                return (half3)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float3)rhs;
            }
            else
            {
                return (half3)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float3)rhs;
            }
            else
            {
                return (half3)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float3)rhs;
            }
            else
            {
                return (half3)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short lhs, half3 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float3)rhs;
            }
            else
            {
                return (half3)lhs >= rhs;
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zz; }
        }

        
        public half this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return __x0[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                __x0[index] = value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(half other) => math.all(this == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.half other) => math.all(this == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(half3 other) => math.all(this == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.half3 other) => math.all(this == other);

        public override readonly bool Equals(object o) => (o is half3 converted && Equals(converted)) || (o is Unity.Mathematics.half3 convertedU && Equals(convertedU)) || (o is half3 convertedS && Equals(convertedS)) || (o is Unity.Mathematics.half convertedSU && Equals(convertedSU)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("half3({0}, {1}, {2})", x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("half3({0}, {1}, {2})", x.ToString(format, formatProvider), y.ToString(format, formatProvider), z.ToString(format, formatProvider));
        }
    }
}
