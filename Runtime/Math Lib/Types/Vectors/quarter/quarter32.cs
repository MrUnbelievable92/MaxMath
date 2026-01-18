using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 32 * sizeof(byte))]
    [DebuggerTypeProxy(typeof(quarter32.DebuggerProxy))]
    unsafe public struct quarter32 : IEquatable<quarter32>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public quarter x0;
            public quarter x1;
            public quarter x2;
            public quarter x3;
            public quarter x4;
            public quarter x5;
            public quarter x6;
            public quarter x7;
            public quarter x8;
            public quarter x9;
            public quarter x10;
            public quarter x11;
            public quarter x12;
            public quarter x13;
            public quarter x14;
            public quarter x15;
            public quarter x16;
            public quarter x17;
            public quarter x18;
            public quarter x19;
            public quarter x20;
            public quarter x21;
            public quarter x22;
            public quarter x23;
            public quarter x24;
            public quarter x25;
            public quarter x26;
            public quarter x27;
            public quarter x28;
            public quarter x29;
            public quarter x30;
            public quarter x31;

            public DebuggerProxy(quarter32 v)
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


        [FieldOffset(0)]  internal quarter16 _v16_0;
        [FieldOffset(16)] internal quarter16 _v16_16;

        [FieldOffset(0)]  public quarter x0;
        [FieldOffset(1)]  public quarter x1;
        [FieldOffset(2)]  public quarter x2;
        [FieldOffset(3)]  public quarter x3;
        [FieldOffset(4)]  public quarter x4;
        [FieldOffset(5)]  public quarter x5;
        [FieldOffset(6)]  public quarter x6;
        [FieldOffset(7)]  public quarter x7;
        [FieldOffset(8)]  public quarter x8;
        [FieldOffset(9)]  public quarter x9;
        [FieldOffset(10)] public quarter x10;
        [FieldOffset(11)] public quarter x11;
        [FieldOffset(12)] public quarter x12;
        [FieldOffset(13)] public quarter x13;
        [FieldOffset(14)] public quarter x14;
        [FieldOffset(15)] public quarter x15;
        [FieldOffset(16)] public quarter x16;
        [FieldOffset(17)] public quarter x17;
        [FieldOffset(18)] public quarter x18;
        [FieldOffset(19)] public quarter x19;
        [FieldOffset(20)] public quarter x20;
        [FieldOffset(21)] public quarter x21;
        [FieldOffset(22)] public quarter x22;
        [FieldOffset(23)] public quarter x23;
        [FieldOffset(24)] public quarter x24;
        [FieldOffset(25)] public quarter x25;
        [FieldOffset(26)] public quarter x26;
        [FieldOffset(27)] public quarter x27;
        [FieldOffset(28)] public quarter x28;
        [FieldOffset(29)] public quarter x29;
        [FieldOffset(30)] public quarter x30;
        [FieldOffset(31)] public quarter x31;


        public static quarter32 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter32(quarter x0, quarter x1, quarter x2, quarter x3, quarter x4, quarter x5, quarter x6, quarter x7, quarter x8, quarter x9, quarter x10, quarter x11, quarter x12, quarter x13, quarter x14, quarter x15, quarter x16, quarter x17, quarter x18, quarter x19, quarter x20, quarter x21, quarter x22, quarter x23, quarter x24, quarter x25, quarter x26, quarter x27, quarter x28, quarter x29, quarter x30, quarter x31)
        {
            this = asquarter(new byte32(x0.value, x1.value, x2.value, x3.value, x4.value, x5.value, x6.value, x7.value, x8.value, x9.value, x10.value, x11.value, x12.value, x13.value, x14.value, x15.value, x16.value, x17.value, x18.value, x19.value, x20.value, x21.value, x22.value, x23.value, x24.value, x25.value, x26.value, x27.value, x28.value, x29.value, x30.value, x31.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter32(quarter x0x32)
        {
            this = asquarter(new byte32(x0x32.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter32(quarter4 x0_3, quarter4 x4_7, quarter4 x8_11, quarter4 x12_15, quarter4 x16_19, quarter4 x20_23, quarter4 x24_27, quarter4 x28_31)
        {
            this = asquarter(new byte32(asbyte(x0_3), asbyte(x4_7), asbyte(x8_11), asbyte(x12_15), asbyte(x16_19), asbyte(x20_23), asbyte(x24_27), asbyte(x28_31)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter32(quarter8 v8_0, quarter8 v8_8, quarter8 v8_16, quarter8 v8_24)
        {
            this = asquarter(new byte32(asbyte(v8_0), asbyte(v8_8), asbyte(v8_16), asbyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter32(quarter16 v16_0, quarter8 v8_16, quarter8 v8_24)
        {
            this = asquarter(new byte32(asbyte(v16_0), asbyte(v8_16), asbyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter32(quarter8 v8_0, quarter16 v16_8, quarter8 v8_24)
        {
            this = asquarter(new byte32(asbyte(v8_0), asbyte(v16_8), asbyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter32(quarter8 v8_0, quarter8 v8_8, quarter16 v16_16)
        {
            this = asquarter(new byte32(asbyte(v8_0), asbyte(v8_8), asbyte(v16_16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter32(quarter16 v16_0, quarter16 v16_16)
        {
            this = asquarter(new byte32(asbyte(v16_0), asbyte(v16_16)));
        }


        #region Shuffle
        public quarter16 v16_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_0  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_1  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_2  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_3  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_4  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_5  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_6  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_7  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_8  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_9  = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_10 = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_11 = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_12 = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_13 = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_14 = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_15 = asbyte(value); this = asquarter(temp); } }
        public quarter16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v16_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v16_16 = asbyte(value); this = asquarter(temp); } }

        public quarter8 v8_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_0  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_1  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_2  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_3  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_4  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_5  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_6  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_7  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_8  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_9  = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_10 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_11 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_12 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_13 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_14 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_15 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_16 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_17 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_18 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_19 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_20 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_21 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_22 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_23 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v8_24 = asbyte(value); this = asquarter(temp); } }

        public quarter4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_0  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_1  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_2  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_3  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_4  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_5  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_6  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_7  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_8  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_9  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_10 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_11 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_12 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_13 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_14 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_15 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_16 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_17 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_18 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_19 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_20 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_21 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_22 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_23 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_24 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_25 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_26 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_27 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v4_28 = asbyte(value); this = asquarter(temp); } }

        public quarter3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_0  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_1  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_2  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_3  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_4  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_5  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_6  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_7  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_8  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_9  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_10 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_11 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_12 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_13 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_14 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_15 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_16 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_17 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_18 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_19 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_20 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_21 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_22 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_23 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_24 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_25 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_26 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_27 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_28 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_29); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v3_29 = asbyte(value); this = asquarter(temp); } }

        public quarter2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_0  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_1  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_2  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_3  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_4  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_5  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_6  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_7  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_8  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_9  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_10 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_11 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_12 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_13 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_14 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_15 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_16 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_17 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_18 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_19 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_20 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_21 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_22 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_23 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_24 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_25 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_26 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_27 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_28 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_29); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_29 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_30); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = asbyte(this); temp.v2_30 = asbyte(value); this = asquarter(temp); } }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(quarter32 input) => RegisterConversion.ToRegister256(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter32(v256 input) => RegisterConversion.ToAbstraction256<quarter32>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter32(quarter input) => new quarter32(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter32(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter32(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter32(double input) => (quarter)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter32(byte32 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu8_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter32((quarter16)input.v16_0, (quarter16)input.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter32(sbyte32 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi8_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter32((quarter16)input.v16_0, (quarter16)input.v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(quarter32 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi8(input);
            }
            else
            {
                return new sbyte32((sbyte16)input.v16_0, (sbyte16)input.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(quarter32 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu8(input);
            }
            else
            {
                return new byte32((byte16)input.v16_0, (byte16)input.v16_16);
            }
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return asquarter(asbyte(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte32 cpy = asbyte(this);
                cpy[index] = asbyte(value);
                this = asquarter(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 operator - (quarter32 value)
        {
            return asquarter(asbyte(value) ^ new byte32(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (quarter32 left, quarter32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_cmpeq_pq(left, right));
            }
            else
            {
                return new bool32(left.v16_0 == right.v16_0, left.v16_16 == right.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (quarter32 left, quarter right)
        {
            return left == (quarter32)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (quarter left, quarter32 right)
        {
            return (quarter32)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (quarter32 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 == right, left.v16_16 == right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (half left, quarter32 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (quarter32 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 == right, left.v16_16 == right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (float left, quarter32 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (quarter32 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 == right, left.v16_16 == right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (double left, quarter32 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (quarter32 left, quarter32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_cmpneq_pq(left, right));
            }
            else
            {
                return new bool32(left.v16_0 != right.v16_0, left.v16_16 != right.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (quarter32 left, quarter right)
        {
            return left != (quarter32)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (quarter left, quarter32 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (quarter32 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 != right, left.v16_16 != right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (half left, quarter32 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (quarter32 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 != right, left.v16_16 != right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (float left, quarter32 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (quarter32 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 != right, left.v16_16 != right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (double left, quarter32 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (quarter32 left, quarter32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_cmplt_pq(left, right));
            }
            else
            {
                return new bool32(left.v16_0 < right.v16_0, left.v16_16 < right.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (quarter32 left, quarter right)
        {
            return left < (quarter32)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (quarter left, quarter32 right)
        {
            return (quarter32)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (quarter32 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 < right, left.v16_16 < right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (half left, quarter32 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter32);
            }
            else
            {
                return new bool32(left < right.v16_0, left < right.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (quarter32 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 < right, left.v16_16 < right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (float left, quarter32 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter32);
            }
            else
            {
                return new bool32(left < right.v16_0, left < right.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (quarter32 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 < right, left.v16_16 < right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (double left, quarter32 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter32);
            }
            else
            {
                return new bool32(left < right.v16_0, left < right.v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (quarter32 left, quarter32 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (quarter32 left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (quarter left, quarter32 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (quarter32 left, half right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (half left, quarter32 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (quarter32 left, float right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (float left, quarter32 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (quarter32 left, double right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (double left, quarter32 right) => right < left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (quarter32 left, quarter32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_cmple_pq(left, right));
            }
            else
            {
                return new bool32(left.v16_0 <= right.v16_0, left.v16_16 <= right.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (quarter32 left, quarter right)
        {
            return left <= (quarter32)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (quarter left, quarter32 right)
        {
            return (quarter32)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (quarter32 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 <= right, left.v16_16 <= right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (half left, quarter32 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter32);
            }
            else
            {
                return new bool32(left <= right.v16_0, left <= right.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (quarter32 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 <= right, left.v16_16 <= right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (float left, quarter32 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter32);
            }
            else
            {
                return new bool32(left <= right.v16_0, left <= right.v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (quarter32 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter32);
            }
            else
            {
                return new bool32(left.v16_0 <= right, left.v16_16 <= right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (double left, quarter32 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter32);
            }
            else
            {
                return new bool32(left <= right.v16_0, left <= right.v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (quarter32 left, quarter32 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (quarter32 left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (quarter left, quarter32 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (quarter32 left, half right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (half left, quarter32 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (quarter32 left, float right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (float left, quarter32 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (quarter32 left, double right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (double left, quarter32 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter32 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<quarter>(Xse.mm256_cmpeq_pq(this, other));
            }
            else
            {
                return this._v16_0.Equals(other._v16_0) & this._v16_16.Equals(other._v16_16);
            }
        }

        public override readonly bool Equals(object obj) => obj is quarter32 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Hash.v256(this);
            }
            else
            {
                return _v16_0.GetHashCode() ^ _v16_16.GetHashCode();
            }
        }


        public override readonly string ToString() =>  $"quarter32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"quarter32({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)},    {x16.ToString(format, formatProvider)}, {x17.ToString(format, formatProvider)}, {x18.ToString(format, formatProvider)}, {x19.ToString(format, formatProvider)},    {x20.ToString(format, formatProvider)}, {x21.ToString(format, formatProvider)}, {x22.ToString(format, formatProvider)}, {x23.ToString(format, formatProvider)},    {x24.ToString(format, formatProvider)}, {x25.ToString(format, formatProvider)}, {x26.ToString(format, formatProvider)}, {x27.ToString(format, formatProvider)},    {x28.ToString(format, formatProvider)}, {x29.ToString(format, formatProvider)}, {x30.ToString(format, formatProvider)}, {x31.ToString(format, formatProvider)})";
    }
}