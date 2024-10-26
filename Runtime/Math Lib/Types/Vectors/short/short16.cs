using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 16 * sizeof(short))]
    [DebuggerTypeProxy(typeof(short16.DebuggerProxy))]
    unsafe public struct short16 : IEquatable<short16>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public short x0;
            public short x1;
            public short x2;
            public short x3;
            public short x4;
            public short x5;
            public short x6;
            public short x7;
            public short x8;
            public short x9;
            public short x10;
            public short x11;
            public short x12;
            public short x13;
            public short x14;
            public short x15;

            public DebuggerProxy(short16 v)
            {
                x0  = v.x0;
                x1  = v.x1;
                x2  = v.x2;
                x3  = v.x3;
                x4  = v.x4;
                x5  = v.x5;
                x6  = v.x6;
                x7  = v.x7;
                x8  = v.x8;
                x9  = v.x9;
                x10 = v.x10;
                x11 = v.x11;
                x12 = v.x12;
                x13 = v.x13;
                x14 = v.x14;
                x15 = v.x15;
            }
        }


        [FieldOffset(0)]  internal short8 _v8_0;
        [FieldOffset(16)] internal short8 _v8_8;

        [FieldOffset(0)]  public short x0;
        [FieldOffset(2)]  public short x1;
        [FieldOffset(4)]  public short x2;
        [FieldOffset(6)]  public short x3;
        [FieldOffset(8)]  public short x4;
        [FieldOffset(10)] public short x5;
        [FieldOffset(12)] public short x6;
        [FieldOffset(14)] public short x7;
        [FieldOffset(16)] public short x8;
        [FieldOffset(18)] public short x9;
        [FieldOffset(20)] public short x10;
        [FieldOffset(22)] public short x11;
        [FieldOffset(24)] public short x12;
        [FieldOffset(26)] public short x13;
        [FieldOffset(28)] public short x14;
        [FieldOffset(30)] public short x15;


        public static short16 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7, short x8, short x9, short x10, short x11, short x12, short x13, short x14, short x15)
        {
            this = (short16)new ushort16((ushort)x0, (ushort)x1, (ushort)x2, (ushort)x3, (ushort)x4, (ushort)x5, (ushort)x6, (ushort)x7, (ushort)x8, (ushort)x9, (ushort)x10, (ushort)x11, (ushort)x12, (ushort)x13, (ushort)x14, (ushort)x15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short x0x16)
        {
            this = (short16)new ushort16((ushort)x0x16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short2 x01, short2 x23, short2 x45, short2 x67, short2 x89, short2 x10_11, short2 x12_13, short2 x14_15)
        {
            this = new short16(new short8(x01, x23, x45, x67), new short8(x89, x10_11, x12_13, x14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short4 x4567, short4 x8_9_10_11, short4 x12_13_14_15)
        {
            this = new short16(new short8(x0123, x4567), new short8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short3 x456, short3 x789, short3 x10_11_12, short3 x13_14_15)
        {
            this = (short16)new ushort16((ushort4)x0123, (ushort3)x456, (ushort3)x789, (ushort3)x10_11_12, (ushort3)x13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short3 x012, short4 x3456, short3 x789, short3 x10_11_12, short3 x13_14_15)
        {
            this = (short16)new ushort16((ushort3)x012, (ushort4)x3456, (ushort3)x789, (ushort3)x10_11_12, (ushort3)x13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short3 x012, short3 x345, short4 x6789, short3 x10_11_12, short3 x13_14_15)
        {
            this = (short16)new ushort16((ushort3)x012, (ushort3)x345, (ushort4)x6789, (ushort3)x10_11_12, (ushort3)x13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short3 x012, short3 x345, short3 x678, short4 x9_10_11_12, short3 x13_14_15)
        {
            this = (short16)new ushort16((ushort3)x012, (ushort3)x345, (ushort3)x678, (ushort4)x9_10_11_12, (ushort3)x13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short3 x012, short3 x345, short3 x678, short3 x9_10_11, short4 x12_13_14_15)
        {
            this = (short16)new ushort16((ushort3)x012, (ushort3)x345, (ushort3)x678, (ushort3)x9_10_11, (ushort4)x12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short8 x01234567, short4 x8_9_10_11, short4 x12_13_14_15)
        {
            this = new short16(x01234567, new short8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short8 x4_5_6_7_8_9_10_11, short4 x12_13_14_15)
        {
            this = (short16)new ushort16((ushort4)x0123, (ushort8)x4_5_6_7_8_9_10_11, (ushort4)x12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short4 x4567, short8 x8_9_10_11_12_13_14_15)
        {
            this = new short16(new short8(x0123, x4567), x8_9_10_11_12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short8 x01234567, short8 x8_9_10_11_12_13_14_15)
        {
            this = (short16)new ushort16((ushort8)x01234567, (ushort8)x8_9_10_11_12_13_14_15);
        }


        #region Shuffle
        public short8 v8_0  { readonly get => (short8)((ushort16)this).v8_0;    set { ushort16 _this = (ushort16)this; _this.v8_0  = (ushort8)value; this = (short16)_this; } }
        public short8 v8_1  { readonly get => (short8)((ushort16)this).v8_1;    set { ushort16 _this = (ushort16)this; _this.v8_1  = (ushort8)value; this = (short16)_this; } }
        public short8 v8_2  { readonly get => (short8)((ushort16)this).v8_2;    set { ushort16 _this = (ushort16)this; _this.v8_2  = (ushort8)value; this = (short16)_this; } }
        public short8 v8_3  { readonly get => (short8)((ushort16)this).v8_3;    set { ushort16 _this = (ushort16)this; _this.v8_3  = (ushort8)value; this = (short16)_this; } }
        public short8 v8_4  { readonly get => (short8)((ushort16)this).v8_4;    set { ushort16 _this = (ushort16)this; _this.v8_4  = (ushort8)value; this = (short16)_this; } }
        public short8 v8_5  { readonly get => (short8)((ushort16)this).v8_5;    set { ushort16 _this = (ushort16)this; _this.v8_5  = (ushort8)value; this = (short16)_this; } }
        public short8 v8_6  { readonly get => (short8)((ushort16)this).v8_6;    set { ushort16 _this = (ushort16)this; _this.v8_6  = (ushort8)value; this = (short16)_this; } }
        public short8 v8_7  { readonly get => (short8)((ushort16)this).v8_7;    set { ushort16 _this = (ushort16)this; _this.v8_7  = (ushort8)value; this = (short16)_this; } }
        public short8 v8_8  { readonly get => (short8)((ushort16)this).v8_8;    set { ushort16 _this = (ushort16)this; _this.v8_8  = (ushort8)value; this = (short16)_this; } }

        public short4 v4_0  { readonly get => (short4)((ushort16)this).v4_0;    set { ushort16 _this = (ushort16)this; _this.v4_0  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_1  { readonly get => (short4)((ushort16)this).v4_1;    set { ushort16 _this = (ushort16)this; _this.v4_1  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_2  { readonly get => (short4)((ushort16)this).v4_2;    set { ushort16 _this = (ushort16)this; _this.v4_2  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_3  { readonly get => (short4)((ushort16)this).v4_3;    set { ushort16 _this = (ushort16)this; _this.v4_3  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_4  { readonly get => (short4)((ushort16)this).v4_4;    set { ushort16 _this = (ushort16)this; _this.v4_4  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_5  { readonly get => (short4)((ushort16)this).v4_5;    set { ushort16 _this = (ushort16)this; _this.v4_5  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_6  { readonly get => (short4)((ushort16)this).v4_6;    set { ushort16 _this = (ushort16)this; _this.v4_6  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_7  { readonly get => (short4)((ushort16)this).v4_7;    set { ushort16 _this = (ushort16)this; _this.v4_7  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_8  { readonly get => (short4)((ushort16)this).v4_8;    set { ushort16 _this = (ushort16)this; _this.v4_8  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_9  { readonly get => (short4)((ushort16)this).v4_9;    set { ushort16 _this = (ushort16)this; _this.v4_9  = (ushort4)value; this = (short16)_this; } }
        public short4 v4_10 { readonly get => (short4)((ushort16)this).v4_10;   set { ushort16 _this = (ushort16)this; _this.v4_10 = (ushort4)value; this = (short16)_this; } }
        public short4 v4_11 { readonly get => (short4)((ushort16)this).v4_11;   set { ushort16 _this = (ushort16)this; _this.v4_11 = (ushort4)value; this = (short16)_this; } }
        public short4 v4_12 { readonly get => (short4)((ushort16)this).v4_12;   set { ushort16 _this = (ushort16)this; _this.v4_12 = (ushort4)value; this = (short16)_this; } }

        public short3 v3_0  { readonly get => (short3)((ushort16)this).v3_0;    set { ushort16 _this = (ushort16)this; _this.v3_0  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_1  { readonly get => (short3)((ushort16)this).v3_1;    set { ushort16 _this = (ushort16)this; _this.v3_1  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_2  { readonly get => (short3)((ushort16)this).v3_2;    set { ushort16 _this = (ushort16)this; _this.v3_2  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_3  { readonly get => (short3)((ushort16)this).v3_3;    set { ushort16 _this = (ushort16)this; _this.v3_3  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_4  { readonly get => (short3)((ushort16)this).v3_4;    set { ushort16 _this = (ushort16)this; _this.v3_4  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_5  { readonly get => (short3)((ushort16)this).v3_5;    set { ushort16 _this = (ushort16)this; _this.v3_5  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_6  { readonly get => (short3)((ushort16)this).v3_6;    set { ushort16 _this = (ushort16)this; _this.v3_6  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_7  { readonly get => (short3)((ushort16)this).v3_7;    set { ushort16 _this = (ushort16)this; _this.v3_7  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_8  { readonly get => (short3)((ushort16)this).v3_8;    set { ushort16 _this = (ushort16)this; _this.v3_8  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_9  { readonly get => (short3)((ushort16)this).v3_9;    set { ushort16 _this = (ushort16)this; _this.v3_9  = (ushort3)value; this = (short16)_this; } }
        public short3 v3_10 { readonly get => (short3)((ushort16)this).v3_10;   set { ushort16 _this = (ushort16)this; _this.v3_10 = (ushort3)value; this = (short16)_this; } }
        public short3 v3_11 { readonly get => (short3)((ushort16)this).v3_11;   set { ushort16 _this = (ushort16)this; _this.v3_11 = (ushort3)value; this = (short16)_this; } }
        public short3 v3_12 { readonly get => (short3)((ushort16)this).v3_12;   set { ushort16 _this = (ushort16)this; _this.v3_12 = (ushort3)value; this = (short16)_this; } }
        public short3 v3_13 { readonly get => (short3)((ushort16)this).v3_13;   set { ushort16 _this = (ushort16)this; _this.v3_13 = (ushort3)value; this = (short16)_this; } }

        public short2 v2_0  { readonly get => (short2)((ushort16)this).v2_0;    set { ushort16 _this = (ushort16)this; _this.v2_0  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_1  { readonly get => (short2)((ushort16)this).v2_1;    set { ushort16 _this = (ushort16)this; _this.v2_1  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_2  { readonly get => (short2)((ushort16)this).v2_2;    set { ushort16 _this = (ushort16)this; _this.v2_2  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_3  { readonly get => (short2)((ushort16)this).v2_3;    set { ushort16 _this = (ushort16)this; _this.v2_3  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_4  { readonly get => (short2)((ushort16)this).v2_4;    set { ushort16 _this = (ushort16)this; _this.v2_4  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_5  { readonly get => (short2)((ushort16)this).v2_5;    set { ushort16 _this = (ushort16)this; _this.v2_5  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_6  { readonly get => (short2)((ushort16)this).v2_6;    set { ushort16 _this = (ushort16)this; _this.v2_6  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_7  { readonly get => (short2)((ushort16)this).v2_7;    set { ushort16 _this = (ushort16)this; _this.v2_7  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_8  { readonly get => (short2)((ushort16)this).v2_8;    set { ushort16 _this = (ushort16)this; _this.v2_8  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_9  { readonly get => (short2)((ushort16)this).v2_9;    set { ushort16 _this = (ushort16)this; _this.v2_9  = (ushort2)value; this = (short16)_this; } }
        public short2 v2_10 { readonly get => (short2)((ushort16)this).v2_10;   set { ushort16 _this = (ushort16)this; _this.v2_10 = (ushort2)value; this = (short16)_this; } }
        public short2 v2_11 { readonly get => (short2)((ushort16)this).v2_11;   set { ushort16 _this = (ushort16)this; _this.v2_11 = (ushort2)value; this = (short16)_this; } }
        public short2 v2_12 { readonly get => (short2)((ushort16)this).v2_12;   set { ushort16 _this = (ushort16)this; _this.v2_12 = (ushort2)value; this = (short16)_this; } }
        public short2 v2_13 { readonly get => (short2)((ushort16)this).v2_13;   set { ushort16 _this = (ushort16)this; _this.v2_13 = (ushort2)value; this = (short16)_this; } }
        public short2 v2_14 { readonly get => (short2)((ushort16)this).v2_14;   set { ushort16 _this = (ushort16)this; _this.v2_14 = (ushort2)value; this = (short16)_this; } }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(short16 input) => new v256{ SShort0 = input.x0, SShort1 = input.x1, SShort2 = input.x2, SShort3 = input.x3, SShort4 = input.x4, SShort5 = input.x5, SShort6 = input.x6, SShort7 = input.x7, SShort8 = input.x8, SShort9 = input.x9, SShort10 = input.x10, SShort11 = input.x11, SShort12 = input.x12, SShort13 = input.x13, SShort14 = input.x14, SShort15 = input.x15 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(v256 input) => new short16{ x0 = input.SShort0, x1 = input.SShort1, x2 = input.SShort2, x3 = input.SShort3, x4 = input.SShort4, x5 = input.SShort5, x6 = input.SShort6, x7 = input.SShort7, x8 = input.SShort8, x9 = input.SShort9, x10 = input.SShort10, x11 = input.SShort11, x12 = input.SShort12, x13 = input.SShort13, x14 = input.SShort14, x15 = input.SShort15 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(short input) => new short16(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short16(ushort16 input) => *(short16*)&input;


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (short)((ushort16)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ushort16 _this = (ushort16)this;
                _this[index] = (ushort)value;
                this = (short16)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator + (short16 left, short16 right) => (short16)((ushort16)left + (ushort16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator - (short16 left, short16 right) => (short16)((ushort16)left - (ushort16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator * (short16 left, short16 right) => (short16)((ushort16)left * (ushort16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator / (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_div_epi16(left, right);
            }
            else
            {
                return new short16(left._v8_0 / right._v8_0, left._v8_8 / right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator % (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rem_epi16(left, right);
            }
            else
            {
                return new short16(left._v8_0 % right._v8_0, left._v8_8 % right._v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator * (short left, short16 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator * (short16 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return new short16((short)(left.x0 * right), (short)(left.x1 * right), (short)(left.x2 * right), (short)(left.x3 * right), (short)(left.x4 * right), (short)(left.x5 * right), (short)(left.x6 * right), (short)(left.x7 * right), (short)(left.x8 * right), (short)(left.x9 * right), (short)(left.x10 * right), (short)(left.x11 * right), (short)(left.x12 * right), (short)(left.x13 * right), (short)(left.x14 * right), (short)(left.x15 * right));
                }
                else
                {
                    return left * (short16)right;
                }
            }
            else
            {
                return new short16(left._v8_0 * right, left._v8_8 * right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator / (short16 left, short right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_constdiv_epi16(left, right);
                    }
                    else
                    {
                        return new short16(Xse.constdiv_epi16(left.v8_0, right), Xse.constdiv_epi16(left.v8_8, right));
                    }
                }
            }

            return left / (short16)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator % (short16 left, short right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_constrem_epi16(left, right);
                    }
                    else
                    {
                        return new short16(Xse.constrem_epi16(left.v8_0, right), Xse.constrem_epi16(left.v8_8, right));
                    }
                }
            }

            return left % (short16)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator & (short16 left, short16 right) => (short16)((ushort16)left & (ushort16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator | (short16 left, short16 right) => (short16)((ushort16)left | (ushort16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ^ (short16 left, short16 right) => (short16)((ushort16)left ^ (ushort16)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator - (short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi16(x);
            }
            else
            {
                return new short16(-x._v8_0, -x._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ++ (short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi16(x);
            }
            else
            {
                return new short16(x._v8_0 + 1, x._v8_8 + 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator -- (short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_epi16(x);
            }
            else
            {
                return new short16(x._v8_0 - 1, x._v8_8 - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ~ (short16 x) => (short16)~(ushort16)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator << (short16 x, int n) => (short16)((ushort16)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator >> (short16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srai_epi16(x, n);
            }
            else
            {
                return new short16(x._v8_0 >> n, x._v8_8 >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (short16 left, short16 right) => (ushort16)left == (ushort16)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.mm256_cmplt_epi16(left, right));
            }
            else
            {
                return new bool16(left._v8_0 < right._v8_0, left._v8_8 < right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Avx2.mm256_cmpgt_epi16(left, right));
            }
            else
            {
                return new bool16(left._v8_0 > right._v8_0, left._v8_8 > right._v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (short16 left, short16 right) => (ushort16)left != (ushort16)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse16(Avx2.mm256_cmpgt_epi16(left, right));
            }
            else
            {
                return new bool16(left._v8_0 <= right._v8_0, left._v8_8 <= right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse16(Avx2.mm256_cmpgt_epi16(right, left));
            }
            else
            {
                return new bool16(left._v8_0 >= right._v8_0, left._v8_8 >= right._v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short16 other) => ((ushort16)this).Equals((ushort16)other);

        public override readonly bool Equals(object obj) => obj is short16 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((ushort16)this).GetHashCode();


        public override readonly string ToString() =>  $"short16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}