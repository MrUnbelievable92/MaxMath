using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class bool8DebuggerProxy
    {
        public bool x0;
        public bool x1;
        public bool x2;
        public bool x3;
        public bool x4;
        public bool x5;
        public bool x6;
        public bool x7;
        
        public bool8DebuggerProxy(bool8 v)
        {
            x0 = v.x0;
            x1 = v.x1;
            x2 = v.x2;
            x3 = v.x3;
            x4 = v.x4;
            x5 = v.x5;
            x6 = v.x6;
            x7 = v.x7;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(bool8DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct bool8 : IEquatable<bool8>
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x0;
        
        public ref bool x0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool8* ptr = &this) { return ref *((bool*)ptr + 0); } } }
        public ref bool x1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool8* ptr = &this) { return ref *((bool*)ptr + 1); } } }
        public ref bool x2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool8* ptr = &this) { return ref *((bool*)ptr + 2); } } }
        public ref bool x3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool8* ptr = &this) { return ref *((bool*)ptr + 3); } } }
        public ref bool x4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool8* ptr = &this) { return ref *((bool*)ptr + 4); } } }
        public ref bool x5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool8* ptr = &this) { return ref *((bool*)ptr + 5); } } }
        public ref bool x6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool8* ptr = &this) { return ref *((bool*)ptr + 6); } } }
        public ref bool x7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool8* ptr = &this) { return ref *((bool*)ptr + 7); } } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7)
        {
            this = math.tobool(new byte8(math.tobyte(x0), math.tobyte(x1), math.tobyte(x2), math.tobyte(x3), math.tobyte(x4), math.tobyte(x5), math.tobyte(x6), math.tobyte(x7)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool x0x8)
        {
            this = math.tobool(new byte8(math.tobyte(x0x8)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool2 x01, bool2 x23, bool2 x45, bool2 x67)
        {
            this = math.tobool(new byte8(math.tobyte(x01), math.tobyte(x23), math.tobyte(x45), math.tobyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool2 x01, bool3 x234, bool3 x567)
        {
            this = math.tobool(new byte8(math.tobyte(x01), math.tobyte(x234), math.tobyte(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool3 x012, bool2 x34, bool3 x567)
        {
            this = math.tobool(new byte8(math.tobyte(x012), math.tobyte(x34), math.tobyte(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool3 x012, bool3 x345, bool2 x67)
        {
            this = math.tobool(new byte8(math.tobyte(x012), math.tobyte(x345), math.tobyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool4 x0123, bool2 x45, bool2 x67)
        {
            this = math.tobool(new byte8(math.tobyte(x0123), math.tobyte(x45), math.tobyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool2 x01, bool4 x2345, bool2 x67)
        {
            this = math.tobool(new byte8(math.tobyte(x01), math.tobyte(x2345), math.tobyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool2 x01, bool2 x23, bool4 x4567)
        {
            this = math.tobool(new byte8(math.tobyte(x01), math.tobyte(x23), math.tobyte(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool4 x0123, bool4 x4567)
        {
            this = math.tobool(new byte8(math.tobyte(x0123), math.tobyte(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(bool8 v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(mask8x8 v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(mask16x8 v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(mask32x8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(byte v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(byte8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(sbyte v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(sbyte8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(ushort v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(ushort8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(short v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(short8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(uint v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(uint8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(int v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(int8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(ulong v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(long v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(UInt128 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(Int128 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(quarter v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(quarter8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(half v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(half8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(float v)
        {
            this = (bool8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(float8 v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(double v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(quadruple v)
        {
            this = (bool8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8(Unity.Mathematics.half v)
        {
            this = (bool8)v;
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v4_0 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v4_1 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v4_2 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v4_3 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v4_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v4_4 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v3_0 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v3_1 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v3_2 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v3_3 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v3_4 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v3_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v3_5 = math.tobyte(value); this = math.tobool(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v2_0 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v2_1 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v2_2 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v2_3 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v2_4 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v2_5 = math.tobyte(value); this = math.tobool(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.tobool(math.tobyte(this).v2_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = math.tobyte(this); temp.v2_6 = math.tobyte(value); this = math.tobool(temp); } }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool8(v128 v) => ((byte8)v).Reinterpret<byte8, bool8>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(bool8 v) => v.Reinterpret<bool8, byte8>();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool8(bool x) => new bool8(x);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(quadruple v) => math.andnot(v != 0, math.isnan(v));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(Unity.Mathematics.half v) => (bool8)(half)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 operator == (bool8 left, bool8 right) => math.tobyte(left) == math.tobyte(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 operator != (bool8 left, bool8 right) => math.tobyte(left) != math.tobyte(right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator & (bool8 left, bool8 right) => math.tobool(math.tobyte(left) & math.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator | (bool8 left, bool8 right) => math.tobool(math.tobyte(left) | math.tobyte(right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator ^ (bool8 left, bool8 right) => math.tobool(math.tobyte(left) ^ math.tobyte(right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator ! (bool8 val)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.andnot_si128(val, new byte8(1));
            }
            else
            {
                return new bool8(!val.x0, !val.x1, !val.x2, !val.x3, !val.x4, !val.x5, !val.x6, !val.x7);
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
                byte8 cpy = math.tobyte(this);
                cpy[index] = math.tobyte(value);
                this = math.tobool(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool8 other) => math.tobyte(this).Equals(math.tobyte(other));

        public override readonly bool Equals(object obj) => obj is bool8 converted && this.Equals(converted);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);

        public override string ToString() => $"bool8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";

        
        /// <summary>       Returns a <see cref="bool4"/> from the first 8 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 FromBitmask(int bitmask)
        {
            bool8 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                result = Xse.broadcastmask_epi8(bitmask, MaskType.One, 8);
            }
            else
            {
                result = math.tobool(1 & new byte8((byte)bitmask, (byte)(bitmask >> 1), (byte)(bitmask >> 2), (byte)(bitmask >> 3), (byte)(bitmask >> 4), (byte)(bitmask >> 5), (byte)(bitmask >> 6), (byte)(bitmask >> 7)));
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b1111_1111));
            return result;
        }
    }
}