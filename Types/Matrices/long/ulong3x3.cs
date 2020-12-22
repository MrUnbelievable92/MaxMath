using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 72)]
    unsafe public struct ulong3x3 : IEquatable<ulong3x3>, IFormattable
    {
        public ulong3 c0;
        public ulong3 c1;
        public ulong3 c2;


        public static ulong3x3 identity => new ulong3x3(1, 0, 0,   0, 1, 0,   0, 0, 1);

        public static ulong3x3 zero => default(ulong3x3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x3(ulong3 c0, ulong3 c1, ulong3 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x3(ulong m00, ulong m01, ulong m02,
                        ulong m10, ulong m11, ulong m12,
                        ulong m20, ulong m21, ulong m22)
        {
            this.c0 = new ulong3(m00, m10, m20);
            this.c1 = new ulong3(m01, m11, m21);
            this.c2 = new ulong3(m02, m12, m22);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x3(ulong v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x3(ulong v) => new ulong3x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x3(long3x3 input) => new ulong3x3((ulong3)input.c0, (ulong3)input.c1, (ulong3)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x3(float3x3 input) => new ulong3x3((ulong3)input.c0, (ulong3)input.c1, (ulong3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x3(double3x3 input) => new ulong3x3((ulong3)input.c0, (ulong3)input.c1, (ulong3)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x3(ulong3x3 input) => new float3x3((float3)input.c0, (float3)input.c1, (float3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(ulong3x3 input) => new double3x3((double3)input.c0, (double3)input.c1, (double3)input.c2);


        public ref ulong3 this[[AssumeRange(0, 2)] int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((ulong3*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator + (ulong3x3 lhs, ulong3x3 rhs) => new ulong3x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator - (ulong3x3 lhs, ulong3x3 rhs) => new ulong3x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator * (ulong3x3 lhs, ulong3x3 rhs) => new ulong3x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator / (ulong3x3 lhs, ulong3x3 rhs) => new ulong3x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator % (ulong3x3 lhs, ulong3x3 rhs) => new ulong3x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator * (ulong3x3 lhs, ulong rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator * (ulong lhs, ulong3x3 rhs) => new ulong3x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator / (ulong3x3 lhs, ulong rhs) => new ulong3x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator % (ulong3x3 lhs, ulong rhs) => new ulong3x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator & (ulong3x3 lhs, ulong3x3 rhs) => new ulong3x3 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator | (ulong3x3 lhs, ulong3x3 rhs) => new ulong3x3 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator ^ (ulong3x3 lhs, ulong3x3 rhs) => new ulong3x3 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator ++ (ulong3x3 val) => new ulong3x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator -- (ulong3x3 val) => new ulong3x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator ~ (ulong3x3 val) => new ulong3x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator << (ulong3x3 x, int n) => new ulong3x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 operator >> (ulong3x3 x, int n) => new ulong3x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (ulong3x3 lhs, ulong3x3 rhs) => new bool3x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (ulong3x3 lhs, ulong3x3 rhs) => new bool3x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (ulong3x3 lhs, ulong3x3 rhs) => new bool3x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (ulong3x3 lhs, ulong3x3 rhs) => new bool3x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (ulong3x3 lhs, ulong3x3 rhs) => new bool3x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (ulong3x3 lhs, ulong3x3 rhs) => new bool3x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong3x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((ulong3x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ (c2.GetHashCode() << 8);


        public override string ToString() => $"ulong3x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong3x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)})";
    }
}