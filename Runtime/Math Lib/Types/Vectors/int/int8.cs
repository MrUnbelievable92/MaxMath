using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(int))]
    [DebuggerTypeProxy(typeof(int8.DebuggerProxy))]
    unsafe public struct int8 : IEquatable<int8>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public int x0;
            public int x1;
            public int x2;
            public int x3;
            public int x4;
            public int x5;
            public int x6;
            public int x7;

            public DebuggerProxy(int8 v)
            {
                x0 = v.x0;
                x1 = v.x1;
                x2 = v.x2;
                x3 = v.x3;
                x4 = v.x4;
                x5 = v.x5;
                x6 = v.x6;
                x7 = v.x7;
            }
        }


        [FieldOffset(0)]  internal int4 _v4_0;
        [FieldOffset(16)] internal int4 _v4_4;

        [FieldOffset(0)]  public int x0;
        [FieldOffset(4)]  public int x1;
        [FieldOffset(8)]  public int x2;
        [FieldOffset(12)] public int x3;
        [FieldOffset(16)] public int x4;
        [FieldOffset(20)] public int x5;
        [FieldOffset(24)] public int x6;
        [FieldOffset(28)] public int x7;


        public static int8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int x0, int x1, int x2, int x3, int x4, int x5, int x6, int x7)
        {
            this = (int8)new uint8((uint)x0, (uint)x1, (uint)x2, (uint)x3, (uint)x4, (uint)x5, (uint)x6, (uint)x7);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int x0x8)
        {
            this = (int8)new uint8((uint)x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int2 x23, int2 x45, int2 x67)
        {
            this = (int8)new uint8((uint2)x01, (uint2)x23, (uint2)x45, (uint2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int3 x234, int3 x567)
        {
            this = (int8)new uint8((uint2)x01, (uint3)x234, (uint3)x567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int3 x012, int2 x34, int3 x567)
        {
            this = (int8)new uint8((uint3)x012, (uint2)x34, (uint3)x567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int3 x012, int3 x345, int2 x67)
        {
            this = (int8)new uint8((uint3)x012, (uint3)x345, (uint2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int4 x0123, int2 x45, int2 x67)
        {
            this = (int8)new uint8((uint4)x0123, (uint2)x45, (uint2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int4 x2345, int2 x67)
        {
            this = (int8)new uint8((uint2)x01, (uint4)x2345, (uint2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int2 x23, int4 x4567)
        {
            this = (int8)new uint8((uint2)x01, (uint2)x23, (uint4)x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int4 x0123, int4 x4567)
        {
            this = (int8)new uint8((uint4)x0123, (uint4)x4567);
        }


        #region Shuffle
        public int4 v4_0  { readonly get => (int4)((uint8)this).v4_0;    set { uint8 _this = (uint8)this; _this.v4_0  = (uint4)value; this = (int8)_this; } }
        public int4 v4_1  { readonly get => (int4)((uint8)this).v4_1;    set { uint8 _this = (uint8)this; _this.v4_1  = (uint4)value; this = (int8)_this; } }
        public int4 v4_2  { readonly get => (int4)((uint8)this).v4_2;    set { uint8 _this = (uint8)this; _this.v4_2  = (uint4)value; this = (int8)_this; } }
        public int4 v4_3  { readonly get => (int4)((uint8)this).v4_3;    set { uint8 _this = (uint8)this; _this.v4_3  = (uint4)value; this = (int8)_this; } }
        public int4 v4_4  { readonly get => (int4)((uint8)this).v4_4;    set { uint8 _this = (uint8)this; _this.v4_4  = (uint4)value; this = (int8)_this; } }

        public int3 v3_0  { readonly get => (int3)((uint8)this).v3_0;    set { uint8 _this = (uint8)this; _this.v3_0  = (uint3)value; this = (int8)_this; } }
        public int3 v3_1  { readonly get => (int3)((uint8)this).v3_1;    set { uint8 _this = (uint8)this; _this.v3_1  = (uint3)value; this = (int8)_this; } }
        public int3 v3_2  { readonly get => (int3)((uint8)this).v3_2;    set { uint8 _this = (uint8)this; _this.v3_2  = (uint3)value; this = (int8)_this; } }
        public int3 v3_3  { readonly get => (int3)((uint8)this).v3_3;    set { uint8 _this = (uint8)this; _this.v3_3  = (uint3)value; this = (int8)_this; } }
        public int3 v3_4  { readonly get => (int3)((uint8)this).v3_4;    set { uint8 _this = (uint8)this; _this.v3_4  = (uint3)value; this = (int8)_this; } }
        public int3 v3_5  { readonly get => (int3)((uint8)this).v3_5;    set { uint8 _this = (uint8)this; _this.v3_5  = (uint3)value; this = (int8)_this; } }

        public int2 v2_0  { readonly get => (int2)((uint8)this).v2_0;    set { uint8 _this = (uint8)this; _this.v2_0  = (uint2)value; this = (int8)_this; } }
        public int2 v2_1  { readonly get => (int2)((uint8)this).v2_1;    set { uint8 _this = (uint8)this; _this.v2_1  = (uint2)value; this = (int8)_this; } }
        public int2 v2_2  { readonly get => (int2)((uint8)this).v2_2;    set { uint8 _this = (uint8)this; _this.v2_2  = (uint2)value; this = (int8)_this; } }
        public int2 v2_3  { readonly get => (int2)((uint8)this).v2_3;    set { uint8 _this = (uint8)this; _this.v2_3  = (uint2)value; this = (int8)_this; } }
        public int2 v2_4  { readonly get => (int2)((uint8)this).v2_4;    set { uint8 _this = (uint8)this; _this.v2_4  = (uint2)value; this = (int8)_this; } }
        public int2 v2_5  { readonly get => (int2)((uint8)this).v2_5;    set { uint8 _this = (uint8)this; _this.v2_5  = (uint2)value; this = (int8)_this; } }
        public int2 v2_6  { readonly get => (int2)((uint8)this).v2_6;    set { uint8 _this = (uint8)this; _this.v2_6  = (uint2)value; this = (int8)_this; } }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(int8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(v256 input) => new int8{ x0 = input.SInt0, x1 = input.SInt1, x2 = input.SInt2, x3 = input.SInt3, x4 = input.SInt4, x5 = input.SInt5, x6 = input.SInt6, x7 = input.SInt7 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(int input) => new int8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(uint8 input) => *(int8*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(half8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi32(input);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return new int8(RegisterConversion.ToInt4(Xse.cvttph_epi32(RegisterConversion.ToV128(input.v4_0), 4)),
                                RegisterConversion.ToInt4(Xse.cvttph_epi32(RegisterConversion.ToV128(input.v4_4), 4)));
            }
            else
            {
                return new int8((int)maxmath.BASE_cvtf16i32(input.x0, signed: true, trunc: true),
                                (int)maxmath.BASE_cvtf16i32(input.x1, signed: true, trunc: true),
                                (int)maxmath.BASE_cvtf16i32(input.x2, signed: true, trunc: true),
                                (int)maxmath.BASE_cvtf16i32(input.x3, signed: true, trunc: true),
                                (int)maxmath.BASE_cvtf16i32(input.x4, signed: true, trunc: true),
                                (int)maxmath.BASE_cvtf16i32(input.x5, signed: true, trunc: true),
                                (int)maxmath.BASE_cvtf16i32(input.x6, signed: true, trunc: true),
                                (int)maxmath.BASE_cvtf16i32(input.x7, signed: true, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(float8 input)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvttps_epi32(input);
            }
            else
            {
                return new int8((int4)input._v4_0, (int4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(int8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(int8 input)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvtepi32_ps(input);
            }
            else
            {
                return new float8((float4)input._v4_0, (float4)input._v4_4);
            }
        }


        public int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (int)((uint8)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                uint8 _this = (uint8)this;
                _this[index] = (uint)value;
                this = (int8)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator + (int8 left, int8 right) => (int8)((uint8)left + (uint8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator - (int8 left, int8 right) => (int8)((uint8)left - (uint8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int8 left, int8 right) => (int8)((uint8)left * (uint8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator / (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_div_epi32(left, right);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return new int8(RegisterConversion.ToInt4(Xse.div_epi32(RegisterConversion.ToV128(left.v4_0), RegisterConversion.ToV128(right.v4_0))),
                                RegisterConversion.ToInt4(Xse.div_epi32(RegisterConversion.ToV128(left.v4_4), RegisterConversion.ToV128(right.v4_4))));
            }
            else
            {
                return new int8((left.x0 / right.x0), (left.x1 / right.x1), (left.x2 / right.x2), (left.x3 / right.x3), (left.x4 / right.x4), (left.x5 / right.x5), (left.x6 / right.x6), (left.x7 / right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator % (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rem_epi32(left, right);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return new int8(RegisterConversion.ToInt4(Xse.rem_epi32(RegisterConversion.ToV128(left.v4_0), RegisterConversion.ToV128(right.v4_0))),
                                RegisterConversion.ToInt4(Xse.rem_epi32(RegisterConversion.ToV128(left.v4_4), RegisterConversion.ToV128(right.v4_4))));
            }
            else
            {
                return new int8((left.x0 % right.x0), (left.x1 % right.x1), (left.x2 % right.x2), (left.x3 % right.x3), (left.x4 % right.x4), (left.x5 % right.x5), (left.x6 % right.x6), (left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int left, int8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int8 left, int right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return new int8((left.x0 * right), (left.x1 * right), (left.x2 * right), (left.x3 * right), (left.x4 * right), (left.x5 * right), (left.x6 * right), (left.x7 * right));
                }
                else
                {
                    return left * (int8)right;
                }
            }
            else
            {
                return new int8(left._v4_0 * right, left._v4_4 * right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator / (int8 left, int right)
        {
Assert.AreNotEqual(right, 0);

Assert.IsFalse(left.x0 == int.MinValue && right == -1);
Assert.IsFalse(left.x1 == int.MinValue && right == -1);
Assert.IsFalse(left.x2 == int.MinValue && right == -1);
Assert.IsFalse(left.x3 == int.MinValue && right == -1);
Assert.IsFalse(left.x4 == int.MinValue && right == -1);
Assert.IsFalse(left.x5 == int.MinValue && right == -1);
Assert.IsFalse(left.x6 == int.MinValue && right == -1);
Assert.IsFalse(left.x7 == int.MinValue && right == -1);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constdiv_epi32(left, right);
                }
            }

            return left / (int8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator % (int8 left, int right)
        {
Assert.AreNotEqual(right, 0);

Assert.IsFalse(left.x0 == int.MinValue && right == -1);
Assert.IsFalse(left.x1 == int.MinValue && right == -1);
Assert.IsFalse(left.x2 == int.MinValue && right == -1);
Assert.IsFalse(left.x3 == int.MinValue && right == -1);
Assert.IsFalse(left.x4 == int.MinValue && right == -1);
Assert.IsFalse(left.x5 == int.MinValue && right == -1);
Assert.IsFalse(left.x6 == int.MinValue && right == -1);
Assert.IsFalse(left.x7 == int.MinValue && right == -1);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constrem_epi32(left, right);
                }
            }

            return left % (int8)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator & (int8 left, int8 right) => (int8)((uint8)left & (uint8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator | (int8 left, int8 right) => (int8)((uint8)left | (uint8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ^ (int8 left, int8 right) => (int8)((uint8)left ^ (uint8)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator - (int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi32(x);
            }
            else
            {
                return new int8(-x._v4_0, -x._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ++ (int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi32(x);
            }
            else
            {
                return new int8(x._v4_0 + 1, x._v4_4 + 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator -- (int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_epi32(x);
            }
            else
            {
                return new int8(x._v4_0 - 1, x._v4_4 - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ~ (int8 x) => (int8)~(uint8)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator << (int8 x, int n) => (int8)((uint8)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator >> (int8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srai_epi32(x, n);
            }
            else
            {
                return new int8(x._v4_0 >> n, x._v4_4 >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (int8 left, int8 right) => (uint8)left == (uint8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmplt_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 < right._v4_0, left._v4_4 < right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Avx2.mm256_cmpgt_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 > right._v4_0, left._v4_4 > right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (int8 left, int8 right) => (uint8)left != (uint8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse32(Avx2.mm256_cmpgt_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 <= right._v4_0, left._v4_4 <= right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse32(Xse.mm256_cmplt_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 >= right._v4_0, left._v4_4 >= right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int8 other) => ((uint8)this).Equals((uint8)other);

        public override readonly bool Equals(object obj) => obj is int8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((uint8)this).GetHashCode();

        public override readonly string ToString() => $"int8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"int8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}