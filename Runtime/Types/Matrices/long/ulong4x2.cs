using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 64)]
    unsafe public struct ulong4x2 : IEquatable<ulong4x2>, IFormattable
    {
        public ulong4 c0;
        public ulong4 c1;


        public static ulong4x2 zero => default(ulong4x2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x2(ulong4 c0, ulong4 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x2(ulong m00, ulong m01,
                        ulong m10, ulong m11,
                        ulong m20, ulong m21,
                        ulong m30, ulong m31)
        {
            this.c0 = new ulong4(m00, m10, m20, m30);
            this.c1 = new ulong4(m01, m11, m21, m31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x2(ulong v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x2(ulong v) => new ulong4x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x2(long4x2 input) => new ulong4x2((ulong4)input.c0, (ulong4)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x2(float4x2 input) => new ulong4x2((ulong4)input.c0, (ulong4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x2(double4x2 input) => new ulong4x2((ulong4)input.c0, (ulong4)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x2(ulong4x2 input) => new float4x2((float4)input.c0, (float4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x2(ulong4x2 input) => new double4x2((double4)input.c0, (double4)input.c1);


        public ref ulong4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((ulong4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator + (ulong4x2 lhs, ulong4x2 rhs) => new ulong4x2 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator - (ulong4x2 lhs, ulong4x2 rhs) => new ulong4x2 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator * (ulong4x2 lhs, ulong4x2 rhs) => new ulong4x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator / (ulong4x2 lhs, ulong4x2 rhs) => new ulong4x2 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator % (ulong4x2 lhs, ulong4x2 rhs) => new ulong4x2 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator * (ulong4x2 lhs, ulong rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator * (ulong lhs, ulong4x2 rhs) => new ulong4x2 (lhs * rhs.c0, lhs * rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator / (ulong4x2 lhs, ulong rhs) => new ulong4x2 (lhs.c0 / rhs, lhs.c1 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator % (ulong4x2 lhs, ulong rhs) => new ulong4x2 (lhs.c0 % rhs, lhs.c1 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator & (ulong4x2 lhs, ulong4x2 rhs) => new ulong4x2 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator | (ulong4x2 lhs, ulong4x2 rhs) => new ulong4x2 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator ^ (ulong4x2 lhs, ulong4x2 rhs) => new ulong4x2 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator ++ (ulong4x2 val) => new ulong4x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator -- (ulong4x2 val) => new ulong4x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator ~ (ulong4x2 val) => new ulong4x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator << (ulong4x2 x, int n) => new ulong4x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 operator >> (ulong4x2 x, int n) => new ulong4x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator == (ulong4x2 lhs, ulong4x2 rhs) => new bool4x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator < (ulong4x2 lhs, ulong4x2 rhs) => new bool4x2 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator > (ulong4x2 lhs, ulong4x2 rhs) => new bool4x2 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator != (ulong4x2 lhs, ulong4x2 rhs) => new bool4x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator <= (ulong4x2 lhs, ulong4x2 rhs) => new bool4x2 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator >= (ulong4x2 lhs, ulong4x2 rhs) => new bool4x2 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong4x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override bool Equals(object obj) => Equals((ulong4x2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override string ToString() => $"ulong4x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z},  {c0.w}, {c1.w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong4x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)})";
    }
}