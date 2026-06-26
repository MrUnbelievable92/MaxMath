using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class short2DebuggerProxy
    {
        public short x;
        public short y;

        public short2DebuggerProxy(short2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(short2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct short2 : IEquatable<short2>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint __x0;
        
        public ref short x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short2* ptr = &this) { return ref *((short*)ptr +  0); } } }
        public ref short y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short2* ptr = &this) { return ref *((short*)ptr +  1); } } }


        public static short2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(short x, short y)
        {
            this = (short2)new ushort2((ushort)x, (ushort)y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(short xy)
        {
            this = (short2)new ushort2((ushort)xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(bool v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(bool2 v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(mask8x2 v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(mask16x2 v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(mask32x2 v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(mask64x2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(byte v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(byte2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(sbyte v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(sbyte2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(ushort v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(ushort2 v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(short2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(uint v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(uint2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(int v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(int2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(ulong v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(ulong2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(long v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(long2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(UInt128 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(Int128 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(quarter v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(quarter2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(half v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(half2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(float v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(float2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(double v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(double2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(quadruple v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(Unity.Mathematics.bool2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(Unity.Mathematics.uint2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(Unity.Mathematics.int2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(Unity.Mathematics.half v)
        {
            this = (short2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(Unity.Mathematics.half2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(Unity.Mathematics.float2 v)
        {
            this = (short2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(Unity.Mathematics.double2 v)
        {
            this = (short2)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxxx => (short4)((ushort2)this).xxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxxy => (short4)((ushort2)this).xxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxyx => (short4)((ushort2)this).xxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxyy => (short4)((ushort2)this).xxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyxx => (short4)((ushort2)this).xyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyxy => (short4)((ushort2)this).xyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyyx => (short4)((ushort2)this).xyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyyy => (short4)((ushort2)this).xyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxxx => (short4)((ushort2)this).yxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxxy => (short4)((ushort2)this).yxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxyx => (short4)((ushort2)this).yxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxyy => (short4)((ushort2)this).yxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyxx => (short4)((ushort2)this).yyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyxy => (short4)((ushort2)this).yyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyyx => (short4)((ushort2)this).yyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyyy => (short4)((ushort2)this).yyyy;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xxx => (short3)((ushort2)this).xxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xxy => (short3)((ushort2)this).xxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xyx => (short3)((ushort2)this).xyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xyy => (short3)((ushort2)this).xyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yxx => (short3)((ushort2)this).yxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yxy => (short3)((ushort2)this).yxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yyx => (short3)((ushort2)this).yyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yyy => (short3)((ushort2)this).yyy;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short2 xx => (short2)((ushort2)this).xx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 xy { readonly get => (short2)((ushort2)this).xy;  set { ushort2 _this = (ushort2)this; _this.xy = (ushort2)value; this = (short2)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 yx { readonly get => (short2)((ushort2)this).yx;  set { ushort2 _this = (ushort2)this; _this.yx = (ushort2)value; this = (short2)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short2 yy => (short2)((ushort2)this).yy;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short2 input) => (ushort2)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(v128 input) => (short2)(ushort2)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(bool2 x) => (short2)(mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(Unity.Mathematics.bool2 x) => (short2)(mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (short2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (short2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (short2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(short2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(short2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(short2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(short2 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(short2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(short2 x) => (mask16x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short2(byte x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short2(sbyte x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ushort x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(uint x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(int x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ulong x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(long x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(UInt128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(Int128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(quarter x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(half x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(float x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(double x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(quadruple x) => (short)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(Unity.Mathematics.half x) => (short2)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(Unity.Mathematics.half2 x) => (short2)(half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(Unity.Mathematics.float2 x) => (short2)(float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(Unity.Mathematics.double2 x) => (short2)(double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(Unity.Mathematics.uint2 x) => (short2)(uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(Unity.Mathematics.int2 x) => (short2)(int2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half2(short2 x) => (half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(short2 x) => (float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(short2 x) => (double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(short2 x) => (uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2(short2 x) => (int2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(short input) => new short2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ushort2 input) => *(short2*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(int2 input) => (short2)(ushort2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(uint2 input) => (short2)(ushort2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(long2 input) => (short2)(ushort2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ulong2 input) => (short2)(ushort2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(float2 input) => (short2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(double2 input) => (short2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi32(input);
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi32(input);
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_ps(input);
            }
            else
            {
                return (float2)(int2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pd(input);
            }
            else
            {
                return (double2)(int2)input;
            }
        }


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (short)((ushort2)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ushort2 _this = (ushort2)this;
                _this[index] = (ushort)value;
                this = (short2)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (short2 left, short2 right) => (short2)((ushort2)left + (ushort2)right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (short left, short2 right) => (short2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (short2 left, short right) => left + (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 left, short2 right) => (short2)((ushort2)left - (ushort2)right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short left, short2 right) => (short2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 left, short right) => left - (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, short2 right) => (short2)((ushort2)left * (ushort2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short left, short2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return new short2((short)(left.x * right), (short)(left.y * right));
                }
            }

            return left * (short2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi16(left, right, false, 2);
            }
            else
            {
                return new short2((short)(left.x / right.x), (short)(left.y / right.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short left, short2 right) => (short2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, right, 2);
                }
            }

            return left / (short2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi16(left, right, 2);
            }
            else
            {
                return new short2((short)(left.x % right.x), (short)(left.y % right.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short left, short2 right) => (short2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, right, 2);
                }
            }

            return left % (short2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (short2 left, byte2 right) => left + (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (byte2 left, short2 right) => (short2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 left, byte2 right) => left - (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (byte2 left, short2 right) => (short2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, byte2 right) => left * (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (byte2 left, short2 right) => (short2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, Xse.cvtepu8_epi16(right));
                }

                v128 left22 = Xse.cvtepi16_ps(left);
                v128 right22 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                return Xse.packs_epi32(toInt, toInt);
            }
            else
            {
                return new short2((short)(left.x / right.x), (short)(left.y / right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (byte2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(Xse.cvtepu8_epi16(left), right);
                }

                v128 left22 = Xse.cvtepu8_ps(left);
                v128 right22 = Xse.cvtepi16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                return Xse.packs_epi32(toInt, toInt);
            }
            else
            {
                return new short2((short)(left.x / right.x), (short)(left.y / right.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, Xse.cvtepu8_epi16(right));
                }

                v128 left22 = Xse.cvtepi16_ps(left);
                v128 right22 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                v128 toInt16 = Xse.packs_epi32(toInt, toInt);

                return Xse.sub_epi16(left, Xse.mullo_epi16(toInt16, Xse.cvtepu8_epi16(right)));
            }
            else
            {
                return new short2((short)(left.x % right.x), (short)(left.y % right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (byte2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(Xse.cvtepu8_epi16(left), right);
                }

                v128 left22 = Xse.cvtepu8_ps(left);
                v128 right22 = Xse.cvtepi16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                v128 toInt16 = Xse.packs_epi32(toInt, toInt);

                return Xse.sub_epi16(Xse.cvtepu8_epi16(left), Xse.mullo_epi16(toInt16, right));
            }
            else
            {
                return new short2((short)(left.x % right.x), (short)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (short2 left, byte right) => left + (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (byte left, short2 right) => (short)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 left, byte right) => left - (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (byte left, short2 right) => (short)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, byte right) => left * (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (byte left, short2 right) => (short)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, byte right) => left / (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (byte left, short2 right) => (short)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, byte right) => left % (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (byte left, short2 right) => (short)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (short2 left, sbyte2 right) => left + (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (sbyte2 left, short2 right) => (short2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 left, sbyte2 right) => left - (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (sbyte2 left, short2 right) => (short2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, sbyte2 right) => left * (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (sbyte2 left, short2 right) => (short2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, Xse.cvtepi8_epi16(right));
                }

                v128 left22 = Xse.cvtepi16_ps(left);
                v128 right22 = Xse.cvtepi8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);
                
                v128 toInt = Xse.cvttps_epi32(quotient);

                if (constexpr.ALL_GT_EPI16(left, short.MinValue, 2) || constexpr.ALL_NEQ_EPI8(right, -1, 2))
                {
                    return Xse.packs_epi32(toInt, toInt);
                }
                else
                {
                    return Xse.cvtepi32_epi16(toInt);
                }
            }
            else
            {
                return new short2((short)(left.x / right.x), (short)(left.y / right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (sbyte2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(Xse.cvtepi8_epi16(left), right);
                }

                v128 left22 = Xse.cvtepi8_ps(left);
                v128 right22 = Xse.cvtepi16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                return Xse.packs_epi32(toInt, toInt);
            }
            else
            {
                return new short2((short)(left.x / right.x), (short)(left.y / right.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, Xse.cvtepi8_epi16(right));
                }

                v128 left22 = Xse.cvtepi16_ps(left);
                v128 right22 = Xse.cvtepi8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                v128 quotient16;

                if (constexpr.ALL_GT_EPI16(left, short.MinValue, 2) || constexpr.ALL_NEQ_EPI8(right, -1, 2))
                {
                    quotient16 = Xse.packs_epi32(toInt, toInt);
                }
                else
                {
                    quotient16 = Xse.cvtepi32_epi16(toInt);
                }

                return Xse.sub_epi16(left, Xse.mullo_epi16(quotient16, Xse.cvtepi8_epi16(right)));
            }
            else
            {
                return new short2((short)(left.x % right.x), (short)(left.y % right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (sbyte2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(Xse.cvtepi8_epi16(left), right);
                }

                v128 left22 = Xse.cvtepi8_ps(left);
                v128 right22 = Xse.cvtepi16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                v128 quotient16 = Xse.packs_epi32(toInt, toInt);

                return Xse.sub_epi16(Xse.cvtepi8_epi16(left), Xse.mullo_epi16(quotient16, right));
            }
            else
            {
                return new short2((short)(left.x % right.x), (short)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (short2 left, sbyte right) => left + (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (sbyte left, short2 right) => (short)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 left, sbyte right) => left - (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (sbyte left, short2 right) => (short)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, sbyte right) => left * (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (sbyte left, short2 right) => (short)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, sbyte right) => left / (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (sbyte left, short2 right) => (short)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, sbyte right) => left % (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (sbyte left, short2 right) => (short)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (short2 left, Unity.Mathematics.int2 right) => left + (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (Unity.Mathematics.int2 left, short2 right) => (int2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (short2 left, Unity.Mathematics.int2 right) => left - (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (Unity.Mathematics.int2 left, short2 right) => (int2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (short2 left, Unity.Mathematics.int2 right) => left * (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (Unity.Mathematics.int2 left, short2 right) => (int2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (short2 left, Unity.Mathematics.int2 right) => left / (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (Unity.Mathematics.int2 left, short2 right) => (int2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (short2 left, Unity.Mathematics.int2 right) => left % (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (Unity.Mathematics.int2 left, short2 right) => (int2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (short2 left, Unity.Mathematics.float2 right) => left + (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 left, short2 right) => (float2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (short2 left, Unity.Mathematics.float2 right) => left - (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 left, short2 right) => (float2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (short2 left, Unity.Mathematics.float2 right) => left * (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 left, short2 right) => (float2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (short2 left, Unity.Mathematics.float2 right) => left / (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 left, short2 right) => (float2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (short2 left, Unity.Mathematics.float2 right) => left % (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 left, short2 right) => (float2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (short2 left, Unity.Mathematics.double2 right) => left + (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 left, short2 right) => (double2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (short2 left, Unity.Mathematics.double2 right) => left - (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 left, short2 right) => (double2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (short2 left, Unity.Mathematics.double2 right) => left * (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 left, short2 right) => (double2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (short2 left, Unity.Mathematics.double2 right) => left / (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 left, short2 right) => (double2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (short2 left, Unity.Mathematics.double2 right) => left % (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 left, short2 right) => (double2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 left, short2 right) => (short2)((ushort2)left & (ushort2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 left, short2 right) => (short2)((ushort2)left | (ushort2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 left, short2 right) => (short2)((ushort2)left ^ (ushort2)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short left, short2 right) => (short2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 left, short right) => left & (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short left, short2 right) => (short2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 left, short right) => left | (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short left, short2 right) => (short2)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 left, short right) => left ^ (short2)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (byte left, short2 right) => (short2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 left, byte right) => left & (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (byte left, short2 right) => (short2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 left, byte right) => left | (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (byte left, short2 right) => (short2)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 left, byte right) => left ^ (short2)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (sbyte left, short2 right) => (short2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 left, sbyte right) => left & (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (sbyte left, short2 right) => (short2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 left, sbyte right) => left | (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (sbyte left, short2 right) => (short2)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 left, sbyte right) => left ^ (short2)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (byte2 left, short2 right) => (short2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 left, byte2 right) => left & (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (byte2 left, short2 right) => (short2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 left, byte2 right) => left | (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (byte2 left, short2 right) => (short2)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 left, byte2 right) => left ^ (short2)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (sbyte2 left, short2 right) => (short2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 left, sbyte2 right) => left & (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (sbyte2 left, short2 right) => (short2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 left, sbyte2 right) => left | (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (sbyte2 left, short2 right) => (short2)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 left, sbyte2 right) => left ^ (short2)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (Unity.Mathematics.int2 left, short2 right) => (int2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (short2 left, Unity.Mathematics.int2 right) => left & (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (Unity.Mathematics.int2 left, short2 right) => (int2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (short2 left, Unity.Mathematics.int2 right) => left | (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (Unity.Mathematics.int2 left, short2 right) => (int2)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (short2 left, Unity.Mathematics.int2 right) => left ^ (int2)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return new short2((short)-x.x, (short)-x.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ++ (short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
			}
            else
            {
                return new short2((short)(x.x + 1), (short)(x.y + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator -- (short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
			}
            else
            {
                return new short2((short)(x.x - 1), (short)(x.y - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ~ (short2 x) => (short2)~(ushort2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator << (short2 x, int n) => (short2)((ushort2)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator >> (short2 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi16(x, n, inRange: true);
            }
            else
            {
                return new short2((short)(x.x >> n), (short)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, short2 right) => (ushort2)left == (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmplt_epi16(left, right);
            }
            else
            {
                return new mask16x2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpgt_epi16(left, right);
            }
            else
            {
                return new mask16x2(left.x > right.x, left.y > right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, short2 right) => (ushort2)left != (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.not_si128(Xse.cmpgt_epi16(left, right));
            }
            else
            {
                return new mask16x2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.not_si128(Xse.cmplt_epi16(left, right));
			}
            else
            {
                return new mask16x2(left.x >= right.x, left.y >= right.y);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, byte right) => left == (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (byte left, short2 right) => (short)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, byte right) => left != (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (byte left, short2 right) => (short)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, byte right) => left < (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (byte left, short2 right) => (short)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, byte right) => left > (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (byte left, short2 right) => (short)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, byte right) => left <= (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (byte left, short2 right) => (short)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, byte right) => left >= (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (byte left, short2 right) => (short)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, sbyte right) => left == (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (sbyte left, short2 right) => (short)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, sbyte right) => left != (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (sbyte left, short2 right) => (short)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, sbyte right) => left < (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (sbyte left, short2 right) => (short)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, sbyte right) => left > (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (sbyte left, short2 right) => (short)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, sbyte right) => left <= (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (sbyte left, short2 right) => (short)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, sbyte right) => left >= (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (sbyte left, short2 right) => (short)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, short right) => left == (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short left, short2 right) => (short2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, short right) => left != (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short left, short2 right) => (short2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, short right) => left < (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short left, short2 right) => (short2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, short right) => left > (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short left, short2 right) => (short2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, short right) => left <= (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short left, short2 right) => (short2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, short right) => left >= (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short left, short2 right) => (short2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, byte2 right) => left == (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (byte2 left, short2 right) => (short2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, byte2 right) => left != (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (byte2 left, short2 right) => (short2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, byte2 right) => left < (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (byte2 left, short2 right) => (short2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, byte2 right) => left > (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (byte2 left, short2 right) => (short2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, byte2 right) => left <= (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (byte2 left, short2 right) => (short2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, byte2 right) => left >= (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (byte2 left, short2 right) => (short2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, sbyte2 right) => left == (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (sbyte2 left, short2 right) => (short2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, sbyte2 right) => left != (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (sbyte2 left, short2 right) => (short2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, sbyte2 right) => left < (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (sbyte2 left, short2 right) => (short2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, sbyte2 right) => left > (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (sbyte2 left, short2 right) => (short2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, sbyte2 right) => left <= (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (sbyte2 left, short2 right) => (short2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, sbyte2 right) => left >= (short2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (sbyte2 left, short2 right) => (short2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, Unity.Mathematics.int2 right) => left == (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.int2 left, short2 right) => (int2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, Unity.Mathematics.int2 right) => left != (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.int2 left, short2 right) => (int2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, Unity.Mathematics.int2 right) => left < (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.int2 left, short2 right) => (int2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, Unity.Mathematics.int2 right) => left > (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.int2 left, short2 right) => (int2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, Unity.Mathematics.int2 right) => left <= (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.int2 left, short2 right) => (int2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, Unity.Mathematics.int2 right) => left >= (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.int2 left, short2 right) => (int2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, Unity.Mathematics.half2 right) => left == (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.half2 left, short2 right) => (half2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, Unity.Mathematics.half2 right) => left != (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.half2 left, short2 right) => (half2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, Unity.Mathematics.half2 right) => left < (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.half2 left, short2 right) => (half2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, Unity.Mathematics.half2 right) => left > (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.half2 left, short2 right) => (half2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, Unity.Mathematics.half2 right) => left <= (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.half2 left, short2 right) => (half2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, Unity.Mathematics.half2 right) => left >= (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.half2 left, short2 right) => (half2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, Unity.Mathematics.float2 right) => left == (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.float2 left, short2 right) => (float2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, Unity.Mathematics.float2 right) => left != (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.float2 left, short2 right) => (float2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, Unity.Mathematics.float2 right) => left < (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.float2 left, short2 right) => (float2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, Unity.Mathematics.float2 right) => left > (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.float2 left, short2 right) => (float2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, Unity.Mathematics.float2 right) => left <= (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.float2 left, short2 right) => (float2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, Unity.Mathematics.float2 right) => left >= (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.float2 left, short2 right) => (float2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 left, Unity.Mathematics.double2 right) => left == (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.double2 left, short2 right) => (double2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 left, Unity.Mathematics.double2 right) => left != (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.double2 left, short2 right) => (double2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 left, Unity.Mathematics.double2 right) => left < (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.double2 left, short2 right) => (double2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 left, Unity.Mathematics.double2 right) => left > (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.double2 left, short2 right) => (double2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 left, Unity.Mathematics.double2 right) => left <= (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.double2 left, short2 right) => (double2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 left, Unity.Mathematics.double2 right) => left >= (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.double2 left, short2 right) => (double2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short2 other) => ((ushort2)this).Equals((ushort2)other);

        public override readonly bool Equals(object obj) => obj is short2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"short2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}