using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class double3DebuggerProxy
    {
        public double x;
        public double y;
        public double z;
        
        public double3DebuggerProxy(double3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(double3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct double3 : IEquatable<double3>, IEquatable<Unity.Mathematics.double3>, IEquatable<double>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.double3 __x0;
        
        public ref double x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(double3* ptr = &this) { return ref *((double*)ptr +  0); } } }
        public ref double y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(double3* ptr = &this) { return ref *((double*)ptr +  1); } } }
        public ref double z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(double3* ptr = &this) { return ref *((double*)ptr +  2); } } }


        public static double3 zero => default;
        
        
        /// <summary>   Unity's up axis (0, 1, 0).  </summary>
        public static double3 Up => new double3(0d, 1d, 0d);

        /// <summary>   Unity's down axis (0, -1, 0).   </summary>
        public static double3 Down => new double3(0d, -1d, 0d);

        /// <summary>   Unity's forward axis (0, 0, 1).     </summary>
        public static double3 Forward => new double3(0d, 0d, 1d);

        /// <summary>   Unity's back axis (0, 0, -1).   </summary>
        public static double3 Back => new double3(0d, 0d, -1d);

        /// <summary>   Unity's left axis (-1, 0, 0).   </summary>
        public static double3 Left => new double3(-1d, 0d, 0d);

        /// <summary>   Unity's right axis (1, 0, 0).   </summary>
        public static double3 Right => new double3(1d, 0d, 0d);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double x, double y, double z)
        {
            __x0 = new Unity.Mathematics.double3(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double x, double2 yz)
        {
            __x0 = new Unity.Mathematics.double3(x, yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double2 xy, double z)
        {
            __x0 = new Unity.Mathematics.double3(xy, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double3 xyz)
        {
            __x0 = new Unity.Mathematics.double3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double v)
        {
            __x0 = new Unity.Mathematics.double3(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(Unity.Mathematics.double3 xyz)
        {
            __x0 = new Unity.Mathematics.double3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(bool v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(bool3 v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(mask8x3 v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(mask16x3 v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(mask32x3 v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(mask64x3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(byte v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(byte3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(sbyte v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(sbyte3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(ushort v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(ushort3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(short v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(short3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(uint v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(uint3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(int v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(int3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(ulong v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(ulong3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(long v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(long3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(UInt128 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(Int128 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(quarter v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(quarter3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(half v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(half3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(float v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(float3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(quadruple v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(Unity.Mathematics.bool3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(Unity.Mathematics.uint3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(Unity.Mathematics.int3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(Unity.Mathematics.half v)
        {
            this = (double3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(Unity.Mathematics.half3 v)
        {
            this = (double3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(Unity.Mathematics.float3 v)
        {
            this = (double3)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(v256 v) => math.asdouble((ulong3)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(double3 v) => math.asulong(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(bool x) => (double3)(mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(bool3 x) => (double3)(mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(Unity.Mathematics.bool3 x) => (double3)(mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (double3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (double3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (double3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(mask64x3 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_pd(x, Xse.mm256_set1_pd(1));
            }
            else
            {
                return new double3((double2)x.xy, math.todouble(x.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(double3 x) => (Unity.Mathematics.bool3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(double3 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(double3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(double3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(double3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(double3 x) => math.andnot(x != 0, math.isnan(x));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double3(byte x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double3(sbyte x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double3(ushort x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double3(short x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(ulong x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(long x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(UInt128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Int128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(quadruple x) => (double)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Unity.Mathematics.double3 v) => new double3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(double3 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Unity.Mathematics.int3 v) => new double3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(double3 v) => (Unity.Mathematics.int3)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Unity.Mathematics.uint3 v) => new double3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(double3 v) => (Unity.Mathematics.uint3)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Unity.Mathematics.half3 v) => (half3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(double3 v) => (half3)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Unity.Mathematics.float3 v) => new double3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float3(double3 v) => (Unity.Mathematics.float3)v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(double v) => new double3 { __x0 = (Unity.Mathematics.double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(int v) => new double3 { __x0 = (Unity.Mathematics.double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(int3 v) => new double3 { __x0 = (Unity.Mathematics.double3)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(uint v) => new double3 { __x0 = (Unity.Mathematics.double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(uint3 v) => new double3 { __x0 = (Unity.Mathematics.double3)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(half v) => (double)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(float v) => new double3 { __x0 = (Unity.Mathematics.double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(float3 v) => new double3 { __x0 = (Unity.Mathematics.double3)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 val) => +val.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 val) => -val.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator ++ (double3 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator -- (double3 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, double3 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, double rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double lhs, double3 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, double3 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, double rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double lhs, double3 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, double3 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, double rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double lhs, double3 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, double3 rhs) => lhs.__x0 / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, double rhs) => lhs.__x0 / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double lhs, double3 rhs) => lhs / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, double3 rhs) => lhs.__x0 % rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, double rhs) => lhs.__x0 % rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double lhs, double3 rhs) => lhs % rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, Unity.Mathematics.double3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, Unity.Mathematics.double3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, Unity.Mathematics.double3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, Unity.Mathematics.double3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, Unity.Mathematics.double3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, quarter rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, quarter rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, quarter rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, quarter rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, quarter rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (quarter lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (quarter lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (quarter lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (quarter lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (quarter lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, quarter3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, quarter3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, quarter3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, quarter3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, quarter3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (quarter3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (quarter3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (quarter3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (quarter3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (quarter3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, half rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, half rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, half rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, half rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, half rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (half lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (half lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (half lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (half lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (half lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, half3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, half3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, half3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, half3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, half3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (half3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (half3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (half3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (half3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (half3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, Unity.Mathematics.half rhs) => lhs + (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, Unity.Mathematics.half rhs) => lhs - (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, Unity.Mathematics.half rhs) => lhs * (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, Unity.Mathematics.half rhs) => lhs / (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, Unity.Mathematics.half rhs) => lhs % (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, Unity.Mathematics.half3 rhs) => lhs + (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, Unity.Mathematics.half3 rhs) => lhs - (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, Unity.Mathematics.half3 rhs) => lhs * (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, Unity.Mathematics.half3 rhs) => lhs / (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, Unity.Mathematics.half3 rhs) => lhs % (half3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, float rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, float rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, float rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, float rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, float rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (float lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (float lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (float lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (float lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (float lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, float3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, float3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, float3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, float3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, float3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (float3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (float3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (float3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (float3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (float3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, Unity.Mathematics.float3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, Unity.Mathematics.float3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, Unity.Mathematics.float3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, Unity.Mathematics.float3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, Unity.Mathematics.float3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, byte3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, byte3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, byte3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, byte3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, byte3 rhs) => lhs % (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (byte3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (byte3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (byte3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (byte3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (byte3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, sbyte3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, sbyte3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, sbyte3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, sbyte3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, sbyte3 rhs) => lhs % (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (sbyte3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (sbyte3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (sbyte3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (sbyte3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (sbyte3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, short3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, short3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, short3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, short3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, short3 rhs) => lhs % (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (short3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (short3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (short3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (short3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (short3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, ushort3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, ushort3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, ushort3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, ushort3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, ushort3 rhs) => lhs % (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (ushort3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (ushort3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (ushort3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (ushort3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (ushort3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, int3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, int3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, int3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, int3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, int3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (int3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (int3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (int3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (int3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (int3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, uint3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, uint3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, uint3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, uint3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, uint3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (uint3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (uint3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (uint3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (uint3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (uint3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, long3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, long3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, long3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, long3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, long3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (long3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (long3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (long3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (long3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (long3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, ulong3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, ulong3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, ulong3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, ulong3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, ulong3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (ulong3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (ulong3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (ulong3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (ulong3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (ulong3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, Unity.Mathematics.int3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, Unity.Mathematics.int3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, Unity.Mathematics.int3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, Unity.Mathematics.int3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, Unity.Mathematics.int3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, byte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (byte lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, byte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (byte lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, byte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (byte lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, byte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (byte lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, byte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (byte lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, sbyte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (sbyte lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, sbyte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (sbyte lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, sbyte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (sbyte lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, sbyte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (sbyte lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, sbyte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (sbyte lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, short rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (short lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, short rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (short lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, short rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (short lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, short rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (short lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, short rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (short lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, ushort rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (ushort lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, ushort rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (ushort lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, ushort rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (ushort lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, ushort rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (ushort lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, ushort rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (ushort lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, int rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (int lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, int rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (int lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, int rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (int lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, int rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (int lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, int rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (int lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, uint rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (uint lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, uint rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (uint lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, uint rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (uint lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, uint rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (uint lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, uint rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (uint lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, long rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (long lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, long rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (long lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, long rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (long lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, long rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (long lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, long rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (long lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, ulong rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (ulong lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, ulong rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (ulong lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, ulong rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (ulong lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, ulong rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (ulong lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, ulong rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (ulong lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, Int128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Int128 lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, Int128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Int128 lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, Int128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Int128 lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, Int128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Int128 lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, Int128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Int128 lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, UInt128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (UInt128 lhs, double3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, UInt128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (UInt128 lhs, double3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, UInt128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (UInt128 lhs, double3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, UInt128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (UInt128 lhs, double3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, UInt128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (UInt128 lhs, double3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, double3 rhs)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpeq_pd(lhs, rhs);
            }
            else
            {
                return new mask64x3(lhs.xy == rhs.xy, lhs.z == rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, double rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, double3 rhs)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpneq_pd(lhs, rhs);
            }
            else
            {
                return new mask64x3(lhs.xy != rhs.xy, lhs.z != rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, double rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, double3 rhs)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmplt_pd(lhs, rhs);
            }
            else
            {
                return new mask64x3(lhs.xy < rhs.xy, lhs.z < rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, double rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, double3 rhs)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpgt_pd(lhs, rhs);
            }
            else
            {
                return new mask64x3(lhs.xy > rhs.xy, lhs.z > rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, double rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, double3 rhs)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmple_pd(lhs, rhs);
            }
            else
            {
                return new mask64x3(lhs.xy <= rhs.xy, lhs.z <= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, double rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, double3 rhs)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpge_pd(lhs, rhs);
            }
            else
            {
                return new mask64x3(lhs.xy >= rhs.xy, lhs.z >= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, double rhs) => lhs >= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, Unity.Mathematics.double3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, Unity.Mathematics.double3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, Unity.Mathematics.double3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, Unity.Mathematics.double3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, Unity.Mathematics.double3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, Unity.Mathematics.double3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.double3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, quarter rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, quarter rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, quarter rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, quarter rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, quarter rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, quarter rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (quarter lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (quarter lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (quarter lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (quarter lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (quarter lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (quarter lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, quarter3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, quarter3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, quarter3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, quarter3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, quarter3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, quarter3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (quarter3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (quarter3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (quarter3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (quarter3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (quarter3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (quarter3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, half rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, half rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, half rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, half rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, half rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, half rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (half lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (half lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (half lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (half lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (half lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (half lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, half3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, half3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, half3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, half3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, half3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, half3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (half3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (half3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (half3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (half3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (half3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (half3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.half lhs, double3 rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, Unity.Mathematics.half3 rhs) => lhs == (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, Unity.Mathematics.half3 rhs) => lhs != (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, Unity.Mathematics.half3 rhs) => lhs < (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, Unity.Mathematics.half3 rhs) => lhs > (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, Unity.Mathematics.half3 rhs) => lhs <= (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, Unity.Mathematics.half3 rhs) => lhs >= (half3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.half3 lhs, double3 rhs) => (half3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, float rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, float rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, float rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, float rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, float rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, float rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (float lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (float lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (float lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (float lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (float lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (float lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, float3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, float3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, float3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, float3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, float3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, float3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (float3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (float3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (float3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (float3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (float3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (float3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, Unity.Mathematics.float3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, Unity.Mathematics.float3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, Unity.Mathematics.float3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, Unity.Mathematics.float3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, Unity.Mathematics.float3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, Unity.Mathematics.float3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.float3 lhs, double3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, byte3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, byte3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, byte3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, byte3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, byte3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, byte3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (byte3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (byte3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (byte3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (byte3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (byte3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (byte3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, sbyte3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, sbyte3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, sbyte3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, sbyte3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, sbyte3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, sbyte3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (sbyte3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (sbyte3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (sbyte3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (sbyte3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (sbyte3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (sbyte3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, ushort3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, ushort3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, ushort3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, ushort3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, ushort3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, ushort3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ushort3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ushort3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ushort3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ushort3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ushort3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ushort3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, short3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, short3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, short3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, short3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, short3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, short3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (short3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (short3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (short3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (short3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (short3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (short3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, int3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, int3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, int3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, int3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, int3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, int3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (int3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (int3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (int3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (int3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (int3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (int3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, uint3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, uint3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, uint3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, uint3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, uint3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, uint3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (uint3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (uint3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (uint3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (uint3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (uint3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (uint3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, Unity.Mathematics.int3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, Unity.Mathematics.int3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, Unity.Mathematics.int3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, Unity.Mathematics.int3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, Unity.Mathematics.int3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, Unity.Mathematics.int3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.int3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, Unity.Mathematics.uint3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.uint3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, long3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, long3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, long3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, long3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, long3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, long3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, ulong3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, ulong3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, ulong3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, ulong3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, ulong3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, ulong3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong3 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong3 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong3 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong3 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong3 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong3 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, byte rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, byte rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, byte rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, byte rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, byte rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, byte rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (byte lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (byte lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (byte lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (byte lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (byte lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (byte lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, sbyte rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, sbyte rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, sbyte rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, sbyte rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, sbyte rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, sbyte rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (sbyte lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (sbyte lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (sbyte lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (sbyte lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (sbyte lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (sbyte lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, ushort rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, ushort rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, ushort rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, ushort rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, ushort rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, ushort rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ushort lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ushort lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ushort lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ushort lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ushort lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ushort lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, short rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, short rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, short rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, short rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, short rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, short rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (short lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (short lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (short lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (short lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (short lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (short lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, int rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, int rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, int rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, int rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, int rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, int rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (int lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (int lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (int lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (int lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (int lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (int lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, uint rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, uint rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, uint rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, uint rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, uint rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, uint rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (uint lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (uint lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (uint lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (uint lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (uint lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (uint lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, long rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, long rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, long rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, long rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, long rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, long rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, ulong rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, ulong rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, ulong rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, ulong rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, ulong rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, ulong rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ulong lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ulong lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ulong lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ulong lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ulong lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ulong lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, Int128 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, Int128 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, Int128 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, Int128 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, Int128 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, Int128 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Int128 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Int128 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Int128 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Int128 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Int128 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Int128 lhs, double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (double3 lhs, UInt128 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (double3 lhs, UInt128 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (double3 lhs, UInt128 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (double3 lhs, UInt128 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (double3 lhs, UInt128 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (double3 lhs, UInt128 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (UInt128 lhs, double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (UInt128 lhs, double3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (UInt128 lhs, double3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (UInt128 lhs, double3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (UInt128 lhs, double3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (UInt128 lhs, double3 rhs) => (double3)lhs >= rhs;


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
        public readonly double4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxz; }
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
        public readonly double4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzz; }
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
        public readonly double4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxz; }
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
        public readonly double4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzz; }
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
        public readonly double4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxz; }
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
        public readonly double4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzz; }
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
        public readonly double4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxz; }
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
        public readonly double4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzz; }
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
        public readonly double3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxz; }
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
        public double3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzz; }
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
        public double3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxz = value; }
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
        public readonly double3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzz; }
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
        public double2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xz = value; }
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public double2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly double2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zz; }
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
        public readonly bool Equals(double3 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.double3 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is double3 converted && Equals(converted)) || (o is Unity.Mathematics.double3 convertedU && Equals(convertedU)) || (o is double convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
