using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 48)]
    unsafe public struct ulong2x3 : IEquatable<ulong2x3>, IFormattable
    {
        public ulong2 c0;
        public ulong2 c1;
        public ulong2 c2;


        public static ulong2x3 zero => default(ulong2x3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ulong2 c0, ulong2 c1, ulong2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ulong m00, ulong m01, ulong m02,
                        ulong m10, ulong m11, ulong m12)
        {
            this.c0 = new ulong2(m00, m10);
            this.c1 = new ulong2(m01, m11);
            this.c2 = new ulong2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ulong v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x3(ulong v) => new ulong2x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(long2x3 input) => new ulong2x3((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(float2x3 input) => new ulong2x3((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(double2x3 input) => new ulong2x3((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(ulong2x3 input) => new float2x3((float2)input.c0, (float2)input.c1, (float2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x3(ulong2x3 input) => new double2x3((double2)input.c0, (double2)input.c1, (double2)input.c2);


        public ref ulong2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((ulong2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, ulong rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong lhs, ulong2x3 rhs) => new ulong2x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, ulong rhs) => new ulong2x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, ulong rhs) => new ulong2x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ++ (ulong2x3 val) => new ulong2x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator -- (ulong2x3 val) => new ulong2x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ~ (ulong2x3 val) => new ulong2x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator << (ulong2x3 x, int n) => new ulong2x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator >> (ulong2x3 x, int n) => new ulong2x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (ulong2x3 lhs, ulong2x3 rhs) => new bool2x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator < (ulong2x3 lhs, ulong2x3 rhs) => new bool2x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator > (ulong2x3 lhs, ulong2x3 rhs) => new bool2x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (ulong2x3 lhs, ulong2x3 rhs) => new bool2x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator <= (ulong2x3 lhs, ulong2x3 rhs) => new bool2x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator >= (ulong2x3 lhs, ulong2x3 rhs) => new bool2x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong2x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((ulong2x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode() ^ c2.GetHashCode();


        public override string ToString() => $"ulong2x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong2x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)})";
    }
}