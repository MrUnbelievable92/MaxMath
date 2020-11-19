using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;

namespace MaxMath
{
    [Serializable]   [StructLayout(LayoutKind.Explicit, Size = 32)]
    unsafe public struct bool32 : IEquatable<bool32>
    {
        [NoAlias] [FieldOffset(0)]  public bool x0;
        [NoAlias] [FieldOffset(1)]  public bool x1;
        [NoAlias] [FieldOffset(2)]  public bool x2;
        [NoAlias] [FieldOffset(3)]  public bool x3;
        [NoAlias] [FieldOffset(4)]  public bool x4;
        [NoAlias] [FieldOffset(5)]  public bool x5;
        [NoAlias] [FieldOffset(6)]  public bool x6;
        [NoAlias] [FieldOffset(7)]  public bool x7;
        [NoAlias] [FieldOffset(8)]  public bool x8;
        [NoAlias] [FieldOffset(9)]  public bool x9;
        [NoAlias] [FieldOffset(10)] public bool x10;
        [NoAlias] [FieldOffset(11)] public bool x11;
        [NoAlias] [FieldOffset(12)] public bool x12;
        [NoAlias] [FieldOffset(13)] public bool x13;
        [NoAlias] [FieldOffset(14)] public bool x14;
        [NoAlias] [FieldOffset(15)] public bool x15;
        [NoAlias] [FieldOffset(16)] public bool x16;
        [NoAlias] [FieldOffset(17)] public bool x17;
        [NoAlias] [FieldOffset(18)] public bool x18;
        [NoAlias] [FieldOffset(19)] public bool x19;
        [NoAlias] [FieldOffset(20)] public bool x20;
        [NoAlias] [FieldOffset(21)] public bool x21;
        [NoAlias] [FieldOffset(22)] public bool x22;
        [NoAlias] [FieldOffset(23)] public bool x23;
        [NoAlias] [FieldOffset(24)] public bool x24;
        [NoAlias] [FieldOffset(25)] public bool x25;
        [NoAlias] [FieldOffset(26)] public bool x26;
        [NoAlias] [FieldOffset(27)] public bool x27;
        [NoAlias] [FieldOffset(28)] public bool x28;
        [NoAlias] [FieldOffset(29)] public bool x29;
        [NoAlias] [FieldOffset(30)] public bool x30;
        [NoAlias] [FieldOffset(31)] public bool x31;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15, bool x16, bool x17, bool x18, bool x19, bool x20, bool x21, bool x22, bool x23, bool x24, bool x25, bool x26, bool x27, bool x28, bool x29, bool x30, bool x31)
        {
            this.x0  = x0;
            this.x1  = x1;
            this.x2  = x2;
            this.x3  = x3;
            this.x4  = x4;
            this.x5  = x5;
            this.x6  = x6;
            this.x7  = x7;
            this.x8  = x8;
            this.x9  = x9;
            this.x10 = x10;
            this.x11 = x11;
            this.x12 = x12;
            this.x13 = x13;
            this.x14 = x14;
            this.x15 = x15;
            this.x16 = x16;
            this.x17 = x17;
            this.x18 = x18;
            this.x19 = x19;
            this.x20 = x20;
            this.x21 = x21;
            this.x22 = x22;
            this.x23 = x23;
            this.x24 = x24;
            this.x25 = x25;
            this.x26 = x26;
            this.x27 = x27;
            this.x28 = x28;
            this.x29 = x29;
            this.x30 = x30;
            this.x31 = x31;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool4x4 v16_0, bool4x4 v16_1)
        {
            bool32 @new = new bool32();

            ((bool4x4*)&@new)[0] = v16_0;
            ((bool4x4*)&@new)[1] = v16_1;

            this = @new;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(bool32 input) => *(byte32*)&input;


        public bool this[[AssumeRange(0, 31)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 32);
                
                fixed (void* ptr = &this)
                {
                    return ((bool*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                fixed (void* ptr = &this)
                {
                    ((bool*)ptr)[index] = value;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(bool32 other) => ((byte32)this).Equals((byte32)other);

        public override bool Equals(object obj) => Equals((bool32)obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._256bit((byte32)this);

        public override string ToString() => $"bool32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
    }
}