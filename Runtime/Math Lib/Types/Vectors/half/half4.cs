using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class half4DebuggerProxy
    {
	    public half x;
	    public half y;
	    public half z;
	    public half w;
        
	    public half4DebuggerProxy(half4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(half4DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct half4 : IEquatable<half4>, IEquatable<Unity.Mathematics.half4>, IEquatable<half>, IEquatable<Unity.Mathematics.half>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.half4 __x0;
        
        public ref half x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half4* ptr = &this) { return ref *((half*)ptr +  0); } } }
        public ref half y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half4* ptr = &this) { return ref *((half*)ptr +  1); } } }
        public ref half z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half4* ptr = &this) { return ref *((half*)ptr +  2); } } }
        public ref half w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half4* ptr = &this) { return ref *((half*)ptr +  3); } } }


        public static half4 zero => default;
        

        internal readonly bool4 IsZero => (math.asushort(this) & 0x7FFF) == 0;
        internal readonly bool4 IsNotZero => (math.asushort(this) & 0x7FFF) != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half x, half y, half z, half w)
        {
            __x0 = new Unity.Mathematics.half4(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half x, half y, half2 zw)
        {
            __x0 = new Unity.Mathematics.half4(x, y, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half x, half2 yz, half w)
        {
            __x0 = new Unity.Mathematics.half4(x, yz, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half x, half3 yzw)
        {
            __x0 = new Unity.Mathematics.half4(x, yzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half2 xy, half z, half w)
        {
            __x0 = new Unity.Mathematics.half4(xy, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half2 xy, half2 zw)
        {
            __x0 = new Unity.Mathematics.half4(xy, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half3 xyz, half w)
        {
            __x0 = new Unity.Mathematics.half4(xyz, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half4 xyzw)
        {
            __x0 = new Unity.Mathematics.half4(xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(half v)
        {
            __x0 = new Unity.Mathematics.half4(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(Unity.Mathematics.half4 xyzw)
        {
            __x0 = new Unity.Mathematics.half4(xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(Unity.Mathematics.half v)
        {
            __x0 = new Unity.Mathematics.half4(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(bool v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(bool4 v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(mask8x4 v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(mask16x4 v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(mask32x4 v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(mask64x4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(byte v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(byte4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(sbyte v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(sbyte4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(ushort v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(ushort4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(short v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(short4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(uint v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(uint4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(int v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(int4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(ulong v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(ulong4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(long v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(long4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(UInt128 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(Int128 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(quarter v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(quarter4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(float v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(float4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(double v)
        {
            this = (half4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(double4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(quadruple v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(Unity.Mathematics.bool4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(Unity.Mathematics.uint4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(Unity.Mathematics.int4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(Unity.Mathematics.float4 v)
        {
            this = (half4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half4(Unity.Mathematics.double4 v)
        {
            this = (half4)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(v128 v) => math.ashalf((ushort4)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(half4 v) => math.asushort(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(bool x) => (half4)(mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(bool4 x) => (half4)(mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(Unity.Mathematics.bool4 x) => (half4)(mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half4)(mask16x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_ph((half)1f));
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half4)(mask16x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(mask64x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half4)(mask16x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(half4 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(half4 x) => (bool4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(half4 x) => (mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4(half4 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4(half4 x) => (mask16x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4(half4 x) => (mask16x4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(UInt128 x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(Int128 x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(quadruple x) => (half)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(half v) => math.ashalf((ushort4)v.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(Unity.Mathematics.half v) => (half)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(Unity.Mathematics.half4 v) => new half4 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half4(half4 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half4(sbyte input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(sbyte4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_ph(input, elements: 4);
            }
            else
            {
                return new half4(input.x, input.y, input.z, input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(input, 4);
            }
            else
            {
                return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half4(byte input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(byte4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_ph(input, elements: 4);
            }
            else
            {
                return new half4(input.x, input.y, input.z, input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(input, 4);
            }
            else
            {
                return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(short input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(short4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_ph(input, elements: 4);
            }
            else
            {
                return new half4(input.x, input.y, input.z, input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(input, 4);
            }
            else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(ushort input) =>(half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(ushort4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_ph(input, MaxMath.half.PositiveInfinity, elements: 4);
            }
            else
            {
                return new half4((half)input.x, (half)input.y, (half)input.z, (half)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(input, 4);
            }
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(int input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(int4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_ph(input, MaxMath.half.PositiveInfinity, elements: 4);
            }
            else
            {
                return new half4((half)input.x, (half)input.y, (half)input.z, (half)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi32(input, 4);
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(uint input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(uint4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_ph(input, MaxMath.half.PositiveInfinity, elements: 4);
            }
            else
            {
                return new half4((half)input.x, (half)input.y, (half)input.z, (half)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu32(input, 4);
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(Unity.Mathematics.int4 input) => (half4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(half4 input) => (Unity.Mathematics.int4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(Unity.Mathematics.uint4 input) => (half4)(uint4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(half4 input) => (Unity.Mathematics.uint4)(uint4)input;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(long input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_ph(input, MaxMath.half.PositiveInfinity, elements: 4);
            }
            else
            {
                return new half4((half2)input.xy, (half2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(half4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi64(input, elements: 4);
            }
            else
            {
                return new long4((long2)input.xy, (long2)input.zw);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(ulong input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_ph(input, MaxMath.half.PositiveInfinity, elements: 4);
            }
            else
            {
                return new half4((half2)input.xy, (half2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(half4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu64(input, elements: 4);
            }
            else
            {
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(float input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(float4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_ph(input, elements: 4);
            }
            else
            {
                return new half4((half)input.x, (half)input.y, (half)input.z, (half)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_ps(input, elements: 4);
            }
            else
            {
                return new float4((float)input.x, (float)input.y, (float)input.z, (float)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(Unity.Mathematics.float4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4(half4 input) => (Unity.Mathematics.float4)(float4)input;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(double input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(double4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpd_ph(input, elements: 4);
            }
            else
            {
                return new half4((half2)input.xy, (half2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(half4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_pd(input, elements: 4);
            }
            else
            {
                return new double4((double2)input.xy, (double2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(Unity.Mathematics.double4 input) => (half4)(double4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double4(half4 input) => (Unity.Mathematics.double4)(double4)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 operator + (half4 val) => val;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 operator - (half4 val) => math.ashalf(math.asushort(val) ^ 0x8000);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (half4 lhs, float rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (half4 lhs, float rhs) => (float4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (half4 lhs, float rhs) => (float4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (half4 lhs, float rhs) => (float4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (half4 lhs, float rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float lhs, half4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float lhs, half4 rhs) => lhs - (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float lhs, half4 rhs) => lhs * (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float lhs, half4 rhs) => lhs / (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float lhs, half4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 lhs, half4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 lhs, half4 rhs) => lhs - (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 lhs, half4 rhs) => lhs * (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 lhs, half4 rhs) => lhs / (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 lhs, half4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (half4 lhs, double rhs) => (double4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (half4 lhs, double rhs) => (double4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (half4 lhs, double rhs) => (double4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (half4 lhs, double rhs) => (double4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (half4 lhs, double rhs) => (double4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (double lhs, half4 rhs) => lhs + (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (double lhs, half4 rhs) => lhs - (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (double lhs, half4 rhs) => lhs * (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (double lhs, half4 rhs) => lhs / (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (double lhs, half4 rhs) => lhs % (double4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 lhs, half4 rhs) => lhs + (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 lhs, half4 rhs) => lhs - (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 lhs, half4 rhs) => lhs * (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 lhs, half4 rhs) => lhs / (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 lhs, half4 rhs) => lhs % (double4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_ph(lhs, rhs, elements: 4);
            }
            else
            {
                return new mask16x4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, half rhs) => lhs == (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half lhs, half4 rhs) => (half4)lhs == rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_ph(lhs, rhs, elements: 4);
            }
            else
            {
                return new mask16x4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, half rhs) => lhs != (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half lhs, half4 rhs) => (half4)lhs != rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_ph(lhs, rhs, elements: 4);
            }
            else
            {
                return new mask16x4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, half rhs) => lhs < (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half lhs, half4 rhs) => (half4)lhs < rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_ph(lhs, rhs, elements: 4);
            }
            else
            {
                return new mask16x4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, half rhs) => lhs > (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half lhs, half4 rhs) => (half4)lhs > rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_ph(lhs, rhs, elements: 4);
            }
            else
            {
                return new mask16x4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, half rhs) => lhs <= (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half lhs, half4 rhs) => (half4)lhs <= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_ph(lhs, rhs, elements: 4);
            }
            else
            {
                return new mask16x4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, half rhs) => lhs >= (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half lhs, half4 rhs) => (half4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs == rhs;
            }
            else
            {
                return lhs == (half4)rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs != rhs;
            }
            else
            {
                return lhs != (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs < rhs;
            }
            else
            {
                return lhs < (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs > rhs;
            }
            else
            {
                return lhs > (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs <= rhs;
            }
            else
            {
                return lhs <= (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs >= rhs;
            }
            else
            {
                return lhs >= (half4)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (quarter lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float4)rhs;
            }
            else
            {
                return (half4)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (quarter lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float4)rhs;
            }
            else
            {
                return (half4)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (quarter lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float4)rhs;
            }
            else
            {
                return (half4)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (quarter lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float4)rhs;
            }
            else
            {
                return (half4)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (quarter lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float4)rhs;
            }
            else
            {
                return (half4)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (quarter lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float4)rhs;
            }
            else
            {
                return (half4)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, Unity.Mathematics.half4 rhs) => lhs == (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, Unity.Mathematics.half4 rhs) => lhs != (half4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, Unity.Mathematics.half4 rhs) => lhs < (half4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, Unity.Mathematics.half4 rhs) => lhs > (half4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, Unity.Mathematics.half4 rhs) => lhs <= (half4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, Unity.Mathematics.half4 rhs) => lhs >= (half4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (Unity.Mathematics.half4 lhs, half4 rhs) => (half4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (Unity.Mathematics.half4 lhs, half4 rhs) => (half4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (Unity.Mathematics.half4 lhs, half4 rhs) => (half4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (Unity.Mathematics.half4 lhs, half4 rhs) => (half4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (Unity.Mathematics.half4 lhs, half4 rhs) => (half4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (Unity.Mathematics.half4 lhs, half4 rhs) => (half4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (Unity.Mathematics.half lhs, half4 rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (Unity.Mathematics.half lhs, half4 rhs) => (half)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (Unity.Mathematics.half lhs, half4 rhs) => (half)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (Unity.Mathematics.half lhs, half4 rhs) => (half)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (Unity.Mathematics.half lhs, half4 rhs) => (half)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (Unity.Mathematics.half lhs, half4 rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, float rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, float rhs) => (float4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, float rhs) => (float4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, float rhs) => (float4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, float rhs) => (float4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, float rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (float lhs, half4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (float lhs, half4 rhs) => lhs != (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (float lhs, half4 rhs) => lhs < (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (float lhs, half4 rhs) => lhs > (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (float lhs, half4 rhs) => lhs <= (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (float lhs, half4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (Unity.Mathematics.float4 lhs, half4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (Unity.Mathematics.float4 lhs, half4 rhs) => lhs != (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (Unity.Mathematics.float4 lhs, half4 rhs) => lhs < (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (Unity.Mathematics.float4 lhs, half4 rhs) => lhs > (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (Unity.Mathematics.float4 lhs, half4 rhs) => lhs <= (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (Unity.Mathematics.float4 lhs, half4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, double rhs) => (double4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, double rhs) => (double4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, double rhs) => (double4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, double rhs) => (double4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, double rhs) => (double4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, double rhs) => (double4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (double lhs, half4 rhs) => lhs == (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (double lhs, half4 rhs) => lhs != (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (double lhs, half4 rhs) => lhs < (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (double lhs, half4 rhs) => lhs > (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (double lhs, half4 rhs) => lhs <= (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (double lhs, half4 rhs) => lhs >= (double4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (Unity.Mathematics.double4 lhs, half4 rhs) => lhs == (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (Unity.Mathematics.double4 lhs, half4 rhs) => lhs != (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (Unity.Mathematics.double4 lhs, half4 rhs) => lhs < (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (Unity.Mathematics.double4 lhs, half4 rhs) => lhs > (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (Unity.Mathematics.double4 lhs, half4 rhs) => lhs <= (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (Unity.Mathematics.double4 lhs, half4 rhs) => lhs >= (double4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, byte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half4)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, byte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs != rhs;
            }
            else
            {
                return lhs != (half4)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, byte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs < rhs;
            }
            else
            {
                return lhs < (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, byte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs > rhs;
            }
            else
            {
                return lhs > (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, byte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs <= rhs;
            }
            else
            {
                return lhs <= (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, byte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs >= rhs;
            }
            else
            {
                return lhs >= (half4)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (byte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float4)rhs;
            }
            else
            {
                return math.andnot((half4)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (byte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float4)rhs;
            }
            else
            {
                return (half4)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (byte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float4)rhs;
            }
            else
            {
                return (half4)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (byte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float4)rhs;
            }
            else
            {
                return (half4)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (byte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float4)rhs;
            }
            else
            {
                return (half4)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (byte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float4)rhs;
            }
            else
            {
                return (half4)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half4)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs != rhs;
            }
            else
            {
                return lhs != (half4)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs < rhs;
            }
            else
            {
                return lhs < (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs > rhs;
            }
            else
            {
                return lhs > (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs <= rhs;
            }
            else
            {
                return lhs <= (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs >= rhs;
            }
            else
            {
                return lhs >= (half4)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (byte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float4)rhs;
            }
            else
            {
                return (half4)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (byte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float4)rhs;
            }
            else
            {
                return (half4)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (byte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float4)rhs;
            }
            else
            {
                return (half4)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (byte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float4)rhs;
            }
            else
            {
                return (half4)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (byte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float4)rhs;
            }
            else
            {
                return (half4)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (byte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float4)rhs;
            }
            else
            {
                return (half4)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, sbyte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half4)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, sbyte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs != rhs;
            }
            else
            {
                return lhs != (half4)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, sbyte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs < rhs;
            }
            else
            {
                return lhs < (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, sbyte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs > rhs;
            }
            else
            {
                return lhs > (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, sbyte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs <= rhs;
            }
            else
            {
                return lhs <= (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, sbyte4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs >= rhs;
            }
            else
            {
                return lhs >= (half4)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (sbyte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float4)rhs;
            }
            else
            {
                return math.andnot((half4)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (sbyte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float4)rhs;
            }
            else
            {
                return (half4)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (sbyte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float4)rhs;
            }
            else
            {
                return (half4)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (sbyte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float4)rhs;
            }
            else
            {
                return (half4)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (sbyte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float4)rhs;
            }
            else
            {
                return (half4)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (sbyte4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float4)rhs;
            }
            else
            {
                return (half4)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half4)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs != rhs;
            }
            else
            {
                return lhs != (half4)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs < rhs;
            }
            else
            {
                return lhs < (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs > rhs;
            }
            else
            {
                return lhs > (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs <= rhs;
            }
            else
            {
                return lhs <= (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs >= rhs;
            }
            else
            {
                return lhs >= (half4)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (sbyte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float4)rhs;
            }
            else
            {
                return (half4)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (sbyte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float4)rhs;
            }
            else
            {
                return (half4)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (sbyte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float4)rhs;
            }
            else
            {
                return (half4)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (sbyte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float4)rhs;
            }
            else
            {
                return (half4)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (sbyte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float4)rhs;
            }
            else
            {
                return (half4)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (sbyte lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float4)rhs;
            }
            else
            {
                return (half4)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, short4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half4)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, short4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs != rhs;
            }
            else
            {
                return lhs != (half4)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, short4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs < rhs;
            }
            else
            {
                return lhs < (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, short4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs > rhs;
            }
            else
            {
                return lhs > (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, short4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs <= rhs;
            }
            else
            {
                return lhs <= (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, short4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs >= rhs;
            }
            else
            {
                return lhs >= (half4)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (short4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float4)rhs;
            }
            else
            {
                return math.andnot((half4)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (short4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float4)rhs;
            }
            else
            {
                return (half4)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (short4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float4)rhs;
            }
            else
            {
                return (half4)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (short4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float4)rhs;
            }
            else
            {
                return (half4)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (short4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float4)rhs;
            }
            else
            {
                return (half4)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (short4 lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float4)rhs;
            }
            else
            {
                return (half4)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (half4 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half4)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (half4 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs != rhs;
            }
            else
            {
                return lhs != (half4)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (half4 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs < rhs;
            }
            else
            {
                return lhs < (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (half4 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs > rhs;
            }
            else
            {
                return lhs > (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (half4 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs <= rhs;
            }
            else
            {
                return lhs <= (half4)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (half4 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)lhs >= rhs;
            }
            else
            {
                return lhs >= (half4)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator == (short lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float4)rhs;
            }
            else
            {
                return (half4)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator != (short lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float4)rhs;
            }
            else
            {
                return (half4)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator < (short lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float4)rhs;
            }
            else
            {
                return (half4)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator > (short lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float4)rhs;
            }
            else
            {
                return (half4)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator <= (short lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float4)rhs;
            }
            else
            {
                return (half4)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 operator >= (short lhs, half4 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float4)rhs;
            }
            else
            {
                return (half4)lhs >= rhs;
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
        public readonly half4 xxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxw; }
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
        public readonly half4 xxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyw; }
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
        public readonly half4 xxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxww; }
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
        public readonly half4 xyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxw; }
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
        public readonly half4 xyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyw; }
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
        public half4 xyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 xywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xywz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xywz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyww; }
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
        public readonly half4 xzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxw; }
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
        public half4 xzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzyw = value; }
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
        public readonly half4 xzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 xzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 xwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 xwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwww; }
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
        public readonly half4 yxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxw; }
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
        public readonly half4 yxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyw; }
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
        public half4 yxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 yxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxwz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxwz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxww; }
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
        public readonly half4 yyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxw; }
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
        public readonly half4 yyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyw; }
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
        public readonly half4 yyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyww; }
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
        public half4 yzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzxw = value; }
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
        public readonly half4 yzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyw; }
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
        public readonly half4 yzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 yzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzwx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzwx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 ywxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 ywzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 ywww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywww; }
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
        public readonly half4 zxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxw; }
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
        public half4 zxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxyw = value; }
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
        public readonly half4 zxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 zxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxww; }
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
        public half4 zyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyxw = value; }
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
        public readonly half4 zyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyw; }
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
        public readonly half4 zyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 zywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zywx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zywx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyww; }
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
        public readonly half4 zzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxw; }
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
        public readonly half4 zzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyw; }
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
        public readonly half4 zzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 zwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 zwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 zwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 wxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 wxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 wyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 wyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 wzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 wzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 wwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwww; }
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
        public readonly half3 xxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxw; }
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
        public half3 xyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyw = value; }
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
        public half3 xzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 xwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 xwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xww; }
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
        public half3 yxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxw = value; }
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
        public readonly half3 yyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyw; }
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
        public half3 yzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 ywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 ywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 ywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yww; }
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
        public half3 zxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxw = value; }
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
        public half3 zyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyw = value; }
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
        public readonly half3 zzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 zwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 zwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 zww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 wxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 wxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 wyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 wyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 wzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 wzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 wwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 www
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.www; }
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
        public half2 xw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xw = value; }
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
        public half2 yw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yw = value; }
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 zw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 wx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 wy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 wz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half2 ww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ww; }
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
        public readonly bool Equals(half4 other) => math.all(this == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.half4 other) => math.all(this == other);

        public override readonly bool Equals(object o) => (o is half4 converted && Equals(converted)) || (o is Unity.Mathematics.half4 convertedU && Equals(convertedU)) || (o is half4 convertedS && Equals(convertedS)) || (o is Unity.Mathematics.half convertedSU && Equals(convertedSU)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("half4({0}, {1}, {2}, {3})", x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("half4({0}, {1}, {2}, {3})", x.ToString(format, formatProvider), y.ToString(format, formatProvider), z.ToString(format, formatProvider), w.ToString(format, formatProvider));
            }
    }
}
