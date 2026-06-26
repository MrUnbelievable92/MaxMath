using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool4x4 : IEquatable<bool4x4>, IEquatable<Unity.Mathematics.bool4x4>, IEquatable<bool>
    {
        public bool4 c0;
        public bool4 c1;
        public bool4 c2;
        public bool4 c3;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(bool4 c0, bool4 c1, bool4 c2, bool4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(bool m00, bool m01, bool m02, bool m03,
                       bool m10, bool m11, bool m12, bool m13,
                       bool m20, bool m21, bool m22, bool m23,
                       bool m30, bool m31, bool m32, bool m33)
        {
            this.c0 = new bool4(m00, m10, m20, m30);
            this.c1 = new bool4(m01, m11, m21, m31);
            this.c2 = new bool4(m02, m12, m22, m32);
            this.c3 = new bool4(m03, m13, m23, m33);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(bool v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(bool4x4 v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(mask8x4x4 v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(mask16x4x4 v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(mask32x4x4 v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(mask64x4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(byte v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(byte4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(sbyte v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(sbyte4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(ushort v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(ushort4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(short v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(short4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(uint v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(uint4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(int v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(int4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(ulong v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(ulong4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(long v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(long4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(UInt128 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(Int128 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(quarter v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(half v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(float v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(float4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(double v)
        {
            this = (bool4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(double4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(quadruple v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(Unity.Mathematics.bool4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(Unity.Mathematics.uint4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(Unity.Mathematics.int4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(Unity.Mathematics.half v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(Unity.Mathematics.float4x4 v)
        {
            this = (bool4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(Unity.Mathematics.double4x4 v)
        {
            this = (bool4x4)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4x4(Unity.Mathematics.bool4x4 v) => new bool4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool4x4(bool4x4 v) => new Unity.Mathematics.bool4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4x4(bool v) => (Unity.Mathematics.bool4x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(byte v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(ushort v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(uint v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(ulong v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(UInt128 v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(sbyte v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(short v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(int v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(long v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(Int128 v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(quarter v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(half v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(float v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(double v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(quadruple v) => new bool4x4 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v, c3 = (bool4)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(Unity.Mathematics.half v) => (bool4x4)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(Unity.Mathematics.float4x4 v) => (bool4x4)(float4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(Unity.Mathematics.double4x4 v) => (bool4x4)(double4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(Unity.Mathematics.uint4x4 v) => (bool4x4)(uint4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(Unity.Mathematics.int4x4 v) => (bool4x4)(int4x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4x4(bool4x4 v) => (float4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double4x4(bool4x4 v) => (double4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x4(bool4x4 v) => (uint4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x4(bool4x4 v) => (int4x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator ! (bool4x4 val) => new bool4x4 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2, c3 = !val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator & (bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator & (bool4x4 lhs, bool rhs) => new bool4x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator & (bool lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator | (bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator | (bool4x4 lhs, bool rhs) => new bool4x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator | (bool lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator ^ (bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator ^ (bool4x4 lhs, bool rhs) => new bool4x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator ^ (bool lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator & (bool4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator | (bool4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator ^ (bool4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator & (Unity.Mathematics.bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator | (Unity.Mathematics.bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator ^ (Unity.Mathematics.bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator == (bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator == (bool4x4 lhs, bool rhs) => new bool4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator == (bool lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator != (bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator != (bool4x4 lhs, bool rhs) => new bool4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator != (bool lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator == (bool4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator != (bool4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator == (Unity.Mathematics.bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x4 operator != (Unity.Mathematics.bool4x4 lhs, bool4x4 rhs) => new bool4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        public ref bool4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (bool4x4* array = &this) { return ref ((bool4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is bool4x4 converted && Equals(converted)) || (o is Unity.Mathematics.bool4x4 convertedU && Equals(convertedU)) || (o is bool convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool4x4)this).ToString();
    }
}
