using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]  
    [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(byte))]  
    [DebuggerTypeProxy(typeof(byte2.DebuggerProxy))]
    unsafe public struct byte2 : IEquatable<byte2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public byte x;
            public byte y;

            public DebuggerProxy(byte2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] private fixed byte asArray[2];

        [FieldOffset(0)] public byte x;
        [FieldOffset(1)] public byte y;


        public static byte2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte x, byte y)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x) && Constant.IsConstantExpression(y))
                {
                    this = Sse2.cvtsi32_si128(bitfield(x, y));
                }
                else
                {
                    this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)y, (sbyte)x);
                }
            }
            else
            {
                this.x = x;
                this.y = y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte xy)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(xy))
                {
                    this = Sse2.cvtsi32_si128(bitfield(xy, xy));
                }
                else
                {
                    this = Sse2.set1_epi8((sbyte)xy);
                }
            }
            else
            {
                this.x = this.y = xy;
            }
        }

        
        #region Shuffle
		public readonly byte4 xxxx
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxxx(this);
                }
                else
                {
                    return new byte4(x, x, x, x);
                }
            }
        }
        public readonly byte4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxxy(this);
                }
                else
                {
                    return new byte4(x, x, x, y);
                }
            }
        }
        public readonly byte4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxyx(this);
                }
                else
                {
                    return new byte4(x, x, y, x);
                }
            }
        }
        public readonly byte4 xxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxyy(this);
                }
				else
				{
					return new byte4(x, x, y, y);
				}
			}
		}
        public readonly byte4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyxx(this);
                }
                else
                {
                    return new byte4(x, y, x, x);
                }
            }
        }
		public readonly byte4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyxy(this);
                }
				else
				{
					return new byte4(x, y, x, y);
				}
			}
		}
		public readonly byte4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyyx(this);
                }
                else
                {
                    return new byte4(x, y, y, x);
                }
            }
        }
		public readonly byte4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyyy(this);
                }
                else
                {
                    return new byte4(x, y, y, y);
                }
            }
        }
		public readonly byte4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxxx(this);
                }
                else
                {
                    return new byte4(y, x, x, x);
                }
            }
        }
        public readonly byte4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxxy(this);
                }
                else
                {
                    return new byte4(y, x, x, y);
                }
            }
        }
		public readonly byte4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxyx(this);
                }
                else
                {
                    return new byte4(y, x, y, x);
                }
            }
        }
        public readonly byte4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxyy(this);
                }
                else
                {
                    return new byte4(y, x, y, y);
                }
            }
        }
		public readonly byte4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyxx(this);
                }
                else
                {
                    return new byte4(y, y, x, x);
                }
            }
        }
        public readonly byte4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyxy(this);
                }
                else
                {
                    return new byte4(y, y, x, y);
                }
            }
        }
		public readonly byte4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyyx(this);
                }
                else
                {
                    return new byte4(y, y, y, x);
                }
            }
        }
        public readonly byte4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyyy(this);
                }
                else
                {
                    return new byte4(y, y, y, y);
                }
            }
        }

		public readonly byte3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxx(this);
                }
                else
                {
                    return new byte3(x, x, x);
                }
            }
        }
        public readonly byte3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxy(this);
                }
                else
                {
                    return new byte3(x, x, y);
                }
            }
        }
		public readonly byte3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyx(this);
                }
                else
                {
                    return new byte3(x, y, x);
                }
            }
        }
        public readonly byte3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyy(this);
                }
                else
                {
                    return new byte3(x, y, y);
                }
            }
        }
		public readonly byte3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxx(this);
                }
                else
                {
                    return new byte3(y, x, x);
                }
            }
        }
        public readonly byte3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxy(this);
                }
                else
                {
                    return new byte3(y, x, y);
                }
            }
        }
		public readonly byte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyx(this);
                }
                else
                {
                    return new byte3(y, y, x);
                }
            }
        }
        public readonly byte3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyy(this);
                }
                else
                {
                    return new byte3(y, y, y);
                }
            }
        }

		public readonly byte2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xx(this);
                }
                else
                {
                    return new byte2(x, x);
                }
            }
        }
        public          byte2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
		public          byte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
        
        public readonly byte2 yy
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get 
			{
                if (Sse2.IsSse2Supported)
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

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte2 input) => RegisterConversion.ToV128(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(v128 input) => RegisterConversion.ToType<byte2>(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(byte input) => new byte2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(sbyte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(byte2*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(short2 input)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(uint2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(long2 input)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi64_epi8(input);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(half2 input) => (byte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(float2 input) => (byte2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(double2 input) => (byte2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int2>(Xse.cvtepu8_epi32(input));
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.cvtepu8_epi32(input));
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepu8_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(byte2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float2>(Xse.cvtepu8_ps(input));
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
            readonly get
            {
Assert.IsWithinArrayBounds(index, 2);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                asArray[index] = value;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator + (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new byte2((byte)(left.x + right.x), (byte)(left.y + right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator - (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new byte2((byte)(left.x - right.x), (byte)(left.y - right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.rem_epu8(left, right, 2);
            }
            else
            {
                return new byte2((byte)(left.x % right.x), (byte)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte left, byte2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte2 left, byte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.mullo_epu8(left, right, 2);
                }
            }
            
            return left * (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 left, byte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
					return Xse.constexpr.div_epu8(left, right, 2);
                }
            }

            return left / (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 left, byte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
					return Xse.constexpr.rem_epu8(left, right, 2);
                }
            }

            return left % (byte2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator & (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x & right.x), (byte)(left.y & right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator | (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x | right.x), (byte)(left.y | right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ^ (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x ^ right.x), (byte)(left.y ^ right.y));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ++ (byte2 x)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi8(x, n);
            }
            else
            {
                return new byte2((byte)(x.x << n), (byte)(x.y << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator >> (byte2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srli_epi8(x, n);
            }
            else
            {
                return new byte2((byte)(x.x >> n), (byte)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool2>(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool2(left.x == right.x, left.y == right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool2>(Xse.cmplt_epu8(left, right, 2));
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool2>(Xse.cmpgt_epu8(left, right, 2));
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse8<bool2>(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool2(left.x != right.x, left.y != right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool2>(Xse.cmple_epu8(left, right, 8));
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool2>(Xse.cmpge_epu8(left, right, 8));
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }

    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte2 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return ushort.MaxValue == Sse2.cmpeq_epi8(this, other).UShort0;
            }
            else
            {
                return this.x == other.x & this.y == other.y;
            }
        }

        public override readonly bool Equals(object obj) => obj is byte2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse.IsSseSupported)
            {
                return ((v128)this).UShort0;
            }
            else
            {
                byte2 temp = this;

                return *(ushort*)&temp;
            }
        }


        public override readonly string ToString() => $"byte2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"byte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}