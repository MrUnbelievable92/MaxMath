using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class double2DebuggerProxy
    {
        public double x;
        public double y;

        public double2DebuggerProxy(double2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(double2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct double2 : IEquatable<double2>, IEquatable<Unity.Mathematics.double2>, IEquatable<double>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.double2 __x0;
        
        public ref double x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(double2* ptr = &this) { return ref *((double*)ptr +  0); } } }
        public ref double y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(double2* ptr = &this) { return ref *((double*)ptr +  1); } } }


        public static double2 zero => default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double x, double y)
        {
            __x0 = new Unity.Mathematics.double2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double2 xy)
        {
            __x0 = new Unity.Mathematics.double2(xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double v)
        {
            __x0 = new Unity.Mathematics.double2(v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(Unity.Mathematics.double2 xy)
        {
            __x0 = xy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(bool v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(bool2 v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(mask8x2 v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(mask16x2 v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(mask32x2 v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(mask64x2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(byte v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(byte2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(sbyte v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(sbyte2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(ushort v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(ushort2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(short v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(short2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(uint v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(uint2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(int v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(int2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(ulong v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(ulong2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(long v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(long2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(UInt128 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(Int128 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(quarter v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(quarter2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(half v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(half2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(float v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(float2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(quadruple v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(Unity.Mathematics.bool2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(Unity.Mathematics.uint2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(Unity.Mathematics.int2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(Unity.Mathematics.half v)
        {
            this = (double2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(Unity.Mathematics.half2 v)
        {
            this = (double2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(Unity.Mathematics.float2 v)
        {
            this = (double2)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(v128 v) => math.asdouble((ulong2)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(double2 v) => math.asulong(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(bool x) => (double2)(mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(bool2 x) => (double2)(mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(Unity.Mathematics.bool2 x) => (double2)(mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (double2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (double2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (double2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_pd(x, Xse.set1_pd(1));
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(double2 x) => (Unity.Mathematics.bool2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(double2 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(double2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(double2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(double2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(double2 x) => math.andnot(x != 0, math.isnan(x));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double2(byte x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double2(sbyte x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double2(ushort x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double2(short x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(ulong x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(long x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(UInt128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Int128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(quadruple x) => (double)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Unity.Mathematics.double2 v) => new double2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(double2 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Unity.Mathematics.int2 v) => new double2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(double2 v) => (Unity.Mathematics.int2)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Unity.Mathematics.uint2 v) => new double2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(double2 v) => (Unity.Mathematics.uint2)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Unity.Mathematics.half2 v) => (half2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(double2 v) => (half2)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Unity.Mathematics.float2 v) => new double2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2(double2 v) => (Unity.Mathematics.float2)v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(double v) => new double2 { __x0 = (Unity.Mathematics.double2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(int v) => new double2 { __x0 = (Unity.Mathematics.double2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(int2 v) => new double2 { __x0 = (Unity.Mathematics.double2)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(uint v) => new double2 { __x0 = (Unity.Mathematics.double2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(uint2 v) => new double2 { __x0 = (Unity.Mathematics.double2)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(half v) => (double)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(float v) => new double2 { __x0 = (Unity.Mathematics.double2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(float2 v) => new double2 { __x0 = (Unity.Mathematics.double2)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 val) => +val.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 val) => -val.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator ++ (double2 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -- (double2 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, double2 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, double rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double lhs, double2 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, double2 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, double rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double lhs, double2 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, double2 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, double rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double lhs, double2 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, double2 rhs) => lhs.__x0 / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, double rhs) => lhs.__x0 / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double lhs, double2 rhs) => lhs / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, double2 rhs) => lhs.__x0 % rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, double rhs) => lhs.__x0 % rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double lhs, double2 rhs) => lhs % rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, Unity.Mathematics.double2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, Unity.Mathematics.double2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, Unity.Mathematics.double2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, Unity.Mathematics.double2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, Unity.Mathematics.double2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, quarter rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, quarter rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, quarter rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, quarter rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, quarter rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (quarter lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (quarter lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (quarter lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (quarter lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (quarter lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, quarter2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, quarter2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, quarter2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, quarter2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, quarter2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (quarter2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (quarter2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (quarter2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (quarter2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (quarter2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, half rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, half rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, half rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, half rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, half rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (half lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (half lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (half lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (half lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (half lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, half2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, half2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, half2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, half2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, half2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (half2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (half2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (half2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (half2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (half2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, Unity.Mathematics.half rhs) => lhs + (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, Unity.Mathematics.half rhs) => lhs - (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, Unity.Mathematics.half rhs) => lhs * (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, Unity.Mathematics.half rhs) => lhs / (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, Unity.Mathematics.half rhs) => lhs % (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, Unity.Mathematics.half2 rhs) => lhs + (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, Unity.Mathematics.half2 rhs) => lhs - (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, Unity.Mathematics.half2 rhs) => lhs * (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, Unity.Mathematics.half2 rhs) => lhs / (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, Unity.Mathematics.half2 rhs) => lhs % (half2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, float rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, float rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, float rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, float rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, float rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (float lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (float lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (float lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (float lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (float lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, float2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, float2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, float2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, float2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, float2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (float2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (float2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (float2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (float2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (float2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, Unity.Mathematics.float2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, Unity.Mathematics.float2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, Unity.Mathematics.float2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, Unity.Mathematics.float2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, Unity.Mathematics.float2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, byte2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, byte2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, byte2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, byte2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, byte2 rhs) => lhs % (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (byte2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (byte2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (byte2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (byte2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (byte2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, sbyte2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, sbyte2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, sbyte2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, sbyte2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, sbyte2 rhs) => lhs % (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (sbyte2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (sbyte2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (sbyte2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (sbyte2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (sbyte2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, short2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, short2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, short2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, short2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, short2 rhs) => lhs % (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (short2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (short2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (short2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (short2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (short2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, ushort2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, ushort2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, ushort2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, ushort2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, ushort2 rhs) => lhs % (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (ushort2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (ushort2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (ushort2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (ushort2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (ushort2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, int2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, int2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, int2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, int2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, int2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (int2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (int2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (int2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (int2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (int2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, uint2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, uint2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, uint2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, uint2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, uint2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (uint2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (uint2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (uint2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (uint2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (uint2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, long2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, long2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, long2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, long2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, long2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (long2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (long2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (long2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (long2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (long2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, ulong2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, ulong2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, ulong2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, ulong2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, ulong2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (ulong2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (ulong2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (ulong2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (ulong2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (ulong2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, Unity.Mathematics.int2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, Unity.Mathematics.int2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, Unity.Mathematics.int2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, Unity.Mathematics.int2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, Unity.Mathematics.int2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, byte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (byte lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, byte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (byte lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, byte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (byte lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, byte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (byte lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, byte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (byte lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, sbyte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (sbyte lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, sbyte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (sbyte lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, sbyte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (sbyte lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, sbyte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (sbyte lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, sbyte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (sbyte lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, short rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (short lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, short rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (short lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, short rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (short lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, short rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (short lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, short rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (short lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, ushort rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (ushort lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, ushort rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (ushort lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, ushort rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (ushort lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, ushort rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (ushort lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, ushort rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (ushort lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, int rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (int lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, int rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (int lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, int rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (int lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, int rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (int lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, int rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (int lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, uint rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (uint lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, uint rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (uint lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, uint rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (uint lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, uint rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (uint lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, uint rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (uint lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, long rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (long lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, long rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (long lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, long rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (long lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, long rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (long lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, long rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (long lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, ulong rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (ulong lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, ulong rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (ulong lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, ulong rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (ulong lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, ulong rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (ulong lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, ulong rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (ulong lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, Int128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Int128 lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, Int128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Int128 lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, Int128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Int128 lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, Int128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Int128 lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, Int128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Int128 lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double2 lhs, UInt128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (UInt128 lhs, double2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double2 lhs, UInt128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (UInt128 lhs, double2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double2 lhs, UInt128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (UInt128 lhs, double2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double2 lhs, UInt128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (UInt128 lhs, double2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double2 lhs, UInt128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (UInt128 lhs, double2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, double2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_pd(lhs, rhs);
            }
            else
            {
                return new mask64x2(lhs.x == rhs.x, lhs.y == rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, double rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, double2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_pd(lhs, rhs);
            }
            else
            {
                return new mask64x2(lhs.x != rhs.x, lhs.y != rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, double rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, double2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_pd(lhs, rhs);
            }
            else
            {
                return new mask64x2(lhs.x < rhs.x, lhs.y < rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, double rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, double2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_pd(lhs, rhs);
            }
            else
            {
                return new mask64x2(lhs.x > rhs.x, lhs.y > rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, double rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, double2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_pd(lhs, rhs);
            }
            else
            {
                return new mask64x2(lhs.x <= rhs.x, lhs.y <= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, double rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, double2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_pd(lhs, rhs);
            }
            else
            {
                return new mask64x2(lhs.x >= rhs.x, lhs.y >= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, double rhs) => lhs >= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, Unity.Mathematics.double2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, Unity.Mathematics.double2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, Unity.Mathematics.double2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, Unity.Mathematics.double2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, Unity.Mathematics.double2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, Unity.Mathematics.double2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.double2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, quarter rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, quarter rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, quarter rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, quarter rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, quarter rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, quarter rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (quarter lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (quarter lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (quarter lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (quarter lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (quarter lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (quarter lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, quarter2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, quarter2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, quarter2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, quarter2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, quarter2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, quarter2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (quarter2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (quarter2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (quarter2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (quarter2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (quarter2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (quarter2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, half rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, half rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, half rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, half rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, half rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, half rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (half lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (half lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (half lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (half lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (half lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (half lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, half2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, half2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, half2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, half2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, half2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, half2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (half2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (half2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (half2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (half2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (half2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (half2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.half lhs, double2 rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, Unity.Mathematics.half2 rhs) => lhs == (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, Unity.Mathematics.half2 rhs) => lhs != (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, Unity.Mathematics.half2 rhs) => lhs < (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, Unity.Mathematics.half2 rhs) => lhs > (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, Unity.Mathematics.half2 rhs) => lhs <= (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, Unity.Mathematics.half2 rhs) => lhs >= (half2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.half2 lhs, double2 rhs) => (half2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, float rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, float rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, float rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, float rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, float rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, float rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (float lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (float lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (float lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (float lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (float lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (float lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, float2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, float2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, float2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, float2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, float2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, float2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (float2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (float2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (float2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (float2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (float2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (float2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, Unity.Mathematics.float2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, Unity.Mathematics.float2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, Unity.Mathematics.float2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, Unity.Mathematics.float2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, Unity.Mathematics.float2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, Unity.Mathematics.float2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.float2 lhs, double2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, byte2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, byte2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, byte2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, byte2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, byte2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, byte2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (byte2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (byte2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (byte2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (byte2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (byte2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (byte2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, sbyte2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, sbyte2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, sbyte2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, sbyte2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, sbyte2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, sbyte2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (sbyte2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (sbyte2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (sbyte2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (sbyte2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (sbyte2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (sbyte2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, ushort2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, ushort2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, ushort2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, ushort2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, ushort2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, ushort2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ushort2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ushort2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ushort2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ushort2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ushort2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ushort2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, short2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, short2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, short2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, short2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, short2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, short2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (short2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (short2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (short2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (short2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (short2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (short2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, int2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, int2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, int2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, int2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, int2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, int2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (int2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (int2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (int2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (int2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (int2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (int2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, uint2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, uint2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, uint2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, uint2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, uint2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, uint2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (uint2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (uint2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (uint2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (uint2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (uint2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (uint2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, Unity.Mathematics.int2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, Unity.Mathematics.int2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, Unity.Mathematics.int2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, Unity.Mathematics.int2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, Unity.Mathematics.int2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, Unity.Mathematics.int2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.int2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, Unity.Mathematics.uint2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.uint2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, long2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, long2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, long2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, long2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, long2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, long2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, ulong2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, ulong2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, ulong2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, ulong2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, ulong2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, ulong2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, byte rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, byte rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, byte rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, byte rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, byte rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, byte rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (byte lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (byte lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (byte lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (byte lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (byte lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (byte lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, sbyte rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, sbyte rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, sbyte rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, sbyte rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, sbyte rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, sbyte rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (sbyte lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (sbyte lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (sbyte lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (sbyte lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (sbyte lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (sbyte lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, ushort rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, ushort rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, ushort rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, ushort rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, ushort rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, ushort rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ushort lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ushort lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ushort lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ushort lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ushort lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ushort lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, short rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, short rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, short rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, short rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, short rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, short rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (short lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (short lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (short lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (short lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (short lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (short lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, int rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, int rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, int rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, int rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, int rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, int rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (int lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (int lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (int lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (int lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (int lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (int lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, uint rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, uint rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, uint rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, uint rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, uint rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, uint rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (uint lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (uint lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (uint lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (uint lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (uint lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (uint lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, long rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, long rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, long rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, long rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, long rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, long rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, ulong rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, ulong rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, ulong rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, ulong rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, ulong rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, ulong rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, Int128 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, Int128 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, Int128 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, Int128 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, Int128 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, Int128 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Int128 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Int128 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Int128 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Int128 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Int128 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Int128 lhs, double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (double2 lhs, UInt128 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (double2 lhs, UInt128 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (double2 lhs, UInt128 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (double2 lhs, UInt128 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (double2 lhs, UInt128 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (double2 lhs, UInt128 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (UInt128 lhs, double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (UInt128 lhs, double2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (UInt128 lhs, double2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (UInt128 lhs, double2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (UInt128 lhs, double2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (UInt128 lhs, double2 rhs) => (double2)lhs >= rhs;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yy; }
        }


        public double this[int index]
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
        public readonly bool Equals(double other) => __x0.Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double2 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.double2 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is double2 converted && Equals(converted)) || (o is Unity.Mathematics.double2 convertedU && Equals(convertedU)) || (o is double convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
