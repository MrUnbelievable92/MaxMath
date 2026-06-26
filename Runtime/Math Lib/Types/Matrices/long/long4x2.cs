using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct long4x2 : IEquatable<long4x2>, IFormattable
    {
        public long4 c0;
        public long4 c1;

        public static long4x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(long4 c0, long4 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(long m00, long m01,
                       long m10, long m11,
                       long m20, long m21,
                       long m30, long m31)
        {
            this.c0 = new long4(m00, m10, m20, m30);
            this.c1 = new long4(m01, m11, m21, m31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(bool v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(bool4x2 v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(mask8x4x2 v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(mask16x4x2 v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(mask32x4x2 v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(mask64x4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(byte v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(byte4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(sbyte v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(sbyte4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(ushort v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(ushort4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(short v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(short4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(uint v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(uint4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(int v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(int4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(ulong v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(ulong4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(long v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(long4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(UInt128 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(Int128 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(quarter v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(half v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(float v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(float4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(double v)
        {
            this = (long4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(double4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(quadruple v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(Unity.Mathematics.bool4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(Unity.Mathematics.uint4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(Unity.Mathematics.int4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(Unity.Mathematics.half v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(Unity.Mathematics.float4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x2(Unity.Mathematics.double4x2 v)
        {
            this = (long4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(UInt128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(Int128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(quarter x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(quadruple x) => (long)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x2(long4x2 v) => new bool4x2 { c0 = (bool4)v.c0, c1 = (bool4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(Unity.Mathematics.bool4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x2(long4x2 v) => new Unity.Mathematics.bool4x2 { c0 = (bool4)v.c0, c1 = (bool4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(Unity.Mathematics.int4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x2(long4x2 v) => new int4x2 { c0 = (int4)v.c0, c1 = (int4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(Unity.Mathematics.uint4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x2(long4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(Unity.Mathematics.half v) => (long4x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(Unity.Mathematics.float4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x2(long4x2 v) => new float4x2 { c0 = (float4)v.c0, c1 = (float4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(Unity.Mathematics.double4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x2(long4x2 v) => new double4x2 { c0 = (double4)v.c0, c1 = (double4)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(long v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(bool v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(bool4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4x2(sbyte v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(sbyte4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4x2(short v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(short4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(int v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(int4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4x2(byte v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(byte4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4x2(ushort v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(ushort4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(uint v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(uint4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(ulong v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(ulong4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(half v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(float v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(float4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(double v) => new long4x2 { c0 = (long4)v, c1 = (long4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(double4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(mask8x4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(mask16x4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(mask32x4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x2(mask64x4x2 v) => new long4x2 { c0 = (long4)v.c0, c1 = (long4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x2(long4x2 v) => new mask8x4x2 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x2(long4x2 v) => new mask16x4x2 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(long4x2 v) => new mask32x4x2 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x2(long4x2 v) => new mask64x4x2 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 val) => new long4x2 { c0 = -val.c0, c1 = -val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ++ (long4x2 val) => new long4x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator -- (long4x2 val) => new long4x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, long4x2 rhs) => new long4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, long rhs) => new long4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long lhs, long4x2 rhs) => new long4x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, long4x2 rhs) => new long4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, long rhs) => new long4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long lhs, long4x2 rhs) => new long4x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, long4x2 rhs) => new long4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, long rhs) => new long4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long lhs, long4x2 rhs) => new long4x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, long4x2 rhs) => new long4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, long rhs) => new long4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long lhs, long4x2 rhs) => new long4x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, long4x2 rhs) => new long4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, long rhs) => new long4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long lhs, long4x2 rhs) => new long4x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, byte4x2 rhs) => new long4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, byte4x2 rhs) => new long4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, byte4x2 rhs) => new long4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, byte4x2 rhs) => new long4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, byte4x2 rhs) => new long4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, sbyte4x2 rhs) => new long4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, sbyte4x2 rhs) => new long4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, sbyte4x2 rhs) => new long4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, sbyte4x2 rhs) => new long4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, sbyte4x2 rhs) => new long4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, short4x2 rhs) => new long4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, short4x2 rhs) => new long4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, short4x2 rhs) => new long4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, short4x2 rhs) => new long4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, short4x2 rhs) => new long4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (short4x2 lhs, long4x2 rhs) => (long4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (short4x2 lhs, long4x2 rhs) => (long4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (short4x2 lhs, long4x2 rhs) => (long4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (short4x2 lhs, long4x2 rhs) => (long4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (short4x2 lhs, long4x2 rhs) => (long4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, ushort4x2 rhs) => new long4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, ushort4x2 rhs) => new long4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, ushort4x2 rhs) => new long4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, ushort4x2 rhs) => new long4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, ushort4x2 rhs) => new long4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, int4x2 rhs) => new long4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, int4x2 rhs) => new long4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, int4x2 rhs) => new long4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, int4x2 rhs) => new long4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, int4x2 rhs) => new long4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (int4x2 lhs, long4x2 rhs) => (long4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (int4x2 lhs, long4x2 rhs) => (long4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (int4x2 lhs, long4x2 rhs) => (long4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (int4x2 lhs, long4x2 rhs) => (long4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (int4x2 lhs, long4x2 rhs) => (long4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, uint4x2 rhs) => new long4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, uint4x2 rhs) => new long4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, uint4x2 rhs) => new long4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, uint4x2 rhs) => new long4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, uint4x2 rhs) => new long4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs + (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs - (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs * (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs / (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs % (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs + (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs - (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs * (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs / (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs % (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator + (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs + (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator - (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs - (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator * (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs * (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator / (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs / (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator % (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs % (float4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator + (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator - (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator * (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator / (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator % (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator + (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs + (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator - (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs - (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator * (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs * (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator / (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs / (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator % (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs % (double4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator + (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator - (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator * (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator / (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator % (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, byte rhs) => new long4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (byte lhs, long4x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, byte rhs) => new long4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (byte lhs, long4x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, byte rhs) => new long4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (byte lhs, long4x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, byte rhs) => new long4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (byte lhs, long4x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, byte rhs) => new long4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (byte lhs, long4x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, sbyte rhs) => new long4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (sbyte lhs, long4x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, sbyte rhs) => new long4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (sbyte lhs, long4x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, sbyte rhs) => new long4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (sbyte lhs, long4x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, sbyte rhs) => new long4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (sbyte lhs, long4x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, sbyte rhs) => new long4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (sbyte lhs, long4x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, short rhs) => new long4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (short lhs, long4x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, short rhs) => new long4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (short lhs, long4x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, short rhs) => new long4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (short lhs, long4x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, short rhs) => new long4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (short lhs, long4x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, short rhs) => new long4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (short lhs, long4x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, ushort rhs) => new long4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (ushort lhs, long4x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, ushort rhs) => new long4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (ushort lhs, long4x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, ushort rhs) => new long4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (ushort lhs, long4x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, ushort rhs) => new long4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (ushort lhs, long4x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, ushort rhs) => new long4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (ushort lhs, long4x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, int rhs) => new long4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (int lhs, long4x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, int rhs) => new long4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (int lhs, long4x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, int rhs) => new long4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (int lhs, long4x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, int rhs) => new long4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (int lhs, long4x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, int rhs) => new long4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (int lhs, long4x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (long4x2 lhs, uint rhs) => new long4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator + (uint lhs, long4x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (long4x2 lhs, uint rhs) => new long4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator - (uint lhs, long4x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (long4x2 lhs, uint rhs) => new long4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator * (uint lhs, long4x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (long4x2 lhs, uint rhs) => new long4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator / (uint lhs, long4x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (long4x2 lhs, uint rhs) => new long4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator % (uint lhs, long4x2 rhs) => (long)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ~ (long4x2 val) => new long4x2 { c0 = ~val.c0, c1 = ~val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator << (long4x2 val, int n) => new long4x2 { c0 = val.c0 << n, c1 = val.c1 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator >> (long4x2 val, int n) => new long4x2 { c0 = val.c0 >> n, c1 = val.c1 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, long4x2 rhs) => new long4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, long rhs) => new long4x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long lhs, long4x2 rhs) => new long4x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, long4x2 rhs) => new long4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, long rhs) => new long4x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long lhs, long4x2 rhs) => new long4x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, long4x2 rhs) => new long4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, long rhs) => new long4x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long lhs, long4x2 rhs) => new long4x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, byte4x2 rhs) => lhs & (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, byte4x2 rhs) => lhs | (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, byte4x2 rhs) => lhs ^ (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, sbyte4x2 rhs) => lhs & (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, sbyte4x2 rhs) => lhs | (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, sbyte4x2 rhs) => lhs ^ (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, short4x2 rhs) => lhs & (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, short4x2 rhs) => lhs | (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, short4x2 rhs) => lhs ^ (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (short4x2 lhs, long4x2 rhs) => (long4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (short4x2 lhs, long4x2 rhs) => (long4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (short4x2 lhs, long4x2 rhs) => (long4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, ushort4x2 rhs) => lhs & (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, ushort4x2 rhs) => lhs | (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, ushort4x2 rhs) => lhs ^ (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, int4x2 rhs) => lhs & (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, int4x2 rhs) => lhs | (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, int4x2 rhs) => lhs ^ (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (int4x2 lhs, long4x2 rhs) => (long4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (int4x2 lhs, long4x2 rhs) => (long4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (int4x2 lhs, long4x2 rhs) => (long4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, uint4x2 rhs) => lhs & (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, uint4x2 rhs) => lhs | (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, uint4x2 rhs) => lhs ^ (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs & (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs | (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs ^ (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs & (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs | (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs ^ (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, byte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (byte lhs, long4x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, byte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (byte lhs, long4x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, byte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (byte lhs, long4x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, sbyte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (sbyte lhs, long4x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, sbyte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (sbyte lhs, long4x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, sbyte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (sbyte lhs, long4x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, short rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (short lhs, long4x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, short rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (short lhs, long4x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, short rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (short lhs, long4x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, ushort rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (ushort lhs, long4x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, ushort rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (ushort lhs, long4x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, ushort rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (ushort lhs, long4x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, int rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (int lhs, long4x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, int rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (int lhs, long4x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, int rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (int lhs, long4x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (long4x2 lhs, uint rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator & (uint lhs, long4x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (long4x2 lhs, uint rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator | (uint lhs, long4x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (long4x2 lhs, uint rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 operator ^ (uint lhs, long4x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, long rhs) => new mask64x4x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, long rhs) => new mask64x4x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, long rhs) => new mask64x4x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, long rhs) => new mask64x4x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, long rhs) => new mask64x4x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, long rhs) => new mask64x4x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long lhs, long4x2 rhs) => new mask64x4x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, byte4x2 rhs) => lhs == (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, byte4x2 rhs) => lhs != (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, byte4x2 rhs) => lhs < (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, byte4x2 rhs) => lhs > (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, byte4x2 rhs) => lhs <= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, byte4x2 rhs) => lhs >= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (byte4x2 lhs, long4x2 rhs) => (long4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, sbyte4x2 rhs) => lhs == (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, sbyte4x2 rhs) => lhs != (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, sbyte4x2 rhs) => lhs < (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, sbyte4x2 rhs) => lhs > (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, sbyte4x2 rhs) => lhs <= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, sbyte4x2 rhs) => lhs >= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (sbyte4x2 lhs, long4x2 rhs) => (long4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, short4x2 rhs) => lhs == (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, short4x2 rhs) => lhs != (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, short4x2 rhs) => lhs < (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, short4x2 rhs) => lhs > (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, short4x2 rhs) => lhs <= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, short4x2 rhs) => lhs >= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (short4x2 lhs, long4x2 rhs) => (long4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (short4x2 lhs, long4x2 rhs) => (long4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (short4x2 lhs, long4x2 rhs) => (long4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (short4x2 lhs, long4x2 rhs) => (long4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (short4x2 lhs, long4x2 rhs) => (long4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (short4x2 lhs, long4x2 rhs) => (long4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, ushort4x2 rhs) => lhs == (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, ushort4x2 rhs) => lhs != (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, ushort4x2 rhs) => lhs < (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, ushort4x2 rhs) => lhs > (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, ushort4x2 rhs) => lhs <= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, ushort4x2 rhs) => lhs >= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (ushort4x2 lhs, long4x2 rhs) => (long4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, int4x2 rhs) => lhs == (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, int4x2 rhs) => lhs != (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, int4x2 rhs) => lhs < (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, int4x2 rhs) => lhs > (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, int4x2 rhs) => lhs <= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, int4x2 rhs) => lhs >= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (int4x2 lhs, long4x2 rhs) => (long4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (int4x2 lhs, long4x2 rhs) => (long4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (int4x2 lhs, long4x2 rhs) => (long4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (int4x2 lhs, long4x2 rhs) => (long4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (int4x2 lhs, long4x2 rhs) => (long4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (int4x2 lhs, long4x2 rhs) => (long4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, uint4x2 rhs) => lhs == (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, uint4x2 rhs) => lhs != (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, uint4x2 rhs) => lhs < (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, uint4x2 rhs) => lhs > (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, uint4x2 rhs) => lhs <= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, uint4x2 rhs) => lhs >= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (uint4x2 lhs, long4x2 rhs) => (long4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs == (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs != (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs < (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs > (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs <= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs >= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (Unity.Mathematics.int4x2 lhs, long4x2 rhs) => (long4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs == (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs != (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs < (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs > (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs <= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs >= (long4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (Unity.Mathematics.uint4x2 lhs, long4x2 rhs) => (long4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs == (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs != (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs < (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs > (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs <= (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (long4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs >= (float4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (Unity.Mathematics.float4x2 lhs, long4x2 rhs) => (float4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs == (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs != (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs < (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs > (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs <= (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs >= (double4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (Unity.Mathematics.double4x2 lhs, long4x2 rhs) => (double4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, byte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (byte lhs, long4x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, byte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (byte lhs, long4x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, byte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (byte lhs, long4x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, byte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (byte lhs, long4x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, byte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (byte lhs, long4x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, byte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (byte lhs, long4x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, sbyte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (sbyte lhs, long4x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, sbyte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (sbyte lhs, long4x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, sbyte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (sbyte lhs, long4x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, sbyte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (sbyte lhs, long4x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, sbyte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (sbyte lhs, long4x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, sbyte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (sbyte lhs, long4x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, short rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (short lhs, long4x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, short rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (short lhs, long4x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, short rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (short lhs, long4x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, short rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (short lhs, long4x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, short rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (short lhs, long4x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, short rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (short lhs, long4x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, ushort rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (ushort lhs, long4x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, ushort rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (ushort lhs, long4x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, ushort rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (ushort lhs, long4x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, ushort rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (ushort lhs, long4x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, ushort rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (ushort lhs, long4x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, ushort rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (ushort lhs, long4x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, int rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (int lhs, long4x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, int rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (int lhs, long4x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, int rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (int lhs, long4x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, int rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (int lhs, long4x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, int rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (int lhs, long4x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, int rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (int lhs, long4x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (long4x2 lhs, uint rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (uint lhs, long4x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (long4x2 lhs, uint rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (uint lhs, long4x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (long4x2 lhs, uint rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (uint lhs, long4x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (long4x2 lhs, uint rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (uint lhs, long4x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (long4x2 lhs, uint rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (uint lhs, long4x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (long4x2 lhs, uint rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (uint lhs, long4x2 rhs) => (long)lhs >= rhs;


        public ref long4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (long4x2* array = &this) { return ref ((long4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        public override readonly bool Equals(object obj) => obj is long4x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"long4x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z},  {c0.w}, {c1.w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long4x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)})";
    }
}
