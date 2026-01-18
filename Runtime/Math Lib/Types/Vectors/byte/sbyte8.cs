using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(sbyte))]
    [DebuggerTypeProxy(typeof(sbyte8.DebuggerProxy))]
    unsafe public struct sbyte8 : IEquatable<sbyte8>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public sbyte x0;
            public sbyte x1;
            public sbyte x2;
            public sbyte x3;
            public sbyte x4;
            public sbyte x5;
            public sbyte x6;
            public sbyte x7;

            public DebuggerProxy(sbyte8 v)
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


        [FieldOffset(0)] public sbyte x0;
        [FieldOffset(1)] public sbyte x1;
        [FieldOffset(2)] public sbyte x2;
        [FieldOffset(3)] public sbyte x3;
        [FieldOffset(4)] public sbyte x4;
        [FieldOffset(5)] public sbyte x5;
        [FieldOffset(6)] public sbyte x6;
        [FieldOffset(7)] public sbyte x7;


        public static sbyte8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7)
        {
            this = (sbyte8)new byte8((byte)x0, (byte)x1, (byte)x2, (byte)x3, (byte)x4, (byte)x5, (byte)x6, (byte)x7);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte x0x8)
        {
            this = (sbyte8)new byte8((byte)x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte2 x01, sbyte2 x23, sbyte2 x45, sbyte2 x67)
        {
            this = (sbyte8)new byte8((byte2)x01, (byte2)x23, (byte2)x45, (byte2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte2 x01, sbyte3 x234, sbyte3 x567)
        {
            this = (sbyte8)new byte8((byte2)x01, (byte3)x234, (byte3)x567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte3 x012, sbyte2 x34, sbyte3 x567)
        {
            this = (sbyte8)new byte8((byte3)x012, (byte2)x34, (byte3)x567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte3 x012, sbyte3 x345, sbyte2 x67)
        {
            this = (sbyte8)new byte8((byte3)x012, (byte3)x345, (byte2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte4 x0123, sbyte2 x45, sbyte2 x67)
        {
            this = (sbyte8)new byte8((byte4)x0123, (byte2)x45, (byte2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte2 x01, sbyte4 x2345, sbyte2 x67)
        {
            this = (sbyte8)new byte8((byte2)x01, (byte4)x2345, (byte2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte2 x01, sbyte2 x23, sbyte4 x4567)
        {
            this = (sbyte8)new byte8((byte2)x01, (byte2)x23, (byte4)x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte8(sbyte4 x0123, sbyte4 x4567)
        {
            this = (sbyte8)new byte8((byte4)x0123, (byte4)x4567);
        }


        #region Shuffle
        public sbyte4 v4_0  { readonly get => (sbyte4)((byte8)this).v4_0;    set { byte8 _this = (byte8)this; _this.v4_0  = (byte4)value; this = (sbyte8)_this; } }
        public sbyte4 v4_1  { readonly get => (sbyte4)((byte8)this).v4_1;    set { byte8 _this = (byte8)this; _this.v4_1  = (byte4)value; this = (sbyte8)_this; } }
        public sbyte4 v4_2  { readonly get => (sbyte4)((byte8)this).v4_2;    set { byte8 _this = (byte8)this; _this.v4_2  = (byte4)value; this = (sbyte8)_this; } }
        public sbyte4 v4_3  { readonly get => (sbyte4)((byte8)this).v4_3;    set { byte8 _this = (byte8)this; _this.v4_3  = (byte4)value; this = (sbyte8)_this; } }
        public sbyte4 v4_4  { readonly get => (sbyte4)((byte8)this).v4_4;    set { byte8 _this = (byte8)this; _this.v4_4  = (byte4)value; this = (sbyte8)_this; } }

        public sbyte3 v3_0  { readonly get => (sbyte3)((byte8)this).v3_0;    set { byte8 _this = (byte8)this; _this.v3_0  = (byte3)value; this = (sbyte8)_this; } }
        public sbyte3 v3_1  { readonly get => (sbyte3)((byte8)this).v3_1;    set { byte8 _this = (byte8)this; _this.v3_1  = (byte3)value; this = (sbyte8)_this; } }
        public sbyte3 v3_2  { readonly get => (sbyte3)((byte8)this).v3_2;    set { byte8 _this = (byte8)this; _this.v3_2  = (byte3)value; this = (sbyte8)_this; } }
        public sbyte3 v3_3  { readonly get => (sbyte3)((byte8)this).v3_3;    set { byte8 _this = (byte8)this; _this.v3_3  = (byte3)value; this = (sbyte8)_this; } }
        public sbyte3 v3_4  { readonly get => (sbyte3)((byte8)this).v3_4;    set { byte8 _this = (byte8)this; _this.v3_4  = (byte3)value; this = (sbyte8)_this; } }
        public sbyte3 v3_5  { readonly get => (sbyte3)((byte8)this).v3_5;    set { byte8 _this = (byte8)this; _this.v3_5  = (byte3)value; this = (sbyte8)_this; } }

        public sbyte2 v2_0  { readonly get => (sbyte2)((byte8)this).v2_0;    set { byte8 _this = (byte8)this; _this.v2_0  = (byte2)value; this = (sbyte8)_this; } }
        public sbyte2 v2_1  { readonly get => (sbyte2)((byte8)this).v2_1;    set { byte8 _this = (byte8)this; _this.v2_1  = (byte2)value; this = (sbyte8)_this; } }
        public sbyte2 v2_2  { readonly get => (sbyte2)((byte8)this).v2_2;    set { byte8 _this = (byte8)this; _this.v2_2  = (byte2)value; this = (sbyte8)_this; } }
        public sbyte2 v2_3  { readonly get => (sbyte2)((byte8)this).v2_3;    set { byte8 _this = (byte8)this; _this.v2_3  = (byte2)value; this = (sbyte8)_this; } }
        public sbyte2 v2_4  { readonly get => (sbyte2)((byte8)this).v2_4;    set { byte8 _this = (byte8)this; _this.v2_4  = (byte2)value; this = (sbyte8)_this; } }
        public sbyte2 v2_5  { readonly get => (sbyte2)((byte8)this).v2_5;    set { byte8 _this = (byte8)this; _this.v2_5  = (byte2)value; this = (sbyte8)_this; } }
        public sbyte2 v2_6  { readonly get => (sbyte2)((byte8)this).v2_6;    set { byte8 _this = (byte8)this; _this.v2_6  = (byte2)value; this = (sbyte8)_this; } }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte8 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte8(v128 input) => RegisterConversion.ToAbstraction128<sbyte8>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte8(sbyte input) => new sbyte8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(byte8 input) => *(sbyte8*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(ushort8 input) => (sbyte8)(byte8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(short8 input) => (sbyte8)(byte8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(uint8 input) => (sbyte8)(byte8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(int8 input) => (sbyte8)(byte8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(half8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(input);
            }
            else
            {
                return new sbyte8((sbyte)maxmath.BASE_cvtf16i32(input.x0, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.x1, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.x2, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.x3, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.x4, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.x5, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.x6, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.x7, signed: true, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(float8 input) => (sbyte8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(sbyte8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi16(input);
            }
            else
            {
                return new ushort8((ushort)input.x0, (ushort)input.x1, (ushort)input.x2, (ushort)input.x3, (ushort)input.x4, (ushort)input.x5, (ushort)input.x6, (ushort)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(sbyte8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi16(input);
            }
            else
            {
                return new short8((short)input.x0, (short)input.x1, (short)input.x2, (short)input.x3, (short)input.x4, (short)input.x5, (short)input.x6, (short)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(sbyte8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi32(input);
            }
            else
            {
                return new uint8((uint4)input.v4_0, (uint4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(sbyte8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi32(input);
            }
            else
            {
                return new int8((int4)input.v4_0, (int4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(sbyte8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_ph(input);
            }
            else
            {
                return (half8)(float8)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(sbyte8 input) => (float8)(int8)input;


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (sbyte)((byte8)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte8 _this = (byte8)this;
                _this[index] = (byte)value;
                this = (sbyte8)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator + (sbyte8 left, sbyte8 right) => (sbyte8)((byte8)left + (byte8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator - (sbyte8 left, sbyte8 right) => (sbyte8)((byte8)left - (byte8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator * (sbyte8 left, sbyte8 right) => (sbyte8)((byte8)left * (byte8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator / (sbyte8 left, sbyte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi8(left, right, false, 8);
            }
            else
            {
                return new sbyte8((sbyte)(left.x0 / right.x0), (sbyte)(left.x1 / right.x1), (sbyte)(left.x2 / right.x2), (sbyte)(left.x3 / right.x3), (sbyte)(left.x4 / right.x4), (sbyte)(left.x5 / right.x5), (sbyte)(left.x6 / right.x6), (sbyte)(left.x7 / right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator % (sbyte8 left, sbyte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi8(left, right, 8);
            }
            else
            {
                return new sbyte8((sbyte)(left.x0 % right.x0), (sbyte)(left.x1 % right.x1), (sbyte)(left.x2 % right.x2), (sbyte)(left.x3 % right.x3), (sbyte)(left.x4 % right.x4), (sbyte)(left.x5 % right.x5), (sbyte)(left.x6 % right.x6), (sbyte)(left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator * (sbyte left, sbyte8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator * (sbyte8 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epi8(left, right, 8);
                }
            }

            return left * (sbyte8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator / (sbyte8 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi8(left, right, 8);
                }
            }

            return left / (sbyte8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator % (sbyte8 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi8(left, right, 8);
                }
            }

            return left % (sbyte8)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator & (sbyte8 left, sbyte8 right) => (sbyte8)((byte8)left & (byte8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator | (sbyte8 left, sbyte8 right) => (sbyte8)((byte8)left | (byte8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator ^ (sbyte8 left, sbyte8 right) => (sbyte8)((byte8)left ^ (byte8)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator - (sbyte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return new sbyte8((sbyte)(-x.x0), (sbyte)(-x.x1), (sbyte)(-x.x2), (sbyte)(-x.x3), (sbyte)(-x.x4), (sbyte)(-x.x5), (sbyte)(-x.x6), (sbyte)(-x.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator ++ (sbyte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new sbyte8((sbyte)(x.x0 + 1), (sbyte)(x.x1 + 1), (sbyte)(x.x2 + 1), (sbyte)(x.x3 + 1), (sbyte)(x.x4 + 1), (sbyte)(x.x5 + 1), (sbyte)(x.x6 + 1), (sbyte)(x.x7 + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator -- (sbyte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new sbyte8((sbyte)(x.x0 - 1), (sbyte)(x.x1 - 1), (sbyte)(x.x2 - 1), (sbyte)(x.x3 - 1), (sbyte)(x.x4 - 1), (sbyte)(x.x5 - 1), (sbyte)(x.x6 - 1), (sbyte)(x.x7 - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator ~ (sbyte8 x) => (sbyte8)~(byte8)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator << (sbyte8 x, int n) => (sbyte8)((byte8)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator >> (sbyte8 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi8(x, n, inRange: true, elements: 8);
            }
            else
            {
                return new sbyte8((sbyte)(x.x0 >> n), (sbyte)(x.x1 >> n), (sbyte)(x.x2 >> n), (sbyte)(x.x3 >> n), (sbyte)(x.x4 >> n), (sbyte)(x.x5 >> n), (sbyte)(x.x6 >> n), (sbyte)(x.x7 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (sbyte8 left, sbyte8 right) => (byte8)left == (byte8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (sbyte8 left, sbyte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new bool8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (sbyte8 left, sbyte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool8(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (sbyte8 left, sbyte8 right) => (byte8)left != (byte8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (sbyte8 left, sbyte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsFalse8(Xse.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (sbyte8 left, sbyte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsFalse8(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new bool8(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte8 other) => ((byte8)this).Equals((byte8)other);

        public override readonly bool Equals(object obj) => obj is sbyte8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((byte8)this).GetHashCode();


        public override readonly string ToString() => $"sbyte8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}