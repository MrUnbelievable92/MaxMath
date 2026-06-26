using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class bool32DebuggerProxy
    {
        public bool x0;
        public bool x1;
        public bool x2;
        public bool x3;
        public bool x4;
        public bool x5;
        public bool x6;
        public bool x7;
        public bool x8;
        public bool x9;
        public bool x10;
        public bool x11;
        public bool x12;
        public bool x13;
        public bool x14;
        public bool x15;
        public bool x16;
        public bool x17;
        public bool x18;
        public bool x19;
        public bool x20;
        public bool x21;
        public bool x22;
        public bool x23;
        public bool x24;
        public bool x25;
        public bool x26;
        public bool x27;
        public bool x28;
        public bool x29;
        public bool x30;
        public bool x31;
        
        public bool32DebuggerProxy(bool32 v)
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

    [System.Diagnostics.DebuggerTypeProxy(typeof(bool32DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct bool32 : IEquatable<bool32>
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal bool16 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal bool16 __x16;

        public ref bool x0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  0); } } }
        public ref bool x1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  1); } } }
        public ref bool x2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  2); } } }
        public ref bool x3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  3); } } }
        public ref bool x4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  4); } } }
        public ref bool x5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  5); } } }
        public ref bool x6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  6); } } }
        public ref bool x7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  7); } } }
        public ref bool x8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  8); } } }
        public ref bool x9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr +  9); } } }
        public ref bool x10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 10); } } }
        public ref bool x11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 11); } } }
        public ref bool x12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 12); } } }
        public ref bool x13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 13); } } }
        public ref bool x14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 14); } } }
        public ref bool x15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 15); } } }
        public ref bool x16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 16); } } }
        public ref bool x17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 17); } } }
        public ref bool x18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 18); } } }
        public ref bool x19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 19); } } }
        public ref bool x20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 20); } } }
        public ref bool x21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 21); } } }
        public ref bool x22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 22); } } }
        public ref bool x23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 23); } } }
        public ref bool x24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 24); } } }
        public ref bool x25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 25); } } }
        public ref bool x26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 26); } } }
        public ref bool x27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 27); } } }
        public ref bool x28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 28); } } }
        public ref bool x29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 29); } } }
        public ref bool x30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 30); } } }
        public ref bool x31 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool32* ptr = &this) { return ref *((bool*)ptr + 31); } } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15, bool x16, bool x17, bool x18, bool x19, bool x20, bool x21, bool x22, bool x23, bool x24, bool x25, bool x26, bool x27, bool x28, bool x29, bool x30, bool x31)
        {
            this = math.tobool(new byte32(math.tobyte(x0), math.tobyte(x1), math.tobyte(x2), math.tobyte(x3), math.tobyte(x4), math.tobyte(x5), math.tobyte(x6), math.tobyte(x7), math.tobyte(x8), math.tobyte(x9), math.tobyte(x10), math.tobyte(x11), math.tobyte(x12), math.tobyte(x13), math.tobyte(x14), math.tobyte(x15), math.tobyte(x16), math.tobyte(x17), math.tobyte(x18), math.tobyte(x19), math.tobyte(x20), math.tobyte(x21), math.tobyte(x22), math.tobyte(x23), math.tobyte(x24), math.tobyte(x25), math.tobyte(x26), math.tobyte(x27), math.tobyte(x28), math.tobyte(x29), math.tobyte(x30), math.tobyte(x31)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool x0x32)
        {
            this = math.tobool(new byte32(math.tobyte(x0x32)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool4 x0_3, bool4 x4_7, bool4 x8_11, bool4 x12_15, bool4 x16_19, bool4 x20_23, bool4 x24_27, bool4 x28_31)
        {
            this = math.tobool(new byte32(math.tobyte(x0_3), math.tobyte(x4_7), math.tobyte(x8_11), math.tobyte(x12_15), math.tobyte(x16_19), math.tobyte(x20_23), math.tobyte(x24_27), math.tobyte(x28_31)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool8 v8_8, bool8 v8_16, bool8 v8_24)
        {
            this = math.tobool(new byte32(math.tobyte(v8_0), math.tobyte(v8_8), math.tobyte(v8_16), math.tobyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool16 v16_0, bool8 v8_16, bool8 v8_24)
        {
            this = math.tobool(new byte32(math.tobyte(v16_0), math.tobyte(v8_16), math.tobyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool16 v16_8, bool8 v8_24)
        {
            this = math.tobool(new byte32(math.tobyte(v8_0), math.tobyte(v16_8), math.tobyte(v8_24)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool8 v8_0, bool8 v8_8, bool16 v16_16)
        {
            this = math.tobool(new byte32(math.tobyte(v8_0), math.tobyte(v8_8), math.tobyte(v16_16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool16 v16_0, bool16 v16_1)
        {
            this = math.tobool(new byte32(math.tobyte(v16_0), math.tobyte(v16_1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(bool32 v)
        {
            this = (bool32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(mask8x32 v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(byte v)
        {
            this = (bool32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(byte32 v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(sbyte v)
        {
            this = (bool32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(sbyte32 v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(ushort v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(short v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(uint v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(int v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(ulong v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(long v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(UInt128 v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(Int128 v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(quarter v)
        {
            this = (bool32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(quarter32 v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(half v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(float v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(double v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(quadruple v)
        {
            this = (bool32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32(Unity.Mathematics.half v)
        {
            this = (bool32)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_0  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_1  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_2  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_3  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_4  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_5  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_6  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_7  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_8  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_9  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_10 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_11 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_12 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_13 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_14 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_15 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v16_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v16_16 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_0  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_1  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_2  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_3  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_4  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_5  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_6  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_7  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_8  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_9  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_10 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_11 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_12 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_13 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_14 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_15 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_16 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_17 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_18 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_19 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_20 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_21 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_22 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_23 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v8_24 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_0  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_1  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_2  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_3  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_4  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_5  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_6  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_7  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_8  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_9  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_10 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_11 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_12 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_13 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_14 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_15 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_16 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_17 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_18 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_19 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_20 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_21 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_22 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_23 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_24 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_25 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_26 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_27 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v4_28 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_0  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_1  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_2  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_3  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_4  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_5  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_6  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_7  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_8  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_9  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_10 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_11 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_12 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_13 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_14 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_15 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_16 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_17 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_18 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_19 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_20 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_21 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_22 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_23 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_24 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_25 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_26 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_27 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_28 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_29); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v3_29 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_0  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_1  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_2  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_3  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_4  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_5  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_6  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_7  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_8  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_9  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_10 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_11 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_12 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_13 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_14 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_15); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_15 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_16); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_16 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_17); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_17 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_18); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_18 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_19); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_19 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_20); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_20 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_21); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_21 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_22); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_22 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_23); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_23 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_24); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_24 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_25); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_25 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_26); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_26 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_27); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_27 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_28); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_28 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_29); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_29 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_30); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte32 temp = math.tobyte(this); temp.v2_30 = math.tobyte(value); this = math.tobool(temp); } }
        #endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool32(v256 v) => ((byte32)v).Reinterpret<byte32, bool32>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(bool32 v) => v.Reinterpret<bool32, byte32>();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool32(bool x) => new bool32(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(quadruple v) => math.andnot(v != 0, math.isnan(v));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(Unity.Mathematics.half v) => (bool32)(half)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator == (bool32 left, bool32 right) => math.tobyte(left) == math.tobyte(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator != (bool32 left, bool32 right) => math.tobyte(left) != math.tobyte(right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator & (bool32 left, bool32 right) => math.tobool(math.tobyte(left) & math.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator | (bool32 left, bool32 right) => math.tobool(math.tobyte(left) | math.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ^ (bool32 left, bool32 right) => math.tobool(math.tobyte(left) ^ math.tobyte(right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator ! (bool32 val)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_andnot_ps(val, Xse.mm256_set1_epi8(1));
            }
            else
            {
                return new bool32(!val.__x0, !val.__x16);
            }
        }


        public bool this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return math.tobool(math.tobyte(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte32 cpy = math.tobyte(this);
                cpy[index] = math.tobyte(value);
                this = math.tobool(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool32 other) => math.tobyte(this).Equals(math.tobyte(other));

        public override readonly bool Equals(object obj) => obj is bool32 converted && this.Equals(converted);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);

        public override string ToString() => $"bool32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";

        
        /// <summary>       Returns a <see cref="bool32"/> from the bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 FromBitmask(int bitmask)
        {
            bool32 result;
            if (Avx2.IsAvx2Supported)
            {
                result = Xse.mm256_broadcastmask_epi8(bitmask, MaskType.One);
            }
            else
            {
                result = new bool32(bool16.FromBitmask(bitmask), bool16.FromBitmask((int)(uint)(bitmask >> 16)));
            }

            constexpr.ASSUME(math.bitmask(result) == bitmask);
            return result;
        }
    }
}