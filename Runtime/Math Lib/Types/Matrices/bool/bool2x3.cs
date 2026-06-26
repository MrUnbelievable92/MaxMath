using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool2x3 : IEquatable<bool2x3>, IEquatable<Unity.Mathematics.bool2x3>, IEquatable<bool>
    {
        public bool2 c0;
        public bool2 c1;
        public bool2 c2;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(bool2 c0, bool2 c1, bool2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(bool m00, bool m01, bool m02,
                       bool m10, bool m11, bool m12)
        {
            this.c0 = new bool2(m00, m10);
            this.c1 = new bool2(m01, m11);
            this.c2 = new bool2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(bool v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(bool2x3 v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(mask8x2x3 v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(mask16x2x3 v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(mask32x2x3 v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(mask64x2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(byte v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(byte2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(sbyte v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(sbyte2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(ushort v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(ushort2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(short v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(short2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(uint v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(uint2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(int v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(int2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(ulong v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(ulong2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(long v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(long2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(UInt128 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(Int128 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(quarter v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(half v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(float v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(float2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(double v)
        {
            this = (bool2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(double2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(quadruple v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(Unity.Mathematics.bool2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(Unity.Mathematics.uint2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(Unity.Mathematics.int2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(Unity.Mathematics.half v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(Unity.Mathematics.float2x3 v)
        {
            this = (bool2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(Unity.Mathematics.double2x3 v)
        {
            this = (bool2x3)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x3(Unity.Mathematics.bool2x3 v) => new bool2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool2x3(bool2x3 v) => new Unity.Mathematics.bool2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x3(bool v) => (Unity.Mathematics.bool2x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(byte v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(ushort v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(uint v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(ulong v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(UInt128 v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(sbyte v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(short v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(int v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(long v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(Int128 v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(quarter v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(half v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(float v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(double v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(quadruple v) => new bool2x3 { c0 = (bool2)v, c1 = (bool2)v, c2 = (bool2)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(Unity.Mathematics.half v) => (bool2x3)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(Unity.Mathematics.float2x3 v) => (bool2x3)(float2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(Unity.Mathematics.double2x3 v) => (bool2x3)(double2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(Unity.Mathematics.uint2x3 v) => (bool2x3)(uint2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(Unity.Mathematics.int2x3 v) => (bool2x3)(int2x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2x3(bool2x3 v) => (float2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double2x3(bool2x3 v) => (double2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x3(bool2x3 v) => (uint2x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x3(bool2x3 v) => (int2x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator ! (bool2x3 val) => new bool2x3 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator & (bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator & (bool2x3 lhs, bool rhs) => new bool2x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator & (bool lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator | (bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator | (bool2x3 lhs, bool rhs) => new bool2x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator | (bool lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator ^ (bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator ^ (bool2x3 lhs, bool rhs) => new bool2x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator ^ (bool lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator & (bool2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator | (bool2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator ^ (bool2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator & (Unity.Mathematics.bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator | (Unity.Mathematics.bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator ^ (Unity.Mathematics.bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator == (bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator == (bool2x3 lhs, bool rhs) => new bool2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator == (bool lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator != (bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator != (bool2x3 lhs, bool rhs) => new bool2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator != (bool lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator == (bool2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator != (bool2x3 lhs, Unity.Mathematics.bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator == (Unity.Mathematics.bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x3 operator != (Unity.Mathematics.bool2x3 lhs, bool2x3 rhs) => new bool2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        public ref bool2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (bool2x3* array = &this) { return ref ((bool2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        
        public override readonly bool Equals(object o) => (o is bool2x3 converted && Equals(converted)) || (o is Unity.Mathematics.bool2x3 convertedU && Equals(convertedU)) || (o is bool convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool2x3)this).ToString();
    }
}
