using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 32 * sizeof(bool))]
    unsafe public struct bool32 : IEquatable<bool32>
    {
        [FieldOffset(0)]  internal bool16 _v16_0;
        [FieldOffset(16)] internal bool16 _v16_16;

        [FieldOffset(0)]  [MarshalAs(UnmanagedType.U1)] public bool x0;
        [FieldOffset(1)]  [MarshalAs(UnmanagedType.U1)] public bool x1;
        [FieldOffset(2)]  [MarshalAs(UnmanagedType.U1)] public bool x2;
        [FieldOffset(3)]  [MarshalAs(UnmanagedType.U1)] public bool x3;
        [FieldOffset(4)]  [MarshalAs(UnmanagedType.U1)] public bool x4;
        [FieldOffset(5)]  [MarshalAs(UnmanagedType.U1)] public bool x5;
        [FieldOffset(6)]  [MarshalAs(UnmanagedType.U1)] public bool x6;
        [FieldOffset(7)]  [MarshalAs(UnmanagedType.U1)] public bool x7;
        [FieldOffset(8)]  [MarshalAs(UnmanagedType.U1)] public bool x8;
        [FieldOffset(9)]  [MarshalAs(UnmanagedType.U1)] public bool x9;
        [FieldOffset(10)] [MarshalAs(UnmanagedType.U1)] public bool x10;
        [FieldOffset(11)] [MarshalAs(UnmanagedType.U1)] public bool x11;
        [FieldOffset(12)] [MarshalAs(UnmanagedType.U1)] public bool x12;
        [FieldOffset(13)] [MarshalAs(UnmanagedType.U1)] public bool x13;
        [FieldOffset(14)] [MarshalAs(UnmanagedType.U1)] public bool x14;
        [FieldOffset(15)] [MarshalAs(UnmanagedType.U1)] public bool x15;
        [FieldOffset(16)] [MarshalAs(UnmanagedType.U1)] public bool x16;
        [FieldOffset(17)] [MarshalAs(UnmanagedType.U1)] public bool x17;
        [FieldOffset(18)] [MarshalAs(UnmanagedType.U1)] public bool x18;
        [FieldOffset(19)] [MarshalAs(UnmanagedType.U1)] public bool x19;
        [FieldOffset(20)] [MarshalAs(UnmanagedType.U1)] public bool x20;
        [FieldOffset(21)] [MarshalAs(UnmanagedType.U1)] public bool x21;
        [FieldOffset(22)] [MarshalAs(UnmanagedType.U1)] public bool x22;
        [FieldOffset(23)] [MarshalAs(UnmanagedType.U1)] public bool x23;
        [FieldOffset(24)] [MarshalAs(UnmanagedType.U1)] public bool x24;
        [FieldOffset(25)] [MarshalAs(UnmanagedType.U1)] public bool x25;
        [FieldOffset(26)] [MarshalAs(UnmanagedType.U1)] public bool x26;
        [FieldOffset(27)] [MarshalAs(UnmanagedType.U1)] public bool x27;
        [FieldOffset(28)] [MarshalAs(UnmanagedType.U1)] public bool x28;
        [FieldOffset(29)] [MarshalAs(UnmanagedType.U1)] public bool x29;
        [FieldOffset(30)] [MarshalAs(UnmanagedType.U1)] public bool x30;
        [FieldOffset(31)] [MarshalAs(UnmanagedType.U1)] public bool x31;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15, bool x16, bool x17, bool x18, bool x19, bool x20, bool x21, bool x22, bool x23, bool x24, bool x25, bool x26, bool x27, bool x28, bool x29, bool x30, bool x31)
        {
            this = maxmath.tobool(new byte32(maxmath.tobyte(x0), maxmath.tobyte(x1), maxmath.tobyte(x2), maxmath.tobyte(x3), maxmath.tobyte(x4), maxmath.tobyte(x5), maxmath.tobyte(x6), maxmath.tobyte(x7), maxmath.tobyte(x8), maxmath.tobyte(x9), maxmath.tobyte(x10), maxmath.tobyte(x11), maxmath.tobyte(x12), maxmath.tobyte(x13), maxmath.tobyte(x14), maxmath.tobyte(x15), maxmath.tobyte(x16), maxmath.tobyte(x17), maxmath.tobyte(x18), maxmath.tobyte(x19), maxmath.tobyte(x20), maxmath.tobyte(x21), maxmath.tobyte(x22), maxmath.tobyte(x23), maxmath.tobyte(x24), maxmath.tobyte(x25), maxmath.tobyte(x26), maxmath.tobyte(x27), maxmath.tobyte(x28), maxmath.tobyte(x29), maxmath.tobyte(x30), maxmath.tobyte(x31)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0x32)
        {
            this = maxmath.tobool(new byte32(maxmath.tobyte(x0x32)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool4 x0_3, bool4 x4_7, bool4 x8_11, bool4 x12_15, bool4 x16_19, bool4 x20_23, bool4 x24_27, bool4 x28_31)
        {
            this = maxmath.tobool(new byte32(maxmath.tobyte(x0_3), maxmath.tobyte(x4_7), maxmath.tobyte(x8_11), maxmath.tobyte(x12_15), maxmath.tobyte(x16_19), maxmath.tobyte(x20_23), maxmath.tobyte(x24_27), maxmath.tobyte(x28_31)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool8 v8_8, bool8 v8_16, bool8 v8_24)
        {
            this = maxmath.tobool(new byte32(maxmath.tobyte(v8_0), maxmath.tobyte(v8_8), maxmath.tobyte(v8_16), maxmath.tobyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool16 v16_0, bool8 v8_16, bool8 v8_24)
        {
            this = maxmath.tobool(new byte32(maxmath.tobyte(v16_0), maxmath.tobyte(v8_16), maxmath.tobyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool16 v16_8, bool8 v8_24)
        {
            this = maxmath.tobool(new byte32(maxmath.tobyte(v8_0), maxmath.tobyte(v16_8), maxmath.tobyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool8 v8_8, bool16 v16_16)
        {
            this = maxmath.tobool(new byte32(maxmath.tobyte(v8_0), maxmath.tobyte(v8_8), maxmath.tobyte(v16_16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool16 v16_0, bool16 v16_1)
        {
            this = maxmath.tobool(new byte32(maxmath.tobyte(v16_0), maxmath.tobyte(v16_1)));
        }


        #region Shuffle
        public bool16 v16_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_0  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_1  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_2  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_3  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_4  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_5  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_6  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_7  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_8  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_9  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_10 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_11 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_12 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_13 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_14 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_15 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v16_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v16_16 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }

        public bool8 v8_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_0  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_1  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_2  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_3  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_4  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_5  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_6  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_7  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_8  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_9  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_10 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_11 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_12 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_13 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_14 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_15 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_16 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_17 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_18 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_19 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_20 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_21 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_22 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_23 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v8_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v8_24 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }

        public bool4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_0  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_1  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_2  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_3  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_4  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_5  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_6  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_7  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_8  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_9  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_10 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_11 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_12 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_13 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_14 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_15 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_16 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_17 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_18 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_19 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_20 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_21 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_22 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_23 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_24 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_25 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_26 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_27 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v4_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v4_28 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }

        public bool3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_0  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_1  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_2  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_3  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_4  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_5  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_6  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_7  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_8  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_9  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_10 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_11 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_12 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_13 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_14 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_15 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_16 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_17 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_18 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_19 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_20 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_21 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_22 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_23 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_24 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_25 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_26 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_27 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_28 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v3_29); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v3_29 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }

        public bool2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_0  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_1  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_2  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_3  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_4  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_5  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_6  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_7  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_8  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_9  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_10 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_11 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_12 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_13 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_14 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_15 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_16 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_17 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_18 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_19 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_20 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_21 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_22 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_23 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_24 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_25 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_26 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_27 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_28 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_29); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_29 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.tobyte(this).v2_30); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.tobyte(this); temp.v2_30 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(bool32 input) => RegisterConversion.ToRegister256(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool32(v256 input) => RegisterConversion.ToAbstraction256<bool32>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool32(bool x) => new bool32(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (bool32 left, bool32 right) => maxmath.tobyte(left) == maxmath.tobyte(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (bool32 left, bool32 right) => left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator & (bool32 left, bool32 right) => maxmath.tobool(maxmath.tobyte(left) & maxmath.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator | (bool32 left, bool32 right) => maxmath.tobool(maxmath.tobyte(left) | maxmath.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ^ (bool32 left, bool32 right) => maxmath.tobool(maxmath.tobyte(left) ^ maxmath.tobyte(right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ! (bool32 val)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_andnot_ps(val, Xse.mm256_set1_epi8(1));
            }
            else
            {
                return new bool32(!val._v16_0, !val._v16_16);
            }
        }


        public bool this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return maxmath.tobool(maxmath.tobyte(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte32 cpy = maxmath.tobyte(this);
                cpy[index] = maxmath.tobyte(value);
                this = maxmath.tobool(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool32 other) => maxmath.tobyte(this).Equals(maxmath.tobyte(other));

        public override readonly bool Equals(object obj) => obj is bool32 converted && this.Equals(converted);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => maxmath.bitmask(this);

        public override readonly string ToString() => $"bool32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
    }
}