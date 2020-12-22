using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 16)]
    unsafe public struct sbyte4x4 : IEquatable<sbyte4x4>, IFormattable
    {
        public sbyte4 c0;
        public sbyte4 c1;
        public sbyte4 c2;
        public sbyte4 c3;


        public static sbyte4x4 identity => new sbyte4x4(1, 0, 0, 0,   0, 1, 0, 0,   0, 0, 1, 0,   0, 0, 0, 1);

        public static sbyte4x4 zero => default(sbyte4x4);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4x4(sbyte4 c0, sbyte4 c1, sbyte4 c2, sbyte4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4x4(sbyte m00, sbyte m01, sbyte m02, sbyte m03,
                        sbyte m10, sbyte m11, sbyte m12, sbyte m13,
                        sbyte m20, sbyte m21, sbyte m22, sbyte m23,
                        sbyte m30, sbyte m31, sbyte m32, sbyte m33)
        {
            this.c0 = new sbyte4(m00, m10, m20, m30);
            this.c1 = new sbyte4(m01, m11, m21, m31);
            this.c2 = new sbyte4(m02, m12, m22, m32);
            this.c3 = new sbyte4(m03, m13, m23, m33);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4x4(sbyte v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
            this.c3 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4x4(sbyte v) => new sbyte4x4(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(byte4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(short4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(ushort4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(int4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(uint4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(long4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(ulong4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(float4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x4(double4x4 input) => new sbyte4x4((sbyte4)input.c0, (sbyte4)input.c1, (sbyte4)input.c2, (sbyte4)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4x4(sbyte4x4 input) => new short4x4((short4)input.c0, (short4)input.c1, (short4)input.c2, (short4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x4(sbyte4x4 input) => new ushort4x4((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2, (ushort4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x4(sbyte4x4 input) => new int4x4((int4)input.c0, (int4)input.c1, (int4)input.c2, (int4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(sbyte4x4 input) => new uint4x4((uint4)input.c0, (uint4)input.c1, (uint4)input.c2, (uint4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x4(sbyte4x4 input) => new long4x4((long4)input.c0, (long4)input.c1, (long4)input.c2, (long4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(sbyte4x4 input) => new ulong4x4((ulong4)input.c0, (ulong4)input.c1, (ulong4)input.c2, (ulong4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(sbyte4x4 input) => new float4x4((float4)input.c0, (float4)input.c1, (float4)input.c2, (float4)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(sbyte4x4 input) => new double4x4((double4)input.c0, (double4)input.c1, (double4)input.c2, (double4)input.c3);


        public ref sbyte4 this[[AssumeRange(0, 3)] int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ref ((sbyte4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator + (sbyte4x4 lhs, sbyte4x4 rhs) => new sbyte4x4 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator - (sbyte4x4 lhs, sbyte4x4 rhs) => new sbyte4x4 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator * (sbyte4x4 lhs, sbyte4x4 rhs) => new sbyte4x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator / (sbyte4x4 lhs, sbyte4x4 rhs) => new sbyte4x4 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator % (sbyte4x4 lhs, sbyte4x4 rhs) => new sbyte4x4 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator * (sbyte4x4 lhs, sbyte rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator * (sbyte lhs, sbyte4x4 rhs) => new sbyte4x4 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator / (sbyte4x4 lhs, sbyte rhs) => new sbyte4x4 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator % (sbyte4x4 lhs, sbyte rhs) => new sbyte4x4 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator & (sbyte4x4 lhs, sbyte4x4 rhs) => new sbyte4x4 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator | (sbyte4x4 lhs, sbyte4x4 rhs) => new sbyte4x4 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator ^ (sbyte4x4 lhs, sbyte4x4 rhs) => new sbyte4x4 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator - (sbyte4x4 val) => new sbyte4x4 (-val.c0, -val.c1, -val.c2, -val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator ++ (sbyte4x4 val) => new sbyte4x4 (++val.c0, ++val.c1, ++val.c2, ++val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator -- (sbyte4x4 val) => new sbyte4x4 (--val.c0, --val.c1, --val.c2, --val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator ~ (sbyte4x4 val) => new sbyte4x4 (~val.c0, ~val.c1, ~val.c2, ~val.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator << (sbyte4x4 x, int n) => new sbyte4x4 (x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 operator >> (sbyte4x4 x, int n) => new sbyte4x4 (x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator == (sbyte4x4 lhs, sbyte4x4 rhs) => new bool4x4 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator < (sbyte4x4 lhs, sbyte4x4 rhs) => new bool4x4 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator > (sbyte4x4 lhs, sbyte4x4 rhs) => new bool4x4 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator != (sbyte4x4 lhs, sbyte4x4 rhs) => new bool4x4 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator <= (sbyte4x4 lhs, sbyte4x4 rhs) => new bool4x4 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator >= (sbyte4x4 lhs, sbyte4x4 rhs) => new bool4x4 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(sbyte4x4 other) => (this.c0.Equals(other.c0) & this.c1.Equals(other.c1)) & (this.c2.Equals(other.c2) & this.c3.Equals(other.c3));
        public override bool Equals(object obj) => Equals((sbyte4x4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ (c2.GetHashCode() ^ c3.GetHashCode());


        public override string ToString() => $"sbyte4x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y},  {c0.z}, {c1.z}, {c2.z}, {c3.z},  {c0.w}, {c1.w}, {c2.w}, {c3.w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte4x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)}, {c3.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)}, {c2.w.ToString(format, formatProvider)}, {c3.w.ToString(format, formatProvider)})";
    }
}