using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class sbyte2DebuggerProxy
    {
        public sbyte x;
        public sbyte y;

        public sbyte2DebuggerProxy(sbyte2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(sbyte2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct sbyte2 : IEquatable<sbyte2>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ushort __x0;
        
        public ref sbyte x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte2* ptr = &this) { return ref *((sbyte*)ptr +  0); } } }
        public ref sbyte y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte2* ptr = &this) { return ref *((sbyte*)ptr +  1); } } }


        public static sbyte2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte x, sbyte y)
        {
            this = (sbyte2)new byte2((byte)x, (byte)y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte xy)
        {
            this = (sbyte2)new byte2((byte)xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(bool v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(bool2 v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(mask8x2 v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(mask16x2 v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(mask32x2 v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(mask64x2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(byte v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(byte2 v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(ushort v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(ushort2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(short v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(short2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(uint v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(uint2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(int v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(int2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(ulong v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(ulong2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(long v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(long2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(UInt128 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(Int128 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(quarter v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(quarter2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(half v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(half2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(float v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(float2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(double v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(double2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(quadruple v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(Unity.Mathematics.bool2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(Unity.Mathematics.uint2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(Unity.Mathematics.int2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(Unity.Mathematics.half v)
        {
            this = (sbyte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(Unity.Mathematics.half2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(Unity.Mathematics.float2 v)
        {
            this = (sbyte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(Unity.Mathematics.double2 v)
        {
            this = (sbyte2)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxx => (sbyte4)((byte2)this).xxxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxy => (sbyte4)((byte2)this).xxxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyx => (sbyte4)((byte2)this).xxyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyy => (sbyte4)((byte2)this).xxyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxx => (sbyte4)((byte2)this).xyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxy => (sbyte4)((byte2)this).xyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyx => (sbyte4)((byte2)this).xyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyy => (sbyte4)((byte2)this).xyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxx => (sbyte4)((byte2)this).yxxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxy => (sbyte4)((byte2)this).yxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyx => (sbyte4)((byte2)this).yxyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyy => (sbyte4)((byte2)this).yxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxx => (sbyte4)((byte2)this).yyxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxy => (sbyte4)((byte2)this).yyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyx => (sbyte4)((byte2)this).yyyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyy => (sbyte4)((byte2)this).yyyy;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxx => (sbyte3)((byte2)this).xxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxy => (sbyte3)((byte2)this).xxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xyx => (sbyte3)((byte2)this).xyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xyy => (sbyte3)((byte2)this).xyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yxx => (sbyte3)((byte2)this).yxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yxy => (sbyte3)((byte2)this).yxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyx => (sbyte3)((byte2)this).yyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyy => (sbyte3)((byte2)this).yyy;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 xx => (sbyte2)((byte2)this).xx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 xy { readonly get => (sbyte2)((byte2)this).xy;  set { byte2 _this = (byte2)this; _this.xy = (byte2)value; this = (sbyte2)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 yx { readonly get => (sbyte2)((byte2)this).yx;  set { byte2 _this = (byte2)this; _this.yx = (byte2)value; this = (sbyte2)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 yy => (sbyte2)((byte2)this).yy;
		#endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte2 input) => (byte2)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(v128 input) => (sbyte2)(byte2)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(bool x) => math.tosbyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(bool2 x) => (sbyte2)(mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(Unity.Mathematics.bool2 x) => (sbyte2)(mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(sbyte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte2)(mask8x2)x;
            }
            else
            {
                return *(sbyte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte2)(mask8x2)x;
            }
            else
            {
                return *(sbyte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte2)(mask8x2)x;
            }
            else
            {
                return *(sbyte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(sbyte2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(sbyte2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(sbyte2 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(sbyte2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(sbyte2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(sbyte2 x) => (mask8x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(byte x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ushort x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(short x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(uint x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(int x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ulong x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(long x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(UInt128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(Int128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(quarter x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(half x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(float x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(double x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(quadruple x) => (sbyte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(Unity.Mathematics.half x) => (sbyte2)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(Unity.Mathematics.half2 x) => (sbyte2)(half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(Unity.Mathematics.float2 x) => (sbyte2)(float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(Unity.Mathematics.double2 x) => (sbyte2)(double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(Unity.Mathematics.uint2 x) => (sbyte2)(uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(Unity.Mathematics.int2 x) => (sbyte2)(int2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half2(sbyte2 x) => (half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(sbyte2 x) => (float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(sbyte2 x) => (double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint2(sbyte2 x) => (uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2(sbyte2 x) => (int2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(sbyte input) => new sbyte2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(byte2 input) => *(sbyte2*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(short2 input) => (sbyte2)(byte2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ushort2 input) => (sbyte2)(byte2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(int2 input) => (sbyte2)(byte2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(uint2 input) => (sbyte2)(byte2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(long2 input) => (sbyte2)(byte2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ulong2 input) => (sbyte2)(byte2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(float2 input) => (sbyte2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(double2 input) => (sbyte2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi16(input);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi16(input);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi32(input);
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi32(input);
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_ps(input);
            }
            else
            {
                return (float2)(int2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pd(input);
            }
            else
            {
                return (double2)(int2)input;
            }
        }


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (sbyte)((byte2)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte2 _this = (byte2)this;
                _this[index] = (byte)value;
                this = (sbyte2)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator + (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left + (byte2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left - (byte2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left * (byte2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi8(left, right, false, 2);
            }
            else
            {
                return new sbyte2((sbyte)(left.x / right.x), (sbyte)(left.y / right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator % (sbyte2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi8(left, right, 2);
            }
            else
            {
                return new sbyte2((sbyte)(left.x % right.x), (sbyte)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator + (sbyte2 left, sbyte right) => left + (sbyte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator + (sbyte left, sbyte2 right) => (sbyte2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 left, sbyte right) => left - (sbyte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte left, sbyte2 right) => (sbyte2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte2 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epi8(left, right, 2);
                }
            }

            return left * (sbyte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte left, sbyte2 right) => right * left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte left, sbyte2 right) => (sbyte2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi8(left, right, 2);
                }
            }

            return left / (sbyte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator % (sbyte left, sbyte2 right) => (sbyte2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator % (sbyte2 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi8(left, right, 2);
                }
            }

            return left % (sbyte2)right;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (sbyte2 left, Unity.Mathematics.int2 right) => left + (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (sbyte2 left, Unity.Mathematics.int2 right) => left - (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (sbyte2 left, Unity.Mathematics.int2 right) => left * (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (sbyte2 left, Unity.Mathematics.int2 right) => left / (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (sbyte2 left, Unity.Mathematics.int2 right) => left % (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (sbyte2 left, Unity.Mathematics.float2 right) => left + (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (sbyte2 left, Unity.Mathematics.float2 right) => left - (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (sbyte2 left, Unity.Mathematics.float2 right) => left * (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (sbyte2 left, Unity.Mathematics.float2 right) => left / (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (sbyte2 left, Unity.Mathematics.float2 right) => left % (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (sbyte2 left, Unity.Mathematics.double2 right) => left + (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (sbyte2 left, Unity.Mathematics.double2 right) => left - (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (sbyte2 left, Unity.Mathematics.double2 right) => left * (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (sbyte2 left, Unity.Mathematics.double2 right) => left / (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (sbyte2 left, Unity.Mathematics.double2 right) => left % (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator & (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left & (byte2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator | (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left | (byte2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ^ (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left ^ (byte2)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator & (sbyte left, sbyte2 right) => (sbyte2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator & (sbyte2 left, sbyte right) => left & (sbyte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator | (sbyte left, sbyte2 right) => (sbyte2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator | (sbyte2 left, sbyte right) => left | (sbyte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ^ (sbyte left, sbyte2 right) => (sbyte2)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ^ (sbyte2 left, sbyte right) => left ^ (sbyte2)right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (sbyte2 left, Unity.Mathematics.int2 right) => left & (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (sbyte2 left, Unity.Mathematics.int2 right) => left | (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (sbyte2 left, Unity.Mathematics.int2 right) => left ^ (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return new sbyte2((sbyte)(-x.x), (sbyte)(-x.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ++ (sbyte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new sbyte2((sbyte)(x.x + 1), (sbyte)(x.y + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator -- (sbyte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new sbyte2((sbyte)(x.x - 1), (sbyte)(x.y - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ~ (sbyte2 x) => (sbyte2)~(byte2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator << (sbyte2 x, int n) => (sbyte2)((byte2)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator >> (sbyte2 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi8(x, n, inRange: true, elements: 2);
            }
            else
            {
                return new sbyte2((sbyte)(x.x >> n), (sbyte)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (sbyte2 left, sbyte2 right) => (byte2)left == (byte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (sbyte2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epi8(left, right);
            }
            else
            {
                return new mask8x2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (sbyte2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epi8(left, right);
            }
            else
            {
                return new mask8x2(left.x > right.x, left.y > right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (sbyte2 left, sbyte2 right) => (byte2)left != (byte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (sbyte2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpgt_epi8(left, right));
            }
            else
            {
                return new mask8x2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (sbyte2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new mask8x2(left.x >= right.x, left.y >= right.y);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (sbyte2 left, sbyte right) => left == (sbyte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (sbyte left, sbyte2 right) => (sbyte2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (sbyte2 left, sbyte right) => left != (sbyte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (sbyte left, sbyte2 right) => (sbyte2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (sbyte2 left, sbyte right) => left < (sbyte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (sbyte left, sbyte2 right) => (sbyte2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (sbyte2 left, sbyte right) => left > (sbyte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (sbyte left, sbyte2 right) => (sbyte2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (sbyte2 left, sbyte right) => left <= (sbyte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (sbyte left, sbyte2 right) => (sbyte2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (sbyte2 left, sbyte right) => left >= (sbyte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (sbyte left, sbyte2 right) => (sbyte2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (sbyte2 left, Unity.Mathematics.int2 right) => left == (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (sbyte2 left, Unity.Mathematics.int2 right) => left != (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (sbyte2 left, Unity.Mathematics.int2 right) => left < (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (sbyte2 left, Unity.Mathematics.int2 right) => left > (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (sbyte2 left, Unity.Mathematics.int2 right) => left <= (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (sbyte2 left, Unity.Mathematics.int2 right) => left >= (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.int2 left, sbyte2 right) => (int2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (sbyte2 left, Unity.Mathematics.half2 right) => left == (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.half2 left, sbyte2 right) => (half2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (sbyte2 left, Unity.Mathematics.half2 right) => left != (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.half2 left, sbyte2 right) => (half2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (sbyte2 left, Unity.Mathematics.half2 right) => left < (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.half2 left, sbyte2 right) => (half2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (sbyte2 left, Unity.Mathematics.half2 right) => left > (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.half2 left, sbyte2 right) => (half2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (sbyte2 left, Unity.Mathematics.half2 right) => left <= (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.half2 left, sbyte2 right) => (half2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (sbyte2 left, Unity.Mathematics.half2 right) => left >= (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.half2 left, sbyte2 right) => (half2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (sbyte2 left, Unity.Mathematics.float2 right) => left == (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (sbyte2 left, Unity.Mathematics.float2 right) => left != (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (sbyte2 left, Unity.Mathematics.float2 right) => left < (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (sbyte2 left, Unity.Mathematics.float2 right) => left > (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (sbyte2 left, Unity.Mathematics.float2 right) => left <= (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (sbyte2 left, Unity.Mathematics.float2 right) => left >= (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.float2 left, sbyte2 right) => (float2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (sbyte2 left, Unity.Mathematics.double2 right) => left == (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (sbyte2 left, Unity.Mathematics.double2 right) => left != (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (sbyte2 left, Unity.Mathematics.double2 right) => left < (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (sbyte2 left, Unity.Mathematics.double2 right) => left > (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (sbyte2 left, Unity.Mathematics.double2 right) => left <= (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (sbyte2 left, Unity.Mathematics.double2 right) => left >= (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.double2 left, sbyte2 right) => (double2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte2 other) => ((byte2)this).Equals((byte2)other);

        public override readonly bool Equals(object obj) => obj is sbyte2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"sbyte2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}