using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 32)]
    unsafe public struct ulong2x2 : IEquatable<ulong2x2>, IFormattable
    {
        public ulong2 c0;
        public ulong2 c1;


        public static ulong2x2 identity => new ulong2x2(1, 0,   0, 1);

        public static ulong2x2 zero => default(ulong2x2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x2(ulong2 c0, ulong2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x2(ulong m00, ulong m01,
                        ulong m10, ulong m11)
        {
            this.c0 = new ulong2(m00, m10);
            this.c1 = new ulong2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x2(ulong v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x2(ulong v) => new ulong2x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x2(long2x2 input) => new ulong2x2((ulong2)input.c0, (ulong2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x2(float2x2 input) => new ulong2x2((ulong2)input.c0, (ulong2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x2(double2x2 input) => new ulong2x2((ulong2)input.c0, (ulong2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(ulong2x2 input) => new float2x2((float2)input.c0, (float2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(ulong2x2 input) => new double2x2((double2)input.c0, (double2)input.c1);


        public ref ulong2 this[[AssumeRange(0, 1)] int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((ulong2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator + (ulong2x2 lhs, ulong2x2 rhs) => new ulong2x2 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator - (ulong2x2 lhs, ulong2x2 rhs) => new ulong2x2 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator * (ulong2x2 lhs, ulong2x2 rhs) => new ulong2x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator / (ulong2x2 lhs, ulong2x2 rhs) => new ulong2x2 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator % (ulong2x2 lhs, ulong2x2 rhs) => new ulong2x2 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator * (ulong2x2 lhs, ulong rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator * (ulong lhs, ulong2x2 rhs) => new ulong2x2 (lhs * rhs.c0, lhs * rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator / (ulong2x2 lhs, ulong rhs) => new ulong2x2 (lhs.c0 / rhs, lhs.c1 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator % (ulong2x2 lhs, ulong rhs) => new ulong2x2 (lhs.c0 % rhs, lhs.c1 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator & (ulong2x2 lhs, ulong2x2 rhs) => new ulong2x2 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator | (ulong2x2 lhs, ulong2x2 rhs) => new ulong2x2 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator ^ (ulong2x2 lhs, ulong2x2 rhs) => new ulong2x2 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator ++ (ulong2x2 val) => new ulong2x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator -- (ulong2x2 val) => new ulong2x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator ~ (ulong2x2 val) => new ulong2x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator << (ulong2x2 x, int n) => new ulong2x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator >> (ulong2x2 x, int n) => new ulong2x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (ulong2x2 lhs, ulong2x2 rhs) => new bool2x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator < (ulong2x2 lhs, ulong2x2 rhs) => new bool2x2 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator > (ulong2x2 lhs, ulong2x2 rhs) => new bool2x2 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (ulong2x2 lhs, ulong2x2 rhs) => new bool2x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator <= (ulong2x2 lhs, ulong2x2 rhs) => new bool2x2 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator >= (ulong2x2 lhs, ulong2x2 rhs) => new bool2x2 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong2x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override bool Equals(object obj) => Equals((ulong2x2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override string ToString() => $"ulong2x2({c0.x}, {c1.x},  {c0.y}, {c1.y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong2x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)})";
    }
}