using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Sequential, Size = 2 * 3 * sizeof(short))]
    unsafe public struct short2x3 : IEquatable<short2x3>, IFormattable
    {
        public short2 c0;
        public short2 c1;
        public short2 c2;


        public static short2x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short2 c0, short2 c1, short2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short m00, short m01, short m02,
                        short m10, short m11, short m12)
        {
            this.c0 = new short2(m00, m10);
            this.c1 = new short2(m01, m11);
            this.c2 = new short2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x3(short v) => new short2x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(ushort2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(int2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(uint2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(long2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(ulong2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(float2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(double2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x3(short2x3 input) => new int2x3((int2)input.c0, (int2)input.c1, (int2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(short2x3 input) => new uint2x3((uint2)input.c0, (uint2)input.c1, (uint2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(short2x3 input) => new long2x3((long2)input.c0, (long2)input.c1, (long2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(short2x3 input) => new ulong2x3((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(short2x3 input) => new float2x3((float2)input.c0, (float2)input.c1, (float2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x3(short2x3 input) => new double2x3((double2)input.c0, (double2)input.c1, (double2)input.c2);


        public ref short2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((short2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short2x3 left, short2x3 right) => new short2x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 left, short2x3 right) => new short2x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 left, short2x3 right) => new short2x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 left, short2x3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
#if DEBUG
                short8 packed_LHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        Sse2.unpacklo_epi32(left.c2, new short2(1)));
                short8 packed_RHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(right.c0, right.c1),
                                                        Sse2.unpacklo_epi32(right.c2, new short2(1)));

                short8 div = packed_LHS / packed_RHS;

                return new short2x3(div.v2_0, div.v2_2, div.v2_4);
#else
                short8 packed_LHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        left.c2);
                short8 packed_RHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(right.c0, right.c1),
                                                        right.c2);

                short8 div = packed_LHS / packed_RHS;

                return new short2x3(div.v2_0, div.v2_2, div.v2_4);
#endif
            }
            else if (Sse2.IsSse2Supported)
            {
                short8 packed_LHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        Sse2.unpacklo_epi32(left.c2, new short2(1)));

                short4 div = new short4(left.c0, left.c1) / new short4(right.c0, right.c1);

                return new short2x3(div.xy, div.zw, left.c2 / right.c2);
            }
            else
            {
                return new short2x3(left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 left, short2x3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
#if DEBUG
                short8 packed_LHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        Sse2.unpacklo_epi32(left.c2, new short2(1)));
                short8 packed_RHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(right.c0, right.c1),
                                                        Sse2.unpacklo_epi32(right.c2, new short2(1)));

                short8 rem = packed_LHS % packed_RHS;

                return new short2x3(rem.v2_0, rem.v2_2, rem.v2_4);
#else
                short8 packed_LHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        left.c2);
                short8 packed_RHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(right.c0, right.c1),
                                                        right.c2);

                short8 rem = packed_LHS % packed_RHS;

                return new short2x3(rem.v2_0, rem.v2_2, rem.v2_4);
#endif
            }
            else if (Sse2.IsSse2Supported)
            {
                short8 packed_LHS = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        Sse2.unpacklo_epi32(left.c2, new short2(1)));

                short4 rem = new short4(left.c0, left.c1) % new short4(right.c0, right.c1);

                return new short2x3(rem.xy, rem.zw, left.c2 % right.c2);
            }
            else
            {
                return new short2x3(left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 left, short right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short left, short2x3 right) => new short2x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
#if DEBUG
                    short8 packed = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        Sse2.unpacklo_epi32(left.c2, new short2(1)));

                    short8 div = packed / right;

                    return new short2x3(div.v2_0, div.v2_2, div.v2_4);
#else
                    short8 packed = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        left.c2);

                    short8 div = packed / right;

                    return new short2x3(div.v2_0, div.v2_2, div.v2_4);
#endif
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    v128 divisor = (short4)right;
                    short4 lo = new short4(left.c0, left.c1) / divisor;

                    return new short2x3(lo.xy, lo.zw, left.c2 / divisor);
                }
            }

            return new short2x3(left.c0 / right, left.c1 / right, left.c2 / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    short8 packed = Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(left.c0, left.c1),
                                                        Sse2.unpacklo_epi32(left.c2, Xse.setall_si128()));

                    short8 div = packed % right;

                    return new short2x3(div.v2_0, div.v2_2, div.v2_4);
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    v128 divisor = (short4)right;
                    short4 lo = new short4(left.c0, left.c1) % divisor;

                    return new short2x3(lo.xy, lo.zw, left.c2 % divisor);
                }
            }

            return new short2x3(left.c0 % right, left.c1 % right, left.c2 % right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (short2x3 left, short2x3 right) => new short2x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (short2x3 left, short2x3 right) => new short2x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (short2x3 left, short2x3 right) => new short2x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 val) => new short2x3(-val.c0, -val.c1, -val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ++ (short2x3 val) => new short2x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator -- (short2x3 val) => new short2x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ~ (short2x3 val) => new short2x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator << (short2x3 x, int n) => new short2x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator >> (short2x3 x, int n) => new short2x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (short2x3 left, short2x3 right) => new bool2x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator < (short2x3 left, short2x3 right) => new bool2x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator > (short2x3 left, short2x3 right) => new bool2x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (short2x3 left, short2x3 right) => new bool2x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator <= (short2x3 left, short2x3 right) => new bool2x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator >= (short2x3 left, short2x3 right) => new bool2x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short2x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override readonly bool Equals(object obj) => obj is short2x3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode() ^ c2.GetHashCode();


        public override readonly string ToString() => $"short2x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short2x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)})";
    }
}