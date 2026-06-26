using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

#pragma warning disable CS0660
namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public ref struct mask32x2x3
    {
        public mask32x2 c0;
        public mask32x2 c1;
        public mask32x2 c2;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(mask32x2 c0, mask32x2 c1, mask32x2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(bool m00, bool m01, bool m02,
                          bool m10, bool m11, bool m12)
        {
            this.c0 = new mask32x2(m00, m10);
            this.c1 = new mask32x2(m01, m11);
            this.c2 = new mask32x2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(bool v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(bool2x3 v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(mask8x2x3 v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(mask16x2x3 v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(mask32x2x3 v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(mask64x2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(byte v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(byte2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(sbyte v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(sbyte2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(ushort v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(ushort2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(short v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(short2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(uint v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(uint2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(int v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(int2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(ulong v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(ulong2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(long v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(long2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(UInt128 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(Int128 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(quarter v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(half v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(float v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(float2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(double v)
        {
            this = (mask32x2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(double2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(quadruple v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(Unity.Mathematics.bool2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(Unity.Mathematics.uint2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(Unity.Mathematics.int2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(Unity.Mathematics.half v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(Unity.Mathematics.float2x3 v)
        {
            this = (mask32x2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x2x3(Unity.Mathematics.double2x3 v)
        {
            this = (mask32x2x3)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x2x3(mask64x2x3 v) => new mask32x2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask64x2x3(mask32x2x3 v) => new mask64x2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x2x3(Unity.Mathematics.bool2x3 v) => new mask32x2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool2x3(mask32x2x3 v) => new Unity.Mathematics.bool2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x2x3(bool2x3 v) => new mask32x2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x3(mask32x2x3 v) => new bool2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x2x3(bool v) => new mask32x2x3 { c0 = v, c1 = v, c2 = v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(byte v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(ushort v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(uint v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(ulong v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(UInt128 v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(sbyte v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(short v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(int v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(long v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(Int128 v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(quarter v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(half v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(float v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(double v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(quadruple v) => new mask32x2x3 { c0 = (mask32x2)v, c1 = (mask32x2)v, c2 = (mask32x2)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(Unity.Mathematics.half v) => (mask32x2x3)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(Unity.Mathematics.float2x3 v) => (mask32x2x3)(float2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(Unity.Mathematics.double2x3 v) => (mask32x2x3)(double2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(Unity.Mathematics.uint2x3 v) => (mask32x2x3)(uint2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(Unity.Mathematics.int2x3 v) => (mask32x2x3)(int2x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2x3(mask32x2x3 v) => (float2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double2x3(mask32x2x3 v) => (double2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x3(mask32x2x3 v) => (uint2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x3(mask32x2x3 v) => (int2x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator ! (mask32x2x3 val) => new mask32x2x3 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator & (mask32x2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator & (mask32x2x3 lhs, bool rhs) => new mask32x2x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator & (bool lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator | (mask32x2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator | (mask32x2x3 lhs, bool rhs) => new mask32x2x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator | (bool lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator ^ (mask32x2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator ^ (mask32x2x3 lhs, bool rhs) => new mask32x2x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator ^ (bool lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator & (mask32x2x3 lhs, mask64x2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator | (mask32x2x3 lhs, mask64x2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator ^ (mask32x2x3 lhs, mask64x2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator & (mask64x2x3 lhs, mask32x2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator | (mask64x2x3 lhs, mask32x2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator ^ (mask64x2x3 lhs, mask32x2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator & (mask32x2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator | (mask32x2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator ^ (mask32x2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator & (Unity.Mathematics.bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator | (Unity.Mathematics.bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator ^ (Unity.Mathematics.bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator & (mask32x2x3 lhs, bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator | (mask32x2x3 lhs, bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator ^ (mask32x2x3 lhs, bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator & (bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator | (bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator ^ (bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (mask32x2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (mask32x2x3 lhs, bool rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (bool lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (mask32x2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (mask32x2x3 lhs, bool rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (bool lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (mask32x2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (mask32x2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (mask32x2x3 lhs, bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (mask32x2x3 lhs, bool2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (bool2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (mask32x2x3 lhs, mask64x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (mask32x2x3 lhs, mask64x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (mask64x2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (mask64x2x3 lhs, mask32x2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        public ref mask32x2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (mask32x2x3* array = &this) { return ref ((mask32x2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask8x2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask16x2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask32x2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask64x2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool2x3)this).ToString();
    }
}
#pragma warning restore CS0660
