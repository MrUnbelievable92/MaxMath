using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct long3x2 : IEquatable<long3x2>, IFormattable
    {
        public long3 c0;
        public long3 c1;

        public static long3x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(long3 c0, long3 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(long m00, long m01,
                       long m10, long m11,
                       long m20, long m21)
        {
            this.c0 = new long3(m00, m10, m20);
            this.c1 = new long3(m01, m11, m21);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(bool v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(bool3x2 v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(mask8x3x2 v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(mask16x3x2 v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(mask32x3x2 v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(mask64x3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(byte v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(byte3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(sbyte v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(sbyte3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(ushort v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(ushort3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(short v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(short3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(uint v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(uint3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(int v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(int3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(ulong v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(ulong3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(long v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(long3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(UInt128 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(Int128 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(quarter v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(half v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(float v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(float3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(double v)
        {
            this = (long3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(double3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(quadruple v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(Unity.Mathematics.bool3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(Unity.Mathematics.uint3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(Unity.Mathematics.int3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(Unity.Mathematics.half v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(Unity.Mathematics.float3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3x2(Unity.Mathematics.double3x2 v)
        {
            this = (long3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(UInt128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(Int128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(quarter x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(quadruple x) => (long)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(long3x2 v) => new bool3x2 { c0 = (bool3)v.c0, c1 = (bool3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(Unity.Mathematics.bool3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x2(long3x2 v) => new Unity.Mathematics.bool3x2 { c0 = (bool3)v.c0, c1 = (bool3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(Unity.Mathematics.int3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x2(long3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(Unity.Mathematics.uint3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x2(long3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(Unity.Mathematics.half v) => (long3x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(Unity.Mathematics.float3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3x2(long3x2 v) => new float3x2 { c0 = (float3)v.c0, c1 = (float3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(Unity.Mathematics.double3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x2(long3x2 v) => new double3x2 { c0 = (double3)v.c0, c1 = (double3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(long v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(bool v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(bool3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3x2(sbyte v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(sbyte3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3x2(short v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(short3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(int v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(int3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3x2(byte v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(byte3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3x2(ushort v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(ushort3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(uint v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(uint3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(ulong v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(ulong3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(half v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(float v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(float3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(double v) => new long3x2 { c0 = (long3)v, c1 = (long3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(double3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(mask8x3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(mask16x3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(mask32x3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3x2(mask64x3x2 v) => new long3x2 { c0 = (long3)v.c0, c1 = (long3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x2(long3x2 v) => new mask8x3x2 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x2(long3x2 v) => new mask16x3x2 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x2(long3x2 v) => new mask32x3x2 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x2(long3x2 v) => new mask64x3x2 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 val) => new long3x2 { c0 = -val.c0, c1 = -val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ++ (long3x2 val) => new long3x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator -- (long3x2 val) => new long3x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, long3x2 rhs) => new long3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, long rhs) => new long3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long lhs, long3x2 rhs) => new long3x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, long3x2 rhs) => new long3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, long rhs) => new long3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long lhs, long3x2 rhs) => new long3x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, long3x2 rhs) => new long3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, long rhs) => new long3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long lhs, long3x2 rhs) => new long3x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, long3x2 rhs) => new long3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, long rhs) => new long3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long lhs, long3x2 rhs) => new long3x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, long3x2 rhs) => new long3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, long rhs) => new long3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long lhs, long3x2 rhs) => new long3x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, byte3x2 rhs) => new long3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, byte3x2 rhs) => new long3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, byte3x2 rhs) => new long3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, byte3x2 rhs) => new long3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, byte3x2 rhs) => new long3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, sbyte3x2 rhs) => new long3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, sbyte3x2 rhs) => new long3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, sbyte3x2 rhs) => new long3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, sbyte3x2 rhs) => new long3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, sbyte3x2 rhs) => new long3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, short3x2 rhs) => new long3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, short3x2 rhs) => new long3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, short3x2 rhs) => new long3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, short3x2 rhs) => new long3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, short3x2 rhs) => new long3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (short3x2 lhs, long3x2 rhs) => (long3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (short3x2 lhs, long3x2 rhs) => (long3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (short3x2 lhs, long3x2 rhs) => (long3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (short3x2 lhs, long3x2 rhs) => (long3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (short3x2 lhs, long3x2 rhs) => (long3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, ushort3x2 rhs) => new long3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, ushort3x2 rhs) => new long3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, ushort3x2 rhs) => new long3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, ushort3x2 rhs) => new long3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, ushort3x2 rhs) => new long3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, int3x2 rhs) => new long3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, int3x2 rhs) => new long3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, int3x2 rhs) => new long3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, int3x2 rhs) => new long3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, int3x2 rhs) => new long3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (int3x2 lhs, long3x2 rhs) => (long3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (int3x2 lhs, long3x2 rhs) => (long3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (int3x2 lhs, long3x2 rhs) => (long3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (int3x2 lhs, long3x2 rhs) => (long3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (int3x2 lhs, long3x2 rhs) => (long3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, uint3x2 rhs) => new long3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, uint3x2 rhs) => new long3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, uint3x2 rhs) => new long3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, uint3x2 rhs) => new long3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, uint3x2 rhs) => new long3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs + (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs - (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs * (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs / (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs % (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs + (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs - (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs * (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs / (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs % (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs + (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs - (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs * (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs / (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs % (float3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs + (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs - (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs * (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs / (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs % (double3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, byte rhs) => new long3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (byte lhs, long3x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, byte rhs) => new long3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (byte lhs, long3x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, byte rhs) => new long3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (byte lhs, long3x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, byte rhs) => new long3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (byte lhs, long3x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, byte rhs) => new long3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (byte lhs, long3x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, sbyte rhs) => new long3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (sbyte lhs, long3x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, sbyte rhs) => new long3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (sbyte lhs, long3x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, sbyte rhs) => new long3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (sbyte lhs, long3x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, sbyte rhs) => new long3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (sbyte lhs, long3x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, sbyte rhs) => new long3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (sbyte lhs, long3x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, short rhs) => new long3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (short lhs, long3x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, short rhs) => new long3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (short lhs, long3x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, short rhs) => new long3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (short lhs, long3x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, short rhs) => new long3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (short lhs, long3x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, short rhs) => new long3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (short lhs, long3x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, ushort rhs) => new long3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (ushort lhs, long3x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, ushort rhs) => new long3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (ushort lhs, long3x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, ushort rhs) => new long3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (ushort lhs, long3x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, ushort rhs) => new long3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (ushort lhs, long3x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, ushort rhs) => new long3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (ushort lhs, long3x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, int rhs) => new long3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (int lhs, long3x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, int rhs) => new long3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (int lhs, long3x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, int rhs) => new long3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (int lhs, long3x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, int rhs) => new long3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (int lhs, long3x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, int rhs) => new long3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (int lhs, long3x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (long3x2 lhs, uint rhs) => new long3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator + (uint lhs, long3x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (long3x2 lhs, uint rhs) => new long3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator - (uint lhs, long3x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (long3x2 lhs, uint rhs) => new long3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator * (uint lhs, long3x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (long3x2 lhs, uint rhs) => new long3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator / (uint lhs, long3x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (long3x2 lhs, uint rhs) => new long3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator % (uint lhs, long3x2 rhs) => (long)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ~ (long3x2 val) => new long3x2 { c0 = ~val.c0, c1 = ~val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator << (long3x2 val, int n) => new long3x2 { c0 = val.c0 << n, c1 = val.c1 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator >> (long3x2 val, int n) => new long3x2 { c0 = val.c0 >> n, c1 = val.c1 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, long3x2 rhs) => new long3x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, long rhs) => new long3x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long lhs, long3x2 rhs) => new long3x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, long3x2 rhs) => new long3x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, long rhs) => new long3x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long lhs, long3x2 rhs) => new long3x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, long3x2 rhs) => new long3x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, long rhs) => new long3x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long lhs, long3x2 rhs) => new long3x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, byte3x2 rhs) => lhs & (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, byte3x2 rhs) => lhs | (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, byte3x2 rhs) => lhs ^ (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, sbyte3x2 rhs) => lhs & (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, sbyte3x2 rhs) => lhs | (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, sbyte3x2 rhs) => lhs ^ (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, short3x2 rhs) => lhs & (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, short3x2 rhs) => lhs | (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, short3x2 rhs) => lhs ^ (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (short3x2 lhs, long3x2 rhs) => (long3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (short3x2 lhs, long3x2 rhs) => (long3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (short3x2 lhs, long3x2 rhs) => (long3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, ushort3x2 rhs) => lhs & (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, ushort3x2 rhs) => lhs | (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, ushort3x2 rhs) => lhs ^ (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, int3x2 rhs) => lhs & (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, int3x2 rhs) => lhs | (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, int3x2 rhs) => lhs ^ (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (int3x2 lhs, long3x2 rhs) => (long3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (int3x2 lhs, long3x2 rhs) => (long3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (int3x2 lhs, long3x2 rhs) => (long3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, uint3x2 rhs) => lhs & (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, uint3x2 rhs) => lhs | (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, uint3x2 rhs) => lhs ^ (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs & (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs | (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs ^ (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs & (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs | (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs ^ (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, byte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (byte lhs, long3x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, byte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (byte lhs, long3x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, byte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (byte lhs, long3x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, sbyte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (sbyte lhs, long3x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, sbyte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (sbyte lhs, long3x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, sbyte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (sbyte lhs, long3x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, short rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (short lhs, long3x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, short rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (short lhs, long3x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, short rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (short lhs, long3x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, ushort rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (ushort lhs, long3x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, ushort rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (ushort lhs, long3x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, ushort rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (ushort lhs, long3x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, int rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (int lhs, long3x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, int rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (int lhs, long3x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, int rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (int lhs, long3x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (long3x2 lhs, uint rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator & (uint lhs, long3x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (long3x2 lhs, uint rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator | (uint lhs, long3x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (long3x2 lhs, uint rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 operator ^ (uint lhs, long3x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, long rhs) => new mask64x3x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, long rhs) => new mask64x3x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, long rhs) => new mask64x3x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, long rhs) => new mask64x3x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, long rhs) => new mask64x3x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, long rhs) => new mask64x3x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long lhs, long3x2 rhs) => new mask64x3x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, byte3x2 rhs) => lhs == (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, byte3x2 rhs) => lhs != (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, byte3x2 rhs) => lhs < (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, byte3x2 rhs) => lhs > (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, byte3x2 rhs) => lhs <= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, byte3x2 rhs) => lhs >= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (byte3x2 lhs, long3x2 rhs) => (long3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, sbyte3x2 rhs) => lhs == (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, sbyte3x2 rhs) => lhs != (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, sbyte3x2 rhs) => lhs < (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, sbyte3x2 rhs) => lhs > (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, sbyte3x2 rhs) => lhs <= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, sbyte3x2 rhs) => lhs >= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (sbyte3x2 lhs, long3x2 rhs) => (long3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, short3x2 rhs) => lhs == (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, short3x2 rhs) => lhs != (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, short3x2 rhs) => lhs < (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, short3x2 rhs) => lhs > (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, short3x2 rhs) => lhs <= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, short3x2 rhs) => lhs >= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (short3x2 lhs, long3x2 rhs) => (long3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (short3x2 lhs, long3x2 rhs) => (long3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (short3x2 lhs, long3x2 rhs) => (long3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (short3x2 lhs, long3x2 rhs) => (long3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (short3x2 lhs, long3x2 rhs) => (long3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (short3x2 lhs, long3x2 rhs) => (long3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, ushort3x2 rhs) => lhs == (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, ushort3x2 rhs) => lhs != (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, ushort3x2 rhs) => lhs < (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, ushort3x2 rhs) => lhs > (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, ushort3x2 rhs) => lhs <= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, ushort3x2 rhs) => lhs >= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ushort3x2 lhs, long3x2 rhs) => (long3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, int3x2 rhs) => lhs == (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, int3x2 rhs) => lhs != (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, int3x2 rhs) => lhs < (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, int3x2 rhs) => lhs > (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, int3x2 rhs) => lhs <= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, int3x2 rhs) => lhs >= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (int3x2 lhs, long3x2 rhs) => (long3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (int3x2 lhs, long3x2 rhs) => (long3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (int3x2 lhs, long3x2 rhs) => (long3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (int3x2 lhs, long3x2 rhs) => (long3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (int3x2 lhs, long3x2 rhs) => (long3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (int3x2 lhs, long3x2 rhs) => (long3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, uint3x2 rhs) => lhs == (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, uint3x2 rhs) => lhs != (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, uint3x2 rhs) => lhs < (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, uint3x2 rhs) => lhs > (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, uint3x2 rhs) => lhs <= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, uint3x2 rhs) => lhs >= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (uint3x2 lhs, long3x2 rhs) => (long3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs == (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs != (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs < (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs > (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs <= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs >= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (Unity.Mathematics.int3x2 lhs, long3x2 rhs) => (long3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs == (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs != (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs < (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs > (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs <= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs >= (long3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (Unity.Mathematics.uint3x2 lhs, long3x2 rhs) => (long3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs == (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs != (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs < (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs > (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs <= (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (long3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs >= (float3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (Unity.Mathematics.float3x2 lhs, long3x2 rhs) => (float3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs == (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs != (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs < (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs > (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs <= (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs >= (double3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (Unity.Mathematics.double3x2 lhs, long3x2 rhs) => (double3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, byte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (byte lhs, long3x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, byte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (byte lhs, long3x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, byte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (byte lhs, long3x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, byte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (byte lhs, long3x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, byte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (byte lhs, long3x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, byte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (byte lhs, long3x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, sbyte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (sbyte lhs, long3x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, sbyte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (sbyte lhs, long3x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, sbyte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (sbyte lhs, long3x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, sbyte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (sbyte lhs, long3x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, sbyte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (sbyte lhs, long3x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, sbyte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (sbyte lhs, long3x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, short rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (short lhs, long3x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, short rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (short lhs, long3x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, short rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (short lhs, long3x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, short rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (short lhs, long3x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, short rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (short lhs, long3x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, short rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (short lhs, long3x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, ushort rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ushort lhs, long3x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, ushort rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ushort lhs, long3x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, ushort rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ushort lhs, long3x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, ushort rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ushort lhs, long3x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, ushort rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ushort lhs, long3x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, ushort rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ushort lhs, long3x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, int rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (int lhs, long3x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, int rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (int lhs, long3x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, int rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (int lhs, long3x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, int rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (int lhs, long3x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, int rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (int lhs, long3x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, int rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (int lhs, long3x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (long3x2 lhs, uint rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (uint lhs, long3x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (long3x2 lhs, uint rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (uint lhs, long3x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (long3x2 lhs, uint rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (uint lhs, long3x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (long3x2 lhs, uint rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (uint lhs, long3x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (long3x2 lhs, uint rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (uint lhs, long3x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (long3x2 lhs, uint rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (uint lhs, long3x2 rhs) => (long)lhs >= rhs;


        public ref long3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (long3x2* array = &this) { return ref ((long3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long3x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        public override readonly bool Equals(object obj) => obj is long3x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"long3x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long3x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)})";
    }
}