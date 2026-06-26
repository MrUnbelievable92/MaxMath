using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class byte2DebuggerProxy
    {
        public byte x;
        public byte y;

        public byte2DebuggerProxy(byte2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(byte2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct byte2 : IEquatable<byte2>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ushort __x0;
        
        public ref byte x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte2* ptr = &this) { return ref *((byte*)ptr +  0); } } }
        public ref byte y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte2* ptr = &this) { return ref *((byte*)ptr +  1); } } }


        public static byte2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte x, byte y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)y, (sbyte)x);
            }
            else
            {
                __x0 = Uninitialized<ushort>.Create();

                this.x = x;
                this.y = y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte xy)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set1_epi8(xy, 2);
            }
            else
            {
                __x0 = Uninitialized<ushort>.Create();

                this.x = this.y = xy;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(bool v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(bool2 v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(mask8x2 v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(mask16x2 v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(mask32x2 v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(mask64x2 v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(sbyte v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(sbyte2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(ushort v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(ushort2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(short v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(short2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(uint v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(uint2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(int v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(int2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(ulong v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(ulong2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(long v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(long2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(UInt128 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(Int128 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(quarter v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(quarter2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(half v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(half2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(float v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(float2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(double v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(double2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(quadruple v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(Unity.Mathematics.bool2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(Unity.Mathematics.uint2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(Unity.Mathematics.int2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(Unity.Mathematics.half v)
        {
            this = (byte2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(Unity.Mathematics.half2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(Unity.Mathematics.float2 v)
        {
            this = (byte2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(Unity.Mathematics.double2 v)
        {
            this = (byte2)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
		public byte4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxxx(this);
                }
                else
                {
                    return new byte4(x, x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxxy(this);
                }
                else
                {
                    return new byte4(x, x, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxyx(this);
                }
                else
                {
                    return new byte4(x, x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxyy(this);
                }
				else
				{
					return new byte4(x, x, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyxx(this);
                }
                else
                {
                    return new byte4(x, y, x, x);
                }
            }
        }
		public byte4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyxy(this);
                }
				else
				{
					return new byte4(x, y, x, y);
				}
			}
		}
		public byte4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyyx(this);
                }
                else
                {
                    return new byte4(x, y, y, x);
                }
            }
        }
		public byte4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyyy(this);
                }
                else
                {
                    return new byte4(x, y, y, y);
                }
            }
        }
		public byte4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxxx(this);
                }
                else
                {
                    return new byte4(y, x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxxy(this);
                }
                else
                {
                    return new byte4(y, x, x, y);
                }
            }
        }
		public byte4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxyx(this);
                }
                else
                {
                    return new byte4(y, x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxyy(this);
                }
                else
                {
                    return new byte4(y, x, y, y);
                }
            }
        }
		public byte4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyxx(this);
                }
                else
                {
                    return new byte4(y, y, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyxy(this);
                }
                else
                {
                    return new byte4(y, y, x, y);
                }
            }
        }
		public byte4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyyx(this);
                }
                else
                {
                    return new byte4(y, y, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyyy(this);
                }
                else
                {
                    return new byte4(y, y, y, y);
                }
            }
        }

		public byte3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxx(this);
                }
                else
                {
                    return new byte3(x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxy(this);
                }
                else
                {
                    return new byte3(x, x, y);
                }
            }
        }
		public byte3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyx(this);
                }
                else
                {
                    return new byte3(x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyy(this);
                }
                else
                {
                    return new byte3(x, y, y);
                }
            }
        }
		public byte3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxx(this);
                }
                else
                {
                    return new byte3(y, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxy(this);
                }
                else
                {
                    return new byte3(y, x, y);
                }
            }
        }
		public byte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyx(this);
                }
                else
                {
                    return new byte3(y, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyy(this);
                }
                else
                {
                    return new byte3(y, y, y);
                }
            }
        }

		public byte2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xx(this);
                }
                else
                {
                    return new byte2(x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xy(this);
                }
                else
                {
                    return new byte2(x, y);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blend_epi16(this, value, 0b01);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
				}
			}
        }
		public byte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yx(this);
                }
                else
                {
                    return new byte2(y, x);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blend_epi16(this, value.yx, 0b01);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
				}
			}
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yy(this);
                }
                else
                {
                    return new byte2(y, y);
                }
            }
        }
		#endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte2 input)
        {
            v128 result;
            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                result = Uninitialized<v128>.Create();
            }

            result.UShort0 = input.__x0;
            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(v128 input) => new byte2 { __x0 = input.UShort0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(bool2 x) => (byte2)(mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(Unity.Mathematics.bool2 x) => (byte2)(mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte2)(mask8x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte2)(mask8x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte2)(mask8x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(byte2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(byte2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(byte2 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(byte2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(byte2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(byte2 x) => (mask8x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(sbyte x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(ushort x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(short x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(uint x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(int x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(ulong x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(long x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(UInt128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(Int128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(quarter x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(half x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(float x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(double x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(quadruple x) => (byte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(Unity.Mathematics.half x) => (byte2)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(Unity.Mathematics.half2 x) => (byte2)(half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(Unity.Mathematics.float2 x) => (byte2)(float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(Unity.Mathematics.double2 x) => (byte2)(double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(Unity.Mathematics.uint2 x) => (byte2)(uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(Unity.Mathematics.int2 x) => (byte2)(int2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half2(byte2 x) => (half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(byte2 x) => (float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(byte2 x) => (double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint2(byte2 x) => (uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2(byte2 x) => (int2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(byte input) => new byte2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(sbyte2 input) => *(byte2*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi8(input, 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi8(input, 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(int2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi8(input, 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(uint2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi8(input, 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_epi8(input);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_epi8(input);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(float2 input) => (byte2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(double2 input) => (byte2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi16(input);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi16(input);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi32(input);
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi32(input);
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_ps(input);
            }
            else
            {
                return (float2)(int2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(byte2 input) => (double2)(int2)input;

        
        public byte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
					    return Xse.extract_epi8(this, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (byte2* ptr = &this)
                    {
                        return ((byte*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<byte2, byte>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
						this = Xse.insert_epi8(this, value, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (byte2* ptr = &this)
                    {
                        ((byte*)ptr)[index] = value;
                    }
                }
                else
                {
                    this.SetField(value, index);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator + (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.add_epi8(left, right);
            }
            else
            {
                return new byte2((byte)(left.x + right.x), (byte)(left.y + right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator - (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sub_epi8(left, right);
            }
            else
            {
                return new byte2((byte)(left.x - right.x), (byte)(left.y - right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi8(left, right, 2);
            }
            else
            {
                return new byte2((byte)(left.x * right.x), (byte)(left.y * right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu8(left, right, 2);
            }
            else
            {
                return new byte2((byte)(left.x / right.x), (byte)(left.y / right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu8(left, right, 2);
            }
            else
            {
                return new byte2((byte)(left.x % right.x), (byte)(left.y % right.y));
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator + (byte2 left, byte right) => left + (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator + (byte left, byte2 right) => (byte2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator - (byte2 left, byte right) => left - (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator - (byte left, byte2 right) => (byte2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte left, byte2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte2 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epu8(left, right, 2);
                }
            }

            return left * (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.constdiv_epu8(left, right, 2);
                }
            }

            return left / (byte2)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte left, byte2 right) => (byte2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.constrem_epu8(left, right, 2);
                }
            }

            return left % (byte2)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte left, byte2 right) => (byte2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (byte2 left, Unity.Mathematics.int2 right) => left + (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (Unity.Mathematics.int2 left, byte2 right) => (int2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (byte2 left, Unity.Mathematics.int2 right) => left - (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (Unity.Mathematics.int2 left, byte2 right) => (int2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (byte2 left, Unity.Mathematics.int2 right) => left * (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (Unity.Mathematics.int2 left, byte2 right) => (int2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (byte2 left, Unity.Mathematics.int2 right) => left / (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (Unity.Mathematics.int2 left, byte2 right) => (int2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (byte2 left, Unity.Mathematics.int2 right) => left % (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (Unity.Mathematics.int2 left, byte2 right) => (int2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (byte2 left, Unity.Mathematics.uint2 right) => left + (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (byte2 left, Unity.Mathematics.uint2 right) => left - (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (byte2 left, Unity.Mathematics.uint2 right) => left * (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (byte2 left, Unity.Mathematics.uint2 right) => left / (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (byte2 left, Unity.Mathematics.uint2 right) => left % (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (byte2 left, Unity.Mathematics.float2 right) => left + (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 left, byte2 right) => (float2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (byte2 left, Unity.Mathematics.float2 right) => left - (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 left, byte2 right) => (float2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (byte2 left, Unity.Mathematics.float2 right) => left * (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 left, byte2 right) => (float2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (byte2 left, Unity.Mathematics.float2 right) => left / (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 left, byte2 right) => (float2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (byte2 left, Unity.Mathematics.float2 right) => left % (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 left, byte2 right) => (float2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (byte2 left, Unity.Mathematics.double2 right) => left + (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 left, byte2 right) => (double2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (byte2 left, Unity.Mathematics.double2 right) => left - (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 left, byte2 right) => (double2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (byte2 left, Unity.Mathematics.double2 right) => left * (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 left, byte2 right) => (double2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (byte2 left, Unity.Mathematics.double2 right) => left / (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 left, byte2 right) => (double2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (byte2 left, Unity.Mathematics.double2 right) => left % (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 left, byte2 right) => (double2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator & (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x & right.x), (byte)(left.y & right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator | (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x | right.x), (byte)(left.y | right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ^ (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x ^ right.x), (byte)(left.y ^ right.y));
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator & (byte2 left, byte right) => left & (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator & (byte left, byte2 right) => (byte2)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator | (byte2 left, byte right) => left | (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator | (byte left, byte2 right) => (byte2)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ^ (byte2 left, byte right) => left ^ (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ^ (byte left, byte2 right) => (byte2)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (byte2 left, Unity.Mathematics.int2 right) => left & (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (Unity.Mathematics.int2 left, byte2 right) => (int2)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (byte2 left, Unity.Mathematics.int2 right) => left | (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (Unity.Mathematics.int2 left, byte2 right) => (int2)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (byte2 left, Unity.Mathematics.int2 right) => left ^ (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (Unity.Mathematics.int2 left, byte2 right) => (int2)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (byte2 left, Unity.Mathematics.uint2 right) => left & (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (byte2 left, Unity.Mathematics.uint2 right) => left | (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (byte2 left, Unity.Mathematics.uint2 right) => left ^ (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ++ (byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new byte2((byte)(x.x + 1), (byte)(x.y + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator -- (byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new byte2((byte)(x.x - 1), (byte)(x.y - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ~ (byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new byte2((byte)~x.x, (byte)~x.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator << (byte2 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.slli_epi8(x, n, inRange: true);
            }
            else
            {
                return new byte2((byte)(x.x << n), (byte)(x.y << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator >> (byte2 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi8(x, n, inRange: true);
            }
            else
            {
                return new byte2((byte)(x.x >> n), (byte)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_epi8(left, right);
            }
            else
            {
                return new mask8x2(left.x == right.x, left.y == right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epu8(left, right, 2);
            }
            else
            {
                return new mask8x2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epu8(left, right, 2);
            }
            else
            {
                return new mask8x2(left.x > right.x, left.y > right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpeq_epi8(left, right));
            }
            else
            {
                return new mask8x2(left.x != right.x, left.y != right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_epu8(left, right, 8);
            }
            else
            {
                return new mask8x2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (byte2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_epu8(left, right, 8);
            }
            else
            {
                return new mask8x2(left.x >= right.x, left.y >= right.y);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (byte2 left, byte right) => left == (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (byte left, byte2 right) => (byte2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (byte2 left, byte right) => left != (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (byte left, byte2 right) => (byte2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (byte2 left, byte right) => left < (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (byte left, byte2 right) => (byte2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (byte2 left, byte right) => left > (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (byte left, byte2 right) => (byte2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (byte2 left, byte right) => left <= (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (byte left, byte2 right) => (byte2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (byte2 left, byte right) => left >= (byte2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (byte left, byte2 right) => (byte2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (byte2 left, Unity.Mathematics.int2 right) => left == (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.int2 left, byte2 right) => (int2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (byte2 left, Unity.Mathematics.int2 right) => left != (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.int2 left, byte2 right) => (int2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (byte2 left, Unity.Mathematics.int2 right) => left < (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.int2 left, byte2 right) => (int2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (byte2 left, Unity.Mathematics.int2 right) => left > (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.int2 left, byte2 right) => (int2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (byte2 left, Unity.Mathematics.int2 right) => left <= (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.int2 left, byte2 right) => (int2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (byte2 left, Unity.Mathematics.int2 right) => left >= (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.int2 left, byte2 right) => (int2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (byte2 left, Unity.Mathematics.uint2 right) => left == (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (byte2 left, Unity.Mathematics.uint2 right) => left != (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (byte2 left, Unity.Mathematics.uint2 right) => left < (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (byte2 left, Unity.Mathematics.uint2 right) => left > (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (byte2 left, Unity.Mathematics.uint2 right) => left <= (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (byte2 left, Unity.Mathematics.uint2 right) => left >= (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.uint2 left, byte2 right) => (uint2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (byte2 left, Unity.Mathematics.half2 right) => left == (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.half2 left, byte2 right) => (half2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (byte2 left, Unity.Mathematics.half2 right) => left != (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.half2 left, byte2 right) => (half2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (byte2 left, Unity.Mathematics.half2 right) => left < (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.half2 left, byte2 right) => (half2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (byte2 left, Unity.Mathematics.half2 right) => left > (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.half2 left, byte2 right) => (half2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (byte2 left, Unity.Mathematics.half2 right) => left <= (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.half2 left, byte2 right) => (half2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (byte2 left, Unity.Mathematics.half2 right) => left >= (half2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.half2 left, byte2 right) => (half2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (byte2 left, Unity.Mathematics.float2 right) => left == (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.float2 left, byte2 right) => (float2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (byte2 left, Unity.Mathematics.float2 right) => left != (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.float2 left, byte2 right) => (float2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (byte2 left, Unity.Mathematics.float2 right) => left < (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.float2 left, byte2 right) => (float2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (byte2 left, Unity.Mathematics.float2 right) => left > (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.float2 left, byte2 right) => (float2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (byte2 left, Unity.Mathematics.float2 right) => left <= (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.float2 left, byte2 right) => (float2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (byte2 left, Unity.Mathematics.float2 right) => left >= (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.float2 left, byte2 right) => (float2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (byte2 left, Unity.Mathematics.double2 right) => left == (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.double2 left, byte2 right) => (double2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (byte2 left, Unity.Mathematics.double2 right) => left != (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.double2 left, byte2 right) => (double2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (byte2 left, Unity.Mathematics.double2 right) => left < (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.double2 left, byte2 right) => (double2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (byte2 left, Unity.Mathematics.double2 right) => left > (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.double2 left, byte2 right) => (double2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (byte2 left, Unity.Mathematics.double2 right) => left <= (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.double2 left, byte2 right) => (double2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (byte2 left, Unity.Mathematics.double2 right) => left >= (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.double2 left, byte2 right) => (double2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte2 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return ushort.MaxValue == Xse.cmpeq_epi8(this, other).UShort0;
            }
            else
            {
                return this.x == other.x & this.y == other.y;
            }
        }

        public override bool Equals(object obj) => obj is byte2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"byte2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}