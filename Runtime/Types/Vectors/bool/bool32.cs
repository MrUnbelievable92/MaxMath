using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]    [StructLayout(LayoutKind.Explicit, Size = 32 * sizeof(bool))]
    unsafe public struct bool32 : IEquatable<bool32>
    {
        [FieldOffset(0)]  private fixed bool asArray[32];

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
            this = maxmath.tobool(new byte32(maxmath.touint8(x0), maxmath.touint8(x1), maxmath.touint8(x2), maxmath.touint8(x3), maxmath.touint8(x4), maxmath.touint8(x5), maxmath.touint8(x6), maxmath.touint8(x7), maxmath.touint8(x8), maxmath.touint8(x9), maxmath.touint8(x10), maxmath.touint8(x11), maxmath.touint8(x12), maxmath.touint8(x13), maxmath.touint8(x14), maxmath.touint8(x15), maxmath.touint8(x16), maxmath.touint8(x17), maxmath.touint8(x18), maxmath.touint8(x19), maxmath.touint8(x20), maxmath.touint8(x21), maxmath.touint8(x22), maxmath.touint8(x23), maxmath.touint8(x24), maxmath.touint8(x25), maxmath.touint8(x26), maxmath.touint8(x27), maxmath.touint8(x28), maxmath.touint8(x29), maxmath.touint8(x30), maxmath.touint8(x31)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0x32)
        {
            this = maxmath.tobool(new byte32(maxmath.touint8(x0x32)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool8 v8_8, bool8 v8_16, bool8 v8_24)
        {
            this = maxmath.tobool(new byte32(maxmath.touint8(v8_0), maxmath.touint8(v8_8), maxmath.touint8(v8_16), maxmath.touint8(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool16 v16_0, bool8 v8_16, bool8 v8_24)
        {
            this = maxmath.tobool(new byte32(maxmath.touint8(v16_0), maxmath.touint8(v8_16), maxmath.touint8(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool16 v16_8, bool8 v8_24)
        {
            this = maxmath.tobool(new byte32(maxmath.touint8(v8_0), maxmath.touint8(v16_8), maxmath.touint8(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool8 v8_8, bool16 v16_16)
        {
            this = maxmath.tobool(new byte32(maxmath.touint8(v8_0), maxmath.touint8(v8_8), maxmath.touint8(v16_16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool16 v16_0, bool16 v16_1)
        {
            this = maxmath.tobool(new byte32(maxmath.touint8(v16_0), maxmath.touint8(v16_1)));
        }


        #region Shuffle
        public bool16 v16_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_0  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_1  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_2  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_3  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_4  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_5  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_6  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_7  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_8  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_9  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_10 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_11 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_12 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_13 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_14 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_15 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v16_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v16_16 = maxmath.touint8(value); this = maxmath.tobool(temp); } }

        public bool8 v8_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_0  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_1  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_2  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_3  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_4  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_5  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_6  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_7  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_8  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_9  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_10 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_11 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_12 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_13 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_14 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_15 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_16 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_17 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_18 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_19 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_20 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_21 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_22 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_23 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v8_24 = maxmath.touint8(value); this = maxmath.tobool(temp); } }

        public bool4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_0  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_1  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_2  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_3  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_4  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_5  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_6  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_7  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_8  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_9  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_10 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_11 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_12 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_13 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_14 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_15 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_16 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_17 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_18 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_19 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_20 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_21 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_22 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_23 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_24 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_25 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_26 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_27 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool4 v4_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v4_28 = maxmath.touint8(value); this = maxmath.tobool(temp); } }

        public bool3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_0  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_1  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_2  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_3  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_4  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_5  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_6  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_7  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_8  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_9  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_10 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_11 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_12 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_13 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_14 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_15 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_16 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_17 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_18 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_19 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_20 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_21 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_22 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_23 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_24 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_25 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_26 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_27 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_28 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool3 v3_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_29); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v3_29 = maxmath.touint8(value); this = maxmath.tobool(temp); } }

        public bool2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_0  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_1  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_2  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_3  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_4  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_5  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_6  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_7  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_8  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_9  = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_10 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_11 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_12 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_13 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_14 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_15 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_16 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_17 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_18 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_19 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_20 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_21 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_22 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_23 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_24 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_25 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_26 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_27 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_28 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_29); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_29 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool2 v2_30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_30); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = maxmath.touint8(this); temp.v2_30 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(bool32 input) => new v256(*(byte*)&input.x0, *(byte*)&input.x1, *(byte*)&input.x2, *(byte*)&input.x3, *(byte*)&input.x4, *(byte*)&input.x5, *(byte*)&input.x6, *(byte*)&input.x7, *(byte*)&input.x8, *(byte*)&input.x9, *(byte*)&input.x10, *(byte*)&input.x11, *(byte*)&input.x12, *(byte*)&input.x13, *(byte*)&input.x14, *(byte*)&input.x15, *(byte*)&input.x16, *(byte*)&input.x17, *(byte*)&input.x18, *(byte*)&input.x19, *(byte*)&input.x20, *(byte*)&input.x21, *(byte*)&input.x22, *(byte*)&input.x23, *(byte*)&input.x24, *(byte*)&input.x25, *(byte*)&input.x26, *(byte*)&input.x27, *(byte*)&input.x28, *(byte*)&input.x29, *(byte*)&input.x30, *(byte*)&input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator bool32(v256 input) => new bool32 { x0 = maxmath.tobool(input.Byte0), x1 = maxmath.tobool(input.Byte1), x2 = maxmath.tobool(input.Byte2), x3 = maxmath.tobool(input.Byte3), x4 = maxmath.tobool(input.Byte4), x5 = maxmath.tobool(input.Byte5), x6 = maxmath.tobool(input.Byte6), x7 = maxmath.tobool(input.Byte7), x8 = maxmath.tobool(input.Byte8), x9 = maxmath.tobool(input.Byte9), x10 = maxmath.tobool(input.Byte10), x11 = maxmath.tobool(input.Byte11), x12 = maxmath.tobool(input.Byte12), x13 = maxmath.tobool(input.Byte13), x14 = maxmath.tobool(input.Byte14), x15 = maxmath.tobool(input.Byte15), x16 = maxmath.tobool(input.Byte16), x17 = maxmath.tobool(input.Byte17), x18 = maxmath.tobool(input.Byte18), x19 = maxmath.tobool(input.Byte19), x20 = maxmath.tobool(input.Byte20), x21 = maxmath.tobool(input.Byte21), x22 = maxmath.tobool(input.Byte22), x23 = maxmath.tobool(input.Byte23), x24 = maxmath.tobool(input.Byte24), x25 = maxmath.tobool(input.Byte25), x26 = maxmath.tobool(input.Byte26), x27 = maxmath.tobool(input.Byte27), x28 = maxmath.tobool(input.Byte28), x29 = maxmath.tobool(input.Byte29), x30 = maxmath.tobool(input.Byte30), x31 = maxmath.tobool(input.Byte31) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool32(bool x) => new bool32(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (bool32 left, bool32 right) => maxmath.touint8(left) == maxmath.touint8(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (bool32 left, bool32 right) => maxmath.touint8(left) != maxmath.touint8(right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator & (bool32 left, bool32 right) => maxmath.tobool(maxmath.touint8(left) & maxmath.touint8(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator | (bool32 left, bool32 right) => maxmath.tobool(maxmath.touint8(left) | maxmath.touint8(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ^ (bool32 left, bool32 right) => maxmath.tobool(maxmath.touint8(left) ^ maxmath.touint8(right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ! (bool32 val)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(val, new byte32(1));
            }
            else
            {
                return new bool32(!val._v16_0, !val._v16_16);
            }
        }


        public bool this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get
            {
Assert.IsWithinArrayBounds(index, 32);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                asArray[index] = value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public  bool Equals(bool32 other) => maxmath.touint8(this).Equals(maxmath.touint8(other));

        public override  bool Equals(object obj) => Equals((bool32)obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override  int GetHashCode() => maxmath.touint8(this).GetHashCode();

        public override  string ToString() => $"bool32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
    }
}