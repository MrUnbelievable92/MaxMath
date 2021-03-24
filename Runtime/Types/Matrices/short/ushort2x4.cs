using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 2 * 4 * sizeof(ushort))]
    unsafe public struct ushort2x4 : IEquatable<ushort2x4>, IFormattable
    {
        public ushort2 c0;
        public ushort2 c1;
        public ushort2 c2;
        public ushort2 c3;


        public static ushort2x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2x4(ushort2 c0, ushort2 c1, ushort2 c2, ushort2 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2x4(ushort m00, ushort m01, ushort m02, ushort m03,
                         ushort m10, ushort m11, ushort m12, ushort m13)
        {
            this.c0 = new ushort2(m00, m10);
            this.c1 = new ushort2(m01, m11);
            this.c2 = new ushort2(m02, m12);
            this.c3 = new ushort2(m03, m13);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2x4(ushort v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
            this.c3 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2x4(ushort v) => new ushort2x4(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x4(short2x4 input) => new ushort2x4((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2, (ushort2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x4(int2x4 input) => new ushort2x4((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2, (ushort2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x4(uint2x4 input) => new ushort2x4((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2, (ushort2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x4(long2x4 input) => new ushort2x4((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2, (ushort2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x4(ulong2x4 input) => new ushort2x4((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2, (ushort2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x4(float2x4 input) => new ushort2x4((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2, (ushort2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x4(double2x4 input) => new ushort2x4((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2, (ushort2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(ushort2x4 input) => new int2x4((int2)input.c0, (int2)input.c1, (int2)input.c2, (int2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2x4(ushort2x4 input) => new uint2x4((uint2)input.c0, (uint2)input.c1, (uint2)input.c2, (uint2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(ushort2x4 input) => new long2x4((long2)input.c0, (long2)input.c1, (long2)input.c2, (long2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x4(ushort2x4 input) => new ulong2x4((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2, (ulong2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x4(ushort2x4 input) => new float2x4((float2)input.c0, (float2)input.c1, (float2)input.c2, (float2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x4(ushort2x4 input) => new double2x4((double2)input.c0, (double2)input.c1, (double2)input.c2, (double2)input.c3);


        public ref ushort2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ref ((ushort2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator + (ushort2x4 left, ushort2x4 right) => new ushort2x4 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2, left.c3 + right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator - (ushort2x4 left, ushort2x4 right) => new ushort2x4 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2, left.c3 - right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator * (ushort2x4 left, ushort2x4 right) => new ushort2x4(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2, left.c3 * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator / (ushort2x4 left, ushort2x4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                ushort8 div = new ushort8(left.c0, left.c1, left.c2, left.c3) / new ushort8(right.c0, right.c1, right.c2, right.c3);

                return new ushort2x4(div.v2_0, div.v2_2, div.v2_4, div.v2_6);
            }
            else if (Sse2.IsSse2Supported)
            {
                ushort4 lo = new ushort4(left.c0, left.c1) / new ushort4(right.c0, right.c1);
                ushort4 hi = new ushort4(left.c2, left.c3) / new ushort4(right.c2, right.c3);

                return new ushort2x4(lo.xy, lo.zw, hi.xy, hi.zw);
            }
            else
            {
                return new ushort2x4(left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator % (ushort2x4 left, ushort2x4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                ushort8 div = new ushort8(left.c0, left.c1, left.c2, left.c3) % new ushort8(right.c0, right.c1, right.c2, right.c3);

                return new ushort2x4(div.v2_0, div.v2_2, div.v2_4, div.v2_6);
            }
            else if (Sse2.IsSse2Supported)
            {
                ushort4 lo = new ushort4(left.c0, left.c1) % new ushort4(right.c0, right.c1);
                ushort4 hi = new ushort4(left.c2, left.c3) % new ushort4(right.c2, right.c3);

                return new ushort2x4(lo.xy, lo.zw, hi.xy, hi.zw);
            }
            else
            {
                return new ushort2x4(left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator * (ushort2x4 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator * (ushort left, ushort2x4 right) => new ushort2x4 (left * right.c0, left * right.c1, left * right.c2, left * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator / (ushort2x4 left, ushort right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!Constant.IsConstantExpression(right))
                {
                    ushort8 div = new ushort8(left.c0, left.c1, left.c2, left.c3) / right;

                    return new ushort2x4(div.v2_0, div.v2_2, div.v2_4, div.v2_6);
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                if (!Constant.IsConstantExpression(right))
                {
                    ushort4 divisor = right;
                    ushort4 lo = new ushort4(left.c0, left.c1) / divisor;
                    ushort4 hi = new ushort4(left.c2, left.c3) / divisor;

                    return new ushort2x4(lo.xy, lo.zw, hi.xy, hi.zw);
                }
            }

            return new ushort2x4(left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator % (ushort2x4 left, ushort right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!Constant.IsConstantExpression(right))
                {
                    ushort8 rem = new ushort8(left.c0, left.c1, left.c2, left.c3) % right;

                    return new ushort2x4(rem.v2_0, rem.v2_2, rem.v2_4, rem.v2_6);
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                if (!Constant.IsConstantExpression(right))
                {
                    ushort4 divisor = right;
                    ushort4 lo = new ushort4(left.c0, left.c1) % divisor;
                    ushort4 hi = new ushort4(left.c2, left.c3) % divisor;

                    return new ushort2x4(lo.xy, lo.zw, hi.xy, hi.zw);
                }
            }

            return new ushort2x4(left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator & (ushort2x4 left, ushort2x4 right) => new ushort2x4 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2, left.c3 & right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator | (ushort2x4 left, ushort2x4 right) => new ushort2x4 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2, left.c3 | right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator ^ (ushort2x4 left, ushort2x4 right) => new ushort2x4 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2, left.c3 ^ right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator ++ (ushort2x4 val) => new ushort2x4 (++val.c0, ++val.c1, ++val.c2, ++val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator -- (ushort2x4 val) => new ushort2x4 (--val.c0, --val.c1, --val.c2, --val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator ~ (ushort2x4 val) => new ushort2x4 (~val.c0, ~val.c1, ~val.c2, ~val.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator << (ushort2x4 x, int n) => new ushort2x4 (x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 operator >> (ushort2x4 x, int n) => new ushort2x4 (x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator == (ushort2x4 left, ushort2x4 right) => new bool2x4 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2, left.c3 == right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator < (ushort2x4 left, ushort2x4 right) => new bool2x4 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2, left.c3 < right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator > (ushort2x4 left, ushort2x4 right) => new bool2x4 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2, left.c3 > right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator != (ushort2x4 left, ushort2x4 right) => new bool2x4 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2, left.c3 != right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator <= (ushort2x4 left, ushort2x4 right) => new bool2x4 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2, left.c3 <= right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator >= (ushort2x4 left, ushort2x4 right) => new bool2x4 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2, left.c3 >= right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort2x4 other) => (this.c0.Equals(other.c0) & this.c1.Equals(other.c1)) & (this.c2.Equals(other.c2) & this.c3.Equals(other.c3));
        public override bool Equals(object obj) => Equals((ushort2x4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ (c2.GetHashCode() ^ c3.GetHashCode());


        public override string ToString() => $"ushort2x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort2x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)})";
    }
}