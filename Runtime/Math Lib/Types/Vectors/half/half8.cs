using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

namespace MaxMath
{
#if DEBUG
    internal sealed class half8DebuggerProxy
    {
        public half x0;
        public half x1;
        public half x2;
        public half x3;
        public half x4;
        public half x5;
        public half x6;
        public half x7;
        
        public half8DebuggerProxy(half8 v)
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

    [System.Diagnostics.DebuggerTypeProxy(typeof(half8DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct half8 : IEquatable<half8>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x8;
        
        public ref half x0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half8* ptr = &this) { return ref *((half*)ptr + 0); } } }
        public ref half x1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half8* ptr = &this) { return ref *((half*)ptr + 1); } } }
        public ref half x2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half8* ptr = &this) { return ref *((half*)ptr + 2); } } }
        public ref half x3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half8* ptr = &this) { return ref *((half*)ptr + 3); } } }
        public ref half x4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half8* ptr = &this) { return ref *((half*)ptr + 4); } } }
        public ref half x5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half8* ptr = &this) { return ref *((half*)ptr + 5); } } }
        public ref half x6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half8* ptr = &this) { return ref *((half*)ptr + 6); } } }
        public ref half x7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half8* ptr = &this) { return ref *((half*)ptr + 7); } } }

        
        internal readonly bool8 IsZero => (math.asushort(this) & 0x7FFF) == 0;
        internal readonly bool8 IsNotZero => (math.asushort(this) & 0x7FFF) != 0;


        public static half8 zero => default;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half x0, half x1, half x2, half x3, half x4, half x5, half x6, half x7)
        {
            this = math.ashalf(new ushort8(asushort(x0), asushort(x1), asushort(x2), asushort(x3), asushort(x4), asushort(x5), asushort(x6), asushort(x7)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half x0x8)
        {
            this = math.ashalf(new ushort8(asushort(x0x8)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(Unity.Mathematics.half x0x8)
        {
            this = math.ashalf(new ushort8(asushort(x0x8)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half2 x23, half2 x45, half2 x67)
        {
            this = math.ashalf(new ushort8(asushort(x01), asushort(x23), asushort(x45), asushort(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half3 x234, half3 x567)
        {
            this = math.ashalf(new ushort8(asushort(x01), asushort(x234), asushort(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half3 x012, half2 x34, half3 x567)
        {
            this = math.ashalf(new ushort8(asushort(x012), asushort(x34), asushort(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half3 x012, half3 x345, half2 x67)
        {
            this = math.ashalf(new ushort8(asushort(x012), asushort(x345), asushort(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half4 x0123, half2 x45, half2 x67)
        {
            this = math.ashalf(new ushort8(asushort(x0123), asushort(x45), asushort(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half4 x2345, half2 x67)
        {
            this = math.ashalf(new ushort8(asushort(x01), asushort(x2345), asushort(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half2 x23, half4 x4567)
        {
            this = math.ashalf(new ushort8(asushort(x01), asushort(x23), asushort(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half4 x0123, half4 x4567)
        {
            this = math.ashalf(new ushort8(asushort(x0123), asushort(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(bool v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(bool8 v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(mask8x8 v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(mask16x8 v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(mask32x8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(byte v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(byte8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(sbyte v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(sbyte8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(ushort v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(ushort8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(short v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(short8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(uint v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(uint8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(int v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(int8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(ulong v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(long v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(UInt128 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(Int128 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(quarter v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(quarter8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(float v)
        {
            this = (half8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(float8 v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(double v)
        {
            this = (half8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(quadruple v)
        {
            this = (half8)v;
        }



#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v4_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v4_0 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v4_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v4_1 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v4_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v4_2 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v4_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v4_3 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v4_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v4_4 = math.asushort(value); this = math.ashalf(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v3_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v3_0 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v3_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v3_1 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v3_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v3_2 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v3_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v3_3 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v3_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v3_4 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v3_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v3_5 = math.asushort(value); this = math.ashalf(temp); } }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v2_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v2_0 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v2_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v2_1 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v2_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v2_2 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v2_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v2_3 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v2_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v2_4 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v2_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v2_5 = math.asushort(value); this = math.ashalf(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => math.ashalf(math.asushort(this).v2_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = math.asushort(this); temp.v2_6 = math.asushort(value); this = math.ashalf(temp); } }

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(half8 input) => asushort(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(v128 input) => ashalf((ushort8)input);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(bool x) => (half8)(mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(bool8 x) => (half8)(mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half8)(mask16x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_ph((half)1f));
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(mask32x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half8)(mask16x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(half8 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(half8 x) => (mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x8(half8 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(half8 x) => (mask16x8)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half8(byte x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half8(sbyte x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(ushort x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(short x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(uint x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(int x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(ulong x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(long x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(UInt128 x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(Int128 x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(quadruple x) => (half)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(Unity.Mathematics.half x) => (half8)(half)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(half input) => new half8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(float input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(double input) => (half)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(float8 input)
        {
            if (F16C.IsF16CSupported)
            {
                return Xse.mm256_cvtps_ph(input);
            }
            else
            {
                return new half8((half4)input.v4_0, (half4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(half8 input)
        {
            if (F16C.IsF16CSupported)
            {
                return Xse.mm256_cvtph_ps(input);
            }
            else
            {
                return new float8((float4)input.v4_0, (float4)input.v4_4);
            }
        }


        public half this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return ashalf(asushort(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ushort8 cpy = asushort(this);
                cpy[index] = asushort(value);
                this = ashalf(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 left, half8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_ph(left, right);
            }
            else
            {
                return new mask16x8(left.v4_0 == right.v4_0, left.v4_4 == right.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 left, half8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_ph(left, right);
            }
            else
            {
                return new mask16x8(left.v4_0 != right.v4_0, left.v4_4 != right.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 left, half8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_ph(left, right);
            }
            else
            {
                return new mask16x8(left.v4_0 < right.v4_0, left.v4_4 < right.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 left, half8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_ph(left, right);
            }
            else
            {
                return new mask16x8(left.v4_0 > right.v4_0, left.v4_4 > right.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 left, half8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_ph(left, right);
            }
            else
            {
                return new mask16x8(left.v4_0 <= right.v4_0, left.v4_4 <= right.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 left, half8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_ph(left, right);
            }
            else
            {
                return new mask16x8(left.v4_0 >= right.v4_0, left.v4_4 >= right.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 lhs, byte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half8)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 lhs, byte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs != rhs;
            }
            else
            {
                return lhs != (half8)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 lhs, byte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs < rhs;
            }
            else
            {
                return lhs < (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 lhs, byte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs > rhs;
            }
            else
            {
                return lhs > (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 lhs, byte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs <= rhs;
            }
            else
            {
                return lhs <= (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 lhs, byte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs >= rhs;
            }
            else
            {
                return lhs >= (half8)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (byte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float8)rhs;
            }
            else
            {
                return math.andnot((half8)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (byte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float8)rhs;
            }
            else
            {
                return (half8)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (byte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float8)rhs;
            }
            else
            {
                return (half8)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (byte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float8)rhs;
            }
            else
            {
                return (half8)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (byte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float8)rhs;
            }
            else
            {
                return (half8)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (byte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float8)rhs;
            }
            else
            {
                return (half8)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half8)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs != rhs;
            }
            else
            {
                return lhs != (half8)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs < rhs;
            }
            else
            {
                return lhs < (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs > rhs;
            }
            else
            {
                return lhs > (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs <= rhs;
            }
            else
            {
                return lhs <= (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs >= rhs;
            }
            else
            {
                return lhs >= (half8)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (byte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float8)rhs;
            }
            else
            {
                return (half8)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (byte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float8)rhs;
            }
            else
            {
                return (half8)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (byte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float8)rhs;
            }
            else
            {
                return (half8)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (byte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float8)rhs;
            }
            else
            {
                return (half8)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (byte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float8)rhs;
            }
            else
            {
                return (half8)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (byte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float8)rhs;
            }
            else
            {
                return (half8)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 lhs, sbyte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half8)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 lhs, sbyte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs != rhs;
            }
            else
            {
                return lhs != (half8)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 lhs, sbyte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs < rhs;
            }
            else
            {
                return lhs < (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 lhs, sbyte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs > rhs;
            }
            else
            {
                return lhs > (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 lhs, sbyte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs <= rhs;
            }
            else
            {
                return lhs <= (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 lhs, sbyte8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs >= rhs;
            }
            else
            {
                return lhs >= (half8)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (sbyte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float8)rhs;
            }
            else
            {
                return math.andnot((half8)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (sbyte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float8)rhs;
            }
            else
            {
                return (half8)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (sbyte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float8)rhs;
            }
            else
            {
                return (half8)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (sbyte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float8)rhs;
            }
            else
            {
                return (half8)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (sbyte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float8)rhs;
            }
            else
            {
                return (half8)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (sbyte8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float8)rhs;
            }
            else
            {
                return (half8)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half8)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs != rhs;
            }
            else
            {
                return lhs != (half8)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs < rhs;
            }
            else
            {
                return lhs < (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs > rhs;
            }
            else
            {
                return lhs > (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs <= rhs;
            }
            else
            {
                return lhs <= (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs >= rhs;
            }
            else
            {
                return lhs >= (half8)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (sbyte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float8)rhs;
            }
            else
            {
                return (half8)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (sbyte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float8)rhs;
            }
            else
            {
                return (half8)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (sbyte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float8)rhs;
            }
            else
            {
                return (half8)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (sbyte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float8)rhs;
            }
            else
            {
                return (half8)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (sbyte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float8)rhs;
            }
            else
            {
                return (half8)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (sbyte lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float8)rhs;
            }
            else
            {
                return (half8)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 lhs, short8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half8)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 lhs, short8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs != rhs;
            }
            else
            {
                return lhs != (half8)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 lhs, short8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs < rhs;
            }
            else
            {
                return lhs < (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 lhs, short8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs > rhs;
            }
            else
            {
                return lhs > (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 lhs, short8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs <= rhs;
            }
            else
            {
                return lhs <= (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 lhs, short8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs >= rhs;
            }
            else
            {
                return lhs >= (half8)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (short8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float8)rhs;
            }
            else
            {
                return math.andnot((half8)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (short8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float8)rhs;
            }
            else
            {
                return (half8)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (short8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float8)rhs;
            }
            else
            {
                return (half8)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (short8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float8)rhs;
            }
            else
            {
                return (half8)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (short8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float8)rhs;
            }
            else
            {
                return (half8)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (short8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float8)rhs;
            }
            else
            {
                return (half8)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half8)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs != rhs;
            }
            else
            {
                return lhs != (half8)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs < rhs;
            }
            else
            {
                return lhs < (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs > rhs;
            }
            else
            {
                return lhs > (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs <= rhs;
            }
            else
            {
                return lhs <= (half8)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float8)lhs >= rhs;
            }
            else
            {
                return lhs >= (half8)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (short lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float8)rhs;
            }
            else
            {
                return (half8)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (short lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float8)rhs;
            }
            else
            {
                return (half8)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (short lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float8)rhs;
            }
            else
            {
                return (half8)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (short lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float8)rhs;
            }
            else
            {
                return (half8)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (short lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float8)rhs;
            }
            else
            {
                return (half8)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (short lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float8)rhs;
            }
            else
            {
                return (half8)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 lhs, quarter8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs == rhs;
                }
            }
            
            return lhs == (half8)rhs;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 lhs, quarter8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs != rhs;
                }
            }
            
            return lhs != (half8)rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 lhs, quarter8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs < rhs;
                }
            }
            
            return lhs < (half8)rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 lhs, quarter8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs > rhs;
                }
            }
            
            return lhs > (half8)rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 lhs, quarter8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs <= rhs;
                }
            }
            
            return lhs <= (half8)rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 lhs, quarter8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs >= rhs;
                }
            }
            
            return lhs >= (half8)rhs;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (quarter8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs == (float8)rhs;
                }
            }
            
            return (half8)lhs == rhs;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (quarter8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs != (float8)rhs;
                }
            }
            
            return (half8)lhs != rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (quarter8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs < (float8)rhs;
                }
            }
            
            return (half8)lhs < rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (quarter8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs > (float8)rhs;
                }
            }
            
            return (half8)lhs > rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (quarter8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs <= (float8)rhs;
                }
            }
            
            return (half8)lhs <= rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (quarter8 lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs >= (float8)rhs;
                }
            }
            
            return (half8)lhs >= rhs;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (half8 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs == rhs;
                }
            }
            
            return lhs == (half8)rhs;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (half8 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs != rhs;
                }
            }
            
            return lhs != (half8)rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (half8 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs < rhs;
                }
            }
            
            return lhs < (half8)rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (half8 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs > rhs;
                }
            }
            
            return lhs > (half8)rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (half8 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs <= rhs;
                }
            }
            
            return lhs <= (half8)rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (half8 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return (float8)lhs >= rhs;
                }
            }
            
            return lhs >= (half8)rhs;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (quarter lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs == (float8)rhs;
                }
            }
            
            return (half8)lhs == rhs;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (quarter lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs != (float8)rhs;
                }
            }
            
            return (half8)lhs != rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (quarter lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs < (float8)rhs;
                }
            }
            
            return (half8)lhs < rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (quarter lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs > (float8)rhs;
                }
            }
            
            return (half8)lhs > rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (quarter lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs <= (float8)rhs;
                }
            }
            
            return (half8)lhs <= rhs;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (quarter lhs, half8 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == Unity.Burst.OptimizeFor.Size)
                {
                    return lhs >= (float8)rhs;
                }
            }
            
            return (half8)lhs >= rhs;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(half8 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return ulong.MaxValue == Xse.cmpeq_ph(this, other).ULong0;
            }
            else
            {
                return this.v4_0.Equals(other.v4_0) & this.v4_4.Equals(other.v4_4);
            }
        }

        public override readonly bool Equals(object obj) => obj is half8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"half8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"half8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}