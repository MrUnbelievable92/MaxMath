using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class float2DebuggerProxy
    {
        public float x;
        public float y;

        public float2DebuggerProxy(float2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(float2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct float2 : IEquatable<float2>, IEquatable<Unity.Mathematics.float2>, IEquatable<float>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.float2 __x0;
        
        public ref float x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float2* ptr = &this) { return ref *((float*)ptr +  0); } } }
        public ref float y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float2* ptr = &this) { return ref *((float*)ptr +  1); } } }


        public static float2 zero => default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float x, float y)
        {
            __x0 = new Unity.Mathematics.float2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float2 xy)
        {
            __x0 = new Unity.Mathematics.float2(xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float v)
        {
            __x0 = new Unity.Mathematics.float2(v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(Unity.Mathematics.float2 xy)
        {
            __x0 = xy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(bool v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(bool2 v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(mask8x2 v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(mask16x2 v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(mask32x2 v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(mask64x2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(byte v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(byte2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(sbyte v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(sbyte2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(ushort v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(ushort2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(short v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(short2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(uint v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(uint2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(int v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(int2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(ulong v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(ulong2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(long v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(long2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(UInt128 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(Int128 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(quarter v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(quarter2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(half v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(half2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(double v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(double2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(quadruple v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(Unity.Mathematics.bool2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(Unity.Mathematics.uint2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(Unity.Mathematics.int2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(Unity.Mathematics.half v)
        {
            this = (float2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(Unity.Mathematics.half2 v)
        {
            this = (float2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(Unity.Mathematics.double2 v)
        {
            this = (float2)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(v128 v) => math.asfloat((uint2)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(float2 v) => math.asuint(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(bool x) => (float2)(mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(bool2 x) => (float2)(mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(Unity.Mathematics.bool2 x) => (float2)(mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float2)(mask32x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float2)(mask32x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_ps(x, Xse.set1_ps(1));
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float2)(mask32x2)x;
            }
            else
            {
                return *(float2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(float2 x) => (Unity.Mathematics.bool2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(float2 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(float2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(float2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(float2 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(float2 x) => (mask32x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2(byte x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2(sbyte x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2(ushort x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2(short x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(ulong x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(long x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(UInt128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(Int128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(quadruple x) => (float)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(UnityEngine.Vector2 v) => new float2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector2(float2 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(Unity.Mathematics.float2 v) => new float2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(float2 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(Unity.Mathematics.int2 v) => new float2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(float2 v) => (Unity.Mathematics.int2)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(Unity.Mathematics.uint2 v) => new float2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(float2 v) => (Unity.Mathematics.uint2)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(Unity.Mathematics.half2 v) => (half2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(float2 v) => (half2)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(Unity.Mathematics.double2 v) => new float2 { __x0 = (Unity.Mathematics.float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(float2 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(float v) => new float2 { __x0 = (Unity.Mathematics.float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(int v) => new float2 { __x0 = (Unity.Mathematics.float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(int2 v) => new float2 { __x0 = (Unity.Mathematics.float2)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(uint v) => new float2 { __x0 = (Unity.Mathematics.float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(uint2 v) => new float2 { __x0 = (Unity.Mathematics.float2)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(half v) => (float)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(double v) => new float2 { __x0 = (Unity.Mathematics.float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(double2 v) => new float2 { __x0 = (Unity.Mathematics.float2)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 val) => +val.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 val) => -val.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator ++ (float2 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -- (float2 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, float2 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, float rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float lhs, float2 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, float2 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, float rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float lhs, float2 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, float2 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, float rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float lhs, float2 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, float2 rhs) => lhs.__x0 / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, float rhs) => lhs.__x0 / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float lhs, float2 rhs) => lhs / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, float2 rhs) => lhs.__x0 % rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, float rhs) => lhs.__x0 % rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float lhs, float2 rhs) => lhs % rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, Unity.Mathematics.float2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, Unity.Mathematics.float2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, Unity.Mathematics.float2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, Unity.Mathematics.float2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, Unity.Mathematics.float2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (float2 lhs, Unity.Mathematics.double2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (float2 lhs, Unity.Mathematics.double2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (float2 lhs, Unity.Mathematics.double2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (float2 lhs, Unity.Mathematics.double2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (float2 lhs, Unity.Mathematics.double2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, quarter rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, quarter rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, quarter rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, quarter rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, quarter rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (quarter lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (quarter lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (quarter lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (quarter lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (quarter lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, quarter2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, quarter2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, quarter2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, quarter2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, quarter2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (quarter2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (quarter2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (quarter2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (quarter2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (quarter2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, half rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, half rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, half rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, half rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, half rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (half lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (half lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (half lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (half lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (half lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, half2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, half2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, half2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, half2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, half2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (half2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (half2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (half2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (half2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (half2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, Unity.Mathematics.half rhs) => lhs + (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, Unity.Mathematics.half rhs) => lhs - (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, Unity.Mathematics.half rhs) => lhs * (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, Unity.Mathematics.half rhs) => lhs / (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, Unity.Mathematics.half rhs) => lhs % (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, Unity.Mathematics.half2 rhs) => lhs + (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, Unity.Mathematics.half2 rhs) => lhs - (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, Unity.Mathematics.half2 rhs) => lhs * (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, Unity.Mathematics.half2 rhs) => lhs / (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, Unity.Mathematics.half2 rhs) => lhs % (half2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, byte2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, byte2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, byte2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, byte2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, byte2 rhs) => lhs % (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (byte2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (byte2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (byte2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (byte2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (byte2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, sbyte2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, sbyte2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, sbyte2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, sbyte2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, sbyte2 rhs) => lhs % (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (sbyte2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (sbyte2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (sbyte2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (sbyte2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (sbyte2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, short2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, short2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, short2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, short2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, short2 rhs) => lhs % (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (short2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (short2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (short2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (short2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (short2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, ushort2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, ushort2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, ushort2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, ushort2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, ushort2 rhs) => lhs % (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (ushort2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (ushort2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (ushort2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (ushort2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (ushort2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, int2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, int2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, int2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, int2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, int2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (int2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (int2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (int2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (int2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (int2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, uint2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, uint2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, uint2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, uint2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, uint2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (uint2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (uint2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (uint2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (uint2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (uint2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, long2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, long2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, long2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, long2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, long2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (long2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (long2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (long2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (long2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (long2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, ulong2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, ulong2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, ulong2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, ulong2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, ulong2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (ulong2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (ulong2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (ulong2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (ulong2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (ulong2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, Unity.Mathematics.int2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, Unity.Mathematics.int2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, Unity.Mathematics.int2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, Unity.Mathematics.int2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, Unity.Mathematics.int2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, byte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (byte lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, byte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (byte lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, byte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (byte lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, byte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (byte lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, byte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (byte lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, sbyte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (sbyte lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, sbyte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (sbyte lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, sbyte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (sbyte lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, sbyte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (sbyte lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, sbyte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (sbyte lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, short rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (short lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, short rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (short lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, short rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (short lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, short rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (short lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, short rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (short lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, ushort rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (ushort lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, ushort rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (ushort lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, ushort rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (ushort lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, ushort rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (ushort lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, ushort rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (ushort lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, int rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (int lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, int rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (int lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, int rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (int lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, int rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (int lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, int rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (int lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, uint rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (uint lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, uint rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (uint lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, uint rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (uint lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, uint rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (uint lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, uint rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (uint lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, long rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (long lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, long rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (long lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, long rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (long lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, long rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (long lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, long rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (long lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, ulong rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (ulong lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, ulong rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (ulong lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, ulong rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (ulong lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, ulong rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (ulong lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, ulong rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (ulong lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, Int128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Int128 lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, Int128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Int128 lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, Int128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Int128 lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, Int128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Int128 lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, Int128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Int128 lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float2 lhs, UInt128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (UInt128 lhs, float2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float2 lhs, UInt128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (UInt128 lhs, float2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float2 lhs, UInt128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (UInt128 lhs, float2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float2 lhs, UInt128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (UInt128 lhs, float2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float2 lhs, UInt128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (UInt128 lhs, float2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, float2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_ps(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x == rhs.x, lhs.y == rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, float rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, float2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_ps(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x != rhs.x, lhs.y != rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, float rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, float2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_ps(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x < rhs.x, lhs.y < rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, float rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, float2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_ps(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x > rhs.x, lhs.y > rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, float rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, float2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_ps(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x <= rhs.x, lhs.y <= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, float rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, float2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_ps(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x >= rhs.x, lhs.y >= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, float rhs) => lhs >= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, Unity.Mathematics.float2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, Unity.Mathematics.float2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, Unity.Mathematics.float2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, Unity.Mathematics.float2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, Unity.Mathematics.float2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, Unity.Mathematics.float2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.float2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, Unity.Mathematics.double2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, Unity.Mathematics.double2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, Unity.Mathematics.double2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, Unity.Mathematics.double2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, Unity.Mathematics.double2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, Unity.Mathematics.double2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.double2 lhs, float2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, quarter rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, quarter rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, quarter rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, quarter rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, quarter rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, quarter rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (quarter lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (quarter lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (quarter lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (quarter lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (quarter lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (quarter lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, quarter2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, quarter2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, quarter2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, quarter2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, quarter2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, quarter2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (quarter2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (quarter2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (quarter2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (quarter2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (quarter2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (quarter2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, half rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, half rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, half rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, half rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, half rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, half rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (half lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (half lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (half lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (half lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (half lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (half lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, half2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, half2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, half2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, half2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, half2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, half2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (half2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (half2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (half2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (half2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (half2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (half2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.half lhs, float2 rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, Unity.Mathematics.half2 rhs) => lhs == (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, Unity.Mathematics.half2 rhs) => lhs != (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, Unity.Mathematics.half2 rhs) => lhs < (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, Unity.Mathematics.half2 rhs) => lhs > (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, Unity.Mathematics.half2 rhs) => lhs <= (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, Unity.Mathematics.half2 rhs) => lhs >= (half2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.half2 lhs, float2 rhs) => (half2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, byte2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, byte2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, byte2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, byte2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, byte2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, byte2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (byte2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (byte2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (byte2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (byte2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (byte2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (byte2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, sbyte2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, sbyte2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, sbyte2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, sbyte2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, sbyte2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, sbyte2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (sbyte2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (sbyte2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (sbyte2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (sbyte2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (sbyte2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (sbyte2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, ushort2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, ushort2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, ushort2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, ushort2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, ushort2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, ushort2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (ushort2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (ushort2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (ushort2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (ushort2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (ushort2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (ushort2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, short2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, short2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, short2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, short2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, short2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, short2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (short2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (short2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (short2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (short2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (short2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (short2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, int2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, int2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, int2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, int2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, int2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, int2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, uint2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, uint2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, uint2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, uint2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, uint2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, uint2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, Unity.Mathematics.int2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, Unity.Mathematics.int2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, Unity.Mathematics.int2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, Unity.Mathematics.int2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, Unity.Mathematics.int2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, Unity.Mathematics.int2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.int2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, Unity.Mathematics.uint2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.uint2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, long2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, long2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, long2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, long2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, long2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, long2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (long2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (long2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (long2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (long2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (long2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (long2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, ulong2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, ulong2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, ulong2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, ulong2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, ulong2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, ulong2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (ulong2 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (ulong2 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (ulong2 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (ulong2 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (ulong2 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (ulong2 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, byte rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, byte rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, byte rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, byte rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, byte rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, byte rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (byte lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (byte lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (byte lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (byte lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (byte lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (byte lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, sbyte rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, sbyte rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, sbyte rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, sbyte rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, sbyte rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, sbyte rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (sbyte lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (sbyte lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (sbyte lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (sbyte lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (sbyte lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (sbyte lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, ushort rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, ushort rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, ushort rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, ushort rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, ushort rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, ushort rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (ushort lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (ushort lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (ushort lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (ushort lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (ushort lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (ushort lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, short rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, short rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, short rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, short rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, short rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, short rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (short lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (short lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (short lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (short lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (short lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (short lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, int rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, int rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, int rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, int rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, int rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, int rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, uint rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, uint rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, uint rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, uint rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, uint rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, uint rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, long rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, long rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, long rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, long rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, long rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, long rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (long lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (long lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (long lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (long lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (long lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (long lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, ulong rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, ulong rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, ulong rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, ulong rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, ulong rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, ulong rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (ulong lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (ulong lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (ulong lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (ulong lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (ulong lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (ulong lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, Int128 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, Int128 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, Int128 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, Int128 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, Int128 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, Int128 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Int128 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Int128 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Int128 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Int128 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Int128 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Int128 lhs, float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (float2 lhs, UInt128 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (float2 lhs, UInt128 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (float2 lhs, UInt128 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (float2 lhs, UInt128 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (float2 lhs, UInt128 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (float2 lhs, UInt128 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (UInt128 lhs, float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (UInt128 lhs, float2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (UInt128 lhs, float2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (UInt128 lhs, float2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (UInt128 lhs, float2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (UInt128 lhs, float2 rhs) => (float2)lhs >= rhs;


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
        public readonly bool Equals(float2 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.float2 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is float2 converted && Equals(converted)) || (o is Unity.Mathematics.float2 convertedU && Equals(convertedU)) || (o is float convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
