using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 16 * sizeof(sbyte))]
    [DebuggerTypeProxy(typeof(sbyte16.DebuggerProxy))]
    unsafe public struct sbyte16 : IEquatable<sbyte16>, IFormattable
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
            public sbyte x8;
            public sbyte x9;
            public sbyte x10;
            public sbyte x11;
            public sbyte x12;
            public sbyte x13;
            public sbyte x14;
            public sbyte x15;

            public DebuggerProxy(sbyte16 v)
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


        [FieldOffset(0)]  public sbyte x0;
        [FieldOffset(1)]  public sbyte x1;
        [FieldOffset(2)]  public sbyte x2;
        [FieldOffset(3)]  public sbyte x3;
        [FieldOffset(4)]  public sbyte x4;
        [FieldOffset(5)]  public sbyte x5;
        [FieldOffset(6)]  public sbyte x6;
        [FieldOffset(7)]  public sbyte x7;
        [FieldOffset(8)]  public sbyte x8;
        [FieldOffset(9)]  public sbyte x9;
        [FieldOffset(10)] public sbyte x10;
        [FieldOffset(11)] public sbyte x11;
        [FieldOffset(12)] public sbyte x12;
        [FieldOffset(13)] public sbyte x13;
        [FieldOffset(14)] public sbyte x14;
        [FieldOffset(15)] public sbyte x15;


        public static sbyte16 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15)
        {
            this = (sbyte16)new byte16((byte)x0, (byte)x1, (byte)x2, (byte)x3, (byte)x4, (byte)x5, (byte)x6, (byte)x7, (byte)x8, (byte)x9, (byte)x10, (byte)x11, (byte)x12, (byte)x13, (byte)x14, (byte)x15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte x0x16)
        {
            this = (sbyte16)new byte16((byte)x0x16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte2 x01, sbyte2 x23, sbyte2 x45, sbyte2 x67, sbyte2 x89, sbyte2 x10_11, sbyte2 x12_13, sbyte2 x14_15)
        {
            this = new sbyte16(new sbyte8(x01, x23, x45, x67), new sbyte8(x89, x10_11, x12_13, x14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte4 x4567, sbyte4 x8_9_10_11, sbyte4 x12_13_14_15)
        {
            this = new sbyte16(new sbyte8(x0123, x4567), new sbyte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte3 x456, sbyte3 x789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            this = (sbyte16)new byte16((byte4)x0123, (byte3)x456, (byte3)x789, (byte3)x10_11_12, (byte3)x13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte3 x012, sbyte4 x3456, sbyte3 x789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            this = (sbyte16)new byte16((byte3)x012, (byte4)x3456, (byte3)x789, (byte3)x10_11_12, (byte3)x13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte4 x6789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            this = (sbyte16)new byte16((byte3)x012, (byte3)x345, (byte4)x6789, (byte3)x10_11_12, (byte3)x13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte3 x678, sbyte4 x9_10_11_12, sbyte3 x13_14_15)
        {
            this = (sbyte16)new byte16((byte3)x012, (byte3)x345, (byte3)x678, (byte4)x9_10_11_12, (byte3)x13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte3 x678, sbyte3 x9_10_11, sbyte4 x12_13_14_15)
        {
            this = (sbyte16)new byte16((byte3)x012, (byte3)x345, (byte3)x678, (byte3)x9_10_11, (byte4)x12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte8 x01234567, sbyte4 x8_9_10_11, sbyte4 x12_13_14_15)
        {
            this = new sbyte16(x01234567, new sbyte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte8 x4_5_6_7_8_9_10_11, sbyte4 x12_13_14_15)
        {
            this = (sbyte16)new byte16((byte4)x0123, (byte8)x4_5_6_7_8_9_10_11, (byte4)x12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte4 x4567, sbyte8 x8_9_10_11_12_13_14_15)
        {
            this = new sbyte16(new sbyte8(x0123, x4567), x8_9_10_11_12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte8 x01234567, sbyte8 x8_9_10_11_12_13_14_15)
        {
            this = (sbyte16)new byte16((byte8)x01234567, (byte8)x8_9_10_11_12_13_14_15);
        }


        #region Shuffle
        public sbyte8 v8_0  { readonly get => (sbyte8)((byte16)this).v8_0;    set { byte16 _this = (byte16)this; _this.v8_0  = (byte8)value; this = (sbyte16)_this; } }
        public sbyte8 v8_1  { readonly get => (sbyte8)((byte16)this).v8_1;    set { byte16 _this = (byte16)this; _this.v8_1  = (byte8)value; this = (sbyte16)_this; } }
        public sbyte8 v8_2  { readonly get => (sbyte8)((byte16)this).v8_2;    set { byte16 _this = (byte16)this; _this.v8_2  = (byte8)value; this = (sbyte16)_this; } }
        public sbyte8 v8_3  { readonly get => (sbyte8)((byte16)this).v8_3;    set { byte16 _this = (byte16)this; _this.v8_3  = (byte8)value; this = (sbyte16)_this; } }
        public sbyte8 v8_4  { readonly get => (sbyte8)((byte16)this).v8_4;    set { byte16 _this = (byte16)this; _this.v8_4  = (byte8)value; this = (sbyte16)_this; } }
        public sbyte8 v8_5  { readonly get => (sbyte8)((byte16)this).v8_5;    set { byte16 _this = (byte16)this; _this.v8_5  = (byte8)value; this = (sbyte16)_this; } }
        public sbyte8 v8_6  { readonly get => (sbyte8)((byte16)this).v8_6;    set { byte16 _this = (byte16)this; _this.v8_6  = (byte8)value; this = (sbyte16)_this; } }
        public sbyte8 v8_7  { readonly get => (sbyte8)((byte16)this).v8_7;    set { byte16 _this = (byte16)this; _this.v8_7  = (byte8)value; this = (sbyte16)_this; } }
        public sbyte8 v8_8  { readonly get => (sbyte8)((byte16)this).v8_8;    set { byte16 _this = (byte16)this; _this.v8_8  = (byte8)value; this = (sbyte16)_this; } }

        public sbyte4 v4_0  { readonly get => (sbyte4)((byte16)this).v4_0;    set { byte16 _this = (byte16)this; _this.v4_0  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_1  { readonly get => (sbyte4)((byte16)this).v4_1;    set { byte16 _this = (byte16)this; _this.v4_1  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_2  { readonly get => (sbyte4)((byte16)this).v4_2;    set { byte16 _this = (byte16)this; _this.v4_2  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_3  { readonly get => (sbyte4)((byte16)this).v4_3;    set { byte16 _this = (byte16)this; _this.v4_3  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_4  { readonly get => (sbyte4)((byte16)this).v4_4;    set { byte16 _this = (byte16)this; _this.v4_4  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_5  { readonly get => (sbyte4)((byte16)this).v4_5;    set { byte16 _this = (byte16)this; _this.v4_5  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_6  { readonly get => (sbyte4)((byte16)this).v4_6;    set { byte16 _this = (byte16)this; _this.v4_6  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_7  { readonly get => (sbyte4)((byte16)this).v4_7;    set { byte16 _this = (byte16)this; _this.v4_7  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_8  { readonly get => (sbyte4)((byte16)this).v4_8;    set { byte16 _this = (byte16)this; _this.v4_8  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_9  { readonly get => (sbyte4)((byte16)this).v4_9;    set { byte16 _this = (byte16)this; _this.v4_9  = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_10 { readonly get => (sbyte4)((byte16)this).v4_10;   set { byte16 _this = (byte16)this; _this.v4_10 = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_11 { readonly get => (sbyte4)((byte16)this).v4_11;   set { byte16 _this = (byte16)this; _this.v4_11 = (byte4)value; this = (sbyte16)_this; } }
        public sbyte4 v4_12 { readonly get => (sbyte4)((byte16)this).v4_12;   set { byte16 _this = (byte16)this; _this.v4_12 = (byte4)value; this = (sbyte16)_this; } }

        public sbyte3 v3_0  { readonly get => (sbyte3)((byte16)this).v3_0;    set { byte16 _this = (byte16)this; _this.v3_0  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_1  { readonly get => (sbyte3)((byte16)this).v3_1;    set { byte16 _this = (byte16)this; _this.v3_1  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_2  { readonly get => (sbyte3)((byte16)this).v3_2;    set { byte16 _this = (byte16)this; _this.v3_2  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_3  { readonly get => (sbyte3)((byte16)this).v3_3;    set { byte16 _this = (byte16)this; _this.v3_3  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_4  { readonly get => (sbyte3)((byte16)this).v3_4;    set { byte16 _this = (byte16)this; _this.v3_4  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_5  { readonly get => (sbyte3)((byte16)this).v3_5;    set { byte16 _this = (byte16)this; _this.v3_5  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_6  { readonly get => (sbyte3)((byte16)this).v3_6;    set { byte16 _this = (byte16)this; _this.v3_6  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_7  { readonly get => (sbyte3)((byte16)this).v3_7;    set { byte16 _this = (byte16)this; _this.v3_7  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_8  { readonly get => (sbyte3)((byte16)this).v3_8;    set { byte16 _this = (byte16)this; _this.v3_8  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_9  { readonly get => (sbyte3)((byte16)this).v3_9;    set { byte16 _this = (byte16)this; _this.v3_9  = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_10 { readonly get => (sbyte3)((byte16)this).v3_10;   set { byte16 _this = (byte16)this; _this.v3_10 = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_11 { readonly get => (sbyte3)((byte16)this).v3_11;   set { byte16 _this = (byte16)this; _this.v3_11 = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_12 { readonly get => (sbyte3)((byte16)this).v3_12;   set { byte16 _this = (byte16)this; _this.v3_12 = (byte3)value; this = (sbyte16)_this; } }
        public sbyte3 v3_13 { readonly get => (sbyte3)((byte16)this).v3_13;   set { byte16 _this = (byte16)this; _this.v3_13 = (byte3)value; this = (sbyte16)_this; } }

        public sbyte2 v2_0  { readonly get => (sbyte2)((byte16)this).v2_0;    set { byte16 _this = (byte16)this; _this.v2_0  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_1  { readonly get => (sbyte2)((byte16)this).v2_1;    set { byte16 _this = (byte16)this; _this.v2_1  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_2  { readonly get => (sbyte2)((byte16)this).v2_2;    set { byte16 _this = (byte16)this; _this.v2_2  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_3  { readonly get => (sbyte2)((byte16)this).v2_3;    set { byte16 _this = (byte16)this; _this.v2_3  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_4  { readonly get => (sbyte2)((byte16)this).v2_4;    set { byte16 _this = (byte16)this; _this.v2_4  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_5  { readonly get => (sbyte2)((byte16)this).v2_5;    set { byte16 _this = (byte16)this; _this.v2_5  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_6  { readonly get => (sbyte2)((byte16)this).v2_6;    set { byte16 _this = (byte16)this; _this.v2_6  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_7  { readonly get => (sbyte2)((byte16)this).v2_7;    set { byte16 _this = (byte16)this; _this.v2_7  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_8  { readonly get => (sbyte2)((byte16)this).v2_8;    set { byte16 _this = (byte16)this; _this.v2_8  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_9  { readonly get => (sbyte2)((byte16)this).v2_9;    set { byte16 _this = (byte16)this; _this.v2_9  = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_10 { readonly get => (sbyte2)((byte16)this).v2_10;   set { byte16 _this = (byte16)this; _this.v2_10 = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_11 { readonly get => (sbyte2)((byte16)this).v2_11;   set { byte16 _this = (byte16)this; _this.v2_11 = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_12 { readonly get => (sbyte2)((byte16)this).v2_12;   set { byte16 _this = (byte16)this; _this.v2_12 = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_13 { readonly get => (sbyte2)((byte16)this).v2_13;   set { byte16 _this = (byte16)this; _this.v2_13 = (byte2)value; this = (sbyte16)_this; } }
        public sbyte2 v2_14 { readonly get => (sbyte2)((byte16)this).v2_14;   set { byte16 _this = (byte16)this; _this.v2_14 = (byte2)value; this = (sbyte16)_this; } }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte16 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte16(v128 input) => RegisterConversion.ToAbstraction128<sbyte16>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte16(sbyte input) => new sbyte16(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(byte16 input) => *(sbyte16*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(short16 input) => (sbyte16)(byte16)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(ushort16 input) => (sbyte16)(byte16)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(half16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi8(input);
            }
            else
            {
                return new sbyte16((sbyte8)input.v8_0, (sbyte8)input.v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(sbyte16 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Cast.SByte16ToShort16(input);
            }
            else
            {
                return new short16((short8)input.v8_0, (short8)input.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort16(sbyte16 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort16)Cast.SByte16ToShort16(input);
            }
            else
            {
                return new ushort16((ushort8)input.v8_0, (ushort8)input.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half16(sbyte16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi8_ph(input);
            }
            else
            {
                return new half16((half8)input.v8_0, (half8)input.v8_8);
            }
        }


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (sbyte)((byte16)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte16 _this = (byte16)this;
                _this[index] = (byte)value;
                this = (sbyte16)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator + (sbyte16 left, sbyte16 right) => (sbyte16)((byte16)left + (byte16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator - (sbyte16 left, sbyte16 right) => (sbyte16)((byte16)left - (byte16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator * (sbyte16 left, sbyte16 right) => (sbyte16)((byte16)left * (byte16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator / (sbyte16 left, sbyte16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi8(left, right, false, 16);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 / right.x0), (sbyte)(left.x1 / right.x1), (sbyte)(left.x2 / right.x2), (sbyte)(left.x3 / right.x3), (sbyte)(left.x4 / right.x4), (sbyte)(left.x5 / right.x5), (sbyte)(left.x6 / right.x6), (sbyte)(left.x7 / right.x7), (sbyte)(left.x8 / right.x8), (sbyte)(left.x9 / right.x9), (sbyte)(left.x10 / right.x10), (sbyte)(left.x11 / right.x11), (sbyte)(left.x12 / right.x12), (sbyte)(left.x13 / right.x13), (sbyte)(left.x14 / right.x14), (sbyte)(left.x15 / right.x15));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator % (sbyte16 left, sbyte16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi8(left, right, 16);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 % right.x0), (sbyte)(left.x1 % right.x1), (sbyte)(left.x2 % right.x2), (sbyte)(left.x3 % right.x3), (sbyte)(left.x4 % right.x4), (sbyte)(left.x5 % right.x5), (sbyte)(left.x6 % right.x6), (sbyte)(left.x7 % right.x7), (sbyte)(left.x8 % right.x8), (sbyte)(left.x9 % right.x9), (sbyte)(left.x10 % right.x10), (sbyte)(left.x11 % right.x11), (sbyte)(left.x12 % right.x12), (sbyte)(left.x13 % right.x13), (sbyte)(left.x14 % right.x14), (sbyte)(left.x15 % right.x15));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator * (sbyte left, sbyte16 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator * (sbyte16 left, sbyte right)
        {
            if (constexpr.IS_CONST(right))
            {
                return new sbyte16((sbyte)(left.x0 * right), (sbyte)(left.x1 * right), (sbyte)(left.x2 * right), (sbyte)(left.x3 * right), (sbyte)(left.x4 * right), (sbyte)(left.x5 * right), (sbyte)(left.x6 * right), (sbyte)(left.x7 * right), (sbyte)(left.x8 * right), (sbyte)(left.x9 * right), (sbyte)(left.x10 * right), (sbyte)(left.x11 * right), (sbyte)(left.x12 * right), (sbyte)(left.x13 * right), (sbyte)(left.x14 * right), (sbyte)(left.x15 * right));
            }
            else
            {
                return left * (sbyte16)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator / (sbyte16 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi8(left, right, 16);
                }
            }

            return left / (sbyte16)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator % (sbyte16 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi8(left, right, 16);
                }
            }

            return left % (sbyte16)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator & (sbyte16 left, sbyte16 right) => (sbyte16)((byte16)left & (byte16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator | (sbyte16 left, sbyte16 right) => (sbyte16)((byte16)left | (byte16)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ^ (sbyte16 left, sbyte16 right) => (sbyte16)((byte16)left ^ (byte16)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator - (sbyte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return new sbyte16((sbyte)(-x.x0), (sbyte)(-x.x1), (sbyte)(-x.x2), (sbyte)(-x.x3), (sbyte)(-x.x4), (sbyte)(-x.x5), (sbyte)(-x.x6), (sbyte)(-x.x7), (sbyte)(-x.x8), (sbyte)(-x.x9), (sbyte)(-x.x10), (sbyte)(-x.x11), (sbyte)(-x.x12), (sbyte)(-x.x13), (sbyte)(-x.x14), (sbyte)(-x.x15));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ++ (sbyte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new sbyte16((sbyte)(x.x0 + 1), (sbyte)(x.x1 + 1), (sbyte)(x.x2 + 1), (sbyte)(x.x3 + 1), (sbyte)(x.x4 + 1), (sbyte)(x.x5 + 1), (sbyte)(x.x6 + 1), (sbyte)(x.x7 + 1), (sbyte)(x.x8 + 1), (sbyte)(x.x9 + 1), (sbyte)(x.x10 + 1), (sbyte)(x.x11 + 1), (sbyte)(x.x12 + 1), (sbyte)(x.x13 + 1), (sbyte)(x.x14 + 1), (sbyte)(x.x15 + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator -- (sbyte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new sbyte16((sbyte)(x.x0 - 1), (sbyte)(x.x1 - 1), (sbyte)(x.x2 - 1), (sbyte)(x.x3 - 1), (sbyte)(x.x4 - 1), (sbyte)(x.x5 - 1), (sbyte)(x.x6 - 1), (sbyte)(x.x7 - 1), (sbyte)(x.x8 - 1), (sbyte)(x.x9 - 1), (sbyte)(x.x10 - 1), (sbyte)(x.x11 - 1), (sbyte)(x.x12 - 1), (sbyte)(x.x13 - 1), (sbyte)(x.x14 - 1), (sbyte)(x.x15 - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ~ (sbyte16 x) => (sbyte16)~(byte16)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator << (sbyte16 x, int n) => (sbyte16)((byte16)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator >> (sbyte16 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi8(x, n, inRange: true);
            }
            else
            {
                return new sbyte16((sbyte)(x.x0 >> n), (sbyte)(x.x1 >> n), (sbyte)(x.x2 >> n), (sbyte)(x.x3 >> n), (sbyte)(x.x4 >> n), (sbyte)(x.x5 >> n), (sbyte)(x.x6 >> n), (sbyte)(x.x7 >> n), (sbyte)(x.x8 >> n), (sbyte)(x.x9 >> n), (sbyte)(x.x10 >> n), (sbyte)(x.x11 >> n), (sbyte)(x.x12 >> n), (sbyte)(x.x13 >> n), (sbyte)(x.x14 >> n), (sbyte)(x.x15 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (sbyte16 left, sbyte16 right) => (byte16)left == (byte16)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (sbyte16 left, sbyte16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7, left.x8 < right.x8, left.x9 < right.x9, left.x10 < right.x10, left.x11 < right.x11, left.x12 < right.x12, left.x13 < right.x13, left.x14 < right.x14, left.x15 < right.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (sbyte16 left, sbyte16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7, left.x8 > right.x8, left.x9 > right.x9, left.x10 > right.x10, left.x11 > right.x11, left.x12 > right.x12, left.x13 > right.x13, left.x14 > right.x14, left.x15 > right.x15);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (sbyte16 left, sbyte16 right) => (byte16)left != (byte16)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (sbyte16 left, sbyte16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsFalse8(Xse.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7, left.x8 <= right.x8, left.x9 <= right.x9, left.x10 <= right.x10, left.x11 <= right.x11, left.x12 <= right.x12, left.x13 <= right.x13, left.x14 <= right.x14, left.x15 <= right.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (sbyte16 left, sbyte16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsFalse8(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7, left.x8 >= right.x8, left.x9 >= right.x9, left.x10 >= right.x10, left.x11 >= right.x11, left.x12 >= right.x12, left.x13 >= right.x13, left.x14 >= right.x14, left.x15 >= right.x15);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte16 other) => ((byte16)this).Equals((byte16)other);

        public override readonly bool Equals(object obj) => obj is sbyte16 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((byte16)this).GetHashCode();


        public override readonly string ToString() => $"({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}