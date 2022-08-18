using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Sequential, Size = 4 * 2 * sizeof(sbyte))]
    unsafe public struct sbyte4x2 : IEquatable<sbyte4x2>, IFormattable
    {
        public sbyte4 c0;
        public sbyte4 c1;


        public static sbyte4x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4x2(sbyte4 c0, sbyte4 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4x2(sbyte m00, sbyte m01,
                        sbyte m10, sbyte m11,
                        sbyte m20, sbyte m21,
                        sbyte m30, sbyte m31)
        {
            this.c0 = new sbyte4(m00, m10, m20, m30);
            this.c1 = new sbyte4(m01, m11, m21, m31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4x2(sbyte v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4x2(sbyte v) => new sbyte4x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(byte4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(short4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(ushort4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(int4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(uint4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(long4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(ulong4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(float4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4x2(double4x2 input) => new sbyte4x2((sbyte4)input.c0, (sbyte4)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4x2(sbyte4x2 input) => new short4x2((short4)input.c0, (short4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x2(sbyte4x2 input) => new ushort4x2((ushort4)input.c0, (ushort4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x2(sbyte4x2 input) => new int4x2((int4)input.c0, (int4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(sbyte4x2 input) => new uint4x2((uint4)input.c0, (uint4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(sbyte4x2 input) => new long4x2((long4)input.c0, (long4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x2(sbyte4x2 input) => new ulong4x2((ulong4)input.c0, (ulong4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x2(sbyte4x2 input) => new float4x2((float4)input.c0, (float4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x2(sbyte4x2 input) => new double4x2((double4)input.c0, (double4)input.c1);


        public ref sbyte4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((sbyte4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator + (sbyte4x2 left, sbyte4x2 right) => new sbyte4x2 (left.c0 + right.c0, left.c1 + right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator - (sbyte4x2 left, sbyte4x2 right) => new sbyte4x2 (left.c0 - right.c0, left.c1 - right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator * (sbyte4x2 left, sbyte4x2 right) => new sbyte4x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator / (sbyte4x2 left, sbyte4x2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte8 dividend = Sse2.unpacklo_epi32(left.c0, left.c1);
                sbyte8 divisor  = Sse2.unpacklo_epi32(right.c0, right.c1);

                sbyte8 quotient = dividend / divisor;

                return new sbyte4x2(quotient.v4_0, quotient.v4_4);
            }
            else
            {
                return new sbyte4x2(left.c0 / right.c0, left.c1 / right.c1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator % (sbyte4x2 left, sbyte4x2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte8 dividend = Sse2.unpacklo_epi32(left.c0, left.c1);
                sbyte8 divisor  = Sse2.unpacklo_epi32(right.c0, right.c1);

                sbyte8 remainder = dividend % divisor;

                return new sbyte4x2(remainder.v4_0, remainder.v4_4);
            }
            else
            {
                return new sbyte4x2(left.c0 % right.c0, left.c1 % right.c1);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator * (sbyte4x2 left, sbyte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator * (sbyte left, sbyte4x2 right) => new sbyte4x2 (left * right.c0, left * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator / (sbyte4x2 left, sbyte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {

                    sbyte8 dividend = Sse2.unpacklo_epi32(left.c0, left.c1);

                    sbyte8 quotient = dividend / right;

                    return new sbyte4x2(quotient.v4_0, quotient.v4_4);
                }
            }

            return new sbyte4x2 (left.c0 / right, left.c1 / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator % (sbyte4x2 left, sbyte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {

                    sbyte8 dividend = Sse2.unpacklo_epi32(left.c0, left.c1);

                    sbyte8 quotient = dividend % right;

                    return new sbyte4x2(quotient.v4_0, quotient.v4_4);
                }
            }

            return new sbyte4x2(left.c0 % right, left.c1 % right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator & (sbyte4x2 left, sbyte4x2 right) => new sbyte4x2 (left.c0 & right.c0, left.c1 & right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator | (sbyte4x2 left, sbyte4x2 right) => new sbyte4x2 (left.c0 | right.c0, left.c1 | right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator ^ (sbyte4x2 left, sbyte4x2 right) => new sbyte4x2 (left.c0 ^ right.c0, left.c1 ^ right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator - (sbyte4x2 val) => new sbyte4x2 (-val.c0, -val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator ++ (sbyte4x2 val) => new sbyte4x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator -- (sbyte4x2 val) => new sbyte4x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator ~ (sbyte4x2 val) => new sbyte4x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator << (sbyte4x2 x, int n) => new sbyte4x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 operator >> (sbyte4x2 x, int n) => new sbyte4x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator == (sbyte4x2 left, sbyte4x2 right) => new bool4x2 (left.c0 == right.c0, left.c1 == right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator < (sbyte4x2 left, sbyte4x2 right) => new bool4x2 (left.c0 < right.c0, left.c1 < right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator > (sbyte4x2 left, sbyte4x2 right) => new bool4x2 (left.c0 > right.c0, left.c1 > right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator != (sbyte4x2 left, sbyte4x2 right) => new bool4x2 (left.c0 != right.c0, left.c1 != right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator <= (sbyte4x2 left, sbyte4x2 right) => new bool4x2 (left.c0 <= right.c0, left.c1 <= right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator >= (sbyte4x2 left, sbyte4x2 right) => new bool4x2 (left.c0 >= right.c0, left.c1 >= right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte4x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override readonly bool Equals(object obj) => obj is sbyte4x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override readonly string ToString() => $"sbyte4x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z},  {c0.w}, {c1.w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte4x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)})";
    }
}