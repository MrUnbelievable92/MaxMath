using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool4x3 : IEquatable<bool4x3>, IEquatable<Unity.Mathematics.bool4x3>, IEquatable<bool>
    {
        public bool4 c0;
        public bool4 c1;
        public bool4 c2;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(bool4 c0, bool4 c1, bool4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(bool m00, bool m01, bool m02,
                       bool m10, bool m11, bool m12,
                       bool m20, bool m21, bool m22,
                       bool m30, bool m31, bool m32)
        {
            this.c0 = new bool4(m00, m10, m20, m30);
            this.c1 = new bool4(m01, m11, m21, m31);
            this.c2 = new bool4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(bool v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(bool4x3 v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(mask8x4x3 v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(mask16x4x3 v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(mask32x4x3 v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(mask64x4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(byte v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(byte4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(sbyte v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(sbyte4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(ushort v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(ushort4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(short v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(short4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(uint v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(uint4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(int v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(int4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(ulong v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(ulong4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(long v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(long4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(UInt128 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(Int128 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(quarter v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(half v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(float v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(float4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(double v)
        {
            this = (bool4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(double4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(quadruple v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(Unity.Mathematics.bool4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(Unity.Mathematics.uint4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(Unity.Mathematics.int4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(Unity.Mathematics.half v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(Unity.Mathematics.float4x3 v)
        {
            this = (bool4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x3(Unity.Mathematics.double4x3 v)
        {
            this = (bool4x3)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4x3(Unity.Mathematics.bool4x3 v) => new bool4x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool4x3(bool4x3 v) => new Unity.Mathematics.bool4x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4x3(bool v) => (Unity.Mathematics.bool4x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(byte v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(ushort v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(uint v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(ulong v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(UInt128 v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(sbyte v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(short v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(int v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(long v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(Int128 v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(quarter v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(half v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(float v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(double v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(quadruple v) => new bool4x3 { c0 = (bool4)v, c1 = (bool4)v, c2 = (bool4)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(Unity.Mathematics.half v) => (bool4x3)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(Unity.Mathematics.float4x3 v) => (bool4x3)(float4x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(Unity.Mathematics.double4x3 v) => (bool4x3)(double4x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(Unity.Mathematics.uint4x3 v) => (bool4x3)(uint4x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(Unity.Mathematics.int4x3 v) => (bool4x3)(int4x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4x3(bool4x3 v) => (float4x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double4x3(bool4x3 v) => (double4x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x3(bool4x3 v) => (uint4x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x3(bool4x3 v) => (int4x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator ! (bool4x3 val) => new bool4x3 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator & (bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator & (bool4x3 lhs, bool rhs) => new bool4x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator & (bool lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator | (bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator | (bool4x3 lhs, bool rhs) => new bool4x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator | (bool lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator ^ (bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator ^ (bool4x3 lhs, bool rhs) => new bool4x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator ^ (bool lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator & (bool4x3 lhs, Unity.Mathematics.bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator | (bool4x3 lhs, Unity.Mathematics.bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator ^ (bool4x3 lhs, Unity.Mathematics.bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator & (Unity.Mathematics.bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator | (Unity.Mathematics.bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator ^ (Unity.Mathematics.bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator == (bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator == (bool4x3 lhs, bool rhs) => new bool4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator == (bool lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator != (bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator != (bool4x3 lhs, bool rhs) => new bool4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator != (bool lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator == (bool4x3 lhs, Unity.Mathematics.bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator != (bool4x3 lhs, Unity.Mathematics.bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator == (Unity.Mathematics.bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4x3 operator != (Unity.Mathematics.bool4x3 lhs, bool4x3 rhs) => new bool4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        public ref bool4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (bool4x3* array = &this) { return ref ((bool4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool4x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool4x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        
        public override readonly bool Equals(object o) => (o is bool4x3 converted && Equals(converted)) || (o is Unity.Mathematics.bool4x3 convertedU && Equals(convertedU)) || (o is bool convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool4x3)this).ToString();
    }
}
