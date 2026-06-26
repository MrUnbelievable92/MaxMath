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
    internal sealed class short8DebuggerProxy
    {
        public short x0;
        public short x1;
        public short x2;
        public short x3;
        public short x4;
        public short x5;
        public short x6;
        public short x7;
        
        public short8DebuggerProxy(short8 v)
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

    [System.Diagnostics.DebuggerTypeProxy(typeof(short8DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct short8 : IEquatable<short8>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x4;
        
        public ref short x0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short8* ptr = &this) { return ref *((short*)ptr + 0); } } }
        public ref short x1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short8* ptr = &this) { return ref *((short*)ptr + 1); } } }
        public ref short x2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short8* ptr = &this) { return ref *((short*)ptr + 2); } } }
        public ref short x3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short8* ptr = &this) { return ref *((short*)ptr + 3); } } }
        public ref short x4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short8* ptr = &this) { return ref *((short*)ptr + 4); } } }
        public ref short x5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short8* ptr = &this) { return ref *((short*)ptr + 5); } } }
        public ref short x6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short8* ptr = &this) { return ref *((short*)ptr + 6); } } }
        public ref short x7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short8* ptr = &this) { return ref *((short*)ptr + 7); } } }


        public static short8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7)
        {
            this = (short8)new ushort8((ushort)x0, (ushort)x1, (ushort)x2, (ushort)x3, (ushort)x4, (ushort)x5, (ushort)x6, (ushort)x7);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short x0x8)
        {
            this = (short8)new ushort8((ushort)x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short2 x23, short2 x45, short2 x67)
        {
            this = (short8)new ushort8((ushort2)x01, (ushort2)x23, (ushort2)x45, (ushort2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short3 x234, short3 x567)
        {
            this = (short8)new ushort8((ushort2)x01, (ushort3)x234, (ushort3)x567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short3 x012, short2 x34, short3 x567)
        {
            this = (short8)new ushort8((ushort3)x012, (ushort2)x34, (ushort3)x567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short3 x012, short3 x345, short2 x67)
        {
            this = (short8)new ushort8((ushort3)x012, (ushort3)x345, (ushort2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short4 x0123, short2 x45, short2 x67)
        {
            this = (short8)new ushort8((ushort4)x0123, (ushort2)x45, (ushort2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short4 x2345, short2 x67)
        {
            this = (short8)new ushort8((ushort2)x01, (ushort4)x2345, (ushort2)x67);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short2 x23, short4 x4567)
        {
            this = (short8)new ushort8((ushort2)x01, (ushort2)x23, (ushort4)x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short4 x0123, short4 x4567)
        {
            this = (short8)new ushort8((ushort4)x0123, (ushort4)x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(bool v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(bool8 v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(mask8x8 v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(mask16x8 v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(mask32x8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(byte v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(byte8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(sbyte v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(sbyte8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(ushort v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(ushort8 v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(uint v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(uint8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(int v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(int8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(ulong v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(long v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(UInt128 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(Int128 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(quarter v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(quarter8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(half v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(half8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(float v)
        {
            this = (short8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(float8 v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(double v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(quadruple v)
        {
            this = (short8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(Unity.Mathematics.half v)
        {
            this = (short8)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short4 v4_0  { readonly get => (short4)((ushort8)this).v4_0;    set { ushort8 _this = (ushort8)this; _this.v4_0  = (ushort4)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short4 v4_1  { readonly get => (short4)((ushort8)this).v4_1;    set { ushort8 _this = (ushort8)this; _this.v4_1  = (ushort4)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short4 v4_2  { readonly get => (short4)((ushort8)this).v4_2;    set { ushort8 _this = (ushort8)this; _this.v4_2  = (ushort4)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short4 v4_3  { readonly get => (short4)((ushort8)this).v4_3;    set { ushort8 _this = (ushort8)this; _this.v4_3  = (ushort4)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short4 v4_4  { readonly get => (short4)((ushort8)this).v4_4;    set { ushort8 _this = (ushort8)this; _this.v4_4  = (ushort4)value; this = (short8)_this; } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 v3_0  { readonly get => (short3)((ushort8)this).v3_0;    set { ushort8 _this = (ushort8)this; _this.v3_0  = (ushort3)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 v3_1  { readonly get => (short3)((ushort8)this).v3_1;    set { ushort8 _this = (ushort8)this; _this.v3_1  = (ushort3)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 v3_2  { readonly get => (short3)((ushort8)this).v3_2;    set { ushort8 _this = (ushort8)this; _this.v3_2  = (ushort3)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 v3_3  { readonly get => (short3)((ushort8)this).v3_3;    set { ushort8 _this = (ushort8)this; _this.v3_3  = (ushort3)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 v3_4  { readonly get => (short3)((ushort8)this).v3_4;    set { ushort8 _this = (ushort8)this; _this.v3_4  = (ushort3)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 v3_5  { readonly get => (short3)((ushort8)this).v3_5;    set { ushort8 _this = (ushort8)this; _this.v3_5  = (ushort3)value; this = (short8)_this; } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 v2_0  { readonly get => (short2)((ushort8)this).v2_0;    set { ushort8 _this = (ushort8)this; _this.v2_0  = (ushort2)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 v2_1  { readonly get => (short2)((ushort8)this).v2_1;    set { ushort8 _this = (ushort8)this; _this.v2_1  = (ushort2)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 v2_2  { readonly get => (short2)((ushort8)this).v2_2;    set { ushort8 _this = (ushort8)this; _this.v2_2  = (ushort2)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 v2_3  { readonly get => (short2)((ushort8)this).v2_3;    set { ushort8 _this = (ushort8)this; _this.v2_3  = (ushort2)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 v2_4  { readonly get => (short2)((ushort8)this).v2_4;    set { ushort8 _this = (ushort8)this; _this.v2_4  = (ushort2)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 v2_5  { readonly get => (short2)((ushort8)this).v2_5;    set { ushort8 _this = (ushort8)this; _this.v2_5  = (ushort2)value; this = (short8)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 v2_6  { readonly get => (short2)((ushort8)this).v2_6;    set { ushort8 _this = (ushort8)this; _this.v2_6  = (ushort2)value; this = (short8)_this; } }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short8 input) => (ushort8)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(v128 input) => (short8)(ushort8)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(bool8 x) => (short8)(mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (short8)(mask16x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(mask32x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (short8)(mask16x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(short8 x) => (mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(short8 x) => (mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x8(short8 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(short8 x) => (mask16x8)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short8(byte x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short8(sbyte x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(ushort x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(uint x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(int x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(ulong x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(long x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(UInt128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(Int128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(quarter x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(half x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(float x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(double x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(quadruple x) => (short)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(Unity.Mathematics.half x) => (short8)(half)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(short input) => new short8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(ushort8 input) => *(short8*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(uint8 input) => (short8)(ushort8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(int8 input) => (short8)(ushort8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(half8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(input);
            }
            else
            {
                return new short8((short)input.x0,
                                  (short)input.x1,
                                  (short)input.x2,
                                  (short)input.x3,
                                  (short)input.x4,
                                  (short)input.x5,
                                  (short)input.x6,
                                  (short)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(float8 input) => (short8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(short8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint8)Cast.Short8ToInt8(input);
            }
            else
            {
                return new uint8((uint4)input.v4_0, (uint4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(short8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Cast.Short8ToInt8(input);
            }
            else
            {
                return new int8((int4)input.v4_0, (int4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(short8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_ph(input);
            }
            else
            {
                return new half8((half)input.x0, (half)input.x1, (half)input.x2, (half)input.x3, (half)input.x4, (half)input.x5, (half)input.x6, (half)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(short8 input)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtepi16_ps(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo = Xse.cvt2x2epi16_ps(input, out v128 hi);

                return new float8(*(float4*)&lo, *(float4*)&hi);
            }
            else
            {
                return (float8)(int8)input;
            }
        }


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (short)((ushort8)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ushort8 _this = (ushort8)this;
                _this[index] = (ushort)value;
                this = (short8)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (short8 left, short8 right) => (short8)((ushort8)left + (ushort8)right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (short left, short8 right) => (short8)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (short8 left, short right) => left + (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 left, short8 right) => (short8)((ushort8)left - (ushort8)right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short left, short8 right) => (short8)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 left, short right) => left - (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, short8 right) => (short8)((ushort8)left * (ushort8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short left, short8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return new short8((short)(left.x0 * right), (short)(left.x1 * right), (short)(left.x2 * right), (short)(left.x3 * right), (short)(left.x4 * right), (short)(left.x5 * right), (short)(left.x6 * right), (short)(left.x7 * right));
                }
            }

            return left * (short8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi16(left, right, false, 8);
            }
            else
            {
                return new short8((short)(left.x0 / right.x0), (short)(left.x1 / right.x1), (short)(left.x2 / right.x2), (short)(left.x3 / right.x3), (short)(left.x4 / right.x4), (short)(left.x5 / right.x5), (short)(left.x6 / right.x6), (short)(left.x7 / right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short left, short8 right) => (short8)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, right, 8);
                }
            }

            return left / (short8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi16(left, right, 8);
            }
            else
            {
                return new short8((short)(left.x0 % right.x0), (short)(left.x1 % right.x1), (short)(left.x2 % right.x2), (short)(left.x3 % right.x3), (short)(left.x4 % right.x4), (short)(left.x5 % right.x5), (short)(left.x6 % right.x6), (short)(left.x7 % right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short left, short8 right) => (short8)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, right, 8);
                }
            }

            return left % (short8)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (short8 left, byte8 right) => left + (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (byte8 left, short8 right) => (short8)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 left, byte8 right) => left - (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (byte8 left, short8 right) => (short8)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, byte8 right) => left * (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (byte8 left, short8 right) => (short8)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, byte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, Xse.cvtepu8_epi16(right));
                }

                v128 left32lo = Xse.cvt2x2epi16_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epu8_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                v128 toInthi = Xse.cvttps_epi32(quotienthi);
                return Xse.packs_epi32(toIntlo, toInthi);
            }
            else
            {
                return new short8((short)(left.x0 / right.x0), (short)(left.x1 / right.x1), (short)(left.x2 / right.x2), (short)(left.x3 / right.x3), (short)(left.x4 / right.x4), (short)(left.x5 / right.x5), (short)(left.x6 / right.x6), (short)(left.x7 / right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (byte8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(Xse.cvtepu8_epi16(left), right);
                }

                v128 left32lo = Xse.cvt2x2epu8_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epi16_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                v128 toInthi = Xse.cvttps_epi32(quotienthi);
                return Xse.packs_epi32(toIntlo, toInthi);
            }
            else
            {
                return new short8((short)(left.x0 / right.x0), (short)(left.x1 / right.x1), (short)(left.x2 / right.x2), (short)(left.x3 / right.x3), (short)(left.x4 / right.x4), (short)(left.x5 / right.x5), (short)(left.x6 / right.x6), (short)(left.x7 / right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, byte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, Xse.cvtepu8_epi16(right));
                }

                v128 left32lo = Xse.cvt2x2epi16_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epu8_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                v128 toInthi = Xse.cvttps_epi32(quotienthi);
                v128 quotient = Xse.packs_epi32(toIntlo, toInthi);

                return Xse.sub_epi16(left, Xse.mullo_epi16(quotient, Xse.cvtepu8_epi16(right)));
            }
            else
            {
                return new short8((short)(left.x0 % right.x0), (short)(left.x1 % right.x1), (short)(left.x2 % right.x2), (short)(left.x3 % right.x3), (short)(left.x4 % right.x4), (short)(left.x5 % right.x5), (short)(left.x6 % right.x6), (short)(left.x7 % right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (byte8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(Xse.cvtepu8_epi16(left), right);
                }

                v128 left32lo = Xse.cvt2x2epu8_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epi16_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                v128 toInthi = Xse.cvttps_epi32(quotienthi);
                v128 quotient = Xse.packs_epi32(toIntlo, toInthi);

                return Xse.sub_epi16(Xse.cvtepu8_epi16(left), Xse.mullo_epi16(quotient, right));
            }
            else
            {
                return new short8((short)(left.x0 % right.x0), (short)(left.x1 % right.x1), (short)(left.x2 % right.x2), (short)(left.x3 % right.x3), (short)(left.x4 % right.x4), (short)(left.x5 % right.x5), (short)(left.x6 % right.x6), (short)(left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (short8 left, byte right) => left + (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (byte left, short8 right) => (short)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 left, byte right) => left - (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (byte left, short8 right) => (short)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, byte right) => left * (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (byte left, short8 right) => (short)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, byte right) => left / (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (byte left, short8 right) => (short)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, byte right) => left % (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (byte left, short8 right) => (short)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (short8 left, sbyte8 right) => left + (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (sbyte8 left, short8 right) => (short8)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 left, sbyte8 right) => left - (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (sbyte8 left, short8 right) => (short8)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, sbyte8 right) => left * (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (sbyte8 left, short8 right) => (short8)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, sbyte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, Xse.cvtepi8_epi16(right));
                }

                v128 left32lo = Xse.cvt2x2epi16_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epi8_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                v128 toInthi = Xse.cvttps_epi32(quotienthi);

                if (constexpr.ALL_GT_EPI16(left, short.MinValue, 8) || constexpr.ALL_NEQ_EPI8(right, -1, 8))
                {
                    return Xse.packs_epi32(toIntlo, toInthi);
                }
                else
                {
                    return Xse.cvt2x2epi32_epi16(toIntlo, toInthi);
                }
            }
            else
            {
                return new short8((short)(left.x0 / right.x0), (short)(left.x1 / right.x1), (short)(left.x2 / right.x2), (short)(left.x3 / right.x3), (short)(left.x4 / right.x4), (short)(left.x5 / right.x5), (short)(left.x6 / right.x6), (short)(left.x7 / right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (sbyte8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(Xse.cvtepi8_epi16(left), right);
                }

                v128 left32lo = Xse.cvt2x2epi8_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epi16_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                v128 toInthi = Xse.cvttps_epi32(quotienthi);
                return Xse.packs_epi32(toIntlo, toInthi);
            }
            else
            {
                return new short8((short)(left.x0 / right.x0), (short)(left.x1 / right.x1), (short)(left.x2 / right.x2), (short)(left.x3 / right.x3), (short)(left.x4 / right.x4), (short)(left.x5 / right.x5), (short)(left.x6 / right.x6), (short)(left.x7 / right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, sbyte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, Xse.cvtepi8_epi16(right));
                }

                v128 left32lo = Xse.cvt2x2epi16_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epi8_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                v128 toInthi = Xse.cvttps_epi32(quotienthi);
                v128 quotient;

                if (constexpr.ALL_GT_EPI16(left, short.MinValue, 8) || constexpr.ALL_NEQ_EPI8(right, -1, 8))
                {
                    quotient = Xse.packs_epi32(toIntlo, toInthi);
                }
                else
                {
                    quotient = Xse.cvt2x2epi32_epi16(toIntlo, toInthi);
                }

                return Xse.sub_epi16(left, Xse.mullo_epi16(quotient, Xse.cvtepi8_epi16(right)));
            }
            else
            {
                return new short8((short)(left.x0 % right.x0), (short)(left.x1 % right.x1), (short)(left.x2 % right.x2), (short)(left.x3 % right.x3), (short)(left.x4 % right.x4), (short)(left.x5 % right.x5), (short)(left.x6 % right.x6), (short)(left.x7 % right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (sbyte8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(Xse.cvtepi8_epi16(left), right);
                }

                v128 left32lo = Xse.cvt2x2epi8_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epi16_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                v128 toInthi = Xse.cvttps_epi32(quotienthi);
                v128 quotient = Xse.packs_epi32(toIntlo, toInthi);

                return Xse.sub_epi16(Xse.cvtepi8_epi16(left), Xse.mullo_epi16(quotient, right));
            }
            else
            {
                return new short8((short)(left.x0 % right.x0), (short)(left.x1 % right.x1), (short)(left.x2 % right.x2), (short)(left.x3 % right.x3), (short)(left.x4 % right.x4), (short)(left.x5 % right.x5), (short)(left.x6 % right.x6), (short)(left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (short8 left, sbyte right) => left + (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator + (sbyte left, short8 right) => (short)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 left, sbyte right) => left - (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (sbyte left, short8 right) => (short)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, sbyte right) => left * (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (sbyte left, short8 right) => (short)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, sbyte right) => left / (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (sbyte left, short8 right) => (short)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, sbyte right) => left % (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (sbyte left, short8 right) => (short)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (short8 left, short8 right) => (short8)((ushort8)left & (ushort8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (short8 left, short8 right) => (short8)((ushort8)left | (ushort8)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (short8 left, short8 right) => (short8)((ushort8)left ^ (ushort8)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (short8 left, short right) => left & (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (short left, short8 right) => (short8)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (short8 left, short right) => left | (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (short left, short8 right) => (short8)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (short8 left, short right) => left ^ (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (short left, short8 right) => (short8)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (short8 left, byte right) => left & (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (byte left, short8 right) => (short8)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (short8 left, byte right) => left | (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (byte left, short8 right) => (short8)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (short8 left, byte right) => left ^ (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (byte left, short8 right) => (short8)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (short8 left, sbyte right) => left & (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (sbyte left, short8 right) => (short8)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (short8 left, sbyte right) => left | (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (sbyte left, short8 right) => (short8)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (short8 left, sbyte right) => left ^ (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (sbyte left, short8 right) => (short8)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return new short8((short)(-x.x0), (short)(-x.x1), (short)(-x.x2), (short)(-x.x3), (short)(-x.x4), (short)(-x.x5), (short)(-x.x6), (short)(-x.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ++ (short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
            }
            else
            {
                return new short8((short)(x.x0 + 1), (short)(x.x1 + 1), (short)(x.x2 + 1), (short)(x.x3 + 1), (short)(x.x4 + 1), (short)(x.x5 + 1), (short)(x.x6 + 1), (short)(x.x7 + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator -- (short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
            }
            else
            {
                return new short8((short)(x.x0 - 1), (short)(x.x1 - 1), (short)(x.x2 - 1), (short)(x.x3 - 1), (short)(x.x4 - 1), (short)(x.x5 - 1), (short)(x.x6 - 1), (short)(x.x7 - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ~ (short8 x) => (short8)~(ushort8)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator << (short8 x, int n) => (short8)((ushort8)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator >> (short8 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi16(x, n, inRange: true);
            }
            else
            {
                return new short8((short)(x.x0 >> n), (short)(x.x1 >> n), (short)(x.x2 >> n), (short)(x.x3 >> n), (short)(x.x4 >> n), (short)(x.x5 >> n), (short)(x.x6 >> n), (short)(x.x7 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (short8 left, short8 right) => (ushort8)left == (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (short8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epi16(left, right);
            }
            else
            {
                return new mask16x8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (short8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epi16(left, right);
            }
            else
            {
                return new mask16x8(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (short8 left, short8 right) => (ushort8)left != (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (short8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpgt_epi16(left, right));
            }
            else
            {
                return new mask16x8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (short8 left, short8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmplt_epi16(left, right));
            }
            else
            {
                return new mask16x8(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (short8 left, short right) => left == (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (short left, short8 right) => (short8)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (short8 left, short right) => left != (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (short left, short8 right) => (short8)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (short8 left, short right) => left < (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (short left, short8 right) => (short8)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (short8 left, short right) => left > (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (short left, short8 right) => (short8)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (short8 left, short right) => left <= (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (short left, short8 right) => (short8)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (short8 left, short right) => left >= (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (short left, short8 right) => (short8)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (short8 left, byte right) => left == (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (byte left, short8 right) => (short8)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (short8 left, byte right) => left != (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (byte left, short8 right) => (short8)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (short8 left, byte right) => left < (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (byte left, short8 right) => (short8)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (short8 left, byte right) => left > (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (byte left, short8 right) => (short8)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (short8 left, byte right) => left <= (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (byte left, short8 right) => (short8)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (short8 left, byte right) => left >= (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (byte left, short8 right) => (short8)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (short8 left, sbyte right) => left == (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (sbyte left, short8 right) => (short8)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (short8 left, sbyte right) => left != (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (sbyte left, short8 right) => (short8)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (short8 left, sbyte right) => left < (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (sbyte left, short8 right) => (short8)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (short8 left, sbyte right) => left > (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (sbyte left, short8 right) => (short8)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (short8 left, sbyte right) => left <= (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (sbyte left, short8 right) => (short8)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (short8 left, sbyte right) => left >= (short8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (sbyte left, short8 right) => (short8)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short8 other) => ((ushort8)this).Equals((ushort8)other);

        public override readonly bool Equals(object obj) => obj is short8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"short8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}