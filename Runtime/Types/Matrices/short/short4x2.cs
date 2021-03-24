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
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 4 * 2 * sizeof(short))]
    unsafe public struct short4x2 : IEquatable<short4x2>, IFormattable
    {
        public short4 c0;
        public short4 c1;


        public static short4x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4x2(short4 c0, short4 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4x2(short m00, short m01,
                        short m10, short m11,
                        short m20, short m21,
                        short m30, short m31)
        {
            this.c0 = new short4(m00, m10, m20, m30);
            this.c1 = new short4(m01, m11, m21, m31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4x2(short v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4x2(short v) => new short4x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x2(ushort4x2 input) => new short4x2((short4)input.c0, (short4)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x2(int4x2 input) => new short4x2((short4)input.c0, (short4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x2(uint4x2 input) => new short4x2((short4)input.c0, (short4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x2(long4x2 input) => new short4x2((short4)input.c0, (short4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x2(ulong4x2 input) => new short4x2((short4)input.c0, (short4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x2(float4x2 input) => new short4x2((short4)input.c0, (short4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x2(double4x2 input) => new short4x2((short4)input.c0, (short4)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x2(short4x2 input) => new int4x2((int4)input.c0, (int4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(short4x2 input) => new uint4x2((uint4)input.c0, (uint4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(short4x2 input) => new long4x2((long4)input.c0, (long4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x2(short4x2 input) => new ulong4x2((ulong4)input.c0, (ulong4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x2(short4x2 input) => new float4x2((float4)input.c0, (float4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x2(short4x2 input) => new double4x2((double4)input.c0, (double4)input.c1);


        public ref short4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((short4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator + (short4x2 left, short4x2 right) => new short4x2 (left.c0 + right.c0, left.c1 + right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator - (short4x2 left, short4x2 right) => new short4x2 (left.c0 - right.c0, left.c1 - right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator * (short4x2 left, short4x2 right) => new short4x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator / (short4x2 left, short4x2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                short8 div = new short8(left.c0, left.c1) / new short8(right.c0, right.c1);

                return new short4x2(div.v4_0, div.v4_4);
            }
            else
            {
                return new short4x2(left.c0 / right.c0, left.c1 / right.c1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator % (short4x2 left, short4x2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                short8 rem = new short8(left.c0, left.c1) % new short8(right.c0, right.c1);

                return new short4x2(rem.v4_0, rem.v4_4);
            }
            else
            {
                return new short4x2(left.c0 % right.c0, left.c1 % right.c1);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator * (short4x2 left, short right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator * (short left, short4x2 right) => new short4x2 (left * right.c0, left * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator / (short4x2 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!Constant.IsConstantExpression(right))
                {
                    short8 div = new short8(left.c0, left.c1) / right;

                    return new short4x2(div.v4_0, div.v4_4);
                }
            }

            return new short4x2(left.c0 / right, left.c1 / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator % (short4x2 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!Constant.IsConstantExpression(right))
                {
                    short8 rem = new short8(left.c0, left.c1) % right;

                    return new short4x2(rem.v4_0, rem.v4_4);
                }
            }

            return new short4x2(left.c0 % right, left.c1 % right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator & (short4x2 left, short4x2 right) => new short4x2 (left.c0 & right.c0, left.c1 & right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator | (short4x2 left, short4x2 right) => new short4x2 (left.c0 | right.c0, left.c1 | right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator ^ (short4x2 left, short4x2 right) => new short4x2 (left.c0 ^ right.c0, left.c1 ^ right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator - (short4x2 val) => new short4x2 (-val.c0, -val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator ++ (short4x2 val) => new short4x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator -- (short4x2 val) => new short4x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator ~ (short4x2 val) => new short4x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator << (short4x2 x, int n) => new short4x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 operator >> (short4x2 x, int n) => new short4x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator == (short4x2 left, short4x2 right) => new bool4x2 (left.c0 == right.c0, left.c1 == right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator < (short4x2 left, short4x2 right) => new bool4x2 (left.c0 < right.c0, left.c1 < right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator > (short4x2 left, short4x2 right) => new bool4x2 (left.c0 > right.c0, left.c1 > right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator != (short4x2 left, short4x2 right) => new bool4x2 (left.c0 != right.c0, left.c1 != right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator <= (short4x2 left, short4x2 right) => new bool4x2 (left.c0 <= right.c0, left.c1 <= right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator >= (short4x2 left, short4x2 right) => new bool4x2 (left.c0 >= right.c0, left.c1 >= right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short4x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override bool Equals(object obj) => Equals((short4x2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override string ToString() => $"short4x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z},  {c0.w}, {c1.w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short4x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)})";
    }
}