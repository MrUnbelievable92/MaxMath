using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class bool16DebuggerProxy
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
        
        public bool16DebuggerProxy(bool16 v)
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

    [System.Diagnostics.DebuggerTypeProxy(typeof(bool16DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct bool16 : IEquatable<bool16>
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x8;
        
        public ref bool x0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  0); } } }
        public ref bool x1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  1); } } }
        public ref bool x2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  2); } } }
        public ref bool x3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  3); } } }
        public ref bool x4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  4); } } }
        public ref bool x5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  5); } } }
        public ref bool x6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  6); } } }
        public ref bool x7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  7); } } }
        public ref bool x8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  8); } } }
        public ref bool x9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr +  9); } } }
        public ref bool x10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr + 10); } } }
        public ref bool x11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr + 11); } } }
        public ref bool x12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr + 12); } } }
        public ref bool x13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr + 13); } } }
        public ref bool x14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr + 14); } } }
        public ref bool x15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool16* ptr = &this) { return ref *((bool*)ptr + 15); } } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15)
        {
            this = math.tobool(new byte16(math.tobyte(x0), math.tobyte(x1), math.tobyte(x2), math.tobyte(x3), math.tobyte(x4), math.tobyte(x5), math.tobyte(x6), math.tobyte(x7), math.tobyte(x8), math.tobyte(x9), math.tobyte(x10), math.tobyte(x11), math.tobyte(x12), math.tobyte(x13), math.tobyte(x14), math.tobyte(x15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool x0x16)
        {
            this = math.tobool(new byte16(math.tobyte(x0x16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool2 x01, bool2 x23, bool2 x45, bool2 x67, bool2 x89, bool2 x10_11, bool2 x12_13, bool2 x14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x01), math.tobyte(x23), math.tobyte(x45), math.tobyte(x67), math.tobyte(x89), math.tobyte(x10_11), math.tobyte(x12_13), math.tobyte(x14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool4 x4567, bool4 x8_9_10_11, bool4 x12_13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x0123), math.tobyte(x4567), math.tobyte(x8_9_10_11), math.tobyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool3 x456, bool3 x789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x0123), math.tobyte(x456), math.tobyte(x789), math.tobyte(x10_11_12), math.tobyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool4 x3456, bool3 x789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x012), math.tobyte(x3456), math.tobyte(x789), math.tobyte(x10_11_12), math.tobyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool4 x6789, bool3 x10_11_12, bool3 x13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x012), math.tobyte(x345), math.tobyte(x6789), math.tobyte(x10_11_12), math.tobyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool3 x678, bool4 x9_10_11_12, bool3 x13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x012), math.tobyte(x345), math.tobyte(x678), math.tobyte(x9_10_11_12), math.tobyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool3 x012, bool3 x345, bool3 x678, bool3 x9_10_11, bool4 x12_13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x012), math.tobyte(x345), math.tobyte(x678), math.tobyte(x9_10_11), math.tobyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool8 x01234567, bool4 x8_9_10_11, bool4 x12_13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x01234567), math.tobyte(x8_9_10_11), math.tobyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool8 x4_5_6_7_8_9_10_11, bool4 x12_13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x0123), math.tobyte(x4_5_6_7_8_9_10_11), math.tobyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool4 x0123, bool4 x4567, bool8 x8_9_10_11_12_13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x0123), math.tobyte(x4567), math.tobyte(x8_9_10_11_12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool8 x01234567, bool8 x8_9_10_11_12_13_14_15)
        {
            this = math.tobool(new byte16(math.tobyte(x01234567), math.tobyte(x8_9_10_11_12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(bool16 v)
        {
            this = (bool16)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(mask8x16 v)
        {
            this = (bool16)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(mask16x16 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(byte v)
        {
            this = (bool16)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(byte16 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(sbyte v)
        {
            this = (bool16)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(sbyte16 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(ushort v)
        {
            this = (bool16)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(ushort16 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(short v)
        {
            this = (bool16)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(short16 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(uint v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(int v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(ulong v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(long v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(UInt128 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(Int128 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(quarter v)
        {
            this = (bool16)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(quarter16 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(half v)
        {
            this = (bool16)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(half16 v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(float v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(double v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(quadruple v)
        {
            this = (bool16)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16(Unity.Mathematics.half v)
        {
            this = (bool16)v;
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_0 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_1 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_2 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_3 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_4 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_5 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_6 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_7); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_7 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool8 v8_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v8_8); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v8_8 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_0  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_1  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_2  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_3  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_4  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_5  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_6  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_7  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_8  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_9  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_10 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_11 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v4_12 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_0  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_1  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_2  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_3  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_4  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_5  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_6  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_7  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_8  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_9  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_10 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_11 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_12 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v3_13 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_0 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_0  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_1 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_1  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_2 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_2  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_3 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_3  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_4 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_4  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_5 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_5  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_6 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_6  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_7 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_7  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_8 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_8  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_9 ); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_9  = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_10 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_11 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_12 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_13 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = math.tobyte(this); temp.v2_14 = math.tobyte(value); this = math.tobool(temp); } }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool16(v128 v) => ((byte16)v).Reinterpret<byte16, bool16>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(bool16 v) => v.Reinterpret<bool16, byte16>();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool16(bool x) => new bool16(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(quadruple v) => math.andnot(v != 0, math.isnan(v));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool16(Unity.Mathematics.half v) => (bool16)(half)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 operator == (bool16 left, bool16 right) => math.tobyte(left) == math.tobyte(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 operator != (bool16 left, bool16 right) => math.tobyte(left) != math.tobyte(right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator & (bool16 left, bool16 right) => math.tobool(math.tobyte(left) & math.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator | (bool16 left, bool16 right) => math.tobool(math.tobyte(left) | math.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator ^ (bool16 left, bool16 right) => math.tobool(math.tobyte(left) ^ math.tobyte(right));


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
                return math.tobool(math.tobyte(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte16 cpy = math.tobyte(this);
                cpy[index] = math.tobyte(value);
                this = math.tobool(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool16 other) => math.tobyte(this).Equals(math.tobyte(other));

        public override readonly bool Equals(object obj) => obj is bool16 converted && this.Equals(converted);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);

        public override string ToString() => $"bool16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";

        
        /// <summary>       Returns a <see cref="bool16"/> from the first 16 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 FromBitmask(int bitmask)
        {
            bool16 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                result = Xse.broadcastmask_epi8(bitmask, MaskType.One, 16);
            }
            else
            {
                result = math.tobool(1 & new byte16((byte)bitmask, (byte)(bitmask >> 1), (byte)(bitmask >> 2), (byte)(bitmask >> 3), (byte)(bitmask >> 4), (byte)(bitmask >> 5), (byte)(bitmask >> 6), (byte)(bitmask >> 7), (byte)(bitmask >> 8), (byte)(bitmask >> 9), (byte)(bitmask >> 10), (byte)(bitmask >> 11), (byte)(bitmask >> 12), (byte)(bitmask >> 13), (byte)(bitmask >> 14), (byte)(bitmask >> 15)));
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b1111_1111_1111_1111));
            return result;
        }
    }
}