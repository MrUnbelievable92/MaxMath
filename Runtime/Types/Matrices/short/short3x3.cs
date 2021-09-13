using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 3 * 3 * sizeof(short))]
    unsafe public struct short3x3 : IEquatable<short3x3>, IFormattable
    {
        public short3 c0;
        public short3 c1;
        public short3 c2;


        public static short3x3 identity => new short3x3(1, 0, 0,   0, 1, 0,   0, 0, 1);

        public static short3x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3x3(short3 c0, short3 c1, short3 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3x3(short m00, short m01, short m02,
                        short m10, short m11, short m12,
                        short m20, short m21, short m22)
        {
            this.c0 = new short3(m00, m10, m20);
            this.c1 = new short3(m01, m11, m21);
            this.c2 = new short3(m02, m12, m22);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3x3(short v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3x3(short v) => new short3x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3x3(ushort3x3 input) => new short3x3((short3)input.c0, (short3)input.c1, (short3)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3x3(int3x3 input) => new short3x3((short3)input.c0, (short3)input.c1, (short3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3x3(uint3x3 input) => new short3x3((short3)input.c0, (short3)input.c1, (short3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3x3(long3x3 input) => new short3x3((short3)input.c0, (short3)input.c1, (short3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3x3(ulong3x3 input) => new short3x3((short3)input.c0, (short3)input.c1, (short3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3x3(float3x3 input) => new short3x3((short3)input.c0, (short3)input.c1, (short3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3x3(double3x3 input) => new short3x3((short3)input.c0, (short3)input.c1, (short3)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x3(short3x3 input) => new int3x3((int3)input.c0, (int3)input.c1, (int3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(short3x3 input) => new uint3x3((uint3)input.c0, (uint3)input.c1, (uint3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x3(short3x3 input) => new long3x3((long3)input.c0, (long3)input.c1, (long3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x3(short3x3 input) => new ulong3x3((ulong3)input.c0, (ulong3)input.c1, (ulong3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x3(short3x3 input) => new float3x3((float3)input.c0, (float3)input.c1, (float3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(short3x3 input) => new double3x3((double3)input.c0, (double3)input.c1, (double3)input.c2);


        public ref short3 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((short3*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator + (short3x3 left, short3x3 right) => new short3x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator - (short3x3 left, short3x3 right) => new short3x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator * (short3x3 left, short3x3 right) => new short3x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator / (short3x3 left, short3x3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                short8 dividend_lo = Sse2.unpacklo_epi64(left.c0, left.c1);
                short8 divisor_lo  = Sse2.unpacklo_epi64(right.c0, right.c1);

#if DEBUG
                divisor_lo.x3 = 1;
                divisor_lo.x7 = 1;
#endif
                short8 div_lo = dividend_lo / divisor_lo;

                return new short3x3(div_lo.v3_0, div_lo.v3_4, left.c2 / right.c2);
            }
            else
            {
                return new short3x3(left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator % (short3x3 left, short3x3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                short8 dividend_lo = Sse2.unpacklo_epi64(left.c0, left.c1);
                short8 divisor_lo  = Sse2.unpacklo_epi64(right.c0, right.c1);

#if DEBUG
                divisor_lo.x3 = 1;
                divisor_lo.x7 = 1;
#endif
                short8 rem_lo = dividend_lo % divisor_lo;

                return new short3x3(rem_lo.v3_0, rem_lo.v3_4, left.c2 % right.c2);
            }
            else
            {
                return new short3x3(left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator * (short3x3 left, short right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator * (short left, short3x3 right) => new short3x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator / (short3x3 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    short8 dividend_lo = Sse2.unpacklo_epi64(left.c0, left.c1);

                    short8 div_lo = dividend_lo / right;

                    return new short3x3(div_lo.v3_0, div_lo.v3_4, left.c2 / right);
                }
            }

            return new short3x3(left.c0 / right, left.c1 / right, left.c2 / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator % (short3x3 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    short8 dividend_lo = Sse2.unpacklo_epi64(left.c0, left.c1);

                    short8 rem_lo = dividend_lo % right;

                    return new short3x3(rem_lo.v3_0, rem_lo.v3_4, left.c2 % right);
                }
            }

            return new short3x3(left.c0 % right, left.c1 % right, left.c2 % right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator & (short3x3 left, short3x3 right) => new short3x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator | (short3x3 left, short3x3 right) => new short3x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator ^ (short3x3 left, short3x3 right) => new short3x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator - (short3x3 val) => new short3x3 (-val.c0, -val.c1, -val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator ++ (short3x3 val) => new short3x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator -- (short3x3 val) => new short3x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator ~ (short3x3 val) => new short3x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator << (short3x3 x, int n) => new short3x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 operator >> (short3x3 x, int n) => new short3x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (short3x3 left, short3x3 right) => new bool3x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (short3x3 left, short3x3 right) => new bool3x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (short3x3 left, short3x3 right) => new bool3x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (short3x3 left, short3x3 right) => new bool3x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (short3x3 left, short3x3 right) => new bool3x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (short3x3 left, short3x3 right) => new bool3x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short3x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((short3x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ (c2.GetHashCode() << 8);


        public override string ToString() => $"short3x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short3x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)})";
    }
}