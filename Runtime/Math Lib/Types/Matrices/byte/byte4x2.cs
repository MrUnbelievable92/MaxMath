using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct byte4x2 : IEquatable<byte4x2>, IFormattable
    {
        public byte4 c0;
        public byte4 c1;

        public static byte4x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(byte4 c0, byte4 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(byte m00, byte m01,
                       byte m10, byte m11,
                       byte m20, byte m21,
                       byte m30, byte m31)
        {
            this.c0 = new byte4(m00, m10, m20, m30);
            this.c1 = new byte4(m01, m11, m21, m31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(bool v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(bool4x2 v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(mask8x4x2 v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(mask16x4x2 v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(mask32x4x2 v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(mask64x4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(sbyte v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(sbyte4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(byte v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(byte4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(ushort v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(ushort4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(short v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(short4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(uint v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(uint4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(int v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(int4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(long v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(long4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(ulong v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(ulong4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(UInt128 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(Int128 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(quarter v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(half v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(float v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(float4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(double v)
        {
            this = (byte4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(double4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(quadruple v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(Unity.Mathematics.bool4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(Unity.Mathematics.uint4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(Unity.Mathematics.int4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(Unity.Mathematics.half v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(Unity.Mathematics.float4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x2(Unity.Mathematics.double4x2 v)
        {
            this = (byte4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(UInt128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(Int128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(quarter x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(quadruple x) => (byte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x2(byte4x2 v) => new bool4x2 { c0 = (bool4)v.c0, c1 = (bool4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(Unity.Mathematics.bool4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x2(byte4x2 v) => new Unity.Mathematics.bool4x2 { c0 = (bool4)v.c0, c1 = (bool4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(Unity.Mathematics.int4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int4x2(byte4x2 v) => new int4x2 { c0 = (int4)v.c0, c1 = (int4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(Unity.Mathematics.uint4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint4x2(byte4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(Unity.Mathematics.half v) => (byte4x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(Unity.Mathematics.float4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x2(byte4x2 v) => new float4x2 { c0 = (float4)v.c0, c1 = (float4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(Unity.Mathematics.double4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x2(byte4x2 v) => new double4x2 { c0 = (double4)v.c0, c1 = (double4)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4x2(byte v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(bool v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(bool4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(short v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(short4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(int v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(int4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(long v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(long4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(sbyte v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(sbyte4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(ushort v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(ushort4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(uint v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(uint4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(ulong v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(ulong4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(half v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(float v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(float4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(double v) => new byte4x2 { c0 = (byte4)v, c1 = (byte4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(double4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(mask8x4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(mask16x4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(mask32x4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x2(mask64x4x2 v) => new byte4x2 { c0 = (byte4)v.c0, c1 = (byte4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x2(byte4x2 v) => new mask8x4x2 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x2(byte4x2 v) => new mask16x4x2 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(byte4x2 v) => new mask32x4x2 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x2(byte4x2 v) => new mask64x4x2 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator ++ (byte4x2 val) => new byte4x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator -- (byte4x2 val) => new byte4x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator + (byte4x2 lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator + (byte4x2 lhs, byte rhs) => new byte4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator + (byte lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator - (byte4x2 lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator - (byte4x2 lhs, byte rhs) => new byte4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator - (byte lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator * (byte4x2 lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator * (byte4x2 lhs, byte rhs) => new byte4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator * (byte lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator / (byte4x2 lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator / (byte4x2 lhs, byte rhs) => new byte4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator / (byte lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator % (byte4x2 lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator % (byte4x2 lhs, byte rhs) => new byte4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator % (byte lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator + (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs + (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator - (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs - (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator * (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs * (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator / (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs / (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator % (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs % (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator + (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator - (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator * (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator / (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator % (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs + (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs - (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs * (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs / (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs % (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator + (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs + (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator - (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs - (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator * (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs * (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator / (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs / (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator % (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs % (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator + (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator - (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator * (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator / (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator % (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator + (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs + (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator - (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs - (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator * (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs * (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator / (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs / (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator % (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs % (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator + (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator - (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator * (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator / (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator % (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator ~ (byte4x2 val) => new byte4x2 { c0 = ~val.c0, c1 = ~val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator << (byte4x2 val, int n) => new byte4x2 { c0 = val.c0 << n, c1 = val.c1 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator >> (byte4x2 val, int n) => new byte4x2 { c0 = val.c0 >> n, c1 = val.c1 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator & (byte4x2 lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator & (byte4x2 lhs, byte rhs) => new byte4x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator & (byte lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator | (byte4x2 lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator | (byte4x2 lhs, byte rhs) => new byte4x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator | (byte lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator ^ (byte4x2 lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator ^ (byte4x2 lhs, byte rhs) => new byte4x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 operator ^ (byte lhs, byte4x2 rhs) => new byte4x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator & (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs & (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator | (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs | (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator ^ (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs ^ (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator & (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator | (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 operator ^ (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs & (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs | (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs ^ (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator == (byte4x2 lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator == (byte4x2 lhs, byte rhs) => new mask8x4x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator == (byte lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator != (byte4x2 lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator != (byte4x2 lhs, byte rhs) => new mask8x4x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator != (byte lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator < (byte4x2 lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator < (byte4x2 lhs, byte rhs) => new mask8x4x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator < (byte lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator > (byte4x2 lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator > (byte4x2 lhs, byte rhs) => new mask8x4x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator > (byte lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator <= (byte4x2 lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator <= (byte4x2 lhs, byte rhs) => new mask8x4x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator <= (byte lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator >= (byte4x2 lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator >= (byte4x2 lhs, byte rhs) => new mask8x4x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x2 operator >= (byte lhs, byte4x2 rhs) => new mask8x4x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs == (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs != (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs < (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs > (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs <= (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (byte4x2 lhs, Unity.Mathematics.int4x2 rhs) => lhs >= (int4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (Unity.Mathematics.int4x2 lhs, byte4x2 rhs) => (int4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs == (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs != (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs < (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs > (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs <= (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (byte4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs >= (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (Unity.Mathematics.uint4x2 lhs, byte4x2 rhs) => (uint4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs == (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs != (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs < (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs > (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs <= (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (byte4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs >= (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (Unity.Mathematics.float4x2 lhs, byte4x2 rhs) => (float4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs == (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs != (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs < (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs > (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs <= (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (byte4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs >= (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (Unity.Mathematics.double4x2 lhs, byte4x2 rhs) => (double4x2)lhs >= rhs;


        public ref byte4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (byte4x2* array = &this) { return ref ((byte4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        public override readonly bool Equals(object obj) => obj is byte4x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"byte4x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z},  {c0.w}, {c1.w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"byte4x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)})";
    }
}