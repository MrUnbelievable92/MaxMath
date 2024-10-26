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
    [StructLayout(LayoutKind.Explicit, Size = 32 * sizeof(sbyte))]
    [DebuggerTypeProxy(typeof(sbyte32.DebuggerProxy))]
    unsafe public struct sbyte32 : IEquatable<sbyte32>, IFormattable
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
            public sbyte x16;
            public sbyte x17;
            public sbyte x18;
            public sbyte x19;
            public sbyte x20;
            public sbyte x21;
            public sbyte x22;
            public sbyte x23;
            public sbyte x24;
            public sbyte x25;
            public sbyte x26;
            public sbyte x27;
            public sbyte x28;
            public sbyte x29;
            public sbyte x30;
            public sbyte x31;

            public DebuggerProxy(sbyte32 v)
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
                x16 = v.x16;
                x17 = v.x17;
                x18 = v.x18;
                x19 = v.x19;
                x20 = v.x20;
                x21 = v.x21;
                x22 = v.x22;
                x23 = v.x23;
                x24 = v.x24;
                x25 = v.x25;
                x26 = v.x26;
                x27 = v.x27;
                x28 = v.x28;
                x29 = v.x29;
                x30 = v.x30;
                x31 = v.x31;
            }
        }


        [FieldOffset(0)]  internal sbyte16 _v16_0;
        [FieldOffset(16)] internal sbyte16 _v16_16;

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
        [FieldOffset(16)] public sbyte x16;
        [FieldOffset(17)] public sbyte x17;
        [FieldOffset(18)] public sbyte x18;
        [FieldOffset(19)] public sbyte x19;
        [FieldOffset(20)] public sbyte x20;
        [FieldOffset(21)] public sbyte x21;
        [FieldOffset(22)] public sbyte x22;
        [FieldOffset(23)] public sbyte x23;
        [FieldOffset(24)] public sbyte x24;
        [FieldOffset(25)] public sbyte x25;
        [FieldOffset(26)] public sbyte x26;
        [FieldOffset(27)] public sbyte x27;
        [FieldOffset(28)] public sbyte x28;
        [FieldOffset(29)] public sbyte x29;
        [FieldOffset(30)] public sbyte x30;
        [FieldOffset(31)] public sbyte x31;


        public static sbyte32 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15, sbyte x16, sbyte x17, sbyte x18, sbyte x19, sbyte x20, sbyte x21, sbyte x22, sbyte x23, sbyte x24, sbyte x25, sbyte x26, sbyte x27, sbyte x28, sbyte x29, sbyte x30, sbyte x31)
        {
            this = (sbyte32)new byte32((byte)x0, (byte)x1, (byte)x2, (byte)x3, (byte)x4, (byte)x5, (byte)x6, (byte)x7, (byte)x8, (byte)x9, (byte)x10, (byte)x11, (byte)x12, (byte)x13, (byte)x14, (byte)x15, (byte)x16, (byte)x17, (byte)x18, (byte)x19, (byte)x20, (byte)x21, (byte)x22, (byte)x23, (byte)x24, (byte)x25, (byte)x26, (byte)x27, (byte)x28, (byte)x29, (byte)x30, (byte)x31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte x0x32)
        {
            this = (sbyte32)new byte32((byte)x0x32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte4 x0_3, sbyte4 x4_7, sbyte4 x8_11, sbyte4 x12_15, sbyte4 x16_19, sbyte4 x20_23, sbyte4 x24_27, sbyte4 x28_31)
        {
            this = new sbyte32(new sbyte16(x0_3, x4_7, x8_11, x12_15), new sbyte16(x16_19, x20_23, x24_27, x28_31));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte8 v8_0, sbyte8 v8_8, sbyte8 v8_16, sbyte8 v8_24)
        {
            this = new sbyte32(new sbyte16(v8_0, v8_8), new sbyte16(v8_16, v8_24));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte16 v16_0, sbyte8 v8_16, sbyte8 v8_24)
        {
            this = new sbyte32(v16_0, new sbyte16(v8_16, v8_24));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte8 v8_0, sbyte16 v16_8, sbyte8 v8_24)
        {
            this = (sbyte32)new byte32((byte8)v8_0, (byte16)v16_8, (byte8)v8_24);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte8 v8_0, sbyte8 v8_8, sbyte16 v16_16)
        {
            this = new sbyte32(new sbyte16(v8_0, v8_8), v16_16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte16 v16_0, sbyte16 v16_16)
        {
            this = (sbyte32)new byte32((byte16)v16_0, (byte16)v16_16);
        }



        #region Shuffle
        public sbyte16 v16_0  { readonly get => (sbyte16)((byte32)this).v16_0;    set { byte32 _this = (byte32)this; _this.v16_0  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_1  { readonly get => (sbyte16)((byte32)this).v16_1;    set { byte32 _this = (byte32)this; _this.v16_1  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_2  { readonly get => (sbyte16)((byte32)this).v16_2;    set { byte32 _this = (byte32)this; _this.v16_2  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_3  { readonly get => (sbyte16)((byte32)this).v16_3;    set { byte32 _this = (byte32)this; _this.v16_3  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_4  { readonly get => (sbyte16)((byte32)this).v16_4;    set { byte32 _this = (byte32)this; _this.v16_4  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_5  { readonly get => (sbyte16)((byte32)this).v16_5;    set { byte32 _this = (byte32)this; _this.v16_5  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_6  { readonly get => (sbyte16)((byte32)this).v16_6;    set { byte32 _this = (byte32)this; _this.v16_6  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_7  { readonly get => (sbyte16)((byte32)this).v16_7;    set { byte32 _this = (byte32)this; _this.v16_7  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_8  { readonly get => (sbyte16)((byte32)this).v16_8;    set { byte32 _this = (byte32)this; _this.v16_8  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_9  { readonly get => (sbyte16)((byte32)this).v16_9;    set { byte32 _this = (byte32)this; _this.v16_9  = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_10 { readonly get => (sbyte16)((byte32)this).v16_10;   set { byte32 _this = (byte32)this; _this.v16_10 = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_11 { readonly get => (sbyte16)((byte32)this).v16_11;   set { byte32 _this = (byte32)this; _this.v16_11 = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_12 { readonly get => (sbyte16)((byte32)this).v16_12;   set { byte32 _this = (byte32)this; _this.v16_12 = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_13 { readonly get => (sbyte16)((byte32)this).v16_13;   set { byte32 _this = (byte32)this; _this.v16_13 = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_14 { readonly get => (sbyte16)((byte32)this).v16_14;   set { byte32 _this = (byte32)this; _this.v16_14 = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_15 { readonly get => (sbyte16)((byte32)this).v16_15;   set { byte32 _this = (byte32)this; _this.v16_15 = (byte16)value; this = (sbyte32)_this; } }
        public sbyte16 v16_16 { readonly get => (sbyte16)((byte32)this).v16_16;   set { byte32 _this = (byte32)this; _this.v16_16 = (byte16)value; this = (sbyte32)_this; } }

        public sbyte8 v8_0  { readonly get => (sbyte8)((byte32)this).v8_0;    set { byte32 _this = (byte32)this; _this.v8_0  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_1  { readonly get => (sbyte8)((byte32)this).v8_1;    set { byte32 _this = (byte32)this; _this.v8_1  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_2  { readonly get => (sbyte8)((byte32)this).v8_2;    set { byte32 _this = (byte32)this; _this.v8_2  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_3  { readonly get => (sbyte8)((byte32)this).v8_3;    set { byte32 _this = (byte32)this; _this.v8_3  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_4  { readonly get => (sbyte8)((byte32)this).v8_4;    set { byte32 _this = (byte32)this; _this.v8_4  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_5  { readonly get => (sbyte8)((byte32)this).v8_5;    set { byte32 _this = (byte32)this; _this.v8_5  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_6  { readonly get => (sbyte8)((byte32)this).v8_6;    set { byte32 _this = (byte32)this; _this.v8_6  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_7  { readonly get => (sbyte8)((byte32)this).v8_7;    set { byte32 _this = (byte32)this; _this.v8_7  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_8  { readonly get => (sbyte8)((byte32)this).v8_8;    set { byte32 _this = (byte32)this; _this.v8_8  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_9  { readonly get => (sbyte8)((byte32)this).v8_9;    set { byte32 _this = (byte32)this; _this.v8_9  = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_10 { readonly get => (sbyte8)((byte32)this).v8_10;   set { byte32 _this = (byte32)this; _this.v8_10 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_11 { readonly get => (sbyte8)((byte32)this).v8_11;   set { byte32 _this = (byte32)this; _this.v8_11 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_12 { readonly get => (sbyte8)((byte32)this).v8_12;   set { byte32 _this = (byte32)this; _this.v8_12 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_13 { readonly get => (sbyte8)((byte32)this).v8_13;   set { byte32 _this = (byte32)this; _this.v8_13 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_14 { readonly get => (sbyte8)((byte32)this).v8_14;   set { byte32 _this = (byte32)this; _this.v8_14 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_15 { readonly get => (sbyte8)((byte32)this).v8_15;   set { byte32 _this = (byte32)this; _this.v8_15 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_16 { readonly get => (sbyte8)((byte32)this).v8_16;   set { byte32 _this = (byte32)this; _this.v8_16 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_17 { readonly get => (sbyte8)((byte32)this).v8_17;   set { byte32 _this = (byte32)this; _this.v8_17 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_18 { readonly get => (sbyte8)((byte32)this).v8_18;   set { byte32 _this = (byte32)this; _this.v8_18 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_19 { readonly get => (sbyte8)((byte32)this).v8_19;   set { byte32 _this = (byte32)this; _this.v8_19 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_20 { readonly get => (sbyte8)((byte32)this).v8_20;   set { byte32 _this = (byte32)this; _this.v8_20 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_21 { readonly get => (sbyte8)((byte32)this).v8_21;   set { byte32 _this = (byte32)this; _this.v8_21 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_22 { readonly get => (sbyte8)((byte32)this).v8_22;   set { byte32 _this = (byte32)this; _this.v8_22 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_23 { readonly get => (sbyte8)((byte32)this).v8_23;   set { byte32 _this = (byte32)this; _this.v8_23 = (byte8)value; this = (sbyte32)_this; } }
        public sbyte8 v8_24 { readonly get => (sbyte8)((byte32)this).v8_24;   set { byte32 _this = (byte32)this; _this.v8_24 = (byte8)value; this = (sbyte32)_this; } }

        public sbyte4 v4_0  { readonly get => (sbyte4)((byte32)this).v4_0;    set { byte32 _this = (byte32)this; _this.v4_0  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_1  { readonly get => (sbyte4)((byte32)this).v4_1;    set { byte32 _this = (byte32)this; _this.v4_1  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_2  { readonly get => (sbyte4)((byte32)this).v4_2;    set { byte32 _this = (byte32)this; _this.v4_2  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_3  { readonly get => (sbyte4)((byte32)this).v4_3;    set { byte32 _this = (byte32)this; _this.v4_3  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_4  { readonly get => (sbyte4)((byte32)this).v4_4;    set { byte32 _this = (byte32)this; _this.v4_4  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_5  { readonly get => (sbyte4)((byte32)this).v4_5;    set { byte32 _this = (byte32)this; _this.v4_5  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_6  { readonly get => (sbyte4)((byte32)this).v4_6;    set { byte32 _this = (byte32)this; _this.v4_6  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_7  { readonly get => (sbyte4)((byte32)this).v4_7;    set { byte32 _this = (byte32)this; _this.v4_7  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_8  { readonly get => (sbyte4)((byte32)this).v4_8;    set { byte32 _this = (byte32)this; _this.v4_8  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_9  { readonly get => (sbyte4)((byte32)this).v4_9;    set { byte32 _this = (byte32)this; _this.v4_9  = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_10 { readonly get => (sbyte4)((byte32)this).v4_10;   set { byte32 _this = (byte32)this; _this.v4_10 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_11 { readonly get => (sbyte4)((byte32)this).v4_11;   set { byte32 _this = (byte32)this; _this.v4_11 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_12 { readonly get => (sbyte4)((byte32)this).v4_12;   set { byte32 _this = (byte32)this; _this.v4_12 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_13 { readonly get => (sbyte4)((byte32)this).v4_13;   set { byte32 _this = (byte32)this; _this.v4_13 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_14 { readonly get => (sbyte4)((byte32)this).v4_14;   set { byte32 _this = (byte32)this; _this.v4_14 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_15 { readonly get => (sbyte4)((byte32)this).v4_15;   set { byte32 _this = (byte32)this; _this.v4_15 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_16 { readonly get => (sbyte4)((byte32)this).v4_16;   set { byte32 _this = (byte32)this; _this.v4_16 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_17 { readonly get => (sbyte4)((byte32)this).v4_17;   set { byte32 _this = (byte32)this; _this.v4_17 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_18 { readonly get => (sbyte4)((byte32)this).v4_18;   set { byte32 _this = (byte32)this; _this.v4_18 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_19 { readonly get => (sbyte4)((byte32)this).v4_19;   set { byte32 _this = (byte32)this; _this.v4_19 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_20 { readonly get => (sbyte4)((byte32)this).v4_20;   set { byte32 _this = (byte32)this; _this.v4_20 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_21 { readonly get => (sbyte4)((byte32)this).v4_21;   set { byte32 _this = (byte32)this; _this.v4_21 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_22 { readonly get => (sbyte4)((byte32)this).v4_22;   set { byte32 _this = (byte32)this; _this.v4_22 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_23 { readonly get => (sbyte4)((byte32)this).v4_23;   set { byte32 _this = (byte32)this; _this.v4_23 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_24 { readonly get => (sbyte4)((byte32)this).v4_24;   set { byte32 _this = (byte32)this; _this.v4_24 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_25 { readonly get => (sbyte4)((byte32)this).v4_25;   set { byte32 _this = (byte32)this; _this.v4_25 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_26 { readonly get => (sbyte4)((byte32)this).v4_26;   set { byte32 _this = (byte32)this; _this.v4_26 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_27 { readonly get => (sbyte4)((byte32)this).v4_27;   set { byte32 _this = (byte32)this; _this.v4_27 = (byte4)value; this = (sbyte32)_this; } }
        public sbyte4 v4_28 { readonly get => (sbyte4)((byte32)this).v4_28;   set { byte32 _this = (byte32)this; _this.v4_28 = (byte4)value; this = (sbyte32)_this; } }

        public sbyte3 v3_0  { readonly get => (sbyte3)((byte32)this).v3_0;    set { byte32 _this = (byte32)this; _this.v3_0  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_1  { readonly get => (sbyte3)((byte32)this).v3_1;    set { byte32 _this = (byte32)this; _this.v3_1  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_2  { readonly get => (sbyte3)((byte32)this).v3_2;    set { byte32 _this = (byte32)this; _this.v3_2  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_3  { readonly get => (sbyte3)((byte32)this).v3_3;    set { byte32 _this = (byte32)this; _this.v3_3  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_4  { readonly get => (sbyte3)((byte32)this).v3_4;    set { byte32 _this = (byte32)this; _this.v3_4  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_5  { readonly get => (sbyte3)((byte32)this).v3_5;    set { byte32 _this = (byte32)this; _this.v3_5  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_6  { readonly get => (sbyte3)((byte32)this).v3_6;    set { byte32 _this = (byte32)this; _this.v3_6  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_7  { readonly get => (sbyte3)((byte32)this).v3_7;    set { byte32 _this = (byte32)this; _this.v3_7  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_8  { readonly get => (sbyte3)((byte32)this).v3_8;    set { byte32 _this = (byte32)this; _this.v3_8  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_9  { readonly get => (sbyte3)((byte32)this).v3_9;    set { byte32 _this = (byte32)this; _this.v3_9  = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_10 { readonly get => (sbyte3)((byte32)this).v3_10;   set { byte32 _this = (byte32)this; _this.v3_10 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_11 { readonly get => (sbyte3)((byte32)this).v3_11;   set { byte32 _this = (byte32)this; _this.v3_11 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_12 { readonly get => (sbyte3)((byte32)this).v3_12;   set { byte32 _this = (byte32)this; _this.v3_12 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_13 { readonly get => (sbyte3)((byte32)this).v3_13;   set { byte32 _this = (byte32)this; _this.v3_13 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_14 { readonly get => (sbyte3)((byte32)this).v3_14;   set { byte32 _this = (byte32)this; _this.v3_14 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_15 { readonly get => (sbyte3)((byte32)this).v3_15;   set { byte32 _this = (byte32)this; _this.v3_15 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_16 { readonly get => (sbyte3)((byte32)this).v3_16;   set { byte32 _this = (byte32)this; _this.v3_16 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_17 { readonly get => (sbyte3)((byte32)this).v3_17;   set { byte32 _this = (byte32)this; _this.v3_17 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_18 { readonly get => (sbyte3)((byte32)this).v3_18;   set { byte32 _this = (byte32)this; _this.v3_18 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_19 { readonly get => (sbyte3)((byte32)this).v3_19;   set { byte32 _this = (byte32)this; _this.v3_19 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_20 { readonly get => (sbyte3)((byte32)this).v3_20;   set { byte32 _this = (byte32)this; _this.v3_20 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_21 { readonly get => (sbyte3)((byte32)this).v3_21;   set { byte32 _this = (byte32)this; _this.v3_21 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_22 { readonly get => (sbyte3)((byte32)this).v3_22;   set { byte32 _this = (byte32)this; _this.v3_22 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_23 { readonly get => (sbyte3)((byte32)this).v3_23;   set { byte32 _this = (byte32)this; _this.v3_23 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_24 { readonly get => (sbyte3)((byte32)this).v3_24;   set { byte32 _this = (byte32)this; _this.v3_24 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_25 { readonly get => (sbyte3)((byte32)this).v3_25;   set { byte32 _this = (byte32)this; _this.v3_25 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_26 { readonly get => (sbyte3)((byte32)this).v3_26;   set { byte32 _this = (byte32)this; _this.v3_26 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_27 { readonly get => (sbyte3)((byte32)this).v3_27;   set { byte32 _this = (byte32)this; _this.v3_27 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_28 { readonly get => (sbyte3)((byte32)this).v3_28;   set { byte32 _this = (byte32)this; _this.v3_28 = (byte3)value; this = (sbyte32)_this; } }
        public sbyte3 v3_29 { readonly get => (sbyte3)((byte32)this).v3_29;   set { byte32 _this = (byte32)this; _this.v3_29 = (byte3)value; this = (sbyte32)_this; } }

        public sbyte2 v2_0  { readonly get => (sbyte2)((byte32)this).v2_0;    set { byte32 _this = (byte32)this; _this.v2_0  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_1  { readonly get => (sbyte2)((byte32)this).v2_1;    set { byte32 _this = (byte32)this; _this.v2_1  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_2  { readonly get => (sbyte2)((byte32)this).v2_2;    set { byte32 _this = (byte32)this; _this.v2_2  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_3  { readonly get => (sbyte2)((byte32)this).v2_3;    set { byte32 _this = (byte32)this; _this.v2_3  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_4  { readonly get => (sbyte2)((byte32)this).v2_4;    set { byte32 _this = (byte32)this; _this.v2_4  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_5  { readonly get => (sbyte2)((byte32)this).v2_5;    set { byte32 _this = (byte32)this; _this.v2_5  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_6  { readonly get => (sbyte2)((byte32)this).v2_6;    set { byte32 _this = (byte32)this; _this.v2_6  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_7  { readonly get => (sbyte2)((byte32)this).v2_7;    set { byte32 _this = (byte32)this; _this.v2_7  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_8  { readonly get => (sbyte2)((byte32)this).v2_8;    set { byte32 _this = (byte32)this; _this.v2_8  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_9  { readonly get => (sbyte2)((byte32)this).v2_9;    set { byte32 _this = (byte32)this; _this.v2_9  = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_10 { readonly get => (sbyte2)((byte32)this).v2_10;   set { byte32 _this = (byte32)this; _this.v2_10 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_11 { readonly get => (sbyte2)((byte32)this).v2_11;   set { byte32 _this = (byte32)this; _this.v2_11 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_12 { readonly get => (sbyte2)((byte32)this).v2_12;   set { byte32 _this = (byte32)this; _this.v2_12 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_13 { readonly get => (sbyte2)((byte32)this).v2_13;   set { byte32 _this = (byte32)this; _this.v2_13 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_14 { readonly get => (sbyte2)((byte32)this).v2_14;   set { byte32 _this = (byte32)this; _this.v2_14 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_15 { readonly get => (sbyte2)((byte32)this).v2_15;   set { byte32 _this = (byte32)this; _this.v2_15 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_16 { readonly get => (sbyte2)((byte32)this).v2_16;   set { byte32 _this = (byte32)this; _this.v2_16 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_17 { readonly get => (sbyte2)((byte32)this).v2_17;   set { byte32 _this = (byte32)this; _this.v2_17 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_18 { readonly get => (sbyte2)((byte32)this).v2_18;   set { byte32 _this = (byte32)this; _this.v2_18 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_19 { readonly get => (sbyte2)((byte32)this).v2_19;   set { byte32 _this = (byte32)this; _this.v2_19 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_20 { readonly get => (sbyte2)((byte32)this).v2_20;   set { byte32 _this = (byte32)this; _this.v2_20 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_21 { readonly get => (sbyte2)((byte32)this).v2_21;   set { byte32 _this = (byte32)this; _this.v2_21 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_22 { readonly get => (sbyte2)((byte32)this).v2_22;   set { byte32 _this = (byte32)this; _this.v2_22 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_23 { readonly get => (sbyte2)((byte32)this).v2_23;   set { byte32 _this = (byte32)this; _this.v2_23 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_24 { readonly get => (sbyte2)((byte32)this).v2_24;   set { byte32 _this = (byte32)this; _this.v2_24 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_25 { readonly get => (sbyte2)((byte32)this).v2_25;   set { byte32 _this = (byte32)this; _this.v2_25 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_26 { readonly get => (sbyte2)((byte32)this).v2_26;   set { byte32 _this = (byte32)this; _this.v2_26 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_27 { readonly get => (sbyte2)((byte32)this).v2_27;   set { byte32 _this = (byte32)this; _this.v2_27 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_28 { readonly get => (sbyte2)((byte32)this).v2_28;   set { byte32 _this = (byte32)this; _this.v2_28 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_29 { readonly get => (sbyte2)((byte32)this).v2_29;   set { byte32 _this = (byte32)this; _this.v2_29 = (byte2)value; this = (sbyte32)_this; } }
        public sbyte2 v2_30 { readonly get => (sbyte2)((byte32)this).v2_30;   set { byte32 _this = (byte32)this; _this.v2_30 = (byte2)value; this = (sbyte32)_this; } }
        #endregion



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(sbyte32 input) => new v256 { SByte0 = input.x0, SByte1 = input.x1, SByte2 = input.x2, SByte3 = input.x3, SByte4 = input.x4, SByte5 = input.x5, SByte6 = input.x6, SByte7 = input.x7, SByte8 = input.x8, SByte9 = input.x9, SByte10 = input.x10, SByte11 = input.x11, SByte12 = input.x12, SByte13 = input.x13, SByte14 = input.x14, SByte15 = input.x15, SByte16 = input.x16, SByte17 = input.x17, SByte18 = input.x18, SByte19 = input.x19, SByte20 = input.x20, SByte21 = input.x21, SByte22 = input.x22, SByte23 = input.x23, SByte24 = input.x24, SByte25 = input.x25, SByte26 = input.x26, SByte27 = input.x27, SByte28 = input.x28, SByte29 = input.x29, SByte30 = input.x30, SByte31 = input.x31 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte32(v256 input) => new sbyte32 { x0 = input.SByte0, x1 = input.SByte1, x2 = input.SByte2, x3 = input.SByte3, x4 = input.SByte4, x5 = input.SByte5, x6 = input.SByte6, x7 = input.SByte7, x8 = input.SByte8, x9 = input.SByte9, x10 = input.SByte10, x11 = input.SByte11, x12 = input.SByte12, x13 = input.SByte13, x14 = input.SByte14, x15 = input.SByte15, x16 = input.SByte16, x17 = input.SByte17, x18 = input.SByte18, x19 = input.SByte19, x20 = input.SByte20, x21 = input.SByte21, x22 = input.SByte22, x23 = input.SByte23, x24 = input.SByte24, x25 = input.SByte25, x26 = input.SByte26, x27 = input.SByte27, x28 = input.SByte28, x29 = input.SByte29, x30 = input.SByte30, x31 = input.SByte31 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte32(sbyte input) => new sbyte32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(byte32 input) => *(sbyte32*)&input;


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (sbyte)((byte32)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte32 _this = (byte32)this;
                _this[index] = (byte)value;
                this = (sbyte32)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator + (sbyte32 left, sbyte32 right) => (sbyte32)((byte32)left + (byte32)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator - (sbyte32 left, sbyte32 right) => (sbyte32)((byte32)left - (byte32)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator * (sbyte32 left, sbyte32 right) => (sbyte32)((byte32)left * (byte32)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator / (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_div_epi8(left, right, false);
            }
            else
            {
                return new sbyte32(left._v16_0 / right._v16_0, left._v16_16 / right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator % (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rem_epi8(left, right);
            }
            else
            {
                return new sbyte32(left._v16_0 % right._v16_0, left._v16_16 % right._v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator * (sbyte left, sbyte32 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator * (sbyte32 left, sbyte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return new sbyte32((sbyte)(left.x0 * right), (sbyte)(left.x1 * right), (sbyte)(left.x2 * right), (sbyte)(left.x3 * right), (sbyte)(left.x4 * right), (sbyte)(left.x5 * right), (sbyte)(left.x6 * right), (sbyte)(left.x7 * right), (sbyte)(left.x8 * right), (sbyte)(left.x9 * right), (sbyte)(left.x10 * right), (sbyte)(left.x11 * right), (sbyte)(left.x12 * right), (sbyte)(left.x13 * right), (sbyte)(left.x14 * right), (sbyte)(left.x15 * right), (sbyte)(left.x16 * right), (sbyte)(left.x17 * right), (sbyte)(left.x18 * right), (sbyte)(left.x19 * right), (sbyte)(left.x20 * right), (sbyte)(left.x21 * right), (sbyte)(left.x22 * right), (sbyte)(left.x23 * right), (sbyte)(left.x24 * right), (sbyte)(left.x25 * right), (sbyte)(left.x26 * right), (sbyte)(left.x27 * right), (sbyte)(left.x28 * right), (sbyte)(left.x29 * right), (sbyte)(left.x30 * right), (sbyte)(left.x31 * right));
                }
                else
                {
                    return left * (sbyte32)right;
                }
            }
            else
            {
                return new sbyte32(left._v16_0 * right, left._v16_16 * right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator / (sbyte32 left, sbyte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constdiv_epi8(left, right);
                }
                else
                {
                    return left / (sbyte32)right;
                }
            }
            else
            {
                return new sbyte32(left._v16_0 / right, left._v16_16 / right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator % (sbyte32 left, sbyte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constrem_epi8(left, right);
                }
                else
                {
                    return left % (sbyte32)right;
                }
            }
            else
            {
                return new sbyte32(left._v16_0 % right, left._v16_16 % right);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator & (sbyte32 left, sbyte32 right) => (sbyte32)((byte32)left & (byte32)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator | (sbyte32 left, sbyte32 right) => (sbyte32)((byte32)left | (byte32)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ^ (sbyte32 left, sbyte32 right) => (sbyte32)((byte32)left ^ (byte32)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator - (sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi8(x);
            }
            else
            {
                return new sbyte32(-x._v16_0, -x._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ++ (sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi8(x);
            }
            else
            {
                return new sbyte32(x._v16_0 + 1, x._v16_16 + 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator -- (sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_epi8(x);
            }
            else
            {
                return new sbyte32(x._v16_0 - 1, x._v16_16 - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ~ (sbyte32 x) => (sbyte32)~(byte32)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator << (sbyte32 x, int n) => (sbyte32)((byte32)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator >> (sbyte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srai_epi8(x, n);
            }
            else
            {
                return new sbyte32(x._v16_0 >> n, x._v16_16 >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (sbyte32 left, sbyte32 right) => (byte32)left == (byte32)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_cmplt_epi8(left, right));
            }
            else
            {
                return new bool32(left._v16_0 < right._v16_0, left._v16_16 < right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Avx2.mm256_cmpgt_epi8(left, right));
            }
            else
            {
                return new bool32(left._v16_0 > right._v16_0, left._v16_16 > right._v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (sbyte32 left, sbyte32 right) => (byte32)left != (byte32)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse8(Avx2.mm256_cmpgt_epi8(left, right));
            }
            else
            {
                return new bool32(left._v16_0 <= right._v16_0, left._v16_16 <= right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse8(Avx2.mm256_cmpgt_epi8(right, left));
            }
            else
            {
                return new bool32(left._v16_0 >= right._v16_0, left._v16_16 >= right._v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte32 other) => ((byte32)this).Equals((byte32)other);

        public override readonly bool Equals(object obj) => obj is sbyte32 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((byte32)this).GetHashCode();


        public override readonly string ToString() =>  $"sbyte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte32({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)},    {x16.ToString(format, formatProvider)}, {x17.ToString(format, formatProvider)}, {x18.ToString(format, formatProvider)}, {x19.ToString(format, formatProvider)},    {x20.ToString(format, formatProvider)}, {x21.ToString(format, formatProvider)}, {x22.ToString(format, formatProvider)}, {x23.ToString(format, formatProvider)},    {x24.ToString(format, formatProvider)}, {x25.ToString(format, formatProvider)}, {x26.ToString(format, formatProvider)}, {x27.ToString(format, formatProvider)},    {x28.ToString(format, formatProvider)}, {x29.ToString(format, formatProvider)}, {x30.ToString(format, formatProvider)}, {x31.ToString(format, formatProvider)})";
    }
}