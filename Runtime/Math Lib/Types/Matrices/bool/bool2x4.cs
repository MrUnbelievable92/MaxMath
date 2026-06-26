using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool2x4 : IEquatable<bool2x4>, IEquatable<Unity.Mathematics.bool2x4>, IEquatable<bool>
    {
        public bool2 c0;
        public bool2 c1;
        public bool2 c2;
        public bool2 c3;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(bool2 c0, bool2 c1, bool2 c2, bool2 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(bool m00, bool m01, bool m02, bool m03,
                       bool m10, bool m11, bool m12, bool m13)
        {
            this.c0 = new bool2(m00, m10);
            this.c1 = new bool2(m01, m11);
            this.c2 = new bool2(m02, m12);
            this.c3 = new bool2(m03, m13);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(bool v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(bool2x4 v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(mask8x2x4 v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(mask16x2x4 v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(mask32x2x4 v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(mask64x2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(byte v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(byte2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(sbyte v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(sbyte2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(ushort v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(ushort2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(short v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(short2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(uint v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(uint2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(int v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(int2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(ulong v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(ulong2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(long v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(long2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(UInt128 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(Int128 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(quarter v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(half v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(float v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(float2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(double v)
        {
            this = (bool2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(double2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(quadruple v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(Unity.Mathematics.bool2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(Unity.Mathematics.uint2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(Unity.Mathematics.int2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(Unity.Mathematics.half v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(Unity.Mathematics.float2x4 v)
        {
            this = (bool2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x4(Unity.Mathematics.double2x4 v)
        {
            this = (bool2x4)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x4(Unity.Mathematics.bool2x4 v) => new bool2x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool2x4(bool2x4 v) => new Unity.Mathematics.bool2x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x4(bool v) => (Unity.Mathematics.bool2x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(byte v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(ushort v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(uint v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(ulong v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(UInt128 v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(sbyte v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(short v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(int v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(long v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(Int128 v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(quarter v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(half v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(float v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(double v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(quadruple v) => new bool2x4 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v, c3 = (bool2)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(Unity.Mathematics.half v) => (bool2x4)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(Unity.Mathematics.float2x4 v) => (bool2x4)(float2x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(Unity.Mathematics.double2x4 v) => (bool2x4)(double2x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(Unity.Mathematics.uint2x4 v) => (bool2x4)(uint2x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(Unity.Mathematics.int2x4 v) => (bool2x4)(int2x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2x4(bool2x4 v) => (float2x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double2x4(bool2x4 v) => (double2x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x4(bool2x4 v) => (uint2x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x4(bool2x4 v) => (int2x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator ! (bool2x4 val) => new bool2x4 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2, c3 = !val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator & (bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator & (bool2x4 lhs, bool rhs) => new bool2x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator & (bool lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator | (bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator | (bool2x4 lhs, bool rhs) => new bool2x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator | (bool lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator ^ (bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator ^ (bool2x4 lhs, bool rhs) => new bool2x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator ^ (bool lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator & (bool2x4 lhs, Unity.Mathematics.bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator | (bool2x4 lhs, Unity.Mathematics.bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator ^ (bool2x4 lhs, Unity.Mathematics.bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator & (Unity.Mathematics.bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator | (Unity.Mathematics.bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator ^ (Unity.Mathematics.bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator == (bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator == (bool2x4 lhs, bool rhs) => new bool2x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator == (bool lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator != (bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator != (bool2x4 lhs, bool rhs) => new bool2x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator != (bool lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator == (bool2x4 lhs, Unity.Mathematics.bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator != (bool2x4 lhs, Unity.Mathematics.bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator == (Unity.Mathematics.bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x4 operator != (Unity.Mathematics.bool2x4 lhs, bool2x4 rhs) => new bool2x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        public ref bool2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (bool2x4* array = &this) { return ref ((bool2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool2x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool2x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is bool2x4 converted && Equals(converted)) || (o is Unity.Mathematics.bool2x4 convertedU && Equals(convertedU)) || (o is bool convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool2x4)this).ToString();
    }
}
