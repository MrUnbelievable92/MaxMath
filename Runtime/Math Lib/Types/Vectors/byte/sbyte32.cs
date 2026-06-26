using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class sbyte32DebuggerProxy
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
        
        public sbyte32DebuggerProxy(sbyte32 v)
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

    [System.Diagnostics.DebuggerTypeProxy(typeof(sbyte32DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct sbyte32 : IEquatable<sbyte32>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal sbyte16 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal sbyte16 __x16;

        public ref sbyte x0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  0); } } }
        public ref sbyte x1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  1); } } }
        public ref sbyte x2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  2); } } }
        public ref sbyte x3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  3); } } }
        public ref sbyte x4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  4); } } }
        public ref sbyte x5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  5); } } }
        public ref sbyte x6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  6); } } }
        public ref sbyte x7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  7); } } }
        public ref sbyte x8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  8); } } }
        public ref sbyte x9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr +  9); } } }
        public ref sbyte x10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 10); } } }
        public ref sbyte x11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 11); } } }
        public ref sbyte x12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 12); } } }
        public ref sbyte x13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 13); } } }
        public ref sbyte x14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 14); } } }
        public ref sbyte x15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 15); } } }
        public ref sbyte x16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 16); } } }
        public ref sbyte x17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 17); } } }
        public ref sbyte x18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 18); } } }
        public ref sbyte x19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 19); } } }
        public ref sbyte x20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 20); } } }
        public ref sbyte x21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 21); } } }
        public ref sbyte x22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 22); } } }
        public ref sbyte x23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 23); } } }
        public ref sbyte x24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 24); } } }
        public ref sbyte x25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 25); } } }
        public ref sbyte x26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 26); } } }
        public ref sbyte x27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 27); } } }
        public ref sbyte x28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 28); } } }
        public ref sbyte x29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 29); } } }
        public ref sbyte x30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 30); } } }
        public ref sbyte x31 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte32* ptr = &this) { return ref *((sbyte*)ptr + 31); } } }


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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(bool v)
        {
            this = (sbyte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(bool32 v)
        {
            this = (sbyte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(mask8x32 v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(byte v)
        {
            this = (sbyte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(byte32 v)
        {
            this = (sbyte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte32 v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(ushort v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(short v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(uint v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(int v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(ulong v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(long v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(UInt128 v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(Int128 v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(quarter v)
        {
            this = (sbyte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(quarter32 v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(half v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(float v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(double v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(quadruple v)
        {
            this = (sbyte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(Unity.Mathematics.half v)
        {
            this = (sbyte32)v;
        }

        #region Shuffle

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_0  { readonly get => (sbyte16)((byte32)this).v16_0;    set { byte32 _this = (byte32)this; _this.v16_0  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_1  { readonly get => (sbyte16)((byte32)this).v16_1;    set { byte32 _this = (byte32)this; _this.v16_1  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_2  { readonly get => (sbyte16)((byte32)this).v16_2;    set { byte32 _this = (byte32)this; _this.v16_2  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_3  { readonly get => (sbyte16)((byte32)this).v16_3;    set { byte32 _this = (byte32)this; _this.v16_3  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_4  { readonly get => (sbyte16)((byte32)this).v16_4;    set { byte32 _this = (byte32)this; _this.v16_4  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_5  { readonly get => (sbyte16)((byte32)this).v16_5;    set { byte32 _this = (byte32)this; _this.v16_5  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_6  { readonly get => (sbyte16)((byte32)this).v16_6;    set { byte32 _this = (byte32)this; _this.v16_6  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_7  { readonly get => (sbyte16)((byte32)this).v16_7;    set { byte32 _this = (byte32)this; _this.v16_7  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_8  { readonly get => (sbyte16)((byte32)this).v16_8;    set { byte32 _this = (byte32)this; _this.v16_8  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_9  { readonly get => (sbyte16)((byte32)this).v16_9;    set { byte32 _this = (byte32)this; _this.v16_9  = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_10 { readonly get => (sbyte16)((byte32)this).v16_10;   set { byte32 _this = (byte32)this; _this.v16_10 = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_11 { readonly get => (sbyte16)((byte32)this).v16_11;   set { byte32 _this = (byte32)this; _this.v16_11 = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_12 { readonly get => (sbyte16)((byte32)this).v16_12;   set { byte32 _this = (byte32)this; _this.v16_12 = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_13 { readonly get => (sbyte16)((byte32)this).v16_13;   set { byte32 _this = (byte32)this; _this.v16_13 = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_14 { readonly get => (sbyte16)((byte32)this).v16_14;   set { byte32 _this = (byte32)this; _this.v16_14 = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_15 { readonly get => (sbyte16)((byte32)this).v16_15;   set { byte32 _this = (byte32)this; _this.v16_15 = (byte16)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte16 v16_16 { readonly get => (sbyte16)((byte32)this).v16_16;   set { byte32 _this = (byte32)this; _this.v16_16 = (byte16)value; this = (sbyte32)_this; } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_0  { readonly get => (sbyte8)((byte32)this).v8_0;    set { byte32 _this = (byte32)this; _this.v8_0  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_1  { readonly get => (sbyte8)((byte32)this).v8_1;    set { byte32 _this = (byte32)this; _this.v8_1  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_2  { readonly get => (sbyte8)((byte32)this).v8_2;    set { byte32 _this = (byte32)this; _this.v8_2  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_3  { readonly get => (sbyte8)((byte32)this).v8_3;    set { byte32 _this = (byte32)this; _this.v8_3  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_4  { readonly get => (sbyte8)((byte32)this).v8_4;    set { byte32 _this = (byte32)this; _this.v8_4  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_5  { readonly get => (sbyte8)((byte32)this).v8_5;    set { byte32 _this = (byte32)this; _this.v8_5  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_6  { readonly get => (sbyte8)((byte32)this).v8_6;    set { byte32 _this = (byte32)this; _this.v8_6  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_7  { readonly get => (sbyte8)((byte32)this).v8_7;    set { byte32 _this = (byte32)this; _this.v8_7  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_8  { readonly get => (sbyte8)((byte32)this).v8_8;    set { byte32 _this = (byte32)this; _this.v8_8  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_9  { readonly get => (sbyte8)((byte32)this).v8_9;    set { byte32 _this = (byte32)this; _this.v8_9  = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_10 { readonly get => (sbyte8)((byte32)this).v8_10;   set { byte32 _this = (byte32)this; _this.v8_10 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_11 { readonly get => (sbyte8)((byte32)this).v8_11;   set { byte32 _this = (byte32)this; _this.v8_11 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_12 { readonly get => (sbyte8)((byte32)this).v8_12;   set { byte32 _this = (byte32)this; _this.v8_12 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_13 { readonly get => (sbyte8)((byte32)this).v8_13;   set { byte32 _this = (byte32)this; _this.v8_13 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_14 { readonly get => (sbyte8)((byte32)this).v8_14;   set { byte32 _this = (byte32)this; _this.v8_14 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_15 { readonly get => (sbyte8)((byte32)this).v8_15;   set { byte32 _this = (byte32)this; _this.v8_15 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_16 { readonly get => (sbyte8)((byte32)this).v8_16;   set { byte32 _this = (byte32)this; _this.v8_16 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_17 { readonly get => (sbyte8)((byte32)this).v8_17;   set { byte32 _this = (byte32)this; _this.v8_17 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_18 { readonly get => (sbyte8)((byte32)this).v8_18;   set { byte32 _this = (byte32)this; _this.v8_18 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_19 { readonly get => (sbyte8)((byte32)this).v8_19;   set { byte32 _this = (byte32)this; _this.v8_19 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_20 { readonly get => (sbyte8)((byte32)this).v8_20;   set { byte32 _this = (byte32)this; _this.v8_20 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_21 { readonly get => (sbyte8)((byte32)this).v8_21;   set { byte32 _this = (byte32)this; _this.v8_21 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_22 { readonly get => (sbyte8)((byte32)this).v8_22;   set { byte32 _this = (byte32)this; _this.v8_22 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_23 { readonly get => (sbyte8)((byte32)this).v8_23;   set { byte32 _this = (byte32)this; _this.v8_23 = (byte8)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte8 v8_24 { readonly get => (sbyte8)((byte32)this).v8_24;   set { byte32 _this = (byte32)this; _this.v8_24 = (byte8)value; this = (sbyte32)_this; } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_0  { readonly get => (sbyte4)((byte32)this).v4_0;    set { byte32 _this = (byte32)this; _this.v4_0  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_1  { readonly get => (sbyte4)((byte32)this).v4_1;    set { byte32 _this = (byte32)this; _this.v4_1  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_2  { readonly get => (sbyte4)((byte32)this).v4_2;    set { byte32 _this = (byte32)this; _this.v4_2  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_3  { readonly get => (sbyte4)((byte32)this).v4_3;    set { byte32 _this = (byte32)this; _this.v4_3  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_4  { readonly get => (sbyte4)((byte32)this).v4_4;    set { byte32 _this = (byte32)this; _this.v4_4  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_5  { readonly get => (sbyte4)((byte32)this).v4_5;    set { byte32 _this = (byte32)this; _this.v4_5  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_6  { readonly get => (sbyte4)((byte32)this).v4_6;    set { byte32 _this = (byte32)this; _this.v4_6  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_7  { readonly get => (sbyte4)((byte32)this).v4_7;    set { byte32 _this = (byte32)this; _this.v4_7  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_8  { readonly get => (sbyte4)((byte32)this).v4_8;    set { byte32 _this = (byte32)this; _this.v4_8  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_9  { readonly get => (sbyte4)((byte32)this).v4_9;    set { byte32 _this = (byte32)this; _this.v4_9  = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_10 { readonly get => (sbyte4)((byte32)this).v4_10;   set { byte32 _this = (byte32)this; _this.v4_10 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_11 { readonly get => (sbyte4)((byte32)this).v4_11;   set { byte32 _this = (byte32)this; _this.v4_11 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_12 { readonly get => (sbyte4)((byte32)this).v4_12;   set { byte32 _this = (byte32)this; _this.v4_12 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_13 { readonly get => (sbyte4)((byte32)this).v4_13;   set { byte32 _this = (byte32)this; _this.v4_13 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_14 { readonly get => (sbyte4)((byte32)this).v4_14;   set { byte32 _this = (byte32)this; _this.v4_14 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_15 { readonly get => (sbyte4)((byte32)this).v4_15;   set { byte32 _this = (byte32)this; _this.v4_15 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_16 { readonly get => (sbyte4)((byte32)this).v4_16;   set { byte32 _this = (byte32)this; _this.v4_16 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_17 { readonly get => (sbyte4)((byte32)this).v4_17;   set { byte32 _this = (byte32)this; _this.v4_17 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_18 { readonly get => (sbyte4)((byte32)this).v4_18;   set { byte32 _this = (byte32)this; _this.v4_18 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_19 { readonly get => (sbyte4)((byte32)this).v4_19;   set { byte32 _this = (byte32)this; _this.v4_19 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_20 { readonly get => (sbyte4)((byte32)this).v4_20;   set { byte32 _this = (byte32)this; _this.v4_20 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_21 { readonly get => (sbyte4)((byte32)this).v4_21;   set { byte32 _this = (byte32)this; _this.v4_21 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_22 { readonly get => (sbyte4)((byte32)this).v4_22;   set { byte32 _this = (byte32)this; _this.v4_22 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_23 { readonly get => (sbyte4)((byte32)this).v4_23;   set { byte32 _this = (byte32)this; _this.v4_23 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_24 { readonly get => (sbyte4)((byte32)this).v4_24;   set { byte32 _this = (byte32)this; _this.v4_24 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_25 { readonly get => (sbyte4)((byte32)this).v4_25;   set { byte32 _this = (byte32)this; _this.v4_25 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_26 { readonly get => (sbyte4)((byte32)this).v4_26;   set { byte32 _this = (byte32)this; _this.v4_26 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_27 { readonly get => (sbyte4)((byte32)this).v4_27;   set { byte32 _this = (byte32)this; _this.v4_27 = (byte4)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte4 v4_28 { readonly get => (sbyte4)((byte32)this).v4_28;   set { byte32 _this = (byte32)this; _this.v4_28 = (byte4)value; this = (sbyte32)_this; } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_0  { readonly get => (sbyte3)((byte32)this).v3_0;    set { byte32 _this = (byte32)this; _this.v3_0  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_1  { readonly get => (sbyte3)((byte32)this).v3_1;    set { byte32 _this = (byte32)this; _this.v3_1  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_2  { readonly get => (sbyte3)((byte32)this).v3_2;    set { byte32 _this = (byte32)this; _this.v3_2  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_3  { readonly get => (sbyte3)((byte32)this).v3_3;    set { byte32 _this = (byte32)this; _this.v3_3  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_4  { readonly get => (sbyte3)((byte32)this).v3_4;    set { byte32 _this = (byte32)this; _this.v3_4  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_5  { readonly get => (sbyte3)((byte32)this).v3_5;    set { byte32 _this = (byte32)this; _this.v3_5  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_6  { readonly get => (sbyte3)((byte32)this).v3_6;    set { byte32 _this = (byte32)this; _this.v3_6  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_7  { readonly get => (sbyte3)((byte32)this).v3_7;    set { byte32 _this = (byte32)this; _this.v3_7  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_8  { readonly get => (sbyte3)((byte32)this).v3_8;    set { byte32 _this = (byte32)this; _this.v3_8  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_9  { readonly get => (sbyte3)((byte32)this).v3_9;    set { byte32 _this = (byte32)this; _this.v3_9  = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_10 { readonly get => (sbyte3)((byte32)this).v3_10;   set { byte32 _this = (byte32)this; _this.v3_10 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_11 { readonly get => (sbyte3)((byte32)this).v3_11;   set { byte32 _this = (byte32)this; _this.v3_11 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_12 { readonly get => (sbyte3)((byte32)this).v3_12;   set { byte32 _this = (byte32)this; _this.v3_12 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_13 { readonly get => (sbyte3)((byte32)this).v3_13;   set { byte32 _this = (byte32)this; _this.v3_13 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_14 { readonly get => (sbyte3)((byte32)this).v3_14;   set { byte32 _this = (byte32)this; _this.v3_14 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_15 { readonly get => (sbyte3)((byte32)this).v3_15;   set { byte32 _this = (byte32)this; _this.v3_15 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_16 { readonly get => (sbyte3)((byte32)this).v3_16;   set { byte32 _this = (byte32)this; _this.v3_16 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_17 { readonly get => (sbyte3)((byte32)this).v3_17;   set { byte32 _this = (byte32)this; _this.v3_17 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_18 { readonly get => (sbyte3)((byte32)this).v3_18;   set { byte32 _this = (byte32)this; _this.v3_18 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_19 { readonly get => (sbyte3)((byte32)this).v3_19;   set { byte32 _this = (byte32)this; _this.v3_19 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_20 { readonly get => (sbyte3)((byte32)this).v3_20;   set { byte32 _this = (byte32)this; _this.v3_20 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_21 { readonly get => (sbyte3)((byte32)this).v3_21;   set { byte32 _this = (byte32)this; _this.v3_21 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_22 { readonly get => (sbyte3)((byte32)this).v3_22;   set { byte32 _this = (byte32)this; _this.v3_22 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_23 { readonly get => (sbyte3)((byte32)this).v3_23;   set { byte32 _this = (byte32)this; _this.v3_23 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_24 { readonly get => (sbyte3)((byte32)this).v3_24;   set { byte32 _this = (byte32)this; _this.v3_24 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_25 { readonly get => (sbyte3)((byte32)this).v3_25;   set { byte32 _this = (byte32)this; _this.v3_25 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_26 { readonly get => (sbyte3)((byte32)this).v3_26;   set { byte32 _this = (byte32)this; _this.v3_26 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_27 { readonly get => (sbyte3)((byte32)this).v3_27;   set { byte32 _this = (byte32)this; _this.v3_27 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_28 { readonly get => (sbyte3)((byte32)this).v3_28;   set { byte32 _this = (byte32)this; _this.v3_28 = (byte3)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 v3_29 { readonly get => (sbyte3)((byte32)this).v3_29;   set { byte32 _this = (byte32)this; _this.v3_29 = (byte3)value; this = (sbyte32)_this; } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_0  { readonly get => (sbyte2)((byte32)this).v2_0;    set { byte32 _this = (byte32)this; _this.v2_0  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_1  { readonly get => (sbyte2)((byte32)this).v2_1;    set { byte32 _this = (byte32)this; _this.v2_1  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_2  { readonly get => (sbyte2)((byte32)this).v2_2;    set { byte32 _this = (byte32)this; _this.v2_2  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_3  { readonly get => (sbyte2)((byte32)this).v2_3;    set { byte32 _this = (byte32)this; _this.v2_3  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_4  { readonly get => (sbyte2)((byte32)this).v2_4;    set { byte32 _this = (byte32)this; _this.v2_4  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_5  { readonly get => (sbyte2)((byte32)this).v2_5;    set { byte32 _this = (byte32)this; _this.v2_5  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_6  { readonly get => (sbyte2)((byte32)this).v2_6;    set { byte32 _this = (byte32)this; _this.v2_6  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_7  { readonly get => (sbyte2)((byte32)this).v2_7;    set { byte32 _this = (byte32)this; _this.v2_7  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_8  { readonly get => (sbyte2)((byte32)this).v2_8;    set { byte32 _this = (byte32)this; _this.v2_8  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_9  { readonly get => (sbyte2)((byte32)this).v2_9;    set { byte32 _this = (byte32)this; _this.v2_9  = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_10 { readonly get => (sbyte2)((byte32)this).v2_10;   set { byte32 _this = (byte32)this; _this.v2_10 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_11 { readonly get => (sbyte2)((byte32)this).v2_11;   set { byte32 _this = (byte32)this; _this.v2_11 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_12 { readonly get => (sbyte2)((byte32)this).v2_12;   set { byte32 _this = (byte32)this; _this.v2_12 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_13 { readonly get => (sbyte2)((byte32)this).v2_13;   set { byte32 _this = (byte32)this; _this.v2_13 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_14 { readonly get => (sbyte2)((byte32)this).v2_14;   set { byte32 _this = (byte32)this; _this.v2_14 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_15 { readonly get => (sbyte2)((byte32)this).v2_15;   set { byte32 _this = (byte32)this; _this.v2_15 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_16 { readonly get => (sbyte2)((byte32)this).v2_16;   set { byte32 _this = (byte32)this; _this.v2_16 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_17 { readonly get => (sbyte2)((byte32)this).v2_17;   set { byte32 _this = (byte32)this; _this.v2_17 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_18 { readonly get => (sbyte2)((byte32)this).v2_18;   set { byte32 _this = (byte32)this; _this.v2_18 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_19 { readonly get => (sbyte2)((byte32)this).v2_19;   set { byte32 _this = (byte32)this; _this.v2_19 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_20 { readonly get => (sbyte2)((byte32)this).v2_20;   set { byte32 _this = (byte32)this; _this.v2_20 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_21 { readonly get => (sbyte2)((byte32)this).v2_21;   set { byte32 _this = (byte32)this; _this.v2_21 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_22 { readonly get => (sbyte2)((byte32)this).v2_22;   set { byte32 _this = (byte32)this; _this.v2_22 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_23 { readonly get => (sbyte2)((byte32)this).v2_23;   set { byte32 _this = (byte32)this; _this.v2_23 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_24 { readonly get => (sbyte2)((byte32)this).v2_24;   set { byte32 _this = (byte32)this; _this.v2_24 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_25 { readonly get => (sbyte2)((byte32)this).v2_25;   set { byte32 _this = (byte32)this; _this.v2_25 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_26 { readonly get => (sbyte2)((byte32)this).v2_26;   set { byte32 _this = (byte32)this; _this.v2_26 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_27 { readonly get => (sbyte2)((byte32)this).v2_27;   set { byte32 _this = (byte32)this; _this.v2_27 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_28 { readonly get => (sbyte2)((byte32)this).v2_28;   set { byte32 _this = (byte32)this; _this.v2_28 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_29 { readonly get => (sbyte2)((byte32)this).v2_29;   set { byte32 _this = (byte32)this; _this.v2_29 = (byte2)value; this = (sbyte32)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 v2_30 { readonly get => (sbyte2)((byte32)this).v2_30;   set { byte32 _this = (byte32)this; _this.v2_30 = (byte2)value; this = (sbyte32)_this; } }
        #endregion


        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(sbyte32 input) => (byte32)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte32(v256 input) => (sbyte32)(byte32)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(bool x) => math.tosbyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(bool32 x) => (sbyte32)(mask8x32)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi8(x);
            }
            else
            {
                return new sbyte32((sbyte16)x.v16_0, (sbyte16)x.v16_16);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(sbyte32 x) => (mask8x32)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(sbyte32 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(byte x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(ushort x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(short x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(uint x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(int x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(ulong x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(long x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(UInt128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(Int128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(quarter x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(half x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(float x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(double x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(quadruple x) => (sbyte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(Unity.Mathematics.half x) => (sbyte32)(half)x;


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
                return new sbyte32(left.__x0 / right.__x0, left.__x16 / right.__x16);
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
                return new sbyte32(left.__x0 % right.__x0, left.__x16 % right.__x16);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator + (sbyte32 left, sbyte right) => left + (sbyte32)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator + (sbyte left, sbyte32 right) => (sbyte32)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator - (sbyte32 left, sbyte right) => left - (sbyte32)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator - (sbyte left, sbyte32 right) => (sbyte32)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator * (sbyte left, sbyte32 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator * (sbyte32 left, sbyte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constmullo_epi8(left, right);
                }
                else
                {
                    return Xse.mm256_mullo_epi8(left, Xse.mm256_set1_epi8(right));
                }
            }

            return new sbyte32(left.v16_0 * right, left.v16_16 * right);
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
                    return Xse.mm256_div_epi8(left, Xse.mm256_set1_epi8(right));
                }
            }

            return new sbyte32(left.v16_0 / right, left.v16_16 / right);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator / (sbyte left, sbyte32 right) => (sbyte32)left / right;

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
                    return Xse.mm256_rem_epi8(left, Xse.mm256_set1_epi8(right));
                }
            }

            return new sbyte32(left.v16_0 % right, left.v16_16 % right);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator % (sbyte left, sbyte32 right) => (sbyte32)left % right;


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
                return new sbyte32(-x.__x0, -x.__x16);
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
                return new sbyte32(x.__x0 + 1, x.__x16 + 1);
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
                return new sbyte32(x.__x0 - 1, x.__x16 - 1);
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
                return new sbyte32(x.__x0 >> n, x.__x16 >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator == (sbyte32 left, sbyte32 right) => (byte32)left == (byte32)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator < (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmplt_epi8(left, right);
            }
            else
            {
                return new mask8x32(left.__x0 < right.__x0, left.__x16 < right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator > (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cmpgt_epi8(left, right);
            }
            else
            {
                return new mask8x32(left.__x0 > right.__x0, left.__x16 > right.__x16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator != (sbyte32 left, sbyte32 right) => (byte32)left != (byte32)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator <= (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_not_si256(Avx2.mm256_cmpgt_epi8(left, right));
            }
            else
            {
                return new mask8x32(left.__x0 <= right.__x0, left.__x16 <= right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator >= (sbyte32 left, sbyte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_not_si256(Avx2.mm256_cmpgt_epi8(right, left));
            }
            else
            {
                return new mask8x32(left.__x0 >= right.__x0, left.__x16 >= right.__x16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte32 other) => ((byte32)this).Equals((byte32)other);

        public override readonly bool Equals(object obj) => obj is sbyte32 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() =>  $"sbyte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte32({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)},    {x16.ToString(format, formatProvider)}, {x17.ToString(format, formatProvider)}, {x18.ToString(format, formatProvider)}, {x19.ToString(format, formatProvider)},    {x20.ToString(format, formatProvider)}, {x21.ToString(format, formatProvider)}, {x22.ToString(format, formatProvider)}, {x23.ToString(format, formatProvider)},    {x24.ToString(format, formatProvider)}, {x25.ToString(format, formatProvider)}, {x26.ToString(format, formatProvider)}, {x27.ToString(format, formatProvider)},    {x28.ToString(format, formatProvider)}, {x29.ToString(format, formatProvider)}, {x30.ToString(format, formatProvider)}, {x31.ToString(format, formatProvider)})";
    }
}