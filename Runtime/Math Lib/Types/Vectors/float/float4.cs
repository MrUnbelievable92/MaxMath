using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class float4DebuggerProxy
    {
	    public float x;
	    public float y;
	    public float z;
	    public float w;
        
	    public float4DebuggerProxy(float4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(float4DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct float4 : IEquatable<float4>, IEquatable<Unity.Mathematics.float4>, IEquatable<float>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.float4 __x0;
        
        public ref float x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float4* ptr = &this) { return ref *((float*)ptr +  0); } } }
        public ref float y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float4* ptr = &this) { return ref *((float*)ptr +  1); } } }
        public ref float z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float4* ptr = &this) { return ref *((float*)ptr +  2); } } }
        public ref float w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float4* ptr = &this) { return ref *((float*)ptr +  3); } } }


        public static float4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float x, float y, float z, float w)
        {
            __x0 = new Unity.Mathematics.float4(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float x, float y, float2 zw)
        {
            __x0 = new Unity.Mathematics.float4(x, y, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float x, float2 yz, float w)
        {
            __x0 = new Unity.Mathematics.float4(x, yz, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float x, float3 yzw)
        {
            __x0 = new Unity.Mathematics.float4(x, yzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float2 xy, float z, float w)
        {
            __x0 = new Unity.Mathematics.float4(xy, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float2 xy, float2 zw)
        {
            __x0 = new Unity.Mathematics.float4(xy, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float3 xyz, float w)
        {
            __x0 = new Unity.Mathematics.float4(xyz, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float4 xyzw)
        {
            __x0 = new Unity.Mathematics.float4(xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float v)
        {
            __x0 = new Unity.Mathematics.float4(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(Unity.Mathematics.float4 xyzw)
        {
            __x0 = new Unity.Mathematics.float4(xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(bool v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(bool4 v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(mask8x4 v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(mask16x4 v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(mask32x4 v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(mask64x4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(byte v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(byte4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(sbyte v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(sbyte4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(ushort v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(ushort4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(short v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(short4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(uint v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(uint4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(int v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(int4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(ulong v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(ulong4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(long v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(long4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(UInt128 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(Int128 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(quarter v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(quarter4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(half v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(half4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(double v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(double4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(quadruple v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(Unity.Mathematics.bool4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(Unity.Mathematics.uint4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(Unity.Mathematics.int4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(Unity.Mathematics.half v)
        {
            this = (float4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(Unity.Mathematics.half4 v)
        {
            this = (float4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(Unity.Mathematics.double4 v)
        {
            this = (float4)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(v128 v) => math.asfloat((uint4)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(float4 v) => math.asuint(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(bool x) => (float4)(mask32x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(bool4 x) => (float4)(mask32x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(Unity.Mathematics.bool4 x) => (float4)(mask32x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float4)(mask32x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float4)(mask32x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_ps(x, Xse.set1_ps(1));
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(mask64x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float4)(mask32x4)x;
            }
            else
            {
                return *(float4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(float4 x) => (Unity.Mathematics.bool4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(float4 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(float4 x) => (mask32x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4(float4 x) => (mask32x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4(float4 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4(float4 x) => (mask32x4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float4(byte x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float4(sbyte x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float4(ushort x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float4(short x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(ulong x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(long x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(UInt128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Int128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(quadruple x) => (float)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(UnityEngine.Vector4 v) => new float4 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector4(float4 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Unity.Mathematics.float4 v) => new float4 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(float4 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Unity.Mathematics.int4 v) => new float4 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(float4 v) => (Unity.Mathematics.int4)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Unity.Mathematics.uint4 v) => new float4 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(float4 v) => (Unity.Mathematics.uint4)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Unity.Mathematics.half4 v) => (half4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half4(float4 v) => (half4)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(Unity.Mathematics.double4 v) => new float4 { __x0 = (Unity.Mathematics.float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(float4 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(float v) => new float4 { __x0 = (Unity.Mathematics.float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(int v) => new float4 { __x0 = (Unity.Mathematics.float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(int4 v) => new float4 { __x0 = (Unity.Mathematics.float4)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(uint v) => new float4 { __x0 = (Unity.Mathematics.float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(uint4 v) => new float4 { __x0 = (Unity.Mathematics.float4)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(half v) => (float)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(double v) => new float4 { __x0 = (Unity.Mathematics.float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(double4 v) => new float4 { __x0 = (Unity.Mathematics.float4)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 val) => +val.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 val) => -val.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator ++ (float4 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator -- (float4 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, float4 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, float rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float lhs, float4 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, float4 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, float rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float lhs, float4 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, float4 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, float rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float lhs, float4 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, float4 rhs) => lhs.__x0 / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, float rhs) => lhs.__x0 / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float lhs, float4 rhs) => lhs / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, float4 rhs) => lhs.__x0 % rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, float rhs) => lhs.__x0 % rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float lhs, float4 rhs) => lhs % rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, Unity.Mathematics.float4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, Unity.Mathematics.float4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, Unity.Mathematics.float4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, Unity.Mathematics.float4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, Unity.Mathematics.float4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (float4 lhs, Unity.Mathematics.double4 rhs) => lhs + (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (float4 lhs, Unity.Mathematics.double4 rhs) => lhs - (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (float4 lhs, Unity.Mathematics.double4 rhs) => lhs * (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (float4 lhs, Unity.Mathematics.double4 rhs) => lhs / (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (float4 lhs, Unity.Mathematics.double4 rhs) => lhs % (double4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, quarter rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, quarter rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, quarter rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, quarter rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, quarter rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (quarter lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (quarter lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (quarter lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (quarter lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (quarter lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, quarter4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, quarter4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, quarter4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, quarter4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, quarter4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (quarter4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (quarter4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (quarter4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (quarter4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (quarter4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, half rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, half rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, half rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, half rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, half rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (half lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (half lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (half lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (half lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (half lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, half4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, half4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, half4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, half4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, half4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (half4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (half4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (half4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (half4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (half4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, Unity.Mathematics.half rhs) => lhs + (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, Unity.Mathematics.half rhs) => lhs - (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, Unity.Mathematics.half rhs) => lhs * (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, Unity.Mathematics.half rhs) => lhs / (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, Unity.Mathematics.half rhs) => lhs % (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, Unity.Mathematics.half4 rhs) => lhs + (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, Unity.Mathematics.half4 rhs) => lhs - (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, Unity.Mathematics.half4 rhs) => lhs * (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, Unity.Mathematics.half4 rhs) => lhs / (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, Unity.Mathematics.half4 rhs) => lhs % (half4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, byte4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, byte4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, byte4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, byte4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, byte4 rhs) => lhs % (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (byte4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (byte4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (byte4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (byte4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (byte4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, sbyte4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, sbyte4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, sbyte4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, sbyte4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, sbyte4 rhs) => lhs % (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (sbyte4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (sbyte4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (sbyte4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (sbyte4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (sbyte4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, short4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, short4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, short4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, short4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, short4 rhs) => lhs % (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (short4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (short4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (short4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (short4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (short4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, ushort4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, ushort4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, ushort4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, ushort4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, ushort4 rhs) => lhs % (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (ushort4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (ushort4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (ushort4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (ushort4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (ushort4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, int4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, int4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, int4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, int4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, int4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (int4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (int4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (int4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (int4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (int4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, uint4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, uint4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, uint4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, uint4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, uint4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (uint4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (uint4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (uint4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (uint4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (uint4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, long4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, long4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, long4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, long4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, long4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (long4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (long4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (long4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (long4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (long4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, ulong4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, ulong4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, ulong4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, ulong4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, ulong4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (ulong4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (ulong4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (ulong4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (ulong4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (ulong4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, Unity.Mathematics.int4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, Unity.Mathematics.int4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, Unity.Mathematics.int4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, Unity.Mathematics.int4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, Unity.Mathematics.int4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs - (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs * (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs / (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, byte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (byte lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, byte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (byte lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, byte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (byte lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, byte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (byte lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, byte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (byte lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, sbyte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (sbyte lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, sbyte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (sbyte lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, sbyte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (sbyte lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, sbyte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (sbyte lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, sbyte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (sbyte lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, short rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (short lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, short rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (short lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, short rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (short lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, short rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (short lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, short rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (short lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, ushort rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (ushort lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, ushort rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (ushort lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, ushort rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (ushort lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, ushort rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (ushort lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, ushort rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (ushort lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, int rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (int lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, int rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (int lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, int rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (int lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, int rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (int lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, int rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (int lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, uint rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (uint lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, uint rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (uint lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, uint rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (uint lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, uint rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (uint lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, uint rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (uint lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, long rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (long lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, long rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (long lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, long rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (long lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, long rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (long lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, long rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (long lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, ulong rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (ulong lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, ulong rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (ulong lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, ulong rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (ulong lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, ulong rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (ulong lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, ulong rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (ulong lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, Int128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Int128 lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, Int128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Int128 lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, Int128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Int128 lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, Int128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Int128 lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, Int128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Int128 lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (float4 lhs, UInt128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (UInt128 lhs, float4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (float4 lhs, UInt128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (UInt128 lhs, float4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (float4 lhs, UInt128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (UInt128 lhs, float4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (float4 lhs, UInt128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (UInt128 lhs, float4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (float4 lhs, UInt128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (UInt128 lhs, float4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, float4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_ps(lhs, rhs);
            }
            else
            {
                return new mask32x4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, float rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, float4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_ps(lhs, rhs);
            }
            else
            {
                return new mask32x4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, float rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, float4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_ps(lhs, rhs);
            }
            else
            {
                return new mask32x4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, float rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, float4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_ps(lhs, rhs);
            }
            else
            {
                return new mask32x4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, float rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, float4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_ps(lhs, rhs);
            }
            else
            {
                return new mask32x4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, float rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, float4 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_ps(lhs, rhs);
            }
            else
            {
                return new mask32x4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, float rhs) => lhs >= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, Unity.Mathematics.float4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, Unity.Mathematics.float4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, Unity.Mathematics.float4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, Unity.Mathematics.float4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, Unity.Mathematics.float4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, Unity.Mathematics.float4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (Unity.Mathematics.float4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, Unity.Mathematics.double4 rhs) => lhs == (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, Unity.Mathematics.double4 rhs) => lhs != (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, Unity.Mathematics.double4 rhs) => lhs <= (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, Unity.Mathematics.double4 rhs) => lhs > (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, Unity.Mathematics.double4 rhs) => lhs <= (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, Unity.Mathematics.double4 rhs) => lhs >= (double4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (Unity.Mathematics.double4 lhs, float4 rhs) => (double4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, quarter rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, quarter rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, quarter rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, quarter rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, quarter rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, quarter rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (quarter lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (quarter lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (quarter lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (quarter lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (quarter lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (quarter lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, quarter4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, quarter4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, quarter4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, quarter4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, quarter4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, quarter4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (quarter4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (quarter4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (quarter4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (quarter4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (quarter4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (quarter4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, half rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, half rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, half rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, half rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, half rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, half rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (half lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (half lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (half lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (half lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (half lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (half lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, half4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, half4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, half4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, half4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, half4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, half4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (half4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (half4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (half4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (half4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (half4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (half4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (Unity.Mathematics.half lhs, float4 rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, Unity.Mathematics.half4 rhs) => lhs == (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, Unity.Mathematics.half4 rhs) => lhs != (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, Unity.Mathematics.half4 rhs) => lhs < (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, Unity.Mathematics.half4 rhs) => lhs > (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, Unity.Mathematics.half4 rhs) => lhs <= (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, Unity.Mathematics.half4 rhs) => lhs >= (half4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (Unity.Mathematics.half4 lhs, float4 rhs) => (half4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, byte4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, byte4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, byte4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, byte4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, byte4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, byte4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (byte4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (byte4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (byte4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (byte4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (byte4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (byte4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, sbyte4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, sbyte4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, sbyte4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, sbyte4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, sbyte4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, sbyte4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (sbyte4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (sbyte4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (sbyte4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (sbyte4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (sbyte4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (sbyte4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, ushort4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, ushort4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, ushort4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, ushort4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, ushort4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, ushort4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (ushort4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (ushort4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (ushort4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (ushort4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (ushort4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (ushort4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, short4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, short4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, short4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, short4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, short4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, short4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (short4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (short4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (short4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (short4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (short4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (short4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, int4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, int4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, int4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, int4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, int4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, int4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (int4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (int4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (int4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (int4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (int4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (int4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, uint4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, uint4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, uint4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, uint4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, uint4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, uint4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (uint4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (uint4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (uint4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (uint4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (uint4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (uint4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, Unity.Mathematics.int4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, Unity.Mathematics.int4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, Unity.Mathematics.int4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, Unity.Mathematics.int4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, Unity.Mathematics.int4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, Unity.Mathematics.int4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (Unity.Mathematics.int4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, Unity.Mathematics.uint4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (Unity.Mathematics.uint4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, long4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, long4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, long4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, long4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, long4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, long4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (long4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (long4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (long4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (long4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (long4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (long4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, ulong4 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, ulong4 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, ulong4 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, ulong4 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, ulong4 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, ulong4 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (ulong4 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (ulong4 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (ulong4 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (ulong4 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (ulong4 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (ulong4 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, byte rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, byte rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, byte rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, byte rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, byte rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, byte rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (byte lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (byte lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (byte lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (byte lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (byte lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (byte lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, sbyte rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, sbyte rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, sbyte rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, sbyte rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, sbyte rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, sbyte rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (sbyte lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (sbyte lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (sbyte lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (sbyte lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (sbyte lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (sbyte lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, ushort rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, ushort rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, ushort rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, ushort rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, ushort rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, ushort rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (ushort lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (ushort lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (ushort lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (ushort lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (ushort lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (ushort lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, short rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, short rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, short rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, short rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, short rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, short rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (short lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (short lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (short lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (short lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (short lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (short lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, int rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, int rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, int rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, int rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, int rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, int rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (int lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (int lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (int lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (int lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (int lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (int lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, uint rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, uint rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, uint rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, uint rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, uint rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, uint rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (uint lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (uint lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (uint lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (uint lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (uint lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (uint lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, long rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, long rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, long rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, long rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, long rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, long rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (long lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (long lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (long lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (long lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (long lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (long lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, ulong rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, ulong rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, ulong rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, ulong rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, ulong rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, ulong rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (ulong lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (ulong lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (ulong lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (ulong lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (ulong lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (ulong lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, Int128 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, Int128 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, Int128 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, Int128 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, Int128 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, Int128 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (Int128 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (Int128 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (Int128 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (Int128 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (Int128 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (Int128 lhs, float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (float4 lhs, UInt128 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (float4 lhs, UInt128 rhs) => lhs != (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (float4 lhs, UInt128 rhs) => lhs < (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (float4 lhs, UInt128 rhs) => lhs > (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (float4 lhs, UInt128 rhs) => lhs <= (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (float4 lhs, UInt128 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator == (UInt128 lhs, float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator != (UInt128 lhs, float4 rhs) => (float4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator < (UInt128 lhs, float4 rhs) => (float4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator > (UInt128 lhs, float4 rhs) => (float4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator <= (UInt128 lhs, float4 rhs) => (float4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 operator >= (UInt128 lhs, float4 rhs) => (float4)lhs >= rhs;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 xyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 xywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xywz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xywz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 xzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzyw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 xzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 xwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 xwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 yxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 yxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxwz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxwz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 yzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzxw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 yzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzwx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzwx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 ywxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 ywzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 ywww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 zxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxyw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 zxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 zyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyxw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 zywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zywx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zywx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 zwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 zwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 wxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 wxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 wyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 wyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 wzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float4 wzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 wwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 xyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 xzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 xwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 xwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 yxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 yzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 ywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 ywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 ywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 zxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 zyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 zwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 zwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 wxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 wxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 wyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 wyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 wzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 wzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 wwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 www
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.www; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 xw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 yw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 zw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 wx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 wy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 wz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float2 ww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ww; }
        }


        public float this[int index]
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
        public readonly bool Equals(float other) => __x0.Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float4 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.float4 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is float4 converted && Equals(converted)) || (o is Unity.Mathematics.float4 convertedU && Equals(convertedU)) || (o is float convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
