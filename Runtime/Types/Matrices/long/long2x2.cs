using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 4)]
    unsafe public struct long2x2 : IEquatable<long2x2>, IFormattable
    {
        public long2 c0;
        public long2 c1;


        public static long2x2 identity => new long2x2(1, 0,   0, 1);

        public static long2x2 zero => default(long2x2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long2 c0, long2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long m00, long m01,
                       long m10, long m11)
        {
            this.c0 = new long2(m00, m10);
            this.c1 = new long2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(long v) => new long2x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(ulong2x2 input) => new long2x2((long2)input.c0, (long2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(float2x2 input) => new long2x2((long2)input.c0, (long2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(double2x2 input) => new long2x2((long2)input.c0, (long2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(long2x2 input) => new float2x2((float2)input.c0, (float2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(long2x2 input) => new double2x2((double2)input.c0, (double2)input.c1);


        public ref long2 this[[AssumeRange(0, 1)] int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((long2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, long2x2 rhs) => new long2x2 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, long2x2 rhs) => new long2x2 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, long2x2 rhs) => new long2x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, long2x2 rhs) => new long2x2 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, long2x2 rhs) => new long2x2 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, long rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long lhs, long2x2 rhs) => new long2x2 (lhs * rhs.c0, lhs * rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, long rhs) => new long2x2 (lhs.c0 / rhs, lhs.c1 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, long rhs) => new long2x2 (lhs.c0 % rhs, lhs.c1 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, long2x2 rhs) => new long2x2 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, long2x2 rhs) => new long2x2 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, long2x2 rhs) => new long2x2 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 val) => new long2x2(-val.c0, -val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ++ (long2x2 val) => new long2x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator -- (long2x2 val) => new long2x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ~ (long2x2 val) => new long2x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator << (long2x2 x, int n) => new long2x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator >> (long2x2 x, int n) => new long2x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (long2x2 lhs, long2x2 rhs) => new bool2x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator < (long2x2 lhs, long2x2 rhs) => new bool2x2 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator > (long2x2 lhs, long2x2 rhs) => new bool2x2 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (long2x2 lhs, long2x2 rhs) => new bool2x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator <= (long2x2 lhs, long2x2 rhs) => new bool2x2 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator >= (long2x2 lhs, long2x2 rhs) => new bool2x2 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(long2x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override bool Equals(object obj) => Equals((long2x2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override string ToString() => $"long2x2({c0.x}, {c1.x},  {c0.y}, {c1.y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"long2x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)})";
    }
}