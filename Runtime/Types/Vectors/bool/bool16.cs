using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]    [StructLayout(LayoutKind.Explicit, Size = 16 * sizeof(bool))]
    unsafe public struct bool16 : IEquatable<bool16>
    {
        [FieldOffset(0)]  private fixed bool asArray[16];

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
            this = maxmath.tobool(new byte16(maxmath.touint8(x0), maxmath.touint8(x1), maxmath.touint8(x2), maxmath.touint8(x3), maxmath.touint8(x4), maxmath.touint8(x5), maxmath.touint8(x6), maxmath.touint8(x7), maxmath.touint8(x8), maxmath.touint8(x9), maxmath.touint8(x10), maxmath.touint8(x11), maxmath.touint8(x12), maxmath.touint8(x13), maxmath.touint8(x14), maxmath.touint8(x15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool x0x16)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x0x16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool2 x01, bool2 x23, bool2 x45, bool2 x67, bool2 x89, bool2 x10_11, bool2 x12_13, bool2 x14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x01), maxmath.touint8(x23), maxmath.touint8(x45), maxmath.touint8(x67), maxmath.touint8(x89), maxmath.touint8(x10_11), maxmath.touint8(x12_13), maxmath.touint8(x14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool4 x4567, bool4 x8_9_10_11, bool4 x12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x0123), maxmath.touint8(x4567), maxmath.touint8(x8_9_10_11), maxmath.touint8(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool3 x456, bool3 x789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x0123), maxmath.touint8(x456), maxmath.touint8(x789), maxmath.touint8(x10_11_12), maxmath.touint8(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool4 x3456, bool3 x789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x012), maxmath.touint8(x3456), maxmath.touint8(x789), maxmath.touint8(x10_11_12), maxmath.touint8(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool4 x6789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x012), maxmath.touint8(x345), maxmath.touint8(x6789), maxmath.touint8(x10_11_12), maxmath.touint8(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool3 x678, bool4 x9_10_11_12, bool3 x13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x012), maxmath.touint8(x345), maxmath.touint8(x678), maxmath.touint8(x9_10_11_12), maxmath.touint8(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool3 x678, bool3 x9_10_11, bool4 x12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x012), maxmath.touint8(x345), maxmath.touint8(x678), maxmath.touint8(x9_10_11), maxmath.touint8(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool8 x01234567, bool4 x8_9_10_11, bool4 x12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x01234567), maxmath.touint8(x8_9_10_11), maxmath.touint8(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool8 x4_5_6_7_8_9_10_11, bool4 x12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x0123), maxmath.touint8(x4_5_6_7_8_9_10_11), maxmath.touint8(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool4 x4567, bool8 x8_9_10_11_12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x0123), maxmath.touint8(x4567), maxmath.touint8(x8_9_10_11_12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool8 x01234567, bool8 x8_9_10_11_12_13_14_15)
        {
            this = maxmath.tobool(new byte16(maxmath.touint8(x01234567), maxmath.touint8(x8_9_10_11_12_13_14_15)));
        }


        public bool8 v8_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_0 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_1 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_2 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_3 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_4 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_5 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_6 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_7); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_7 = maxmath.touint8(value); this = maxmath.tobool(temp); } }
        public bool8 v8_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v8_8); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v8_8 = maxmath.touint8(value); this = maxmath.tobool(temp); } }

        public bool4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_0  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_1  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_2  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_3  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_4  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_5  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_6  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_7  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_8  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_9  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_10 = maxmath.touint8(value); this = maxmath.tobool(temp); } }  
        public bool4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_11 = maxmath.touint8(value); this = maxmath.tobool(temp); } }  
        public bool4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v4_12 = maxmath.touint8(value); this = maxmath.tobool(temp); } }

        public bool3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_0  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_1  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_2  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_3  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_4  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_5  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_6  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_7  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_8  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_9  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_10 = maxmath.touint8(value); this = maxmath.tobool(temp); } }  
        public bool3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_11 = maxmath.touint8(value); this = maxmath.tobool(temp); } }  
        public bool3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_12 = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v3_13 = maxmath.touint8(value); this = maxmath.tobool(temp); } }

        public bool2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_0  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_1  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_2  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_3  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_4  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_5  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_6  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_7  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_8  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_9  = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_10 = maxmath.touint8(value); this = maxmath.tobool(temp); } }  
        public bool2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_11 = maxmath.touint8(value); this = maxmath.tobool(temp); } }  
        public bool2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_12 = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_13 = maxmath.touint8(value); this = maxmath.tobool(temp); } } 
        public bool2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.tobool(maxmath.touint8(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = maxmath.touint8(this); temp.v2_14 = maxmath.touint8(value); this = maxmath.tobool(temp); } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v128(bool16 input) => new v128(*(byte*)&input.x0, *(byte*)&input.x1, *(byte*)&input.x2, *(byte*)&input.x3, *(byte*)&input.x4, *(byte*)&input.x5, *(byte*)&input.x6, *(byte*)&input.x7, *(byte*)&input.x8, *(byte*)&input.x9, *(byte*)&input.x10, *(byte*)&input.x11, *(byte*)&input.x12, *(byte*)&input.x13, *(byte*)&input.x14, *(byte*)&input.x15);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
        public static implicit operator bool16(v128 input) => new bool16 { x0 = maxmath.tobool(input.Byte0), x1 = maxmath.tobool(input.Byte1), x2 = maxmath.tobool(input.Byte2), x3 = maxmath.tobool(input.Byte3), x4 = maxmath.tobool(input.Byte4), x5 = maxmath.tobool(input.Byte5), x6 = maxmath.tobool(input.Byte6), x7 = maxmath.tobool(input.Byte7), x8 = maxmath.tobool(input.Byte8), x9 = maxmath.tobool(input.Byte9), x10 = maxmath.tobool(input.Byte10), x11 = maxmath.tobool(input.Byte11), x12 = maxmath.tobool(input.Byte12), x13 = maxmath.tobool(input.Byte13), x14 = maxmath.tobool(input.Byte14), x15 = maxmath.tobool(input.Byte15)};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool16(bool x) => new bool16(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (bool16 left, bool16 right) => maxmath.touint8(left) == maxmath.touint8(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (bool16 left, bool16 right) => maxmath.touint8(left) != maxmath.touint8(right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator & (bool16 left, bool16 right) => maxmath.tobool(maxmath.touint8(left) & maxmath.touint8(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator | (bool16 left, bool16 right) => maxmath.tobool(maxmath.touint8(left) | maxmath.touint8(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator ^ (bool16 left, bool16 right) => maxmath.tobool(maxmath.touint8(left) ^ maxmath.touint8(right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator ! (bool16 val)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(val, new byte16(1));
            }
            else
            {
                return new bool16(!val.x0, !val.x1, !val.x2, !val.x3, !val.x4, !val.x5, !val.x6, !val.x7, !val.x8, !val.x9, !val.x10, !val.x11, !val.x12, !val.x13, !val.x14, !val.x15);
            }
        }


        public bool this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 16);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 16);

                asArray[index] = value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(bool16 other) => maxmath.touint8(this).Equals(maxmath.touint8(other));

        public override bool Equals(object obj) => Equals((bool16)obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => maxmath.touint8(this).GetHashCode();

        public override string ToString() => $"bool16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
    }
}