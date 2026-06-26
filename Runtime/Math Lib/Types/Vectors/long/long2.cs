using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class long2DebuggerProxy
    {
        public long x;
        public long y;

        public long2DebuggerProxy(long2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(long2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct long2 : IEquatable<long2>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        public ulong __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        public ulong __x1;
        
        public ref long x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long2* ptr = &this) { return ref *((long*)ptr +  0); } } }
        public ref long y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long2* ptr = &this) { return ref *((long*)ptr +  1); } } }


        public static long2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(long x, long y)
        {
            this = (long2)new ulong2((ulong)x, (ulong)y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(long xy)
        {
            this = (long2)new ulong2((ulong)xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(bool v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(bool2 v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(mask8x2 v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(mask16x2 v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(mask32x2 v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(mask64x2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(byte v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(byte2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(sbyte v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(sbyte2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(ushort v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(ushort2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(short v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(short2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(uint v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(uint2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(int v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(int2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(ulong v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(ulong2 v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(long2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(UInt128 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(Int128 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(quarter v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(quarter2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(half v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(half2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(float v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(float2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(double v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(double2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(quadruple v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(Unity.Mathematics.bool2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(Unity.Mathematics.uint2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(Unity.Mathematics.int2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(Unity.Mathematics.half v)
        {
            this = (long2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(Unity.Mathematics.half2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(Unity.Mathematics.float2 v)
        {
            this = (long2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2(Unity.Mathematics.double2 v)
        {
            this = (long2)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxx => (long4)((ulong2)this).xxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxy => (long4)((ulong2)this).xxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyx => (long4)((ulong2)this).xxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyy => (long4)((ulong2)this).xxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxx => (long4)((ulong2)this).xyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxy => (long4)((ulong2)this).xyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyx => (long4)((ulong2)this).xyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyy => (long4)((ulong2)this).xyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxx => (long4)((ulong2)this).yxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxy => (long4)((ulong2)this).yxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyx => (long4)((ulong2)this).yxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyy => (long4)((ulong2)this).yxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxx => (long4)((ulong2)this).yyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxy => (long4)((ulong2)this).yyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyx => (long4)((ulong2)this).yyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyy => (long4)((ulong2)this).yyyy;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxx => (long3)((ulong2)this).xxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxy => (long3)((ulong2)this).xxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xyx => (long3)((ulong2)this).xyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xyy => (long3)((ulong2)this).xyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yxx => (long3)((ulong2)this).yxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yxy => (long3)((ulong2)this).yxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyx => (long3)((ulong2)this).yyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyy => (long3)((ulong2)this).yyy;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 xx => (long2)((ulong2)this).xx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 xy { readonly get => (long2)((ulong2)this).xy;  set { ulong2 _this = (ulong2)this; _this.xy = (ulong2)value; this = (long2)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 yx { readonly get => (long2)((ulong2)this).yx;  set { ulong2 _this = (ulong2)this; _this.yx = (ulong2)value; this = (long2)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 yy => (long2)((ulong2)this).yy;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(long2 input) => (ulong2)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(v128 input) => (long2)(ulong2)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(bool2 x) => (long2)(mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(Unity.Mathematics.bool2 x) => (long2)(mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi64(x);
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(long2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(long2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(long2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(long2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(long2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(long2 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2(byte x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2(sbyte x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2(ushort x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2(short x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2(uint x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2(int x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(ulong x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(UInt128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(Int128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(quarter x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(half x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(float x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(double x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(quadruple x) => (long)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(Unity.Mathematics.half x) => (long2)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(Unity.Mathematics.half2 x) => (long2)(half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(Unity.Mathematics.float2 x) => (long2)(float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(Unity.Mathematics.double2 x) => (long2)(double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(Unity.Mathematics.uint2 x) => (long2)(uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(Unity.Mathematics.int2 x) => (long2)(int2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(long2 x) => (half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(long2 x) => (float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(long2 x) => (double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(long2 x) => (uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(long2 x) => (int2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(long input) => new long2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(ulong2 input) => *(long2*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(uint2 input) => (long2)(ulong2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(int2 input) => (long2)(ulong2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(float2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttps_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(double2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpd_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(long2 input) => (uint2)(ulong2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(long2 input) => (int2)(ulong2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_ps(input);
            }
            else
            {
                return new float2((float)input.x, (float)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_pd(input);
            }

            return new double2((double)input.x, (double)input.y);
        }


        public long this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (long)((ulong2)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ulong2 _this = (ulong2)this;
                _this[index] = (ulong)value;
                this = (long2)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, long2 right) => (long2)((ulong2)left + (ulong2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, long2 right) => (long2)((ulong2)left - (ulong2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, long2 right) => (long2)((ulong2)left * (ulong2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(left, right);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(left, right);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, byte right) => left + (byte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, ushort right) => left + (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, uint right) => left + (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, sbyte right) => left + (sbyte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, short right) => left + (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, int right) => left + (int2)right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 operator + (long2 left, long right) => left + (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, byte right) => left - (byte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, ushort right) => left - (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, uint right) => left - (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, sbyte right) => left - (sbyte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, short right) => left - (short2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, int right) => left - (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, long right) => left - (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, byte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, uint right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, sbyte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, short right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, int right) => right * left;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, long right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(right))
				{
					return new long2(left.x * right, left.y * right);
				}
			}

            return new long2(left.x * right, left.y * right);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (ushort2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (uint2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (sbyte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (short2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, int right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (int2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, long right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi64(left, right);
                }
            }

            return new long2(left.x / right, left.y / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (ushort2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (uint2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (sbyte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (short2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, int right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (int2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, long right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi64(left, right);
                }
            }

            return new long2(left.x % right, left.y % right);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (byte left, long2 right) => (byte2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (ushort left, long2 right) => (ushort2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (uint left, long2 right) => (uint2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (sbyte left, long2 right) => (sbyte2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (short left, long2 right) => (short2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (int left, long2 right) => (int2)left + right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 operator + (long left, long2 right) => (long2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (byte left, long2 right) => (byte2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (ushort left, long2 right) => (ushort2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (uint left, long2 right) => (uint2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (sbyte left, long2 right) => (sbyte2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (short left, long2 right) => (short2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (int left, long2 right) => (int2)left - right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 operator - (long left, long2 right) => (long2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (byte left, long2 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (ushort left, long2 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (uint left, long2 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (sbyte left, long2 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (short left, long2 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (int left, long2 right) => (long)left * right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 operator * (long left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (byte left, long2 right) => (byte2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (ushort left, long2 right) => (ushort2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (uint left, long2 right) => (uint2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (sbyte left, long2 right) => (sbyte2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (short left, long2 right) => (short2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (int left, long2 right) => (int2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long left, long2 right) => (long2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (byte left, long2 right) => (byte2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (ushort left, long2 right) => (ushort2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (uint left, long2 right) => (uint2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (sbyte left, long2 right) => (sbyte2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (short left, long2 right) => (short2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (int left, long2 right) => (int2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long left, long2 right) => (long2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, byte2 right) => left + (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (byte2 left, long2 right) => (long2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, byte2 right) => left - (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (byte2 left, long2 right) => (long2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (long2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (byte2 left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (byte2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(Xse.cvtepu8_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, byte2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(left, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (byte2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(Xse.cvtepu8_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, byte2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(left, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, ushort2 right) => left + (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (ushort2 left, long2 right) => (long2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, ushort2 right) => left - (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (ushort2 left, long2 right) => (long2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (long2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (ushort2 left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (ushort2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(Xse.cvtepu16_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, ushort2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(left, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (ushort2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(Xse.cvtepu16_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, ushort2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(left, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, uint2 right) => left + (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (uint2 left, long2 right) => (long2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, uint2 right) => left - (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (uint2 left, long2 right) => (long2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, uint2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (long2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (uint2 left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (uint2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(Xse.cvtepu32_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, uint2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(left, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (uint2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(Xse.cvtepu32_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, uint2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(left, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, sbyte2 right) => left + (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (sbyte2 left, long2 right) => (long2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, sbyte2 right) => left - (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (sbyte2 left, long2 right) => (long2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (long2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (sbyte2 left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (sbyte2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(Xse.cvtepi8_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, sbyte2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(left, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (sbyte2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(Xse.cvtepi8_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, sbyte2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(left, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, short2 right) => left + (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (short2 left, long2 right) => (long2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, short2 right) => left - (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (short2 left, long2 right) => (long2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, short2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (long2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (short2 left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (short2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(Xse.cvtepi16_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, short2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(left, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (short2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(Xse.cvtepi16_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, short2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(left, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, int2 right) => left + (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (int2 left, long2 right) => (long2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, int2 right) => left - (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (int2 left, long2 right) => (long2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, int2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (long2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (int2 left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (int2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(Xse.cvtepi32_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, int2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epi64(left, Xse.cvtepi32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new long2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (int2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(Xse.cvtepi32_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, int2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epi64(left, Xse.cvtepi32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new long2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, Unity.Mathematics.int2 right) => left + (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, Unity.Mathematics.int2 right) => left - (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, Unity.Mathematics.int2 right) => left * (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, Unity.Mathematics.int2 right) => left / (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, Unity.Mathematics.int2 right) => left % (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (Unity.Mathematics.int2 left, long2 right) => (int2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (Unity.Mathematics.int2 left, long2 right) => (int2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (Unity.Mathematics.int2 left, long2 right) => (int2)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (Unity.Mathematics.int2 left, long2 right) => (int2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (Unity.Mathematics.int2 left, long2 right) => (int2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (long2 left, Unity.Mathematics.uint2 right) => left + (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 left, Unity.Mathematics.uint2 right) => left - (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, Unity.Mathematics.uint2 right) => left * (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, Unity.Mathematics.uint2 right) => left / (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, Unity.Mathematics.uint2 right) => left % (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator + (Unity.Mathematics.uint2 left, long2 right) => (uint2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (Unity.Mathematics.uint2 left, long2 right) => (uint2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (Unity.Mathematics.uint2 left, long2 right) => (uint2)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (Unity.Mathematics.uint2 left, long2 right) => (uint2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (Unity.Mathematics.uint2 left, long2 right) => (uint2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (long2 left, Unity.Mathematics.float2 right) => left + (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (long2 left, Unity.Mathematics.float2 right) => left - (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (long2 left, Unity.Mathematics.float2 right) => left * (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (long2 left, Unity.Mathematics.float2 right) => left / (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (long2 left, Unity.Mathematics.float2 right) => left % (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 left, long2 right) => (float2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 left, long2 right) => (float2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 left, long2 right) => (float2)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 left, long2 right) => (float2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 left, long2 right) => (float2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (long2 left, Unity.Mathematics.double2 right) => left + (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (long2 left, Unity.Mathematics.double2 right) => left - (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (long2 left, Unity.Mathematics.double2 right) => left * (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (long2 left, Unity.Mathematics.double2 right) => left / (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (long2 left, Unity.Mathematics.double2 right) => left % (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 left, long2 right) => (double2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 left, long2 right) => (double2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 left, long2 right) => (double2)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 left, long2 right) => (double2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 left, long2 right) => (double2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, long2 right) => (long2)((ulong2)left & (ulong2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, long2 right) => (long2)((ulong2)left | (ulong2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, long2 right) => (long2)((ulong2)left ^ (ulong2)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, byte2 right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, byte2 right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, byte2 right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (byte2 left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (byte2 left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (byte2 left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, ushort2 right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, ushort2 right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, ushort2 right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (ushort2 left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (ushort2 left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (ushort2 left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, uint2 right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, uint2 right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, uint2 right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (uint2 left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (uint2 left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (uint2 left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, Unity.Mathematics.uint2 right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, Unity.Mathematics.uint2 right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, Unity.Mathematics.uint2 right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (Unity.Mathematics.uint2 left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (Unity.Mathematics.uint2 left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (Unity.Mathematics.uint2 left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, sbyte2 right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, sbyte2 right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, sbyte2 right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (sbyte2 left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (sbyte2 left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (sbyte2 left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, short2 right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, short2 right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, short2 right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (short2 left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (short2 left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (short2 left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, int2 right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, int2 right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, int2 right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (int2 left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (int2 left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (int2 left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, Unity.Mathematics.int2 right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, Unity.Mathematics.int2 right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, Unity.Mathematics.int2 right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (Unity.Mathematics.int2 left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (Unity.Mathematics.int2 left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (Unity.Mathematics.int2 left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, byte right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, byte right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, byte right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (byte left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (byte left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (byte left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, ushort right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, ushort right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, ushort right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (ushort left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (ushort left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (ushort left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, uint right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, uint right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, uint right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (uint left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (uint left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (uint left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, sbyte right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, sbyte right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, sbyte right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (sbyte left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (sbyte left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (sbyte left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, short right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, short right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, short right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (short left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (short left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (short left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, int right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, int right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, int right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (int left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (int left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (int left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, long right) => left & (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, long right) => left | (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, long right) => left ^ (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long left, long2 right) => (long2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long left, long2 right) => (long2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long left, long2 right) => (long2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator - (long2 x)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi64(x);
			}
			else
            {
				return new long2(-x.x, -x.y);
            }
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ++ (long2 x)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.inc_epi64(x);
			}
			else
			{
				return new long2(x.x + 1, x.y + 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator -- (long2 x)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.dec_epi64(x);
			}
			else
			{
				return new long2(x.x - 1, x.y - 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ~ (long2 x) => (long2)~(ulong2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator << (long2 x, int n) => (long2)((ulong2)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator >> (long2 x, int n)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.srai_epi64(x, n);
			}
			else
			{
				return new long2(x.x >> n, x.y >> n);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, long2 right) => (ulong2)left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cmplt_epi64(left, right);
			}
			else
			{
				return new mask64x2(left.x < right.x, left.y < right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cmpgt_epi64(left, right);
			}
			else
			{
				return new mask64x2(left.x > right.x, left.y > right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, long2 right) => (ulong2)left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.not_si128(Xse.cmpgt_epi64(left, right));
			}
			else
			{
				return new mask64x2(left.x <= right.x, left.y <= right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, long2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.not_si128(Xse.cmplt_epi64(left, right));
			}
			else
			{
				return new mask64x2(left.x >= right.x, left.y >= right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, byte right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (byte left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, byte right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (byte left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, byte right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (byte left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, byte right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (byte left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, byte right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (byte left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, byte right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (byte left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, ushort right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ushort left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, ushort right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ushort left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, ushort right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ushort left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, ushort right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ushort left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, ushort right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ushort left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, ushort right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ushort left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, uint right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (uint left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, uint right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (uint left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, uint right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (uint left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, uint right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (uint left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, uint right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (uint left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, uint right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (uint left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, sbyte right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (sbyte left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, sbyte right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (sbyte left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, sbyte right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (sbyte left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, sbyte right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (sbyte left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, sbyte right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (sbyte left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, sbyte right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (sbyte left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, short right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (short left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, short right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (short left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, short right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (short left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, short right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (short left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, short right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (short left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, short right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (short left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, int right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (int left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, int right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (int left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, int right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (int left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, int right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (int left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, int right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (int left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, int right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (int left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, long right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, long right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, long right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, long right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, long right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, long right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, byte2 right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (byte2 left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, byte2 right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (byte2 left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, byte2 right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (byte2 left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, byte2 right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (byte2 left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, byte2 right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (byte2 left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, byte2 right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (byte2 left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, ushort2 right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ushort2 left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, ushort2 right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ushort2 left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, ushort2 right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ushort2 left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, ushort2 right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ushort2 left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, ushort2 right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ushort2 left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, ushort2 right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ushort2 left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, uint2 right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (uint2 left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, uint2 right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (uint2 left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, uint2 right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (uint2 left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, uint2 right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (uint2 left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, uint2 right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (uint2 left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, uint2 right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (uint2 left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, Unity.Mathematics.uint2 right) => left == (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.uint2 left, long2 right) => (uint2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, Unity.Mathematics.uint2 right) => left != (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.uint2 left, long2 right) => (uint2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, Unity.Mathematics.uint2 right) => left < (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.uint2 left, long2 right) => (uint2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, Unity.Mathematics.uint2 right) => left > (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.uint2 left, long2 right) => (uint2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, Unity.Mathematics.uint2 right) => left <= (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.uint2 left, long2 right) => (uint2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, Unity.Mathematics.uint2 right) => left >= (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.uint2 left, long2 right) => (uint2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, sbyte2 right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (sbyte2 left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, sbyte2 right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (sbyte2 left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, sbyte2 right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (sbyte2 left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, sbyte2 right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (sbyte2 left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, sbyte2 right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (sbyte2 left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, sbyte2 right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (sbyte2 left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, short2 right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (short2 left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, short2 right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (short2 left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, short2 right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (short2 left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, short2 right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (short2 left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, short2 right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (short2 left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, short2 right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (short2 left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, int2 right) => left == (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (int2 left, long2 right) => (long2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, int2 right) => left != (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (int2 left, long2 right) => (long2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, int2 right) => left < (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (int2 left, long2 right) => (long2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, int2 right) => left > (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (int2 left, long2 right) => (long2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, int2 right) => left <= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (int2 left, long2 right) => (long2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, int2 right) => left >= (long2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (int2 left, long2 right) => (long2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, Unity.Mathematics.int2 right) => left == (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.int2 left, long2 right) => (int2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, Unity.Mathematics.int2 right) => left != (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.int2 left, long2 right) => (int2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, Unity.Mathematics.int2 right) => left < (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.int2 left, long2 right) => (int2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, Unity.Mathematics.int2 right) => left > (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.int2 left, long2 right) => (int2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, Unity.Mathematics.int2 right) => left <= (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.int2 left, long2 right) => (int2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, Unity.Mathematics.int2 right) => left >= (int2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.int2 left, long2 right) => (int2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, Unity.Mathematics.float2 right) => left == (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.float2 left, long2 right) => (float2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, Unity.Mathematics.float2 right) => left != (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.float2 left, long2 right) => (float2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, Unity.Mathematics.float2 right) => left < (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.float2 left, long2 right) => (float2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, Unity.Mathematics.float2 right) => left > (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.float2 left, long2 right) => (float2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, Unity.Mathematics.float2 right) => left <= (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.float2 left, long2 right) => (float2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, Unity.Mathematics.float2 right) => left >= (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.float2 left, long2 right) => (float2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (long2 left, Unity.Mathematics.double2 right) => left == (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.double2 left, long2 right) => (double2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (long2 left, Unity.Mathematics.double2 right) => left != (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.double2 left, long2 right) => (double2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (long2 left, Unity.Mathematics.double2 right) => left < (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.double2 left, long2 right) => (double2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (long2 left, Unity.Mathematics.double2 right) => left > (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.double2 left, long2 right) => (double2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (long2 left, Unity.Mathematics.double2 right) => left <= (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.double2 left, long2 right) => (double2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (long2 left, Unity.Mathematics.double2 right) => left >= (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.double2 left, long2 right) => (double2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2 other) => ((ulong2)this).Equals((ulong2)other);

        public override readonly bool Equals(object obj) => obj is long2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"long2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"long2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}