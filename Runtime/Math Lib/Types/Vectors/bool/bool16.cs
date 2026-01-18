using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 16 * sizeof(bool))]
    unsafe public struct bool16 : IEquatable<bool16>
    {
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x0), maxmath.tobyte(x1), maxmath.tobyte(x2), maxmath.tobyte(x3), maxmath.tobyte(x4), maxmath.tobyte(x5), maxmath.tobyte(x6), maxmath.tobyte(x7), maxmath.tobyte(x8), maxmath.tobyte(x9), maxmath.tobyte(x10), maxmath.tobyte(x11), maxmath.tobyte(x12), maxmath.tobyte(x13), maxmath.tobyte(x14), maxmath.tobyte(x15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool x0x16)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x0x16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool2 x01, bool2 x23, bool2 x45, bool2 x67, bool2 x89, bool2 x10_11, bool2 x12_13, bool2 x14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x01), maxmath.tobyte(x23), maxmath.tobyte(x45), maxmath.tobyte(x67), maxmath.tobyte(x89), maxmath.tobyte(x10_11), maxmath.tobyte(x12_13), maxmath.tobyte(x14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool4 x4567, bool4 x8_9_10_11, bool4 x12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x0123), maxmath.tobyte(x4567), maxmath.tobyte(x8_9_10_11), maxmath.tobyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool3 x456, bool3 x789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x0123), maxmath.tobyte(x456), maxmath.tobyte(x789), maxmath.tobyte(x10_11_12), maxmath.tobyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool4 x3456, bool3 x789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x012), maxmath.tobyte(x3456), maxmath.tobyte(x789), maxmath.tobyte(x10_11_12), maxmath.tobyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool4 x6789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x012), maxmath.tobyte(x345), maxmath.tobyte(x6789), maxmath.tobyte(x10_11_12), maxmath.tobyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool3 x678, bool4 x9_10_11_12, bool3 x13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x012), maxmath.tobyte(x345), maxmath.tobyte(x678), maxmath.tobyte(x9_10_11_12), maxmath.tobyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool3 x678, bool3 x9_10_11, bool4 x12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x012), maxmath.tobyte(x345), maxmath.tobyte(x678), maxmath.tobyte(x9_10_11), maxmath.tobyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool8 x01234567, bool4 x8_9_10_11, bool4 x12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x01234567), maxmath.tobyte(x8_9_10_11), maxmath.tobyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool8 x4_5_6_7_8_9_10_11, bool4 x12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x0123), maxmath.tobyte(x4_5_6_7_8_9_10_11), maxmath.tobyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool4 x4567, bool8 x8_9_10_11_12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x0123), maxmath.tobyte(x4567), maxmath.tobyte(x8_9_10_11_12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool8 x01234567, bool8 x8_9_10_11_12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.tobyte(x01234567), maxmath.tobyte(x8_9_10_11_12_13_14_15)));
        }


        public bool8 v8_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_0 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_1 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_2 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_3 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_4 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_5 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_6 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_7); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_7 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool8 v8_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v8_8); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v8_8 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }

        public bool4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_0  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_1  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_2  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_3  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_4  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_5  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_6  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_7  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_8  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_9  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_10 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_11 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v4_12 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }

        public bool3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_0  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_1  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_2  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_3  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_4  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_5  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_6  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_7  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_8  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_9  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_10 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_11 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_12 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v3_13 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }

        public bool2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_0  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_1  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_2  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_3  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_4  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_5  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_6  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_7  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_8  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_9  = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_10 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_11 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_12 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_13 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }
        public bool2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.tobool(maxmath.tobyte(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.tobyte(this); temp.v2_14 = maxmath.tobyte(value); this = maxmath.tobool(temp); } }

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(bool16 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool16(v128 input) => RegisterConversion.ToAbstraction128<bool16>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool16(bool x) => new bool16(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (bool16 left, bool16 right) => maxmath.tobyte(left) == maxmath.tobyte(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (bool16 left, bool16 right) => left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator & (bool16 left, bool16 right) => maxmath.tobool(maxmath.tobyte(left) & maxmath.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator | (bool16 left, bool16 right) => maxmath.tobool(maxmath.tobyte(left) | maxmath.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator ^ (bool16 left, bool16 right) => maxmath.tobool(maxmath.tobyte(left) ^ maxmath.tobyte(right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator ! (bool16 val)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.andnot_si128(val, new byte16(1));
            }
            else
            {
                return new bool16(!val.x0, !val.x1, !val.x2, !val.x3, !val.x4, !val.x5, !val.x6, !val.x7, !val.x8, !val.x9, !val.x10, !val.x11, !val.x12, !val.x13, !val.x14, !val.x15);
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
                byte16 cpy = maxmath.tobyte(this);
                cpy[index] = maxmath.tobyte(value);
                this = maxmath.tobool(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool16 other) => maxmath.tobyte(this).Equals(maxmath.tobyte(other));

        public override readonly bool Equals(object obj) => obj is bool16 converted && this.Equals(converted);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => maxmath.bitmask(this);

        public override readonly string ToString() => $"bool16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
    }
}